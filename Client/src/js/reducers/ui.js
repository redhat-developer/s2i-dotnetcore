const DEFAULT_STATE = {
  requests: {
    waiting: false,
    error: {}, // ApiError
  },

  schoolBuses: {},
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
  }

  return { ...state, ...newState };
}
