import store from './store';

import * as Action from './actionTypes';
import * as Constant from './constants';
import * as History from './history';

import { daysFromToday, formatDateTime, hoursAgo, sortableDateTime } from './utils/date';
import { ApiRequest } from './utils/http';
import { lastFirstName, firstLastName, concat } from './utils/string';

import _ from 'lodash';

////////////////////
// Users
////////////////////

function parseUser(user) {
  if (!user.district) {
    user.district = { id: 0, name: '' };
  }
  if (!user.userRoles) {
    user.userRoles = [];
  }

  user.name = lastFirstName(user.surname, user.givenName);
  user.fullName = firstLastName(user.givenName, user.surname);
  user.districtName = user.district.name;

  user.path = `${Constant.USERS_PATHNAME}/${user.id}`;
  user.url = `#/${user.path}`;
  user.historyEntity = History.makeHistoryEntity(History.USER, user);

  _.each(user.userRoles, (userRole) => {
    userRole.roleId = userRole.role && userRole.role.id ? userRole.role.id : 0;
    userRole.roleName = userRole.role && userRole.role.name ? userRole.role.name : '';
    userRole.effectiveDateSort = sortableDateTime(user.effectiveDate);
    userRole.expiryDateSort = sortableDateTime(user.expiryDate);
  });

  user.canEdit = true;
  user.canDelete = true;
}

export function getCurrentUser() {
  return new ApiRequest('/users/current').get().then((response) => {
    var user = response;

    // Add display fields
    parseUser(user);

    store.dispatch({ type: Action.UPDATE_CURRENT_USER, user: user });
  });
}

//Check if current user is Administrator
export function isAdmin() {
  return store.getState().user.isSystemAdmin;
}

export function searchUsers(params) {
  return new ApiRequest('/users/search').get(params).then((response) => {
    // Normalize the response
    var users = _.fromPairs(response.map((user) => [user.id, user]));

    // Add display fields
    _.map(users, (user) => {
      parseUser(user);
    });

    store.dispatch({ type: Action.UPDATE_USERS, users: users });
  });
}

export function getUsers() {
  return new ApiRequest('/users').get().then((response) => {
    // Normalize the response
    var users = _.fromPairs(response.map((user) => [user.id, user]));

    // Add display fields
    _.map(users, (user) => {
      parseUser(user);
    });

    store.dispatch({ type: Action.UPDATE_USERS, users: users });
  });
}

export function getUser(userId) {
  return new ApiRequest(`/users/${userId}`).get().then((response) => {
    var user = response;

    // Add display fields
    parseUser(user);

    store.dispatch({ type: Action.UPDATE_USER, user: user });
  });
}

export function addUser(user) {
  return new ApiRequest('/users').post(user).then((response) => {
    var user = response;

    // Add display fields
    parseUser(user);

    store.dispatch({ type: Action.ADD_USER, user: user });
  });
}

export function updateUser(user) {
  return new ApiRequest(`/users/${user.id}`).put(user).then((response) => {
    var user = response;

    // Add display fields
    parseUser(user);

    store.dispatch({ type: Action.UPDATE_USER, user: user });
  });
}

export function deleteUser(user) {
  return new ApiRequest(`/users/${user.id}/delete`).post().then((response) => {
    var user = response;

    // Add display fields
    parseUser(user);

    store.dispatch({ type: Action.DELETE_USER, user: user });
  });
}

export function addUserHistory(userId, history) {
  return new ApiRequest(`/users/${userId}/history`).post(history);
}

export function getUserHistory(userId, params) {
  return new ApiRequest(`/users/${userId}/history`).get(params).then((response) => {
    // Normalize the response
    var history = _.fromPairs(response.map((history) => [history.id, history]));

    // Add display fields
    _.map(history, (history) => {
      parseHistory(history);
    });

    store.dispatch({ type: Action.UPDATE_HISTORY, history: history });
  });
}

export function addUserRole(userId, userRole) {
  return new ApiRequest(`/users/${userId}/roles`).post(userRole).then(() => {
    // After updating the user's role, refresh the user state.
    return getUser(userId);
  });
}

