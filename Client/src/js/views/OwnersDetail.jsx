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
import ColField from '../components/ColField.jsx';
import ColLabel from '../components/ColLabel.jsx';
import Confirm from '../components/Confirm.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';

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

  saveContact() {
  },

  render: function() {
    var owner = this.props.owner;

    var daysToInspection = owner.daysToInspection;
    if (owner.isOverdue) { daysToInspection *= -1; }

    var inspectionNotice = (owner.isReinspection ? '&reg; ' : '') + (owner.isOverdue ? 'Overdue &ndash; ' : '')
      + daysToInspection + ' ' + plural(daysToInspection, 'day', 'days')
      + ' &ndash; ' + formatDateTime(owner.nextInspectionDate, 'YYYY-DD-MMM');

    var inspectionStyle = owner.isOverdue ? 'danger' : (daysToInspection <= Constant.INSPECTION_DAYS_DUE_WARNING ? 'warning' : 'success');

    return <div id="owners-detail">
      <div>
        <Row id="owners-top">
          <Col md={10}>
            <Label bsStyle={ owner.isActive ? 'success' : 'danger'}>{ owner.isActive ? 'Verified Active' : owner.status }</Label>
            <span className={ `label label-${inspectionStyle}` } dangerouslySetInnerHTML={{ __html: inspectionNotice }}></span>
          </Col>
          <Col md={2}>
            <div className="pull-right">
              <Button><Glyphicon glyph="print" title="Print" /></Button>
              <LinkContainer to={{ pathname: 'owners' }}>
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
                  <Button title="edit" bsSize="small" onClick={ this.openEditDialog }><Glyphicon glyph="edit" /></Button>
                </h1>
              </Col>
            </Row>
          </div>;
        })()}

        <Row>
          <Col md={6}>
            <Well>
              <h3>School Bus Data <span className="pull-right">
                <Button title="add" bsSize="small" onClick={ this.openSchoolBusDialog }><Glyphicon glyph="plus" /> Add School Bus</Button>
              </span></h3>
              {(() => {
                if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                return <div id="owners-data">
                  <Row>
                    <ColLabel md={4}>Number of School Buses</ColLabel>
                    <ColField md={8}>{ owner.numberOfBuses }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Owner Added On</ColLabel>
                    <ColField md={8}>{ formatDateTime(owner.dateCreated, 'YYYY-MM-DD') }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Next Inspection</ColLabel>
                    <ColField md={8}>{ formatDateTime(owner.nextInspectionDate, 'YYYY-MM-DD') }
                      { owner.isReinspection ? <BadgeLabel bsStyle="info">R</BadgeLabel> : null }
                      { owner.isOverdue ? <BadgeLabel bsStyle="danger">!</BadgeLabel> : null }
                    </ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Main Contact</ColLabel>
                    <ColField md={8}>{ owner.primaryContactName }</ColField>
                  </Row>
                </div>;
              })()}
            </Well>
            <Well>
              <h3>Contacts <span className="pull-right"><Button title="addInspection" onClick={ this.addContact } bsSize="small"><Glyphicon glyph="plus" /></Button></span></h3>
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

                return <SortTable id="inspection-list" sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={ headers }>
                  {
                    _.map(contacts, (contact) => {
                      return <tr key={ contact.id }>
                        <td>{ contact.name }</td>
                        <td>{ contact.phone }</td>
                        <td>{ contact.email }</td>
                        <td>{ contact.role }</td>
                        <td style={{ textAlign: 'right' }}>
                          <ButtonGroup>
                            <Button className={ contact.canEdit ? '' : 'hidden' } title="editInspection" bsSize="xsmall" onClick={ this.openInspectionDialog.bind(this, contact) }><Glyphicon glyph="pencil" /></Button>
                            <OverlayTrigger trigger="click" placement="top" rootClose overlay={ <Confirm onConfirm={ this.deleteInspection.bind(this, contact) }/> }>
                              <Button className={ contact.canDelete ? '' : 'hidden' } title="deleteInspection" bsSize="xsmall"><Glyphicon glyph="trash" /></Button>
                            </OverlayTrigger>
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
