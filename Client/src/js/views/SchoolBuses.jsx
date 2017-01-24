import React from 'react';
import { connect } from 'react-redux';
import { Well, Alert, Table, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, DropdownButton, MenuItem, Button, ButtonGroup, Glyphicon } from 'react-bootstrap';
import { Form, FormControl, InputGroup, Checkbox } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';
import Moment from 'moment';

import * as Api from '../api';
import store from '../store';

import BadgeLabel from '../components/BadgeLabel.jsx';
import DateControl from '../components/DateControl.jsx';
import Favourites from '../components/Favourites.jsx';
import MultiDropdown from '../components/MultiDropdown.jsx';
import Spinner from '../components/Spinner.jsx';

import { formatDateTime } from '../utils/date';
import { notBlank } from '../utils/string';

/*

* System default should be:
** If user is an inspector, Inspector == Current User else not used
** If the user is not an inspector, Districts in home district, else not used

TODO:
* Print / Email

*/

const KEY_SEARCH_REGI = 'Regi';
const KEY_SEARCH_VIN = 'VIN';
const KEY_SEARCH_PLATE = 'Plate';

const BEFORE_TODAY = 'Before Today';
const BEFORE_END_OF_MONTH = 'Before End of Month';
const BEFORE_END_OF_QUARTER = 'Before End of Quarter';
const TODAY = 'Today';
const WITHIN_30_DAYS = 'Within 30 Days';
const THIS_MONTH = 'This Month';
const NEXT_MONTH = 'Next Month';
const THIS_QUARTER = 'This Quarter';
const CUSTOM = 'Custom';
const ALL = 'All';

const DEFAULT_SORT_FIELD = 'ownerName';