export function updateUserRole(userId, userRole) {
  return new ApiRequest(`/users/${userId}/roles/${userRole.id}`).put(userRole).then(() => {
    // After updating the user's role, refresh the user state.
    return getUser(userId);
  });
}

////////////////////
// Roles / Permissions
////////////////////

function parseRole(role) {
  role.canEdit = true;
  role.canDelete = false;

  role.path = `${Constant.ROLES_PATHNAME}/${role.id}`;
  role.url = `#/${role.path}`;
  role.historyEntity = History.makeHistoryEntity(History.ROLE, role);
}

export function searchRoles(params) {
  return new ApiRequest('/roles').get(params).then((response) => {
    // Normalize the response
    var roles = _.fromPairs(response.map((role) => [role.id, role]));

    // Add display fields
    _.map(roles, (role) => {
      parseRole(role);
    });

    store.dispatch({ type: Action.UPDATE_ROLES, roles: roles });
  });
}

export function getRole(roleId) {
  return new ApiRequest(`/roles/${roleId}`).get().then((response) => {
    var role = response;

    // Add display fields
    parseRole(role);

    store.dispatch({ type: Action.UPDATE_ROLE, role: role });
  });
}

export function addRole(role) {
  return new ApiRequest('/roles').post(role).then((response) => {
    var role = response;

    // Add display fields
    parseRole(role);

    store.dispatch({ type: Action.ADD_ROLE, role: role });
  });
}

export function updateRole(role) {
  return new ApiRequest(`/roles/${role.id}`).put(role).then((response) => {
    var role = response;

    // Add display fields
    parseRole(role);

    store.dispatch({ type: Action.UPDATE_ROLE, role: role });
  });
}

export function deleteRole(role) {
  return new ApiRequest(`/roles/${role.id}/delete`).post().then((response) => {
    var role = response;

    // Add display fields
    parseRole(role);

    store.dispatch({ type: Action.DELETE_ROLE, role: role });
  });
}

export function getRolePermissions(roleId) {
  return new ApiRequest(`/roles/${roleId}/permissions`).get().then((response) => {
    var permissions = _.fromPairs(response.map((permission) => [permission.id, permission]));

    store.dispatch({
      type: Action.UPDATE_ROLE_PERMISSIONS,
      rolePermissions: permissions,
    });
  });
}

export function updateRolePermissions(roleId, permissionsArray) {
  return new ApiRequest(`/roles/${roleId}/permissions`).put(permissionsArray).then(() => {
    // After updating the role's permissions, refresh the permissions state.
    return getRolePermissions(roleId);
  });
}

////////////////////
// Favourites
////////////////////

export function getFavourites(type) {
  return new ApiRequest(`/users/current/favourites/${type}`).get().then((response) => {
    // Normalize the response
    var favourites = _.fromPairs(response.map((favourite) => [favourite.id, favourite]));

    store.dispatch({
      type: Action.UPDATE_FAVOURITES,
      favourites: favourites,
    });
  });
}

export function addFavourite(favourite) {
  return new ApiRequest('/users/current/favourites').post(favourite).then((response) => {
    // Normalize the response
    var favourite = _.fromPairs([[response.id, response]]);

    store.dispatch({ type: Action.ADD_FAVOURITE, favourite: favourite });
  });
}

export function updateFavourite(favourite) {
  return new ApiRequest('/users/current/favourites').put(favourite).then((response) => {
    // Normalize the response
    var favourite = _.fromPairs([[response.id, response]]);

    store.dispatch({ type: Action.UPDATE_FAVOURITE, favourite: favourite });
  });
}

export function deleteFavourite(favourite) {
  return new ApiRequest(`/users/current/favourites/${favourite.id}/delete`).post().then((response) => {
    // No needs to normalize, as we just want the id from the response.
    store.dispatch({ type: Action.DELETE_FAVOURITE, id: response.id });
  });
}

////////////////////
// School Buses
////////////////////

function parseCCW(ccw) {
  if (ccw.icbcRebuiltStatus === 'R') {
    ccw.icbcRebuiltStatus = 'R - Rebuilt';
  } else if (ccw.icbcRebuiltStatus === 'S') {
    ccw.icbcRebuiltStatus = 'S - Salvage';
  }
}

