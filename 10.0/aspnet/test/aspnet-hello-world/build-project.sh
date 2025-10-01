#!/bin/bash

rm -rf bin obj

dotnet publish -f net10.0 -c Release

tar -czvf app.tar.gz -C bin/Release/net10.0/publish .
