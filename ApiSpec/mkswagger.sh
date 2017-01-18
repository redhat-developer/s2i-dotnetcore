#!/bin/bash

prj=SBI

if [ -z "$2" ]; then
	echo Error: not enough args
	echo Usage: $0 files...
	echo Concatonates files into the ${prj}swagger.yaml file, copying the previous version of ${PRJ}swagger.yaml.bck
	exit 1
fi

out=${prj}swagger.yaml
bck=${out}.bck

if [ -e ${bck} ]; then rm ${bck}; fi
if [ -e ${out} ]; then mv ${out} ${bck}; fi

while (( "$#" )); do
	if [ -e "$1" ]; then cat $1 >>${out}; fi
	shift
done
