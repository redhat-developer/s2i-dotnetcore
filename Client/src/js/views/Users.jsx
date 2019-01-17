import React from 'react';

import { connect } from 'react-redux';

import { PageHeader, Well, Alert, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, Button, ButtonGroup, Glyphicon, InputGroup } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';
import Promise from 'bluebird';

import * as Action from '../actionTypes';
import * as Api from '../api';
import * as Constant from '../constants';
import store from '../store';

import CheckboxControl from '../components/CheckboxControl.jsx';
import DeleteButton from '../components/DeleteButton.jsx';
import EditButton from '../components/EditButton.jsx';
import Favourites from '../components/Favourites.jsx';
import FormInputControl from '../components/FormInputControl.jsx';
import MultiDropdown from '../components/MultiDropdown.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';
import Unimplemented from '../components/Unimplemented.jsx';


var UserManagement = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
    users: React.PropTypes.object,
    user: React.PropTypes.object,
    districts: React.PropTypes.object,
    favourites: React.PropTypes.object,
    search: React.PropTypes.object,
    ui: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: true,

      search: {
        selectedDistrictsIds: this.props.search.selectedDistrictsIds || [],
        surname: this.props.search.surname || '',
        hideInactive: this.props.search.hideInactive !== false,
      },

      ui : {
        sortField: this.props.ui.sortField || 'surname',
        sortDesc: this.props.ui.sortDesc === true,
      },
    };
  },

  buildSearchParams() {
    var searchParams = {
      includeInactive: !this.state.search.hideInactive,
      surname: this.state.search.surname,
    };

    if (this.state.search.selectedDistrictsIds.length > 0 && this.state.search.selectedDistrictsIds.length != _.size(this.props.districts)) {
      searchParams.districts = this.state.search.selectedDistrictsIds;
    }

    return searchParams;
  },

  componentDidMount() {
    this.setState({ loading: true });

    var favouritesPromise = Api.getFavourites('user');

    Promise.all([favouritesPromise]).then(() => {
      // If this is the first load, then look for a default favourite
      if (!this.props.search.loaded) {
        var favourite = _.find(this.props.favourites, (favourite) => { return favourite.isDefault; });
        if (favourite) {
          this.loadFavourite(favourite);
          return;
        }
      }
      return this.fetch();
    }).finally(() => {
      this.setState({ loading: false });
    });
  },

  fetch() {
    this.setState({ loading: true });
    return Api.searchUsers(this.buildSearchParams()).finally(() => {
      this.setState({ loading: false });
    });
  },

  updateSearchState(state, callback) {
    this.setState({ search: { ...this.state.search, ...state, ...{ loaded: true } }}, () =>{
      store.dispatch({ type: Action.UPDATE_USERS_SEARCH, users: this.state.search });
      if (callback) { callback(); }
    });
  },

  updateUIState(state, callback) {
    this.setState({ ui: { ...this.state.ui, ...state }}, () =>{
      store.dispatch({ type: Action.UPDATE_USERS_UI, users: this.state.ui });
      if (callback) { callback(); }
    });
  },

  loadFavourite(favourite) {
    this.updateSearchState(JSON.parse(favourite.value), this.fetch);
  },

  delete(user) {
    Api.deleteUser(user).then(() => {
      this.fetch();
    });
  },

  email() {

  },

  print() {

  },

  render() {
    var districts = _.sortBy(this.props.districts, 'name');

    var numUsers = this.state.loading ? '...' : Object.keys(this.props.users).length;

    return <div id="users-list">
      <PageHeader>Users ({ numUsers })
        <ButtonGroup id="users-buttons">
          <Unimplemented>
            <Button onClick={ this.email }><Glyphicon glyph="envelope" title="E-mail" /></Button>
          </Unimplemented>
          <Unimplemented>
            <Button onClick={ this.print }><Glyphicon glyph="print" title="Print" /></Button>
          </Unimplemented>
        </ButtonGroup>
      </PageHeader>
      <div>
        <Well id="users-bar" bsSize="small" className="clearfix">
          <Row>
            <Col md={10}>
              <ButtonToolbar id="users-search">
                <MultiDropdown id="selectedDistrictsIds" placeholder="Districts"
                  items={ districts } selectedIds={ this.state.search.selectedDistrictsIds } updateState={ this.updateSearchState } showMaxItems={ 2 } />
                <InputGroup>
                  <InputGroup.Addon>Surname</InputGroup.Addon>
                  <FormInputControl id="surname" type="text" value={ this.state.search.surname } updateState={ this.updateSearchState }/>
                </InputGroup>
                <CheckboxControl inline id="hideInactive" checked={ this.state.search.hideInactive } updateState={ this.updateSearchState }>Hide Inactive</CheckboxControl>
                <Button id="search-button" bsStyle="primary" onClick={ this.fetch }>Search</Button>
              </ButtonToolbar>
            </Col>
            <Col md={2}>
              <Row id="users-faves">
                <Favourites id="users-faves-dropdown" type="user" favourites={ this.props.favourites } data={ this.state.search } onSelect={ this.loadFavourite } pullRight />
              </Row>
            </Col>
          </Row>
        </Well>

        {(() => {
          if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

          var addUserButton = <LinkContainer to={{ pathname: `${ Constant.USERS_PATHNAME }/0` }}>
            <Button title="Add User" bsSize="xsmall"><Glyphicon glyph="plus" />&nbsp;<strong>Add User</strong></Button>
          </LinkContainer>;
          if (Object.keys(this.props.users).length === 0) { return <Alert bsStyle="success">No users { addUserButton }</Alert>; }

          var users = _.sortBy(this.props.users, this.state.ui.sortField);
          if (this.state.ui.sortDesc) {
            _.reverse(users);
          }

          return <SortTable sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={[
            { field: 'surname',      title: 'Surname'    },
            { field: 'givenName',    title: 'First Name' },
            { field: 'smUserId',     title: 'User ID'    },
            { field: 'districtName', title: 'District'   },
            { field: 'addUser',      title: 'Add User',  style: { textAlign: 'right'  },
              node: addUserButton,
            },
          ]}>
            {
              _.map(users, (user) => {
                return <tr key={ user.id } className={ user.active ? null : 'info' }>
                  <td>{ user.surname }</td>
                  <td>{ user.givenName }</td>
                  <td>{ user.smUserId }</td>
                  <td>{ user.districtName }</td>
                  <td style={{ textAlign: 'right' }}>
                    <ButtonGroup>
                      <DeleteButton name="User" hide={ !user.canDelete } onConfirm={ this.delete.bind(this, user) }/>
                      <EditButton name="User" hide={ !user.canEdit } view pathname={ user.path }/>
                    </ButtonGroup>
                  </td>
                </tr>;
              })
            }
          </SortTable>;
        })()}
      </div>
    </div>;
  },
});

function mapStateToProps(state) {
  return {
    currentUser: state.user,
    users: state.models.users,
    user: state.models.user,
    districts: state.lookups.districts,
    favourites: state.models.favourites,
    search: state.search.users,
    ui: state.ui.users,
  };
}

export default connect(mapStateToProps)(UserManagement);