var SchoolBuses = React.createClass({
  propTypes: {
    schoolBuses: React.PropTypes.object,
    districts: React.PropTypes.object,
    inspectors: React.PropTypes.object,
    cities: React.PropTypes.object,
    schoolDistricts: React.PropTypes.object,
    owners: React.PropTypes.object,
    favourites: React.PropTypes.object,
    search: React.PropTypes.object,
    ui: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: false,

      search: {
        selectedDistrictsIds: this.props.search.selectedDistrictsIds || [],
        selectedInspectorsIds: this.props.search.selectedInspectorsIds || [],
        selectedCitiesIds: this.props.search.selectedCitiesIds || [],
        selectedSchoolDistrictsIds: this.props.search.selectedSchoolDistrictsIds || [],
        ownerId: this.props.search.ownerId || '',
        ownerName: this.props.search.ownerName || 'Owner',
        keySearchField: this.props.search.keySearchField || KEY_SEARCH_REGI,
        searchText: this.props.search.searchText || '',
        nextInspection: this.props.search.nextInspection || WITHIN_30_DAYS,
        startDate: this.props.search.startDate || '',
        endDate: this.props.search.endDate || '',
        hideInactive: this.props.search.hideInactive !== false,
        justReInspections: this.props.search.justReInspections === true,
      },

      ui : {
        sortField: this.props.ui.sortField || DEFAULT_SORT_FIELD,
        sortDesc: this.props.ui.sortDesc === true,
      },
    };
  },

  buildSearchParams() {
    if (notBlank(this.state.search.searchText)) {
      switch (this.state.search.keySearchField) {
        case KEY_SEARCH_REGI: return { regi: this.state.search.searchText };
        case KEY_SEARCH_VIN: return { vin: this.state.search.searchText };
        case KEY_SEARCH_PLATE: return { plate: this.state.search.searchText };
        // Let this fall through if key search field is not set for some reason.
      }
    }

    var searchParams = {
      includeInactive: !this.state.search.hideInactive,
      onlyReInspections: this.state.search.justReInspections,
      owner: this.state.search.ownerId,
    };

    if (this.state.search.selectedDistrictsIds.length > 0) {
      searchParams.districts = this.state.search.selectedDistrictsIds;
    }
    if (this.state.search.selectedInspectorsIds.length > 0) {
      searchParams.inspectors = this.state.search.selectedInspectorsIds;
    }
    if (this.state.search.selectedCitiesIds.length > 0) {
      searchParams.cities = this.state.search.selectedCitiesIds;
    }
    if (this.state.search.selectedSchoolDistrictsIds.length > 0) {
      searchParams.schooldistricts = this.state.search.selectedSchoolDistrictsIds;
    }

    var startDate;
    var endDate;
    var today = Moment();

    switch (this.state.search.nextInspection) {
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
      case WITHIN_30_DAYS:
        endDate = today.add(30, 'day');
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
        startDate = Moment(this.state.search.startDate);
        endDate = Moment(this.state.search.endDate);
        break;
      case ALL:
      default:
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

    var inspectorsPromise = Api.getInspectors();
    var ownersPromise = Api.getOwners();
    var favouritesPromise = Api.getFavourites('schoolBus');

    Promise.all([inspectorsPromise, ownersPromise, favouritesPromise]).then(() => {
      // If this is the first load, then look for a default favourite
      if (!this.props.search.loaded) {
        var favourite = _.find(this.props.favourites, (favourite) => { return favourite.isDefault; });
        if (favourite) {
          this.loadFavourite(favourite);
          return;
        }
      }
      this.fetch();
    });
  },

  fetch() {
    this.setState({ loading: true });
    Api.searchSchoolBuses(this.buildSearchParams()).finally(() => {
      this.setState({ loading: false });
    });
  },

  updateSearchState(state, callback) {
    this.setState({ search: { ...this.state.search, ...state }}, () =>{
      store.dispatch({ type: 'UPDATE_BUSES_SEARCH', schoolBuses: this.state.search });
      if (callback) { callback(); }
    });
  },

  updateUIState(state, callback) {
    this.setState({ ui: { ...this.state.ui, ...state }}, () =>{
      store.dispatch({ type: 'UPDATE_BUSES_UI', schoolBuses: this.state.ui });
      if (callback) { callback(); }
    });
  },

  districtsChanged(selected) {
    var selectedIds = _.map(selected, 'id');
    this.updateSearchState({
      selectedDistrictsIds: selectedIds,
    });
  },

  inspectorsChanged(selected) {
    var selectedIds = _.map(selected, 'id');
    this.updateSearchState({
      selectedInspectorsIds: selectedIds,
    });
  },

  citiesChanged(selected) {
    var selectedIds = _.map(selected, 'id');
    this.updateSearchState({
      selectedCitiesIds: selectedIds,
    });
  },

  schoolDistrictsChanged(selected) {
    var selectedIds = _.map(selected, 'id');
    this.updateSearchState({
      selectedSchoolDistrictsIds: selectedIds,
    });
  },

  ownerSelected(keyEvent, e) {
    this.updateSearchState({
      ownerId: keyEvent || '',
      ownerName: keyEvent !== 0 ? e.target.text : 'Owner',
    });
  },

  keySearchSelected(keyEvent) {
    this.updateSearchState({
      keySearchField: keyEvent,
    });
  },

  searchTextChanged(e) {
    this.updateSearchState({
      searchText: e.target.value,
    });
  },

  nextInspectionSelected(keyEvent) {
    this.updateSearchState({
      nextInspection: keyEvent,
    });
  },

  startDateChanged(date) {
    this.updateSearchState({
      startDate: date,
    });
  },

  endDateChanged(date) {
    this.updateSearchState({
      endDate: date,
    });
  },

  hideInactiveSelected(e) {
    this.updateSearchState({
      hideInactive: e.target.checked,
    });
  },

  justReInspectionsSelected(e) {
    this.updateSearchState({
      justReInspections: e.target.checked,
    });
  },

  saveFavourite(favourite) {
    favourite.value = JSON.stringify(this.state.search);
  },

  loadFavourite(favourite) {
    this.updateSearchState(JSON.parse(favourite.value), this.fetch);
  },

  sort(e) {
    var newState = {};
    if (this.state.ui.sortField !== e.currentTarget.id) {
      newState.sortField = e.currentTarget.id;
      newState.sortDesc = false;
    } else {
      newState.sortDesc = !this.state.ui.sortDesc;
    }

    this.updateUIState(newState);
  },

  email() {

  },

  print() {

  },

  render() {
    var districts = _.sortBy(this.props.districts, 'name');
    var inspectors = _.sortBy(this.props.inspectors, 'name');
    var cities = _.sortBy(this.props.cities, 'name');
    var schoolDistricts = _.sortBy(this.props.schoolDistricts, 'name');
    var owners = _.sortBy(this.props.owners, 'name');

    return <div id="school-buses-list">
      <Well id="school-buses-bar" bsSize="small" className="clearfix">
        <Row>
          <Col md={11}>
            <Row>
              <ButtonToolbar id="school-buses-search">
                <MultiDropdown id="districts-dropdown" placeholder="Districts"
                  items={ districts } selectedIds={ this.state.search.selectedDistrictsIds } onChange={ this.districtsChanged } showMaxItems={ 2 } />
                <MultiDropdown id="inspectors-dropdown" placeholder="Inspectors"
                  items={ inspectors } selectedIds={ this.state.search.selectedInspectorsIds } onChange={ this.inspectorsChanged } showMaxItems={ 2 } />
                <MultiDropdown id="cities-dropdown" placeholder="Cities"
                  items={ cities } selectedIds={ this.state.search.selectedCitiesIds } onChange={ this.citiesChanged } showMaxItems={ 2 } />
                <MultiDropdown id="school-districts-dropdown" placeholder="School Districts"
                  items={ schoolDistricts } selectedIds={ this.state.search.selectedSchoolDistrictsIds } fieldName="shortName" onChange={ this.schoolDistrictsChanged } showMaxItems={ 2 } />
                <DropdownButton id="school-buses-owner-dropdown" title={ this.state.search.ownerName } onSelect={ this.ownerSelected }>
                  <MenuItem key={ 0 } eventKey={ 0 }>&nbsp;</MenuItem>
                  {
                    _.map(owners, (owner) => {
                      return <MenuItem key={ owner.id } eventKey={ owner.id }>{ owner.name }</MenuItem>;
                    })
                  }
                </DropdownButton>
                <Form inline>
                  <InputGroup id="school-buses-key-search">
                    <DropdownButton id="school-buses-key-dropdown" componentClass={ InputGroup.Button } title={ this.state.search.keySearchField } onSelect={ this.keySearchSelected }>
                      <MenuItem key={ KEY_SEARCH_REGI } eventKey={ KEY_SEARCH_REGI }>{ KEY_SEARCH_REGI }</MenuItem>
                      <MenuItem key={ KEY_SEARCH_VIN } eventKey={ KEY_SEARCH_VIN }>{ KEY_SEARCH_VIN }</MenuItem>
                      <MenuItem key={ KEY_SEARCH_PLATE } eventKey={ KEY_SEARCH_PLATE }>{ KEY_SEARCH_PLATE }</MenuItem>
                    </DropdownButton>
                    <FormControl type="text" value={ this.state.search.searchText } onChange={ this.searchTextChanged } />
                  </InputGroup>
                </Form>
              </ButtonToolbar>
            </Row>
            <Row>
              <ButtonToolbar id="school-buses-inspections">
                <DropdownButton id="school-buses-inspection-dropdown" title={ this.state.search.nextInspection } onSelect={ this.nextInspectionSelected }>
                  <MenuItem key={ ALL } eventKey={ ALL }>{ ALL }</MenuItem>
                  <MenuItem key={ BEFORE_TODAY } eventKey={ BEFORE_TODAY }>{ BEFORE_TODAY }</MenuItem>
                  <MenuItem key={ BEFORE_END_OF_MONTH } eventKey={ BEFORE_END_OF_MONTH }>{ BEFORE_END_OF_MONTH }</MenuItem>
                  <MenuItem key={ BEFORE_END_OF_QUARTER } eventKey={ BEFORE_END_OF_QUARTER }>{ BEFORE_END_OF_QUARTER }</MenuItem>
                  <MenuItem key={ TODAY } eventKey={ TODAY }>{ TODAY }</MenuItem>
                  <MenuItem key={ WITHIN_30_DAYS } eventKey={ WITHIN_30_DAYS }>{ WITHIN_30_DAYS }</MenuItem>
                  <MenuItem key={ THIS_MONTH } eventKey={ THIS_MONTH }>{ THIS_MONTH }</MenuItem>
                  <MenuItem key={ NEXT_MONTH } eventKey={ NEXT_MONTH }>{ NEXT_MONTH }</MenuItem>
                  <MenuItem key={ THIS_QUARTER } eventKey={ THIS_QUARTER }>{ THIS_QUARTER }</MenuItem>
                  <MenuItem key={ CUSTOM } eventKey={ CUSTOM }>{ CUSTOM }&hellip;</MenuItem>
                </DropdownButton>
                {(() => {
                  if (this.state.search.nextInspection === CUSTOM) {
                    return <span>
                      <DateControl date={ this.state.search.startDate } onChange={ this.startDateChanged } placeholder="mm/dd/yyyy" label="From:" title="start date"/>
                      <DateControl date={ this.state.search.endDate } onChange={ this.endDateChanged } placeholder="mm/dd/yyyy" label="To:" title="end date"/>
                    </span>;
                  }
                })()}
                <Checkbox inline checked={ this.state.search.hideInactive } onChange={ this.hideInactiveSelected }>Hide Inactive</Checkbox>
                <Checkbox inline checked={ this.state.search.justReInspections } onChange={ this.justReInspectionsSelected }>Just Re-Inspections</Checkbox>
                <Button id="search-button" bsStyle="primary" onClick={ this.fetch }>Search</Button>
              </ButtonToolbar>
            </Row>
          </Col>
          <Col md={1}>
            <Row id="school-buses-buttons">
              <ButtonGroup>
                <Button onClick={ this.email }><Glyphicon glyph="envelope" title="E-mail" /></Button>
                <Button onClick={ this.print }><Glyphicon glyph="print" title="Print" /></Button>
              </ButtonGroup>
            </Row>
            <Row id="school-buses-faves">
              <Favourites id="school-buses-faves-dropdown" type="schoolBus" favourites={ this.props.favourites } onAdd={ this.saveFavourite } onSelect={ this.loadFavourite } pullRight />
            </Row>
          </Col>
        </Row>
      </Well>

      {(() => {
        if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }
        if (Object.keys(this.props.schoolBuses).length === 0) { return <Alert bsStyle="success">No school buses</Alert>; }

        var schoolBuses = _.sortBy(this.props.schoolBuses, this.state.ui.sortField);
        if (this.state.ui.sortDesc) {
          _.reverse(schoolBuses);
        }

        var buildHeader = (id, title) => {
          var sortGlyph = '';
          if (this.state.ui.sortField === id) {
            sortGlyph = <span>&nbsp;<Glyphicon glyph={ this.state.ui.sortDesc ? 'sort-by-attributes-alt' : 'sort-by-attributes' }/></span>;
          }
          return <th id={ id } onClick={ this.sort }>{ title }{ sortGlyph }</th>;
        };

        return <Table condensed striped>
          <thead>
            <tr>
              { buildHeader('ownerName', 'Owner') }
              { buildHeader('districtName', 'District') }
              { buildHeader('homeTerminal', 'Home Terminal') }
              { buildHeader('icbcRegistrationNumber', 'Regi') }
              { buildHeader('unitNumber', 'Fleet Unit #') }
              { buildHeader('permitNumber', 'Permit') }
              { buildHeader('nextInspectionDate', 'Next Inspection') }
              { buildHeader('inspectorName', 'Inspector') }
              <th></th>
            </tr>
          </thead>
          <tbody>
          {
            _.map(schoolBuses, (bus) => {
              return <tr key={ bus.id } className={ bus.status != 'Active' ? 'info' : null }>
                <td><a href={ bus.ownerPath }>{ bus.ownerName }</a></td>
                <td>{ bus.districtName }</td>
                <td>{ bus.homeTerminalCityPostal }</td>
                <td>{ bus.icbcRegistrationNumber }</td>
                <td>{ bus.unitNumber }</td>
                <td>{ bus.permitNumber }</td>
                <td>{ formatDateTime(bus.nextInspectionDate, 'MM/DD/YYYY') }
                  { bus.isReinspection ? <BadgeLabel bsStyle="info">R</BadgeLabel> : null }
                  { bus.isOverdue ? <BadgeLabel bsStyle="danger">!</BadgeLabel> : null }
                </td>
                <td>{ bus.inspectorName }</td>
                <td style={{ textAlign: 'right' }}>
                  <LinkContainer to={{ pathname: 'school-buses/' + bus.id }}>
                    <Button title="edit" bsSize="xsmall"><Glyphicon glyph="edit" /></Button>
                  </LinkContainer>
                </td>
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
    districts: state.lookups.districts,
    inspectors: state.models.inspectors,
    cities: state.lookups.cities,
    schoolDistricts: state.lookups.schoolDistricts,
    owners: state.models.owners,
    favourites: state.models.favourites,
    search: state.search.schoolBuses,
    ui: state.ui.schoolBuses,
  };
}

export default connect(mapStateToProps)(SchoolBuses);
