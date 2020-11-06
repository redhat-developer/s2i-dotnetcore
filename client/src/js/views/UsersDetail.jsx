import React from 'react';
import PropTypes from 'prop-types';

import { connect } from 'react-redux';

import { Well, Row, Col } from 'react-bootstrap';
import { Alert, Label, Button, Glyphicon, Popover } from 'react-bootstrap';
import { Form, FormGroup, HelpBlock } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';

import UserRoleAddDialog from './dialogs/UserRoleAddDialog.jsx';
import UsersEditDialog from './dialogs/UsersEditDialog.jsx';

import * as Action from '../actionTypes';
import * as Api from '../api';
import * as Constant from '../constants';
import store from '../store';

import CheckboxControl from '../components/CheckboxControl.jsx';
import ColDisplay from '../components/ColDisplay.jsx';
import DateControl from '../components/DateControl.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';
import Authorize from '../components/Authorize';

import { formatDateTime, today, isValidDate, toZuluTime, dateIsBeforeToday } from '../utils/date';
import { isBlank, notBlank } from '../utils/string';

class UsersDetail extends React.Component {
  static propTypes = {
    user: PropTypes.object,
    ui: PropTypes.object,
    params: PropTypes.object,
    router: PropTypes.object,
  };

  state = {
    loading: true,

    showEditDialog: false,
    showUserRoleDialog: false,

    isNew: this.props.params.userId === '0',

    ui: {
      // User roles
      sortField: this.props.ui.sortField || 'roleName',
      sortDesc: this.props.ui.sortDesc !== false, // defaults to true
      showExpiredOnly: false,
    },
  };

  componentDidMount() {
    if (this.state.isNew) {
      // Clear the spinner
      this.setState({ loading: false });
      // Clear the user store
      store.dispatch({
        type: Action.UPDATE_USER,
        user: {
          id: 0,
          active: true,
          district: { id: 0, name: '' },
        },
      });
      // Open editor to add new user
      this.openEditDialog();
    } else {
      this.fetch();
    }
  }

  fetch = () => {
    this.setState({ loading: true });
    Api.getUser(this.props.params.userId).finally(() => {
      this.setState({ loading: false });
    });
  };

  updateUIState = (state, callback) => {
    this.setState({ ui: { ...this.state.ui, ...state } }, () => {
      store.dispatch({
        type: Action.UPDATE_USER_ROLES_UI,
        userRoles: this.state.ui,
      });
      if (callback) {
        callback();
      }
    });
  };

  openEditDialog = () => {
    this.setState({ showEditDialog: true });
  };

  closeEditDialog = () => {
    this.setState({ showEditDialog: false });
  };

  onSaveEdit = (user) => {
    var savePromise = this.state.isNew ? Api.addUser : Api.updateUser;
    savePromise(user).then(() => {
      if (this.state.isNew) {
        // Make sure we get the new user's ID
        user.id = this.props.user.id;
      }

      this.props.router.push({
        pathname: `${Constant.USERS_PATHNAME}/${this.props.user.id}`,
      });
    });
    this.closeEditDialog();
  };

  onCloseEdit = () => {
    this.closeEditDialog();
    if (this.state.isNew) {
      // Go back to user list if cancelling new user
      this.props.router.push({
        pathname: Constant.USERS_PATHNAME,
      });
    }
  };

  openUserRoleDialog = () => {
    this.setState({ showUserRoleDialog: true });
  };

  closeUserRoleDialog = () => {
    this.setState({ showUserRoleDialog: false });
  };

  addUserRole = (userRole) => {
    Api.addUserRole(this.props.user.id, userRole);
    this.closeUserRoleDialog();
  };

  updateUserRole = (userRole) => {
    Api.updateUserRole(this.props.user.id, userRole);
    this.closeUserRoleDialog();
  };

