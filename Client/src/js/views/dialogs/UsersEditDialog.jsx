import React from "react";
import PropTypes from "prop-types";

import { connect } from "react-redux";

import { Grid, Row, Col } from "react-bootstrap";
import { Form, FormGroup, HelpBlock, ControlLabel } from "react-bootstrap";

import _ from "lodash";

import * as Constant from "../../constants";

import DropdownControl from "../../components/DropdownControl.jsx";
import EditDialog from "../../components/EditDialog.jsx";
import FilterDropdown from "../../components/FilterDropdown.jsx";
import FormInputControl from "../../components/FormInputControl.jsx";
import MultiDropdown from "../../components/MultiDropdown.jsx";

import { isBlank } from "../../utils/string";

class UsersEditDialog extends React.Component {
  static propTypes = {
    user: PropTypes.object,
    districts: PropTypes.object,
    groups: PropTypes.object,

    onSave: PropTypes.func.isRequired,
    onClose: PropTypes.func.isRequired,
    show: PropTypes.bool,
  };

  state = {
    isNew: this.props.user.id === 0,

    active: this.props.user.active === true,
    givenName: this.props.user.givenName || "",
    surname: this.props.user.surname || "",
    smUserId: this.props.user.smUserId || "",
    email: this.props.user.email || "",
    districtId: this.props.user.district.id || 0,
    selectedGroupsIds:
      this.props.user.groupIds.map((groupIds) => {
        return groupIds.groupId;
      }) || [],

    status: this.props.user.active
      ? Constant.STATUS_ACTIVE
      : Constant.STATUS_ARCHIVED,

    givenNameError: false,
    surnameError: false,
    smUserIdError: false,
    emailError: false,
    districtIdError: false,
    selectedGroupsIdsError: false,
  };

  componentDidMount() {
    this.input.focus();
  }

  updateState = (state, callback) => {
    this.setState(state, callback);
  };

  updateStatus = (state, callback) => {
    this.setState(
      {
        status: state.status,
        active: state.status === Constant.STATUS_ACTIVE,
      },
      callback
    );
  };

  didChange = () => {
    if (this.state.active !== this.props.user.active) {
      return true;
    }
    if (this.state.givenName !== this.props.user.givenName) {
      return true;
    }
    if (this.state.surname !== this.props.user.surname) {
      return true;
    }
    if (this.state.smUserId !== this.props.user.smUserId) {
      return true;
    }
    if (this.state.email !== this.props.user.email) {
      return true;
    }
    if (this.state.districtId !== this.props.user.districtId) {
      return true;
    }
    if (!_.isEqual(this.state.selectedGroupsIds, this.props.user.groupIds)) {
      return true;
    }

    return false;
  };

  isValid = () => {
    this.setState({
      givenNameError: false,
      surnameError: false,
      smUserIdError: false,
      emailError: false,
      districtIdError: false,
      selectedGroupsIdsError: false,
    });

    var valid = true;

    if (isBlank(this.state.givenName)) {
      this.setState({ givenNameError: "Given Name is required" });
      valid = false;
    }

    if (isBlank(this.state.surname)) {
      this.setState({ surnameError: "Surname is required" });
      valid = false;
    }

    if (isBlank(this.state.smUserId)) {
      this.setState({ smUserIdError: "User ID is required" });
      valid = false;
    }

    if (isBlank(this.state.email)) {
      this.setState({ emailError: "E-mail address is required" });
      valid = false;
    }

    if (this.state.districtId === 0) {
      this.setState({ districtIdError: "District is required" });
      valid = false;
    }

    if (this.state.selectedGroupsIds.length === 0) {
      this.setState({ selectedGroupsIdsError: "Group is required" });
      valid = false;
    }

    return valid;
  };

  onSave = () => {
    this.props.onSave({
      ...this.props.user,
      ...{
        active: this.state.active,
        givenName: this.state.givenName,
        surname: this.state.surname,
        smUserId: this.state.smUserId,
        email: this.state.email,
        district: { id: this.state.districtId },
        groupIds: this.state.selectedGroupsIds.map((groupId) => {
          return { groupId: groupId };
        }),
      },
    });
  };

