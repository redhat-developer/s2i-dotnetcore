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
