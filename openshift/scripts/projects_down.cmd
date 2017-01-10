@echo off
REM ==============================================================================
REM Script for taking down the OpenShift environment for the Schoolbus application
REM
REM * Requires the OpenShift Origin CLI
REM ------------------------------------------------------------------------------
REM
REM USAGE:  
REM projects_down
REM
REM ==============================================================================

oc delete project tran-schoolbus-tools
oc delete project tran-schoolbus-dev
oc delete project tran-schoolbus-test
oc delete project tran-schoolbus-prod