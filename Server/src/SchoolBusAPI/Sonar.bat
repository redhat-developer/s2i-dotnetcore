@echo off
echo Running Sonar Tests
rem dotnet restore project.sonar.json
SonarQube.Scanner.MSBuild.exe begin /k:"GW_MOTI_SCHOOLBUS" /n:"GW_MOTI_SCHOOLBUS" /v:1.0
"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" /t:Rebuild Sonar.csproj
SonarQube.Scanner.MSBuild.exe end
rem start chrome https://sonarqube.com/code/?id=GW_MOTI_SCHOOLBUS



