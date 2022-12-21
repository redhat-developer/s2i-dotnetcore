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
    echo "Usage: $script_name"
    echo "       $script_name --rm"
    echo "       $script_name -h|-?|--help"
    echo ""
    echo "$script_name is a script for installing/updating/removing .NET S2I streams."
    echo ""
    echo "Options:"
    echo "  --i,--imagestreams                 Installs the imagestreams from the given path."
    echo "  --n,--namespace                    Namespace to add imagestreams to. Defaults to current 'oc' project."
    echo "                                     Set this to 'openshift' to install globally (requires admin priviledges)."
    echo "  --rm                               Remove the image streams."
    echo "  -?,--?,-h,--help                   Shows this help message."
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
imagestreams_url="https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/dotnet_imagestreams.json"
remove=false

while [ $# -ne 0 ]
do
    name="$1"
    case "$name" in
        -n|--namespace)
            shift
            namespace="$1"
            ;;
        -i|--imagestreams)
            shift
            imagestreams_url="$1"
            ;;
        --rm)
            remove=true
            ;;
        -p|--password|-u|--user|-o|--os)
            shift
            say "The '$name' argument is obsolete and will be ignored. You can remove it from the command line."
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
if [ "$prereq_ok" == false ]; then
    exit 1
fi

# Remove
if [ "$remove" == "true" ]; then
    say "Removing installed image streams."
    oc_delete is dotnet         | \
    oc_delete is dotnet-runtime | \
    oc_delete secret redhat-registry-dotnet-install
    exit
fi

# Determine namespace
if [ "$namespace" == "" ]; then
    namespace=$(get_current_namespace)
fi

# Install/update imagestreams
if has_dotnet_imagestream; then
    say "Updating image streams:"
    oc replace -n "$namespace" -f "$imagestreams_url"
else
    say "Installing image streams:"
    oc create -n "$namespace" -f "$imagestreams_url"
fi
