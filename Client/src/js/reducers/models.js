const DEFAULT_MODELS = {
  users : {},
  schoolBuses: {},
};

export default function modelsReducer(state = DEFAULT_MODELS, action) {
  var newState = {};

  switch(action.type) {
    // Users
    case 'UPDATE_USERS':
      newState = { ...state, ...action.users };
      break;

    // Buses
    case 'UPDATE_BUSES':
      newState = { ...state, ...action.schoolBuses };
      break;
  }

  return { ...state, ...newState };
}
