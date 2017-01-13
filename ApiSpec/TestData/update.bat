@echo off
SET PYTHONCMD=C:\Python27\python.exe
for %%f in (in\*.csv) do (
echo %%~nf
%PYTHONCMD% csv2json.py in\%%~nf.csv yes
)