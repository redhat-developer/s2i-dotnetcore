import React from 'react';
import { Button, Modal } from 'react-bootstrap';
import { Form, FormGroup, FormControl, HelpBlock, ControlLabel, Checkbox } from 'react-bootstrap';

import _ from 'lodash';

import { isBlank } from '../../utils/string';

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
    favourite: React.PropTypes.object.isRequired,
    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
  },

  getInitialState() {
    return {
      name: this.props.favourite.name || '',
      isDefault: this.props.favourite.isDefault || false,
      nameError: '',
    };
  },

  componentDidMount() {
    this.input.focus();
  },

  nameChanged(e) {
    this.setState({ name: e.target.value });
  },

  defaultChanged(e) {
    this.setState({ isDefault: e.target.checked });
  },

  save() {
    if (isBlank(this.state.name)) {
      this.setState({ nameError: 'Name is required' });
    } else {
      this.props.onSave({ ...this.props.favourite, ...{
        name: this.state.name,
        isDefault: this.state.isDefault,
      }});
    }
  },

  render() {
    return <Modal id="edit-favourite" show={ this.props.show } bsSize="small" onHide={ this.props.onClose }>
      <Modal.Header closeButton>
        <Modal.Title>
          <strong>Favourite</strong>
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <FormGroup validationState={ this.state.nameError ? 'error' : null }>
            <ControlLabel>Name <sup>*</sup></ControlLabel>
            <FormControl type="text" defaultValue={ this.state.name } onChange={ this.nameChanged } inputRef={ ref => { this.input = ref; }} />
            <HelpBlock>{ this.state.nameError }</HelpBlock>
          </FormGroup>
          <Checkbox checked={ this.state.isDefault } onChange={ this.defaultChanged }>
            Default
          </Checkbox>
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
