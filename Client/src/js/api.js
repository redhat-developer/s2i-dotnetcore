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
    var users = _.fromPairs(response.map(user => [ user.id, user ]));

    // Add display fields
    _.map(users, user => {
      if (user.surname && user.givenName) {
        user.name = user.surname + ', ' + user.givenName;
      } else if (user.surname) {
        user.name = user.surname;
      } else {
        user.name = user.givenName;
      }
    });

    store.dispatch({ type: 'UPDATE_USERS', users: users });
  });
}

export function getSchoolBuses(params) {
  return new ApiRequest('/schoolbuses').get(params).then(response => {
    // Normalize the response
    var schoolBuses = _.fromPairs(response.map(schoolBus => [ schoolBus.id, schoolBus ]));

    store.dispatch({ type: 'UPDATE_BUSES', schoolBuses: schoolBuses });
  });
}

// Look Ups

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