  render() {
    var districts = _.sortBy(this.props.districts, "name");
    var groups = _.sortBy(this.props.groups, "name");

    return (
      <EditDialog
        id="users-edit"
        show={this.props.show}
        bsSize="large"
        onClose={this.props.onClose}
        onSave={this.onSave}
        didChange={this.didChange}
        isValid={this.isValid}
        title={<strong>User</strong>}
      >
        {(() => {
          return (
            <Form>
              <Grid fluid>
                <Row>
                  <Col md={4}>
                    <FormGroup
                      controlId="givenName"
                      validationState={
                        this.state.givenNameError ? "error" : null
                      }
                    >
                      <ControlLabel>
                        Given Name <sup>*</sup>
                      </ControlLabel>
                      <FormInputControl
                        type="text"
                        defaultValue={this.state.givenName}
                        updateState={this.updateState}
                        inputRef={(ref) => {
                          this.input = ref;
                        }}
                      />
                      <HelpBlock>{this.state.givenNameError}</HelpBlock>
                    </FormGroup>
                  </Col>
                  <Col md={4}>
                    <FormGroup
                      controlId="surname"
                      validationState={this.state.surnameError ? "error" : null}
                    >
                      <ControlLabel>
                        Surname <sup>*</sup>
                      </ControlLabel>
                      <FormInputControl
                        type="text"
                        defaultValue={this.state.surname}
                        updateState={this.updateState}
                      />
                      <HelpBlock>{this.state.surnameError}</HelpBlock>
                    </FormGroup>
                  </Col>
                  <Col md={2}>
                    <FormGroup
                      controlId="smUserId"
                      validationState={
                        this.state.smUserIdError ? "error" : null
                      }
                    >
                      <ControlLabel>
                        User ID <sup>*</sup>
                      </ControlLabel>
                      <FormInputControl
                        type="text"
                        defaultValue={this.state.smUserId}
                        updateState={this.updateState}
                      />
                      <HelpBlock>{this.state.smUserIdError}</HelpBlock>
                    </FormGroup>
                  </Col>
                  <Col md={2}>
                    <FormGroup controlId="status">
                      <ControlLabel>Status</ControlLabel>
                      <DropdownControl
                        id="status"
                        title={this.state.status}
                        updateState={this.updateStatus}
                        items={[
                          Constant.STATUS_ACTIVE,
                          Constant.STATUS_ARCHIVED,
                        ]}
                      />
                    </FormGroup>
                  </Col>
                </Row>
                <Row>
                  <Col md={4}>
                    <FormGroup
                      controlId="email"
                      validationState={this.state.emailError ? "error" : null}
                    >
                      <ControlLabel>
                        E-mail <sup>*</sup>
                      </ControlLabel>
                      <FormInputControl
                        type="text"
                        defaultValue={this.state.email}
                        updateState={this.updateState}
                      />
                      <HelpBlock>{this.state.emailError}</HelpBlock>
                    </FormGroup>
                  </Col>
                  <Col md={4}>
                    <FormGroup
                      controlId="districtId"
                      validationState={
                        this.state.districtIdError ? "error" : null
                      }
                    >
                      <ControlLabel>
                        District <sup>*</sup>
                      </ControlLabel>
                      <FilterDropdown
                        id="districtId"
                        placeholder="None"
                        blankLine
                        items={districts}
                        selectedId={this.state.districtId}
                        updateState={this.updateState}
                      />
                      <HelpBlock>{this.state.districtIdError}</HelpBlock>
                    </FormGroup>
                  </Col>
                  <Col md={4}>
                    <FormGroup
                      controlId="selectedGroupsIds"
                      validationState={
                        this.state.selectedGroupsIdsError ? "error" : null
                      }
                    >
                      <ControlLabel>
                        Groups <sup>*</sup>
                      </ControlLabel>
                      <MultiDropdown
                        id="selectedGroupsIds"
                        placeholder="None"
                        items={groups}
                        selectedIds={this.state.selectedGroupsIds}
                        updateState={this.updateState}
                        showMaxItems={2}
                      />
                      <HelpBlock>{this.state.selectedGroupsIdsError}</HelpBlock>
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
    user: state.models.user,
    districts: state.lookups.districts,
    groups: state.lookups.groups,
  };
}

export default connect(mapStateToProps)(UsersEditDialog);
