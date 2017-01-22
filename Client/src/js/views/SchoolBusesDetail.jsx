import React from 'react';
import { connect } from 'react-redux';
import { Well, Row, Col  } from 'react-bootstrap';
import { Alert, Label, Button, Glyphicon, Checkbox, Table  } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';

import ColField from '../components/ColField.jsx';
import ColLabel from '../components/ColLabel.jsx';
import Spinner from '../components/Spinner.jsx';

import { formatDateTime } from '../utils/date';
import { concat, plural } from '../utils/string';

import * as Api from '../api';


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

  showNotes() {
  },

  showAttachments() {
  },

  showHistory() {
  },

  edit () {

  },

  print() {

  },

  render() {
    var bus = this.props.schoolBus;
    var ccw = this.props.schoolBusCCW;

    var daysToInspection = bus.daysToInspection;
    if (bus.isOverdue) { daysToInspection *= -1; }

    var inspectionNotice = (bus.isReinspection ? '&reg; ' : '') + (bus.isOverdue ? 'Overdue &ndash; ' : '')
      + daysToInspection + ' ' + plural(daysToInspection, 'day', 'days')
      + ' &ndash; ' + formatDateTime(bus.nextInspectionDate, 'YYYY-DD-MMM');

    var inspectionStyle = bus.isOverdue ? 'danger' : (daysToInspection <= DAYS_DUE_WARNING ? 'warning' : 'success');

    return <div id="school-buses-detail">
      <Row id="school-buses-top">
        <Col md={10}>
          <Label bsStyle={ bus.isActive ? 'success' : 'danger'}>{ bus.isActive ? 'Verified Active' : bus.status }</Label>
          <Label className={ bus.isOutOfProvince ? '' : 'hide' }>Out of Province</Label>
          <span className={ `label label-${inspectionStyle}` } dangerouslySetInnerHTML={{ __html: inspectionNotice }}></span>
          <Button title="Notes" onClick={ this.showNotes }>Notes ({ Object.keys(this.props.schoolBusNotes).length })</Button>
          <Button title="Attachments" onClick={ this.showAttachments }>Attachments ({ Object.keys(this.props.schoolBusAttachments).length })</Button>
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
            <h3>School Bus Data <span className="pull-right"><Button title="edit" bsSize="small"><Glyphicon glyph="edit" /></Button></span></h3>
            {(() => {
              if (this.state.loadingSchoolBus) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

              return <div id="school-buses-data">
                <Row>
                  <ColLabel md={4}>Area</ColLabel>
                  <ColField md={8}>{ bus.serviceAreaName }</ColField>
                </Row>
                <Row>
                  <ColLabel md={4}>Inspector</ColLabel>
                  <ColField md={8}>{ bus.inspectorName }</ColField>
                </Row>
                <Row>
                  <ColLabel md={4}>Home Terminal</ColLabel>
                  <ColField md={8}>{ bus.homeTerminalAddrs }</ColField>
                </Row>
                <Row>
                  <ColLabel md={4}>City, Prov</ColLabel>
                  <ColField md={8}>{ bus.homeTerminalCityProv }</ColField>
                </Row>
                <Row>
                  <ColLabel md={4}>Postal Code</ColLabel>
                  <ColField md={8}>{ bus.homeTerminalPostalCode }</ColField>
                </Row>
                <Row>
                  <ColLabel md={4}>Desription</ColLabel>
                  <ColField md={8}>{ bus.homeTerminalComment }</ColField>
                </Row>
                <Row>
                  <ColLabel md={4}>Permit Class</ColLabel>
                  <ColField md={8}>{ bus.schoolBusClass }</ColField>
                </Row>
                <Row>
                  <ColLabel md={4}>Body Type</ColLabel>
                  <ColField md={8}>{ bus.schoolBusBodyType }</ColField>
                </Row>
                <Row>
                  <ColLabel md={4}>Restrictions</ColLabel>
                  <ColField md={8}>{ bus.restrictions }</ColField>
                </Row>
                <Row>
                  <ColLabel md={4}>School District</ColLabel>
                  <ColField md={8}>{ bus.districtName }</ColField>
                </Row>
                <Row>
                  <ColLabel md={4}>Independent School</ColLabel>
                  <ColField md={1}><Checkbox checked={ bus.isIndependentSchool } disabled></Checkbox></ColField>
                  <ColField md={6}>{ bus.nameOfIndependentSchool }</ColField>
                </Row>
                <Row>
                  <ColLabel md={4}>Unit Number</ColLabel>
                  <ColField md={8}>{ bus.schoolBusUnitNumber }</ColField>
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
                  <ColLabel md={2}>Policy #</ColLabel>
                  <ColField md={2}>{ ccw.nscPolicyNumber }</ColField>
                  <ColLabel md={2}>Status Date</ColLabel>
                  <ColField md={2}>{ formatDateTime(ccw.nscPolicyStatusDate, 'YYYY-MMM-DD') }</ColField>
                  <ColLabel md={2}>Is</ColLabel>
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
                  <ColLabel md={2}>RODL<br />POOL</ColLabel>
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
