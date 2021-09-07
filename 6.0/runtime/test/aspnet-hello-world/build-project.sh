#!/bin/bash

rm -rf bin obj

dotnet publish -f net5.0 -c Release

tar -czvf app.tar.gz -C bin/Release/net5.0/publish .