import store from './store';

import * as Action from './actionTypes';
import * as Constant from './constants';

import { daysFromToday, hoursAgo, sortableDateTime } from './utils/date';
import { ApiRequest } from './utils/http';
import { lastFirstName, firstLastName, concat } from './utils/string';

import _ from 'lodash';


////////////////////
// Users
////////////////////

function parseUser(user) {
  if (!user.district) { user.district = { id: '', name: '' }; }
  if (!user.userRoles) { user.userRoles = []; }
  if (!user.groupMemberships) { user.groupMemberships = []; }

  user.name = lastFirstName(user.surname, user.givenName);
  user.fullName = firstLastName(user.givenName, user.surname);
  user.districtName = user.district.name;

  user.groupNames = _.chain(user.groupMemberships).filter(membership => {
    return membership.group && membership.group.name;
  }).map(membership =>{
    return membership.group.name;
  }).sortBy(name =>{
    return name;
  }).join(', ').value();

  // This field is formatted to be used in updateUserGroups(), which expects
  // [ { groupId: 1 }, { groupId: 2 }, ... ]
  user.groupIds = _.filter(user.groupMemberships, membership => {
    return membership.group && membership.group.id;
  }).map(membership =>{
    return { groupId: membership.group.id };
  });

  _.each(user.userRoles, userRole =>{
    userRole.roleId = userRole.role && userRole.role.id ? userRole.role.id : 0;
    userRole.roleName = userRole.role && userRole.role.name ? userRole.role.name : '';
    userRole.effectiveDateSort = sortableDateTime(user.effectiveDate);
    userRole.expiryDateSort = sortableDateTime(user.expiryDate);
  });

  user.canEdit = true;
  user.canDelete = true;

  var inspectorGroupId = getInspectorGroupId();
  var isInspector = _.find(user.groupMemberships, membership => {
    return (membership.group && membership.group.id === inspectorGroupId);
  });
  user.isInspector = isInspector !== undefined;
}

export function getCurrentUser() {
  return new ApiRequest('/users/current').get().then(response => {
    var user = response;

    // Add display fields
    parseUser(user);

    store.dispatch({ type: Action.UPDATE_CURRENT_USER, user: user });
  });
}

export function searchUsers(params) {
  return new ApiRequest('/users/search').get(params).then(response => {
    // Normalize the response
    var users = _.fromPairs(response.map(user => [ user.id, user ]));

    // Add display fields
    _.map(users, user => { parseUser(user); });

    store.dispatch({ type: Action.UPDATE_USERS, users: users });
  });
}

export function getUsers() {
  return new ApiRequest('/users').get().then(response => {
    // Normalize the response
    var users = _.fromPairs(response.map(user => [ user.id, user ]));

    // Add display fields
    _.map(users, user => { parseUser(user); });

    store.dispatch({ type: Action.UPDATE_USERS, users: users });
  });
}

export function getUser(userId) {
  return new ApiRequest(`/users/${ userId }`).get().then(response => {
    var user = response;

    // Add display fields
    parseUser(user);

    store.dispatch({ type: Action.UPDATE_USER, user: user });
  });
}

export function addUser(user) {
  return new ApiRequest('/users').post(user).then(response => {
    var user = response;

    // Add display fields
    parseUser(user);

    store.dispatch({ type: Action.ADD_USER, user: user });
  });
}

export function updateUser(user) {
  return new ApiRequest(`/users/${ user.id }`).put(user).then(response => {
    var user = response;

    // Add display fields
    parseUser(user);

    store.dispatch({ type: Action.UPDATE_USER, user: user });
  });
}

export function deleteUser(user) {
  return new ApiRequest(`/users/${ user.id }/delete`).post().then(response => {
    var user = response;

    // Add display fields
    parseUser(user);

    store.dispatch({ type: Action.DELETE_USER, user: user });
  });
}

