import PropTypes from 'prop-types';
import React, { useState } from 'react';
import { ButtonGroup, Button, Glyphicon, Alert } from 'react-bootstrap';
import _ from 'lodash';

import * as Constant from '../../constants';

import NotesAddDialog from './NotesAddDialog.jsx';
import ModalDialog from '../../components/ModalDialog.jsx';
import TableControl from '../../components/TableControl.jsx';
import DeleteButton from '../../components/DeleteButton.jsx';
import EditButton from '../../components/EditButton.jsx';
import Authorize from '../../components/Authorize';

import { formatDateTimeUTCToLocal } from '../../utils/date';

const NotesDialog = (props) => {
  const { id, notes, addNote, updateNote, deleteNote, getNotes, show, onClose, permissions } = props;

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

  const headers = [
    { field: 'date', title: 'Date' },
    { field: 'note', title: 'Note' },
    { field: 'user', title: 'User' },
    { field: 'blank' },
  ];
  const showNoNotesMessage = !notes || notes.length === 0;
  const notesSorted = _.orderBy(notes, ['createTimestamp'], ['desc']);

  return (
    <ModalDialog id="notes" show={show} onClose={() => onClose()} title={<strong>Notes</strong>}>
      <TableControl id="notes-list" headers={headers}>
        {notesSorted.map((note) => {
          return (
            <tr key={note.id}>
              <td className="nowrap">
                {formatDateTimeUTCToLocal(note.createTimestamp, Constant.DATE_YEAR_SHORT_MONTH_DAY)}
              </td>
              <td width="100%">{note.noteText}</td>
              <td>{note.createUserid}</td>
              <td style={{ textAlign: 'right', minWidth: '60px' }}>
                <Authorize permissions={permissions}>
                  <ButtonGroup>
                    <EditButton name="editNote" disabled={!note.id} onClick={editNote(note)} />
                    <DeleteButton name="note" disabled={!note.id} onConfirm={onNoteDeleted(note)} />
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
      <Authorize permissions={permissions}>
        <Button title="Add Note" bsSize="small" onClick={openNotesAddDialog}>
          <Glyphicon glyph="plus" />
          &nbsp;<strong>Add Note</strong>
        </Button>
      </Authorize>

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
    </ModalDialog>
  );
};

NotesDialog.propTypes = {
  id: PropTypes.number.isRequired,
  show: PropTypes.bool,
  notes: PropTypes.array,
  getNotes: PropTypes.func.isRequired,
  addNote: PropTypes.func.isRequired,
  updateNote: PropTypes.func.isRequired,
  deleteNote: PropTypes.func.isRequired,
  onClose: PropTypes.func.isRequired,
  permisssions: PropTypes.oneOfType([PropTypes.string, PropTypes.arrayOf(PropTypes.string)]).isRequired,
};

export default NotesDialog;
