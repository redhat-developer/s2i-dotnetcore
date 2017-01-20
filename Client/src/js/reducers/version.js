const DEFAULT_VERSION = {
  applicationVersions: [{

  }],
  databaseVersions: [{

  }],
};

export default function versionReducer(state = DEFAULT_VERSION, action) {
  var newState = {};

  switch(action.type) {
    case 'UPDATE_VERSION':
      return { ...state, ...action.version };
  }

  return { ...state, ...newState };
}
