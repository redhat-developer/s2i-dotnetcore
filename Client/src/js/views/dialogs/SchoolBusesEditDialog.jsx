import React from 'react';
import { Button, Modal } from 'react-bootstrap';
import { Form, FormGroup, FormControl, HelpBlock, ControlLabel } from 'react-bootstrap';


/*

Don't have the separate pencil for the SBOwner. When the user
goes to edit the School Bus data, include the "School Bus Owner"
and "Status" fields as part of the edit.

Changing the School Bus Owner is related to
Moving a School Bus - SB-133. You can't add a
new School Bus Owner at this point.

Status can be "Active" and "Archived". There will likely
be a permission around the editing of the School Bus Owner
and the status of a bus. Deal with that later.

Out of Province is a CCW data element - not manually edited.

The pencil within the "School Bus Data" makes all of that
editable - minus "Restrictions" (see below)

School Bus Capacity and Mobility Aid Capacity are required fields on add and edit.

Restrictions is a bit magic. Here's how it will work:
  The "School Bus Class" drop down will have an associated "Restriction" text string for each option.
  When a new Class is selected, the "Restriction" text is set to the associated string.
  The user will be able to click a button ("Edit") beside the "Restriction" if they Really Really Really want to edit the text of the Restriction.
  If they do, show a note - "The permit restriction text should be changed only in rare circumstances. Are you sure? [Y] [N]"
  If they say yes - go ahead with the editing.

For now, the Regi/VIN/Plate cannot be edited. If needed, that would be a separate feature.

*/

var SchoolBusesEditDialog = React.createClass({
  propTypes: {
    schoolBus: React.PropTypes.object.isRequired,
    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
  },

  getInitialState() {
    return {
      field: '',
      fieldError: false,
    };
  },

  componentDidMount() {
    this.input.focus();
  },

  fieldChanged(e) {
    this.setState({ field: e.target.value });
  },

  save() {
  },

  render() {
    return <Modal id="school-buses-edit" show={ this.props.show } bsSize="large" onHide={ this.props.onClose }>
      <Modal.Header closeButton>
        <Modal.Title>
          <strong>School Bus</strong>
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <FormGroup validationState={ this.state.fieldError ? 'error' : null }>
            <ControlLabel>Field <sup>*</sup></ControlLabel>
            <FormControl type="text" defaultValue={ this.state.field } onChange={ this.fieldChanged } inputRef={ ref => { this.input = ref; }} />
            <HelpBlock>{ this.state.fieldError }</HelpBlock>
          </FormGroup>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button onClick={ this.props.onClose }>Close</Button>
        <Button bsStyle="primary" onClick={ this.save }>Save</Button>
      </Modal.Footer>
    </Modal>;
  },
});

export default SchoolBusesEditDialog;
