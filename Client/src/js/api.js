import store from './store';
import {ApiRequest} from './utils/http';

const TESTING = true;


export function test(/*testId*/) {
  return new ApiRequest('/test').get().then(response => {
    store.dispatch({ type: 'TEST_COUNT', count: response.count });
  });
}

export function getCurrentUser() {
  if (TESTING) { return store.dispatch({ type: 'TEST_USER' }); }

  return new ApiRequest('/users/current').get().then(response => {
    store.dispatch({ type: 'UPDATE_USER', user: response });
  });
}

export function getUsers(regionId, cityId, localAreaId) {
  if (TESTING) { return store.dispatch({ type: 'TEST_USERS' }); }

  return new ApiRequest('/users').get({
    regionId    : regionId,
    cityId      : cityId,
    localAreaId : localAreaId,
  }).then(response => {
    store.dispatch({ type: 'UPDATE_USERS', users: response });
  });
}
