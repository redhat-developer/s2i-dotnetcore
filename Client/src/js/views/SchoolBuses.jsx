import React from 'react';

import { connect } from 'react-redux';

import { PageHeader, Well, Alert, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, Button, ButtonGroup, Glyphicon } from 'react-bootstrap';

import _ from 'lodash';
import Moment from 'moment';
import Promise from 'bluebird';

import * as Action from '../actionTypes';
import * as Api from '../api';
import * as Constant from '../constants';
import store from '../store';

import BadgeLabel from '../components/BadgeLabel.jsx';
import CheckboxControl from '../components/CheckboxControl.jsx';
import DateControl from '../components/DateControl.jsx';
import DeleteButton from '../components/DeleteButton.jsx';
import DropdownControl from '../components/DropdownControl.jsx';
import EditButton from '../components/EditButton.jsx';
import Favourites from '../components/Favourites.jsx';
import FilterDropdown from '../components/FilterDropdown.jsx';
import KeySearchControl from '../components/KeySearchControl.jsx';
import MultiDropdown from '../components/MultiDropdown.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';
import SchoolBusesEmailDialog from '../views/dialogs/SchoolBusesEmailDialog.jsx';
import EmailSendSuccessDialog from '../views/dialogs/EmailSendSuccessDialog.jsx';
import EmailSendFailDialog from '../views/dialogs/EmailSendFailDialog.jsx';
import { formatDateTime, toZuluTime } from '../utils/date';

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
    currentUser: React.PropTypes.object,
    schoolBuses: React.PropTypes.object,
    districts: React.PropTypes.object,
    inspectors: React.PropTypes.object,
    cities: React.PropTypes.object,
    schoolDistricts: React.PropTypes.object,
    owners: React.PropTypes.object,
    favourites: React.PropTypes.object,
    search: React.PropTypes.object,
    ui: React.PropTypes.object,
    location: React.PropTypes.object,
  },

  getInitialState() {
    var defaultSelectedInspectors = this.props.currentUser.isInspector ? [ this.props.currentUser.id ] : [];
    var defaultSelectedDistricts = (this.props.currentUser.isInspector || !this.props.currentUser.district.id) ? [] : [ this.props.currentUser.district.id ];

    return {
      loading: true,
      showEmailDialog: false,
      showEmailSendConfirmDialog: false,
      showEmailSendFailDialog : false,
      email: {},
      emailSendErrorMessage: '',

      rightNow: Moment().format('MMMM Do YYYY, h:mm a'),
      search: {
        selectedDistrictsIds: this.props.search.selectedDistrictsIds || defaultSelectedDistricts,
        selectedInspectorsIds: this.props.search.selectedInspectorsIds || defaultSelectedInspectors,
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
        loaded: this.props.search.loaded === true,
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
      searchParams.startDate = toZuluTime(startDate.startOf('day'));
    }
    if (endDate && endDate.isValid()) {
      searchParams.endDate = toZuluTime(endDate.startOf('day'));
    }

    return searchParams;
  },

  componentDidMount() {
    this.setState({ loading: true });

    var inspectorsPromise = Api.getInspectors();
    var ownersPromise = Api.getOwners();
    var favouritesPromise = Api.getFavourites('schoolBus');

    Promise.all([inspectorsPromise, ownersPromise, favouritesPromise]).then(() => {
      if (this.props.location.search) {
        // Check for specific school bus query
        var state = {
          selectedDistrictsIds: [],
          selectedInspectorsIds: this.props.currentUser.isInspector ? [ this.props.currentUser.id ] : [],
          selectedCitiesIds: [],
          selectedSchoolDistrictsIds: [],
          ownerId: 0,
          ownerName: 'Owner',
          keySearchField: this.props.search.keySearchField,
          keySearchText: '',
          keySearchParams: null,
          nextInspection: WITHIN_30_DAYS,
          startDate: '',
          endDate: '',
          hideInactive: true,
          justReInspections: false,
        };

        if (this.props.location.query[Constant.SCHOOL_BUS_OWNER_QUERY]) {
          var ownerId = this.props.location.query[Constant.SCHOOL_BUS_OWNER_QUERY];
          state.ownerId = parseInt(ownerId, 10);
          state.ownerName = this.props.owners[ownerId] ? this.props.owners[ownerId].name : '';
          state.nextInspection = ALL;
          state.selectedInspectorsIds = [];
        } else if (this.props.location.query[Constant.SCHOOL_BUS_OVERDUE_QUERY]) {
          state.nextInspection = BEFORE_TODAY;
        } else if (this.props.location.query[Constant.SCHOOL_BUS_REINSPECTIONS_QUERY]) {
          state.nextInspection = ALL;
          state.justReInspections = true;
        } else if (this.props.location.query[Constant.SCHOOL_BUS_NEXT_MONTH_QUERY]) {
          state.nextInspection = NEXT_MONTH;
        }

        this.updateSearchState(state, this.fetch);
      } else {
        if (!this.props.search.loaded) {
          // This is the first load so look for a default favourite
          var favourite = _.find(this.props.favourites, (favourite) => { return favourite.isDefault; });
          if (favourite) {
            this.loadFavourite(favourite);
          }
        }
        return this.fetch();
      }
    }).finally(() => {
      this.setState({ loading: false });
    });
  },

  fetch() {
    this.setState({ loading: true });
    return Api.searchSchoolBuses(this.buildSearchParams()).finally(() => {
      this.setState({ loading: false });
    });
  },

  updateSearchState(state, callback) {
    // Initializing the KeySearchControl causes a state change which we want to catch here by checking
    // state.keySearchOnMount; otherwise this will flag the search state as loaded before it actually is.
    var loaded = state.keySearchOnMount ? {} : { loaded: true };
    this.setState({ search: { ...this.state.search, ...state, ...loaded }}, () =>{
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

  openEmailDialog() {
    this.setState({
      email: {},
      showEmailDialog: true, 
    });
  },

  sendEmail(email){
    this.closeEmailDialog();

    Api.sendEmail(email).then(response => {
      if (response != undefined && response != null && response.mailSent != undefined && response.mailSent == true){//get valid response from server
        this.openEmailSendConfirm();
      } else {//invalid response from server or mailSent == false
        this.openEmailSendFail(email, response);
      }
    }).catch(err => {//when server pod down or get response from server timeout
      this.openEmailSendFail(email, err);
    });
  },

  retryEmailSend(){
    this.closeEmailSendFail();
    this.setState({ showEmailDialog: true });
  },

  closeEmailDialog(){
    this.setState({ showEmailDialog: false });
  },

  openEmailSendConfirm(){
    this.setState({ showEmailSendConfirmDialog: true });
  },

  closeEmailSendConfirm(){
    this.setState({ showEmailSendConfirmDialog: false });
  },

  openEmailSendFail(email, response){
    if(response == undefined || response == null || response.mailSent == undefined || response.mailSent == null){
      this.setState({//if not getting response from server, customize the error message
        email: email,
        emailSendErrorMessage: 'An error occurred sending email. Server response timeout. Please try again later.',
        showEmailSendFailDialog: true,
      });
    } else {//get error message from server, use its error message
      this.setState({ 
        email: email,
        emailSendErrorMessage: response.errorInfo + ' Please try again later.',
        showEmailSendFailDialog: true,
      });
    }
  },

  closeEmailSendFail(){
    this.setState({ showEmailSendFailDialog: false });
  },

  printSelectedDropdownItems(allItems, selectedItemIds) {
    var print = [];

    for(var i = 0; i < selectedItemIds.length; i++) {
      for(var a = 0; a < allItems.length; a++) {
        if(allItems[a].id == selectedItemIds[i]) {
          print.push(allItems[a].name);	
        }
      }
    }
    print = print.join(', ');
    return print.toString();
  },

  printSelectedOwner(allOwners, ownerId){
    var owner = '';
    if(ownerId !== null){
      var index = _.findIndex(allOwners,['id', ownerId]);
      owner = allOwners[index].name;
    }
    return owner;
  },

  print() {
    this.setState({rightNow: Moment().format('MMMM Do YYYY, h:mm a')}, () => {
      window.print();
    });
  },

  render() {
    var districts = _.sortBy(this.props.districts, 'name');
    var inspectors = _.sortBy(this.props.inspectors, 'name');
    var cities = _.sortBy(this.props.cities, 'name');
    var schoolDistricts = _.sortBy(this.props.schoolDistricts, 'name');
    var owners = _.sortBy(this.props.owners, 'name');

    var numBuses = this.state.loading ? '...' : Object.keys(this.props.schoolBuses).length;

    return <div id="school-buses-list">
      <PageHeader id="pageHeader-print">School Bus Inspection Report: {this.state.rightNow}</PageHeader>
      <PageHeader id="subPageHeader-print">School Buses ({ numBuses })
        <ButtonGroup id="email-print-buttonGroup">
            <Button onClick={ this.openEmailDialog }><Glyphicon glyph="envelope" title="E-mail" /></Button>
            <Button onClick={ this.print }><Glyphicon glyph="print" title="Print" /></Button>
        </ButtonGroup>
      </PageHeader>
      <Well id="school-buses-bar" bsSize="small" className="clearfix">
        <Row>
          <Col md={10}>
            <Row>
              <ButtonToolbar id="school-buses-filters">
                <MultiDropdown id="selectedDistrictsIds" placeholder="Districts"
                  items={ districts } selectedIds={ this.state.search.selectedDistrictsIds } updateState={ this.updateSearchState } showMaxItems={ 2 } />
                <MultiDropdown id="selectedInspectorsIds" placeholder="Inspectors"
                  items={ inspectors } selectedIds={ this.state.search.selectedInspectorsIds } updateState={ this.updateSearchState } showMaxItems={ 2 } />
                <MultiDropdown id="selectedCitiesIds" placeholder="Cities"
                  items={ cities } selectedIds={ this.state.search.selectedCitiesIds } updateState={ this.updateSearchState } showMaxItems={ 2 } />
                <MultiDropdown id="selectedSchoolDistrictsIds" placeholder="School Districts"
                  items={ schoolDistricts } selectedIds={ this.state.search.selectedSchoolDistrictsIds } fieldName="shortName" updateState={ this.updateSearchState } showMaxItems={ 2 } />
                <FilterDropdown id="ownerId" placeholder="Owner" blankLine="(All)"
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
                      <DateControl id="startDate" date={ this.state.search.startDate } updateState={ this.updateSearchState } placeholder="mm/dd/yyyy" label="From:" title="Start Date"/>
                      <DateControl id="endDate" date={ this.state.search.endDate } updateState={ this.updateSearchState } placeholder="mm/dd/yyyy" label="To:" title="End date"/>
                    </span>;
                  }
                })()}
                <CheckboxControl inline id="hideInactive" checked={ this.state.search.hideInactive } updateState={ this.updateSearchState }>Hide Inactive</CheckboxControl>
                <CheckboxControl inline id="justReInspections" checked={ this.state.search.justReInspections } updateState={ this.updateSearchState }>Re-Inspections</CheckboxControl>
              </ButtonToolbar>
            </Row>
          </Col>
          <Col md={2}>
            <Row id="school-buses-faves">
              <Favourites id="school-buses-faves-dropdown" type="schoolBus" favourites={ this.props.favourites } data={ this.state.search } onSelect={ this.loadFavourite } pullRight />
            </Row>
            <Row id="school-buses-search">
              <Button id="search-button" bsStyle="primary" onClick={ this.fetch }>Search</Button>
            </Row>
          </Col>
        </Row>
      </Well>

      <Well id="searchCriteria-print" bsSize="small">
        <Row>
          <Col xs={6}><h2>Search Criteria</h2></Col>
          <Col xs={6}><h2>School Buses ({numBuses})</h2></Col>
          {(() => {
            if(this.state.search.selectedDistrictsIds.length !== 0) {
              if(this.state.search.selectedDistrictsIds.length == districts.length){
                return <Col xs={6}>
                  <span style={{fontWeight:'bold'}}>Districts: </span><span>(All districts) </span>
                </Col>;
              }else{
                return <Col xs={6}>
                  <span style={{fontWeight:'bold'}}>Districts: </span><span>{this.printSelectedDropdownItems(districts, this.state.search.selectedDistrictsIds)}</span>
                </Col>;
              }
            }
          })()}
          {(() => {
            if(this.state.search.selectedSchoolDistrictsIds.length !== 0){
              if(this.state.search.selectedSchoolDistrictsIds.length == schoolDistricts.length){
                return <Col xs={6}>
                  <span style={{fontWeight:'bold'}}>School Districts: </span><span>(All school districts) </span>
                </Col>;
              }else{
                return <Col xs={6}>
                  <span style={{fontWeight:'bold'}}>School Districts: </span><span>{this.printSelectedDropdownItems(schoolDistricts, this.state.search.selectedSchoolDistrictsIds)}</span>
                </Col>;
              }
            }
          })()}
          {(() => {
            if(this.state.search.selectedCitiesIds.length !== 0){
              if(this.state.search.selectedCitiesIds.length == cities.length){
                return <Col xs={6}>
                  <span style={{fontWeight:'bold'}}>Cities: </span><span>(All cities) </span>
                </Col>;
              }else{
                return <Col xs={6}>
                  <span style={{fontWeight:'bold'}}>Cities: </span><span>{this.printSelectedDropdownItems(cities, this.state.search.selectedCitiesIds)} </span>
                </Col>;
              }
            }
          })()}
          {(() => {
            if(this.state.search.ownerId !== 0){
              return <Col xs={6}>
                <span style={{fontWeight:'bold'}}>Owners: </span><span>{this.printSelectedOwner(owners, this.state.search.ownerId)} </span>
              </Col>;
            } else {
              return <Col xs={6}>
                <span style={{fontWeight:'bold'}}>Owners: </span><span>(All owners) </span>
              </Col>;
            }
          })()}
          {(() => {
            if(this.state.search.selectedInspectorsIds.length !== 0){
              if(this.state.search.selectedInspectorsIds.length == inspectors.length){
                return <Col xs={6}>
                  <span style={{fontWeight:'bold'}}>Inspectors: </span><span>(All inspectors) </span>
                </Col>;
              }else{
                return <Col xs={6}>
                  <span style={{fontWeight:'bold'}}>Inspectors: </span><span>{this.printSelectedDropdownItems(inspectors, this.state.search.selectedInspectorsIds)} </span>
                </Col>;
              }
            }
          })()}
          {(() => {
            if(this.state.search.keySearchText !== ''){
              return <Col xs={6}>
                <span style={{fontWeight:'bold'}}>{this.state.search.keySearchField}: </span><span>{this.state.search.keySearchText} </span>
              </Col>;
            }
          })()}
          <Col xs={12}>
            {this.state.search.nextInspection==CUSTOM ?
              <span><span style={{fontWeight:'bold'}}>From: </span>{this.state.search.startDate} <span style={{fontWeight:'bold'}}>To: </span>{this.state.search.endDate} </span> : <span style={{fontWeight:'bold'}}>{this.state.search.nextInspection}  </span>
            }
            <CheckboxControl inline checked={ this.state.search.hideInactive }>Hide Inactive</CheckboxControl>
            <CheckboxControl inline checked={ this.state.search.justReInspections }>Re-Inspections</CheckboxControl>
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
            { field: 'unitNumber',             title: 'Unit Number'     },
            { field: 'permitNumber',           title: 'Permit'          },
            { field: 'nextInspectionDateSort', title: 'Next Inspection' },
            { field: 'inspectorName',          title: 'Inspector'       },
            { field: 'details', noSort: true,  title: 'Details'         },
        ]}>
          {
            _.map(schoolBuses, (bus) => {
              return <tr key={ bus.id } className={ bus.isActive ? null : 'info' }>
                <td><a href={ bus.ownerURL }>{ bus.ownerName }</a></td>
                <td>{ bus.districtName }</td>
                <td>{ bus.homeTerminalCityPostal }</td>
                <td>{ bus.canView ? <a href={ bus.url }>{ bus.icbcRegistrationNumber }</a> : bus.icbcRegistrationNumber }</td>
                <td>{ bus.unitNumber }</td>
                <td>{ bus.permitNumber }</td>
                <td><span id="tdNextInspection">{ formatDateTime(bus.nextInspectionDate, Constant.DATE_SHORT_MONTH_DAY_YEAR) }</span>
                  <span id="tdBadgeLabels">{ bus.isReinspection ? <BadgeLabel bsStyle="info">R</BadgeLabel> : null }
                  { bus.isOverdue ? <BadgeLabel bsStyle="danger">!</BadgeLabel> : null }</span>
                </td>
                <td>{ bus.inspectorName }</td>
                <td style={{ textAlign: 'right' }}>
                  <ButtonGroup id="view-edit-buttonGroup">
                    <DeleteButton name="Bus" hide={ !bus.canDelete } onConfirm={ this.delete.bind(this, bus) }/>
                    <EditButton name="Bus" hide={ !bus.canView } view pathname={ bus.path }/>
                  </ButtonGroup>
                </td>
              </tr>;
            })
          }
        </SortTable>;
      })()}
      { this.state.showEmailDialog &&
      <SchoolBusesEmailDialog schoolBuses={this.props.schoolBuses} show={this.state.showEmailDialog} onSave={this.sendEmail} 
      onClose={this.closeEmailDialog} email={this.state.email}/> }
      { this.state.showEmailSendConfirmDialog &&
      <EmailSendSuccessDialog show={this.state.showEmailSendConfirmDialog} onConfirm={this.closeEmailSendConfirm}/> }
      { this.state.showEmailSendFailDialog &&
      <EmailSendFailDialog show={this.state.showEmailSendFailDialog} onClose={this.closeEmailSendFail} 
      onRetry={this.retryEmailSend} errorMessage={this.state.emailSendErrorMessage}/> }
    </div>;
  },
});

function mapStateToProps(state) {
  return {
    currentUser: state.user,
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