function parseSchoolBus(bus) {
  if (!bus.schoolBusOwner) {
    bus.schoolBusOwner = { id: 0, name: '' };
  }
  if (!bus.district) {
    bus.district = { id: 0, name: '' };
  }
  if (!bus.schoolDistrict) {
    bus.schoolDistrict = { id: 0, name: '', shortName: '' };
  }
  if (!bus.homeTerminalCity) {
    bus.homeTerminalCity = { id: 0, name: '' };
  }
  if (!bus.inspector) {
    bus.inspector = { id: 0, givenName: '', surname: '' };
  }

  if (bus.ccwData) {
    parseCCW(bus.ccwData);
  }

  bus.isActive = bus.status === Constant.STATUS_ACTIVE;
  bus.ownerName = bus.schoolBusOwner.name;
  bus.ownerURL = bus.schoolBusOwner.id ? `#/${Constant.OWNERS_PATHNAME}/${bus.schoolBusOwner.id}` : '';
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

  bus.path = `${Constant.BUSES_PATHNAME}/${bus.id}`;
  bus.url = `#/${bus.path}`;
  bus.name = `VIN ${bus.vehicleIdentificationNumber}`;
  bus.historyEntity = History.makeHistoryEntity(History.BUS, bus);

  bus.canView = true;
  bus.canEdit = true;
  bus.canDelete = false;
}

export function searchSchoolBuses(params) {
  return new ApiRequest('/schoolbuses/search').get(params).then((response) => {
    // Normalize the response
    var schoolBuses = _.fromPairs(response.map((schoolBus) => [schoolBus.id, schoolBus]));

    // Add display fields
    _.map(schoolBuses, (bus) => {
      parseSchoolBus(bus);
    });

    store.dispatch({ type: Action.UPDATE_BUSES, schoolBuses: schoolBuses });
  });
}

export function getSchoolBuses() {
  return new ApiRequest('/schoolbuses').get().then((response) => {
    // Normalize the response
    var schoolBuses = _.fromPairs(response.map((schoolBus) => [schoolBus.id, schoolBus]));

    store.dispatch({ type: Action.UPDATE_BUSES, schoolBuses: schoolBuses });
  });
}

export function getSchoolBus(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}`).get().then((response) => {
    var bus = response;

    // Add display fields
    parseSchoolBus(bus);

    store.dispatch({ type: Action.UPDATE_BUS, schoolBus: bus });
  });
}

export function addSchoolBus(schoolBus) {
  return new ApiRequest('/schoolbuses').post(schoolBus).then((response) => {
    var bus = response;

    // Add display fields
    parseSchoolBus(bus);

    store.dispatch({ type: Action.ADD_BUS, schoolBus: bus });
  });
}

export function updateSchoolBus(schoolBus) {
  return new ApiRequest(`/schoolbuses/${schoolBus.id}`).put(schoolBus).then((response) => {
    var bus = response;

    // Add display fields
    parseSchoolBus(bus);

    store.dispatch({ type: Action.UPDATE_BUS, schoolBus: bus });
  });
}

export function deleteSchoolBus(schoolBus) {
  return new ApiRequest(`/schoolbuses/${schoolBus.id}/delete`).post().then((response) => {
    var bus = response;

    // Add display fields
    parseSchoolBus(bus);

    store.dispatch({ type: Action.DELETE_BUS, schoolBus: bus });
  });
}

export function getSchoolBusAttachments(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/attachments`).get().then((response) => {
    // Normalize the response
    var schoolBusAttachments = _.fromPairs(response.map((attachment) => [attachment.id, attachment]));

    store.dispatch({
      type: Action.UPDATE_BUS_ATTACHMENTS,
      schoolBusAttachments: schoolBusAttachments,
    });
  });
}

export function addSchoolBusCCW(ccw) {
  return new ApiRequest('/ccwdata').post(ccw).then((response) => {
    var schoolBusCCW = response || {};

    // Add display fields
    parseCCW(schoolBusCCW);

    store.dispatch({ type: Action.ADD_BUS_CCW, schoolBusCCW: schoolBusCCW });
  });
}

