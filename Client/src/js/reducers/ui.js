import * as Action from '../actionTypes';

const DEFAULT_STATE = {
  requests: {
    waiting: false,
    error: {}, // ApiError
  },

  schoolBuses: {},
  owners: {},
  users: {},
  inspections: {},
};

export default function uiReducer(state = DEFAULT_STATE, action) {
  var newState = {};

  switch(action.type) {
    case Action.REQUESTS_BEGIN:
      return { ...state, requests: {
        waiting: true,
        error: {},
      }};

    case Action.REQUESTS_END:
      return { ...state, requests: { ...state.requests, ...{ waiting: false } } };

    case Action.REQUESTS_ERROR:
      return { ...state, requests: { ...state.requests, ...{ error: action.error } } };



    case Action.UPDATE_BUSES_UI:
      return { ...state, schoolBuses: action.schoolBuses };

    case Action.UPDATE_OWNERS_UI:
      return { ...state, owners: action.owners };

    case Action.UPDATE_USERS_UI:
      return { ...state, users: action.users };

    case Action.UPDATE_INSPECTIONS_UI:
      return { ...state, inspections: action.inspections };
  }

  return { ...state, ...newState };
}
