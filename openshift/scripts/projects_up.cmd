@echo off

if %1.==. (
	echo.
	echo Error!
	echo GitHub account name not supplied!
	echo.
	GOTO USAGE
)

set GitHubAccountName=%1
 
:Start
echo =============================================================================
echo Creating projects ...
echo =============================================================================
echo Creating tran-schoolbus-tools ...
oc new-project tran-schoolbus-tools --display-name="Schoolbus (tools)" --description="Ministry of Transportation Schoolbus Inspection System (tools)"

echo Creating tran-schoolbus-dev ...
oc new-project tran-schoolbus-dev --display-name="Schoolbus (dev)" --description="Ministry of Transportation Schoolbus Inspection System (dev)"

echo Creating tran-schoolbus-test ...
oc new-project tran-schoolbus-test --display-name="Schoolbus (test)" --description="Ministry of Transportation Schoolbus Inspection System (test)"

echo Creating tran-schoolbus-prod ...
oc new-project tran-schoolbus-prod --display-name="Schoolbus (prod)" --description="Ministry of Transportation Schoolbus Inspection System (prod)"

REM Import required image(s) into the tools project
echo =============================================================================
echo Configuring the tools project ...
echo =============================================================================
oc project tran-schoolbus-tools

echo Importing dotnet image ...
oc import-image dotnet --from=docker.io/microsoft/dotnet:1.1.0-sdk-projectjson --confirm

echo =============================================================================
echo Granting the deployment projects access to the images in the tools project ...
echo =============================================================================
echo Granting access to tran-schoolbus-dev ...
oc policy add-role-to-user system:image-puller system:serviceaccount:tran-schoolbus-dev:default -n tran-schoolbus-tools

echo Granting access to tran-schoolbus-test ...
oc policy add-role-to-user system:image-puller system:serviceaccount:tran-schoolbus-test:default -n tran-schoolbus-tools

echo Granting access to tran-schoolbus-prod ...
oc policy add-role-to-user system:image-puller system:serviceaccount:tran-schoolbus-prod:default -n tran-schoolbus-tools

echo =============================================================================
echo Configuring builds ...
echo =============================================================================
oc project tran-schoolbus-tools

echo Parsing the build template ...
oc process ^
-f https://raw.githubusercontent.com/%GitHubAccountName%/schoolbus/master/openshift/templates/schoolbus-build-template.json ^
-p SRC_REPO=https://github.com/%GitHubAccountName%/schoolbus.git ^
 > schoolbus-build.json

echo Processing the build template ...
oc create -f schoolbus-build.json

echo =============================================================================
echo Configuring dev deployments ...
echo =============================================================================
oc project tran-schoolbus-dev

echo Parsing the build template ...
oc process ^
-f https://raw.githubusercontent.com/%GitHubAccountName%/schoolbus/master/openshift/templates/schoolbus-deployment-template-emptydir.json ^
-p APP_DEPLOYMENT_TAG=dev ^
 > schoolbus-deployment-dev-emptydir.json

echo Processing the build template ...
oc create -f schoolbus-deployment-dev-emptydir.json 

echo =============================================================================
echo Configuring test deployments ...
echo =============================================================================
oc project tran-schoolbus-test

echo Parsing the build template ...
oc process ^
-f https://raw.githubusercontent.com/%GitHubAccountName%/schoolbus/master/openshift/templates/schoolbus-deployment-template-emptydir.json ^
-p APP_DEPLOYMENT_TAG=test ^
 > schoolbus-deployment-test-emptydir.json

echo Processing the build template ...
oc create -f schoolbus-deployment-test-emptydir.json 

echo =============================================================================
echo Configuring prod deployments ...
echo =============================================================================
oc project tran-schoolbus-prod

echo Parsing the build template ...
oc process ^
-f https://raw.githubusercontent.com/%GitHubAccountName%/schoolbus/master/openshift/templates/schoolbus-deployment-template-emptydir.json ^
-p APP_DEPLOYMENT_TAG=prod ^
 > schoolbus-deployment-prod-emptydir.json

echo Processing the build template ...
oc create -f schoolbus-deployment-prod-emptydir.json 

GOTO End1

:USAGE
echo =============================================================================
echo Script for setting up the OpenShift environment for the Schoolbus application
echo.
echo * Requires the OpenShift Origin CLI
echo -----------------------------------------------------------------------------
echo.
echo USAGE:  
echo projects_up GitHubAccountName
echo.
echo Where:
echo GitHubAccountName = The name of the GitHub account to use as the source repo.
echo.
echo Use 'bcgov' to connect to the main repository.
echo.
echo =============================================================================
echo.

:End1
