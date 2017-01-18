import store from './store';

import { formatDateTime, isOverdue } from './utils/date';
import { ApiRequest } from './utils/http';
import { lastFirstName, concat } from './utils/string';

import _ from 'lodash';


////////////////////
// Current User
////////////////////

export function getCurrentUser() {
  return new ApiRequest('/users/current').get().then(response => {
    store.dispatch({ type: 'UPDATE_CURRENT_USER', user: response });
  });
}

////////////////////
// Users
////////////////////

export function getUsers(params) {
  return new ApiRequest('/users').get(params).then(response => {
    // Normalize the response
    var users = _.fromPairs(response.map(user => [ user.id, user ]));

    // Add display fields
    _.map(users, user => {
      user.name = lastFirstName(user.surname, user.givenName);
    });

    store.dispatch({ type: 'UPDATE_USERS', users: users });
  });
}

export function getUser(userId) {
  return new ApiRequest(`/users/${userId}`).get().then(response => {
    var user = response;

    // Add display fields
    user.name = lastFirstName(user.surname, user.givenName);

    store.dispatch({ type: 'UPDATE_USER', user: user });
  });
}

////////////////////
// Favourites
////////////////////

export function getFavourites(type) {
  return new ApiRequest(`/users/current/favourites/${type}`).get().then(response => {
    // Normalize the response
    var favourites = _.fromPairs(response.map(favourite => [ favourite.id, favourite ]));

    store.dispatch({ type: 'UPDATE_FAVOURITES', favourites: favourites });
  });
}

export function addFavourite(favourite) {
  return new ApiRequest('/users/current/favourites').post(favourite).then(response => {
    // Normalize the response
    var favourite = _.fromPairs([[ response.id, response ]]);

    store.dispatch({ type: 'ADD_FAVOURITE', favourite: favourite });
  });
}

export function updateFavourite(favourite) {
  return new ApiRequest('/users/current/favourites').put(favourite).then(response => {
    // Normalize the response
    var favourite = _.fromPairs([[ response.id, response ]]);

    store.dispatch({ type: 'UPDATE_FAVOURITE', favourite: favourite });
  });
}

export function deleteFavourite(favourite) {
  return new ApiRequest(`/users/current/favourites/${favourite.id}/delete`).post().then(response => {
    // No needs to normalize, as we just want the id from the response.
    store.dispatch({ type: 'DELETE_FAVOURITE', id: response.id });
  });
}

////////////////////
// School Buses
////////////////////

export function searchSchoolBuses(params) {
  return new ApiRequest('/schoolbuses/search').get(params).then(response => {
    // Normalize the response
    var schoolBuses = _.fromPairs(response.map(schoolBus => [ schoolBus.id, schoolBus ]));

    // Add display fields
    _.map(schoolBuses, bus => {
      bus.ownerName = bus.schoolBusOwner ? bus.schoolBusOwner.name : '';
      bus.serviceAreaName = bus.serviceArea ? bus.serviceArea.name : '';
      bus.homeTerminal = concat(bus.homeTerminalCity ? bus.homeTerminalCity.name : '', bus.homeTerminalPostalCode, ', ');
      bus.isOverdue = isOverdue(bus.nextInspectionDate);
      bus.nextInspectionDate = formatDateTime(bus.nextInspectionDate, 'MM/DD/YYYY');
    });

    store.dispatch({ type: 'UPDATE_BUSES', schoolBuses: schoolBuses });
  });
}

export function getSchoolBuses(params) {
  return new ApiRequest('/schoolbuses').get(params).then(response => {
    // Normalize the response
    var schoolBuses = _.fromPairs(response.map(schoolBus => [ schoolBus.id, schoolBus ]));

    store.dispatch({ type: 'UPDATE_BUSES', schoolBuses: schoolBuses });
  });
}

export function getSchoolBus(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}`).get().then(response => {
    var schoolBus = response;

    store.dispatch({ type: 'UPDATE_BUS', schoolBus: schoolBus });
  });
}

export function getSchoolBusAttachments(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/attachments`).get().then(response => {
    // Normalize the response
    var schoolBusAttachments = _.fromPairs(response.map(attachment => [ attachment.id, attachment ]));

    store.dispatch({ type: 'UPDATE_BUS_ATTACHMENTS', schoolBusAttachments: schoolBusAttachments });
  });
}

export function getSchoolBusCCW(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/ccwdata`).get().then(response => {
    var schoolBusCCW = response || {};

    store.dispatch({ type: 'UPDATE_BUS_CCW', schoolBusCCW: schoolBusCCW });
  });
}

export function getSchoolBusHistories(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/history`).get().then(response => {
    // Normalize the response
    var schoolBusHistories = _.fromPairs(response.map(history => [ history.id, history ]));

    store.dispatch({ type: 'UPDATE_BUS_HISTORIES', schoolBusHistories: schoolBusHistories });
  });
}

export function getSchoolBusInspections(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/inspections`).get().then(response => {
    // Normalize the response
    var schoolBusInspections = _.fromPairs(response.map(inspection => [ inspection.id, inspection ]));

    store.dispatch({ type: 'UPDATE_BUS_INSPECTIONS', schoolBusInspections: schoolBusInspections });
  });
}

export function getSchoolBusNotes(schoolBusId) {
  return new ApiRequest(`/schoolbuses/${schoolBusId}/notes`).get().then(response => {
    // Normalize the response
    var schoolBusNotes = _.fromPairs(response.map(note => [ note.id, note ]));

    store.dispatch({ type: 'UPDATE_BUS_NOTES', schoolBusNotes: schoolBusNotes });
  });
}

////////////////////
// Owners
////////////////////

export function getOwner(ownerId) {
  return new ApiRequest(`/schoolbusowners/${ownerId}`).get().then(response => {
    var owner = response;

    store.dispatch({ type: 'UPDATE_OWNER', owner: owner });
  });
}

////////////////////
// Look Ups
////////////////////

export function getCities() {
  return new ApiRequest('/cities').get().then(response => {
    // Normalize the response
    var cities = _.fromPairs(response.map(city => [ city.id, city ]));

    store.dispatch({ type: 'UPDATE_CITIES', cities: cities });
  });
}

export function getDistricts() {
  return new ApiRequest('/districts').get().then(response => {
    // Normalize the response
    var districts = _.fromPairs(response.map(district => [ district.id, district ]));

    store.dispatch({ type: 'UPDATE_DISTRICTS', districts: districts });
  });
}

export function getRegions() {
  return new ApiRequest('/regions').get().then(response => {
    // Normalize the response
    var regions = _.fromPairs(response.map(region => [ region.id, region ]));

    store.dispatch({ type: 'UPDATE_REGIONS', regions: regions });
  });
}

export function getSchoolDistricts() {
  return new ApiRequest('/schooldistricts').get().then(response => {
    // Normalize the response
    var schoolDistricts = _.fromPairs(response.map(schoolDistrict => [ schoolDistrict.id, schoolDistrict ]));

    store.dispatch({ type: 'UPDATE_SCHOOL_DISTRICTS', schoolDistricts: schoolDistricts });
  });
}

export function getServiceAreas() {
  return new ApiRequest('/serviceareas').get().then(response => {
    // Normalize the response
    var serviceAreas = _.fromPairs(response.map(serviceArea => [ serviceArea.id, serviceArea ]));

    store.dispatch({ type: 'UPDATE_SERVICE_AREAS', serviceAreas: serviceAreas });
  });
}
