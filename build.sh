#!/bin/bash
#
# Build container images and run tests.

set -euo pipefail

print_usage()
{
    echo "Usage: $0 [<VERSION>...]"
    echo "Build Container images and run tests."
    echo ""
    echo "Arguments:"
    echo "  --base-os   <os>         Choose between different Dockerfiles"
    echo "  --continue-on-error      Don't stop executing tests when an error occurs"
    echo "  --no-build               Skip building the image"
    echo "  --no-test                Skip running the tests"
    echo "  --test-port <port>       Local TCP port used for tests"
    echo "  --debug                  Print the bash script commands before executing them"
    echo "  --dotnet-tarball <url>   Tarball containing a .NET SDK to be used instead of distro packages"
    echo "  --ci                     Indicates the build is a CI/dev version."
}

RUN_TESTS=true
DOTNET_TARBALL=
CI=false
DEBUG=
BASE_OS=
VERSIONS=""
TEST_PORT=8080
RUN_BUILD=true
STOP_ON_ERROR=true

while [ $# -ne 0 ]
do
    name="$1"
    case "$name" in
        --base-os)
            shift
            BASE_OS="$1"
            ;;
        --no-build)
            RUN_BUILD=false
            ;;
        --no-test)
            RUN_TESTS=false
            ;;
        --test-port)
            shift
            TEST_PORT="$1"
            ;;
        --dotnet-tarball)
            shift
            DOTNET_TARBALL="$1"
            ;;
        --debug)
            set -x
            DEBUG=true
            ;;
        --continue-on-error)
            STOP_ON_ERROR=false
            ;;
        --ci)
            CI=true
            ;;
        --github-ci)
            CI=true
            DEBUG=true
            STOP_ON_ERROR=false
            ;;
        --help)
            print_usage
            exit 0
            break
            ;;
        *)
            VERSIONS="$VERSIONS $1"
            ;;
    esac
    shift
done

VERSIONS=$(echo "$VERSIONS" | xargs)

# default to building the currently supported versions.
if [ -z "$VERSIONS" ]; then
  VERSIONS="6.0 8.0"
fi

# Use podman instead of docker when available.
if command -v podman >/dev/null; then
  docker() {
    podman "$@"
  }
fi

image_exists() {
  docker inspect $1 &>/dev/null
}

default_base_os_for_version() {
  local version=$1
  echo "rhel8"
}

os_image_prefix_for() {
  local version=$1
  local base_os=$2
  if [ "$base_os" == "rhel8" ]; then
    echo "ubi8"
  else
    echo "$base_os"
  fi
}

check_result_msg() {
  local retval=$1
  local msg=$2
  if [ ${retval} -ne 0 ]; then
    echo 1>&2 "${msg}"
    exit 1
  fi
}

build_image() {
  local path=$1
  local docker_filename=$2
  local name=$3

  if [ "$RUN_BUILD" == "false" ]; then
    return
  fi

  echo "Building Docker image ${name} ..."
  if [ ! -d "${path}" ]; then
    echo "No directory found at given location '${path}'. Skipping this image."
    return
  fi
  pushd ${path} &>/dev/null
    docker build --no-cache \
      --build-arg=DOTNET_TARBALL=$DOTNET_TARBALL \
      --build-arg=IS_CI=$CI \
      -f ${docker_filename} -t ${name} .
    check_result_msg $? "Building Docker image ${name} FAILED!"
  popd &>/dev/null
}

test_images() {
  local path=$1
  local base_os=$2
  local test_image=$3
  local runtime_image=$4

  if [ "$RUN_TESTS" == "false" ]; then
    return
  fi

  local image_os=$(echo "$base_os" | tr '[:lower:]' '[:upper:]')

  echo "Running tests..."
  STOP_ON_ERROR=$STOP_ON_ERROR DEBUG=$DEBUG IMAGE_OS=${image_os} SKIP_VERSION_CHECK=$CI IMAGE_NAME=${test_image} RUNTIME_IMAGE_NAME=${runtime_image} ${path}/run
  check_result_msg $? "Tests FAILED!"
}

for VERSION in ${VERSIONS}; do
  # use the specified BASE_OS, or default to the prefered os when unset.
  base_os_for_version="$BASE_OS"
  if [ -z "$base_os_for_version" ]; then
    base_os_for_version=$(default_base_os_for_version $VERSION)
  fi

  docker_filename="Dockerfile.$base_os_for_version"

  image_prefix=$(os_image_prefix_for $VERSION $base_os_for_version)
  version_no_dot=$(echo ${VERSION} | sed 's/\.//g')
  build_name="localhost/${image_prefix}/dotnet-$version_no_dot"
  runtime_name="localhost/${image_prefix}/dotnet-$version_no_dot-runtime"

  # Build the runtime image
  build_image "$VERSION/runtime" "${docker_filename}" "${runtime_name}"
  test_images "$VERSION/runtime/test" "$base_os_for_version" "${runtime_name}" "${runtime_name}"

  # Build the build image
  build_image "$VERSION/build" "${docker_filename}" "${build_name}"
  test_images "$VERSION/build/test" "$base_os_for_version" "${build_name}" "${runtime_name}"
done

echo "ALL builds and tests were successful!"
exit 0
