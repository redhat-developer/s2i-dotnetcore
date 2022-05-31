#!/bin/bash

# Test an imagestreams file by installing it into an OpenShift instance.
#

set -euo pipefail

if [[ "${DEBUG:-}" = "true" ]]; then
  set -x
fi

usage () {
  echo " Usage:"
  echo "      $0"
  echo "      IMAGE_OS=FEDORA $0"
  echo "      IMAGE_OS=RHEL REGISTRY_USERNAME=<user> REGISTRY_PASSWORD=<password> $0"
  echo ""
  echo "Test that the imagestreams file is valid by installing it into an OpenShift instance."
  echo ""
  echo "Requires: jq, oc"
  echo ""
  echo "Supported environment variables:"
  echo ""
  echo "-----------------------------------------------------"
  echo "VERSIONS            The list of expected versions."
  echo "                    Defaults to all versions. i.e '3.1 6.0'."
  echo ""
  echo "IMAGE_OS            The base os image to use when building"
  echo "                    the containers."
  echo "                    Options are CENTOS, RHEL, and"
  echo "                    FEDORA."
  echo "                    Defaults to match the OS."
  echo ""
  echo "REGISTRY_USERNAME   Optional username for accessing the"
  echo "                    registry. An empty value means credentials"
  echo "                    are not required."
  echo "                    Defaults to empty."
  echo ""
  echo "REGISTRY_PASSWORD   Optional password for accessing the"
  echo "                    registry. An empty value means credentials"
  echo "                    are not required."
  echo "                    Defaults to empty."
  echo ""
  echo "TIMEOUT             The timeout, in seconds, for applications"
  echo "                    to build and start running."
  echo "                    Defaults to 180."
  echo "-----------------------------------------------------"
  echo ""
}

if [[ $# -ge 1 ]]; then
  if [[ "$1" = '--help' ]]; then
    usage
    exit 0
  fi
  usage
  exit 1
fi

get_os() {
  if [[ -f /etc/os-release ]]; then
    source /etc/os-release
  elif [[ -f /usr/lib/os-release ]]; then
    source /usr/lib/os-release
  fi

  if [[ "$ID" = 'rhel' ]]; then
    version=${VERSION_ID%%.*}
    echo "RHEL${version}"
  elif [[ "$ID" = 'fedora' ]]; then
    echo "FEDORA"
  elif [[ "$ID" = 'centos' ]]; then
    version=${VERSION_ID%%.*}
    echo "CENTOS${version}"
  else
    echo 1>&2 "error: Set IMAGE_OS to specify the base image."
    exit 1
  fi
}

if [[ -z "$IMAGE_OS" ]]; then
  IMAGE_OS=$(get_os)
fi
IMAGE_OS=$(echo "$IMAGE_OS" | tr '[:upper:]' '[:lower:]')

case "$IMAGE_OS" in
"centos*")
  VERSIONS="${VERSIONS:-3.1}"
  imagestreams_file_name=dotnet_imagestreams_centos.json
  ;;
"fedora")
  VERSIONS="${VERSIONS:-3.1}"
  imagestreams_file_name=dotnet_imagestreams_fedora.json
  ;;
"rhel*")
  VERSIONS="${VERSIONS:-3.1 6.0}"
  imagestreams_file_name=dotnet_imagestreams.json
  ;;
*)
  echo 1>&2 "error: Unknown or unsupported OS '$IMAGE_OS'. Set the env var IMAGE_OS to override this."
  exit 1
  ;;
esac

if [[ -z "${TIMEOUT:-}" ]]; then
  TIMEOUT=180
fi

#
# Create a new project and load the imagestream to test in it
#

echo "Testing ${imagestreams_file_name}"

project_name=s2i-dotnetcore-imagestream-"$RANDOM"
oc new-project "$project_name" >/dev/null
install_arguments=(--os "$IMAGE_OS" -i "$imagestreams_file_name")
if [[ -n ${REGISTRY_USERNAME:-} ]]; then
  install_arguments+=(--user "$REGISTRY_USERNAME")
  install_arguments+=(--password "$REGISTRY_PASSWORD")
fi
./install-imagestreams.sh "${install_arguments[@]}"
oc_output="$(oc get -o json is | jq --raw-output '.items[].metadata.name')"
mapfile -t imagestreams <<< "$oc_output"


