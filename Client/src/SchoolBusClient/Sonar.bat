@echo off
echo Running Sonar Tests
dotnet restore
SonarQube.Scanner.MSBuild.exe begin /k:"GWTEST" /n:"GWTEST" /v:1.0
"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" /t:Rebuild Sonar.csproj
SonarQube.Scanner.MSBuild.exe end
start chrome https://sonarqube.com/code/?id=GWTEST



