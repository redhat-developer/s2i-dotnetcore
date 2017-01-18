import _ from 'lodash';

const DEFAULT_MODELS = {
  users: {},
  user: {},

  favourites: {},

  schoolBuses: {},
  schoolBus: {},
  schoolBusAttachments: {},
  schoolBusCCW: {},
  schoolBusHistories: {},
  schoolBusInspections: {},
  schoolBusNotes: {},

  owners: {},
  owner: {},
};

export default function modelsReducer(state = DEFAULT_MODELS, action) {
  switch(action.type) {
    // Users
    case 'UPDATE_USERS':
      return { ...state, users: action.users };

    case 'UPDATE_USER':
      return { ...state, user: action.user };

    // Favourites
    case 'UPDATE_FAVOURITES':
      return { ...state, favourites: action.favourites };

    case 'ADD_FAVOURITE':
      return { ...state, favourites: { ...state.favourites, ...action.favourite } };

    case 'UPDATE_FAVOURITE':
      return { ...state, favourites: { ...state.favourites, ...action.favourite } };

    case 'DELETE_FAVOURITE':
      return { ...state, favourites: _.omit(state.favourites, [ action.id ]) };

    // Buses
    case 'UPDATE_BUSES':
      return { ...state, schoolBuses: action.schoolBuses };

    case 'UPDATE_BUS':
      return { ...state, schoolBus: action.schoolBus };

    case 'UPDATE_BUS_ATTACHMENTS':
      return { ...state, schoolBusAttachments: action.schoolBusAttachments };

    case 'UPDATE_BUS_CCW':
      return { ...state, schoolBusCCW: action.schoolBusCCW };

    case 'UPDATE_BUS_HISTORIES':
      return { ...state, schoolBusHistories: action.schoolBusHistories };

    case 'UPDATE_BUS_INSPECTIONS':
      return { ...state, schoolBusInspections: action.schoolBusInspections };

    case 'UPDATE_BUS_NOTES':
      return { ...state, schoolBusNotes: action.schoolBusNotes };

    // Owners
    case 'UPDATE_OWNERS':
      return { ...state, owners: action.owners };

    case 'UPDATE_OWNER':
      return { ...state, owner: action.owner };
  }

  return state;
}
