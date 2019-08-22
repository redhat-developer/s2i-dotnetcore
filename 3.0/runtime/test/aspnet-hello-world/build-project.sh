#!/bin/bash

rm -rf bin obj

dotnet publish -f netcoreapp3.0 -c Release

tar -czvf app.tar.gz -C bin/Release/netcoreapp3.0/publish .