export function getSchoolBusCCW(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/ccwdata`).get().then((response) => {
    var schoolBusCCW = response || {};

    // Add display fields
    parseCCW(schoolBusCCW);

    store.dispatch({
      type: Action.UPDATE_BUS_CCW,
      schoolBusCCW: schoolBusCCW,
    });
  });
}

export function addSchoolBusHistory(schoolBusId, history) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/history`).post(history);
}

export function getSchoolBusHistory(schoolBusId, params) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/history`).get(params).then((response) => {
    // Normalize the response
    var history = _.fromPairs(response.map((history) => [history.id, history]));

    // Add display fields
    _.map(history, (history) => {
      parseHistory(history);
    });

    store.dispatch({ type: Action.UPDATE_HISTORY, history: history });
  });
}

export function getSchoolBusInspections(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/inspections`).get().then((response) => {
    // Normalize the response
    var schoolBusInspections = _.fromPairs(response.map((inspection) => [inspection.id, inspection]));

    // Add display fields
    _.map(schoolBusInspections, (inspection) => {
      parseInspection(inspection);
    });

    store.dispatch({
      type: Action.UPDATE_BUS_INSPECTIONS,
      schoolBusInspections: schoolBusInspections,
    });

    return schoolBusInspections;
  });
}

export function getSchoolBusNotes(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/notes`).get().then((response) => {
    // Normalize the response
    return _.fromPairs(response.map((note) => [note.id, note]));
  });
}

export function addSchoolBusNotes(schoolBusId, note) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/notes`).post(note).then((response) => {
    return response;
  });
}

export function updateSchoolBusNotes(schoolBusId, note) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/notes/${note.id}`).put(note).then((response) => {
    return response;
  });
}

export function deleteSchoolBusNotes(schoolBusId, noteId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/notes/${noteId}`).delete().then((response) => {
    return response;
  });
}

export function newSchoolBusPermit(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/newpermit`).put().then((response) => {
    var bus = response;

    // Add display fields
    parseSchoolBus(bus);

    store.dispatch({ type: Action.UPDATE_BUS, schoolBus: bus });
  });
}

export function getSchoolBusPermit(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/pdfpermit`).getBlob();
}

export function getSchoolBusPermitURL(schoolBusId) {
  // Not an API call, per se, as it must be called from the browser window.
  return `${window.location.origin}${window.location.pathname}api/schoolbuses/${schoolBusId}/pdfpermit`;
}

////////////////////
// CCW
////////////////////

export function searchCCW(params) {
  return new ApiRequest('/ccwdata/fetch').get(params).then((response) => {
    var ccw = response || {};

    // Add display fields
    parseCCW(ccw);

    store.dispatch({ type: Action.UPDATE_BUS_CCW, schoolBusCCW: ccw });
  });
}

////////////////////
// Inspections
////////////////////

function parseInspection(inspection) {
  inspection.inspectorName = inspection.inspector
    ? firstLastName(inspection.inspector.givenName, inspection.inspector.surname)
    : '';
  inspection.isReinspection = inspection.inspectionTypeCode === Constant.INSPECTION_TYPE_REINSPECTION;
  inspection.inspectionDateSort = sortableDateTime(inspection.inspectionDate);

  inspection.path = inspection.schoolBus
    ? `${Constant.BUSES_PATHNAME}/${inspection.schoolBus.id}/${Constant.INSPECTION_PATHNAME}/${inspection.id}`
    : null;
  inspection.url = inspection.path ? `#/${inspection.path}` : null;
  inspection.name = `(${formatDateTime(inspection.inspectionDate, Constant.DATE_SHORT_MONTH_DAY_YEAR)})`;
  inspection.historyEntity = History.makeHistoryEntity(History.INSPECTION, inspection);

  inspection.canEdit = hoursAgo(inspection.createdDate) <= Constant.INSPECTION_EDIT_GRACE_PERIOD_HOURS || isAdmin();
  inspection.canDelete = hoursAgo(inspection.createdDate) <= Constant.INSPECTION_DELETE_GRACE_PERIOD_HOURS || isAdmin();
}

export function getInspection(id) {
  return new ApiRequest(`/inspections/${id}`).get().then((response) => {
    var inspection = response;

    // Add display fields
    parseInspection(inspection);

    store.dispatch({ type: Action.UPDATE_INSPECTION, inspection: inspection });
  });
}

