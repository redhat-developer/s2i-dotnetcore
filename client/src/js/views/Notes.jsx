import PropTypes from 'prop-types';
import React, { useState } from 'react';
import { ButtonGroup, Button, Glyphicon, Alert, Well } from 'react-bootstrap';
import _ from 'lodash';

import * as Constant from '../constants';

import NotesAddDialog from './dialogs/NotesAddDialog.jsx';
import ModalDialog from '../components/ModalDialog.jsx';
import TableControl from '../components/TableControl.jsx';
import DeleteButton from '../components/DeleteButton.jsx';
import EditButton from '../components/EditButton.jsx';
import Authorize from '../components/Authorize';

import { formatDateTimeUTCToLocal } from '../utils/date';

const Notes = (props) => {
  const { id, notes, addNote, updateNote, deleteNote, getNotes, show, onClose, permissions, isDialog } = props;

  const [noteEditing, setNoteEditing] = useState({});
  const [showNotesAddDialog, setShowNotesAddDialog] = useState(false);

  const openNotesAddDialog = () => {
    setShowNotesAddDialog(true);
  };

  const closeNotesAddDialog = () => {
    setShowNotesAddDialog(false);
    setNoteEditing({});
  };

  const onNoteAdded = (note) => {
    addNote(id, note).then(() => {
      getNotes(id);
    });
    closeNotesAddDialog();
  };

  const onNoteUpdated = (note) => {
    updateNote(id, note).then(() => {
      getNotes(id);
    });
    closeNotesAddDialog();
  };

  const onNoteDeleted = (note) => () => {
    deleteNote(id, note.id).then(() => {
      getNotes(id);
    });
  };

  const editNote = (note) => () => {
    setNoteEditing(note);
    setShowNotesAddDialog(true);
  };

  var addNoteButton = (
    <Authorize permissions={permissions}>
      <Button title="Add Note" bsSize="xsmall" onClick={openNotesAddDialog}>
        <Glyphicon glyph="plus" />
        &nbsp;<strong>Add</strong>
      </Button>
    </Authorize>
  );

  const headers = [
    { field: 'date', title: 'Date' },
    { field: 'note', title: 'Note' },
    { field: 'user', title: 'User' },
    { node: addNoteButton },
  ];

  const showNoNotesMessage = !notes || notes.length === 0;
  const notesSorted = _.orderBy(notes, ['noteDate'], ['desc']);

  const NoteList = () => {
    return (
      <>
        <TableControl id="notes-list" headers={headers}>
          {notesSorted.map((note) => {
            return (
              <tr key={note.id}>
                <td className="nowrap">
                  {formatDateTimeUTCToLocal(note.noteDate, Constant.DATE_YEAR_SHORT_MONTH_DAY)}
                </td>
                <td width="100%">{note.noteText}</td>
                <td>{note.userId}</td>
                <td style={{ textAlign: 'right', minWidth: '60px' }}>
                  <Authorize permissions={permissions}>
                    <ButtonGroup>
                      <DeleteButton name="note" disabled={!note.id} onConfirm={onNoteDeleted(note)} />
                      <EditButton name="editNote" disabled={!note.id} onClick={editNote(note)} />
                    </ButtonGroup>
                  </Authorize>
                </td>
              </tr>
            );
          })}
        </TableControl>
        {showNoNotesMessage && (
          <Alert bsStyle="success" style={{ marginTop: 10 }}>
            No notes
          </Alert>
        )}

        {showNotesAddDialog && (
          <NotesAddDialog
            show={showNotesAddDialog}
            id={id}
            note={noteEditing}
            onAdd={onNoteAdded}
            onUpdate={onNoteUpdated}
            onClose={closeNotesAddDialog}
          />
        )}
      </>
    );
  };

  if (isDialog) {
    return (
      <ModalDialog id="notes" show={show} onClose={() => onClose()} title={<strong>Notes</strong>}>
        {NoteList()}
      </ModalDialog>
    );
  } else {
    return (
      <Well>
        <h3>
          <strong>Notes</strong>
        </h3>
        {NoteList()}
      </Well>
    );
  }
};

Notes.propTypes = {
  id: PropTypes.number.isRequired,
  show: PropTypes.bool,
  notes: PropTypes.array,
  getNotes: PropTypes.func.isRequired,
  addNote: PropTypes.func.isRequired,
  updateNote: PropTypes.func.isRequired,
  deleteNote: PropTypes.func.isRequired,
  onClose: PropTypes.func.isRequired,
  permisssions: PropTypes.oneOfType([PropTypes.string, PropTypes.arrayOf(PropTypes.string)]).isRequired,
  isDialog: PropTypes.bool.isRequired,
};

export default Notes;
