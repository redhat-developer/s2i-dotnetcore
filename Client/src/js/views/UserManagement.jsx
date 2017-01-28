import React from 'react';

import { connect } from 'react-redux';

import { Well, Alert, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, Button, ButtonGroup, Glyphicon, Checkbox } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';
import Promise from 'bluebird';

import * as Api from '../api';
import store from '../store';

import Confirm from '../components/Confirm.jsx';
import Favourites from '../components/Favourites.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';

/*
Create a search screen for user management. Search criteria can be just name for now, and we can add additional criteria later.

List of results should include:

First Name
Surname
SM User ID
home Service Area.

Include an "Add" button the screen to add a new user.

By default, show only active users, but include a checkbox to "Show Inactive" and show them when checked.

TODO:
* Print / Email

*/
var UserManagement = React.createClass({
  propTypes: {
    currentUser : React.PropTypes.object,
    users : React.PropTypes.object,
    favourites: React.PropTypes.object,
    search: React.PropTypes.object,
    ui: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: false,

      search: {
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
    };

    return searchParams;
  },

  componentDidMount() {
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
      this.fetch();
    });
  },

  fetch() {
    this.setState({ loading: true });
    Api.getUsers(this.buildSearchParams()).finally(() => {
      this.setState({ loading: false });
    });
  },

  updateSearchState(state, callback) {
    this.setState({ search: { ...this.state.search, ...state, ...{ loaded: true } }}, () =>{
      store.dispatch({ type: 'UPDATE_USERS_SEARCH', users: this.state.search });
      if (callback) { callback(); }
    });
  },

  updateUIState(state, callback) {
    this.setState({ ui: { ...this.state.ui, ...state }}, () =>{
      store.dispatch({ type: 'UPDATE_USERS_UI', users: this.state.ui });
      if (callback) { callback(); }
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

  email() {

  },

  print() {

  },

  delete(user) {
    console.debug(`delete ${user.name}!`);
  },

  render() {
    return <div id="users-list">
      <Well id="users-bar" bsSize="small" className="clearfix">
        <Row>
          <Col md={10}>
            <ButtonToolbar id="users-search">
              <Checkbox inline checked={ this.state.search.hideInactive } onChange={ this.hideInactiveSelected }>Hide Inactive</Checkbox>
              <Button id="search-button" bsStyle="primary" onClick={ this.fetch }>Search</Button>
            </ButtonToolbar>
          </Col>
          <Col md={1}>
            <Favourites id="users-faves-dropdown" type="user" favourites={ this.props.favourites } onAdd={ this.saveFavourite } onSelect={ this.loadFavourite } />
          </Col>
          <Col md={1}>
            <div id="users-buttons">
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
        if (Object.keys(this.props.users).length === 0) { return <Alert bsStyle="success">No users</Alert>; }

        var users = _.sortBy(this.props.users, this.state.ui.sortField);
        if (this.state.ui.sortDesc) {
          _.reverse(users);
        }

        var headers = [
          { field: 'surname',   title: 'Surname'    },
          { field: 'givenName', title: 'First Name' },
          { field: 'initials',  title: 'Initials'   },
          { field: 'blank' },
        ];

        return <SortTable sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={ headers }>
          {
            _.map(users, (user) => {
              return <tr key={ user.id } className={ user.active ? null : 'info' }>
                <td>{ user.surname }</td>
                <td>{ user.givenName }</td>
                <td>{ user.initials }</td>
                <td style={{ textAlign: 'right' }}>
                  <ButtonGroup>
                    <LinkContainer to={{ pathname: 'user-management/' + user.id }}>
                      <Button title="edit" bsSize="xsmall"><Glyphicon glyph="edit" /></Button>
                    </LinkContainer>
                    <OverlayTrigger trigger="click" placement="top" rootClose overlay={ <Confirm onConfirm={ this.delete.bind(this, user) }/> }>
                      <Button title="delete" bsSize="xsmall"><Glyphicon glyph="trash" /></Button>
                    </OverlayTrigger>
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
    currentUser : state.user,
    users       : state.models.users,
    favourites: state.models.favourites,
    search: state.search.users,
    ui: state.ui.users,
  };
}

export default connect(mapStateToProps)(UserManagement);
