#!/usr/bin/env bash

cd `dirname $0`
cd ..

projectdir=`pwd`
vmdir=/var/schoolbus-client

command='bash'

if [[ "$@"  != '' ]]; then
  command="$@"
fi

docker run \
  --rm \
  -w $vmdir \
  -v $projectdir:$vmdir:rw \
  -i \
  -t \
  bcgov/schoolbus.client \
  bash -c "$command"
