import store from './store';
import {ApiRequest} from './utils/http';

import Promise from 'bluebird';
const TESTING = true;

function emptyPromise() {
  return new Promise(function(resolve) { resolve(); } );
}

export function getCurrentUser() {
  return new ApiRequest('/users/current').get().then(response => {
    store.dispatch({ type: 'UPDATE_USER', user: response });
  });
}

export function getUsers(regionId, cityId, localAreaId) {
  if (TESTING) { store.dispatch({ type: 'TEST_USERS' }); return emptyPromise(); }

  return new ApiRequest('/users').get({
    regionId    : regionId,
    cityId      : cityId,
    localAreaId : localAreaId,
  }).then(response => {
    store.dispatch({ type: 'UPDATE_USERS', users: response });
  });
}
