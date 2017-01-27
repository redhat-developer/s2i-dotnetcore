SET TARGET_SERVER=http://localhost:59836

curl -c cookie %TARGET_SERVER%/api/authentication/dev/token?userId=

call load.bat "cities\cities_city.json" api/cities/bulk "%TARGET_SERVER%"
call load.bat "Regions\Regions_Region.json" api/regions/bulk "%TARGET_SERVER%"
call load.bat "Districts\Districts_District.json" api/districts/bulk "%TARGET_SERVER%"
call load.bat "ServiceAreas\ServiceAreas_ServiceArea.json" api/serviceareas/bulk "%TARGET_SERVER%"
call load.bat "schoolDistricts\schoolDistricts_SchoolDistrict.json" api/schooldistricts/bulk "%TARGET_SERVER%"

rem need to load owner contacts before owners.
call load.bat "OwnerContacts\OwnerContacts_Contact.json" api/contacts/bulk "%TARGET_SERVER%"
call load.bat "Owners\Owners_SBOwner.json" api/schoolbusowners/bulk "%TARGET_SERVER%"
call load.bat "SchoolBus\SchoolBus_SchoolBus.json" api/schoolbuses/bulk "%TARGET_SERVER%"

call load.bat "CCW\CCW_CCW.json" api/ccwdata/bulk %TARGET_SERVER%
call load.bat "Inspections\Inspections_Inspection.json" api/inspections/bulk %TARGET_SERVER%