export function updateUserGroups(user) {
  return new ApiRequest(`/users/${ user.id }/groups`).put(user.groupIds).then(() => {
    // After updating the user's group, refresh the user state.
    return getUser(user.id);
  });
}

export function addUserRole(userId, userRole) {
  return new ApiRequest(`/users/${ userId }/roles`).post(userRole).then(() => {
    // After updating the user's role, refresh the user state.
    return getUser(userId);
  });
}

export function updateUserRoles(userId, userRoleArray) {
  return new ApiRequest(`/users/${ userId }/roles`).put(userRoleArray).then(() => {
    // After updating the user's role, refresh the user state.
    return getUser(userId);
  });
}

////////////////////
// Roles
////////////////////

function parseRole(role) {
  role.canEdit = true;
  role.canDelete = false;
}

export function searchRoles(params) {
  return new ApiRequest('/roles').get(params).then(response => {
    // Normalize the response
    var roles = _.fromPairs(response.map(role => [ role.id, role ]));

    // Add display fields
    _.map(roles, role => { parseRole(role); });

    store.dispatch({ type: Action.UPDATE_ROLES, roles: roles });
  });
}

export function addRole(role) {
  return new ApiRequest('/roles').post(role).then(response => {
    var role = response;

    // Add display fields
    parseRole(role);

    store.dispatch({ type: Action.ADD_ROLE, role: role });
  });
}

export function updateRole(role) {
  return new ApiRequest(`/roles/${ role.id }`).put(role).then(response => {
    var role = response;

    // Add display fields
    parseRole(role);

    store.dispatch({ type: Action.UPDATE_ROLE, role: role });
  });
}

export function deleteRole(role) {
  return new ApiRequest(`/roles/${ role.id }/delete`).post().then(response => {
    var role = response;

    // Add display fields
    parseRole(role);

    store.dispatch({ type: Action.DELETE_ROLE, role: role });
  });
}

////////////////////
// Favourites
////////////////////

export function getFavourites(type) {
  return new ApiRequest(`/users/current/favourites/${ type }`).get().then(response => {
    // Normalize the response
    var favourites = _.fromPairs(response.map(favourite => [ favourite.id, favourite ]));

    store.dispatch({ type: Action.UPDATE_FAVOURITES, favourites: favourites });
  });
}

export function addFavourite(favourite) {
  return new ApiRequest('/users/current/favourites').post(favourite).then(response => {
    // Normalize the response
    var favourite = _.fromPairs([[ response.id, response ]]);

    store.dispatch({ type: Action.ADD_FAVOURITE, favourite: favourite });
  });
}

export function updateFavourite(favourite) {
  return new ApiRequest('/users/current/favourites').put(favourite).then(response => {
    // Normalize the response
    var favourite = _.fromPairs([[ response.id, response ]]);

    store.dispatch({ type: Action.UPDATE_FAVOURITE, favourite: favourite });
  });
}

export function deleteFavourite(favourite) {
  return new ApiRequest(`/users/current/favourites/${ favourite.id }/delete`).post().then(response => {
    // No needs to normalize, as we just want the id from the response.
    store.dispatch({ type: Action.DELETE_FAVOURITE, id: response.id });
  });
}

////////////////////
// School Buses
////////////////////

