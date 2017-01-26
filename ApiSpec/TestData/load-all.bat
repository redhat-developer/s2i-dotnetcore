SET TARGET_SERVER=http://localhost:59836
SET TARGET_SERVER=http://server-tran-schoolbus-dev.pathfinder.gov.bc.ca

curl -c cookie http://server-tran-schoolbus-dev.pathfinder.gov.bc.ca/api/authentication/dev/token?userId=

call load.bat "cities\cities_city.json" api/cities/bulk "%TARGET_SERVER%"
call load.bat "Regions\Regions_Region.json" api/regions/bulk "%TARGET_SERVER%"
call load.bat "Districts\Districts_District.json" api/districts/bulk "%TARGET_SERVER%"
call load.bat "ServiceAreas\ServiceAreas_ServiceArea.json" api/serviceareas/bulk "%TARGET_SERVER%"
call load.bat "schoolDistricts\schoolDistricts_SchoolDistrict.json" api/schooldistricts/bulk "%TARGET_SERVER%"
call load.bat "Permissions\permissions_Perms.json" api/permissions/bulk "%TARGET_SERVER%"

call load.bat "roles\roles_Role.json" api/roles/bulk "%TARGET_SERVER%"

rem need to load owner contacts before owners.
call load.bat "OwnerContacts\OwnerContacts_Contact.json" api/contacts/bulk "%TARGET_SERVER%"
call load.bat "Owners\Owners_SBOwner.json" api/schoolbusowners/bulk "%TARGET_SERVER%"
call load.bat "SchoolBus\SchoolBus_SchoolBus.json" api/schoolbuses/bulk "%TARGET_SERVER%"
call load.bat "users\users_user.json" api/users/bulk "%TARGET_SERVER%"

call load.bat "userRole\userRole_userRole.json" api/userroles/bulk "%TARGET_SERVER%"
call load.bat "userGroup\userGroup_userGroup.json" api/usergroups/bulk "%TARGET_SERVER%"

call load.bat "rolepermission\rolepermission_RP.json" /api/rolepermissions/bulk %TARGET_SERVER%

call load.bat "CCW\CCW_CCW.json" api/ccwdata/bulk %TARGET_SERVER%

call load.bat "group\group_Group.json" api/groups/bulk %TARGET_SERVER%

call load.bat "Inspections\Inspections_Inspection.json" api/inspections/bulk %TARGET_SERVER%








