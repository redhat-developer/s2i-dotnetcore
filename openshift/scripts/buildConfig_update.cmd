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

set SourceFileBase=https://raw.githubusercontent.com/%GitHubAccountName%/schoolbus/master/openshift/templates/
set SourceRepository=https://github.com/%GitHubAccountName%/schoolbus.git
set GitRef=master

if %2.==. (
	GOTO Start
)

set SourceFileBase=%2
 
:Start
echo =============================================================================
echo Updating the build configuration ...
echo =============================================================================
oc project %ToolsProjectName%

echo Parsing the build template from %SourceFileBase%...
oc process ^
-f %SourceFileBase%%BuildTemplate% ^
-p SRC_REPO=%SourceRepository% ^
-p GIT_REFERENCE=%GitRef% ^
 > %BuildConfiguration%

echo Processing the build template ...
oc replace -f %BuildConfiguration%

GOTO End1

:USAGE
echo =============================================================================
echo Script for updating the build configuration in the tools environment.
echo.
echo * Requires the OpenShift Origin CLI
echo -----------------------------------------------------------------------------
echo.
echo USAGE:  
echo buildConfig_update GitHubAccountName
echo.
echo Where:
echo GitHubAccountName = The name of the GitHub account to use as the source repo.
echo.
echo Use 'bcgov' to connect to the main repository.
echo.
echo =============================================================================
echo.

:End1
