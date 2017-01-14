const DEFAULT_SEARCHES = {
  schoolBuses: {},
};

export default function searchReducer(state = DEFAULT_SEARCHES, action) {
  switch(action.type) {
    case 'UPDATE_BUSES_SEARCH':
      return { ...state, schoolBuses: action.schoolBuses };
  }

  return state;
}