export function addInspection(inspection) {
  return new ApiRequest('/inspections').post(inspection).then((response) => {
    // Normalize the response
    var inspection = response;

    // Add display fields
    parseInspection(inspection);

    store.dispatch({ type: Action.ADD_INSPECTION, inspection: inspection });
  });
}

export function updateInspection(inspection) {
  return new ApiRequest(`/inspections/${inspection.id}`).put(inspection).then((response) => {
    // Normalize the response
    var inspection = response;

    // Add display fields
    parseInspection(inspection);

    store.dispatch({
      type: Action.UPDATE_INSPECTION,
      inspection: inspection,
    });
  });
}

export function deleteInspection(inspection) {
  return new ApiRequest(`/inspections/${inspection.id}/delete`).post().then((response) => {
    // Normalize the response
    var inspection = response;

    // Add display fields
    parseInspection(inspection);

    store.dispatch({
      type: Action.DELETE_INSPECTION,
      inspection: inspection,
    });
  });
}

export function getInspectionCounts(params) {
  return new ApiRequest('/inspections/counts').get(params).then((response) => {
    // Normalize the response
    var inspectionCounts = response;

    store.dispatch({
      type: Action.UPDATE_INSPECTION_COUNTS,
      inspectionCounts: inspectionCounts,
    });
  });
}

////////////////////
// Owners
////////////////////

function parseOwner(owner) {
  owner.isActive = owner.status === Constant.STATUS_ACTIVE;
  owner.busesURL = `#/${Constant.BUSES_PATHNAME}?${Constant.SCHOOL_BUS_OWNER_QUERY}=${owner.id}`;

  var primaryContact = owner.primaryContact;

  owner.primaryContactName = primaryContact ? firstLastName(primaryContact.givenName, primaryContact.surname) : '';
  owner.primaryContactNumber = primaryContact ? primaryContact.workPhoneNumber ?? '' : '';
  owner.primaryContactEmail = primaryContact ? primaryContact.emailAddress ?? '' : '';

  owner.daysToInspection = daysFromToday(owner.nextInspectionDate);
  owner.isOverdue = owner.daysToInspection < 0;
  owner.isReinspection = owner.nextInspectionTypeCode === Constant.INSPECTION_TYPE_REINSPECTION;
  owner.nextInspectionDateSort = sortableDateTime(owner.nextInspectionDate);

  owner.path = `${Constant.OWNERS_PATHNAME}/${owner.id}`;
  owner.url = `#/${owner.path}`;
  owner.historyEntity = History.makeHistoryEntity(History.OWNER, owner);

  owner.canView = true;
  owner.canEdit = true;
  owner.canDelete =
    owner.numberOfBuses === 0 && hoursAgo(owner.dateCreated) <= Constant.OWNER_DELETE_GRACE_PERIOD_HOURS;
}

export function searchOwners(params) {
  return new ApiRequest('/schoolbusowners/search').get(params).then((response) => {
    // Normalize the response
    var owners = _.fromPairs(response.map((owner) => [owner.id, owner]));

    // Add display fields
    _.map(owners, (owner) => {
      parseOwner(owner);
    });

    store.dispatch({ type: Action.UPDATE_OWNERS, owners: owners });
  });
}

export function getOwner(ownerId) {
  return new ApiRequest(`/schoolbusowners/${ownerId}/view`).get().then((response) => {
    var owner = response;

    // Add display fields
    parseOwner(owner);

    store.dispatch({ type: Action.UPDATE_OWNER, owner: owner });
  });
}

export function getOwners() {
  return new ApiRequest('/schoolbusowners').get().then((response) => {
    // Normalize the response
    var owners = _.fromPairs(response.map((owner) => [owner.id, owner]));

    // Add display fields
    _.map(owners, (owner) => {
      parseOwner(owner);
    });

    store.dispatch({ type: Action.UPDATE_OWNERS_LOOKUP, owners: owners });
  });
}

export function addOwner(owner) {
  return new ApiRequest('/schoolbusowners').post(owner).then((response) => {
    var owner = response;

    // Add display fields
    parseOwner(owner);

    store.dispatch({ type: Action.ADD_OWNER, owner: owner });
  });
}

