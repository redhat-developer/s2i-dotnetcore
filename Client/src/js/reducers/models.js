const TEST_USERS = {
  users : [{
    userId                  : 1,
    firstName               : 'Rob',
    lastName                : 'Chamberlin',
    fullName                : 'Rob Chamberlin',
    districtName            : 'Cariboo',
    overdueInspections      : 0,
    scheduledReinspections  : 5,
    dueNextMonthInspections : 22,
  },{
    userId                  : 2,
    firstName               : 'Tom',
    lastName                : 'Higgins',
    fullName                : 'Tom Higgins',
    districtName            : 'Cariboo',
    overdueInspections      : 2,
    scheduledReinspections  : 6,
    dueNextMonthInspections : 18,
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
