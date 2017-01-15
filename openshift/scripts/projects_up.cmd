@echo off

if %1.==. (
	echo.
	echo Error!
	echo GitHub account name not supplied!
	echo.
	GOTO USAGE
)

set GitHubAccountName=%1
set BuildTemplate=schoolbus-build-template.json
set DeploymentTemplate=schoolbus-deployment-template.json

set BuildConfiguration=build-configuration.json
set DeploymentConfiguration=deployment-configuration.json

set ToolsProjectName=tran-schoolbus-tools
set DevProjectName=tran-schoolbus-dev
set TestProjectName=tran-schoolbus-test
set ProdProjectName=tran-schoolbus-prod

set SourceFileBase=https://raw.githubusercontent.com/%GitHubAccountName%/schoolbus/master/openshift/templates/
set SourceRepository=https://github.com/%GitHubAccountName%/schoolbus.git
set GitRef=master

REM set SourceFileBase=C:\schoolbus\openshift\templates\
REM set SourceRepository=https://github.com/%GitHubAccountName%/schoolbus.git
REM set GitRef=OpenShift_Scripts
 
:Start
echo =============================================================================
echo Creating projects ...
echo =============================================================================
echo Creating %ToolsProjectName% ...
oc new-project %ToolsProjectName% --display-name="Schoolbus (tools)" --description="Ministry of Transportation Schoolbus Inspection System (tools)"

echo Creating %DevProjectName% ...
oc new-project %DevProjectName% --display-name="Schoolbus (dev)" --description="Ministry of Transportation Schoolbus Inspection System (dev)"

echo Creating %TestProjectName% ...
oc new-project %TestProjectName% --display-name="Schoolbus (test)" --description="Ministry of Transportation Schoolbus Inspection System (test)"

echo Creating %ProdProjectName% ...
oc new-project %ProdProjectName% --display-name="Schoolbus (prod)" --description="Ministry of Transportation Schoolbus Inspection System (prod)"

echo =============================================================================
echo Granting the deployment projects access to the images in the tools project ...
echo =============================================================================
echo Granting access to %DevProjectName% ...
oc policy add-role-to-user system:image-puller system:serviceaccount:%DevProjectName%:default -n %ToolsProjectName%

echo Granting access to %TestProjectName% ...
oc policy add-role-to-user system:image-puller system:serviceaccount:%TestProjectName%:default -n %ToolsProjectName%

echo Granting access to %ProdProjectName% ...
oc policy add-role-to-user system:image-puller system:serviceaccount:%ProdProjectName%:default -n %ToolsProjectName%

echo =============================================================================
echo Configuring builds ...
echo =============================================================================
oc project %ToolsProjectName%

echo Parsing the build template ...
oc process ^
-f %SourceFileBase%%BuildTemplate% ^
-p SRC_REPO=%SourceRepository% ^
-p GIT_REFERENCE=%GitRef% ^
 > %BuildConfiguration%

echo Processing the build template ...
oc create -f %BuildConfiguration%

echo =============================================================================
echo Configuring dev deployments ...
echo =============================================================================
oc project %DevProjectName%

echo Parsing the build template ...
oc process ^
-f %SourceFileBase%%DeploymentTemplate% ^
-p APP_DEPLOYMENT_TAG=dev ^
 > %DeploymentConfiguration%

echo Processing the build template ...
oc create -f %DeploymentConfiguration% 

echo =============================================================================
echo Configuring test deployments ...
echo =============================================================================
oc project %TestProjectName%

echo Parsing the build template ...
oc process ^
-f %SourceFileBase%%DeploymentTemplate% ^
-p APP_DEPLOYMENT_TAG=test ^
 > %DeploymentConfiguration%

echo Processing the build template ...
oc create -f %DeploymentConfiguration% 

echo =============================================================================
echo Configuring prod deployments ...
echo =============================================================================
oc project %ProdProjectName%

echo Parsing the build template ...
oc process ^
-f %SourceFileBase%%DeploymentTemplate% ^
-p APP_DEPLOYMENT_TAG=prod ^
 > %DeploymentConfiguration%

echo Processing the build template ...
oc create -f %DeploymentConfiguration%

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
