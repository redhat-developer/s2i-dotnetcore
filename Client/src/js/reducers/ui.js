import * as Action from "../actionTypes";

const DEFAULT_STATE = {
  requests: {
    waiting: false,
    error: {}, // ApiError
  },

  schoolBuses: {},
  owners: {},
  users: {},
  inspections: {},
  contacts: {},
  roles: {},
  userRoles: {},
  history: {},
};

export default function uiReducer(state = DEFAULT_STATE, action) {
  switch (action.type) {
    // Requests

    case Action.REQUESTS_BEGIN:
      return {
        ...state,
        requests: {
          waiting: true,
          error: {},
        },
      };

    case Action.REQUESTS_END:
      return {
        ...state,
        requests: { ...state.requests, ...{ waiting: false } },
      };

    case Action.REQUESTS_ERROR:
      return {
        ...state,
        requests: { ...state.requests, ...{ error: action.error } },
      };

    case Action.REQUESTS_CLEAR:
      return { ...state, requests: { waiting: false, error: {} } };

    // Screens

    case Action.UPDATE_BUSES_UI:
      return { ...state, schoolBuses: action.schoolBuses };

    case Action.UPDATE_OWNERS_UI:
      return { ...state, owners: action.owners };

    case Action.UPDATE_USERS_UI:
      return { ...state, users: action.users };

    case Action.UPDATE_INSPECTIONS_UI:
      return { ...state, inspections: action.inspections };

    case Action.UPDATE_CONTACTS_UI:
      return { ...state, contacts: action.contacts };

    case Action.UPDATE_ROLES_UI:
      return { ...state, roles: action.roles };

    case Action.UPDATE_USER_ROLES_UI:
      return { ...state, userRoles: action.userRoles };

    case Action.UPDATE_HISTORY_UI:
      return { ...state, history: action.history };

    default:
      return state;
  }
}
