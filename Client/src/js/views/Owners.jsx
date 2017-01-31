import React from 'react';

import { connect } from 'react-redux';

import { Well, Alert, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, MenuItem, Button, ButtonGroup, Glyphicon } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';
import Promise from 'bluebird';

import * as Action from '../actionTypes';
import * as Api from '../api';
import store from '../store';

import BadgeLabel from '../components/BadgeLabel.jsx';
import CheckboxControl from '../components/CheckboxControl.jsx';
import DropdownControl from '../components/DropdownControl.jsx';
import Favourites from '../components/Favourites.jsx';
import MultiDropdown from '../components/MultiDropdown.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';

import { formatDateTime } from '../utils/date';

/*

Default search rules:
  Set the "Inspector" field if the user is an inspector
  Set the "District" field if the user is NOT an inspector to the users home district

TODO:
* Print / Email

*/

var Owners = React.createClass({
  propTypes: {
    ownerList: React.PropTypes.object,
    districts: React.PropTypes.object,
    inspectors: React.PropTypes.object,
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
        ownerId: this.props.search.ownerId || '',
        ownerName: this.props.search.ownerName || 'Owner',
        hideInactive: this.props.search.hideInactive !== false,
      },

      ui : {
        sortField: this.props.ui.sortField || 'name',
        sortDesc: this.props.ui.sortDesc === true,
      },
    };
  },

  buildSearchParams() {
    var searchParams = {
      includeInactive: !this.state.search.hideInactive,
      owner: this.state.search.ownerId,
    };

    if (this.state.search.selectedDistrictsIds.length > 0) {
      searchParams.districts = this.state.search.selectedDistrictsIds;
    }
    if (this.state.search.selectedInspectorsIds.length > 0) {
      searchParams.inspectors = this.state.search.selectedInspectorsIds;
    }

    return searchParams;
  },

  componentDidMount() {
    this.setState({ loading: true });

    var inspectorsPromise = Api.getInspectors();
    var ownersPromise = Api.getOwners();
    var favouritesPromise = Api.getFavourites('owner');

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
    Api.searchOwners(this.buildSearchParams()).finally(() => {
      this.setState({ loading: false });
    });
  },

  updateSearchState(state, callback) {
    this.setState({ search: { ...this.state.search, ...state, ...{ loaded: true } }}, () =>{
      store.dispatch({ type: Action.UPDATE_OWNERS_SEARCH, owners: this.state.search });
      if (callback) { callback(); }
    });
  },

  updateUIState(state, callback) {
    this.setState({ ui: { ...this.state.ui, ...state }}, () =>{
      store.dispatch({ type: Action.UPDATE_OWNERS_UI, owners: this.state.ui });
      if (callback) { callback(); }
    });
  },

  ownerSelected(keyEvent, e) {
    this.updateSearchState({
      ownerId: keyEvent || '',
      ownerName: keyEvent !== 0 ? e.target.text : 'Owner',
    });
  },

  loadFavourite(favourite) {
    this.updateSearchState(JSON.parse(favourite.value), this.fetch);
  },

  email() {

  },

  print() {

  },

  render() {
    var districts = _.sortBy(this.props.districts, 'name');
    var inspectors = _.sortBy(this.props.inspectors, 'name');
    var owners = _.sortBy(this.props.owners, 'name');

    return <div id="owners-list">
      <Well id="owners-bar" bsSize="small" className="clearfix">
        <Row>
          <Col md={10}>
            <ButtonToolbar id="owners-search">
              <MultiDropdown id="selectedDistrictsIds" placeholder="Districts"
                items={ districts } selectedIds={ this.state.search.selectedDistrictsIds } updateState={ this.updateSearchState } showMaxItems={ 2 } />
              <MultiDropdown id="selectedInspectorsIds" placeholder="Inspectors"
                items={ inspectors } selectedIds={ this.state.search.selectedInspectorsIds } updateState={ this.updateSearchState } showMaxItems={ 2 } />
              <DropdownControl id="owners-owner-dropdown" title={ this.state.search.ownerName } onSelect={ this.ownerSelected }>
                <MenuItem key={ 0 } eventKey={ 0 }>&nbsp;</MenuItem>
                {
                  _.map(owners, (owner) => {
                    return <MenuItem key={ owner.id } eventKey={ owner.id }>{ owner.name }</MenuItem>;
                  })
                }
              </DropdownControl>
              <CheckboxControl inline id="hideInactive" checked={ this.state.search.hideInactive } updateState={ this.updateSearchState }>Hide Inactive</CheckboxControl>
              <Button id="search-button" bsStyle="primary" onClick={ this.fetch }>Search</Button>
            </ButtonToolbar>
          </Col>
          <Col md={1}>
            <Favourites id="owners-faves-dropdown" type="owner" favourites={ this.props.favourites } data={ this.state.search } onSelect={ this.loadFavourite } />
          </Col>
          <Col md={1}>
            <div id="owners-buttons">
              <ButtonGroup>
                <Button onClick={ this.email }><Glyphicon glyph="envelope" title="E-mail" /></Button>
                <Button onClick={ this.print }><Glyphicon glyph="print" title="Print" /></Button>
              </ButtonGroup>
            </div>
          </Col>
        </Row>
      </Well>

      {(() => {
        if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }
        if (Object.keys(this.props.ownerList).length === 0) { return <Alert bsStyle="success">No owners</Alert>; }

        var ownerList = _.sortBy(this.props.ownerList, this.state.ui.sortField);
        if (this.state.ui.sortDesc) {
          _.reverse(ownerList);
        }

        return <SortTable sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={[
          { field: 'name',                   title: 'Name'            },
          { field: 'primaryContactName',     title: 'Primary Contact' },
          { field: 'schoolBusCount',         title: 'School Buses',    style:{ textAlign: 'center' } },
          { field: 'nextInspectionDateSort', title: 'Next Inspection', style:{ textAlign: 'center' } },
          { field: 'blank' },
        ]}>
          {
            _.map(ownerList, (owner) => {
              return <tr key={ owner.id } className={ owner.status != 'Active' ? 'info' : null }>
                <td>{ owner.name }</td>
                <td>{ owner.primaryContactName }</td>
                <td style={{ textAlign: 'center' }}>{ owner.schoolBusCount }</td>
                <td style={{ textAlign: 'center' }}>{ formatDateTime(owner.nextInspectionDate, 'MM/DD/YYYY') }
                  { owner.isReinspection ? <BadgeLabel bsStyle="info">R</BadgeLabel> : null }
                  { owner.isOverdue ? <BadgeLabel bsStyle="danger">!</BadgeLabel> : null }
                </td>
                <td style={{ textAlign: 'right' }}>
                  <LinkContainer to={{ pathname: 'owners/' + owner.id }}>
                    <Button title="edit" bsSize="xsmall"><Glyphicon glyph="edit" /></Button>
                  </LinkContainer>
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
    ownerList: state.models.owners,
    districts: state.lookups.districts,
    inspectors: state.lookups.inspectors,
    owners: state.lookups.owners,
    favourites: state.models.favourites,
    search: state.search.owners,
    ui: state.ui.owners,
  };
}

export default connect(mapStateToProps)(Owners);