  render() {
    var user = this.props.user;

    return (
      <div id="users-detail">
        <div>
          <Row id="users-top">
            <Col md={10}>
              <Label bsStyle={user.active ? 'success' : 'danger'}>{user.active ? 'Verified Active' : 'Inactive'}</Label>
            </Col>
            <Col md={2}>
              <div className="pull-right">
                <LinkContainer to={{ pathname: Constant.USERS_PATHNAME }}>
                  <Button title="Return to List">
                    <Glyphicon glyph="arrow-left" /> Return to List
                  </Button>
                </LinkContainer>
              </div>
            </Col>
          </Row>

          {(() => {
            if (this.state.loading) {
              return (
                <div style={{ textAlign: 'center' }}>
                  <Spinner />
                </div>
              );
            }

            return (
              <div id="users-header">
                <Row>
                  <Col md={12}>
                    <h1>
                      User: <small>{user.fullName}</small>
                    </h1>
                  </Col>
                </Row>
              </div>
            );
          })()}
          <Row>
            <Col md={12}>
              <Well>
                <h3>
                  General{' '}
                  <span className="pull-right">
                    <Authorize permissions={Constant.PERMISSION_USER_W}>
                      <Button title="Edit User" bsSize="small" onClick={this.openEditDialog}>
                        <Glyphicon glyph="pencil" />
                      </Button>
                    </Authorize>
                  </span>
                </h3>
                {(() => {
                  if (this.state.loading) {
                    return (
                      <div style={{ textAlign: 'center' }}>
                        <Spinner />
                      </div>
                    );
                  }

                  return (
                    <div id="user-data">
                      <Row>
                        <ColDisplay md={3} label="Given Name">
                          {user.givenName}
                        </ColDisplay>
                        <ColDisplay md={3} label="User ID">
                          {user.smUserId}
                        </ColDisplay>
                        <ColDisplay md={6} label="E-mail">
                          {user.email}
                        </ColDisplay>
                      </Row>
                      <Row>
                        <ColDisplay md={3} label="Surname">
                          {user.surname}
                        </ColDisplay>
                        <ColDisplay md={3} label="District">
                          {user.districtName}
                        </ColDisplay>
                      </Row>
                    </div>
                  );
                })()}
              </Well>
            </Col>
          </Row>
          <Row>
            <Col md={12}>
              <Well id="users-access">
                <h3>
                  Access
                  <CheckboxControl
                    inline
                    id="showExpiredOnly"
                    checked={this.state.ui.showExpiredOnly}
                    updateState={this.updateUIState}
                  >
                    Show Expired Only
                  </CheckboxControl>
                </h3>
                {(() => {
                  if (this.state.loading) {
                    return (
                      <div style={{ textAlign: 'center' }}>
                        <Spinner />
                      </div>
                    );
                  }

                  var addUserRoleButton = (
                    <Authorize permissions={Constant.PERMISSION_USER_W}>
                      <Button title="Add User Role" onClick={this.openUserRoleDialog} bsSize="xsmall">
                        <Glyphicon glyph="plus" />
                        &nbsp;<strong>Add Role</strong>
                      </Button>
                    </Authorize>
                  );

                  var userRoles = _.filter(user.userRoles, (userRole) => {
                    var include = notBlank(userRole.roleName);
                    if (this.state.ui.showExpiredOnly) {
                      include = include && dateIsBeforeToday(userRole.expiryDate);
                    }
                    return include;
                  });
                  if (userRoles.length === 0) {
                    return <Alert bsStyle="success">No roles {addUserRoleButton}</Alert>;
                  }

                  userRoles = _.sortBy(userRoles, this.state.ui.sortField);
                  if (this.state.ui.sortDesc) {
                    _.reverse(userRoles);
                  }

                  var headers = [
                    { field: 'roleName', title: 'Role' },
                    { field: 'effectiveDateSort', title: 'Effective Date' },
                    { field: 'expiryDateSort', title: 'Expiry Date' },
                    {
                      field: 'addUserRole',
                      title: 'Add User Role',
                      style: { textAlign: 'right' },
                      node: addUserRoleButton,
                    },
                  ];

                  return (
                    <SortTable
                      id="user-roles-list"
                      sortField={this.state.ui.sortField}
                      sortDesc={this.state.ui.sortDesc}
                      onSort={this.updateUIState}
                      headers={headers}
                    >
                      {_.map(userRoles, (userRole) => {
                        return (
                          <tr key={userRole.id}>
                            <td>{userRole.roleName}</td>
                            <td>{formatDateTime(userRole.effectiveDate, Constant.DATE_FULL_MONTH_DAY_YEAR)}</td>
                            <td>
                              {formatDateTime(userRole.expiryDate, Constant.DATE_FULL_MONTH_DAY_YEAR)}
                              &nbsp;
                              {dateIsBeforeToday(userRole.expiryDate) ? <Glyphicon glyph="asterisk" /> : ''}
                            </td>
                            <td style={{ textAlign: 'right' }}>
                              <Authorize permissions={Constant.PERMISSION_USER_W}>
                                <OverlayTrigger
                                  trigger="click"
                                  placement="left"
                                  rootClose
                                  overlay={<ExpireOverlay userRole={userRole} onSave={this.updateUserRole} />}
                                >
                                  <Button title="Expire User Role" bsSize="xsmall">
                                    <Glyphicon glyph="pencil" /> Edit
                                  </Button>
                                </OverlayTrigger>
                              </Authorize>
                            </td>
                          </tr>
                        );
                      })}
                    </SortTable>
                  );
                })()}
              </Well>
            </Col>
          </Row>
        </div>

        {this.state.showEditDialog && (
          <Authorize permissions={Constant.PERMISSION_USER_W}>
            <UsersEditDialog show={this.state.showEditDialog} onSave={this.onSaveEdit} onClose={this.onCloseEdit} />
          </Authorize>
        )}

        {this.state.showUserRoleDialog && (
          <UserRoleAddDialog
            show={this.state.showUserRoleDialog}
            onSave={this.addUserRole}
            onClose={this.closeUserRoleDialog}
          />
        )}
      </div>
    );
  }
}