function parseSchoolBus(bus) {
  if (!bus.schoolBusOwner)   { bus.schoolBusOwner   = { id: '', name: '' }; }
  if (!bus.district)         { bus.district         = { id: '', name: '' }; }
  if (!bus.schoolDistrict)   { bus.schoolDistrict   = { id: '', name: '', shortName: '' }; }
  if (!bus.homeTerminalCity) { bus.homeTerminalCity = { id: '', name: '' }; }
  if (!bus.inspector)        { bus.inspector        = { id: '', givenName: '', surname: '' }; }

  bus.isActive = bus.status === Constant.STATUS_ACTIVE;
  bus.ownerName = bus.schoolBusOwner.name;
  bus.ownerPath = bus.schoolBusOwner.id ? '#/owners/' + bus.schoolBusOwner.id : '';
  bus.districtName = bus.district.name;
  bus.schoolDistrictName = bus.schoolDistrict.name;
  bus.homeTerminalAddress = concat(bus.homeTerminalAddress1, bus.homeTerminalAddress2, ', ');
  bus.homeTerminalCityProv = concat(bus.homeTerminalCity.name, bus.homeTerminalProvince, ', ');
  bus.homeTerminalCityPostal = concat(bus.homeTerminalCity.name, bus.homeTerminalPostalCode, ', ');
  bus.daysToInspection = daysFromToday(bus.nextInspectionDate);
  bus.isOverdue = bus.daysToInspection < 0;
  bus.inspectorName = firstLastName(bus.inspector.givenName, bus.inspector.surname);
  bus.isReinspection = bus.nextInspectionTypeCode === Constant.INSPECTION_TYPE_REINSPECTION;
  bus.nextInspectionDateSort = sortableDateTime(bus.nextInspectionDate);
  bus.canEdit = true;
  bus.canDelete = false;
}

export function searchSchoolBuses(params) {
  return new ApiRequest('/schoolbuses/search').get(params).then(response => {
    // Normalize the response
    var schoolBuses = _.fromPairs(response.map(schoolBus => [ schoolBus.id, schoolBus ]));

    // Add display fields
    _.map(schoolBuses, bus => { parseSchoolBus(bus); });

    store.dispatch({ type: Action.UPDATE_BUSES, schoolBuses: schoolBuses });
  });
}

export function getSchoolBuses() {
  return new ApiRequest('/schoolbuses').get().then(response => {
    // Normalize the response
    var schoolBuses = _.fromPairs(response.map(schoolBus => [ schoolBus.id, schoolBus ]));

    store.dispatch({ type: Action.UPDATE_BUSES, schoolBuses: schoolBuses });
  });
}

export function getSchoolBus(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${ schoolBusId }`).get().then(response => {
    var bus = response;

    // Add display fields
    parseSchoolBus(bus);

    store.dispatch({ type: Action.UPDATE_BUS, schoolBus: bus });
  });
}

export function addSchoolBus(schoolBus) {
  return new ApiRequest('/schoolbuses').post(schoolBus).then(response => {
    var bus = response;

    // Add display fields
    parseSchoolBus(bus);

    store.dispatch({ type: Action.ADD_BUS, schoolBus: bus });
  });
}

export function updateSchoolBus(schoolBus) {
  return new ApiRequest(`/schoolbuses/${ schoolBus.id }`).put(schoolBus).then(response => {
    var bus = response;

    // Add display fields
    parseSchoolBus(bus);

    store.dispatch({ type: Action.UPDATE_BUS, schoolBus: bus });
  });
}

export function deleteSchoolBus(schoolBus) {
  return new ApiRequest(`/schoolbuses/${ schoolBus.id }/delete`).post().then(response => {
    var bus = response;

    // Add display fields
    parseSchoolBus(bus);

    store.dispatch({ type: Action.DELETE_BUS, schoolBus: bus });
  });
}

export function getSchoolBusAttachments(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${ schoolBusId }/attachments`).get().then(response => {
    // Normalize the response
    var schoolBusAttachments = _.fromPairs(response.map(attachment => [ attachment.id, attachment ]));

    store.dispatch({ type: Action.UPDATE_BUS_ATTACHMENTS, schoolBusAttachments: schoolBusAttachments });
  });
}

export function addSchoolBusCCW(ccw) {
  return new ApiRequest('/ccwdata').post(ccw).then(response => {
    var schoolBusCCW = response || {};

    store.dispatch({ type: Action.ADD_BUS_CCW, schoolBusCCW: schoolBusCCW });
  });
}

