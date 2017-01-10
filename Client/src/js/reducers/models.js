const DEFAULT_MODELS = {
  users : {},
  schoolBuses: {},
};

export default function modelsReducer(state = DEFAULT_MODELS, action) {
  switch(action.type) {
    // Users
    case 'UPDATE_USERS':
      return { ...state, users: action.users };

    // Buses
    case 'UPDATE_BUSES':
      return { ...state, schoolBuses: action.schoolBuses };
  }

  return state;
}
