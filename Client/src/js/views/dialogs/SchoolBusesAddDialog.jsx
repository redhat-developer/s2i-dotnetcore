import React from 'react';

import { connect } from 'react-redux';

import { Row, Col, Well } from 'react-bootstrap';
import { ButtonToolbar, ButtonGroup, Button, Glyphicon } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';

import * as Action from '../../actionTypes';
import * as Api from '../../api';
import * as Constant from '../../constants';
import store from '../../store';

import ColDisplay from '../../components/ColDisplay.jsx';
import ModalDialog from '../../components/ModalDialog.jsx';
import KeySearchControl from '../../components/KeySearchControl.jsx';
import Spinner from '../../components/Spinner.jsx';

import { formatDateTime } from '../../utils/date';
import { concat } from '../../utils/string';


var SchoolBusAddDialog = React.createClass({
  propTypes: {
    schoolBuses: React.PropTypes.object,
    schoolBusCCW: React.PropTypes.object,
    search: React.PropTypes.object,

    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
  },

  getInitialState() {
    return {
      loading: 0,

      search: {
        keySearchField: this.props.search.keySearchField,
        keySearchText: this.props.search.keySearchText,
        keySearchParams: this.props.search.keySearchParams,
      },

      busInSystemId: 0,

      ccwFound: false,
      ccwError: false,
    };
  },

  updateSearchState(state) {
    this.setState({
      search: { ...this.state.search, ...state },
      // Clear error when they change field
      ccwError: false,
    }, () =>{
      store.dispatch({ type: Action.UPDATE_CCW_SEARCH, schoolBusesCCW: this.state.search });
    });
  },

  fetch() {
    if (this.state.search.keySearchParams) {
      this.setState({
        // Need to count the "loads" because we've got more than one call and
        // don't want to stop the spinner prematurely.
        loading: 1,
        busInSystemId: 0,
        ccwFound: false,
        ccwError: false,
      });
      Api.searchSchoolBuses(this.state.search.keySearchParams).then(() => {
        if (_.keys(this.props.schoolBuses).length > 0) {
          this.setState({
            busInSystemId: _.first(_.keys(this.props.schoolBuses)),
          });
        } else {
          this.setState({ loading: this.state.loading + 1 });
          return Api.searchCCW(this.state.search.keySearchParams).then(() => {
            var found = this.props.schoolBusCCW.icbcRegistrationNumber ? true : false;
            this.setState({
              ccwFound: found,
              ccwError: !found,
            });
          }).catch((/* err */) => {
            // CCW will return a 404 if it doesn't find the vehicle!

            // Suppress showing the error in the top header.
            store.dispatch({ type: Action.REQUESTS_CLEAR });

            // Show generic not found message. Can be more specific later
            // (eg. timed out, service unavailable, etc.) if necessary.
            this.setState({
              ccwFound: false,
              ccwError: true,
            });
          }).finally(() => {
            this.setState({ loading: this.state.loading - 1 });
          });
        }
      }).finally(() => {
        this.setState({ loading: this.state.loading - 1 });
      });
    }
  },

  render() {
    return <ModalDialog id="school-buses-add" show={ this.props.show } onClose={ this.props.onClose }
      title={ <strong>Add School Bus</strong> }
      footer={
        this.state.ccwFound &&
          <LinkContainer to={{ pathname: `${ Constant.BUSES_PATHNAME }/0` }}>
            <Button title="add bus">Continue</Button>
          </LinkContainer>
      }
    >
      {(() => {
        return <div>
          <Row>
            <ButtonToolbar>
              <KeySearchControl id="school-buses-key-search" search={ this.state.search } updateState={ this.updateSearchState } suppressPlate />
              <ButtonGroup>
                <Button id="close-button" onClick={ this.props.onClose }>Close</Button>
                <Button id="search-button" bsStyle="primary" onClick={ this.fetch }>Search</Button>
              </ButtonGroup>
            </ButtonToolbar>
          </Row>
          {(() => {
            if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

            if (this.state.busInSystemId) {
              return <div>
                <Row className="has-error">
                  <span>This bus is already in the Inspection Tracking System.</span>
                  <LinkContainer to={{ pathname: `${ Constant.BUSES_PATHNAME }/${ this.state.busInSystemId }` }}>
                    <Button title="view bus" bsSize="xsmall"><Glyphicon glyph="edit" /></Button>
                  </LinkContainer>
                </Row>
              </div>;
            }

            if (this.state.ccwError) {
              return <div>
                <Row className="has-error">
                  <span>Could not find this { this.state.search.keySearchField } in the ICBC repository of vehicles.</span>
                </Row>
              </div>;
            }

            if (this.state.ccwFound) {
              var ccw = this.props.schoolBusCCW;

              return <div id="school-buses-ccw">
                <Row id="school-buses-top">
                  <ColDisplay label="Registration">{ ccw.icbcRegistrationNumber || <span>&nbsp;</span> }</ColDisplay>
                  <ColDisplay label="Plate">{ ccw.icbcLicencePlateNumber || <span>&nbsp;</span> }</ColDisplay>
                  <ColDisplay label="VIN">{ ccw.icbcVehicleIdentificationNumber || <span>&nbsp;</span> }</ColDisplay>
                </Row>
                <Row>
                  <Well>
                    <h3>ICBC Registered Owner</h3>
                    {(() => {
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
                </Row>
                <Row>
                  <Well>
                    <h3>ICBC Vehicle Data</h3>
                    {(() => {
                      return <div id="school-buses-icbc-vehicle">
                       <Row>
                          <ColDisplay md={6} label="Year">{ ccw.icbcModelYear }</ColDisplay>
                          <ColDisplay md={6} label="GVW">{ ccw.icbcGrossVehicleWeight }</ColDisplay>
                        </Row>
                        <Row>
                          <ColDisplay md={6} label="Net Wt">{ ccw.icbcNetWt }</ColDisplay>
                          <Col md={6}></Col>
                        </Row>
                        <Row>
                          <ColDisplay md={6} label="Vehicle Type">{ ccw.icbcVehicleType }</ColDisplay>
                          <ColDisplay md={6} label="Make">{ ccw.icbcMake }</ColDisplay>
                        </Row>
                        <Row>
                          <ColDisplay md={6} label="Model">{ ccw.icbcModel }</ColDisplay>
                          <ColDisplay md={6} label="Colour">{ ccw.icbcColour }</ColDisplay>
                        </Row>
                        <Row>
                          <ColDisplay md={6} label="Rate Class">{ ccw.icbcRateClass }</ColDisplay>
                          <ColDisplay md={6} label="Body">{ ccw.icbcBody }</ColDisplay>
                        </Row>
                        <Row>
                          <ColDisplay md={6} label="Fuel">{ ccw.icbcFuel }</ColDisplay>
                          <Col md={6}></Col>
                        </Row>
                        <Row>
                          <ColDisplay md={6} label="CVIP Decal">{ ccw.icbccvipDecal }</ColDisplay>
                          <ColDisplay md={6} label="Rebuilt Status">{ ccw.icbcRebuiltStatus }</ColDisplay>
                        </Row>
                        <Row>
                          <ColDisplay md={6} label="Seating Capacity">{ ccw.icbcSeatingCapacity }</ColDisplay>
                          <Col md={6}></Col>
                        </Row>
                        <Row>
                          <ColDisplay md={6} label="Fleet Unit #">{ ccw.icbcFleetUnitNo }</ColDisplay>
                          <ColDisplay md={6} label="CVIP Expiry">{ formatDateTime(ccw.icbccvipExpiry, Constant.DATE_SHORT_MONTH_DAY_YEAR) }</ColDisplay>
                        </Row>
                        <Row>
                          <ColDisplay md={6} label="N&amp;O">{ ccw.icbcNotesAndOrders }</ColDisplay>
                          <ColDisplay md={6} label="Ordered On">{ formatDateTime(ccw.icbcOrderedOn, Constant.DATE_SHORT_MONTH_DAY_YEAR) }</ColDisplay>
                        </Row>
                      </div>;
                    })()}
                  </Well>
                </Row>
                { ccw.dateFetched &&
                  <Row>
                    <Col md={12}>
                      <span id="school-buses-ccw-fetched">ICBC data last fetched on { formatDateTime(ccw.dateFetched, Constant.DATE_TIME_READABLE) }</span>
                    </Col>
                  </Row>
                }
              </div>;
            }
          })()}
        </div>;
      })()}
    </ModalDialog>;
  },
});

function mapStateToProps(state) {
  return {
    schoolBuses: state.models.schoolBuses,
    schoolBusCCW: state.models.schoolBusCCW,
    search: state.search.schoolBusesCCW,
  };
}

export default connect(mapStateToProps)(SchoolBusAddDialog);
