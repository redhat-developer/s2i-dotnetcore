#!/bin/bash

rm -rf bin obj

dotnet publish -f net11.0 -c Release

tar -czvf app.tar.gz -C bin/Release/net11.0/publish .
