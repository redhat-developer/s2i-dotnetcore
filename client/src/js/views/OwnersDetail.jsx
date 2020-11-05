import React from 'react';
import PropTypes from 'prop-types';

import { connect } from 'react-redux';

import { Well, Row, Col } from 'react-bootstrap';
import { Alert, Label, Button, ButtonGroup, Glyphicon, Badge } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';

import HistoryListDialog from './dialogs/HistoryListDialog.jsx';
import OwnersEditDialog from './dialogs/OwnersEditDialog.jsx';
import SchoolBusesAddDialog from './dialogs/SchoolBusesAddDialog.jsx';
import ContactEditDialog from './dialogs/ContactEditDialog.jsx';
import Notes from './Notes.jsx';

import * as Action from '../actionTypes';
import * as Api from '../api';
import * as Constant from '../constants';
import * as History from '../history';
import store from '../store';

import BadgeLabel from '../components/BadgeLabel.jsx';
import ColDisplay from '../components/ColDisplay.jsx';
import DeleteButton from '../components/DeleteButton.jsx';
import EditButton from '../components/EditButton.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';
import Authorize from '../components/Authorize';

import { formatDateTime } from '../utils/date';
import { plural } from '../utils/string';

class OwnersDetail extends React.Component {
  static propTypes = {
    owner: PropTypes.object,
    ui: PropTypes.object,
    params: PropTypes.object,
    router: PropTypes.object,
    ownerContacts: PropTypes.object,
    contact: PropTypes.object,
  };

  state = {
    loading: true,
    loadingContacts: true,
    loadingNotes: true,

    showContactDialog: false,
    showEditDialog: false,
    showHistoryDialog: false,
    showSchoolBusDialog: false,

    contact: {},
    owner: this.props.owner,
    notes: {},

    isNew: this.props.params.ownerId === '0',

    ui: {
      // Contacts
      sortField: this.props.ui.sortField || 'name',
      sortDesc: this.props.ui.sortDesc !== false, // defaults to true
    },
  };

  componentDidMount() {
    this.setState({
      loading: false,
      loadingContacts: false,
      loadingNotes: false,
    });
    this.fetch().then(() => {
      this.openContact(this.props);
    });
  }

  UNSAFE_componentWillReceiveProps(nextProps) {
    if (!_.isEqual(nextProps.params, this.props.params)) {
      if (nextProps.params.contactId && !this.props.params.contactId) {
        this.openContact(nextProps);
      }
    }
  }

  getNotes = (id) => {
    this.setState({ loadingNotes: true });
    return Api.getOwnerNotes(id)
      .then((notes) => {
        this.setState({ notes });
      })
      .finally(() => {
        this.setState({ loadingNotes: false });
      });
  };

  openContact = (props) => {
    var contact = null;

    if (props.params.contactId === '0') {
      //New
      contact = {
        id: 0,
        schoolBusOwner: props.owner,
      };
    } else if (props.params.contactId) {
      contact = props.ownerContacts[props.params.contactId];
    }

    if (contact) {
      this.openContactDialog(contact);
    }
  };

  fetch = () => {
    this.setState({
      loading: true,
      loadingContacts: true,
    });

    var id = this.props.params.ownerId;

    Api.getOwner(id).finally(() => {
      this.setState({ loading: false });
    });

    Api.getOwnerContacts(id).finally(() => {
      this.setState({ loadingContacts: false });
    });

    return this.getNotes(id);
  };

