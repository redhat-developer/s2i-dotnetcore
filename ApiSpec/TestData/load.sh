#$/bin/bash

local=http://frontend-tran-schoolbus-dev.10.0.75.2.nip.io
dev=http://server-tran-schoolbus-dev.pathfinder.gov.bc.ca
test=http://server-tran-schoolbus-test.pathfinder.gov.bc.ca

if [ -z "$3" ]; then
  echo Incorrect syntax
  echo USAGE $0 "<JSON filename> <endpoint> <server URL>"
  echo Example: $0 permissions/permissions_all.json permissions/bulk dev
  echo "Where <server URL> is one of local, dev, test or a full URL"
  echo Note: Do not put a / before the endpoint
  echo The local server is: $test
  echo The dev server is: $dev
  echo The test server is: $test
  exit
fi

server=$3
if [ $3 = "local" ]; then
   server=$local
fi
if [ $3 = "dev" ]; then
   server=$dev
fi
if [ $3 = "test" ]; then
   server=$test
fi

#
# if [ ! -f cookie ]; then
#   curl -c cookie ${server}/api/authentication/dev/token?userId=scurran
# fi

echo Loading File ${1} using endpoint ${server}/${2}
curl -b cookie -v -H "Content-Type: application/json" -X POST --data-binary "@${1}" ${server}/${2}
