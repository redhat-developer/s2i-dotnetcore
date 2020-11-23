#!/bin/bash
set -e

echo "---> Overwriting appsettings.json ..."
cp /opt/app-root/configmap/appsettings.json /opt/app-root/app/appsettings.json

# Execute the default S2I script
echo "---> Executing default s2i run script ..."
source ${STI_SCRIPTS_PATH}/run
