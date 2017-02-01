import React from 'react';

import { connect } from 'react-redux';

import { Grid, Row, Col } from 'react-bootstrap';
import { Form, FormGroup, ControlLabel, HelpBlock } from 'react-bootstrap';

import _ from 'lodash';
import Moment from 'moment';
import Promise from 'bluebird';

import * as Api from '../../api';

import DateControl from '../../components/DateControl.jsx';
import EditDialog from '../../components/EditDialog.jsx';
import FormInputControl from '../../components/FormInputControl.jsx';
import LinkControl from '../../components/LinkControl.jsx';
import Spinner from '../../components/Spinner.jsx';

import { today, businessDayOnOrBefore, daysFromToday, isValidDate } from '../../utils/date';
import { isBlank } from '../../utils/string';

/*
The "inspector" defaults to the current user if the current user is an inspector (TBD - the attribute that will indicate that - likely the existence of a badge number), or blank.

NOTE: The next inspection date and type go into the School Bus record.

*/


const RESULT_PASSED = 'Passed';
const RESULT_FAILED = 'Failed';

const TYPE_ANNUAL = 'Annual';
const TYPE_REINSPECTION = 'Re-Inspection';

var InspectionEditDialog = React.createClass({
  propTypes: {
    inspection: React.PropTypes.object.isRequired,
    inspectors: React.PropTypes.object,

    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
  },

  getInitialState() {
    var isNew = this.props.inspection.id === '';

    return {
      loading: false,

      inspectorId: this.props.inspection.inspector ? this.props.inspection.inspector.id : '',
      inspectionDate: this.props.inspection.inspectionDate || today(),
      inspectionTypeCode: this.props.inspection.inspectionTypeCode || TYPE_ANNUAL,
      inspectionResultCode: this.props.inspection.inspectionResultCode || '',
      nextInspectionDate: isNew ? '' : (this.props.inspection.schoolBus ? this.props.inspection.schoolBus.nextInspectionDate : ''),
      nextInspectionTypeCode: isNew ? '' : (this.props.inspection.schoolBus ? this.props.inspection.schoolBus.nextInspectionTypeCode : ''),
      notes: this.props.inspection.notes || '',
      ripInspectionId: this.props.inspection.ripInspectionId || '',

      inspectionDateError: false,
      inspectorIdError: false,
      inspectionResultCodeError: false,
      nextInspectionDateError: false,
    };
  },

  componentDidMount() {
    this.setState({ loading: true });

    var inspectorsPromise = Api.getInspectors();

    Promise.all([inspectorsPromise]).then(() => {
      this.setState({ loading: false });
    });
  },

  updateState(state, callback) {
    this.setState(state, callback);
  },

  updateNextInspectionDate() {
    var inspectionDate = Moment(this.state.inspectionDate);
    if (inspectionDate && inspectionDate.isValid()) {
      // Remove time elements from date
      inspectionDate.startOf('d');
      var nextDate = '';
      if (this.state.nextInspectionTypeCode === TYPE_REINSPECTION) {
        // 30 days from date
        nextDate = businessDayOnOrBefore(inspectionDate.add(30, 'd'));
      } else if (this.state.nextInspectionTypeCode === TYPE_ANNUAL) {
        // A year from date
        nextDate = businessDayOnOrBefore(inspectionDate.add(1, 'y'));
      }

      this.updateState({
        nextInspectionDate: nextDate,
      });
    }
  },

  inspectionDateChanged(date) {
    this.updateState({
      inspectionDate: date,
    }, this.updateNextInspectionDate);
  },

  resultCodeChanged(e) {
    var resultCode = e.target.value;
    var typeCode = '';

    if (resultCode === RESULT_FAILED) {
      typeCode = TYPE_REINSPECTION;
    } else if (resultCode === RESULT_PASSED) {
      typeCode = TYPE_ANNUAL;
    }

    this.updateState({
      inspectionResultCode: resultCode,
      nextInspectionTypeCode: typeCode,
    }, this.updateNextInspectionDate);

  },

  didChange() {
    if (this.state.inspectorId !== (this.props.inspection.inspector ? this.props.inspection.inspector.id : '')) { return true; }
    if (this.state.inspectionDate !== this.props.inspection.inspectionDate) { return true; }
    if (this.state.inspectionTypeCode !== this.props.inspection.inspectionTypeCode) { return true; }
    if (this.state.inspectionResultCode !== this.props.inspection.inspectionResultCode) { return true; }
    if (this.state.nextInspectionDate !== this.props.inspection.nextInspectionDate) { return true; }
    if (this.state.nextInspectionTypeCode !== this.props.inspection.nextInspectionTypeCode) { return true; }
    if (this.state.notes !== this.props.inspection.notes) { return true; }
    if (this.state.ripInspectionId !== this.props.inspection.ripInspectionId) { return true; }

    return false;
  },

  isValid() {
    this.setState({
      inspectionDateError: false,
      inspectorIdError: false,
      inspectionResultCodeError: false,
      nextInspectionDateError: false,
    });

    var valid = true;
    if (isBlank(this.state.inspectionDate)) {
      this.setState({ inspectionDateError: 'Inspection date is required' });
      valid = false;
    } else if (!isValidDate(this.state.inspectionDate)) {
      this.setState({ inspectionDateError: 'Inspection date not valid' });
      valid = false;
    } else if (daysFromToday(this.state.inspectionDate) > 0) {
      this.setState({ inspectionDateError: 'Inspection date must be today or earlier' });
      valid = false;
    }

    if (isBlank(this.state.inspectorId)) {
      this.setState({ inspectorIdError: 'Inspector is required' });
      valid = false;
    }

    if (isBlank(this.state.inspectionResultCode)) {
      this.setState({ inspectionResultCodeError: 'Result is required' });
      valid = false;
    }

    if (isBlank(this.state.nextInspectionDate)) {
      this.setState({ nextInspectionDateError: 'Next inspection date is required' });
      valid = false;
    } else if (!isValidDate(this.state.nextInspectionDate)) {
      this.setState({ nextInspectionDateError: 'Next inspection date not valid' });
      valid = false;
    } else if (isValidDate(this.state.inspectionDate)) {
      // Remove time elements from dates so day/month/year math works.
      var inspectionDate = Moment(this.state.inspectionDate).startOf('d');
      var nextInspectionDate = Moment(this.state.nextInspectionDate).startOf('d');
      if (this.state.nextInspectionTypeCode === TYPE_REINSPECTION) {
        var diff = nextInspectionDate.diff(inspectionDate, 'd');
        if (diff <= 0) {
          // Cannot be before or on the date of the inspection.
          this.setState({ nextInspectionDateError: 'Re-inspection must be after inspection' });
          valid = false;
        } else if (diff > 30) {
          // Cannot be more than 30 days from the date of the inspection.
          this.setState({ nextInspectionDateError: 'Re-inspection must be within 30 days of inspection' });
          valid = false;
        }
      } else if (this.state.nextInspectionTypeCode === TYPE_ANNUAL) {
        if (nextInspectionDate.diff(inspectionDate, 'M') < 9) {
          // Cannot be less than 9 months from the date of the inspection,
          this.setState({ nextInspectionDateError: 'Annual inspection must be at least 9 months after inspection' });
          valid = false;
        } else if (nextInspectionDate.subtract(1, 'd').diff(inspectionDate, 'y') > 0) {
          // Cannot be more than the one year from the Date of the Inspection.
          this.setState({ nextInspectionDateError: 'Annual inspection must be within a year of inspection' });
          valid = false;
        }
      }
    }

    return valid;
  },

  onSave() {
    this.props.onSave({ ...this.props.inspection, ...{
      inspector: { id: this.state.inspectorId },
      inspectionDate: this.state.inspectionDate,
      inspectionTypeCode: this.state.inspectionTypeCode,
      inspectionResultCode: this.state.inspectionResultCode,
      nextInspectionDate: this.state.nextInspectionDate,
      nextInspectionTypeCode: this.state.nextInspectionTypeCode,
      notes: this.state.notes,
      ripInspectionId: this.state.ripInspectionId,
    }});
  },

  render() {
    var inspectors = _.sortBy(this.props.inspectors, 'name');

    return <EditDialog id="inspection-edit" show={ this.props.show }
      onClose={ this.props.onClose } onSave={ this.onSave } didChange={ this.didChange } isValid={ this.isValid }
      title= {
        <strong>Inspection</strong>
      }>
      {(() => {
        if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

        return <Form>
          <Grid fluid>
            <Row>
              <Col md={4}>
                <FormGroup validationState={ this.state.inspectionDateError ? 'error' : null }>
                  <ControlLabel>Date</ControlLabel>
                  <DateControl id="inspectionDate" date={ this.state.inspectionDate } onChange={ this.inspectionDateChanged } placeholder="mm/dd/yyyy" title="inspection date"/>
                  <HelpBlock>{ this.state.inspectionDateError }</HelpBlock>
                </FormGroup>
              </Col>
              <Col md={5}>
                <FormGroup controlId="inspectorId" validationState={ this.state.inspectorIdError ? 'error' : null }>
                  <ControlLabel>Inspector</ControlLabel>
                  <FormInputControl componentClass="select" value={ this.state.inspectorId || '' } updateState={ this.updateState }>
                    <option value=""></option>
                    {
                      inspectors.map((inspector) => {
                        return <option key={ inspector.id } value={ inspector.id }>{ inspector.name }</option>;
                      })
                    }
                  </FormInputControl>
                  <HelpBlock>{ this.state.inspectorIdError }</HelpBlock>
                </FormGroup>
              </Col>
              <Col md={1}></Col>
              <Col md={2}>
                <FormGroup controlId="inspectionResultCode" validationState={ this.state.inspectionResultCodeError ? 'error' : null }>
                  <ControlLabel>Result</ControlLabel>
                  <FormInputControl componentClass="select" value={ this.state.inspectionResultCode } onChange={ this.resultCodeChanged }>
                    <option value=""></option>
                    <option value={ RESULT_PASSED }>{ RESULT_PASSED }</option>;
                    <option value={ RESULT_FAILED }>{ RESULT_FAILED }</option>;
                  </FormInputControl>
                  <HelpBlock>{ this.state.inspectionResultCodeError }</HelpBlock>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col md={4}>
                <FormGroup validationState={ this.state.nextInspectionDateError ? 'error' : null }>
                  <ControlLabel>Next Inspection Date</ControlLabel>
                  <DateControl id="nextInspectionDate" date={ this.state.nextInspectionDate } updateState={ this.updateState } placeholder="mm/dd/yyyy" title="next inspection date"/>
                  <HelpBlock>{ this.state.nextInspectionDateError }</HelpBlock>
                </FormGroup>
                <FormGroup controlId="ripInspectionId">
                  <ControlLabel>RIP Inspection ID</ControlLabel>
                  <LinkControl value={ this.state.ripInspectionId } url={ (value) => { return `http://google.com/search?q=${value}`; } } updateState={ this.updateState }/>
                </FormGroup>
              </Col>
              <Col md={8}>
                <FormGroup controlId="notes">
                  <ControlLabel>Comments</ControlLabel>
                  <FormInputControl componentClass="textarea" value={ this.state.notes } updateState={ this.updateState }/>
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
    inspectors: state.lookups.inspectors,
  };
}

export default connect(mapStateToProps)(InspectionEditDialog);
