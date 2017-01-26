const DEFAULT_SEARCHES = {
  schoolBuses: {},
  owners: {},
};

export default function searchReducer(state = DEFAULT_SEARCHES, action) {
  switch(action.type) {
    case 'UPDATE_BUSES_SEARCH':
      return { ...state, schoolBuses: action.schoolBuses };

    case 'UPDATE_OWNERS_SEARCH':
      return { ...state, owners: action.owners };

  }

  return state;
}
