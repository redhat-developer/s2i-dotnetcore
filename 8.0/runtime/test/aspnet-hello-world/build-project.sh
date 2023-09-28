#!/bin/bash

rm -rf bin obj

dotnet publish -f net8.0 -c Release

tar -czvf app.tar.gz -C bin/Release/net8.0/publish .
