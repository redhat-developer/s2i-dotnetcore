import PropTypes from 'prop-types';
import React from 'react';
import { ButtonGroup, Button, Glyphicon, Alert } from 'react-bootstrap';
import _ from 'lodash';

import * as Constant from '../../constants';
import * as Api from '../../api';

import NotesAddDialog from './NotesAddDialog.jsx';
import ModalDialog from '../../components/ModalDialog.jsx';
import TableControl from '../../components/TableControl.jsx';
import DeleteButton from '../../components/DeleteButton.jsx';
import EditButton from '../../components/EditButton.jsx';

import { formatDateTimeUTCToLocal } from '../../utils/date';

class NotesDialog extends React.Component {
  static propTypes = {
    id: PropTypes.number.isRequired,
    show: PropTypes.bool,
    notes: PropTypes.array,
    // Api call to get notes for particular entity
    getNotes: PropTypes.func.isRequired,
    // Api function to call on save
    saveNote: PropTypes.func.isRequired,
    onClose: PropTypes.func.isRequired,
  };

  constructor(props) {
    super(props);

    this.state = {
      note: {},
      notes: props.notes || [],
    };
  }

  componentWillReceiveProps(nextProps) {
    if (!_.isEqual(this.props.notes, nextProps.notes)) {
      this.setState({ notes: nextProps.notes });
    }
  }

  openNotesAddDialog = () => {
    this.setState({ showNotesAddDialog: true });
  };

  closeNotesAddDialog = () => {
    this.setState({
      note: {},
      showNotesAddDialog: false,
    });
  };

  onNoteAdded = (note) => {
    this.setState({ notes: this.state.notes.concat([note]) });
    this.props.saveNote(this.props.id, note).then(() => {
      this.props.getNotes(this.props.id);
    });
    this.closeNotesAddDialog();
  };

  onNoteUpdated = (note) => {
    const noteId = note.id;
    const updatedNotes = this.state.notes.map((_note) => {
      return _note.id === noteId ? { ..._note, ...note } : _note;
    });

    this.setState({ notes: updatedNotes });
    Api.updateNote(note).then(() => {
      this.props.getNotes(this.props.id);
    });
    this.closeNotesAddDialog();
  };

  deleteNote = (note) => {
    const noteId = note.id;
    const updatedNotes = this.state.notes.filter((note) => {
      return note.id !== noteId;
    });

    this.setState({ notes: updatedNotes });
    Api.deleteNote(note.id).then(() => {
      this.props.getNotes(this.props.id);
    });
  };

  editNote = (note) => {
    this.setState({
      note: note,
      showNotesAddDialog: true,
    });
  };

  onClose = () => {
    this.props.onClose();
  };

  render() {
    const notes = _.orderBy(this.state.notes, ['createDate'], ['desc']);
    var headers = [{ field: 'date', title: 'Date' }, { field: 'note', title: 'Note' }, { field: 'blank' }];

    const showNoNotesMessage = !notes || notes.length === 0;

    return (
      <ModalDialog id="notes" show={this.props.show} onClose={this.onClose} title={<strong>Notes</strong>}>
        <TableControl id="notes-list" headers={headers}>
          {notes.map((note) => {
            return (
              <tr key={note.id}>
                <td className="nowrap">
                  {formatDateTimeUTCToLocal(note.createDate, Constant.DATE_YEAR_SHORT_MONTH_DAY)}
                </td>
                <td width="100%">{note.noteText}</td>
                <td style={{ textAlign: 'right', minWidth: '60px' }}>
                  <ButtonGroup>
                    <EditButton name="editNote" disabled={!note.id} onClick={this.editNote.bind(this, note)} />
                    <DeleteButton name="note" disabled={!note.id} onConfirm={this.deleteNote.bind(this, note)} />
                  </ButtonGroup>
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
        <Button title="Add Note" bsSize="small" onClick={this.openNotesAddDialog}>
          <Glyphicon glyph="plus" />
          &nbsp;<strong>Add Note</strong>
        </Button>
        {this.state.showNotesAddDialog && (
          <NotesAddDialog
            show={this.state.showNotesAddDialog}
            note={this.state.note}
            onSave={this.onNoteAdded}
            onUpdate={this.onNoteUpdated}
            onClose={this.closeNotesAddDialog}
          />
        )}
      </ModalDialog>
    );
  }
}

export default NotesDialog;
