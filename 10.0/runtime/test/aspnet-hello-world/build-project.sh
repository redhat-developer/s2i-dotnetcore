#!/bin/bash

rm -rf bin obj

dotnet publish -f net9.0 -c Release

tar -czvf app.tar.gz -C bin/Release/net9.0/publish .
