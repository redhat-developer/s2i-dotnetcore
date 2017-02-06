import React from 'react';

import { connect } from 'react-redux';

import { Grid, Row, Col } from 'react-bootstrap';
import { Form, FormGroup, HelpBlock, ControlLabel } from 'react-bootstrap';

import * as Constant from '../../constants';

import DropdownControl from '../../components/DropdownControl.jsx';
import EditDialog from '../../components/EditDialog.jsx';
import FormInputControl from '../../components/FormInputControl.jsx';

import { isBlank } from '../../utils/string';

var OwnersEditDialog = React.createClass({
  propTypes: {
    owner: React.PropTypes.object,
    owners: React.PropTypes.object,

    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
  },

  getInitialState() {
    return {
      isNew: this.props.owner.id === 0,

      status: this.props.owner.status || Constant.STATUS_ACTIVE,
      name: this.props.owner.name || '',

      nameError: false,
    };
  },

  componentDidMount() {
    this.input.focus();
  },

  updateState(state, callback) {
    this.setState(state, callback);
  },

  didChange() {
    if (this.state.status !== this.props.owner.status) { return true; }
    if (this.state.name !== this.props.owner.name) { return true; }

    return false;
  },

  isValid() {
    this.setState({
      nameError: false,
    });

    var valid = true;

    if (isBlank(this.state.name)) {
      this.setState({ nameError: 'Name is required' });
      valid = false;
    }

    return valid;
  },

  onSave() {
    this.props.onSave({ ...this.props.owner, ...{
      status: this.state.status,
      name: this.state.name,
    }});
  },

  render() {
    return <EditDialog id="owners-edit" show={ this.props.show }
      onClose={ this.props.onClose } onSave={ this.onSave } didChange={ this.didChange } isValid={ this.isValid }
      title= { <strong>School Bus Owner </strong> }>
      {(() => {
        return <Form>
          <Grid fluid>
            <Row>
              <Col md={3}>
                <FormGroup controlId="status">
                  <ControlLabel>Status</ControlLabel>
                  <DropdownControl id="status" title={ this.state.status } updateState={ this.updateState }
                    items={[ Constant.STATUS_ACTIVE, Constant.STATUS_ARCHIVED ]}
                  />
                </FormGroup>
              </Col>
              <Col md={9}>
                <FormGroup controlId="name" validationState={ this.state.nameError ? 'error' : null }>
                  <ControlLabel>Name <sup>*</sup></ControlLabel>
                  <FormInputControl type="text" defaultValue={ this.state.name } updateState={ this.updateState } inputRef={ ref => { this.input = ref; }}/>
                  <HelpBlock>{ this.state.nameError }</HelpBlock>
                </FormGroup>
              </Col>
            </Row>
          </Grid>
        </Form>;
      })()}
    </EditDialog>;
  },
});

function mapStateToProps(state) {
  return {
    owner: state.models.owner,
    owners: state.lookups.owners,
  };
}

export default connect(mapStateToProps)(OwnersEditDialog);