#
# Test
#
echo "Test: Making sure expected versions are present"
for imagestream in "${imagestreams[@]}"; do
  oc_output="$(oc get -o json is/"${imagestream}" | jq --raw-output '.spec.tags[] | .name')"
  mapfile -t known_versions <<< "$oc_output"
  for expected_version in ${VERSIONS}; do
    found=0
    for known_version in "${known_versions[@]}"; do
      if [[ "$known_version" = "$expected_version" ]]; then
        found=1
        break
      fi
    done
    if [[ $found = 0 ]]; then
      echo "FAIL: version '$expected_version' not found. Found versions were:" "${known_versions[@]}"
      exit 5
    fi
  done
  echo "PASS: ${imagestream} has expected all versions"
  echo "  Expected: ${VERSIONS}"
  echo "  Got: ${known_versions[*]}"
done


#
# Test
#
echo "Test: Making sure latest points to the latest version"

for imagestream in "${imagestreams[@]}"; do
  oc_output="$(oc get -o json is/"${imagestream}" | jq --raw-output '.spec.tags[] | .name, .from.name')"
  mapfile -t names_and_sources <<< "$oc_output"
  latest=0
  for index in $(seq 0 2 $(("${#names_and_sources[@]}"-1)) ); do
    name=${names_and_sources[$index]}
    from=${names_and_sources[$((index+1))]}

    if [[ $name = 'latest' ]]; then
      if [[ $from != "$latest" ]]; then
        echo "FAIL: 'latest' tag points to '$from', expected '$latest'."
        exit 5
      fi
    else
      if (( $(echo "$name > $latest" | bc -l ) )); then
        latest=$name
      fi
    fi
  done
  echo "PASS: ${imagestream} has 'latest' pointing to the highest version: $latest"
done


#
# Test
#
echo "Test: Making sure images resolve"

for imagestream in "${imagestreams[@]}"; do

  pass=false
  pause_time=1
  for _ in $(seq 1 "$pause_time" $TIMEOUT); do
    if { oc -o json import-image "${imagestream}" -o json || echo '{}'; } | jq '[.status.tags[] | select(.tag == "latest")] | length == 1' --exit-status >/dev/null 2>/dev/null ; then
      pass=true
      break
    fi
    sleep "$pause_time"
  done

  if [[ $pass = false ]]; then
    echo
    echo "FAIL: Unable to import-image ${imagestream}"
    exit 5
  fi

  oc_output="$(oc -o json import-image "${imagestream}" | jq --raw-output ' .status.tags[] | .tag, .items[0].image')"
  mapfile -t version_and_checksums <<< "$oc_output"
  for index in $(seq 0 2 $(("${#version_and_checksums[@]}"-1)) ); do
    version=${version_and_checksums[$index]}
    checksum=${version_and_checksums[$((index+1))]}

    if [[ "$checksum" != sha256:* ]]; then
      echo "FAIL: no checksum for $name found."
      exit 5
    fi

  echo "PASS: $imagestream $version has checksum $checksum"
  done
done


#
# Test
#
echo "Test: Sample Applications"

for version in ${VERSIONS}; do
  sample_apps=("s2i-dotnetcore-ex" "s2i-dotnetcore-persistent-ex")

  for application in "${sample_apps[@]}"; do
    application_source="dotnet:${version}~https://github.com/redhat-developer/${application}#dotnetcore-${version}"

    echo -n "Testing $application for .NET Core $version using $application_source "

    # Add the .NET Core application
    # all resources for this application automatically get the label app=$application
    oc new-app "$application_source" --context-dir=app  >/dev/null

    # Make the .NET Core application accessible externally and show the url
    oc expose service "$application" >/dev/null
    url=$(oc get -o json route "$application"| jq --raw-output '["http://", .spec.host] | join("")')

    pass=false
    pause_time=1
    for _ in $(seq 1 "$pause_time" $TIMEOUT); do
      if [[ "$(curl -s -o /dev/null -w "%{http_code}\n" "$url")" == 200 ]]; then
        pass=true
        break
      fi
      echo -n "."
      sleep "$pause_time"
    done

    if [[ $pass = false ]]; then
      echo
      echo "FAIL: Application was not available at ${url} within $TIMEOUT seconds"
      oc get all -l "app=$application"
      exit 5
    else
      echo " OK"
    fi

    oc delete all -l "app=$application" >/dev/null
  done
done
echo "PASS: All sample applications work."


oc delete project $project_name
