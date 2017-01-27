const DEFAULT_SEARCHES = {
  schoolBuses: {},
  owners: {},
  users: {},
};

export default function searchReducer(state = DEFAULT_SEARCHES, action) {
  switch(action.type) {
    case 'UPDATE_BUSES_SEARCH':
      return { ...state, schoolBuses: action.schoolBuses };

    case 'UPDATE_OWNERS_SEARCH':
      return { ...state, owners: action.owners };

    case 'UPDATE_USERS_SEARCH':
      return { ...state, users: action.users };

  }

  return state;
}