export function updateOwner(owner) {
  return new ApiRequest(`/schoolbusowners/${owner.id}`).put(owner).then((response) => {
    var owner = response;

    // Add display fields
    parseOwner(owner);

    store.dispatch({ type: Action.UPDATE_OWNER, owner: owner });
  });
}

export function deleteOwner(owner) {
  return new ApiRequest(`/schoolbusowners/${owner.id}/delete`).post().then((response) => {
    var owner = response;

    // Add display fields
    parseOwner(owner);

    store.dispatch({ type: Action.DELETE_OWNER, owner: owner });
  });
}

export function addOwnerHistory(ownerId, history) {
  return new ApiRequest(`/schoolbusowners/${ownerId}/history`).post(history);
}

export function getOwnerHistory(ownerId, params) {
  return new ApiRequest(`/schoolbusowners/${ownerId}/history`).get(params).then((response) => {
    // Normalize the response
    var history = _.fromPairs(response.map((history) => [history.id, history]));

    // Add display fields
    _.map(history, (history) => {
      parseHistory(history);
    });

    store.dispatch({ type: Action.UPDATE_HISTORY, history: history });
  });
}

export function getOwnerContacts(ownerId) {
  return new ApiRequest(`/schoolbusowners/${ownerId}/contacts`).get().then((response) => {
    // Normalize the response
    var ownerContacts = _.fromPairs(response.map((contact) => [contact.id, contact]));

    // Add display fields
    _.map(ownerContacts, (contact) => {
      parseContact(contact);
    });

    store.dispatch({
      type: Action.UPDATE_OWNER_CONTACTS,
      ownerContacts: ownerContacts,
    });
  });
}

////////////////////
// Look-ups
////////////////////

export function getCities() {
  return new ApiRequest('/cities').get().then((response) => {
    // Normalize the response
    var cities = _.fromPairs(response.map((city) => [city.id, city]));

    store.dispatch({ type: Action.UPDATE_CITIES_LOOKUP, cities: cities });
  });
}

export function getDistricts() {
  return new ApiRequest('/districts').get().then((response) => {
    // Normalize the response
    var districts = _.fromPairs(response.map((district) => [district.id, district]));

    store.dispatch({
      type: Action.UPDATE_DISTRICTS_LOOKUP,
      districts: districts,
    });
  });
}

export function getRegions() {
  return new ApiRequest('/regions').get().then((response) => {
    // Normalize the response
    var regions = _.fromPairs(response.map((region) => [region.id, region]));

    store.dispatch({ type: Action.UPDATE_REGIONS_LOOKUP, regions: regions });
  });
}

export function getSchoolDistricts() {
  return new ApiRequest('/schooldistricts').get().then((response) => {
    // Normalize the response
    var schoolDistricts = _.fromPairs(response.map((schoolDistrict) => [schoolDistrict.id, schoolDistrict]));

    store.dispatch({
      type: Action.UPDATE_SCHOOL_DISTRICTS_LOOKUP,
      schoolDistricts: schoolDistricts,
    });
  });
}

export function getServiceAreas() {
  return new ApiRequest('/serviceareas').get().then((response) => {
    // Normalize the response
    var serviceAreas = _.fromPairs(response.map((serviceArea) => [serviceArea.id, serviceArea]));

    store.dispatch({
      type: Action.UPDATE_SERVICE_AREAS_LOOKUP,
      serviceAreas: serviceAreas,
    });
  });
}

export function getInspectors() {
  return new ApiRequest(`/users/inspectors`).get().then((response) => {
    // Normalize the response
    var users = _.fromPairs(response.map((user) => [user.id, user]));

    // Add display fields
    _.map(users, (user) => {
      user.isInspector = true;
      parseUser(user);
    });

    store.dispatch({
      type: Action.UPDATE_INSPECTORS_LOOKUP,
      inspectors: users,
    });
  });
}

export function getRoles() {
  return new ApiRequest('/roles').get().then((response) => {
    // Normalize the response
    var roles = _.fromPairs(response.map((role) => [role.id, role]));

    store.dispatch({ type: Action.UPDATE_ROLES_LOOKUP, roles: roles });
  });
}

