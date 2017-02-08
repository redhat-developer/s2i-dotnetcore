import React from 'react';

import { connect } from 'react-redux';

import { Row, Col, Well } from 'react-bootstrap';
import { ButtonToolbar, ButtonGroup, Button, Glyphicon } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';

import * as Action from '../../actionTypes';
import * as Api from '../../api';
import store from '../../store';

import ColField from '../../components/ColField.jsx';
import ColLabel from '../../components/ColLabel.jsx';
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
      loading: false,

      search: {
        keySearchField: this.props.search.keySearchField,
        keySearchText: this.props.search.keySearchText,
        keySearchParams: this.props.search.keySearchParams,
      },

      busInSystemId: 0,
      ccwFound: false,
      ccwNotFound: false,
    };
  },

  updateSearchState(state, callback) {
    this.setState({ search: { ...this.state.search, ...state }}, () =>{
      store.dispatch({ type: Action.UPDATE_CCW_SEARCH, schoolBusesCCW: this.state.search });
      if (callback) { callback(); }
    });
  },

  fetch() {
    if (this.state.search.keySearchParams) {
      this.setState({
        loading: true,
        busInSystemId: 0,
        ccwFound: false,
        ccwNotFound: false,
      });
      Api.searchSchoolBuses(this.state.search.keySearchParams).then(() => {
        if (_.keys(this.props.schoolBuses).length > 0) {
          this.setState({
            busInSystemId: _.first(_.keys(this.props.schoolBuses)),
          });
        } else {
          this.setState({ loading: true });
          Api.searchCCW(this.state.search.keySearchParams).then(() => {
            var found = this.props.schoolBusCCW.icbcRegistrationNumber ? true : false;
            this.setState({
              ccwFound: found,
              ccwNotFound: !found,
            });
          }).finally(() => {
            this.setState({ loading: false });
          });
        }
      }).finally(() => {
        this.setState({ loading: false });
      });
    }
  },

  render() {
    return <ModalDialog id="school-buses-add" show={ this.props.show } onClose={ this.props.onClose }
      title={ <strong>Add School Bus</strong> }
      footer={
        this.state.ccwFound &&
          <LinkContainer to={{ pathname: 'school-buses/0' }}>
            <Button title="add bus">Continue</Button>
          </LinkContainer>
      }
    >
      {(() => {
        return <div>
          <Row>
            <ButtonToolbar>
              <KeySearchControl id="school-buses-key-search" search={ this.state.search } updateState={ this.updateSearchState } />
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
                  <LinkContainer to={{ pathname: 'school-buses/' + this.state.busInSystemId }}>
                    <Button title="view bus" bsSize="xsmall"><Glyphicon glyph="edit" /></Button>
                  </LinkContainer>
                </Row>
              </div>;
            }

            if (this.state.ccwNotFound) {
              return <div>
                <Row className="has-error">
                  <span>Could not find this vehicle in the ICBC CCW system.</span>
                </Row>
              </div>;
            }

            if (this.state.ccwFound) {
              var ccw = this.props.schoolBusCCW;

              return <div id="school-bus-ccw">
                <Row>
                  <Well>
                    <h3>ICBC Registered Owner</h3>
                    {(() => {
                      var city = concat(ccw.icbcRegOwnerCity, ccw.icbcRegOwnerProv);
                      city = concat(city, ccw.icbcRegOwnerPostalCode);

                      return <div id="school-buses-icbc-owner">
                        <Row>
                          <ColLabel md={2}>Owner</ColLabel>
                          <ColField md={6}>{ ccw.icbcRegOwnerName }</ColField>
                          <ColLabel md={2}>Status Is</ColLabel>
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
                          <ColField md={2}>{ ccw.icbcRegOwnerRODL }<br />{ ccw.icbcRegOwnerPODL }</ColField>
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
                      </div>;
                    })()}
                  </Well>
                </Row>
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
