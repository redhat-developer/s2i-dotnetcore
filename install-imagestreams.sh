#!/usr/bin/env bash

# Stop script on NZEC
set -e
# Stop script if unbound variable found (use ${var:-} if intentional)
set -u
# By default cmd1 | cmd2 returns exit code of cmd2 regardless of cmd1 success
# This is causing it to fail
set -o pipefail

if [ -t 1 ] && command -v tput > /dev/null; then
    # see if it supports colors
    ncolors=$(tput colors)
    if [ -n "$ncolors" ] && [ "$ncolors" -ge 8 ]; then
        normal="$(tput sgr0     || echo)"
        red="$(tput setaf 1     || echo)"
        yellow="$(tput setaf 3  || echo)"
    fi
fi

say_warning() {
    printf "%b\\n" "${yellow:-}Warning: $1${normal:-}"
}

say_err() {
    printf "%b\\n" "${red:-}Error: $1${normal:-}" >&2
}

say() {
    printf "%b\\n" "${normal:-}$1"
}

machine_has() {
    hash "$1" > /dev/null 2>&1
    return $?
}

show_help() {
    script_name="$(basename "$0")"
    echo "OpenShift .NET Core S2I Installer"
    echo "Usage: $script_name --os <os>"
    echo "       $script_name --rm"
    echo "       $script_name -h|-?|--help"
    echo ""
    echo "$script_name is a script for installing/updating/removing .NET S2I streams."
    echo ""
    echo "Options:"
    echo "  --o,--os                           Installs image streams based on this distro ('rhel7', 'rhel8', 'centos7', or 'fedora')."
    echo "  --n,--namespace                    Namespace to add imagestreams to. Defaults to current 'oc' project."
    echo "                                     Set this to 'openshift' to install globally (requires admin priviledges)."
    echo "  --rm                               Remove the image streams."
    echo "  --u,--user                         Username for pulling images from the registry."
    echo "  --p,--password                     Password for pulling images from the registry."
    echo "  -?,--?,-h,--help                   Shows this help message."
    echo ""
    echo "Credentials are required for the pulling the rhel7 images. If the project does not contain a secret"
    echo "for pulling the images yet, you can add one by specifying the '--user' and '--password' options."
    echo "For more information see: https://access.redhat.com/articles/3399531."
}

get_current_namespace() {
    local project
    if ! project=$(oc project -q 2>&1); then
        say_err "Cannot determine current oc namespace."
        exit 1
    fi
    echo "$project"
}

has_dotnet_imagestream() {
    local streams;
    if ! streams=$(oc get -n "$namespace" is dotnet 2>&1); then
        if [[ "$streams" == *"NotFound"* ]]; then
            return 1
        fi
        say_err "Cannot determine if the project already contains dotnet imagestreams."
        exit 1
    fi
    return 0
}

has_secret_for_registry() {
    local secret_names;
    if ! secret_names=$(oc get secret -o name -n "$namespace"); then
        say_err "Cannot retrieve secrets."
        exit 1
    fi
    for secret_name in $secret_names; do
        local secret secret_type
        secret=$(oc get "$secret_name" -o json -n "$namespace")
        secret_type=$(echo "$secret" | jq -r '.type')
        local data;
        case "$secret_type" in
            "kubernetes.io/dockercfg")
                data=$(echo "$secret" | jq -r '.data[".dockercfg"]')
                ;;
            "kubernetes.io/dockerconfigjson")
                data=$(echo "$secret" | jq -r '.data[".dockerconfigjson"]')
                ;;
            *)
                continue
                ;;
        esac
        data=$(echo "$data" | base64 --decode)
        if [[ "$data" == *"\"$registry\""* ]]; then
            return 0
        fi
    done
    return 1
}

oc_delete()
{
    local output;
    if ! output=$(oc delete "$@" -n "$namespace" 2>&1); then
        if [[ "$output" == *"NotFound"* ]]; then
            return 0
        fi
        say_err "Cannot delete $*: $output"
        return 1
    fi
    return 0
}