export function getPermissions() {
  return new ApiRequest('/permissions').get().then((response) => {
    // Normalize the response
    var permissions = _.fromPairs(response.map((permission) => [permission.id, permission]));

    store.dispatch({
      type: Action.UPDATE_PERMISSIONS_LOOKUP,
      permissions: permissions,
    });
  });
}

////////////////////
// Contacts
////////////////////

function parseContact(contact) {
  contact.path = contact.schoolBusOwner
    ? `${Constant.OWNERS_PATHNAME}/${contact.schoolBusOwner.id}/${Constant.CONTACT_PATHNAME}/${contact.id}`
    : null;
  contact.url = contact.path ? `#/${contact.path}` : null;
  contact.name = `${firstLastName(contact.givenName, contact.surname)}`;
  contact.historyEntity = History.makeHistoryEntity(History.CONTACT, contact);

  contact.canDelete = true;
  contact.canEdit = true;
}

export function getContact(id) {
  return new ApiRequest(`/contacts/${id}`).get().then((response) => {
    var contact = response;

    parseContact(contact);

    store.dispatch({ type: Action.UPDATE_CONTACT, contact: contact });

    return response;
  });
}

export function addContact(contact) {
  return new ApiRequest('/contacts').post(contact).then((response) => {
    var contact = response;

    parseContact(contact);

    store.dispatch({ type: Action.ADD_CONTACT, contact: contact });

    return response;
  });
}

export function updateContact(contact) {
  return new ApiRequest(`/contacts/${contact.id}`).put(contact).then((response) => {
    var contact = response;

    parseContact(contact);

    store.dispatch({ type: Action.UPDATE_CONTACT, contact: contact });
  });
}

export function deleteContact(contact) {
  return new ApiRequest(`/contacts/${contact.id}/delete`).post().then((response) => {
    var contact = response;

    parseContact(contact);

    store.dispatch({ type: Action.DELETE_CONTACT, contact: contact });
  });
}

////////////////////
// History
////////////////////

function parseHistory(history) {
  history.timestampSort = sortableDateTime(history.lastUpdateTimestamp);
}

////////////////////
// Version
////////////////////

export function getVersion() {
  return new ApiRequest('/version').get().then((response) => {
    store.dispatch({ type: Action.UPDATE_VERSION, version: response });
  });
}

////////////////////
// Send Email
////////////////////
export function sendEmail(email) {
  return new ApiRequest('schoolbuses/email').post(email).then((response) => {
    return response;
  });
}

////////////////////
// CCW Notification
////////////////////
export function getCCWNotifications(params) {
  return new ApiRequest('/ccwnotifications').get(params).then((response) => {
    var ccwnotifications = _.fromPairs(response.map((ccwnotification) => [ccwnotification.id, ccwnotification]));

    // Add display fields
    _.map(ccwnotifications, (ccwnotification) => {
      parseCCWNotification(ccwnotification);
    });

    store.dispatch({ type: Action.UPDATE_CCWNOTIFICATIONS, ccwnotifications: ccwnotifications });
  });
}

function parseCCWNotification(ccwnotification) {
  ccwnotification.ownerURL = ccwnotification.schoolBusOwnerId
    ? `#/${Constant.OWNERS_PATHNAME}/${ccwnotification.schoolBusOwnerId}`
    : '';
  ccwnotification.schoolBusUrl = `#/${Constant.BUSES_PATHNAME}/${ccwnotification.schoolBusId}`;
  ccwnotification.canView = true;
  ccwnotification.canEdit = true;
  ccwnotification.canDelete = false;

  ccwnotification.text = ccwnotification.ccwNotificationDetails
    .map((detail) => `${detail.colDescription} - **New**: ${detail.valueTo} **Old**: ${detail.valueFrom}`)
    .join('\n\n');
}

export function updateHasBeenReadAsRead(ccwnotifications) {
  return new ApiRequest('/ccwnotifications/read').post(ccwnotifications).then((response) => {
    return response;
  });
}

export function updateHasBeenReadAsUnread(ccwnotifications) {
  return new ApiRequest('/ccwnotifications/unread').post(ccwnotifications).then((response) => {
    return response;
  });
}

export function deleteCCWNotifications(ccwnotifications) {
  return new ApiRequest('/ccwnotifications').delete(ccwnotifications).then((response) => {
    return response;
  });
}