  updateUIState = (state, callback) => {
    this.setState({ ui: { ...this.state.ui, ...state } }, () => {
      store.dispatch({
        type: Action.UPDATE_CONTACTS_UI,
        contacts: this.state.ui,
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

  saveEdit = (owner) => {
    // Check for owner status change
    var statusChanged = this.props.owner.status !== owner.status ? true : false;
    var nameChanged = this.props.owner.name !== owner.name ? true : false;

    Api.updateOwner(owner).finally(() => {
      // Logging
      // Owner state change
      if (statusChanged) {
        History.logModifiedOwnerStatus(this.props.owner);
      }

      // Owner name change
      if (nameChanged) {
        History.logModifiedOwnerName(this.props.owner);
      }

      this.closeEditDialog();
    });
  };

  openSchoolBusDialog = () => {
    this.setState({ showSchoolBusDialog: true });
  };

  closeSchoolBusDialog = () => {
    this.setState({ showSchoolBusDialog: false });
  };

  openContactDialog = (contact) => {
    this.setState({
      contact: contact,
      showContactDialog: true,
    });
  };

  closeContactDialog = () => {
    this.setState({ showContactDialog: false }, () => {
      this.props.router.push({
        pathname: this.props.owner.path,
      });
    });
  };

  addContact = () => {
    this.props.router.push({
      pathname: `${this.props.owner.path}/${Constant.CONTACT_PATHNAME}/0`,
    });
  };

  deleteContact = (contact) => {
    Api.deleteContact(contact).then(() => {
      this.fetch();

      History.logDeletedContact(this.props.owner, this.props.contact);
    });
  };

  saveContact = (contact, owner) => {
    var isNew = contact && contact.id === 0;
    var oldPrimary = this.props.owner.primaryContact ? this.props.owner.primaryContact : null;
    var newPrimary = owner.primaryContact ? owner.primaryContact : null;
    var updatePrimary = false;
    var deselectPrimary = false;
    //create new contact also set it as primary
    var isNewPrimaryContact = newPrimary != null && newPrimary.id === 0 && isNew;

    if (
      (oldPrimary == null && newPrimary != null && !isNew) ||
      (!isNew && oldPrimary != null && newPrimary != null && oldPrimary.id !== newPrimary.id)
    ) {
      updatePrimary = true;
    }
    if (oldPrimary != null && newPrimary == null) {
      deselectPrimary = true; //deselected primary contact
    }

    //update select/deselect primary contact
    if (updatePrimary || deselectPrimary) {
      Api.updateOwner({
        ...this.props.owner,
        ...{
          primaryContact: newPrimary,
        },
      });
    }

    var contactPromise = isNew ? Api.addContact : Api.updateContact;

    contactPromise(contact)
      .then((response) => {
        if (isNew) {
          History.logNewContact(this.props.owner, this.props.contact);
        } else {
          History.logModifiedContact(this.props.owner, this.props.contact);
        }
        if (deselectPrimary) {
          History.logDeselectedPrimaryContact(this.props.owner, this.props.contact);
        }
        if (updatePrimary) {
          History.logModifiedPrimaryContact(this.props.owner, this.props.contact);
        }
        if (isNewPrimaryContact && response != null) {
          //adding new contact also set it as primary
          Api.updateOwner({
            ...this.props.owner,
            ...{
              primaryContact: response,
            },
          }).then(() => {
            History.logNewPrimaryContact(this.props.owner, this.props.contact);
          });
        }
      })
      .finally(() => {
        //reflash contact table
        this.fetch();
        this.closeContactDialog();
      });
  };

  showHistoryDialog = () => {
    this.setState({ showHistoryDialog: true });
  };

  closeHistoryDialog = () => {
    this.setState({ showHistoryDialog: false });
  };

  render() {
    var owner = this.props.owner;
    var primaryContactId = owner.primaryContact ? owner.primaryContact.id : null;
    const notes = Object.values(this.state.notes);

    var daysToInspection = owner.daysToInspection;
    if (owner.isOverdue) {
      daysToInspection *= -1;
    }

    var inspectionNotice =
      (owner.isReinspection ? '&reg; ' : '') +
      (owner.isOverdue ? 'Overdue &ndash; ' : '') +
      daysToInspection +
      ' ' +
      plural(daysToInspection, 'day', 'days') +
      ' &ndash; ' +
      formatDateTime(owner.nextInspectionDate, Constant.DATE_FULL_MONTH_DAY_YEAR);

    var inspectionStyle = owner.isOverdue
      ? 'danger'
      : daysToInspection <= Constant.INSPECTION_DAYS_DUE_WARNING
      ? 'warning'
      : 'success';

    return (
      <div id="owners-detail">
        <div>
          <Row id="owners-top">
            <Col md={10}>
              <Label bsStyle={owner.isActive ? 'success' : 'danger'}>
                {owner.isActive ? 'Verified Active' : owner.status}
              </Label>
              {owner.nextInspectionDate && (
                <span
                  className={`label label-${inspectionStyle}`}
                  dangerouslySetInnerHTML={{ __html: inspectionNotice }}
                ></span>
              )}
              <Button title="History" onClick={this.showHistoryDialog}>
                History
              </Button>
            </Col>
            <Col md={2}>
              <div className="pull-right">
                <LinkContainer to={{ pathname: Constant.OWNERS_PATHNAME }}>
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
              <div id="owners-header">
                <Row>
                  <Col md={12}>
                    <h1>
                      School Bus Owner: <small>{owner.name}</small>
                      <Authorize permissions={Constant.PERMISSION_OWNER_W}>
                        <Button title="Edit Owner" bsSize="small" onClick={this.openEditDialog}>
                          <Glyphicon glyph="pencil" />
                        </Button>
                      </Authorize>
                    </h1>
                  </Col>
                </Row>
              </div>
            );
          })()}

          <Row>
            <Col>
              <Well>
                <h3>
                  School Bus Data{' '}
                  <span className="pull-right">
                    <Authorize permissions={Constant.PERMISSION_SB_W}>
                      <Button title="Add Bus" bsSize="small" onClick={this.openSchoolBusDialog}>
                        <Glyphicon glyph="plus" /> Add School Bus
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
                    <div id="owners-data">
                      <Row>
                        <ColDisplay md={12} label="Number of School Buses">
                          <a href={owner.busesURL}>{owner.numberOfBuses}</a>
                        </ColDisplay>
                      </Row>
                      <Row>
                        <ColDisplay md={12} label="Owner Added On">
                          {formatDateTime(owner.dateCreated, Constant.DATE_SHORT_MONTH_DAY_YEAR)}
                        </ColDisplay>
                      </Row>
                      <Row>
                        <ColDisplay md={12} label="Next Inspection">
                          {formatDateTime(owner.nextInspectionDate, Constant.DATE_SHORT_MONTH_DAY_YEAR)}
                          {owner.isReinspection ? <BadgeLabel bsStyle="info">R</BadgeLabel> : null}
                          {owner.isOverdue ? <BadgeLabel bsStyle="danger">!</BadgeLabel> : null}
                        </ColDisplay>
                      </Row>
                      <Row>
                        <ColDisplay md={12} label="Main Contact">
                          {owner.primaryContactName}
                        </ColDisplay>
                      </Row>
                    </div>
                  );
                })()}
              </Well>
            </Col>
          </Row>
          <Row>
            <Col>
              <Well>
                <h3>Contacts</h3>
                {(() => {
                  if (this.state.loadingContacts) {
                    return (
                      <div style={{ textAlign: 'center' }}>
                        <Spinner />
                      </div>
                    );
                  }

                  var addContactButton = (
                    <Authorize permissions={Constant.PERMISSION_OWNER_W}>
                      <Button title="Add Contact" onClick={this.addContact} bsSize="xsmall">
                        <Glyphicon glyph="plus" />
                        &nbsp;<strong>Add</strong>
                      </Button>
                    </Authorize>
                  );
                  var primary = <Badge style={{ backgroundColor: '#5cb85c', marginLeft: '10px' }}>Primary</Badge>;

                  if (this.props.ownerContacts === null || Object.keys(this.props.ownerContacts).length === 0) {
                    return <Alert bsStyle="success">No contacts {addContactButton}</Alert>;
                  }

                  var contacts = _.sortBy(this.props.ownerContacts, this.state.ui.sortField);
                  if (this.state.ui.sortDesc) {
                    _.reverse(contacts);
                  }

                  var index = _.findIndex(contacts, { id: primaryContactId });
                  if (index !== -1 && contacts.length > 1) {
                    var temp = contacts[index];
                    contacts.splice(index, 1);
                    contacts.unshift(temp);
                  }

                  var headers = [
                    { field: 'primary', title: ' ' },
                    { field: 'name', title: 'Name' },
                    { field: 'workPhoneNumber', title: 'Phone' },
                    { field: 'address1', title: 'Address' },
                    {
                      field: 'addContact',
                      title: 'Add Contact',
                      style: { testAlign: 'right' },
                      node: addContactButton,
                    },
                  ];

                  return (
                    <SortTable
                      id="contact-list"
                      sortField={this.state.ui.sortField}
                      sortDesc={this.state.ui.sortDesc}
                      onSort={this.updateUIState}
                      headers={headers}
                    >
                      {_.map(contacts, (contact) => {
                        return (
                          <tr key={contact.id}>
                            {(() => {
                              if (contact.id === primaryContactId) {
                                return <td>{primary}</td>;
                              } else {
                                return <td></td>;
                              }
                            })()}
                            <td>{(contact.givenName ? contact.givenName : '') + ' ' + contact.surname}</td>
                            <td>{contact.workPhoneNumber}</td>
                            <td>{contact.address1}</td>
                            <td>
                              <ButtonGroup>
                                <Authorize permissions={Constant.PERMISSION_OWNER_W}>
                                  <DeleteButton
                                    name="Contact"
                                    hide={!contact.canDelete}
                                    onConfirm={this.deleteContact.bind(this, contact)}
                                  />
                                </Authorize>
                                <EditButton name="Contact" view={!contact.canEdit} pathname={contact.path} />
                              </ButtonGroup>
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
          <Row>
            <Col>
              {owner.id && (
                <Notes
                  show={true}
                  id={owner.id}
                  parentIdColumn="schoolBusOwnerId"
                  notes={notes}
                  getNotes={this.getNotes}
                  addNote={Api.addOwnerNotes}
                  updateNote={Api.updateOwnerNotes}
                  deleteNote={Api.deleteOwnerNotes}
                  onClose={() => {}}
                  permissions={Constant.PERMISSION_OWNER_W}
                  isDialog={false}
                  isLoading={this.state.loadingNotes}
                />
              )}
            </Col>
          </Row>
        </div>
        {this.state.showEditDialog && (
          <OwnersEditDialog show={this.state.showEditDialog} onSave={this.saveEdit} onClose={this.closeEditDialog} />
        )}
        {this.state.showHistoryDialog && (
          <HistoryListDialog
            show={this.state.showHistoryDialog}
            historyEntity={owner.historyEntity}
            onClose={this.closeHistoryDialog}
          />
        )}
        {this.state.showSchoolBusDialog && (
          <SchoolBusesAddDialog
            show={this.state.showSchoolBusDialog}
            onSave={this.closeSchoolBusDialog}
            onClose={this.closeSchoolBusDialog}
          />
        )}
        {this.state.showContactDialog && (
          <ContactEditDialog
            show={this.state.showContactDialog}
            onSave={this.saveContact}
            onClose={this.closeContactDialog}
            owner={this.state.owner}
            contact={this.state.contact}
          />
        )}
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    owner: state.models.owner,
    ui: state.ui.contacts,
    ownerContacts: state.models.ownerContacts,
    contact: state.models.contact,
  };
}

export default connect(mapStateToProps)(OwnersDetail);
