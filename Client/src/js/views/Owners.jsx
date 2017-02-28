import React from 'react';

import { connect } from 'react-redux';

import { PageHeader, Well, Alert, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, Button, ButtonGroup, Glyphicon } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';
import Promise from 'bluebird';

import OwnersAddDialog from './dialogs/OwnersAddDialog.jsx';

import * as Action from '../actionTypes';
import * as Api from '../api';
import * as Constant from '../constants';
import store from '../store';

import BadgeLabel from '../components/BadgeLabel.jsx';
import CheckboxControl from '../components/CheckboxControl.jsx';
import Confirm from '../components/Confirm.jsx';
import Favourites from '../components/Favourites.jsx';
import FilterDropdown from '../components/FilterDropdown.jsx';
import MultiDropdown from '../components/MultiDropdown.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';
import Unimplemented from '../components/Unimplemented.jsx';

import { formatDateTime } from '../utils/date';


var Owners = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
    ownerList: React.PropTypes.object,
    owner: React.PropTypes.object,
    districts: React.PropTypes.object,
    inspectors: React.PropTypes.object,
    owners: React.PropTypes.object,
    favourites: React.PropTypes.object,
    search: React.PropTypes.object,
    ui: React.PropTypes.object,
    router: React.PropTypes.object,
  },

  getInitialState() {
    var defaultSelectedInspectors = this.props.currentUser.isInspector ? [ this.props.currentUser.id ] : [];
    var defaultSelectedDistricts = (this.props.currentUser.isInspector || !this.props.currentUser.district.id) ? [] : [ this.props.currentUser.district.id ];

    return {
      loading: true,

      showAddDialog: false,

      search: {
        selectedDistrictsIds: this.props.search.selectedDistrictsIds || defaultSelectedDistricts,
        selectedInspectorsIds: this.props.search.selectedInspectorsIds || defaultSelectedInspectors,
        ownerId: this.props.search.ownerId || 0,
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
      owner: this.state.search.ownerId || '',
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

  loadFavourite(favourite) {
    this.updateSearchState(JSON.parse(favourite.value), this.fetch);
  },

  openAddDialog() {
    this.setState({ showAddDialog: true });
  },

  closeAddDialog() {
    this.setState({ showAddDialog: false });
  },

  saveNewOwner(owner) {
    Api.addOwner(owner).then(() => {
      // Open it up
      this.props.router.push({
        pathname: `owners/${ this.props.owner.id }`,
      });
    });
  },

  delete(owner) {
    Api.deleteOwner(owner).then(() => {
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
    var owners = _.sortBy(this.props.owners, 'name');

    var numOwners = this.state.loading ? '...' : Object.keys(this.props.ownerList).length;

    return <div id="owners-list">
      <PageHeader>Owners ({ numOwners })
        <ButtonGroup id="owners-buttons">
          <Unimplemented>
            <Button onClick={ this.email }><Glyphicon glyph="envelope" title="E-mail" /></Button>
          </Unimplemented>
          <Unimplemented>
            <Button onClick={ this.print }><Glyphicon glyph="print" title="Print" /></Button>
          </Unimplemented>
        </ButtonGroup>
      </PageHeader>
      <div>
        <Well id="owners-bar" bsSize="small" className="clearfix">
          <Row>
            <Col md={11}>
              <ButtonToolbar id="owners-search">
                <MultiDropdown id="selectedDistrictsIds" placeholder="Districts"
                  items={ districts } selectedIds={ this.state.search.selectedDistrictsIds } updateState={ this.updateSearchState } showMaxItems={ 2 }/>
                <MultiDropdown id="selectedInspectorsIds" placeholder="Inspectors"
                  items={ inspectors } selectedIds={ this.state.search.selectedInspectorsIds } updateState={ this.updateSearchState } showMaxItems={ 2 }/>
                <FilterDropdown id="ownerId" placeholder="Owner" blankLine
                  items={ owners } selectedId={ this.state.search.ownerId } updateState={ this.updateSearchState }/>
                <CheckboxControl inline id="hideInactive" checked={ this.state.search.hideInactive } updateState={ this.updateSearchState }>Hide Inactive</CheckboxControl>
                <Button id="search-button" bsStyle="primary" onClick={ this.fetch }>Search</Button>
              </ButtonToolbar>
            </Col>
            <Col md={1}>
              <Row id="owners-faves">
                <Favourites id="owners-faves-dropdown" type="owner" favourites={ this.props.favourites } data={ this.state.search } onSelect={ this.loadFavourite }/>
              </Row>
            </Col>
          </Row>
        </Well>

        {(() => {
          if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

          var addOwnerButton = <Button title="Add Owner" bsSize="xsmall" onClick={ this.openAddDialog }><Glyphicon glyph="plus" />&nbsp;<strong>Add Owner</strong></Button>;
          if (Object.keys(this.props.ownerList).length === 0) {
            return <Alert bsStyle="success">No owners { addOwnerButton }</Alert>;
          }

          var ownerList = _.sortBy(this.props.ownerList, this.state.ui.sortField);
          if (this.state.ui.sortDesc) {
            _.reverse(ownerList);
          }

          return <SortTable sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={[
            { field: 'name',                   title: 'Name'            },
            { field: 'primaryContactName',     title: 'Primary Contact' },
            { field: 'numberOfBuses',          title: 'School Buses',    style: { textAlign: 'center' } },
            { field: 'nextInspectionDateSort', title: 'Next Inspection' },
            { field: 'addOwner',               title: 'Add Owner',       style: { textAlign: 'right'  },
              node: addOwnerButton,
            },
          ]}>
            {
              _.map(ownerList, (owner) => {
                return <tr key={ owner.id } className={ owner.isActive ? null : 'info' }>
                  <td>{ owner.name }</td>
                  <td>{ owner.primaryContactName }</td>
                  <td style={{ textAlign: 'center' }}>
                    <a href={ `#school-buses?${ Constant.SCHOOL_BUS_OWNER_QUERY }=${ owner.id }` }>{ owner.numberOfBuses }</a>
                  </td>
                  <td>{ formatDateTime(owner.nextInspectionDate, Constant.DATE_SHORT_MONTH_DAY_YEAR) }
                    { owner.isReinspection ? <BadgeLabel bsStyle="info">R</BadgeLabel> : null }
                    { owner.isOverdue ? <BadgeLabel bsStyle="danger">!</BadgeLabel> : null }
                  </td>
                  <td style={{ textAlign: 'right' }}>
                    <ButtonGroup>
                      <OverlayTrigger trigger="click" placement="top" rootClose overlay={ <Confirm onConfirm={ this.delete.bind(this, owner) }/> }>
                        <Button className={ owner.canDelete ? '' : 'hidden' } title="Delete Owner" bsSize="xsmall"><Glyphicon glyph="trash" /></Button>
                      </OverlayTrigger>
                      <LinkContainer to={{ pathname: 'owners/' + owner.id }}>
                        <Button className={ owner.canEdit ? '' : 'hidden' } title="View Owner" bsSize="xsmall"><Glyphicon glyph="edit" /></Button>
                      </LinkContainer>
                    </ButtonGroup>
                  </td>
                </tr>;
              })
            }
          </SortTable>;
        })()}
      </div>
      { this.state.showAddDialog &&
        <OwnersAddDialog show={ this.state.showAddDialog } onSave={ this.saveNewOwner } onClose= { this.closeAddDialog } />
      }
    </div>;
  },
});


function mapStateToProps(state) {
  return {
    currentUser: state.user,
    ownerList: state.models.owners,
    owner: state.models.owner,
    districts: state.lookups.districts,
    inspectors: state.lookups.inspectors,
    owners: state.lookups.owners,
    favourites: state.models.favourites,
    search: state.search.owners,
    ui: state.ui.owners,
  };
}

export default connect(mapStateToProps)(Owners);
