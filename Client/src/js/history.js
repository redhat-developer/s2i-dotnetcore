import React from 'react';


// Logging history events. Note that the current user ID and a timestamp will
// be added to the entry when it is received by the API server.
export function log(type, id, event) {
  var entry = {
    // Type should denote an area of the app, suggest using PATHNAME constants here
    entityType: type,
    // The ID for the corresponding type, if appropriate
    entityId: id,
    // An event object example:
    //   {
    //     text: 'School Bus {0} was added to Owner {1}',
    //     fields: [{
    //       text: 'VIN ABC123DEF456',
    //       path: 'school-buses/200001'
    //     },{
    //       text: 'Thompson Bus Barn',
    //       path: 'owners/200001'
    //     }],
    //   }
    //
    // Kind of clunky, but we're working on it
    eventText: JSON.stringify(event),
  };

  // TODO: API call to add entry.
  return entry;
}

export function renderEvent(entry) {
  try {
    // Unwrap the JSONed event
    var event = JSON.parse(entry.eventText);

    // Parse the text and return it inside a <div>, replacing field placeholders
    // with linked content.
    var tokens = event.text.split(/{\d+}/g);
    return <div>
      {
        tokens.map((token, index) => {
          return <span>
            { token }
            { index < tokens.length - 1 ? buildLink(event.fields[index]) : null }
          </span>;
        })
      }
    </div>;
  } catch (err) {
    console.error('Bad JSON in history entry', err);
    return null;
  }
}

function buildLink(field) {
  // Return a link if there's a path; just the text otherwise.
  return field.path ? <a href={ `#/${ field.path }` }>{ field.text }</a> : <span>{ field.text }</span>;
}

export function test() {
  var logged = log('school-buses', 1, {
    text: 'School Bus {0} was printed.',
    fields: [{
      text: '(VIN 2FTRX08L0YCA33666)',
      path: 'school-buses/1',
    }],
  });

  var rendered = renderEvent(logged);
  return rendered;
}
