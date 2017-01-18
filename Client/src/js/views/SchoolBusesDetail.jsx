import React from 'react';
import { connect } from 'react-redux';
import { Well, Row, Col  } from 'react-bootstrap';
import { Alert, Label, Button, Glyphicon, Checkbox, Table  } from 'react-bootstrap';

import _ from 'lodash';

import Spinner from '../components/Spinner.jsx';

import { formatDateTime } from '../utils/date';
import { concat, plural } from '../utils/string';

import * as Api from '../api';

/*

Notes on the screen:

  "Out of Province" is grayed out (or not displayed?) if false. The drop down would only visible in edit mode.
  The Next Inspection date:
    Has an "R" if it is a "Re-inspection" inspection type
    Is red if it is overdue (red = "error")
    Is yellow if it is due within 30 (configurable) days (yellow = warn)
    Is white otherwise (white, green = "OK" - one or other chosen based on context)
    Has the correspondingly appropriate font colour based on the colour.
  Notes, Attachments show record counts
  School Bus Data box shows the rest of the School Bus Data
  Inspections shows the list of inspections
  Remainder of the screen shows the CCW data

*/

const DAYS_DUE_WARNING = 30;

var SchoolBusesDetail = React.createClass({
  propTypes: {
    schoolBus: React.PropTypes.object,
    schoolBusAttachments: React.PropTypes.object,
    schoolBusCCW: React.PropTypes.object,
    schoolBusHistories: React.PropTypes.object,
    schoolBusInspections: React.PropTypes.object,
    schoolBusNotes: React.PropTypes.object,
    params: React.PropTypes.object,
    router: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loadingSchoolBus: false,
      loadingSchoolBusAttachments: false,
      loadingSchoolBusCCW: false,
      loadingSchoolBusHistories: false,
      loadingSchoolBusInspections: false,
      loadingSchoolBusNotes: false,
    };
  },

  componentDidMount() {
    this.fetch();
  },

  fetch() {
    this.setState({
      loadingSchoolBus: true,
      loadingSchoolBusAttachments: true,
      loadingSchoolBusCCW: true,
      loadingSchoolBusHistories: true,
      loadingSchoolBusInspections: true,
      loadingSchoolBusNotes: true,
    });

    var id = this.props.params.schoolBusId;

    Api.getSchoolBus(id).finally(() => {
      this.setState({ loadingSchoolBus: false });
    });
    Api.getSchoolBusAttachments(id).finally(() => {
      this.setState({ loadingSchoolBusAttachments: false });
    });
    Api.getSchoolBusCCW(id).finally(() => {
      this.setState({ loadingSchoolBusCCW: false });
    });
    Api.getSchoolBusHistories(id).finally(() => {
      this.setState({ loadingSchoolBusHistories: false });
    });
    Api.getSchoolBusInspections(id).finally(() => {
      this.setState({ loadingSchoolBusInspections: false });
    });
    Api.getSchoolBusNotes(id).finally(() => {
      this.setState({ loadingSchoolBusNotes: false });
    });
  },

  goToSchoolBuses() {
    this.props.router.push({
      pathname: 'school-buses',
    });
  },

  showNotes() {
    this.props.router.push({
      pathname: 'school-buses',
    });
  },

  showAttachments() {
    this.props.router.push({
      pathname: 'school-buses',
    });
  },

  showHistory() {
    this.props.router.push({
      pathname: 'school-buses',
    });
  },

  render() {
    var bus = this.props.schoolBus;
    var ccw = this.props.schoolBusCCW;

    var daysToInspection = bus.daysToInspection;
    if (bus.isOverdue) { daysToInspection *= -1; }

    var inspectionNotice = (bus.isReinspection ? 'R ' : '') + (bus.isOverdue ? 'Overdue - ' : '')
      + daysToInspection + ' ' + plural(daysToInspection, 'day', 'days')
      + ' - ' + formatDateTime(bus.nextInspectionDate, 'YYYY-DD-MMM');

    var inspectionStyle = bus.isOverdue ? 'danger' : (daysToInspection <= DAYS_DUE_WARNING ? 'warning' : 'success');

    return <div id="school-buses-detail">
      <Row id="school-buses-top">
        <Col md={10}>
          <Label bsStyle={ bus.isActive ? 'success' : 'danger'}>{ bus.isActive ? 'Verified Active' : bus.status }</Label>
          <Label className={ bus.isOutOfProvince ? '' : 'hide' }>Out of Province</Label>
          <Label bsStyle={ inspectionStyle }>{ inspectionNotice }</Label>
          <Button title="Notes" onClick={ this.showNotes }>Notes ({ Object.keys(this.props.schoolBusNotes).length })</Button>
          <Button title="Attachments" onClick={ this.showAttachments }>Attachments ({ Object.keys(this.props.schoolBusAttachments).length })</Button>
          <Button title="History" onClick={ this.showHistory }>History ({ Object.keys(this.props.schoolBusHistories).length })</Button>
        </Col>
        <Col md={2}>
          <Button><Glyphicon glyph="print" title="Print" /></Button>
          <Button title="Return to List" onClick={ this.goToSchoolBuses }>Return to List</Button>
        </Col>
      </Row>

      {(() => {
        if (this.state.loadingSchoolBus) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

        return <div id="school-buses-header">
          <Row>
            <Col md={12}>
              <h1>SB Owner: <small>{ bus.ownerName }</small></h1>
            </Col>
          </Row>
          <Row>
            <Col md={1}></Col>
            <Col md={11}>
              <h1>Regi: <small>{ bus.regi }</small>
                &nbsp;Plate: <small>{ bus.plate }</small>
                &nbsp;VIN: <small>{ bus.vin }</small>
                &nbsp;Permit: <small>{ bus.permitNumber }</small>
              </h1>
            </Col>
          </Row>
        </div>;
      })()}

      <Row>
        <Col md={6}>
          <Well>
            <h3>School Bus Data</h3>
            {(() => {
              if (this.state.loadingSchoolBus) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

              return <div id="school-buses-data">
                <Row>
                  <Col md={4} className="text-right"><strong>Area:</strong></Col>
                  <Col md={7} style={{ paddingLeft: 5 }}>{ bus.serviceAreaName }</Col>
                  <Col md={1}></Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>Inspector:</strong></Col>
                  <Col md={7} style={{ paddingLeft: 5 }}>{ bus.inspectorName }</Col>
                  <Col md={1}></Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>Home Terminal:</strong></Col>
                  <Col md={7} style={{ paddingLeft: 5 }}>{ bus.homeTerminalAddrs }</Col>
                  <Col md={1}></Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>City, Prov:</strong></Col>
                  <Col md={7} style={{ paddingLeft: 5 }}>{ bus.homeTerminalCityProv }</Col>
                  <Col md={1}></Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>Postal Code:</strong></Col>
                  <Col md={7} style={{ paddingLeft: 5 }}>{ bus.homeTerminalPostalCode }</Col>
                  <Col md={1}></Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>Desription:</strong></Col>
                  <Col md={7} style={{ paddingLeft: 5 }}>{ bus.homeTerminalComment }</Col>
                  <Col md={1}></Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>School Bus Class:</strong></Col>
                  <Col md={7} style={{ paddingLeft: 5 }}>{ bus.schoolBusClass }</Col>
                  <Col md={1}></Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>Restrictions:</strong></Col>
                  <Col md={7} style={{ paddingLeft: 5 }}>{ bus.restrictions }</Col>
                  <Col md={1}></Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>School District:</strong></Col>
                  <Col md={7} style={{ paddingLeft: 5 }}>{ bus.districtName }</Col>
                  <Col md={1}></Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>Independent School:</strong></Col>
                  <Col md={7} style={{ paddingLeft: 5 }}><Checkbox checked={ bus.isIndependentSchool } disabled></Checkbox></Col>
                  <Col md={1}></Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>Unit Number:</strong></Col>
                  <Col md={7} style={{ paddingLeft: 5 }}>{ bus.schoolBusUnitNumber }</Col>
                  <Col md={1}></Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>Seating Capacity:</strong></Col>
                  <Col md={1} style={{ paddingLeft: 5 }}>{ bus.schoolBusSeatingCapacity }</Col>
                  <Col md={4} className="text-right"><strong>Mobile Aid Capacity:</strong></Col>
                  <Col md={1} style={{ paddingLeft: 5 }}>{ bus.mobilityAidCapacity }</Col>
                  <Col md={2}></Col>
                </Row>
              </div>;
            })()}
          </Well>
        </Col>
        <Col md={6}>
          <Well>
            <h3>Inspection History</h3>
            <div className="text-right"><Button><Glyphicon glyph="plus" /> Add</Button></div>
            {(() => {
              if (this.state.loadingSchoolBusInspections ) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }
              if (Object.keys(this.props.schoolBusInspections).length === 0) { return <Alert bsStyle="success" style={{ marginTop: 10 }}>No inspections</Alert>; }

              return <Table condensed striped>
                <thead>
                  <tr>
                    <th>Inspection Date</th>
                    <th>Type</th>
                    <th>Status</th>
                    <th>Inspector</th>
                  </tr>
                </thead>
                <tbody>
                {
                  _.map(this.props.schoolBusInspections, (inspection) => {
                    var editPath = '#/inspections/' + inspection.id;

                    return <tr key={ bus.id } className={ bus.status != 'Active' ? 'info' : null }>
                      <td>{ formatDateTime(inspection.inspectionDate, 'YYYY-MM-DD') }</td>
                      <td>{ inspection.type }</td>
                      <td><a href={ editPath }>{ inspection.result }</a></td>
                      <td>{ bus.inspector ? concat(bus.inspector.givenName, bus.inspector.surname) : '' }</td>
                    </tr>;
                  })
                }
                </tbody>
              </Table>;
            })()}
            <div className="text-right"><Button>CTMS-Web</Button> <Button>All</Button></div>
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
                  <Col md={2} className="text-right"><strong>Policy #:</strong></Col>
                  <Col md={2} style={{ paddingLeft: 5 }}>{ ccw.nscPolicyNumber }</Col>
                  <Col md={2} className="text-right"><strong>Status Date:</strong></Col>
                  <Col md={2} style={{ paddingLeft: 5 }}>{ formatDateTime(ccw.nscPolicyStatusDate, 'YYYY-MMM-DD') }</Col>
                  <Col md={2} className="text-right"><strong>Is:</strong></Col>
                  <Col md={2} style={{ paddingLeft: 5 }}>{ ccw.nscPolicyStatus }</Col>
                </Row>
                <Row>
                  <Col md={2} className="text-right"><strong>Effective Date:</strong></Col>
                  <Col md={2} style={{ paddingLeft: 5 }}>{ formatDateTime(ccw.nscPolicyEffectiveDate, 'YYYY-MMM-DD') }</Col>
                  <Col md={2} className="text-right"><strong>Expiry Date:</strong></Col>
                  <Col md={2} style={{ paddingLeft: 5 }}>{ formatDateTime(ccw.nscPolicyExpiryDate, 'YYYY-MMM-DD') }</Col>
                  <Col md={2} className="text-right"><strong>Plate Decal #:</strong></Col>
                  <Col md={2} style={{ paddingLeft: 5 }}>{ ccw.nscPlateDecal }</Col>
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
                  <Col md={2} className="text-right"><strong>Owner:</strong></Col>
                  <Col md={6} style={{ paddingLeft: 5 }}>{ ccw.icbcRegOwnerName }</Col>
                  <Col md={2} className="text-right"><strong>Is:</strong></Col>
                  <Col md={2} style={{ paddingLeft: 5 }}>{ ccw.icbcRegOwnerStatus }</Col>
                </Row>
                <Row>
                  <Col md={2} className="text-right"><strong>Address:</strong></Col>
                  <Col md={6} style={{ paddingLeft: 5 }}>{(() => {
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
                  })()}</Col>
                  <Col md={2} className="text-right"><strong>RODL:<br />POOL:</strong></Col>
                  <Col md={2} style={{ paddingLeft: 5 }}>{ ccw.icbcRegOwnerStatus }<br />{ ccw.icbcRegOwnerRODL }</Col>
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
                  <Col md={4} className="text-right"><strong>NSC #:</strong></Col>
                  <Col md={8} style={{ paddingLeft: 5 }}>{ ccw.nscClientNum }</Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>Carrier Name:</strong></Col>
                  <Col md={8} style={{ paddingLeft: 5 }}>{ ccw.nscCarrierName }</Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>Carrier Conditions:</strong></Col>
                  <Col md={8} style={{ paddingLeft: 5 }}>{ ccw.nscCarrierConditions }</Col>
                </Row>
                <Row>
                  <Col md={4} className="text-right"><strong>Carrier Safety Rating:</strong></Col>
                  <Col md={8} style={{ paddingLeft: 5 }}>{ ccw.nscCarrierSafetyRating }</Col>
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
                      <Col md={3} className="text-right"><strong>Year:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcModelYear }</Col>
                      <Col md={3} className="text-right"><strong>GVW:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcGrossVehicleWeight }</Col>
                    </Row>
                    <Row>
                      <Col md={3} className="text-right"><strong>Vehicle Type:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcVehicleType }</Col>
                      <Col md={3} className="text-right"><strong>Make:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcMake }</Col>
                    </Row>
                    <Row>
                      <Col md={3} className="text-right"><strong>Rate Class:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcRateClass }</Col>
                      <Col md={3} className="text-right"><strong>Body:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcBody }</Col>
                    </Row>
                    <Row>
                      <Col md={3} className="text-right"><strong>CVIP Decal:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbccvipDecal }</Col>
                      <Col md={3} className="text-right"><strong>Rebuilt Status:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcRebuiltStatus }</Col>
                    </Row>
                    <Row>
                      <Col md={3} className="text-right"><strong>Fleet Unit #:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcFleetUnitNo }</Col>
                      <Col md={3} className="text-right"><strong>CVIP Expiry:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ formatDateTime(ccw.icbccvipExpiry, 'YYYY-MMM-DD') }</Col>
                    </Row>
                  </Col>
                  <Col md={6}>
                    <Row>
                      <Col md={3} className="text-right"><strong>Net Wt:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcNetWt }</Col>
                      <Col md={6}></Col>
                    </Row>
                    <Row>
                      <Col md={3} className="text-right"><strong>Model:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcModel }</Col>
                      <Col md={3} className="text-right"><strong>Colour:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcColour }</Col>
                    </Row>
                    <Row>
                      <Col md={3} className="text-right"><strong>Fuel:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcFuel }</Col>
                      <Col md={6}></Col>
                    </Row>
                    <Row>
                      <Col md={3} className="text-right"><strong>Seating Capacity:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcSeatingCapacity }</Col>
                      <Col md={6}></Col>
                    </Row>
                    <Row>
                      <Col md={3} className="text-right"><strong>N&amp;O:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ ccw.icbcNotesAndOrders }</Col>
                      <Col md={3} className="text-right"><strong>Ordered On:</strong></Col>
                      <Col md={3} style={{ paddingLeft: 5 }}>{ formatDateTime(ccw.icbcOrderedOn, 'YYYY-MMM-DD') }</Col>
                    </Row>
                  </Col>
                </Row>
              </div>;
            })()}
          </Well>
        </Col>
      </Row>
    </div>;
  },
});

function mapStateToProps(state) {
  return {
    schoolBus: state.models.schoolBus,
    schoolBusAttachments: state.models.schoolBusAttachments,
    schoolBusCCW: state.models.schoolBusCCW,
    schoolBusHistories: state.models.schoolBusHistories,
    schoolBusInspections: state.models.schoolBusInspections,
    schoolBusNotes: state.models.schoolBusNotes,
  };
}

export default connect(mapStateToProps)(SchoolBusesDetail);
