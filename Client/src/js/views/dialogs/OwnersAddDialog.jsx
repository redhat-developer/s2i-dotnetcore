import React from "react";
import PropTypes from "prop-types";

import { connect } from "react-redux";

import { Form, FormGroup, HelpBlock, ControlLabel } from "react-bootstrap";

import _ from "lodash";

import * as Constant from "../../constants";

import EditDialog from "../../components/EditDialog.jsx";
import FormInputControl from "../../components/FormInputControl.jsx";

import { isBlank, notBlank } from "../../utils/string";

class OwnersAddDialog extends React.Component {
  static propTypes = {
    owners: PropTypes.object,
    onSave: PropTypes.func.isRequired,
    onClose: PropTypes.func.isRequired,
    show: PropTypes.bool,
  };

  state = {
    name: "",
    nameError: "",
  };

  componentDidMount() {
    this.input.focus();
  }

  updateState = (state, callback) => {
    this.setState(state, callback);
  };

  didChange = () => {
    return notBlank(this.state.name);
  };

  isValid = () => {
    if (isBlank(this.state.name)) {
      this.setState({ nameError: "Name is required" });
      return false;
    }
    // Does the name already exist?
    var name = this.state.name.toLowerCase().trim();
    var owner = _.find(this.props.owners, (owner) => {
      return owner.name.toLowerCase().trim() === name;
    });
    if (owner) {
      this.setState({ nameError: "This owner already exists in the system" });
      return false;
    }
    return true;
  };

  onSave = () => {
    this.props.onSave({
      name: this.state.name,
      status: Constant.STATUS_ACTIVE,
    });
  };

  render() {
    return (
      <EditDialog
        id="add-owner"
        show={this.props.show}
        bsSize="small"
        onClose={this.props.onClose}
        onSave={this.onSave}
        didChange={this.didChange}
        isValid={this.isValid}
        title={<strong>Add Owner</strong>}
      >
        <Form>
          <FormGroup
            controlId="name"
            validationState={this.state.nameError ? "error" : null}
          >
            <ControlLabel>
              Name <sup>*</sup>
            </ControlLabel>
            <FormInputControl
              type="text"
              value={this.state.name}
              updateState={this.updateState}
              inputRef={(ref) => {
                this.input = ref;
              }}
            />
            <HelpBlock>{this.state.nameError}</HelpBlock>
          </FormGroup>
        </Form>
      </EditDialog>
    );
  }
}

function mapStateToProps(state) {
  return {
    owners: state.lookups.owners,
  };
}

export default connect(mapStateToProps)(OwnersAddDialog);
