import PropTypes from 'prop-types';
import React from 'react';

import { FormGroup, ControlLabel, HelpBlock } from 'react-bootstrap';

import FormDialog from '../../components/FormDialog.jsx';
import FormInputControl from '../../components/FormInputControl.jsx';

import * as Constant from '../../constants';

import { isBlank } from '../../utils/string';

class NotesAddDialog extends React.Component {
  static propTypes = {
    onAdd: PropTypes.func.isRequired,
    onUpdate: PropTypes.func.isRequired,
    onClose: PropTypes.func.isRequired,
    show: PropTypes.bool,
    id: PropTypes.number.isRequired,
    note: PropTypes.object,
  };

  constructor(props) {
    super(props);

    this.state = {
      noteId: props.note.id || 0,
      noteText: props.note.noteText || '',
      noteError: '',
      isNoLongerRelevant: false,
    };
  }

  updateState = (state, callback) => {
    this.setState(state, callback);
  };

  didChange = () => {
    if (this.props.note.noteText !== this.state.noteText) {
      return true;
    }

    return false;
  };

  isValid = () => {
    this.setState({
      noteError: '',
    });

    var valid = true;

    if (isBlank(this.state.noteText)) {
      this.setState({ noteError: 'Note is required' });
      valid = false;
    }

    return valid;
  };

  onFormSubmitted = () => {
    if (this.isValid()) {
      if (this.didChange()) {
        // If note id === 0 then you are adding a new note, otherwise you are updating an existing note
        if (this.state.noteId === 0) {
          this.props.onAdd({
            id: 0,
            schoolBusId: this.props.id,
            noteText: this.state.noteText,
            isNoLongerRelevant: false,
          });
        } else {
          console.log(this.props.id);
          this.props.onUpdate({
            id: this.state.noteId,
            schoolBusId: this.props.id,
            noteText: this.state.noteText,
            isNoLongerRelevant: false,
          });
        }
      } else {
        this.props.onClose();
      }
    }
  };

  render() {
    const { noteId } = this.state;
    var maxLength = Constant.MAX_LENGTH_NOTE_TEXT;

    return (
      <FormDialog
        id="notes"
        title={noteId ? 'Edit Note' : 'Add Note'}
        show={this.props.show}
        onClose={this.props.onClose}
        onSubmit={this.onFormSubmitted}
      >
        <FormGroup controlId="noteText" validationState={this.state.noteError ? 'error' : null}>
          <ControlLabel>Note</ControlLabel>
          <FormInputControl
            value={this.state.noteText}
            componentClass="textarea"
            updateState={this.updateState}
            maxLength={maxLength}
          />
          <HelpBlock>{this.state.noteError}</HelpBlock>
          <p>Maximum {maxLength} characters.</p>
        </FormGroup>
      </FormDialog>
    );
  }
}

export default NotesAddDialog;
