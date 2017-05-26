#!/bin/bash

# Setup initial variables
RUNTIME_BASE_IMAGE=${RUNTIME_BASE_IMAGE:-rhel7}
BUILD_IMAGE=$1
BINARY_TAR=publish.tar.gz
DOCKERFILE_TEMPLATE=${DOCKERFILE_TEMPLATE:-runtime-dockerfile-template}
# TODO: is here a way to get this from the build image?
DOTNET_PUBLISH_PATH=${DOTNET_PUBLISH_PATH:-/opt/app-root/publish}

# Check for missing files and images to fail early
if ! $(docker inspect ${BUILD_IMAGE} &> /dev/null); then
	echo "Could not locate a docker image by the name of '${BUILD_IMAGE}'."
	exit 1
fi
if ! $(docker inspect ${BUILD_IMAGE} &> /dev/null); then
	echo "Could not locate a docker image by the name of '${RUNTIME_BASE_IMAGE}'."
	exit 1
fi
if [ ! -e ${DOCKERFILE_TEMPLATE} ]; then
	echo "Could not locate runtime dockerfile file template."
	echo "It was expected to be '${DOCKERFILE_TEMPLATE}'"
	exit 1
fi

# Create the new runtime image name
if [[ ${BUILD_IMAGE} =~ : ]]
then
	RUNTIME_IMAGE_NAME=$(echo ${BUILD_IMAGE} | sed -e 's/:/-runtime:/' -)
else
	RUNTIME_IMAGE_NAME="${BUILD_IMAGE}-runtime"
fi

# Create a temp directory to hold our temporary files
TMPDIR=$(mktemp -d)
# TODO: Figure out a better way to allow access from the image /OTHER/ than 777
chmod 777 ${TMPDIR}
echo "Created temp directory ${TMPDIR}"

# create a subroutine to cleanup our tmp files
cleanup() {
	if [ -n ${TMPDIR} ] && [ -e ${TMPDIR} ]; then
		echo "Removing temp directory ${TMPDIR}"
		rm -rf ${TMPDIR}
	fi
}

RUNTIME_DOCKERFILE=${TMPDIR}/Dockerfile.rhel7.runtime

# Grab the build artifacts from the build image
docker run --rm --volume=${TMPDIR}:/opt/app-root/tmp:Z ${BUILD_IMAGE} tar zcvpf /opt/app-root/tmp/${BINARY_TAR} -C ${DOTNET_PUBLISH_PATH} .

if [ ! -e "${TMPDIR}/${BINARY_TAR}" ] || [ ! -s "${TMPDIR}/${BINARY_TAR}" ]; then
	echo "Failed to extract the publish directory from the build image '${BUILD_IMAGE}'."
	cleanup
	exit 1
fi

# We need to replace a number of 'tags' in the template
# So we'll loop through a matched pair of arrays for that
# TODO: Would it be worth it to see if we can make the dockerfile template
#       version generic using these tags?
tag_keys=(
	__RUNTIME_BASE_IMAGE__
	__BINARY_TAR__
	__DOTNET_PUBLISH_PATH__
)

declare -a tag_vals=(
	${RUNTIME_BASE_IMAGE}
	${BINARY_TAR}
	${DOTNET_PUBLISH_PATH}
)

cp ${DOCKERFILE_TEMPLATE} ${RUNTIME_DOCKERFILE}
for ((i=0;i<${#tag_keys[@]};++i)); do
	# Note the use of '|' instead of '/' as the regex separator
	# This is done because '/' is a common character in docker image names.
	sed -i "s|${tag_keys[$i]}|${tag_vals[$i]}|g" ${RUNTIME_DOCKERFILE}
done

# Prepare the tmp directory

# Copy other necessary files
cp -r root ${TMPDIR}/root
cp -r s2i ${TMPDIR}/s2i

# Build the runtime image
docker build -f ${RUNTIME_DOCKERFILE} -t ${RUNTIME_IMAGE_NAME} ${TMPDIR}

cleanup
