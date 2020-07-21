import React from "react";
import PropTypes from "prop-types";

import { connect } from "react-redux";

import { Grid, Row, Col } from "react-bootstrap";
import { Form, FormGroup, HelpBlock, ControlLabel } from "react-bootstrap";

import _ from "lodash";

import * as Api from "../../api";
import * as Constant from "../../constants";

import DropdownControl from "../../components/DropdownControl.jsx";
import EditDialog from "../../components/EditDialog.jsx";
import FormInputControl from "../../components/FormInputControl.jsx";
import Spinner from "../../components/Spinner.jsx";

import { isBlank } from "../../utils/string";

class OwnersEditDialog extends React.Component {
  static propTypes = {
    owner: PropTypes.object,
    owners: PropTypes.object,

    onSave: PropTypes.func.isRequired,
    onClose: PropTypes.func.isRequired,
    show: PropTypes.bool,
  };

  state = {
    loading: false,

    status: this.props.owner.status || Constant.STATUS_ACTIVE,
    name: this.props.owner.name || "",

    nameError: false,
  };

  componentDidMount() {
    this.setState({ loading: true });
    Api.getOwners().finally(() => {
      this.setState({ loading: false }, () => {
        this.input.focus();
      });
    });
  }

  updateState = (state, callback) => {
    this.setState(state, callback);
  };

  didChange = () => {
    if (this.state.status !== this.props.owner.status) {
      return true;
    }
    if (this.state.name !== this.props.owner.name) {
      return true;
    }
    return false;
  };

  isValid = () => {
    this.setState({
      nameError: false,
    });

    if (isBlank(this.state.name)) {
      this.setState({ nameError: "Name is required" });
      return false;
    }

    // Does the name already exist?
    var name = this.state.name.toLowerCase().trim();
    var owner = _.find(this.props.owners, (owner) => {
      return owner.name.toLowerCase().trim() === name;
    });
    // Make sure it isn't this owner
    if (owner && owner.id !== this.props.owner.id) {
      this.setState({ nameError: "This owner already exists in the system" });
      return false;
    }

    return true;
  };

  onSave = () => {
    this.props.onSave({
      ...this.props.owner,
      ...{
        status: this.state.status,
        name: this.state.name,
      },
    });
  };

  render() {
    if (this.state.loading) {
      return (
        <div style={{ textAlign: "center" }}>
          <Spinner />
        </div>
      );
    }
    return (
      <EditDialog
        id="owners-edit"
        show={this.props.show}
        onClose={this.props.onClose}
        onSave={this.onSave}
        didChange={this.didChange}
        isValid={this.isValid}
        title={<strong>School Bus Owner</strong>}
      >
        {(() => {
          return (
            <Form>
              <Grid fluid>
                <Row>
                  <Col md={3}>
                    <FormGroup controlId="status">
                      <ControlLabel>Status</ControlLabel>
                      <DropdownControl
                        id="status"
                        title={this.state.status}
                        updateState={this.updateState}
                        items={[
                          Constant.STATUS_ACTIVE,
                          Constant.STATUS_ARCHIVED,
                        ]}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={9}>
                    <FormGroup
                      controlId="name"
                      validationState={this.state.nameError ? "error" : null}
                    >
                      <ControlLabel>
                        Name <sup>*</sup>
                      </ControlLabel>
                      <FormInputControl
                        type="text"
                        defaultValue={this.state.name}
                        updateState={this.updateState}
                        inputRef={(ref) => {
                          this.input = ref;
                        }}
                      />
                      <HelpBlock>{this.state.nameError}</HelpBlock>
                    </FormGroup>
                  </Col>
                </Row>
              </Grid>
            </Form>
          );
        })()}
      </EditDialog>
    );
  }
}

function mapStateToProps(state) {
  return {
    owner: state.models.owner,
    owners: state.lookups.owners,
  };
}

export default connect(mapStateToProps)(OwnersEditDialog);
