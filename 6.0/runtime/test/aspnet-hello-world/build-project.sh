#!/bin/bash

rm -rf bin obj

dotnet publish -f net6.0 -c Release

tar -czvf app.tar.gz -C bin/Release/net6.0/publish .