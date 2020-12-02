import * as Action from '../actionTypes';

const DEFAULT_SEARCHES = {
  schoolBuses: {},
  schoolBusesCCW: {},
  owners: {},
  users: {},
  roles: {},
  ccwnotifications: {},
};

export default function searchReducer(state = DEFAULT_SEARCHES, action) {
  switch (action.type) {
    case Action.UPDATE_BUSES_SEARCH:
      return { ...state, schoolBuses: action.schoolBuses };

    case Action.UPDATE_CCW_SEARCH:
      return { ...state, schoolBusesCCW: action.schoolBusesCCW };

    case Action.UPDATE_OWNERS_SEARCH:
      return { ...state, owners: action.owners };

    case Action.UPDATE_USERS_SEARCH:
      return { ...state, users: action.users };

    case Action.UPDATE_ROLES_SEARCH:
      return { ...state, roles: action.roles };

    case Action.UPDATE_CCWNOTIFICATIONS_SEARCH:
      return { ...state, ccwnotifications: action.ccwnotifications };

    default:
      return state;
  }
}
