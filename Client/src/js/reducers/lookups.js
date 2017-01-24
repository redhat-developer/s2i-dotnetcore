const DEFAULT_LOOKUPS = {
  cities: {},
  districts: {},
  regions: {},
  schoolDistricts: {},
  serviceAreas: {},
  groups: {},
};

export default function lookupsReducer(state = DEFAULT_LOOKUPS, action) {
  switch(action.type) {
    case 'UPDATE_CITIES':
      return { ...state, cities: action.cities };

    case 'UPDATE_DISTRICTS':
      return { ...state, districts: action.districts };

    case 'UPDATE_REGIONS':
      return { ...state, regions: action.regions };

    case 'UPDATE_SCHOOL_DISTRICTS':
      return { ...state, schoolDistricts: action.schoolDistricts };

    case 'UPDATE_SERVICE_AREAS':
      return { ...state, serviceAreas: action.serviceAreas };

    case 'UPDATE_GROUPS':
      return { ...state, groups: action.groups };
  }

  return state;
}
