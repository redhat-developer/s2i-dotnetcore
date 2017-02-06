import React from 'react';

import { connect } from 'react-redux';

import { Well, Row, Col  } from 'react-bootstrap';
import { Alert, Label, Button, ButtonGroup, Glyphicon  } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';

import InspectionEditDialog from './dialogs/InspectionEditDialog.jsx';
import SchoolBusesEditDialog from './dialogs/SchoolBusesEditDialog.jsx';

import * as Action from '../actionTypes';
import * as Api from '../api';
import * as Constant from '../constants';
import store from '../store';

import BadgeLabel from '../components/BadgeLabel.jsx';
import CheckboxControl from '../components/CheckboxControl.jsx';
import ColField from '../components/ColField.jsx';
import ColLabel from '../components/ColLabel.jsx';
import Confirm from '../components/Confirm.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';

import { formatDateTime } from '../utils/date';
import { concat, plural } from '../utils/string';


var SchoolBusesDetail = React.createClass({
  propTypes: {
    schoolBus: React.PropTypes.object,
    schoolBusCCW: React.PropTypes.object,
    schoolBusInspections: React.PropTypes.object,
    ui: React.PropTypes.object,
    params: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loadingSchoolBus: true,
      loadingSchoolBusCCW: true,
      loadingSchoolBusInspections: true,

      showEditDialog: false,
      showInspectionDialog: false,

      inspection: {},

      ui : {
        // Inspections
        sortField: this.props.ui.sortField || 'inspectionDateSort',
        sortDesc: this.props.ui.sortDesc != false, // defaults to true
      },
    };
  },

  componentDidMount() {
    this.fetch();
  },

  fetch() {
    this.setState({
      loadingSchoolBus: true,
      loadingSchoolBusCCW: true,
      loadingSchoolBusInspections: true,
    });

    var id = this.props.params.schoolBusId;

    Api.getSchoolBus(id).finally(() => {
      this.setState({ loadingSchoolBus: false });
    });
    Api.getSchoolBusCCW(id).finally(() => {
      this.setState({ loadingSchoolBusCCW: false });
    });
    Api.getSchoolBusInspections(id).finally(() => {
      this.setState({ loadingSchoolBusInspections: false });
    });
  },

  showNotes() {
  },

  showAttachments() {
  },

  showHistory() {
  },

  print() {

  },

  updateUIState(state, callback) {
    this.setState({ ui: { ...this.state.ui, ...state }}, () =>{
      store.dispatch({ type: Action.UPDATE_INSPECTIONS_UI, inspections: this.state.ui });
      if (callback) { callback(); }
    });
  },

  openEditDialog() {
    this.setState({ showEditDialog: true });
  },

  closeEditDialog() {
    this.setState({ showEditDialog: false });
  },

  saveEdit(schoolBus) {
    Api.updateSchoolBus(schoolBus).finally(() => {
      this.closeEditDialog();
    });
  },

  openInspectionDialog(inspection) {
    this.setState({
      inspection: inspection,
      showInspectionDialog: true,
    });
  },

  closeInspectionDialog() {
    this.setState({ showInspectionDialog: false });
  },

  getInspections() {
    this.setState({ loadingSchoolBusInspections: true });
    Api.getSchoolBusInspections(this.props.params.schoolBusId).finally(() => {
      this.setState({ loadingSchoolBusInspections: false });
    });
  },

  addInspection() {
    this.openInspectionDialog({
      id: 0,
      schoolBus: this.props.schoolBus,
      inspector: { id: 0 }, // current user if inspector
    });
  },

  deleteInspection(inspection) {
    Api.deleteInspection(inspection).then(() => {
      this.getInspections();
    });
  },

  saveInspection(inspection) {
    // Update or add accordingly
    var inspectionPromise = inspection.id ? Api.updateInspection : Api.addInspection;

    inspectionPromise(inspection).then(() => {
      // Refresh the inspections table
      this.getInspections();
      // Save next inspection data to this school bus record
      Api.updateSchoolBus({ ...this.props.schoolBus, ...{
        nextInspectionDate: inspection.nextInspectionDate,
        nextInspectionTypeCode: inspection.nextInspectionTypeCode,
      }});
    }).finally(() => {
      this.closeInspectionDialog();
    });
  },

  render() {
    var bus = this.props.schoolBus;
    var ccw = this.props.schoolBusCCW;

    var daysToInspection = bus.daysToInspection;
    if (bus.isOverdue) { daysToInspection *= -1; }

    var inspectionNotice = (bus.isReinspection ? '&reg; ' : '') + (bus.isOverdue ? 'Overdue &ndash; ' : '')
      + daysToInspection + ' ' + plural(daysToInspection, 'day', 'days')
      + ' &ndash; ' + formatDateTime(bus.nextInspectionDate, 'YYYY-DD-MMM');

    var inspectionStyle = bus.isOverdue ? 'danger' : (daysToInspection <= Constant.INSPECTION_DAYS_DUE_WARNING ? 'warning' : 'success');

    return <div id="school-buses-detail">
      <div>
        <Row id="school-buses-top">
          <Col md={10}>
            <Label bsStyle={ bus.isActive ? 'success' : 'danger'}>{ bus.isActive ? 'Verified Active' : bus.status }</Label>
            <Label className={ bus.isOutOfProvince ? '' : 'hide' }>Out of Province</Label>
            <span className={ `label label-${inspectionStyle}` } dangerouslySetInnerHTML={{ __html: inspectionNotice }}></span>
            <Button title="Notes" onClick={ this.showNotes }>Notes ({ bus.notes ? bus.notes.length : 0 })</Button>
            <Button title="Attachments" onClick={ this.showAttachments }>Attachments ({ bus.attachments ? bus.attachments.length : 0 })</Button>
            <Button title="History" onClick={ this.showHistory }>History</Button>
          </Col>
          <Col md={2}>
            <div className="pull-right">
              <Button><Glyphicon glyph="print" title="Print" /></Button>
              <LinkContainer to={{ pathname: 'school-buses' }}>
                <Button title="Return to List"><Glyphicon glyph="arrow-left" /> Return to List</Button>
              </LinkContainer>
            </div>
          </Col>
        </Row>

        {(() => {
          if (this.state.loadingSchoolBus) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

          return <div id="school-buses-header">
            <Row>
              <Col md={12}>
                <h1>School Bus Owner: <small>{ bus.ownerName }</small></h1>
              </Col>
            </Row>
            <Row>
              <Col md={1}></Col>
              <Col md={11}>
                <h1>Registration: <small>{ bus.icbcRegistrationNumber }</small>
                  &nbsp;Plate: <small>{ bus.licencePlateNumber }</small>
                  &nbsp;VIN: <small>{ bus.vehicleIdentificationNumber }</small>
                  &nbsp;Permit: <small>{ bus.permitNumber }</small>
                  {(() => {
                    if (bus.permitNumber) {
                      return <Button bsSize="small">Print Permit</Button>;
                    }
                    return <Button bsSize="small">Generate Permit</Button>;
                  })()}
                </h1>
              </Col>
            </Row>
          </div>;
        })()}

        <Row>
          <Col md={6}>
            <Well>
              <h3>School Bus Data <span className="pull-right"><Button title="edit" bsSize="small" onClick={ this.openEditDialog }><Glyphicon glyph="edit" /></Button></span></h3>
              {(() => {
                if (this.state.loadingSchoolBus) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                return <div id="school-buses-data">
                  <Row>
                    <ColLabel md={4}>District</ColLabel>
                    <ColField md={8}>{ bus.districtName }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Inspector</ColLabel>
                    <ColField md={8}>{ bus.inspectorName }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Home Terminal</ColLabel>
                    <ColField md={8}>{ bus.homeTerminalAddress }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>City, Province</ColLabel>
                    <ColField md={8}>{ bus.homeTerminalCityProv }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Postal Code</ColLabel>
                    <ColField md={8}>{ bus.homeTerminalPostalCode }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Description</ColLabel>
                    <ColField md={8}>{ bus.homeTerminalComment }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Permit Class</ColLabel>
                    <ColField md={8}>{ bus.permitClassCode }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Body Type</ColLabel>
                    <ColField md={8}>{ bus.bodyTypeCode }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Restrictions</ColLabel>
                    <ColField md={8}>{ bus.restrictionsText }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>School District</ColLabel>
                    <ColField md={8}>{ bus.schoolDistrictName }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Independent School</ColLabel>
                    <ColField md={1}><CheckboxControl checked={ bus.isIndependentSchool } disabled></CheckboxControl></ColField>
                    <ColField md={6}>{ bus.independentSchoolName }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Unit Number</ColLabel>
                    <ColField md={8}>{ bus.unitNumber }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Seating Capacity</ColLabel>
                    <ColField md={1}>{ bus.schoolBusSeatingCapacity }</ColField>
                    <ColLabel md={4}>Mobile Aid Capacity</ColLabel>
                    <ColField md={1}>{ bus.mobilityAidCapacity }</ColField>
                    <Col md={2}></Col>
                  </Row>
                </div>;
              })()}
            </Well>
          </Col>
          <Col md={6}>
            <Well>
              <h3>Inspection History <span className="pull-right"><Button title="addInspection" onClick={ this.addInspection } bsSize="small"><Glyphicon glyph="plus" /></Button></span></h3>
              {(() => {
                if (this.state.loadingSchoolBusInspections ) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }
                if (Object.keys(this.props.schoolBusInspections).length === 0) { return <Alert bsStyle="success" style={{ marginTop: 10 }}>No inspections</Alert>; }

                var inspections = _.sortBy(this.props.schoolBusInspections, this.state.ui.sortField);
                if (this.state.ui.sortDesc) {
                  _.reverse(inspections);
                }

                var headers = [
                  { field: 'inspectionDateSort',   title: 'Inspection Date' },
                  { field: 'inspectionTypeCode',   title: 'Type'            },
                  { field: 'inspectionResultCode', title: 'Status'          },
                  { field: 'inspectorName',        title: 'Inspector'       },
                  { field: 'blank' },
                ];

                return <SortTable id="inspection-list" sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={ headers }>
                  {
                    _.map(inspections, (inspection) => {
                      return <tr key={ inspection.id }>
                        <td>{ formatDateTime(inspection.inspectionDate, 'YYYY-MM-DD') }</td>
                        <td>{ inspection.inspectionTypeCode }
                          { inspection.isReinspection ? <BadgeLabel bsStyle="info">R</BadgeLabel> : null }
                        </td>
                        <td>{ inspection.inspectionResultCode }</td>
                          <td>{ inspection.inspectorName }</td>
                        <td style={{ textAlign: 'right' }}>
                          <ButtonGroup>
                            <Button className={ inspection.canEdit ? '' : 'hidden' } title="editInspection" bsSize="xsmall" onClick={ this.openInspectionDialog.bind(this, inspection) }><Glyphicon glyph="pencil" /></Button>
                            <OverlayTrigger trigger="click" placement="top" rootClose overlay={ <Confirm onConfirm={ this.deleteInspection.bind(this, inspection) }/> }>
                              <Button className={ inspection.canDelete ? '' : 'hidden' } title="deleteInspection" bsSize="xsmall"><Glyphicon glyph="trash" /></Button>
                            </OverlayTrigger>
                          </ButtonGroup>
                        </td>
                      </tr>;
                    })
                  }
                </SortTable>;
              })()}
              <div className="text-right"><Button target="_blank" href="http://google.com/search?q=CTMS-Web">CTMS-Web</Button></div>
            </Well>
          </Col>
        </Row>
        <Row>
          <Col md={12}>
            <Well>
              <h3>Policy</h3>
              {(() => {
                if (this.state.loadingSchoolBusCCW) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                return <div id="school-buses-policy">
                  <Row>
                    <ColLabel md={2}>Policy #</ColLabel>
                    <ColField md={2}>{ ccw.nscPolicyNumber }</ColField>
                    <ColLabel md={2}>Status Date</ColLabel>
                    <ColField md={2}>{ formatDateTime(ccw.nscPolicyStatusDate, 'YYYY-MMM-DD') }</ColField>
                    <ColLabel md={2}>Status Is</ColLabel>
                    <ColField md={2}>{ ccw.nscPolicyStatus }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={2}>Effective Date</ColLabel>
                    <ColField md={2}>{ formatDateTime(ccw.nscPolicyEffectiveDate, 'YYYY-MMM-DD') }</ColField>
                    <ColLabel md={2}>Expiry Date</ColLabel>
                    <ColField md={2}>{ formatDateTime(ccw.nscPolicyExpiryDate, 'YYYY-MMM-DD') }</ColField>
                    <ColLabel md={2}>Plate Decal #</ColLabel>
                    <ColField md={2}>{ ccw.nscPlateDecal }</ColField>
                  </Row>
                </div>;
              })()}
            </Well>
          </Col>
        </Row>
        <Row>
          <Col md={6}>
            <Well>
              <h3>ICBC Registered Owner</h3>
              {(() => {
                if (this.state.loadingSchoolBusCCW) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                var city = concat(ccw.icbcRegOwnerCity, ccw.icbcRegOwnerProv);
                city = concat(city, ccw.icbcRegOwnerPostalCode);

                return <div id="school-buses-icbc-owner">
                  <Row>
                    <ColLabel md={2}>Owner</ColLabel>
                    <ColField md={6}>{ ccw.icbcRegOwnerName }</ColField>
                    <ColLabel md={2}>Is</ColLabel>
                    <ColField md={2}>{ ccw.icbcRegOwnerStatus }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={2}>Address</ColLabel>
                    <ColField md={6}>{(() => {
                      if (ccw.icbcRegOwnerAddr1 && ccw.icbcRegOwnerAddr2 && city) {
                        return <div>{ ccw.icbcRegOwnerAddr1 }<br />{ ccw.icbcRegOwnerAddr2 }<br />{ city }</div>;
                      }
                      if (ccw.icbcRegOwnerAddr1 && ccw.icbcRegOwnerAddr2) {
                        return <div>{ ccw.icbcRegOwnerAddr1 }<br />{ ccw.icbcRegOwnerAddr2 }</div>;
                      }
                      if ((ccw.icbcRegOwnerAddr1 || ccw.icbcRegOwnerAddr2) && city) {
                        return <div>{ ccw.icbcRegOwnerAddr1 }{ ccw.icbcRegOwnerAddr2 }<br />{ city }</div>;
                      }
                      return <div>{ ccw.icbcRegOwnerAddr1 }{ ccw.icbcRegOwnerAddr2 }</div>;
                    })()}</ColField>
                    <ColLabel md={2}>RODL #<br />PODL #</ColLabel>
                    <ColField md={2}>{ ccw.icbcRegOwnerRODL }<br />{ ccw.icbcRegOwnerPool }</ColField>
                  </Row>
                </div>;
              })()}
            </Well>
          </Col>
          <Col md={6}>
            <Well>
              <h3>NSC</h3>
              {(() => {
                if (this.state.loadingSchoolBusCCW) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                return <div id="school-buses-nsc">
                  <Row>
                    <ColLabel md={4}>NSC #</ColLabel>
                    <ColField md={8}>{ ccw.nscClientNum }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Carrier Name</ColLabel>
                    <ColField md={8}>{ ccw.nscCarrierName }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Carrier Conditions</ColLabel>
                    <ColField md={8}>{ ccw.nscCarrierConditions }</ColField>
                  </Row>
                  <Row>
                    <ColLabel md={4}>Carrier Safety Rating</ColLabel>
                    <ColField md={8}>{ ccw.nscCarrierSafetyRating }</ColField>
                  </Row>
                </div>;
              })()}
            </Well>
          </Col>
        </Row>
        <Row>
          <Col md={12}>
            <Well>
              <h3>ICBC Vehicle Data</h3>
              {(() => {
                if (this.state.loadingSchoolBusCCW) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                return <div id="school-buses-icbc-vehicle">
                  <Row>
                    <Col md={6}>
                     <Row>
                        <ColLabel md={3}>Year</ColLabel>
                        <ColField md={3}>{ ccw.icbcModelYear }</ColField>
                        <ColLabel md={3}>GVW</ColLabel>
                        <ColField md={3}>{ ccw.icbcGrossVehicleWeight }</ColField>
                      </Row>
                      <Row>
                        <ColLabel md={3}>Vehicle Type</ColLabel>
                        <ColField md={3}>{ ccw.icbcVehicleType }</ColField>
                        <ColLabel md={3}>Make</ColLabel>
                        <ColField md={3}>{ ccw.icbcMake }</ColField>
                      </Row>
                      <Row>
                        <ColLabel md={3}>Rate Class</ColLabel>
                        <ColField md={3}>{ ccw.icbcRateClass }</ColField>
                        <ColLabel md={3}>Body</ColLabel>
                        <ColField md={3}>{ ccw.icbcBody }</ColField>
                      </Row>
                      <Row>
                        <ColLabel md={3}>CVIP Decal</ColLabel>
                        <ColField md={3}>{ ccw.icbccvipDecal }</ColField>
                        <ColLabel md={3}>Rebuilt Status</ColLabel>
                        <ColField md={3}>{ ccw.icbcRebuiltStatus }</ColField>
                      </Row>
                      <Row>
                        <ColLabel md={3}>Fleet Unit #</ColLabel>
                        <ColField md={3}>{ ccw.icbcFleetUnitNo }</ColField>
                        <ColLabel md={3}>CVIP Expiry</ColLabel>
                        <ColField md={3}>{ formatDateTime(ccw.icbccvipExpiry, 'YYYY-MMM-DD') }</ColField>
                      </Row>
                    </Col>
                    <Col md={6}>
                      <Row>
                        <ColLabel md={3}>Net Wt</ColLabel>
                        <ColField md={3}>{ ccw.icbcNetWt }</ColField>
                        <Col md={6}></Col>
                      </Row>
                      <Row>
                        <ColLabel md={3}>Model</ColLabel>
                        <ColField md={3}>{ ccw.icbcModel }</ColField>
                        <ColLabel md={3}>Colour</ColLabel>
                        <ColField md={3}>{ ccw.icbcColour }</ColField>
                      </Row>
                      <Row>
                        <ColLabel md={3}>Fuel</ColLabel>
                        <ColField md={3}>{ ccw.icbcFuel }</ColField>
                        <Col md={6}></Col>
                      </Row>
                      <Row>
                        <ColLabel md={3}>Seating Capacity</ColLabel>
                        <ColField md={3}>{ ccw.icbcSeatingCapacity }</ColField>
                        <Col md={6}></Col>
                      </Row>
                      <Row>
                        <ColLabel md={3}>N&amp;O</ColLabel>
                        <ColField md={3}>{ ccw.icbcNotesAndOrders }</ColField>
                        <ColLabel md={3}>Ordered On</ColLabel>
                        <ColField md={3}>{ formatDateTime(ccw.icbcOrderedOn, 'YYYY-MMM-DD') }</ColField>
                      </Row>
                    </Col>
                  </Row>
                </div>;
              })()}
            </Well>
          </Col>
        </Row>
      </div>
      { this.state.showEditDialog &&
        <SchoolBusesEditDialog show={ this.state.showEditDialog } onSave={ this.saveEdit } onClose= { this.closeEditDialog } />
      }
      { this.state.showInspectionDialog &&
        <InspectionEditDialog show={ this.state.showInspectionDialog } inspection={ this.state.inspection } onSave={ this.saveInspection } onClose= { this.closeInspectionDialog } />
      }
    </div>;
  },
});

function mapStateToProps(state) {
  return {
    schoolBus: state.models.schoolBus,
    schoolBusCCW: state.models.schoolBusCCW,
    schoolBusInspections: state.models.schoolBusInspections,
    ui: state.ui.inspections,
  };
}

export default connect(mapStateToProps)(SchoolBusesDetail);
