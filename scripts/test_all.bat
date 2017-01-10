SET TARGET_SERVER=http://localhost:53477

call load.bat "..\ApiSpec\TestData\Regions\Regions_Region.json" api/regions/bulk "%TARGET_SERVER%"
call load.bat "..\ApiSpec\TestData\Districts\Districts_District.json" api/districts/bulk "%TARGET_SERVER%"
call load.bat "..\ApiSpec\TestData\ServiceAreas\ServiceAreas_ServiceArea.json" api/serviceareas/bulk "%TARGET_SERVER%"
call load.bat "..\ApiSpec\TestData\schoolDistricts\schoolDistricts_SchoolDistrict.json" api/schooldistricts/bulk "%TARGET_SERVER%"
call load.bat "..\ApiSpec\TestData\Permissions\permissions_Perms.json" api/permissions/bulk "%TARGET_SERVER%"

call load.bat "..\ApiSpec\TestData\roles\roles_Role.json" api/roles/bulk "%TARGET_SERVER%"

rem need to load owner contacts before owners.
call load.bat "..\ApiSpec\TestData\OwnerContacts\OwnerContacts_Contact.json" api/schoolbusownercontacts/bulk "%TARGET_SERVER%"
call load.bat "..\ApiSpec\TestData\Owners\Owners_SBOwner.json" api/schoolbusowners/bulk "%TARGET_SERVER%"
call load.bat "..\ApiSpec\TestData\SchoolBus\SchoolBus_SchoolBus.json" api/schoolbuses/bulk "%TARGET_SERVER%"
call load.bat "..\ApiSpec\TestData\users\users_user.json" api/users/bulk "%TARGET_SERVER%"

rem needs endpoint
rem call load.bat "..\ApiSpec\TestData\userRole\userRole" api/users/bulk "%TARGET_SERVER%"
rem call load.bat "..\ApiSpec\TestData\userGroup\userGroup_userGroup.json" api/usergroups/bulk "%TARGET_SERVER%"

rem call load.bat "..\ApiSpec\TestData\rolepermission\rolepermission_RP.json" api/groups/bulk %TARGET_SERVER%

rem call load.bat "..\ApiSpec\TestData\CCW\CCW_CCW.json" api/ccwdata/bulk %TARGET_SERVER%

rem call load.bat "..\ApiSpec\TestData\group\group_Group.json" api/groups/bulk %TARGET_SERVER%








