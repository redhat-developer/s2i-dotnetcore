import React from 'react';

import { connect } from 'react-redux';

import { Well, Row, Col  } from 'react-bootstrap';
import { Alert, Label, Button, ButtonGroup, Glyphicon, Checkbox  } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';

import HistoryListDialog from './dialogs/HistoryListDialog.jsx';
import InspectionEditDialog from './dialogs/InspectionEditDialog.jsx';
import SchoolBusesEditDialog from './dialogs/SchoolBusesEditDialog.jsx';

import * as Action from '../actionTypes';
import * as Api from '../api';
import * as Constant from '../constants';
import * as History from '../history';
import store from '../store';

import BadgeLabel from '../components/BadgeLabel.jsx';
import ColDisplay from '../components/ColDisplay.jsx';
import DeleteButton from '../components/DeleteButton.jsx';
import EditButton from '../components/EditButton.jsx';
import InfoButton from '../components/InfoButton.jsx';
import SchoolBusBodyDescription from '../components/SchoolBusBodyDescription.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';
import Unimplemented from '../components/Unimplemented.jsx';

import { formatDateTime } from '../utils/date';
import { concat, plural } from '../utils/string';


var SchoolBusesDetail = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
    schoolBus: React.PropTypes.object,
    owner: React.PropTypes.object,
    schoolBusCCW: React.PropTypes.object,
    schoolBusInspections: React.PropTypes.object,
    inspection: React.PropTypes.object,
    ui: React.PropTypes.object,
    params: React.PropTypes.object,
    router: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loadingSchoolBus: true,
      loadingSchoolBusInspections: true,

      workingOnPermit: false,

      showEditDialog: false,
      showHistoryDialog: false,
      showInspectionDialog: false,

      inspection: {},

      isNew: this.props.params.schoolBusId === '0',

      ui: {
        // Inspections
        sortField: this.props.ui.sortField || 'inspectionDateSort',
        sortDesc: this.props.ui.sortDesc != false, // defaults to true
      },
    };
  },

  componentDidMount() {
    // Don't just check if this is new. Make sure we're coming in through the Owner screen and not
    // via a refresh of the screen. Also, make sure we have CCW data.
    if (this.state.isNew && this.props.owner.id && this.props.schoolBusCCW.icbcRegistrationNumber) {
      // Clear the spinners
      this.setState({
        loadingSchoolBus: false,
        loadingSchoolBusInspections: false,
      });
      // Clear the school bus store, except for the fields
      // we have from the owner and ccw data.
      store.dispatch({ type: Action.UPDATE_BUS, schoolBus: {
        id: 0,
        schoolBusOwner: { id: this.props.owner.id },
        icbcRegistrationNumber: this.props.schoolBusCCW.icbcRegistrationNumber || '',
        licencePlateNumber: this.props.schoolBusCCW.icbcLicencePlateNumber || '',
        vehicleIdentificationNumber: this.props.schoolBusCCW.icbcVehicleIdentificationNumber || '',
        ccwData: this.props.schoolBusCCW,
      }});
      // Open editor to add new bus
      this.openEditDialog();
    } else {
      this.fetch().then(() => {
        this.openInspection(this.props);
      });
    }
  },

  componentWillReceiveProps(nextProps) {
    if (!_.isEqual(nextProps.params, this.props.params)) {
      if (nextProps.params.inspectionId && !this.props.params.inspectionId) {
        this.openInspection(nextProps);
      }
    }
  },

  openInspection(props) {
    var inspection = null;

    if (props.params.inspectionId === '0') {
      // New
      inspection = {
        id: 0,
        schoolBus: props.schoolBus,
        inspector: { id: props.currentUser.isInspector ? props.currentUser.id : 0 },
      };
    } else if (props.params.inspectionId) {
      // Open the inspection for viewing if possible
      inspection = props.schoolBusInspections[props.params.inspectionId];
    }

    if (inspection) {
      this.openInspectionDialog(inspection);
    }
  },

  fetch() {
    this.setState({
      loadingSchoolBus: true,
      loadingSchoolBusInspections: true,
    });

    var id = this.props.params.schoolBusId;

    Api.getSchoolBus(id).then(() => {
      this.setState({ loadingSchoolBus: false });
      // Fetch CCW to make sure it's up to date
      var params = {};
      if (this.props.schoolBus.icbcRegistrationNumber) {
        params[Constant.CCW_REGISTRATION] = this.props.schoolBus.icbcRegistrationNumber;
      }
      if (this.props.schoolBus.licencePlateNumber) {
        params[Constant.CCW_PLATE] = this.props.schoolBus.licencePlateNumber;
      }
      if (this.props.schoolBus.vehicleIdentificationNumber) {
        params[Constant.CCW_VIN] = this.props.schoolBus.vehicleIdentificationNumber;
      }
      if (Object.keys(params).length > 0) {
        return Api.searchCCW(params).then(() => {
          // Chicanery: push the CCW data into our school bus store.
          store.dispatch({ type: Action.UPDATE_BUS, schoolBus: { ...this.props.schoolBus, ccwData: this.props.schoolBusCCW }});
        });
      }
    }).finally(() => {
      this.setState({ loadingSchoolBus: false });
    });
    return Api.getSchoolBusInspections(id).finally(() => {
      this.setState({ loadingSchoolBusInspections: false });
    });
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

  onSaveEdit(schoolBus) {
    if (schoolBus.id) {
      
      // Check for school bus status or owner change
      var statusChanged = (this.props.schoolBus.status !== schoolBus.status) ? true : false;
      var ownerChanged = (this.props.schoolBus.schoolBusOwner.id !== schoolBus.schoolBusOwner.id) ? true : false;
      
      Api.updateSchoolBus(schoolBus).then(() => {
        // Log existing SchoolBus modified
        History.logModifiedBus(this.props.schoolBus);

        // Check for bus status change
        if(statusChanged) {
          History.logModifiedBusStatus(this.props.schoolBus);
        }

        // Check for school bus owner change
        if(ownerChanged) {
          // First parameter contains school bus entity with new owner info
          // Second parameter contains previous owner entity
          History.logModifiedBusOwner(this.props.schoolBus, this.props.owner);
        }
      });
    } else {
      // Save the new school bus record
      Api.addSchoolBus(schoolBus).then(() => {
        // Reload the screen with new school bus id
        this.props.router.push({
          pathname: this.props.schoolBus.path,
        });
        // Log it
        History.logNewBus(this.props.schoolBus, this.props.owner);
      });
    }

    this.closeEditDialog();
  },

  onCloseEdit() {
    this.closeEditDialog();
    if (this.state.isNew) {
      // Go back to owner page if cancelling new school bus
      this.props.router.push({
        pathname: this.props.owner.path,
      });
    }
  },

  openInspectionDialog(inspection) {
    this.setState({
      inspection: inspection,
      showInspectionDialog: true,
    });
  },

  closeInspectionDialog() {
    this.setState({ showInspectionDialog: false }, () => {
      // Reset school bus location
      this.props.router.push({
        pathname: this.props.schoolBus.path,
      });
    });
  },

  getInspections() {
    this.setState({ loadingSchoolBusInspections: true });
    Api.getSchoolBusInspections(this.props.params.schoolBusId).finally(() => {
      this.setState({ loadingSchoolBusInspections: false });
    });
  },

  addInspection() {
    this.props.router.push({
      pathname: `${ this.props.schoolBus.path }/${ Constant.INSPECTION_PATHNAME }/0`,
    });
  },

  deleteInspection(inspection) {
    Api.deleteInspection(inspection).then(() => {
      // In addition to refreshing the inspections, we need to update the school bus record
      // to get the new next inspection data.
      this.fetch();

      History.logDeletedInspection(this.props.schoolBus, this.props.inspection);
    });
  },

  saveInspection(inspection) {
    // Update or add accordingly
    var isNew = !inspection.id;

    var inspectionPromise = isNew ? Api.addInspection : Api.updateInspection;

    inspectionPromise(inspection).then(() => {
      if (isNew) {
        // Log it
        History.logNewInspection(this.props.schoolBus, this.props.inspection);
      } else {
        History.logModifiedInspection(this.props.schoolBus, this.props.inspection);
      }

      // Refresh the inspections table
      this.getInspections();
      // Save next inspection data to this school bus record
      return Api.updateSchoolBus({ ...this.props.schoolBus, ...{
        nextInspectionDate: inspection.nextInspectionDate,
        nextInspectionTypeCode: inspection.nextInspectionTypeCode,
      }});
    }).finally(() => {
      this.closeInspectionDialog();
    });
  },

  showNotes() {
  },

  showAttachments() {
  },

  showHistoryDialog() {
    this.setState({ showHistoryDialog: true });
  },

  closeHistoryDialog() {
    this.setState({ showHistoryDialog: false });
  },

  print() {
  },

  generatePermit() {
    // This API call will update the school bus state after generating a permit.
    this.setState({ workingOnPermit: true });
    Api.newSchoolBusPermit(this.props.params.schoolBusId).then(() => {
      // Log generated permit to bus history
      History.logGeneratedBusPermit(this.props.schoolBus);
    }).finally(() => {
      this.setState({ workingOnPermit: false });
    });
  },

  printPermit() {
    this.setState({ workingOnPermit: true });
    // Get path to PDF API call and call it in a new browser window.
    window.open(Api.getSchoolBusPermitURL(this.props.params.schoolBusId));
    this.setState({ workingOnPermit: false });
  },

  render() {
    var bus = this.props.schoolBus;
    var ccw = this.props.schoolBus.ccwData || {};

    var daysToInspection = bus.daysToInspection;
    if (bus.isOverdue) { daysToInspection *= -1; }

    var inspectionNotice = (bus.isReinspection ? '&reg; ' : '') + (bus.isOverdue ? 'Overdue &ndash; ' : '')
      + daysToInspection + ' ' + plural(daysToInspection, 'day', 'days')
      + ' &ndash; ' + formatDateTime(bus.nextInspectionDate, Constant.DATE_FULL_MONTH_DAY_YEAR);

    var inspectionStyle = bus.isOverdue ? 'danger' : (daysToInspection <= Constant.INSPECTION_DAYS_DUE_WARNING ? 'warning' : 'success');

    return <div id="school-buses-detail">
      <div>
        <Row id="school-buses-top">
          <Col md={10}>
            <Label bsStyle={ bus.isActive ? 'success' : 'danger'}>{ bus.isActive ? 'Verified Active' : bus.status }</Label>
            <Label className={ bus.isOutOfProvince ? '' : 'hide' }>Out of Province</Label>
            { bus.nextInspectionDate &&
              <span className={ `label label-${inspectionStyle}` } dangerouslySetInnerHTML={{ __html: inspectionNotice }}></span>
            }
            <Unimplemented>
              <Button title="Notes" onClick={ this.showNotes }>Notes ({ bus.notes ? bus.notes.length : 0 })</Button>
            </Unimplemented>
            <Unimplemented>
              <Button title="Attachments" onClick={ this.showAttachments }>Attachments ({ bus.attachments ? bus.attachments.length : 0 })</Button>
            </Unimplemented>
            <Button title="History" onClick={ this.showHistoryDialog }>History</Button>
          </Col>
          <Col md={2}>
            <div className="pull-right">
              <Unimplemented>
                <Button onClick={ this.print }><Glyphicon glyph="print" title="Print" /></Button>
              </Unimplemented>
              <LinkContainer to={{ pathname: Constant.BUSES_PATHNAME }}>
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
                <h1>School Bus Owner: <small><a href={ bus.ownerURL }>{ bus.ownerName }</a></small></h1>
              </Col>
            </Row>
            <Row>
              <Col md={12}>
                <h1 id="school-buses-keys">Registration: <small>{ bus.icbcRegistrationNumber }</small>
                  &nbsp;Plate: <small>{ bus.licencePlateNumber }</small>
                  &nbsp;VIN: <small>{ bus.vehicleIdentificationNumber }</small>
                  &nbsp;Permit: <small>{ bus.permitNumber }</small>
                  {
                    bus.permitNumber ?
                      <Button onClick={ this.printPermit } bsSize="small">
                      { this.state.workingOnPermit ? <span id="permitSpinner" style={{ textAlign: 'center', marginLeft: -10 }}><Spinner/></span> : 'Print Permit' }
                      </Button>
                      :
                      <Button onClick={ this.generatePermit } bsSize="small">
                        { this.state.workingOnPermit ? <span id="permitSpinner" style={{ textAlign: 'center', marginLeft: -10 }}><Spinner/></span> : 'Generate Permit' }
                      </Button>
                  }
                  {
                    bus.permitIssueDate && <small id="issued-date">&nbsp;(Issued: { formatDateTime(bus.permitIssueDate, Constant.DATE_SHORT_MONTH_DAY_YEAR) })</small>
                  }
                </h1>
              </Col>
            </Row>
          </div>;
        })()}

        <Row>
          <Col md={6}>
            <Well>
              <h3>School Bus Data <span className="pull-right"><Button title="Edit Bus" bsSize="small" onClick={ this.openEditDialog }><Glyphicon glyph="pencil" /></Button></span></h3>
              {(() => {
                if (this.state.loadingSchoolBus) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                return <div id="school-buses-data">
                  <Row>
                    <ColDisplay md={12} label="District">{ bus.districtName }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Inspector">{ bus.inspectorName }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Home Terminal">{ bus.homeTerminalAddress }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="City, Province">{ bus.homeTerminalCityProv }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Postal Code">{ bus.homeTerminalPostalCode }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Description">{ bus.homeTerminalComment }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Permit Class">{ bus.permitClassCode }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label={ <span>
                      <InfoButton title="School Bus Body Description">
                        <SchoolBusBodyDescription />
                      </InfoButton><span>Body Description</span>
                    </span> }>
                      { bus.bodyTypeCode }
                    </ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Restrictions">{ bus.restrictionsText }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="School District">{ bus.schoolDistrictName }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={4} label="Independent School"><Checkbox defaultChecked={ bus.isIndependentSchool } disabled></Checkbox></ColDisplay>
                    <ColDisplay md={8}>{ bus.independentSchoolName }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Unit Number">{ bus.unitNumber }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Seating Capacity">{ bus.schoolBusSeatingCapacity }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Mobile Aid Capacity">{ bus.mobilityAidCapacity }</ColDisplay>
                  </Row>
                </div>;
              })()}
            </Well>
          </Col>
          <Col md={6}>
            <Well>
              <h3>Inspection History</h3>
              {(() => {
                if (this.state.loadingSchoolBusInspections ) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                var addInspectionButton = <Button title="Add Inspection" onClick={ this.addInspection } bsSize="xsmall"><Glyphicon glyph="plus" />&nbsp;<strong>Add</strong></Button>;

                if (Object.keys(this.props.schoolBusInspections).length === 0) { return <Alert bsStyle="success">No inspections { addInspectionButton }</Alert>; }

                var inspections = _.sortBy(this.props.schoolBusInspections, this.state.ui.sortField);
                if (this.state.ui.sortDesc) {
                  _.reverse(inspections);
                }

                var headers = [
                  { field: 'inspectionDateSort',   title: 'Date'      },
                  { field: 'inspectionTypeCode',   title: 'Type'      },
                  { field: 'inspectionResultCode', title: 'Status'    },
                  { field: 'inspectorName',        title: 'Inspector' },
                  { field: 'addInspection',        title: 'Add Inspection', style: { textAlign: 'right'  },
                    node: addInspectionButton,
                  },
                ];

                return <SortTable id="inspection-list" sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={ headers }>
                  {
                    _.map(inspections, (inspection) => {
                      return <tr key={ inspection.id }>
                        <td>{ formatDateTime(inspection.inspectionDate, Constant.DATE_SHORT_MONTH_DAY_YEAR) }</td>
                        <td>{ inspection.inspectionTypeCode }
                          { inspection.isReinspection ? <BadgeLabel bsStyle="info">R</BadgeLabel> : null }
                        </td>
                        <td>{ inspection.inspectionResultCode }</td>
                        <td>{ inspection.inspectorName }</td>
                        <td style={{ textAlign: 'right' }}>
                          <ButtonGroup>
                            <DeleteButton name="Inspection" hide={ !inspection.canDelete} onConfirm={ this.deleteInspection.bind(this, inspection) }/>
                            <EditButton name="Inspection" view={ !inspection.canEdit} pathname={ inspection.path }/>
                          </ButtonGroup>
                        </td>
                      </tr>;
                    })
                  }
                </SortTable>;
              })()}
            </Well>
          </Col>
        </Row>
        <Row>
          <Col md={12}>
            <Well>
              <h3>Policy</h3>
              {(() => {
                if (this.state.loadingSchoolBus) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                return <div id="school-buses-policy">
                  <Row>
                    <ColDisplay md={4} label="Policy #">{ ccw.nscPolicyNumber }</ColDisplay>
                    <ColDisplay md={4} label="Status Date">{ formatDateTime(ccw.nscPolicyStatusDate, Constant.DATE_SHORT_MONTH_DAY_YEAR) }</ColDisplay>
                    <ColDisplay md={4} label="Status">{ ccw.nscPolicyStatus }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={4} label="Effective Date">{ formatDateTime(ccw.nscPolicyEffectiveDate, Constant.DATE_SHORT_MONTH_DAY_YEAR) }</ColDisplay>
                    <ColDisplay md={4} label="Expiry Date">{ formatDateTime(ccw.nscPolicyExpiryDate, Constant.DATE_SHORT_MONTH_DAY_YEAR) }</ColDisplay>
                    <ColDisplay md={4} label="Plate Decal #">{ ccw.nscPlateDecal }</ColDisplay>
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
                if (this.state.loadingSchoolBus) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                var city = concat(ccw.icbcRegOwnerCity, ccw.icbcRegOwnerProv);
                city = concat(city, ccw.icbcRegOwnerPostalCode);

                return <div id="school-buses-icbc-owner">
                  <Row>
                    <ColDisplay md={8} label="Owner">{ ccw.icbcRegOwnerName }</ColDisplay>
                    <ColDisplay md={4} label="Status">{ ccw.icbcRegOwnerStatus }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={8} label="Address">{(() => {
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
                    })()}</ColDisplay>
                    <ColDisplay md={4} label={ <span>RODL #<br />PODL #</span> }>{ ccw.icbcRegOwnerRODL }<br />{ ccw.icbcRegOwnerPODL }</ColDisplay>
                  </Row>
                </div>;
              })()}
            </Well>
          </Col>
          <Col md={6}>
            <Well>
              <h3>NSC</h3>
              {(() => {
                if (this.state.loadingSchoolBus) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                return <div id="school-buses-nsc">
                  <Row>
                    <ColDisplay md={12} label="NSC #">{ ccw.nscClientNum }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Carrier Name">{ ccw.nscCarrierName }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Carrier Conditions">{ ccw.nscCarrierConditions }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={12} label="Carrier Safety Rating">{ ccw.nscCarrierSafetyRating }</ColDisplay>
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
                if (this.state.loadingSchoolBus) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

                return <div id="school-buses-icbc-vehicle">
                  <Row>
                    <ColDisplay md={3} label="Year">{ ccw.icbcModelYear }</ColDisplay>
                    <ColDisplay md={3} label="GVW">{ ccw.icbcGrossVehicleWeight }</ColDisplay>
                    <ColDisplay md={3} label="Net Wt">{ ccw.icbcNetWt }</ColDisplay>
                    <Col md={3}></Col>
                  </Row>
                  <Row>
                    <ColDisplay md={3} label="Vehicle Type">{ ccw.icbcVehicleType }</ColDisplay>
                    <ColDisplay md={3} label="Make">{ ccw.icbcMake }</ColDisplay>
                    <ColDisplay md={3} label="Model">{ ccw.icbcModel }</ColDisplay>
                    <ColDisplay md={3} label="Colour">{ ccw.icbcColour }</ColDisplay>
                  </Row>
                  <Row>
                    <ColDisplay md={3} label="Rate Class">{ ccw.icbcRateClass }</ColDisplay>
                    <ColDisplay md={3} label="Body">{ ccw.icbcBody }</ColDisplay>
                    <ColDisplay md={3} label="Fuel">{ ccw.icbcFuel }</ColDisplay>
                    <Col md={6}></Col>
                  </Row>
                  <Row>
                    <ColDisplay md={3} label="CVIP Decal">{ ccw.icbccvipDecal }</ColDisplay>
                    <ColDisplay md={3} label="Rebuilt Status">{ ccw.icbcRebuiltStatus }</ColDisplay>
                    <ColDisplay md={3} label="Seating Capacity">{ ccw.icbcSeatingCapacity }</ColDisplay>
                    <Col md={6}></Col>
                  </Row>
                  <Row>
                    <ColDisplay md={3} label="Fleet Unit #">{ ccw.icbcFleetUnitNo }</ColDisplay>
                    <ColDisplay md={3} label="CVIP Expiry">{ formatDateTime(ccw.icbccvipExpiry, Constant.DATE_SHORT_MONTH_DAY_YEAR) }</ColDisplay>
                    <ColDisplay md={3} label="N&amp;O">{ ccw.icbcNotesAndOrders }</ColDisplay>
                    <ColDisplay md={3} label="Ordered On">{ formatDateTime(ccw.icbcOrderedOn, Constant.DATE_SHORT_MONTH_DAY_YEAR) }</ColDisplay>
                  </Row>
                </div>;
              })()}
            </Well>
          </Col>
        </Row>
        { ccw.dateFetched &&
          <Row>
            <Col md={12}>
              <span id="school-buses-ccw-fetched">ICBC data last fetched on { formatDateTime(ccw.dateFetched, Constant.DATE_TIME_READABLE) }</span>
            </Col>
          </Row>
        }
      </div>
      { this.state.showEditDialog &&
        <SchoolBusesEditDialog show={ this.state.showEditDialog } onSave={ this.onSaveEdit } onClose={ this.onCloseEdit } />
      }
      { this.state.showHistoryDialog &&
        <HistoryListDialog show={ this.state.showHistoryDialog } historyEntity={ bus.historyEntity } onClose={ this.closeHistoryDialog } />
      }
      { this.state.showInspectionDialog &&
        <InspectionEditDialog show={ this.state.showInspectionDialog } inspection={ this.state.inspection } onSave={ this.saveInspection } onClose={ this.closeInspectionDialog } />
      }
    </div>;
  },
});

function mapStateToProps(state) {
  return {
    currentUser: state.user,
    schoolBus: state.models.schoolBus,
    owner: state.models.owner,
    schoolBusCCW: state.models.schoolBusCCW,
    schoolBusInspections: state.models.schoolBusInspections,
    inspection: state.models.inspection,
    ui: state.ui.inspections,
  };
}

export default connect(mapStateToProps)(SchoolBusesDetail);
