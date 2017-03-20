import React from 'react';

import * as Api from './api';
import * as Constant from './constants';


// History Entity Types
export const BUS = 'School Bus';
export const OWNER = 'Owner';
export const USER = 'User';
export const ROLE = 'Role';
export const INSPECTION = 'Inspection';

// History Events
export const BUS_ADDED = 'School Bus %e was added by Owner %e.';
export const BUS_MODIFIED = 'School Bus %e was modified.';
export const BUS_MODIFIED_OWNER = 'The owner of School Bus %e was changed to %e.';
export const BUS_MODIFIED_STATUS = 'The status of School Bus %e was changed';
export const BUS_PASSED_INSPECTION = 'School Bus %e passed an Inspection %e.';
export const BUS_FAILED_INSPECTION = 'School Bus %e failed an Inspection %e.';
export const BUS_OUT_OF_SERVICE = 'School Bus %e is out of service %e.';
export const BUS_PERMIT_GENERATED = 'School Bus %e - Permit';
export const BUS_INSPECTION_ADDED = 'School Bus %e - Inspection %e was added.';
export const BUS_INSPECTION_MODIFIED = 'School Bus %e - Inspection %e was modified.';
export const BUS_INSPECTION_DELETED = 'School Bus %e - Inspection %e was deleted.';

export const OWNER_ADDED = 'Owner %e was added.';
export const OWNER_MODIFIED = 'Owner %e was modified.';
export const OWNER_MODIFIED_STATUS = 'The status of %e was changed';
export const OWNER_ADDED_BUS = 'Owner %e added School Bus %e.';

export const USER_ADDED = 'User %e was added.';
export const USER_MODIFIED = 'User %e was modified.';
export const USER_DELETED = 'User %e was deleted.';

// Helper to create an entity object
export function makeHistoryEntity(type, entity) {
  return {
    type: type,
    id: entity.id,
    description: entity.name,
    url: entity.url,
    path: entity.path,
  };
}

// Log a history event
export function log(historyEntity, event, ...entities) {
  // prepend the 'parent' entity
  entities.unshift(historyEntity);

  // Build the history text
  var historyText = JSON.stringify({
    // The event text, with entity placeholders
    text: event,
    // The array of entities
    entities: entities,
  });

  // Choose the correct API call.
  var addHistoryPromise = null;

  switch (historyEntity.type) {
    case BUS:
      addHistoryPromise = Api.addSchoolBusHistory;
      break;

    case OWNER:
      addHistoryPromise = Api.addOwnerHistory;
      break;

    case USER:
      addHistoryPromise = Api.addUserHistory;
      break;
  }

  if (addHistoryPromise) {
    addHistoryPromise(historyEntity.id, {
      historyText: historyText,
    });
  }

  return historyText;
}

function buildLink(entity, closeFunc) {
  // Return a link if the entity has a path; just the description otherwise.
  return entity.path ? <a onClick={ closeFunc } href={ entity.url }>{ entity.description }</a> : <span>{ entity.description }</span>;
}

export function renderEvent(historyText, closeFunc) {
  try {
    // Unwrap the JSONed event
    var event = JSON.parse(historyText);

    // Parse the text and return it inside a <div>, replacing field placeholders with linked content.
    var tokens = event.text.split('%e');
    return <div>
      {
        tokens.map((token, index) => {
          return <span key={ index }>
            { token }
            { index < tokens.length - 1 ? buildLink(event.entities[index], closeFunc) : null }
          </span>;
        })
      }
    </div>;
  } catch (err) {
    // Not JSON so just push out what's in there.
    return <span>{ historyText }</span>;
  }
}

export function get(historyEntity, offset, limit) {
  // If not showing all, then just fetch the first 10 entries
  var params = {
    offset: offset || 0,
    limit: limit || null,
  };

  switch (historyEntity.type) {
    case BUS:
      return Api.getSchoolBusHistory(historyEntity.id, params);

    case OWNER:
      return Api.getOwnerHistory(historyEntity.id, params);

    case USER:
      return Api.getUserHistory(historyEntity.id, params);
  }

  return null;
}

// Logging
export function logNewBus(bus, owner) {
  log(bus.historyEntity, BUS_ADDED, owner.historyEntity);
  log(owner.historyEntity, OWNER_ADDED_BUS, bus.historyEntity);
}

export function logModifiedBus(bus) {
  log(bus.historyEntity, BUS_MODIFIED);
}

// Bus Details
export function logModifiedBusStatus(bus) {
  var event = BUS_MODIFIED_STATUS;
  // Check if status exists.
  if(typeof(bus.status) === 'string') {
    event += ' to ';
    event += bus.status;
  }
  event += '.';

  log(bus.historyEntity, event);
}

export function logModifiedBusOwner(bus) {
  // Temporary fix for owner.historyEntity async load issue
  var pathMock = 'owners/' + bus.schoolBusOwner.id;
  var ownerHistoryMock = {
    type: 'Owner',
    id: bus.schoolBusOwner.id,
    description: bus.ownerName,
    url: bus.ownerURL,
    path: pathMock,
  };

  log(bus.historyEntity, BUS_MODIFIED_OWNER, ownerHistoryMock);
  log(ownerHistoryMock, OWNER_ADDED_BUS, bus.historyEntity);
}

export function logGeneratedBusPermit(bus) {
  var event = BUS_PERMIT_GENERATED;
  
  if(bus.permitNumber) {
    event += ' #';
    event += (bus.permitNumber).toString();
  }
  event += ' was generated.';
  
  log(bus.historyEntity, event);
}

// Bus Inspection
export function logNewInspection(bus, inspection) {
  var event = null;

  if (inspection.inspectionResultCode === Constant.INSPECTION_RESULT_FAILED) {
    event = BUS_FAILED_INSPECTION;
  } else if (inspection.inspectionResultCode === Constant.INSPECTION_RESULT_PASSED) {
    event = BUS_PASSED_INSPECTION;
  } else if (inspection.inspectionResultCode === Constant.INSPECTION_RESULT_OUT_OF_SERVICE) {
    event = BUS_OUT_OF_SERVICE;
  }

  if (event) {
    log(bus.historyEntity, event, inspection.historyEntity);
  }
}

export function logModifiedInspection(bus, inspection) {
  log(bus.historyEntity, BUS_INSPECTION_MODIFIED, inspection.historyEntity);
}

export function logDeletedInspection(bus, inspection) {
  log(bus.historyEntity, BUS_INSPECTION_DELETED, inspection.historyEntity);
}

//// LOG OWNER
export function logNewOwner(owner) {
  log(owner.historyEntity, OWNER_ADDED);
}

export function logModifiedOwnerStatus(owner) {
  var event = OWNER_MODIFIED_STATUS;

  if(typeof(owner.status) === 'string') {
    event += ' to ';
    event += owner.status;
  }
  event += '.';
  console.log(event);
  log(owner.historyEntity, event);
}
