import React from 'react';

import { connect } from 'react-redux';

import { Grid, Row, Col } from 'react-bootstrap';
import { Form, FormGroup, ControlLabel } from 'react-bootstrap';

import Promise from 'bluebird';

import * as Api from '../../api';

import DateControl from '../../components/DateControl.jsx';
import EditDialog from '../../components/EditDialog.jsx';
import Spinner from '../../components/Spinner.jsx';

import { today } from '../../utils/date';

/*
SB-130

if the age of the inspection is less than some period
(initially, 24 hours), allow the user to both edit and delete an inspection.
  The config setting for this can be in the UI alone - just make it obvious and easily changed.

Based on the result of the inspection - e.g. pass/fail - default the
"Next Inspection Date" to be 1 year from now (business day) on pass, ** TODAY + 365**
30 days from now on fail
  - For business day - verify non-weekend only for now. We may eventually
  add a "BC Stats" API and if so, verify that the date does not fall on a stat
  - Move the date sooner to find a business day
  - Allow the user to edit the next inspection date

The next inspection type is either "Reinspection" or "Annual Inspection".

The next inspection date and type go into the School Bus record. We may
keep that in the inspection as well.

SB-13

Defaults:

  - The "Next Inspection Date" should be blank based until the result is selected. Once done:
  - On "Failed":
    Default to the first business day on or before 30 days from the date of the inspection.
  - On "Passed":
    Default to the first business day on or before 1 year from the date of the inspection.

Validation:

Inspection Date, Inspector, Inspection Result and Next Inspection Date are all required fields.

The RIP inspection ID and Comment fields are optional.

The Next Inspection Date rules are:
  - Failed:
    Can not be more than 30 days from the date of the inspection.
  - Passed:
    Can not be less than 9 months from the date of the inspection, and cannot be more than the one year from the Date of the Inspection.

Inspection:
{
  "id": 0,
  "schoolBus": YADA
  "inspector": YADA
  "inspectionDate": "2017-01-27T21:18:47.947Z",
  "inspectionTypeCode": "string",
  "inspectionResultCode": "string",
  "notes": "string",
  "ripInspectionId": "string",
  "createdDate": "2017-01-27T21:18:47.947Z"
}
*/


const TYPE_ANNUAL = 'Annual';

var InspectionEditDialog = React.createClass({
  propTypes: {
    inspection: React.PropTypes.object,
    inspectors: React.PropTypes.object,

    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
  },

  getInitialState() {
    return {
      loading: false,
      changed: false,

      isNew: this.props.inspection.id === '',

      schoolBus: this.props.inspection.schoolBus,
      inspectorId: this.props.inspection.inspector ? this.props.inspection.inspector.id : '',
      inspectionDate: this.props.inspection.inspectionDate || today(),
      inspectionTypeCode: this.props.inspection.inspectionTypeCode || TYPE_ANNUAL,
      inspectionResultCode: this.props.inspection.inspectionResultCode || '',
      nextInspectionDate: this.props.inspection.nextInspectionDate || '',
      notes: this.props.inspection.notes || '',
      ripInspectionId: this.props.inspection.ripInspectionId || '',

      mobilityAidCapacityError: false,
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

  didChange() {
    if (this.state.inspectorId !== this.props.inspection.inspector.id) { return true; }
    if (this.state.inspectionDate !== this.props.inspection.inspectionDate) { return true; }
    if (this.state.inspectionTypeCode !== this.props.inspection.inspectionTypeCode) { return true; }
    if (this.state.inspectionResultCode !== this.props.inspection.inspectionResultCode) { return true; }
    if (this.state.nextInspectionDate !== this.props.inspection.nextInspectionDate) { return true; }
    if (this.state.notes !== this.props.inspection.notes) { return true; }
    if (this.state.ripInspectionId !== this.props.inspection.ripInspectionId) { return true; }

    return false;
  },

  isValid() {
    return true;
  },

  onSave() {
    this.props.onSave({ ...this.props.inspection, ...{
      inspector: { id: this.state.inspectorId },
      inspectionDate: this.state.inspectionDate,
      inspectionTypeCode: this.state.inspectionTypeCode,
      inspectionResultCode: this.state.inspectionResultCode,
      nextInspectionDate: this.state.nextInspectionDate,
      notes: this.state.notes,
      ripInspectionId: this.state.ripInspectionId,
    }});
  },

  render() {

    return <EditDialog id="inspection-edit" show={ this.props.show } bsSize="large"
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
                <FormGroup controlId="inspectionDate">
                  <ControlLabel>Inspection Date</ControlLabel>
                  <DateControl date={ this.state.inspectionDate } updateState={ this.updateState } placeholder="mm/dd/yyyy" title="inspection date"/>
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
    inspection: state.models.inspection,
    inspectors: state.lookups.inspectors,
  };
}

export default connect(mapStateToProps)(InspectionEditDialog);
