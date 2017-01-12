import React from 'react';
import { connect } from 'react-redux';
import { Well, Alert, Table, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, DropdownButton, MenuItem, Form, FormControl, ControlLabel, Button, Glyphicon, Checkbox } from 'react-bootstrap';

import _ from 'lodash';

import Spinner from '../components/Spinner.jsx';
import MultiDropdown from '../components/MultiDropdown.jsx';
import { formatDateTime } from '../utils/date';

import * as Api from '../api';

/*
Some notes on the searching:

* Service Area, Inspector, Cities, School District should be a multi-select - list with text search
* Key Search options are "Regi", "VIN" and "Plate" and correspond to those values from the SB table.
* Owner searching is allowed, but not driven by this screen.  The API needs to support it so that if a user clicks on their count of buses, the list of active buses for that Owner is returned.
* Date Range is based on just "Next Inspection"
** "Select Range" in UI is for named ranges (e.g. "Custom", "This Month", "Next Month", "This Quarter" etc.)
** Only show the From/To date fields if "Custom" is selected.
** Leave it to the server to convert so Favs can use the named range
** Need to include "Before Today" and "Before End of Month" and "Before End of Quarter" to include overdue inspections
** Could be others, but I don't see any likely candidates
* System default should be:
** If user is an inspector, Inspector == Current User else not used
** If the user is not an inspector, Service Areas in home district, else not used
** Next Inspection Date - "Before the End of the Month"
** Hide Inactive is checked

Logic: OR the values within a field, AND between fields.

Hopefully the Date thing makes sense - but basically, if the user selects anything other than "Custom", the Fav needs to save the Text selected (e.g. "Next Month"), not the specific dates.  That's the only way that Fav is useful.

I said in the JIRA let the server handle the conversion to From/To, but that's not crucial, as long as the Fav records the name of the date range.
*/

const KEY_SEARCH_REGI = 'Regi';
const KEY_SEARCH_VIN = 'VIN';
const KEY_SEARCH_PLATE = 'Plate';

const BEFORE_TODAY = 'Before Today';
const BEFORE_END_OF_MONTH = 'Before End of Month';
const BEFORE_END_OF_QUARTER = 'Before End of Quarter';
const TODAY = 'Today';
const THIS_MONTH = 'This Month';
const NEXT_MONTH = 'Next Month';
const THIS_QUARTER = 'This Quarter';
const CUSTOM = 'Custom';

