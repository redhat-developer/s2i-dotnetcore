const DEFAULT_STATE = {
  users : [],
};

export default function modelsReducer(state = DEFAULT_STATE, action) {
  var newState = {};

  switch(action.type) {
    // Users
    case 'UPDATE_USERS':
      newState = Object.assign({}, state, action.users);
      break;
  }

  return Object.assign({}, state, newState);
}
