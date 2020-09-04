#!/bin/bash

rm -rf bin obj

dotnet publish -f netcoreapp5.0 -c Release

tar -czvf app.tar.gz -C bin/Release/netcoreapp5.0/publish .