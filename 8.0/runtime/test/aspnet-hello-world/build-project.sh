#!/bin/bash

rm -rf bin obj

dotnet publish -f net7.0 -c Release

tar -czvf app-$(uname -m).tar.gz -C bin/Release/net7.0/publish .