var SchoolBuses = React.createClass({
  propTypes: {
    schoolBuses: React.PropTypes.object,
    serviceAreas: React.PropTypes.object,
    inspectors: React.PropTypes.object,
    cities: React.PropTypes.object,
    schoolDistricts: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: false,
      selectedServiceAreasIds: [],
      selectedInspectorsIds: [],
      selectedCitiesIds: [],
      selectedSchoolDistrictsIds: [],
      keySearchField: KEY_SEARCH_REGI,
      nextInspection: BEFORE_END_OF_MONTH,
      customFieldsClassName: 'hide',
      hideInactive: true,
      justReInspections: false,
    };
  },

  componentDidMount() {
    this.setState({ loading: true });
    Api.getUsers().finally(() => {
      this.fetch();
    });
  },

  fetch(params) {
    this.setState({ loading: true });
    Api.getSchoolBuses(params).finally(() => {
      this.setState({ loading: false });
    });
  },

  serviceAreaChanged(selectedIds) {
    this.setState({
      selectedServiceAreasIds: selectedIds,
    });
  },

  inspectorsChanged(selectedIds) {
    this.setState({
      selectedInspectorsIds: selectedIds,
    });
  },

  citiesChanged(selectedIds) {
    this.setState({
      selectedCitiesIds: selectedIds,
    });
  },

  schoolDistrictsChanged(selectedIds) {
    this.setState({
      selectedSchoolDistrictsIds: selectedIds,
    });
  },

  keySearchSelected(keyEvent) {
    this.setState({
      keySearchField: keyEvent,
    });
  },

  nextInspectionSelected(keyEvent) {
    this.setState({
      nextInspection: keyEvent,
      customFieldsClassName: keyEvent !== CUSTOM ? 'hide' : '',
    });
  },

  hideInactiveSelected(e) {
    this.setState({
      hideInactive: e.target.checked,
    });
  },

  justReInspectionsSelected(e) {
    this.setState({
      justReInspections: e.target.checked,
    });
  },

  search() {
    this.fetch({

    });
  },

  render() {
    var serviceAreas = _.sortBy(this.props.serviceAreas, 'name');
    var inspectors = _.sortBy(this.props.inspectors, 'name');
    var cities = _.sortBy(this.props.cities, 'name');
    var schoolDistricts = _.sortBy(this.props.schoolDistricts, 'name');

    return <div id="school-buses">
      <Well id="school-buses-bar" bsSize="small" className="clearfix">
        <Row>
          <Col md={10}>
            <ButtonToolbar id="school-buses-search">
              <MultiDropdown id="service-areas-dropdown" placeholder="Service Areas" items={ serviceAreas } onChange={ this.serviceAreasChanged } showMaxItems={ 2 } />
              <MultiDropdown id="inspectors-dropdown" placeholder="Inspectors" items={ inspectors } onChange={ this.inspectorsChanged } showMaxItems={ 2 } />
              <MultiDropdown id="cities-dropdown" placeholder="Cities" items={ cities } onChange={ this.citiesChanged } showMaxItems={ 2 } />
              <MultiDropdown id="school-districts-dropdown" placeholder="School Districts" items={ schoolDistricts } fieldName="shortName" onChange={ this.schoolDistrictsChanged } showMaxItems={ 2 } />
              <div className="search-label">Key Search By:</div>
              <DropdownButton id="school-buses-key-dropdown" title={ this.state.keySearchField } onSelect={ this.keySearchSelected }>
                <MenuItem key={ KEY_SEARCH_REGI } eventKey={ KEY_SEARCH_REGI }>{ KEY_SEARCH_REGI }</MenuItem>
                <MenuItem key={ KEY_SEARCH_VIN } eventKey={ KEY_SEARCH_VIN }>{ KEY_SEARCH_VIN }</MenuItem>
                <MenuItem key={ KEY_SEARCH_PLATE } eventKey={ KEY_SEARCH_PLATE }>{ KEY_SEARCH_PLATE }</MenuItem>
              </DropdownButton>
              <Form inline>
                <FormControl className="search-text" type="text" placeholder="" />
              </Form>
            </ButtonToolbar>
          </Col>
          <Col md={2}>
            <div id="school-buses-utils" className="pull-right">
              <Button><Glyphicon glyph="envelope" title="E-mail" /></Button>
              <Button><Glyphicon glyph="print" title="Print" /></Button>
              <DropdownButton id="school-buses-faves-dropdown" title="Faves">
                <MenuItem key="1" eventKey="1" disabled>No favourites</MenuItem>
              </DropdownButton>
            </div>
          </Col>
        </Row>
        <Row>
          <Col md={10}>
            <ButtonToolbar id="school-buses-inspections">
              <div className="search-label">Next Inspection:</div>
              <DropdownButton id="school-buses-key-dropdown" title={ this.state.nextInspection } onSelect={ this.nextInspectionSelected }>
                <MenuItem key={ BEFORE_TODAY } eventKey={ BEFORE_TODAY }>{ BEFORE_TODAY }</MenuItem>
                <MenuItem key={ BEFORE_END_OF_MONTH } eventKey={ BEFORE_END_OF_MONTH }>{ BEFORE_END_OF_MONTH }</MenuItem>
                <MenuItem key={ BEFORE_END_OF_QUARTER } eventKey={ BEFORE_END_OF_QUARTER }>{ BEFORE_END_OF_QUARTER }</MenuItem>
                <MenuItem key={ TODAY } eventKey={ TODAY }>{ TODAY }</MenuItem>
                <MenuItem key={ THIS_MONTH } eventKey={ THIS_MONTH }>{ THIS_MONTH }</MenuItem>
                <MenuItem key={ NEXT_MONTH } eventKey={ NEXT_MONTH }>{ NEXT_MONTH }</MenuItem>
                <MenuItem key={ THIS_QUARTER } eventKey={ THIS_QUARTER }>{ THIS_QUARTER }</MenuItem>
                <MenuItem key={ CUSTOM } eventKey={ CUSTOM }>{ CUSTOM }</MenuItem>
              </DropdownButton>
              <Form inline className={ this.state.customFieldsClassName }>
                <ControlLabel>From:</ControlLabel>
                <FormControl className="search-text" type="text" placeholder="mm/dd/yyyy" />
                <ControlLabel>To:</ControlLabel>
                <FormControl className="search-text" type="text" placeholder="mm/dd/yyyy" />
              </Form>
              <Checkbox inline className="search-label" checked={ this.state.hideInactive } onChange={ this.hideInactiveSelected }>Hide Inactive</Checkbox>
              <Checkbox inline className="search-label" checked={ this.state.justReInspections } onChange={ this.justReInspectionsSelected }>Just Re-Inspections</Checkbox>
            </ButtonToolbar>
          </Col>
          <Col md={2}>
            <Button id="search" onClick={ this.search } className="pull-right">Search</Button>
          </Col>
        </Row>
      </Well>

      {(() => {
        if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }
        if (Object.keys(this.props.schoolBuses).length === 0) { return <Alert bsStyle="info">No school buses</Alert>; }

        return <Table condensed striped>
          <thead>
            <tr>
              <th>Regi</th>
              <th>Owner</th>
              <th>Local Area</th>
              <th>Bus Location</th>
              <th>Fleet Unit #</th>
              <th>Permit</th>
              <th>Next Inspection</th>
              <th>Inspector</th>
            </tr>
          </thead>
          <tbody>
          {
            _.map(this.props.schoolBuses, (bus) => {
              var editPath = '#/school-buses/' + bus.id;
              var ownerPath = '#/owners/' + (bus.schoolBusOwner ? bus.schoolBusOwner.id : '');

              return <tr key={ bus.id } className={ bus.status != 'Active' ? 'info' : null }>
                <td><a href={ editPath }>{ bus.regi }</a></td>
                <td><a href={ ownerPath }>{ bus.schoolBusOwner ? bus.schoolBusOwner.name : '' }</a></td>
                <td>{ bus.location }</td>
                <td>{ bus.busLocationCity }, { bus.busLocationPostCode }</td>
                <td>{ bus.schoolBusUnitNumber }</td>
                <td>{ bus.permitNumber }</td>
                <td>{ formatDateTime(bus.nextInspectionDate, 'MM/DD/YYYY') }</td>
                <td>{ bus.inspectorName }</td>
              </tr>;
            })
          }
          </tbody>
        </Table>;
      })()}

    </div>;
  },
});


function mapStateToProps(state) {
  return {
    schoolBuses: state.models.schoolBuses,
    serviceAreas: state.lookups.serviceAreas,
    inspectors: state.models.users,
    cities: state.lookups.cities,
    schoolDistricts: state.lookups.schoolDistricts,
  };
}

export default connect(mapStateToProps)(SchoolBuses);
