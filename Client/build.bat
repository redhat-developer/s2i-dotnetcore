@echo off
REM ===========================================================================
REM A batch file for automating the component installation and build
REM in a Windows environment.
REM ===========================================================================
call npm install

gulp --production
