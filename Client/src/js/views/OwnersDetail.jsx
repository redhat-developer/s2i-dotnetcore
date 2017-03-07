import React from 'react';

import { connect } from 'react-redux';

import { Well, Row, Col  } from 'react-bootstrap';
import { Alert, Label, Button, ButtonGroup, Glyphicon  } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';

import OwnersEditDialog from './dialogs/OwnersEditDialog.jsx';
import SchoolBusesAddDialog from './dialogs/SchoolBusesAddDialog.jsx';

import * as Action from '../actionTypes';
import * as Api from '../api';
import * as Constant from '../constants';
import store from '../store';

import BadgeLabel from '../components/BadgeLabel.jsx';
import ColDisplay from '../components/ColDisplay.jsx';
import DeleteButton from '../components/DeleteButton.jsx';
import EditButton from '../components/EditButton.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';
import Unimplemented from '../components/Unimplemented.jsx';

import { formatDateTime } from '../utils/date';
import { plural } from '../utils/string';


var OwnersDetail = React.createClass({
  propTypes: {
    owner: React.PropTypes.object,
    ui: React.PropTypes.object,
    params: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: true,
      loadingContacts: true,

      showEditDialog: false,
      showContactDialog: false,
      showSchoolBusDialog: false,

      contact: {},

      isNew: this.props.params.ownerId === '0',

      ui : {
        // Contacts
        sortField: this.props.ui.sortField || 'name',
        sortDesc: this.props.ui.sortDesc != false, // defaults to true
      },
    };
  },

  componentDidMount() {
    this.fetch();
  },

  fetch() {
    this.setState({ loading: true });
    Api.getOwner(this.props.params.ownerId).finally(() => {
      this.setState({ loading: false });
    });
  },

  updateUIState(state, callback) {
    this.setState({ ui: { ...this.state.ui, ...state }}, () =>{
      store.dispatch({ type: Action.UPDATE_CONTACTS_UI, contacts: this.state.ui });
      if (callback) { callback(); }
    });
  },

  openEditDialog() {
    this.setState({ showEditDialog: true });
  },

  closeEditDialog() {
    this.setState({ showEditDialog: false });
  },

  saveEdit(owner) {
    Api.updateOwner(owner).finally(() => {
      this.closeEditDialog();
    });
  },

  openSchoolBusDialog() {
    this.setState({ showSchoolBusDialog: true });
  },

  closeSchoolBusDialog() {
    this.setState({ showSchoolBusDialog: false });
  },

  openContactDialog(contact) {
    this.setState({
      contact: contact,
      showContactDialog: true,
    });
  },

  closeContactDialog() {
    this.setState({ showContactDialog: false });
  },

  deleteContact(contact) {
    console.debug(contact);
  },

  saveContact() {
  },

  render: function() {
    var owner = this.props.owner;

    var daysToInspection = owner.daysToInspection;
    if (owner.isOverdue) { daysToInspection *= -1; }

    var inspectionNotice = (owner.isReinspection ? '&reg; ' : '') + (owner.isOverdue ? 'Overdue &ndash; ' : '')
      + daysToInspection + ' ' + plural(daysToInspection, 'day', 'days')
      + ' &ndash; ' + formatDateTime(owner.nextInspectionDate, Constant.DATE_FULL_MONTH_DAY_YEAR);

    var inspectionStyle = owner.isOverdue ? 'danger' : (daysToInspection <= Constant.INSPECTION_DAYS_DUE_WARNING ? 'warning' : 'success');

    return <div id="owners-detail">
      <div>
        <Row id="owners-top">
          <Col md={10}>
            <Label bsStyle={ owner.isActive ? 'success' : 'danger'}>{ owner.isActive ? 'Verified Active' : owner.status }</Label>
            { owner.nextInspectionDate &&
              <span className={ `label label-${inspectionStyle}` } dangerouslySetInnerHTML={{ __html: inspectionNotice }}></span>
            }
          </Col>
          <Col md={2}>
            <div className="pull-right">
              <Unimplemented>
                <Button><Glyphicon glyph="print" title="Print" /></Button>
              </Unimplemented>
              <LinkContainer to={{ pathname: Constant.OWNERS_PATHNAME }}>
                <Button title="Return to List"><Glyphicon glyph="arrow-left" /> Return to List</Button>
              </LinkContainer>
            </div>
          </Col>
        </Row>

        {(() => {
          if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

          return <div id="owners-header">
            <Row>
              <Col md={12}>
                <h1>School Bus Owner: <small>{ owner.name }</small>
                  <Button title="Edit Owner" bsSize="small" onClick={ this.openEditDialog }><Glyphicon glyph="pencil" /></Button>
                </h1>
              </Col>
            </Row>
          </div>;
        })()}

        <Row>
          <Col md={6}>
            <Well>
              <h3>School Bus Data <span className="pull-right">
                <Button title="Add Bus" bsSize="small" onClick={ this.openSchoolBusDialog }><Glyphicon glyph="plus" /> Add School Bus</Button>
              </span></h3>
              {(() => {
                if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                return <div id="owners-data">
                  <Row>
                    <ColDisplay md={12} label="Number of School Buses"><a href={ `#/${ Constant.BUSES_PATHNAME }?${ Constant.SCHOOL_BUS_OWNER_QUERY }=${ owner.id }` }>{ owner.numberOfBuses }</a></ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Owner Added On">{ formatDateTime(owner.dateCreated, Constant.DATE_SHORT_MONTH_DAY_YEAR) }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Next Inspection">{ formatDateTime(owner.nextInspectionDate, Constant.DATE_SHORT_MONTH_DAY_YEAR) }
                      { owner.isReinspection ? <BadgeLabel bsStyle="info">R</BadgeLabel> : null }
                      { owner.isOverdue ? <BadgeLabel bsStyle="danger">!</BadgeLabel> : null }
                    </ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Main Contact">{ owner.primaryContactName }</ColDisplay>
                  </Row>
                </div>;
              })()}
            </Well>
            <Well>
              <h3>Contacts <span className="pull-right">
                <Unimplemented>
                  <Button title="Add Contact" onClick={ this.addContact } bsSize="small"><Glyphicon glyph="plus" /></Button>
                </Unimplemented>
              </span></h3>
              {(() => {
                if (this.state.loading ) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }
                if (!owner.contacts || owner.contacts.length === 0) { return <Alert bsStyle="success" style={{ marginTop: 10 }}>No contacts</Alert>; }

                var contacts = _.sortBy(owner.contacts, this.state.ui.sortField);
                if (this.state.ui.sortDesc) {
                  _.reverse(contacts);
                }

                var headers = [
                  { field: 'name',  title: 'Name'         },
                  { field: 'phone', title: 'Phone Number' },
                  { field: 'email', title: 'Email'        },
                  { field: 'role',  title: 'Role'         },
                  { field: 'blank' },
                ];

                return <SortTable id="contacts-list" sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={ headers }>
                  {
                    _.map(contacts, (contact) => {
                      return <tr key={ contact.id }>
                        <td>{ contact.name }</td>
                        <td>{ contact.phone }</td>
                        <td>{ contact.email }</td>
                        <td>{ contact.role }</td>
                        <td style={{ textAlign: 'right' }}>
                          <ButtonGroup>
                            <DeleteButton name="Contact" hide={ !contact.canDelete } onConfirm={ this.deleteContact.bind(this, contact) }/>
                            <EditButton name="Contact" view={ !contact.canEdit } onClick={ this.openContactDialog.bind(this, contact) }/>
                          </ButtonGroup>
                        </td>
                      </tr>;
                    })
                  }
                </SortTable>;
              })()}
            </Well>
          </Col>
          <Col md={6}>
            <Well>
              <h3>Comment Log</h3>
              {(() => {
                if (this.state.loading ) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }
                if (!owner.notes || owner.notes.length === 0) { return <Alert bsStyle="success" style={{ marginTop: 10 }}>No comments</Alert>; }
              })()}
            </Well>
          </Col>
        </Row>
      </div>
      { this.state.showEditDialog &&
        <OwnersEditDialog show={ this.state.showEditDialog } onSave={ this.saveEdit } onClose= { this.closeEditDialog } />
      }
      { this.state.showSchoolBusDialog &&
        <SchoolBusesAddDialog show={ this.state.showSchoolBusDialog } onSave={ this.closeSchoolBusDialog } onClose= { this.closeSchoolBusDialog } />
      }
    </div>;
  },
});


function mapStateToProps(state) {
  return {
    owner: state.models.owner,
    ui: state.ui.contacts,
  };
}

export default connect(mapStateToProps)(OwnersDetail);
