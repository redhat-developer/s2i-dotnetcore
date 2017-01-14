const DEFAULT_MODELS = {
  users: {},
  user: {},

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
