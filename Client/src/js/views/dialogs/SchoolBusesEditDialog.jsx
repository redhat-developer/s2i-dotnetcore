import React from 'react';

import { connect } from 'react-redux';

import { Grid, Row, Col } from 'react-bootstrap';
import { Radio, Button, Glyphicon } from 'react-bootstrap';
import { Form, FormControl, FormGroup, HelpBlock, ControlLabel } from 'react-bootstrap';

import _ from 'lodash';
import Promise from 'bluebird';

import * as Api from '../../api';

import Confirm from '../../components/Confirm.jsx';
import EditDialog from '../../components/EditDialog.jsx';
import FormInputControl from '../../components/FormInputControl.jsx';
import OverlayTrigger from '../../components/OverlayTrigger.jsx';
import Spinner from '../../components/Spinner.jsx';

import { isBlank } from '../../utils/string';


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
      changed: false,

      isNew: this.props.schoolBus.id === '',

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

  updateState(state, callback) {
    this.setState(state, callback);
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

  isIndependentSchoolChanged(value) {
    this.setState({
      isIndependentSchool: value,
      independentSchoolName: value ? this.state.independentSchoolName : '',
    });
  },

  editRestrictionsText() {
    this.setState({ disableRestrictionsText: false });
  },

  didChange() {
    if (this.state.status !== this.props.schoolBus.status) { return true; }
    if (this.state.ownerId !== this.props.schoolBus.schoolBusOwner.id) { return true; }
    if (this.state.districtId !== this.props.schoolBus.district.id) { return true; }
    if (this.state.inspectorId !== this.props.schoolBus.inspector.id) { return true; }

    if (this.state.address1 !== this.props.schoolBus.homeTerminalAddress1) { return true; }
    if (this.state.address2 !== this.props.schoolBus.homeTerminalAddress2) { return true; }
    if (this.state.cityId !== this.props.schoolBus.homeTerminalCity.id) { return true; }
    if (this.state.province !== this.props.schoolBus.homeTerminalProvince) { return true; }
    if (this.state.postalCode !== this.props.schoolBus.homeTerminalPostalCode) { return true; }
    if (this.state.description !== this.props.schoolBus.homeTerminalComment) { return true; }

    if (this.state.permitClassCode !== this.props.schoolBus.permitClassCode) { return true; }
    if (this.state.bodyTypeCode !== this.props.schoolBus.bodyTypeCode) { return true; }
    if (this.state.restrictionsText !== this.props.schoolBus.restrictionsText) { return true; }

    if (this.state.schoolDistrictId !== this.props.schoolBus.schoolDistrict.id) { return true; }
    if (this.state.isIndependentSchool !== this.props.schoolBus.isIndependentSchool) { return true; }
    if (this.state.independentSchoolName !== this.props.schoolBus.independentSchoolName) { return true; }

    if (this.state.unitNumber !== this.props.schoolBus.unitNumber) { return true; }
    if (this.state.schoolBusSeatingCapacity !== this.props.schoolBus.schoolBusSeatingCapacity) { return true; }
    if (this.state.mobilityAidCapacity !== this.props.schoolBus.mobilityAidCapacity) { return true; }

    return false;
  },

  isValid() {
    if (isBlank(this.state.schoolBusSeatingCapacity)) {
      this.setState({ schoolBusSeatingCapacityError: 'Seating capacity is required' });
      return false;
    }
    if (isBlank(this.state.mobilityAidCapacity)) {
      this.setState({ mobilityAidCapacityError: 'Mobility aid capacity is required' });
      return false;
    }
    return true;
  },

  onSave() {
    this.props.onSave({ ...this.props.schoolBus, ...{
      status: this.state.status,
      schoolBusOwner: { id: this.state.ownerId },
      district: { id: this.state.districtId },
      inspector: { id: this.state.inspectorId },
      homeTerminalAddress1: this.state.address1,
      homeTerminalAddress2: this.state.address2,
      homeTerminalCity: { id: this.state.cityId },
      homeTerminalProvince: this.state.province,
      homeTerminalPostalCode: this.state.postalCode,
      homeTerminalComment: this.state.description,
      permitClassCode: this.state.permitClassCode,
      bodyTypeCode: this.state.bodyTypeCode,
      restrictionsText: this.state.restrictionsText,
      schoolDistrict: { id: this.state.schoolDistrictId },
      isIndependentSchool: this.state.isIndependentSchool,
      independentSchoolName: this.state.independentSchoolName,
      unitNumber: this.state.unitNumber,
      schoolBusSeatingCapacity: this.state.schoolBusSeatingCapacity,
      mobilityAidCapacity: this.state.mobilityAidCapacity,
    }});
  },

  render() {
    var districts = _.sortBy(this.props.districts, 'name');
    var inspectors = _.sortBy(this.props.inspectors, 'name');
    var cities = _.sortBy(this.props.cities, 'name');
    var schoolDistricts = _.sortBy(this.props.schoolDistricts, 'name');
    var owners = _.sortBy(this.props.owners, 'name');

    return <EditDialog id="school-buses-edit" show={ this.props.show } bsSize="large"
      onClose={ this.props.onClose } onSave={ this.onSave } didChange={ this.didChange } isValid={ this.isValid }
      title= {
        <strong>School Bus
          <span>Regi: <small>{ this.props.schoolBus.icbcRegistrationNumber }</small></span>
          <span>Plate: <small>{ this.props.schoolBus.licencePlateNumber }</small></span>
          <span>VIN: <small>{ this.props.schoolBus.vehicleIdentificationNumber }</small></span>
        </strong>
      }>
      {(() => {
        if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

        return <Form>
          <Grid fluid>
            <Row>
              <Col md={3}>
                <FormGroup controlId="status">
                  <ControlLabel>Status</ControlLabel>
                  <FormInputControl componentClass="select" value={ this.state.status } updateState={ this.updateState }>
                    <option key={ STATUS_ACTIVE } value={ STATUS_ACTIVE }>{ STATUS_ACTIVE }</option>
                    <option key={ STATUS_ARCHIVED } value={ STATUS_ARCHIVED }>{ STATUS_ARCHIVED }</option>
                  </FormInputControl>
                </FormGroup>
              </Col>
              <Col md={3}>
                <FormGroup controlId="ownerId">
                  <ControlLabel>Owner</ControlLabel>
                  <FormInputControl componentClass="select" value={ this.state.ownerId } updateState={ this.updateState } disabled={ this.state.isNew }>
                    {
                      owners.map((owner) => {
                        return <option key={ owner.id } value={ owner.id }>{ owner.name }</option>;
                      })
                    }
                  </FormInputControl>
                </FormGroup>
              </Col>
              <Col md={3}>
                <FormGroup controlId="districtId">
                  <ControlLabel>District</ControlLabel>
                  <FormInputControl componentClass="select" value={ this.state.districtId || '' } updateState={ this.updateState }>
                    <option value=""></option>
                    {
                      districts.map((district) => {
                        return <option key={ district.id } value={ district.id }>{ district.name }</option>;
                      })
                    }
                  </FormInputControl>
                </FormGroup>
              </Col>
              <Col md={3}>
                <FormGroup controlId="inspectorId">
                  <ControlLabel>Inspector</ControlLabel>
                  <FormInputControl componentClass="select" value={ this.state.inspectorId || '' } updateState={ this.updateState }>
                    <option value=""></option>
                    {
                      inspectors.map((inspector) => {
                        return <option key={ inspector.id } value={ inspector.id }>{ inspector.name }</option>;
                      })
                    }
                  </FormInputControl>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col md={3}>
                <FormGroup controlId="address1">
                  <ControlLabel>Home Terminal Address 1</ControlLabel>
                  <FormInputControl type="text" defaultValue={ this.state.address1 } updateState={ this.updateState } inputRef={ ref => { this.input = ref; }} />
                </FormGroup>
              </Col>
              <Col md={3}>
                <FormGroup controlId="address2">
                  <ControlLabel>Address 2</ControlLabel>
                  <FormInputControl type="text" defaultValue={ this.state.address2 } updateState={ this.updateState } />
                </FormGroup>
              </Col>
              <Col md={3}>
                <FormGroup controlId="cityId">
                  <ControlLabel>City</ControlLabel>
                  <FormInputControl componentClass="select" value={ this.state.cityId || '' } updateState={ this.updateState }>
                    <option value=""></option>
                    {
                      cities.map((city) => {
                        return <option key={ city.id } value={ city.id }>{ city.name }</option>;
                      })
                    }
                  </FormInputControl>
                </FormGroup>
              </Col>
              <Col md={1}>
                <FormGroup controlId="province">
                  <ControlLabel>Province</ControlLabel>
                  <FormControl.Static>{ this.state.province }</FormControl.Static>
                </FormGroup>
              </Col>
              <Col md={2}>
                <FormGroup controlId="postalCode">
                  <ControlLabel>Postal Code</ControlLabel>
                  <FormInputControl type="text" defaultValue={ this.state.postalCode } updateState={ this.updateState } />
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col md={12}>
                <FormGroup controlId="description">
                  <ControlLabel>Home Terminal Description</ControlLabel>
                  <FormInputControl componentClass="textarea" defaultValue={ this.state.description } updateState={ this.updateState } />
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col md={5}>
                <Row>
                  <Col>
                    <FormGroup controlId="permitClassCode">
                      <ControlLabel>Permit Class</ControlLabel>
                      <FormInputControl componentClass="select" value={ this.state.permitClassCode } onChange={ this.permitClassCodeChanged }>
                        <option key={ PERMIT_CLASS_TYPE_1 } value={ PERMIT_CLASS_TYPE_1 }>{ PERMIT_CLASS_TYPE_1 }</option>;
                        <option key={ PERMIT_CLASS_TYPE_2 } value={ PERMIT_CLASS_TYPE_2 }>{ PERMIT_CLASS_TYPE_2 }</option>;
                        <option key={ PERMIT_CLASS_TYPE_3 } value={ PERMIT_CLASS_TYPE_3 }>{ PERMIT_CLASS_TYPE_3 }</option>;
                      </FormInputControl>
                    </FormGroup>
                  </Col>
                </Row>
                <Row>
                  <Col>
                    <FormGroup controlId="bodyTypeCode">
                      <ControlLabel>Body Type</ControlLabel>
                      <FormInputControl componentClass="select" value={ this.state.bodyTypeCode } updateState={ this.updateState }>
                        {
                          BODY_TYPES.map((bodyType) => {
                            return <option key={ bodyType } value={ bodyType }>{ bodyType }</option>;
                          })
                        }
                      </FormInputControl>
                    </FormGroup>
                  </Col>
                </Row>
              </Col>
              <Col md={7}>
                <FormGroup controlId="restrictionsText">
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
                  <FormInputControl componentClass="textarea" rows="4" value={ this.state.restrictionsText } updateState={ this.updateState } disabled={ this.state.disableRestrictionsText } />
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col md={3}>
                <FormGroup controlId="schoolDistrictId">
                  <ControlLabel>School District</ControlLabel>
                  <FormInputControl componentClass="select" value={ this.state.schoolDistrictId || '' } updateState={ this.updateState }>
                    <option value=""></option>
                    {
                      schoolDistricts.map((sd) => {
                        return <option key={ sd.id } value={ sd.id }>{ sd.name }</option>;
                      })
                    }
                  </FormInputControl>
                </FormGroup>
              </Col>
              <Col md={2}>
                <FormGroup>
                  <ControlLabel>Independent School</ControlLabel>
                  <FormInputControl componentClass="div">
                    <Radio inline onChange={ this.isIndependentSchoolChanged.bind(this, true) } checked={ this.state.isIndependentSchool }>Yes</Radio>
                    { ' ' }
                    <Radio inline onChange={ this.isIndependentSchoolChanged.bind(this, false) } checked={ !this.state.isIndependentSchool }>No</Radio>
                  </FormInputControl>
                </FormGroup>
              </Col>
              <Col md={5}>
                <FormGroup controlId="independentSchoolName">
                  <ControlLabel>Independent School Name</ControlLabel>
                  <FormInputControl type="text" value={ this.state.independentSchoolName } updateState={ this.updateState } disabled= { !this.state.isIndependentSchool }/>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col md={3}>
                <FormGroup controlId="unitNumber">
                  <ControlLabel>Unit Number</ControlLabel>
                  <FormInputControl type="text" defaultValue={ this.state.unitNumber } updateState={ this.updateState } />
                </FormGroup>
              </Col>
              <Col md={2}>
                <FormGroup controlId="schoolBusSeatingCapacity" validationState={ this.state.schoolBusSeatingCapacityError ? 'error' : null }>
                  <ControlLabel>Seating Capacity <sup>*</sup></ControlLabel>
                  <FormInputControl type="number" defaultValue={ this.state.schoolBusSeatingCapacity } updateState={ this.updateState } />
                  <HelpBlock>{ this.state.schoolBusSeatingCapacityError }</HelpBlock>
                </FormGroup>
              </Col>
              <Col md={3}>
                <FormGroup controlId="mobilityAidCapacity" validationState={ this.state.mobilityAidCapacityError ? 'error' : null }>
                  <ControlLabel>Mobility Aid Capacity <sup>*</sup></ControlLabel>
                  <FormInputControl type="number" defaultValue={ this.state.mobilityAidCapacity } updateState={ this.updateState } />
                  <HelpBlock>{ this.state.mobilityAidCapacityError }</HelpBlock>
                </FormGroup>
              </Col>
            </Row>
          </Grid>
        </Form>;
      })()}
    </EditDialog>;
  },
});

function mapStateToProps(state) {
  return {
    schoolBus: state.models.schoolBus,
    districts: state.lookups.districts,
    inspectors: state.lookups.inspectors,
    cities: state.lookups.cities,
    schoolDistricts: state.lookups.schoolDistricts,
    owners: state.lookups.owners,
  };
}

export default connect(mapStateToProps)(SchoolBusesEditDialog);
