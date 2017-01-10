const DEFAULT_LOOKUPS = {
  cities: {},
  districts: {},
  regions: {},
  schoolDistricts: {},
  serviceAreas: {},
};

export default function lookupsReducer(state = DEFAULT_LOOKUPS, action) {
  var newState = {};

  switch(action.type) {
    case 'UPDATE_CITIES':
      newState = { ...state, ...action.cities };
      break;

    case 'UPDATE_DISTRICTS':
      newState = { ...state, ...action.districts };
      break;

    case 'UPDATE_REGIONS':
      newState = { ...state, ...action.regions };
      break;

    case 'UPDATE_SCHOOL_DISTRICTS':
      newState = { ...state, ...action.schoolDistricts };
      break;

    case 'UPDATE_SERVICE_AREAS':
      newState = { ...state, ...action.serviceAreas };
      break;
  }

  return { ...state, ...newState };
}
