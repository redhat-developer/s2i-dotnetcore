import _ from "lodash";

import * as Action from "../actionTypes";

const DEFAULT_MODELS = {
  favourites: {},

  users: {},
  user: {},

  schoolBuses: {},
  schoolBus: {},
  schoolBusAttachments: {},
  schoolBusCCW: {},
  schoolBusInspections: {},
  schoolBusNotes: {},

  inspection: {},

  ownerContacts: {},
  contact: {},

  owners: {},
  owner: {},

  roles: {},
  role: {},
  rolePermissions: {},

  history: {},
};

export default function modelsReducer(state = DEFAULT_MODELS, action) {
  switch (action.type) {
    // Favourites
    case Action.UPDATE_FAVOURITES:
      return { ...state, favourites: action.favourites };

    case Action.ADD_FAVOURITE:
      return {
        ...state,
        favourites: { ...state.favourites, ...action.favourite },
      };

    case Action.UPDATE_FAVOURITE:
      return {
        ...state,
        favourites: { ...state.favourites, ...action.favourite },
      };

    case Action.DELETE_FAVOURITE:
      return { ...state, favourites: _.omit(state.favourites, [action.id]) };

    // Users
    case Action.UPDATE_USERS:
      return { ...state, users: action.users };

    case Action.UPDATE_USER:
      return { ...state, user: action.user };

    case Action.ADD_USER:
      return { ...state, user: action.user };

    case Action.DELETE_USER:
      return { ...state, user: action.user };

    case Action.UPDATE_INSPECTORS:
      return { ...state, inspectors: action.inspectors };

    // Buses
    case Action.UPDATE_BUSES:
      return { ...state, schoolBuses: action.schoolBuses };

    case Action.ADD_BUS:
      return { ...state, schoolBus: action.schoolBus };

    case Action.UPDATE_BUS:
      return { ...state, schoolBus: action.schoolBus };

    case Action.DELETE_BUS:
      return { ...state, schoolBus: action.schoolBus };

    case Action.UPDATE_BUS_ATTACHMENTS:
      return { ...state, schoolBusAttachments: action.schoolBusAttachments };

    case Action.ADD_BUS_CCW:
      return { ...state, schoolBusCCW: action.schoolBusCCW };

    case Action.UPDATE_BUS_CCW:
      return { ...state, schoolBusCCW: action.schoolBusCCW };

    case Action.UPDATE_BUS_INSPECTIONS:
      return { ...state, schoolBusInspections: action.schoolBusInspections };

    case Action.UPDATE_BUS_NOTES:
      return { ...state, schoolBusNotes: action.schoolBusNotes };

    // Inspections
    case Action.ADD_INSPECTION:
      return { ...state, inspection: action.inspection };

    case Action.UPDATE_INSPECTION:
      return { ...state, inspection: action.inspection };

    case Action.DELETE_INSPECTION:
      return { ...state, inspection: action.inspection };

    //Contacts
    case Action.ADD_CONTACT:
      return { ...state, contact: action.contact };

    case Action.UPDATE_CONTACT:
      return { ...state, contact: action.contact };

    case Action.DELETE_CONTACT:
      return { ...state, contact: action.contact };

    // Owners
    case Action.UPDATE_OWNER_CONTACTS:
      return { ...state, ownerContacts: action.ownerContacts };

    case Action.UPDATE_OWNERS:
      return { ...state, owners: action.owners };

    case Action.ADD_OWNER:
      return { ...state, owner: action.owner };

    case Action.UPDATE_OWNER:
      return { ...state, owner: action.owner };

    case Action.DELETE_OWNER:
      return { ...state, owner: action.owner };

    // Roles/Permissions
    case Action.UPDATE_ROLES:
      return { ...state, roles: action.roles };

    case Action.ADD_ROLE:
      return { ...state, role: action.role };

    case Action.UPDATE_ROLE:
      return { ...state, role: action.role };

    case Action.DELETE_ROLE:
      return { ...state, role: action.role };

    case Action.UPDATE_ROLE_PERMISSIONS:
      return { ...state, rolePermissions: action.rolePermissions };

    // History
    case Action.UPDATE_HISTORY:
      return { ...state, history: action.history };
    default:
      return state;
  }
}
