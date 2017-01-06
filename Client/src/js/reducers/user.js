const DEFAULT_STATE = {
  userId                  : null,
  firstName               : null,
  lastName                : null,
  fullName                : null,
  districtName            : null,
  overdueInspections      : 0,
  scheduledReinspections  : 0,
  dueNextMonthInspections : 0,
};

export default function userReducer(state = DEFAULT_STATE, action) {
  var newState = {};

  switch(action.type) {
    case 'UPDATE_USER':
      newState = Object.assign({}, state, action.user);
      break;
  }

  return Object.assign({}, state, newState);
}
