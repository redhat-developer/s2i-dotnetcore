import React from 'react';
import Promise from 'bluebird';
import { connect } from 'react-redux';
import { Modal, Grid, Row, Col } from 'react-bootstrap';
import { Radio, Button, Glyphicon } from 'react-bootstrap';
import { Form, FormGroup, FormControl, HelpBlock, ControlLabel } from 'react-bootstrap';

import _ from 'lodash';

import Confirm from '../../components/Confirm.jsx';
import OverlayTrigger from '../../components/OverlayTrigger.jsx';
import Spinner from '../../components/Spinner.jsx';

import * as Api from '../../api';

import { isBlank } from '../../utils/string';

/*

Changing the School Bus Owner is related to
Moving a School Bus - SB-133. You can't add a
new School Bus Owner at this point.

*/


const STATUS_ACTIVE = 'Active';
const STATUS_ARCHIVED = 'Archived';

const PERMIT_CLASS_TYPE_1 = 'Type 1: Yellow and Black School Bus';
const PERMIT_CLASS_TYPE_2 = 'Type 2: Special Activity Bus';
const PERMIT_CLASS_TYPE_3 = 'Type 3: Special Vehicle';

const BODY_TYPES = [ 'Yellow and Black', 'Bus', 'Coach Bus', 'Mobility Aid', 'Van', 'Other' ];

const RESTRICTION_NON_SCHEDULED_ONLY = 'Non-Scheduled Transportation Only';

