#!/bin/bash
#
# Build Docker images and run tests.
#
# PRE: Docker daemon running, s2i binary available.
#
# Supported environment variables:
#
# -----------------------------------------------------
# TEST_OPENSHIFT  If 'true' run tests to make sure
#                 released images work against the
#                 test application used in OpenShift
#
# VERSIONS        The list of versions to build/test.
#                 Defaults to all versions. i.e "3.1 6.0".
#
# IMAGE_OS        The base os image to use when building
#                 the containers.
#                 Options are CENTOS, RHEL7, RHEL8, and
#                 FEDORA.
#                 Defaults to match the OS.
#
# TEST_PORT       specifies the port on the docker host
#                 to bind to when creating containers
#                 during the asp.net tests. Affects
#                 tests only.
#
# FORCE           rebuild the containers even if they
#                 already exist.
# -----------------------------------------------------
#
# Usage:
#       $ sudo ./build.sh
#       $ sudo VERSIONS=3.1 ./build.sh
#

if [ "${DEBUG}" == "true" ]; then
  set -x
fi

FORCE=${FORCE:-false}

# Use podman instead of docker when available.
if command -v podman >/dev/null; then
  docker() {
    podman "$@"
  }
fi

base_image_name() {
  local version=$1
  local v_no_dot=$(echo ${version} | sed 's/\.//g')
  echo "dotnet-${v_no_dot}";
}

image_exists() {
  docker inspect $1 &>/dev/null
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
  if $FORCE || ! image_exists ${name}; then
    echo "Building Docker image ${name} ..."
    if [ ! -d "${path}" ]; then
      echo "No directory found at given location '${path}'. Skipping this image."
      return
    fi
    pushd ${path} &>/dev/null
      docker build --no-cache -f ${docker_filename} -t ${name} .
      check_result_msg $? "Building Docker image ${name} FAILED!"
    popd &>/dev/null
  fi
}

test_images() {
  local path=$1
  local test_image=$2
  local runtime_image=$3
  echo "Running tests..."
  IMAGE_NAME=${test_image} RUNTIME_IMAGE_NAME=${runtime_image} ${path}/run
  check_result_msg $? "Tests FAILED!"
}

if [ -z "${IMAGE_OS}" ]; then
  # Default to CentOS when not on RHEL.
  if [[ `grep "Red Hat Enterprise Linux Server release 7" /etc/redhat-release` ]]; then
    export IMAGE_OS="RHEL7"
  elif [[ `grep "Red Hat Enterprise Linux release 8" /etc/redhat-release` ]]; then
    export IMAGE_OS="RHEL8"
  elif [[ `grep "CentOS" /etc/redhat-release` ]]; then
    export IMAGE_OS="CENTOS"
  elif [[ `grep "Fedora" /etc/redhat-release` ]]; then
    export IMAGE_OS="FEDORA"
  else
    echo 1>&2 "Set IMAGE_OS to specify the base image."
    exit 1
  fi
fi

if [ "$IMAGE_OS" = "CENTOS" ]; then
  VERSIONS="${VERSIONS:-3.1}"
  image_postfix="-centos7"
  image_prefix="dotnet"
  docker_filename="Dockerfile"
elif [ "$IMAGE_OS" = "RHEL8" ]; then
  VERSIONS="${VERSIONS:-3.1 6.0 7.0}"
  image_prefix="ubi8"
  docker_filename="Dockerfile.rhel8"
elif [ "$IMAGE_OS" = "FEDORA" ]; then
  VERSIONS="${VERSIONS:-3.1 6.0 7.0}"
  image_prefix="fedora"
  docker_filename="Dockerfile.fedora"
else
  VERSIONS="${VERSIONS:-3.1}"
  image_postfix="-rhel7"
  image_prefix="dotnet"
  docker_filename="Dockerfile.rhel7"
fi

for v in ${VERSIONS}; do
  build_name="${image_prefix}/$(base_image_name ${v})${image_postfix}"
  runtime_name="${image_prefix}/$(base_image_name ${v})-runtime${image_postfix}"

  # Build the runtime image
  build_image "${v}/runtime" "${docker_filename}" "${runtime_name}"
  test_images "${v}/runtime/test" "${runtime_name}"

  # Build the build image
  build_image "${v}/build" "${docker_filename}" "${build_name}"
  test_images "${v}/build/test" "${build_name}" "${runtime_name}"

  if [ "$TEST_OPENSHIFT" = "true" ]; then
    build_name="registry.access.redhat.com/${build_name}:latest"
    runtime_name="registry.access.redhat.com/${runtime_name}:latest"
    pushd ${v} &>/dev/null
      echo "Running OpenShift tests on image ${runtime_name} ..."
      IMAGE_NAME="${runtime_name}" OPENSHIFT_ONLY=true ./runtime/test/run
      check_result_msg $? "Tests for image ${runtime_name} FAILED!"

      echo "Running OpenShift tests on image ${build_name} ..."
      IMAGE_NAME="${build_name}" RUNTIME_IMAGE_NAME="${runtime_name}" OPENSHIFT_ONLY=true ./build/test/run
      check_result_msg $? "Tests for image ${build_name} FAILED!"
    popd &>/dev/null
  fi
done

echo "ALL builds and tests were successful!"
exit 0