export function getSchoolBusCCW(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${ schoolBusId }/ccwdata`).get().then(response => {
    var schoolBusCCW = response || {};

    store.dispatch({ type: Action.UPDATE_BUS_CCW, schoolBusCCW: schoolBusCCW });
  });
}

export function getSchoolBusHistories(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${ schoolBusId }/history`).get().then(response => {
    // Normalize the response
    var schoolBusHistories = _.fromPairs(response.map(history => [ history.id, history ]));

    store.dispatch({ type: Action.UPDATE_BUS_HISTORIES, schoolBusHistories: schoolBusHistories });
  });
}

export function getSchoolBusInspections(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${ schoolBusId }/inspections`).get().then(response => {
    // Normalize the response
    var schoolBusInspections = _.fromPairs(response.map(inspection => [ inspection.id, inspection ]));

    // Add display fields
    _.map(schoolBusInspections, inspection => { parseInspection(inspection); });

    store.dispatch({ type: Action.UPDATE_BUS_INSPECTIONS, schoolBusInspections: schoolBusInspections });
  });
}

export function getSchoolBusNotes(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${ schoolBusId }/notes`).get().then(response => {
    // Normalize the response
    var schoolBusNotes = _.fromPairs(response.map(note => [ note.id, note ]));

    store.dispatch({ type: Action.UPDATE_BUS_NOTES, schoolBusNotes: schoolBusNotes });
  });
}

