import React from 'react';

import { connect } from 'react-redux';

import { Well, Alert, Table, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, DropdownButton, MenuItem, Button, ButtonGroup, Glyphicon, Checkbox } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';
import Promise from 'bluebird';

import * as Api from '../api';
import store from '../store';

import BadgeLabel from '../components/BadgeLabel.jsx';
import Favourites from '../components/Favourites.jsx';
import MultiDropdown from '../components/MultiDropdown.jsx';
import Spinner from '../components/Spinner.jsx';

import { formatDateTime } from '../utils/date';

/*

Pretty straight forward search after School Bus search.

All parameters (District, Inspector, Owner) are handled the same as for School Bus search.
  District and Inspector are searches on School Buses to find SB Owners that have buses in those Districts/assigned to those owners
  District and Inspector are not (currently) fields on the School Bus Owner record. We may add them later, but they aren't right now.

On the search results - display information about the Primary Contact

On the search results remove the "District" (currently Service Area) column, as it is not a unique field per SB Owner (on buses, not on SB Owner).

Default search rules:
  Set the "Inspector" field if the user is an inspector
  Set the "District" field if the user is NOT an inspector to the users home district

TODO:
* Print / Email

*/

var Owners = React.createClass({
  propTypes: {
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
    this.setState({ search: { ...this.state.search, ...state }}, () =>{
      store.dispatch({ type: 'UPDATE_OWNERS_SEARCH', owners: this.state.search });
      if (callback) { callback(); }
    });
  },

  updateUIState(state, callback) {
    this.setState({ ui: { ...this.state.ui, ...state }}, () =>{
      store.dispatch({ type: 'UPDATE_OWNERS_UI', owners: this.state.ui });
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

  ownerSelected(keyEvent, e) {
    this.updateSearchState({
      ownerId: keyEvent || '',
      ownerName: keyEvent !== 0 ? e.target.text : 'Owner',
    });
  },

  hideInactiveSelected(e) {
    this.updateSearchState({
      hideInactive: e.target.checked,
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
    var owners = _.sortBy(this.props.owners, 'name');

    return <div id="owners-list">
      <Well id="owners-bar" bsSize="small" className="clearfix">
        <Row>
          <Col md={10}>
            <ButtonToolbar id="owners-search">
              <MultiDropdown id="districts-dropdown" placeholder="Districts"
                items={ districts } selectedIds={ this.state.search.selectedDistrictsIds } onChange={ this.districtsChanged } showMaxItems={ 2 } />
              <MultiDropdown id="inspectors-dropdown" placeholder="Inspectors"
                items={ inspectors } selectedIds={ this.state.search.selectedInspectorsIds } onChange={ this.inspectorsChanged } showMaxItems={ 2 } />
              <DropdownButton id="owners-owner-dropdown" title={ this.state.search.ownerName } onSelect={ this.ownerSelected }>
                <MenuItem key={ 0 } eventKey={ 0 }>&nbsp;</MenuItem>
                {
                  _.map(owners, (owner) => {
                    return <MenuItem key={ owner.id } eventKey={ owner.id }>{ owner.name }</MenuItem>;
                  })
                }
              </DropdownButton>
              <Checkbox inline checked={ this.state.search.hideInactive } onChange={ this.hideInactiveSelected }>Hide Inactive</Checkbox>
              <Button id="search-button" bsStyle="primary" onClick={ this.fetch }>Search</Button>
            </ButtonToolbar>
          </Col>
          <Col md={1}>
            <Favourites id="owners-faves-dropdown" type="owner" favourites={ this.props.favourites } onAdd={ this.saveFavourite } onSelect={ this.loadFavourite } />
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
        if (Object.keys(this.props.owners).length === 0) { return <Alert bsStyle="success">No owners</Alert>; }

        var owners = _.sortBy(this.props.owners, this.state.ui.sortField);
        if (this.state.ui.sortDesc) {
          _.reverse(owners);
        }

        var buildHeader = (field, title, style) => {
          var sortGlyph = '';
          if (this.state.ui.sortField === field) {
            sortGlyph = <span>&nbsp;<Glyphicon glyph={ this.state.ui.sortDesc ? 'sort-by-attributes-alt' : 'sort-by-attributes' }/></span>;
          }
          return <th id={ field } onClick={ this.sort } style={{ ...style, cursor: 'pointer' }}>{ title }{ sortGlyph }</th>;
        };

        return <Table condensed striped>
          <thead>
            <tr>
              { buildHeader('name', 'Name') }
              { buildHeader('primaryContactName', 'Primary Contact') }
              { buildHeader('schoolBusCount', 'School Buses', { textAlign: 'center' }) }
              { buildHeader('nextInspectionDate', 'Next Inspection', { textAlign: 'center' }) }
              <th></th>
            </tr>
          </thead>
          <tbody>
          {
            _.map(owners, (owner) => {
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
          </tbody>
        </Table>;
      })()}

    </div>;
  },
});


function mapStateToProps(state) {
  return {
    districts: state.lookups.districts,
    inspectors: state.lookups.inspectors,
    owners: state.lookups.owners,
    favourites: state.models.favourites,
    search: state.search.owners,
    ui: state.ui.owners,
  };
}

export default connect(mapStateToProps)(Owners);