class ExpireOverlay extends React.Component {
  static propTypes = {
    userRole: PropTypes.object.isRequired,
    onSave: PropTypes.func.isRequired,
    hide: PropTypes.func,
  };

  state = {
    expiryDate: today(),
    expiryDateError: '',
  };

  componentDidMount() {
    const userRole = this.props.userRole;

    if (userRole.expiryDate !== null) {
      this.setState({ expiryDate: formatDateTime(userRole.expiryDate) });
    }
  }

  updateState = (state, callback) => {
    this.setState(state, callback);
  };

  saveUserRole = () => {
    this.setState({ expiryDateError: false });

    if (this.props.userRole.expiryDate === null && isBlank(this.state.expiryDate)) {
      this.setState({ expiryDateError: 'Expiry date is required' });
    } else if (this.props.userRole.expiryDate === null && !isValidDate(this.state.expiryDate)) {
      this.setState({ expiryDateError: 'Expiry date not valid' });
    } else {
      this.props.onSave({
        ...this.props.userRole,
        ...{
          expiryDate: toZuluTime(this.state.expiryDate),
          roleId: this.props.userRole.role.id,
        },
      });
      this.props.hide();
    }
  };

  render() {
    var props = _.omit(this.props, 'onSave', 'hide', 'userRole');
    return (
      <Popover id="users-role-popover" title="Set Expiry Date" {...props}>
        <Form inline>
          <FormGroup controlId="expiryDate" validationState={this.state.expiryDateError ? 'error' : null}>
            <DateControl
              id="expiryDate"
              date={this.state.expiryDate}
              updateState={this.updateState}
              placeholder="mm/dd/yyyy"
              title="Expiry Date"
              showClear={true}
            />
            <HelpBlock>{this.state.expiryDateError}</HelpBlock>
          </FormGroup>
          <Button bsStyle="primary" onClick={this.saveUserRole} className="pull-right">
            Save
          </Button>
        </Form>
      </Popover>
    );
  }
}

function mapStateToProps(state) {
  return {
    user: state.models.user,
    ui: state.ui.userRoles,
  };
}

export default connect(mapStateToProps)(UsersDetail);