namespace=""
os=""
user=""
password=""
imagestreams_url=""
registry_requires_auth=false
registry=""
create_secret=false
pull_secret_name=redhat-registry-dotnet-install
remove=false

if [ $# -eq 0 ]; then
    show_help
    exit 0
fi

while [ $# -ne 0 ]
do
    name="$1"
    case "$name" in
        -n|--namespace)
            shift
            namespace="$1"
            ;;
        -o|--os)
            shift
            os="$1"
            case "$os" in
            "centos7")
                imagestreams_url="https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/dotnet_imagestreams_centos.json"
                registry_requires_auth=false
                ;;
            "rhel7")
                imagestreams_url="https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/dotnet_imagestreams.json"
                registry_requires_auth=true
                registry="registry.redhat.io"
                ;;
            "rhel8")
                imagestreams_url="https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/dotnet_imagestreams_rhel8.json"
                registry_requires_auth=false
                ;;
            "fedora")
                imagestreams_url="https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/dotnet_imagestreams_fedora.json"
                registry_requires_auth=false
                ;;
            *)
                say_err "Unsupported value for --os: '$os'. Valid values are 'centos7', 'rhel7', 'rhel8', and 'fedora'."
                exit 1
                ;;
            esac
            ;;
        -u|--user)
            shift
            user="$1"
            create_secret=true
            ;;
        -p|--password)
            shift
            password="$1"
            ;;
        --rm)
            remove=true
            ;;
        -\?|--\?|-h|--help)
            script_name="$(basename "$0")"
            show_help
            exit 0
            ;;
        *)
            say_err "Unknown argument \`$name\`"
            exit 1
            ;;
    esac
    shift
done

# Check prerequisite tools
prereq_ok=true
if ! machine_has "oc"; then
    say_err "oc is required to install image streams. Please install oc."
    prereq_ok=false
fi
if [ "$create_secret" == true ]; then
    if ! machine_has "jq"; then
        say_err "jq is required to check for configured secrets. Please install jq."
        prereq_ok=false
    fi
    if ! machine_has "base64"; then
        say_err "base64 is required to check for configured secrets. Please install base64."
        prereq_ok=false
    fi
fi
if [ "$prereq_ok" == false ]; then
    exit 1
fi

# Remove
if [ "$remove" == "true" ]; then
    say "Removing installed image streams."
    oc_delete is dotnet         | \
    oc_delete is dotnet-runtime | \
    oc_delete secret $pull_secret_name
    exit
fi

# The --os parameter is required.
if [ "$os" == "" ]; then
    say_err "The --os parameter is required."
    exit 1
fi

# Inform user he may need a pull secret
if [ "$create_secret" == false ] && [ "$registry_requires_auth" == true ]; then
    say "note: The image streams for $os require authentication against $registry. See '--help' for more info."
fi

# Determine namespace
if [ "$namespace" == "" ]; then
    namespace=$(get_current_namespace)
fi

# Create pull secret
if [ "$create_secret" == true ]; then
    if has_secret_for_registry; then
        say "A secret for the registry is already present in the namespace."
    else
        say "Creating a secret for authenticating with $registry:"
        oc create secret docker-registry $pull_secret_name -n "$namespace" \
        --docker-server="$registry" \
        --docker-username="$user" \
        --docker-password="$password" \
        --docker-email=unused
        oc secrets link default $pull_secret_name --for=pull -n "$namespace"
        oc secrets link builder $pull_secret_name -n "$namespace"
    fi
fi

# Install/update imagestreams
if has_dotnet_imagestream; then
    say "Updating image streams:"
    oc replace -n "$namespace" -f "$imagestreams_url"
else
    say "Installing image streams:"
    oc create -n "$namespace" -f "$imagestreams_url"
fi
