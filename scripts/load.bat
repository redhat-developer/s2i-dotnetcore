@ECHO OFF
IF %1.==. GOTO No1
IF %2.==. GOTO No2

curl -v -H "Content-Type: application/json" -X POST --data-binary "@%1" %2
GOTO End1
:No1
  ECHO Please specify the location of the JSON file.
GOTO USAGE:
:No2
  ECHO Please specify the endpoint URL
GOTO USAGE:
:USAGE
  
ECHO load.bat <JSON filename> <endpoint>

:End1
