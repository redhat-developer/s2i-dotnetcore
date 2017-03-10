import React from 'react';


// History Entity Types
export const BUS = 'School Bus';
export const OWNER = 'Owner';
export const USER = 'User';
export const ROLE = 'Role';
export const INSPECTION = 'Inspection';

// History Events
export const BUS_TEST = 'Testing School Bus %entity history.';
export const OWNER_TEST = 'Testing Owner %entity history.';

// Helper to create an entity object
export function makeEntity(type, id, description, url) {
  return {
    type: type,
    id: id,
    description: description,
    url: url,
  };
}

// Log a history event
export function log(type, id, event, ...entities) {
  var entry = {
    // Type should denote an entity
    entityType: type,
    // The ID for the corresponding type, if appropriate
    entityId: id,
    // The event text and entities as a JSON string
    event: JSON.stringify({
      // The event text, with entity placeholders
      text: event,
      // The array of entities
      entities: entities,
    }),
    // These fields will be added by the API server.
    id: null,
    userId: null,
    timestamp: null,
  };

  // TODO: API call to add entry.
  return entry;
}

export function renderEvent(entry) {
  try {
    // Unwrap the JSONed event
    var event = JSON.parse(entry.event);

    // Parse the text and return it inside a <div>, replacing field placeholders with linked content.
    var tokens = event.text.split('%entity');
    return <div>
      {
        tokens.map((token, index) => {
          return <span key={ index }>
            { token }
            { index < tokens.length - 1 ? buildLink(event.entities[index]) : null }
          </span>;
        })
      }
    </div>;
  } catch (err) {
    console.error('Bad JSON in history entry', err);
    return null;
  }
}

function buildLink(entity) {
  // Return a link if there's a path; just the description otherwise.
  return entity.url ? <a href={ `${ entity.url }` }>{ entity.description }</a> : <span>{ entity.description }</span>;
}

export function test() {
  var logged = log(BUS, 1, BUS_TEST, makeEntity(BUS, 1, 'Test Bus', 'http://google.com?q=school+buses+in+BC'));

  var rendered = renderEvent(logged);
  return rendered;
}
