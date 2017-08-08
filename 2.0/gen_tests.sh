#!/bin/bash
#
# Generate the test tarballs for the runtime image
#
# PRE: Docker daemon running, s2i binary available,
#      Build image available
#
# Supported environment variables:
#
# -----------------------------------------------------
#
#  TEST_SRC_DIR     -> Where the test app source directories are.
#                      Defaults to ./build/test
#  TEST_TAR_DIR     -> Where the generated tarballs should go.
#                      Defaults to ./runtime/test
#  TEST_LIST        -> The list of apps to try and build tarballs for
#                      See the script for the defaults
#  BUILD_IMAGE      -> The tag of the build image to use to build the apps.
#                      Defaults to dotnet/dotnet-20-rhel7
#  TEST_COMMIT_HASH -> The commit hash to use to use to check if apps need to
#                      be rebuilt (and relinked).
#                      Defaults to the hash of the currently defined HEAD.
# -----------------------------------------------------
#

if [ "$DEBUG" != "" ]; then
  set -x
fi

TEST_SRC_DIR=${TEST_SRC_DIR:-`dirname $(readlink -m $0)`/build/test}
TEST_TAR_DIR=${TEST_TAR_DIR:-`dirname $(readlink -m $0)`/runtime/test}
TEST_LIST=${TEST_LIST:-hw_framework_config helloworld asp-net-hello-world}
BUILD_IMAGE=${BUILD_IMAGE:-dotnet/dotnet-20-rhel7}
TEST_COMMIT_HASH=${TEST_COMMIT_HASH:-`git rev-parse HEAD`}

info() {
  echo -e "\n\e[1m[INFO] $@\e[0m\n"
}

info "== Generating Test Tarballs =="
info "Test Source Dir: ${TEST_SRC_DIR}"
info "Tarball Destination: ${TEST_TAR_DIR}"

mkdir "${TEST_TAR_DIR}/apps"

# First build any apps that are missing and tar them up
for app in ${TEST_LIST}; do
  src_path="${TEST_SRC_DIR}/${app}"
  app_tar="${app}-${TEST_COMMIT_HASH}.tar.gz"

  if [ -f ${TEST_TAR_DIR}/${app_tar} ]; then
    info "Tar ${app_tar} already exists. Skipping."
    continue
  fi

  info "Generating ${app_tar}"

  tar_dir_mnt_path="/opt/tar"
  src_dir_mnt_path="/opt/src"
  test_image="${BUILD_IMAGE}-${app}"
  tar_cmd="tar -C /opt/app-root/publish -cvf ${tar_dir_mnt_path}/${app_tar} ."

  s2i build --force-pull=false "file://${src_path}" ${BUILD_IMAGE} ${test_image}
  docker run -v=${src_path}:${src_dir_mnt_path} -v=${TEST_TAR_DIR}:${tar_dir_mnt_path} --rm ${test_image} ${tar_cmd}
  docker rmi ${test_image}
done

# Create hard links to the current tests
for app in ${TEST_LIST}; do
  app_tar="${app}.tar.gz"
  app_commit_tar="${app}-${TEST_COMMIT_HASH}.tar.gz"

  info "Hard linking ${app_commit_tar} to '${TEST_TAR_DIR}/${app_tar}'"
  if [ -f ${TEST_TAR_DIR}/${app_tar} ]; then
    rm ${TEST_TAR_DIR}/${app_tar}
  fi
  ln ${TEST_TAR_DIR}/${app_commit_tar} ${TEST_TAR_DIR}/${app_tar}
done

info "Finished generating test tarballs."
