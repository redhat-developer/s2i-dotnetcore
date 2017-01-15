const DEFAULT_STATE = {
  requests: {
    waiting: false,
    error: null,
  },
  schoolBuses: {},
};

export default function uiReducer(state = DEFAULT_STATE, action) {
  var newState = {};

  switch(action.type) {
    case 'REQUESTS_BEGIN':
      return { ...state, requests: {
        waiting: true,
        error: null,
      }};

    case 'REQUESTS_END':
      return { ...state, requests: {
        waiting: false,
      }};

    case 'UPDATE_BUSES_UI':
      return { ...state, schoolBuses: action.schoolBuses };
  }

  return { ...state, ...newState };
}
