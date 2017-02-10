import React from 'react';

import { connect } from 'react-redux';

import { Well, Alert, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, Button, ButtonGroup, Glyphicon } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';
import Moment from 'moment';
import Promise from 'bluebird';

import * as Action from '../actionTypes';
import * as Api from '../api';
import store from '../store';

import BadgeLabel from '../components/BadgeLabel.jsx';
import CheckboxControl from '../components/CheckboxControl.jsx';
import Confirm from '../components/Confirm.jsx';
import DateControl from '../components/DateControl.jsx';
import DropdownControl from '../components/DropdownControl.jsx';
import Favourites from '../components/Favourites.jsx';
import FilterDropdown from '../components/FilterDropdown.jsx';
import KeySearchControl from '../components/KeySearchControl.jsx';
import MultiDropdown from '../components/MultiDropdown.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';

import { formatDateTime } from '../utils/date';

/*

* System default should be:
** If user is an inspector, Inspector == Current User else not used
** If the user is not an inspector, Districts in home district, else not used

TODO:
* Print / Email

*/

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
    params: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: true,

      ownedById: this.props.params.ownerId,

      search: {
        selectedDistrictsIds: this.props.search.selectedDistrictsIds || [],
        selectedInspectorsIds: this.props.search.selectedInspectorsIds || [],
        selectedCitiesIds: this.props.search.selectedCitiesIds || [],
        selectedSchoolDistrictsIds: this.props.search.selectedSchoolDistrictsIds || [],
        ownerId: this.props.search.ownerId || 0,
        ownerName: this.props.search.ownerName || 'Owner',
        keySearchField: this.props.search.keySearchField,
        keySearchText: this.props.search.keySearchText,
        keySearchParams: this.props.search.keySearchParams,
        nextInspection: this.props.search.nextInspection || WITHIN_30_DAYS,
        startDate: this.props.search.startDate || '',
        endDate: this.props.search.endDate || '',
        hideInactive: this.props.search.hideInactive !== false,
        justReInspections: this.props.search.justReInspections === true,
      },

      ui : {
        sortField: this.props.ui.sortField || 'ownerName',
        sortDesc: this.props.ui.sortDesc === true,
      },
    };
  },

  buildSearchParams() {
    if (this.state.search.keySearchParams) {
      // Use key search control params if there
      return this.state.search.keySearchParams;
    }

    var searchParams = {
      includeInactive: !this.state.search.hideInactive,
      onlyReInspections: this.state.search.justReInspections,
      owner: this.state.search.ownerId || '',
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
      if (this.state.ownedById) {
        // We're looking for a specific owner's school buses, so we'll set up state accordingly
        this.updateSearchState({
          ownerId: parseInt(this.state.ownedById, 10),
          selectedDistrictsIds: [],
          selectedInspectorsIds: [],
          selectedCitiesIds: [],
          selectedSchoolDistrictsIds: [],
          ownerName: this.props.owners[this.state.ownedById] ? this.props.owners[this.state.ownedById].name : '',
          keySearchField: this.props.search.keySearchField,
          keySearchText: '',
          keySearchParams: null,
          nextInspection: ALL,
          startDate: '',
          endDate: '',
          hideInactive: false,
          justReInspections: false,
        }, this.fetch);
      } else {
        if (!this.props.search.loaded) {
          // This is the first load so look for a default favourite
          var favourite = _.find(this.props.favourites, (favourite) => { return favourite.isDefault; });
          if (favourite) {
            this.loadFavourite(favourite);
            return;
          }
        }
        this.fetch();
      }
    });
  },

  fetch() {
    this.setState({ loading: true });
    Api.searchSchoolBuses(this.buildSearchParams()).finally(() => {
      this.setState({ loading: false });
    });
  },

  updateSearchState(state, callback) {
    this.setState({ search: { ...this.state.search, ...state, ...{ loaded: true } }}, () =>{
      store.dispatch({ type: Action.UPDATE_BUSES_SEARCH, schoolBuses: this.state.search });
      if (callback) { callback(); }
    });
  },

  updateUIState(state, callback) {
    this.setState({ ui: { ...this.state.ui, ...state }}, () =>{
      store.dispatch({ type: Action.UPDATE_BUSES_UI, schoolBuses: this.state.ui });
      if (callback) { callback(); }
    });
  },

  loadFavourite(favourite) {
    this.updateSearchState(JSON.parse(favourite.value), this.fetch);
  },

  delete(bus) {
    Api.deleteSchoolBus(bus).then(() => {
      this.fetch();
    });
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
                <MultiDropdown id="selectedDistrictsIds" placeholder="Districts"
                  items={ districts } selectedIds={ this.state.search.selectedDistrictsIds } updateState={ this.updateSearchState } showMaxItems={ 2 } />
                <MultiDropdown id="selectedInspectorsIds" placeholder="Inspectors"
                  items={ inspectors } selectedIds={ this.state.search.selectedInspectorsIds } updateState={ this.updateSearchState } showMaxItems={ 2 } />
                <MultiDropdown id="selectedCitiesIds" placeholder="Cities"
                  items={ cities } selectedIds={ this.state.search.selectedCitiesIds } updateState={ this.updateSearchState } showMaxItems={ 2 } />
                <MultiDropdown id="selectedSchoolDistrictsIds" placeholder="School Districts"
                  items={ schoolDistricts } selectedIds={ this.state.search.selectedSchoolDistrictsIds } fieldName="shortName" updateState={ this.updateSearchState } showMaxItems={ 2 } />
                <FilterDropdown id="ownerId" placeholder="Owner" blankLine
                  items={ owners } selectedId={ this.state.search.ownerId } updateState={ this.updateSearchState } />
                <KeySearchControl id="school-buses-key-search" search={ this.state.search } updateState={ this.updateSearchState }/>
              </ButtonToolbar>
            </Row>
            <Row>
              <ButtonToolbar id="school-buses-inspections">
                <DropdownControl id="nextInspection" title={ this.state.search.nextInspection } updateState={ this.updateSearchState }
                  items={[ ALL, BEFORE_TODAY, BEFORE_END_OF_MONTH, BEFORE_END_OF_QUARTER, TODAY, WITHIN_30_DAYS, THIS_MONTH, NEXT_MONTH, THIS_QUARTER, CUSTOM ]}
                />
                {(() => {
                  if (this.state.search.nextInspection === CUSTOM) {
                    return <span>
                      <DateControl id="startDate" date={ this.state.search.startDate } updateState={ this.updateSearchState } placeholder="mm/dd/yyyy" label="From:" title="start date"/>
                      <DateControl id="endDate" date={ this.state.search.endDate } updateState={ this.updateSearchState } placeholder="mm/dd/yyyy" label="To:" title="end date"/>
                    </span>;
                  }
                })()}
                <CheckboxControl inline id="hideInactive" checked={ this.state.search.hideInactive } updateState={ this.updateSearchState }>Hide Inactive</CheckboxControl>
                <CheckboxControl inline id="justReInspections" checked={ this.state.search.justReInspections } updateState={ this.updateSearchState }>Just Re-Inspections</CheckboxControl>
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
              <Favourites id="school-buses-faves-dropdown" type="schoolBus" favourites={ this.props.favourites } data={ this.state.search } onSelect={ this.loadFavourite } pullRight />
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

        return <SortTable sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={[
            { field: 'ownerName',              title: 'Owner'           },
            { field: 'districtName',           title: 'District'        },
            { field: 'homeTerminalCityPostal', title: 'Home Terminal'   },
            { field: 'icbcRegistrationNumber', title: 'Registration'    },
            { field: 'unitNumber',             title: 'Fleet Unit #'    },
            { field: 'permitNumber',           title: 'Permit'          },
            { field: 'nextInspectionDateSort', title: 'Next Inspection' },
            { field: 'inspectorName',          title: 'Inspector'       },
            { field: 'blank' },
        ]}>
          {
            _.map(schoolBuses, (bus) => {
              return <tr key={ bus.id } className={ bus.isActive ? null : 'info' }>
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
                  <ButtonGroup>
                    <OverlayTrigger trigger="click" placement="top" rootClose overlay={ <Confirm onConfirm={ this.delete.bind(this, bus) }/> }>
                      <Button className={ bus.canDelete ? '' : 'hidden' } title="deleteBus" bsSize="xsmall"><Glyphicon glyph="trash" /></Button>
                    </OverlayTrigger>
                    <LinkContainer to={{ pathname: 'school-buses/' + bus.id }}>
                      <Button className={ bus.canEdit ? '' : 'hidden' } title="editBus" bsSize="xsmall"><Glyphicon glyph="edit" /></Button>
                    </LinkContainer>

                  </ButtonGroup>
                </td>
              </tr>;
            })
          }
        </SortTable>;
      })()}

    </div>;
  },
});

function mapStateToProps(state) {
  return {
    schoolBuses: state.models.schoolBuses,
    districts: state.lookups.districts,
    inspectors: state.lookups.inspectors,
    cities: state.lookups.cities,
    schoolDistricts: state.lookups.schoolDistricts,
    owners: state.lookups.owners,
    favourites: state.models.favourites,
    search: state.search.schoolBuses,
    ui: state.ui.schoolBuses,
  };
}

export default connect(mapStateToProps)(SchoolBuses);
