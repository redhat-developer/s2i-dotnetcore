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
# VERSIONS     The list of versions to build/test.
#              Defaults to all versions. i.e "1.0 1.1".
# -----------------------------------------------------
#
# Usage:
#       $ sudo ./build.sh
#       $ sudo VERSIONS=1.0 ./build.sh
#

version_no_dot() {
  local version=$1
  echo ${version} | sed 's/\.//g'
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

VERSIONS="${VERSIONS:-1.0 1.1}"

for v in ${VERSIONS}; do
  v_no_dot="$( version_no_dot ${v} )"
  img_name="dotnet/dotnetcore-${v_no_dot}-rhel7"
  pushd ${v} &>/dev/null
    if ! image_exists ${img_name}; then
      echo "Building Docker image ${img_name} ..."
      docker build -f Dockerfile.rhel7 -t ${img_name} .
      check_result_msg $? "Building Docker image ${img_name} FAILED!"
    fi
    echo "Running tests on image ${img_name} ..."
    ./test/run
    check_result_msg $? "Tests for image ${img_name} FAILED!"
  popd &>/dev/null
done

if [ "$TEST_OPENSHIFT" = "true" ]; then
  for v in ${VERSIONS}; do
    v_no_dot="$( version_no_dot ${v} )"
    img_name="registry.access.redhat.com/dotnet/dotnetcore-${v_no_dot}-rhel7:latest"
    pushd ${v} &>/dev/null
      echo "Running tests on image ${img_name} ..."
      IMAGE_NAME="${img_name}" OPENSHIFT_ONLY=true ./test/run
      check_result_msg $? "Tests for image ${img_name} FAILED!"
    popd &>/dev/null
  done
fi

echo "ALL builds and tests were successful!"
exit 0
