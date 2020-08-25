import * as Action from '../actionTypes';

const DEFAULT_LOOKUPS = {
  cities: {},
  districts: {},
  regions: {},
  schoolDistricts: {},
  serviceAreas: {},
  permissions: {},

  owners: {},
  inspectors: {},
  roles: {},
};

export default function lookupsReducer(state = DEFAULT_LOOKUPS, action) {
  switch (action.type) {
    // Loaded once at init time, as they do not change very often, and
    // certainly not within the app.

    case Action.UPDATE_CITIES_LOOKUP:
      return { ...state, cities: action.cities };

    case Action.UPDATE_DISTRICTS_LOOKUP:
      return { ...state, districts: action.districts };

    case Action.UPDATE_REGIONS_LOOKUP:
      return { ...state, regions: action.regions };

    case Action.UPDATE_SCHOOL_DISTRICTS_LOOKUP:
      return { ...state, schoolDistricts: action.schoolDistricts };

    case Action.UPDATE_SERVICE_AREAS_LOOKUP:
      return { ...state, serviceAreas: action.serviceAreas };

    case Action.UPDATE_PERMISSIONS_LOOKUP:
      return { ...state, permissions: action.permissions };

    // Not typical lookups, because they can change within the app, so
    // ensure they're loaded/updated as needed.

    case Action.UPDATE_OWNERS_LOOKUP:
      return { ...state, owners: action.owners };

    case Action.UPDATE_INSPECTORS_LOOKUP:
      return { ...state, inspectors: action.inspectors };

    case Action.UPDATE_ROLES_LOOKUP:
      return { ...state, roles: action.roles };

    default:
      return state;
  }
}
