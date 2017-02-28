import React from 'react';

import { connect } from 'react-redux';

import { PageHeader, Well, Alert, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, Button, ButtonGroup, Glyphicon } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';

import * as Action from '../actionTypes';
import * as Api from '../api';
import store from '../store';

import Confirm from '../components/Confirm.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';
import SearchControl from '../components/SearchControl.jsx';
import SortTable from '../components/SortTable.jsx';
import Spinner from '../components/Spinner.jsx';
import Unimplemented from '../components/Unimplemented.jsx';


var Roles = React.createClass({
  propTypes: {
    roles: React.PropTypes.object,
    currentUser: React.PropTypes.object,
    search: React.PropTypes.object,
    ui: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: true,

      search: {
        key: this.props.search.key || 'name',
        text: this.props.search.text || '',
        params: this.props.search.params || null,
      },

      ui : {
        sortField: this.props.ui.sortField || 'name',
        sortDesc: this.props.ui.sortDesc === true,
      },
    };
  },

  componentDidMount() {
    this.fetch();
  },

  fetch() {
    this.setState({ loading: true });
    Api.searchRoles().finally(() => {
      this.setState({ loading: false });
    });
  },

  updateSearchState(state, callback) {
    this.setState({ search: { ...this.state.search, ...state }}, () =>{
      store.dispatch({ type: Action.UPDATE_ROLES_SEARCH, roles: this.state.search });
      if (callback) { callback(); }
    });
  },

  updateUIState(state, callback) {
    this.setState({ ui: { ...this.state.ui, ...state }}, () =>{
      store.dispatch({ type: Action.UPDATE_ROLES_UI, roles: this.state.ui });
      if (callback) { callback(); }
    });
  },

  delete(role) {
    Api.deleteRole(role).then(() => {
      this.fetch();
    });
  },

  email() {

  },

  print() {

  },

  render: function() {
    var numRoles = this.state.loading ? '...' : Object.keys(this.props.roles).length;

    return <div id="roles-list">
      <PageHeader>Roles ({ numRoles })
        <ButtonGroup id="roles-buttons">
          <Unimplemented>
            <Button onClick={ this.email }><Glyphicon glyph="envelope" title="E-mail" /></Button>
          </Unimplemented>
          <Unimplemented>
            <Button onClick={ this.print }><Glyphicon glyph="print" title="Print" /></Button>
          </Unimplemented>
        </ButtonGroup>
      </PageHeader>
      <div>
        <Well id="roles-bar" bsSize="small" className="clearfix">
          <Row>
            <Col md={12}>
              <ButtonToolbar id="roles-search">
                <SearchControl id="search" search={ this.state.search } updateState={ this.updateSearchState }
                  items={[
                    { id: 'name',        name: 'Name' },
                    { id: 'description', name: 'Description' },
                  ]}
                />
              </ButtonToolbar>
            </Col>
          </Row>
        </Well>

        {(() => {
          if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

          var addRoleButton = <LinkContainer to={{ pathname: 'roles/0' }}>
            <Button title="Add Role" bsSize="xsmall"><Glyphicon glyph="plus" />&nbsp;<strong>Add Role</strong></Button>
          </LinkContainer>;
          if (Object.keys(this.props.roles).length === 0) { return <Alert bsStyle="success">No roles { addRoleButton }</Alert>; }

          var roles = _.sortBy(_.filter(this.props.roles, role => {
            if (!this.state.search.params) {
              return true;
            }
            return role[this.state.search.key] && role[this.state.search.key].toLowerCase().indexOf(this.state.search.text.toLowerCase()) !== -1;
          }), this.state.ui.sortField);

          if (this.state.ui.sortDesc) {
            _.reverse(roles);
          }

          return <SortTable sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={[
            { field: 'name',        title: 'Name'    },
            { field: 'description', title: 'Description' },
            { field: 'addRole',     title: 'Add Role',  style: { textAlign: 'right'  },
              node: addRoleButton,
            },
          ]}>
            {
              _.map(roles, (role) => {
                return <tr key={ role.id }>
                  <td>{ role.name }</td>
                  <td>{ role.description }</td>
                  <td style={{ textAlign: 'right' }}>
                    <ButtonGroup>
                      <OverlayTrigger trigger="click" placement="top" rootClose overlay={ <Confirm onConfirm={ this.delete.bind(this, role) }/> }>
                        <Button className={ role.canDelete ? '' : 'hidden' } title="Delete Role" bsSize="xsmall"><Glyphicon glyph="trash" /></Button>
                      </OverlayTrigger>
                      <LinkContainer to={{ pathname: 'roles/' + role.id }}>
                        <Button className={ role.canEdit ? '' : 'hidden' } title="Edit Role" bsSize="xsmall"><Glyphicon glyph="pencil" /></Button>
                      </LinkContainer>
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
    roles: state.models.roles,
    search: state.search.roles,
    ui: state.ui.roles,
  };
}

export default connect(mapStateToProps)(Roles);
