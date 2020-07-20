import * as Action from "../actionTypes";

const DEFAULT_VERSION = {
  applicationVersions: [{}],
  databaseVersions: [{}],
};

export default function versionReducer(state = DEFAULT_VERSION, action) {
  switch (action.type) {
    case Action.UPDATE_VERSION:
      return { ...state, ...action.version };
    default:
      return state;
  }
}
