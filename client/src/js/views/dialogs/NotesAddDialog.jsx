import PropTypes from 'prop-types';
import React, { useState } from 'react';

import { FormGroup, ControlLabel, HelpBlock } from 'react-bootstrap';

import FormDialog from '../../components/FormDialog.jsx';
import FormInputControl from '../../components/FormInputControl.jsx';

import * as Constant from '../../constants';

import { isBlank } from '../../utils/string';

const NotesAddDialog = (props) => {
  const { id, parentIdColumn, note, onAdd, onUpdate, show, onClose } = props;
  const noteId = note.id || 0;
  const [noteText, setNoteText] = useState(note.noteText || '');
  const [noteError, setNoteError] = useState('');
  const maxLength = Constant.MAX_LENGTH_NOTE_TEXT;

  const didChange = () => note.noteText !== noteText;

  const isValid = () => {
    setNoteError('');

    var valid = true;

    if (isBlank(noteText)) {
      setNoteError('Note is required');
      valid = false;
    }

    return valid;
  };

  const onFormSubmitted = () => {
    if (isValid()) {
      if (didChange()) {
        // If note id === 0 then you are adding a new note, otherwise you are updating an existing note
        if (noteId === 0) {
          onAdd({
            id: 0,
            [parentIdColumn]: id,
            noteText: noteText,
            isNoLongerRelevant: false,
          });
        } else {
          onUpdate({
            id: noteId,
            [parentIdColumn]: id,
            noteText: noteText,
            isNoLongerRelevant: false,
          });
        }
      } else {
        onClose();
      }
    }
  };

  return (
    <FormDialog
      id="notes"
      title={noteId ? 'Edit Note' : 'Add Note'}
      show={show}
      onClose={onClose}
      onSubmit={onFormSubmitted}
    >
      <FormGroup controlId="noteText" validationState={noteError ? 'error' : null}>
        <ControlLabel>Note</ControlLabel>
        <FormInputControl
          value={noteText}
          componentClass="textarea"
          updateState={(e) => setNoteText(e.noteText)}
          maxLength={maxLength}
        />
        <HelpBlock>{noteError}</HelpBlock>
        <p>Maximum {maxLength} characters.</p>
      </FormGroup>
    </FormDialog>
  );
};

NotesAddDialog.propTypes = {
  onAdd: PropTypes.func.isRequired,
  onUpdate: PropTypes.func.isRequired,
  onClose: PropTypes.func.isRequired,
  show: PropTypes.bool,
  id: PropTypes.number.isRequired,
  parentIdColumn: PropTypes.number.isRequired,
  note: PropTypes.object,
};

export default NotesAddDialog;
