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
    case 'REQUESTS_BEGIN':
      return { ...state, requests: {
        waiting: true,
        error: {},
      }};

    case 'REQUESTS_END':
      return { ...state, requests: { ...state.requests, ...{ waiting: false } } };

    case 'REQUESTS_ERROR':
      return { ...state, requests: { ...state.requests, ...{ error: action.error } } };



    case 'UPDATE_BUSES_UI':
      return { ...state, schoolBuses: action.schoolBuses };

    case 'UPDATE_OWNERS_UI':
      return { ...state, owners: action.owners };

    case 'UPDATE_USERS_UI':
      return { ...state, users: action.users };

    case 'UPDATE_INSPECTIONS_UI':
      return { ...state, inspections: action.inspections };
  }

  return { ...state, ...newState };
}