export function newSchoolBusPermit(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${ schoolBusId }/newpermit`).put().then(response => {
    var bus = response;

    // Add display fields
    parseSchoolBus(bus);

    store.dispatch({ type: Action.UPDATE_BUS, schoolBus: bus });
  });
}

////////////////////
// CCW
////////////////////

export function searchCCW(params) {
  /*

  // For devenv testing

  var ccwResponse = {
    'id': 0,
    'icbcRegistrationNumber': '09281972',
    'icbcModelYear': 1982,
    'icbcVehicleType': '2',
    'icbcRateClass': '671',
    'icbccvipDecal': 'DK66448',
    'icbcFleetUnitNo': 6001,
    'icbcGrossVehicleWeight': 12000,
    'icbcMake': 'THOMAS',
    'icbcBody': 'SCBUS',
    'icbcRebuiltStatus': '',
    'icbccvipExpiry': '2014-01-31T08:00:00Z',
    'icbcNetWt': 6420,
    'icbcModel': '',
    'icbcFuel': 'D',
    'icbcSeatingCapacity': 24,
    'icbcColour': 'PLE',
    'icbcNotesAndOrders': null,
    'icbcOrderedOn': null,
    'icbcRegOwnerName': 'JUNE EXPIRY',
    'icbcRegOwnerAddr1': '1219 CAROL PL',
    'icbcRegOwnerAddr2': 'GIBSONS                BC',
    'icbcRegOwnerCity': '',
    'icbcRegOwnerProv': '',
    'icbcRegOwnerPostalCode': 'V0N1V4',
    'icbcRegOwnerStatus': '',
    'icbcRegOwnerRODL': '',
    'icbcRegOwnerPODL': '',
    'nscClientNum': null,
    'nscCarrierName': null,
    'nscCarrierConditions': null,
    'nscCarrierSafetyRating': null,
    'nscPolicyNumber': null,
    'nscPolicyEffectiveDate': null,
    'nscPolicyStatusDate': null,
    'nscPolicyExpiryDate': null,
    'nscPolicyStatus': null,
    'nscPlateDecal': null,
  };

  return new ApiRequest('/version').get(params).then(response => {
    var ccw = response || {};

    store.dispatch({ type: Action.UPDATE_BUS_CCW, schoolBusCCW: ccwResponse });
  });
*/

  return new ApiRequest('/ccwdata/fetch').get(params).then(response => {
    var ccw = response || {};

    store.dispatch({ type: Action.UPDATE_BUS_CCW, schoolBusCCW: ccw });
  });
}

////////////////////
// Inspections
////////////////////

function parseInspection(inspection) {
  inspection.inspectorName = inspection.inspector ? firstLastName(inspection.inspector.givenName, inspection.inspector.surname) : '';
  inspection.isReinspection = inspection.inspectionTypeCode === Constant.INSPECTION_TYPE_REINSPECTION;
  inspection.canEdit = hoursAgo(inspection.createdDate) <= Constant.INSPECTION_EDIT_GRACE_PERIOD_HOURS;
  inspection.canDelete = hoursAgo(inspection.createdDate) <= Constant.INSPECTION_DELETE_GRACE_PERIOD_HOURS;
  inspection.inspectionDateSort = sortableDateTime(inspection.inspectionDate);
}

export function getInspection(id) {
  return new ApiRequest(`/inspections/${ id }`).get().then(response => {
    var inspection = response;

    // Add display fields
    parseInspection(inspection);

    store.dispatch({ type: Action.UPDATE_INSPECTION, inspection: inspection });
  });
}

export function addInspection(inspection) {
  return new ApiRequest('/inspections').post(inspection).then(response => {
    // Normalize the response
    var inspection = _.fromPairs([[ response.id, response ]]);

    // Add display fields
    parseInspection(inspection);

    store.dispatch({ type: Action.ADD_INSPECTION, inspection: inspection });
  });
}

export function updateInspection(inspection) {
  return new ApiRequest(`/inspections/${ inspection.id }`).put(inspection).then(response => {
    // Normalize the response
    var inspection = _.fromPairs([[ response.id, response ]]);

    // Add display fields
    parseInspection(inspection);

    store.dispatch({ type: Action.UPDATE_INSPECTION, inspection: inspection });
  });
}

export function deleteInspection(inspection) {
  return new ApiRequest(`/inspections/${ inspection.id }/delete`).post().then(response => {
    // Normalize the response
    var inspection = _.fromPairs([[ response.id, response ]]);

    // Add display fields
    parseInspection(inspection);

    store.dispatch({ type: Action.DELETE_INSPECTION, inspection: inspection });
  });
}

////////////////////
// Owners
////////////////////

function parseOwner(owner) {
  owner.isActive = owner.status === Constant.STATUS_ACTIVE;
  owner.primaryContactName = owner.primaryContact ? firstLastName(owner.primaryContact.givenName, owner.primaryContact.surname) : '';
  owner.daysToInspection = daysFromToday(owner.nextInspectionDate);
  owner.isOverdue = owner.daysToInspection < 0;
  owner.isReinspection = owner.nextInspectionTypeCode === Constant.INSPECTION_TYPE_REINSPECTION;
  owner.nextInspectionDateSort = sortableDateTime(owner.nextInspectionDate);
  owner.canEdit = true;
  owner.canDelete = owner.numberOfBuses === 0 && hoursAgo(owner.dateCreated) <= Constant.OWNER_DELETE_GRACE_PERIOD_HOURS;
}

export function searchOwners(params) {
  return new ApiRequest('/schoolbusowners/search').get(params).then(response => {
    // Normalize the response
    var owners = _.fromPairs(response.map(owner => [ owner.id, owner ]));

    // Add display fields
    _.map(owners, owner => { parseOwner(owner); });

    store.dispatch({ type: Action.UPDATE_OWNERS, owners: owners });
  });
}

export function getOwner(ownerId) {
  return new ApiRequest(`/schoolbusowners/${ ownerId }/view`).get().then(response => {
    var owner = response;

    // Add display fields
    parseOwner(owner);

    store.dispatch({ type: Action.UPDATE_OWNER, owner: owner });
  });
}

export function getOwners() {
  return new ApiRequest('/schoolbusowners').get().then(response => {
    // Normalize the response
    var owners = _.fromPairs(response.map(owner => [ owner.id, owner ]));

    // Add display fields
    _.map(owners, owner => { parseOwner(owner); });

    store.dispatch({ type: Action.UPDATE_OWNERS_LOOKUP, owners: owners });
  });
}

export function addOwner(owner) {
  return new ApiRequest('/schoolbusowners').post(owner).then(response => {
    var owner = response;

    // Add display fields
    parseOwner(owner);

    store.dispatch({ type: Action.ADD_OWNER, owner: owner });
  });
}

export function updateOwner(owner) {
  return new ApiRequest(`/schoolbusowners/${ owner.id }`).put(owner).then(response => {
    var owner = response;

    // Add display fields
    parseOwner(owner);

    store.dispatch({ type: Action.UPDATE_OWNER, owner: owner });
  });
}

export function deleteOwner(owner) {
  return new ApiRequest(`/schoolbusowners/${ owner.id }/delete`).post().then(response => {
    var owner = response;

    // Add display fields
    parseOwner(owner);

    store.dispatch({ type: Action.DELETE_OWNER, owner: owner });
  });
}

////////////////////
// Look-ups
////////////////////

export function getCities() {
  return new ApiRequest('/cities').get().then(response => {
    // Normalize the response
    var cities = _.fromPairs(response.map(city => [ city.id, city ]));

    store.dispatch({ type: Action.UPDATE_CITIES_LOOKUP, cities: cities });
  });
}

export function getDistricts() {
  return new ApiRequest('/districts').get().then(response => {
    // Normalize the response
    var districts = _.fromPairs(response.map(district => [ district.id, district ]));

    store.dispatch({ type: Action.UPDATE_DISTRICTS_LOOKUP, districts: districts });
  });
}

export function getRegions() {
  return new ApiRequest('/regions').get().then(response => {
    // Normalize the response
    var regions = _.fromPairs(response.map(region => [ region.id, region ]));

    store.dispatch({ type: Action.UPDATE_REGIONS_LOOKUP, regions: regions });
  });
}

export function getSchoolDistricts() {
  return new ApiRequest('/schooldistricts').get().then(response => {
    // Normalize the response
    var schoolDistricts = _.fromPairs(response.map(schoolDistrict => [ schoolDistrict.id, schoolDistrict ]));

    store.dispatch({ type: Action.UPDATE_SCHOOL_DISTRICTS_LOOKUP, schoolDistricts: schoolDistricts });
  });
}

export function getServiceAreas() {
  return new ApiRequest('/serviceareas').get().then(response => {
    // Normalize the response
    var serviceAreas = _.fromPairs(response.map(serviceArea => [ serviceArea.id, serviceArea ]));

    store.dispatch({ type: Action.UPDATE_SERVICE_AREAS_LOOKUP, serviceAreas: serviceAreas });
  });
}

export function getGroups() {
  return new ApiRequest('/groups').get().then(response => {
    // Normalize the response
    var groups = _.fromPairs(response.map(group => [ group.id, group ]));

    store.dispatch({ type: Action.UPDATE_GROUPS_LOOKUP, groups: groups });
  });
}

export function getInspectors() {
  var inspectorGroupId = getInspectorGroupId();

  return new ApiRequest(`/groups/${ inspectorGroupId }/users`).get().then(response => {
    // Normalize the response
    var users = _.fromPairs(response.map(user => [ user.id, user ]));

    // Add display fields
    _.map(users, user => { parseUser(user); });

    store.dispatch({ type: Action.UPDATE_INSPECTORS_LOOKUP, inspectors: users });
  });
}

export function getRoles() {
  return new ApiRequest('/roles').get().then(response => {
    // Normalize the response
    var roles = _.fromPairs(response.map(role => [ role.id, role ]));

    store.dispatch({ type: Action.UPDATE_ROLES_LOOKUP, roles: roles });
  });
}

////////////////////
// Version
////////////////////

export function getVersion() {
  return new ApiRequest('/version').get().then(response => {
    store.dispatch({ type: Action.UPDATE_VERSION, version: response });
  });
}

////////////////////
// Utilities
////////////////////

function getInspectorGroupId() {
  var inspectorGroup = _.find(store.getState().lookups.groups, { name: 'Inspector' });
  return inspectorGroup ? inspectorGroup.id : 0;
}
