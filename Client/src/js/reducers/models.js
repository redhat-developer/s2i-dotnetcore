const TEST_USERS = {
  users : [{
    id        : 1,
    active    : true,
    givenName : 'Rob',
    surname   : 'Chamberlin',
    initials  : 'RC',
    email     : 'robchamberlin@mail.com',
  },{
    id        : 2,
    active    : true,
    givenName : 'Tom',
    surname   : 'Higgins',
    initials  : 'TH',
    email     : 'tomhiggins@mail.com',
  }],
};

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

    case 'TEST_USERS':
      newState = Object.assign({}, state, TEST_USERS);
      break;
  }

  return Object.assign({}, state, newState);
}
