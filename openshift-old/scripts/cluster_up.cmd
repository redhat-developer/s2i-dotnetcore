@echo off
REM ==============================================================================
REM Script for setting up an OpenShift cluter in Docker for Windows
REM
REM * Requires the OpenShift Origin CLI
REM ------------------------------------------------------------------------------
REM
REM USAGE:  
REM cluster_up
REM
REM ==============================================================================

oc cluster up --host-data-dir=/var/lib/origin/data --use-existing-config