import store from './store';
import {ApiRequest} from './utils/http';

import _ from 'lodash';


export function getCurrentUser() {
  return new ApiRequest('/users/current').get().then(response => {
    store.dispatch({ type: 'UPDATE_CURRENT_USER', user: response });
  });
}

export function getUsers(params) {
  return new ApiRequest('/users').get(params).then(response => {
    // Normalize the response
    var data = { users: {} };
    _.map(response, (user) => { data.users[user.id] = user; });

    store.dispatch({ type: 'UPDATE_USERS', users: data });
  });
}

export function getSchoolBuses(params) {
  return new ApiRequest('/schoolbuses').get(params).then(response => {
    // Normalize the response
    var data = { schoolBuses: {} };
    _.map(response, (bus) => {
      var normal = bus;
      data.schoolBuses[bus.id] = normal;
    });

    store.dispatch({ type: 'UPDATE_BUSES', schoolBuses: data });
  });
}

// Look Ups

export function getCities() {
  return new ApiRequest('/cities').get().then(response => {
    // Normalize the response
    var data = { cities: {} };
    _.map(response, (city) => { data.cities[city.id] = city; });

    store.dispatch({ type: 'UPDATE_CITIES', cities: data });
  });
}

export function getDistricts() {
  return new ApiRequest('/districts').get().then(response => {
    // Normalize the response
    var data = { districts: {} };
    _.map(response, (district) => { data.districts[district.id] = district; });

    store.dispatch({ type: 'UPDATE_DISTRICTS', districts: data });
  });
}

export function getRegions() {
  return new ApiRequest('/regions').get().then(response => {
    // Normalize the response
    var data = { regions: {} };
    _.map(response, (region) => { data.regions[region.id] = region; });

    store.dispatch({ type: 'UPDATE_REGIONS', regions: data });
  });
}

export function getSchoolDistricts() {
  return new ApiRequest('/schooldistricts').get().then(response => {
    // Normalize the response
    var data = { schoolDistricts: {} };
    _.map(response, (schoolDistrict) => { data.schoolDistricts[schoolDistrict.id] = schoolDistrict; });

    store.dispatch({ type: 'UPDATE_SCHOOL_DISTRICTS', schoolDistricts: data });
  });
}

export function getServiceAreas() {
  return new ApiRequest('/serviceareas').get().then(response => {
    // Normalize the response
    var data = { serviceAreas: {} };
    _.map(response, (serviceArea) => { data.serviceAreas[serviceArea.id] = serviceArea; });

    store.dispatch({ type: 'UPDATE_SERVICE_AREAS', serviceAreas: data });
  });
}
