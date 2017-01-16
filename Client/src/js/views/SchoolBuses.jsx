import React from 'react';
import { connect } from 'react-redux';
import { Well, Alert, Table, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, DropdownButton, MenuItem, Button, ButtonGroup, Glyphicon } from 'react-bootstrap';
import { Form, FormControl, InputGroup, Checkbox } from 'react-bootstrap';

import _ from 'lodash';
import Moment from 'moment';

import * as Api from '../api';
import store from '../store';

import Spinner from '../components/Spinner.jsx';
import MultiDropdown from '../components/MultiDropdown.jsx';
import DateControl from '../components/DateControl.jsx';

import { notBlank } from '../utils/string';

/*
* System default should be:
** If user is an inspector, Inspector == Current User else not used
** If the user is not an inspector, Service Areas in home district, else not used

TODO:

* Badges on Next Inspection
* Faves
* Print / Email
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

const DEFAULT_SORT_FIELD = 'regi';

var SchoolBuses = React.createClass({
  propTypes: {
    schoolBuses: React.PropTypes.object,
    serviceAreas: React.PropTypes.object,
    inspectors: React.PropTypes.object,
    cities: React.PropTypes.object,
    schoolDistricts: React.PropTypes.object,
    search: React.PropTypes.object,
    ui: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: false,

      selectedServiceAreasIds: this.props.search.selectedServiceAreasIds || [],
      selectedInspectorsIds: this.props.search.selectedInspectorsIds || [],
      selectedCitiesIds: this.props.search.selectedCitiesIds || [],
      selectedSchoolDistrictsIds: this.props.search.selectedSchoolDistrictsIds || [],
      keySearchField: this.props.search.keySearchField || KEY_SEARCH_REGI,
      searchText: this.props.search.searchText || '',
      nextInspection: this.props.search.nextInspection || BEFORE_END_OF_MONTH,
      startDate: this.props.search.startDate || '',
      endDate: this.props.search.endDate || '',
      hideInactive: this.props.search.hideInactive !== false,
      justReInspections: this.props.search.justReInspections === true,

      sortField: this.props.ui.sortField || DEFAULT_SORT_FIELD,
      sortDesc: this.props.ui.sortDesc === true,
    };
  },

  buildSearchParams() {
    if (notBlank(this.state.searchText)) {
      switch (this.state.keySearchField) {
        case KEY_SEARCH_REGI: return { regi: this.state.searchText };
        case KEY_SEARCH_VIN: return { vin: this.state.searchText };
        case KEY_SEARCH_PLATE: return { plate: this.state.searchText };
        // Let this fall through if key search field is not set for some reason.
      }
    }

    var searchParams = {
      includeInactive: !this.state.hideInactive,
      onlyReInspections: this.state.justReInspections,
    };

    if (this.state.selectedServiceAreasIds.length > 0) {
      searchParams.serviceareas = this.state.selectedServiceAreasIds;
    }
    if (this.state.selectedInspectorsIds.length > 0) {
      searchParams.inspectors = this.state.selectedInspectorsIds;
    }
    if (this.state.selectedCitiesIds.length > 0) {
      searchParams.cities = this.state.selectedCitiesIds;
    }
    if (this.state.selectedSchoolDistrictsIds.length > 0) {
      searchParams.schooldistricts = this.state.selectedSchoolDistrictsIds;
    }

    var startDate;
    var endDate;
    var today = Moment();

    switch (this.state.nextInspection) {
      case BEFORE_TODAY:
        endDate = today.subtract(1, 'day');
        break;
      case BEFORE_END_OF_MONTH:
        endDate = today.endOf('month');
        break;
      case BEFORE_END_OF_QUARTER:
        endDate = today.endOf('quarter');
        break;
      case TODAY:
        startDate = today;
        endDate = today;
        break;
      case THIS_MONTH:
        startDate = today.startOf('month');
        endDate = Moment(startDate).endOf('month');
        break;
      case NEXT_MONTH:
        startDate = today.add(1, 'month').startOf('month');
        endDate = Moment(startDate).endOf('month');
        break;
      case THIS_QUARTER:
        startDate = today.startOf('quarter');
        endDate = Moment(startDate).endOf('quarter');
        break;
      case CUSTOM:
        startDate = Moment(this.state.startDate);
        endDate = Moment(this.state.endDate);
        break;
    }

    if (startDate && startDate.isValid()) {
      searchParams.startDate = startDate.format('YYYY-MM-DDT00:00:00');
    }
    if (endDate && endDate.isValid()) {
      searchParams.endDate = endDate.format('YYYY-MM-DDT00:00:00');
    }

    return searchParams;
  },

  componentDidMount() {
    this.setState({ loading: true });
    Api.getUsers().finally(() => {
      this.fetch();
    });
  },

  fetch() {
    this.setState({ loading: true });
    Api.searchSchoolBuses(this.buildSearchParams()).finally(() => {

      this.setState({ loading: false });
    });
  },

  updateState(state) {
    this.setState(state, () =>{
      store.dispatch({ type: 'UPDATE_BUSES_SEARCH', schoolBuses: {
        selectedServiceAreasIds: this.state.selectedServiceAreasIds,
        selectedInspectorsIds: this.state.selectedInspectorsIds,
        selectedCitiesIds: this.state.selectedCitiesIds,
        selectedSchoolDistrictsIds: this.state.selectedSchoolDistrictsIds,
        keySearchField: this.state.keySearchField,
        searchText: this.state.searchText,
        nextInspection: this.state.nextInspection,
        startDate: this.state.startDate,
        endDate: this.state.endDate,
        hideInactive: this.state.hideInactive,
        justReInspections: this.state.justReInspections,
      }});
    });
  },

  serviceAreasChanged(selected) {
    var selectedIds = _.map(selected, 'id');
    this.updateState({
      selectedServiceAreasIds: selectedIds,
    });
  },

  inspectorsChanged(selected) {
    var selectedIds = _.map(selected, 'id');
    this.updateState({
      selectedInspectorsIds: selectedIds,
    });
  },

  citiesChanged(selected) {
    var selectedIds = _.map(selected, 'id');
    this.updateState({
      selectedCitiesIds: selectedIds,
    });
  },

  schoolDistrictsChanged(selected) {
    var selectedIds = _.map(selected, 'id');
    this.updateState({
      selectedSchoolDistrictsIds: selectedIds,
    });
  },

  keySearchSelected(keyEvent) {
    this.updateState({
      keySearchField: keyEvent,
    });
  },

  searchTextChanged(e) {
    this.updateState({
      searchText: e.target.value,
    });
  },

  nextInspectionSelected(keyEvent) {
    this.updateState({
      nextInspection: keyEvent,
    });
  },

  startDateChanged(date) {
    this.updateState({
      startDate: date,
    });
  },

  endDateChanged(date) {
    this.updateState({
      endDate: date,
    });
  },

  hideInactiveSelected(e) {
    this.updateState({
      hideInactive: e.target.checked,
    });
  },

  justReInspectionsSelected(e) {
    this.updateState({
      justReInspections: e.target.checked,
    });
  },

  sort(e) {
    var newState = {};
    if (this.state.sortField !== e.currentTarget.id) {
      newState.sortField = e.currentTarget.id;
      newState.sortDesc = false;
    } else {
      newState.sortDesc = !this.state.sortDesc;
    }
    this.setState(newState, () =>{
      store.dispatch({ type: 'UPDATE_BUSES_UI', schoolBuses: {
        sortField: this.state.sortField,
        sortDesc: this.state.sortDesc,
      }});
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
          <Col md={11}>
            <Row>
              <Form inline>
                <ButtonToolbar id="school-buses-search">
                  <MultiDropdown id="service-areas-dropdown" placeholder="Service Areas"
                    items={ serviceAreas } selectedIds={ this.state.selectedServiceAreasIds } onChange={ this.serviceAreasChanged } showMaxItems={ 2 } />
                  <MultiDropdown id="inspectors-dropdown" placeholder="Inspectors"
                    items={ inspectors } selectedIds={ this.state.selectedInspectorsIds } onChange={ this.inspectorsChanged } showMaxItems={ 2 } />
                  <MultiDropdown id="cities-dropdown" placeholder="Cities"
                    items={ cities } selectedIds={ this.state.selectedCitiesIds } onChange={ this.citiesChanged } showMaxItems={ 2 } />
                  <MultiDropdown id="school-districts-dropdown" placeholder="School Districts"
                    items={ schoolDistricts } selectedIds={ this.state.selectedSchoolDistrictsIds } fieldName="shortName" onChange={ this.schoolDistrictsChanged } showMaxItems={ 2 } />
                  <InputGroup id="school-buses-key-search">
                    <DropdownButton id="school-buses-key-dropdown" componentClass={InputGroup.Button} title={ this.state.keySearchField } onSelect={ this.keySearchSelected }>
                      <MenuItem key={ KEY_SEARCH_REGI } eventKey={ KEY_SEARCH_REGI }>{ KEY_SEARCH_REGI }</MenuItem>
                      <MenuItem key={ KEY_SEARCH_VIN } eventKey={ KEY_SEARCH_VIN }>{ KEY_SEARCH_VIN }</MenuItem>
                      <MenuItem key={ KEY_SEARCH_PLATE } eventKey={ KEY_SEARCH_PLATE }>{ KEY_SEARCH_PLATE }</MenuItem>
                    </DropdownButton>
                    <FormControl type="text" value={ this.state.searchText } onChange={ this.searchTextChanged } />
                  </InputGroup>
                </ButtonToolbar>
              </Form>
            </Row>
            <Row>
              <ButtonToolbar id="school-buses-inspections">
                <DropdownButton id="school-buses-inspection-dropdown" title={ this.state.nextInspection } onSelect={ this.nextInspectionSelected }>
                  <MenuItem key={ BEFORE_TODAY } eventKey={ BEFORE_TODAY }>{ BEFORE_TODAY }</MenuItem>
                  <MenuItem key={ BEFORE_END_OF_MONTH } eventKey={ BEFORE_END_OF_MONTH }>{ BEFORE_END_OF_MONTH }</MenuItem>
                  <MenuItem key={ BEFORE_END_OF_QUARTER } eventKey={ BEFORE_END_OF_QUARTER }>{ BEFORE_END_OF_QUARTER }</MenuItem>
                  <MenuItem key={ TODAY } eventKey={ TODAY }>{ TODAY }</MenuItem>
                  <MenuItem key={ THIS_MONTH } eventKey={ THIS_MONTH }>{ THIS_MONTH }</MenuItem>
                  <MenuItem key={ NEXT_MONTH } eventKey={ NEXT_MONTH }>{ NEXT_MONTH }</MenuItem>
                  <MenuItem key={ THIS_QUARTER } eventKey={ THIS_QUARTER }>{ THIS_QUARTER }</MenuItem>
                  <MenuItem key={ CUSTOM } eventKey={ CUSTOM }>{ CUSTOM }&hellip;</MenuItem>
                </DropdownButton>
                <span className={ this.state.nextInspection !== CUSTOM ? 'hide' : '' }>
                  <DateControl date={ this.state.startDate } onChange={ this.startDateChanged } placeholder="mm/dd/yyyy" label="From:" title="start date"/>
                  <DateControl date={ this.state.endDate } onChange={ this.endDateChanged } placeholder="mm/dd/yyyy" label="To:" title="end date"/>
                </span>
                <Checkbox inline checked={ this.state.hideInactive } onChange={ this.hideInactiveSelected }>Hide Inactive</Checkbox>
                <Checkbox inline checked={ this.state.justReInspections } onChange={ this.justReInspectionsSelected }>Just Re-Inspections</Checkbox>
                <Button id="search-button" bsStyle="primary" onClick={ this.fetch }>Search</Button>
              </ButtonToolbar>
            </Row>
          </Col>
          <Col md={1}>
            <Row id="school-buses-buttons">
              <ButtonGroup>
                <Button><Glyphicon glyph="envelope" title="E-mail" /></Button>
                <Button><Glyphicon glyph="print" title="Print" /></Button>
              </ButtonGroup>
            </Row>
            <Row id="school-buses-faves">
              <DropdownButton id="school-buses-faves-dropdown" pullRight title="Faves">
                <MenuItem key="1" eventKey="1" disabled>No favourites</MenuItem>
              </DropdownButton>
            </Row>
          </Col>
        </Row>
      </Well>

      {(() => {
        if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }
        if (Object.keys(this.props.schoolBuses).length === 0) { return <Alert bsStyle="info">No school buses</Alert>; }

        var schoolBuses = _.sortBy(this.props.schoolBuses, this.state.sortField);
        if (this.state.sortDesc) {
          _.reverse(schoolBuses);
        }

        var buildHeader = (id, title) => {
          var sortGlyph = '';
          if (this.state.sortField === id) {
            sortGlyph = <span>&nbsp;<Glyphicon glyph={ this.state.sortDesc ? 'sort-by-attributes-alt' : 'sort-by-attributes' }/></span>;
          }
          return <th id={ id } onClick={ this.sort }>{ title }{ sortGlyph }</th>;
        };

        return <Table condensed striped>
          <thead>
            <tr>
              { buildHeader('regi', 'Regi') }
              { buildHeader('ownerName', 'Owner') }
              { buildHeader('serviceAreaName', 'Service Area') }
              { buildHeader('homeTerminal', 'Home Terminal') }
              { buildHeader('schoolBusUnitNumber', 'Fleet Unit #') }
              { buildHeader('permitNumber', 'Permit') }
              { buildHeader('nextInspectionDate', 'Next Inspection') }
              { buildHeader('inspectorName', 'Inspector') }
            </tr>
          </thead>
          <tbody>
          {
            _.map(schoolBuses, (bus) => {
              var editPath = '#/school-buses/' + bus.id;
              var ownerPath = '#/owners/' + (bus.schoolBusOwner ? bus.schoolBusOwner.id : '');

              return <tr key={ bus.id } className={ bus.status != 'Active' ? 'info' : null }>
                <td><a href={ editPath }>{ bus.regi }</a></td>
                <td><a href={ ownerPath }>{ bus.ownerName }</a></td>
                <td>{ bus.serviceAreaName }</td>
                <td>{ bus.homeTerminal }</td>
                <td>{ bus.schoolBusUnitNumber }</td>
                <td>{ bus.permitNumber }</td>
                <td>{ bus.nextInspectionDate }</td>
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
    search: state.search.schoolBuses,
    ui: state.ui.schoolBuses,
  };
}

export default connect(mapStateToProps)(SchoolBuses);