var SchoolBusesEditDialog = React.createClass({
  propTypes: {
    schoolBus: React.PropTypes.object,
    districts: React.PropTypes.object,
    inspectors: React.PropTypes.object,
    cities: React.PropTypes.object,
    schoolDistricts: React.PropTypes.object,
    owners: React.PropTypes.object,

    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
  },

  getInitialState() {
    return {
      loading: false,

      status: this.props.schoolBus.status || STATUS_ACTIVE,
      ownerId: this.props.schoolBus.schoolBusOwner ? this.props.schoolBus.schoolBusOwner.id : '',
      districtId: this.props.schoolBus.district ? this.props.schoolBus.district.id : '',
      inspectorId: this.props.schoolBus.inspector ? this.props.schoolBus.inspector.id : '',

      address1: this.props.schoolBus.homeTerminalAddress1 || '',
      address2: this.props.schoolBus.homeTerminalAddress2 || '',
      cityId: this.props.schoolBus.homeTerminalCity ? this.props.schoolBus.homeTerminalCity.id : '',
      province: this.props.schoolBus.homeTerminalProvince || 'BC',
      postalCode: this.props.schoolBus.homeTerminalPostalCode || '',
      description: this.props.schoolBus.homeTerminalComment || '',

      permitClassCode: this.props.schoolBus.permitClassCode || PERMIT_CLASS_TYPE_1,
      bodyTypeCode: this.props.schoolBus.bodyTypeCode || BODY_TYPES[0],
      restrictionsText: this.props.schoolBus.restrictionsText || '',
      disableRestrictionsText: true,

      schoolDistrictId: this.props.schoolBus.schoolDistrict ? this.props.schoolBus.schoolDistrict.id : '',
      isIndependentSchool: this.props.schoolBus.isIndependentSchool || false,
      independentSchoolName: this.props.schoolBus.independentSchoolName || '',

      unitNumber: this.props.schoolBus.unitNumber || '',
      schoolBusSeatingCapacity: this.props.schoolBus.schoolBusSeatingCapacity || 0,
      mobilityAidCapacity: this.props.schoolBus.mobilityAidCapacity || 0,

      schoolBusSeatingCapacityError: false,
      mobilityAidCapacityError: false,
    };
  },

  componentDidMount() {
    this.setState({ loading: true });

    var inspectorsPromise = Api.getInspectors();
    var ownersPromise = Api.getOwners();

    Promise.all([inspectorsPromise, ownersPromise]).then(() => {
      this.setState({ loading: false });
      this.input.focus();
    });
  },

  statusChanged(e) {
    this.setState({ status: e.target.value });
  },

  ownerIdChanged(e) {
    this.setState({ ownerId: e.target.value });
  },

  districtIdChanged(e) {
    this.setState({ districtId: e.target.value });
  },

  inspectorIdChanged(e) {
    this.setState({ inspectorId: e.target.value });
  },

  address1Changed(e) {
    this.setState({ address1: e.target.value });
  },

  address2Changed(e) {
    this.setState({ address2: e.target.value });
  },

  cityIdChanged(e) {
    this.setState({ cityId: e.target.value });
  },

  postalCodeChanged(e) {
    this.setState({ postalCode: e.target.value });
  },

  descriptionChanged(e) {
    this.setState({ description: e.target.value });
  },

  permitClassCodeChanged(e) {
    var permitClassCode = e.target.value;
    var restriction = '';

    if (permitClassCode === PERMIT_CLASS_TYPE_2) {
      restriction = RESTRICTION_NON_SCHEDULED_ONLY;
    }

    this.setState({
      permitClassCode: permitClassCode,
      restrictionsText: restriction,
    });
  },

  bodyTypeCodeChanged(e) {
    this.setState({ bodyTypeCode: e.target.value });
  },

  restrictionsTextChanged(e) {
    this.setState({ restrictionsText: e.target.value });
  },

  schoolDistrictIdChanged(e) {
    this.setState({ schoolDistrictId: e.target.value });
  },

  isIndependentSchoolChanged(value) {
    this.setState({ isIndependentSchool: value });
  },

  independentSchoolNameChanged(e) {
    this.setState({ independentSchoolName: e.target.value });
  },

  unitNumberChanged(e) {
    this.setState({ unitNumber: e.target.value });
  },

  schoolBusSeatingCapacityChanged(e) {
    this.setState({ schoolBusSeatingCapacity: e.target.value });
  },

  mobilityAidCapacityChanged(e) {
    this.setState({ mobilityAidCapacity: e.target.value });
  },

  editRestrictionsText() {
    this.setState({ disableRestrictionsText: false });
  },

  save() {
    if (isBlank(this.state.schoolBusSeatingCapacity)) {
      this.setState({ schoolBusSeatingCapacityError: 'Seating capacity is required' });
    } else if (isBlank(this.state.mobilityAidCapacity)) {
      this.setState({ mobilityAidCapacityError: 'Mobility aid capacity is required' });
    } else {
      this.props.onSave();
      // this.props.onSave({ ...this.props.schoolBus, ...{
      //   name: this.state.name,
      //   isDefault: this.state.isDefault,
      // }});
    }
  },

  render() {
    var districts = _.sortBy(this.props.districts, 'name');
    var inspectors = _.sortBy(this.props.inspectors, 'name');
    var cities = _.sortBy(this.props.cities, 'name');
    var schoolDistricts = _.sortBy(this.props.schoolDistricts, 'name');
    var owners = _.sortBy(this.props.owners, 'name');

    return <Modal id="school-buses-edit" show={ this.props.show } bsSize="large" onHide={ this.props.onClose }>
      <Modal.Header closeButton>
        <Modal.Title>
          <strong>School Bus
            &nbsp;<small>Regi: { this.props.schoolBus.icbcRegistrationNumber }
            &nbsp;Plate: { this.props.schoolBus.licencePlateNumber }
            &nbsp;VIN: { this.props.schoolBus.vehicleIdentificationNumber }</small>
          </strong>
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {(() => {
          if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

          return <Form>
            <Grid fluid>
              <Row>
                <Col md={3}>
                  <FormGroup>
                    <ControlLabel>Status</ControlLabel>
                    <FormControl componentClass="select" value={ this.state.status } onChange={ this.statusChanged }>
                      <option key={ STATUS_ACTIVE } value={ STATUS_ACTIVE }>{ STATUS_ACTIVE }</option>
                      <option key={ STATUS_ARCHIVED } value={ STATUS_ARCHIVED }>{ STATUS_ARCHIVED }</option>
                    </FormControl>
                  </FormGroup>
                </Col>
                <Col md={3}>
                  <FormGroup>
                    <ControlLabel>Owner</ControlLabel>
                    <FormControl componentClass="select" value={ this.state.ownerId } onChange={ this.ownerIdChanged }>
                      {
                        owners.map((owner) => {
                          return <option key={ owner.id } value={ owner.id }>{ owner.name }</option>;
                        })
                      }
                    </FormControl>
                  </FormGroup>
                </Col>
                <Col md={3}>
                  <FormGroup>
                    <ControlLabel>District</ControlLabel>
                    <FormControl componentClass="select" value={ this.state.districtId || '' } onChange={ this.districtIdChanged }>
                      <option value=""></option>
                      {
                        districts.map((district) => {
                          return <option key={ district.id } value={ district.id }>{ district.name }</option>;
                        })
                      }
                    </FormControl>
                  </FormGroup>
                </Col>
                <Col md={3}>
                  <FormGroup>
                    <ControlLabel>Inspector</ControlLabel>
                    <FormControl componentClass="select" value={ this.state.inspectorId || '' } onChange={ this.inspectorIdChanged }>
                      <option value=""></option>
                      {
                        inspectors.map((inspector) => {
                          return <option key={ inspector.id } value={ inspector.id }>{ inspector.name }</option>;
                        })
                      }
                    </FormControl>
                  </FormGroup>
                </Col>
              </Row>
              <Row>
                <Col md={3}>
                  <FormGroup>
                    <ControlLabel>Home Terminal Address 1</ControlLabel>
                    <FormControl type="text" defaultValue={ this.state.address1 } onChange={ this.address1Changed } inputRef={ ref => { this.input = ref; }} />
                  </FormGroup>
                </Col>
                <Col md={3}>
                  <FormGroup>
                    <ControlLabel>Address 2</ControlLabel>
                    <FormControl type="text" defaultValue={ this.state.address2 } onChange={ this.address2Changed } />
                  </FormGroup>
                </Col>
                <Col md={3}>
                  <FormGroup>
                    <ControlLabel>City</ControlLabel>
                    <FormControl componentClass="select" value={ this.state.cityId || '' } onChange={ this.cityIdChanged }>
                      <option value=""></option>
                      {
                        cities.map((city) => {
                          return <option key={ city.id } value={ city.id }>{ city.name }</option>;
                        })
                      }
                    </FormControl>
                  </FormGroup>
                </Col>
                <Col md={1}>
                  <FormGroup>
                    <ControlLabel>Province</ControlLabel>
                    <FormControl.Static>{ this.state.province }</FormControl.Static>
                  </FormGroup>
                </Col>
                <Col md={2}>
                  <FormGroup>
                    <ControlLabel>Postal Code</ControlLabel>
                    <FormControl type="text" defaultValue={ this.state.postalCode } onChange={ this.postalCodeChanged } />
                  </FormGroup>
                </Col>
              </Row>
              <Row>
                <Col md={12}>
                  <FormGroup>
                    <ControlLabel>Home Terminal Description</ControlLabel>
                    <FormControl componentClass="textarea" defaultValue={ this.state.description } onChange={ this.descriptionChanged } />
                  </FormGroup>
                </Col>
              </Row>
              <Row>
                <Col md={5}>
                  <Row>
                    <Col>
                      <FormGroup>
                        <ControlLabel>Permit Class</ControlLabel>
                        <FormControl componentClass="select" value={ this.state.permitClassCode } onChange={ this.permitClassCodeChanged }>
                          <option key={ PERMIT_CLASS_TYPE_1 } value={ PERMIT_CLASS_TYPE_1 }>{ PERMIT_CLASS_TYPE_1 }</option>;
                          <option key={ PERMIT_CLASS_TYPE_2 } value={ PERMIT_CLASS_TYPE_2 }>{ PERMIT_CLASS_TYPE_2 }</option>;
                          <option key={ PERMIT_CLASS_TYPE_3 } value={ PERMIT_CLASS_TYPE_3 }>{ PERMIT_CLASS_TYPE_3 }</option>;
                        </FormControl>
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col>
                      <FormGroup>
                        <ControlLabel>Body Type</ControlLabel>
                        <FormControl componentClass="select" value={ this.state.bodyTypeCode } onChange={ this.bodyTypeCodeChanged }>
                          {
                            BODY_TYPES.map((bodyType) => {
                              return <option key={ bodyType } value={ bodyType }>{ bodyType }</option>;
                            })
                          }
                        </FormControl>
                      </FormGroup>
                    </Col>
                  </Row>
                </Col>
                <Col md={7}>
                  <FormGroup>
                    <div>
                      <ControlLabel>Restrictions</ControlLabel>
                      <span className="pull-right">
                        <OverlayTrigger trigger="click" placement="top" rootClose
                          overlay={
                            <Confirm title="Edit Permit Restrictions Text?" onConfirm={ this.editRestrictionsText }>
                              <div>The permit restrictions text should be changed only in rare circumstances. Are you sure?</div>
                            </Confirm>
                          }>
                          <Button title="editRestrictions" bsSize="xsmall"><Glyphicon glyph="edit" /></Button>
                        </OverlayTrigger>
                      </span>
                    </div>
                    <FormControl componentClass="textarea" rows="4" value={ this.state.restrictionsText } onChange={ this.restrictionsTextChanged } disabled={ this.state.disableRestrictionsText } />
                  </FormGroup>
                </Col>
              </Row>
              <Row>
                <Col md={3}>
                  <FormGroup>
                    <ControlLabel>School District</ControlLabel>
                    <FormControl componentClass="select" value={ this.state.schoolDistrictId || '' } onChange={ this.schoolDistrictIdChanged }>
                      <option value=""></option>
                      {
                        schoolDistricts.map((sd) => {
                          return <option key={ sd.id } value={ sd.id }>{ sd.name }</option>;
                        })
                      }
                    </FormControl>
                  </FormGroup>
                </Col>
                <Col md={2}>
                  <FormGroup>
                    <ControlLabel>Independent School</ControlLabel>
                    <FormControl componentClass="div">
                      <Radio inline onChange={ this.isIndependentSchoolChanged.bind(this, true) } checked={ this.state.isIndependentSchool }>Yes</Radio>
                      { ' ' }
                      <Radio inline onChange={ this.isIndependentSchoolChanged.bind(this, false) } checked={ !this.state.isIndependentSchool }>No</Radio>
                    </FormControl>
                  </FormGroup>
                </Col>
                <Col md={5}>
                  <FormGroup>
                    <ControlLabel>Independent School Name</ControlLabel>
                    <FormControl type="text" defaultValue={ this.state.independentSchoolName } onChange={ this.independentSchoolNameChanged } disabled= { !this.state.isIndependentSchool }/>
                  </FormGroup>
                </Col>
              </Row>
              <Row>
                <Col md={3}>
                  <FormGroup>
                    <ControlLabel>Unit Number</ControlLabel>
                    <FormControl type="text" defaultValue={ this.state.unitNumber } onChange={ this.unitNumberChanged } />
                  </FormGroup>
                </Col>
                <Col md={2}>
                  <FormGroup validationState={ this.state.schoolBusSeatingCapacityError ? 'error' : null }>
                    <ControlLabel>Seating Capacity <sup>*</sup></ControlLabel>
                    <FormControl type="number" defaultValue={ this.state.schoolBusSeatingCapacity } onChange={ this.schoolBusSeatingCapacityChanged } />
                    <HelpBlock>{ this.state.schoolBusSeatingCapacityError }</HelpBlock>
                  </FormGroup>
                </Col>
                <Col md={3}>
                  <FormGroup validationState={ this.state.mobilityAidCapacityError ? 'error' : null }>
                    <ControlLabel>Mobility Aid Capacity <sup>*</sup></ControlLabel>
                    <FormControl type="number" defaultValue={ this.state.mobilityAidCapacity } onChange={ this.mobilityAidCapacityChanged } />
                    <HelpBlock>{ this.state.mobilityAidCapacityError }</HelpBlock>
                  </FormGroup>
                </Col>
              </Row>
            </Grid>
          </Form>;
        })()}
      </Modal.Body>
      <Modal.Footer>
        <Button onClick={ this.props.onClose }>Close</Button>
        <Button bsStyle="primary" onClick={ this.save }>Save</Button>
      </Modal.Footer>
    </Modal>;
  },
});

function mapStateToProps(state) {
  return {
    schoolBus: state.models.schoolBus,
    districts: state.lookups.districts,
    inspectors: state.models.inspectors,
    cities: state.lookups.cities,
    schoolDistricts: state.lookups.schoolDistricts,
    owners: state.models.owners,
  };
}

export default connect(mapStateToProps)(SchoolBusesEditDialog);
