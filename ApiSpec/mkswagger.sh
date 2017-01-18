#!/bin/bash

if [ -z "$2" ]; then
	echo Error: not enough args
	echo Usage: $0 projectID files...
	echo Concatonates files into swagger.yaml file, copying the previous of swagger.yaml.bck
	exit 1
fi

prj=$1
shift
out=${prj}swagger.yaml
bck=${out}.bck

if [ -e ${bck} ]; then rm ${bck}; fi
if [ -e ${out} ]; then mv ${out} ${bck}; fi

while (( "$#" )); do
	if [ -e "$1" ]; then cat $1 >>${out}; fi
	shift
done
