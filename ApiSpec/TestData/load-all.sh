#$/bin/bash

if [ -z "$1" ]; then
  echo Incorrect syntax
  echo USAGE $0 "<server URL>"
  echo Example: $0 dev
  echo "Where <server URL> is one of local, dev, test, prod or a full URL"
  exit
fi

# Before starting, remove the cookie authentication file.
# The ./load.sh script will add it if needed for the remainder of the calls
if [ -e cookie ]; then
  rm cookie
fi

# The order of the loading is important - need to add independent files before dependent ones
./load.sh cities/cities_city.json api/cities/bulk $1
./load.sh ServiceAreas/ServiceAreas_ServiceArea.json api/serviceareas/bulk $1
./load.sh schoolDistricts/schoolDistricts_SchoolDistrict.json api/schooldistricts/bulk $1
./load.sh OwnerContacts/OwnerContacts_Contact.json api/contacts/bulk $1
./load.sh Owners/Owners_SBOwner.json api/schoolbusowners/bulk $1
./load.sh SchoolBus/SchoolBus_SchoolBus.json api/schoolbuses/bulk $1
./load.sh CCW/CCW_CCW.json api/ccwdata/bulk $1
./load.sh Inspections/Inspections_Inspection.json api/inspections/bulk $1
