#!/usr/bin/env bash

cd `dirname $0`
cd ..

OPTIND=1

port=8000
projectdir=`pwd`
vmdir=/var/schoolbus-client

function show_help() {
    echo "usage: start-dev.sh [-o]"
    echo "  -h      display this help and exit"
    echo "  -o      build and serve release version"
    echo "  -p      port to use"
}

while getopts "h?o?p:" opt; do
    case "$opt" in
    h|\?)
        show_help
        exit 0
        ;;
    p)  port=$OPTARG
        ;;
    esac
done

docker run \
  --rm \
  -it \
  -w $vmdir \
  -p $port:80 \
  -v $projectdir:$vmdir:rw \
  bcgov/schoolbus.client
