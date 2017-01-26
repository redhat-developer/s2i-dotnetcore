import React from 'react';

import { connect } from 'react-redux';

import { PageHeader } from 'react-bootstrap';

import * as Api from '../api';

import Spinner from '../components/Spinner.jsx';

var UserManagementEdit = React.createClass({
  propTypes: {
    user: React.PropTypes.object,
    params: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: false,
    };
  },

  componentDidMount() {
    this.fetch();
  },

  fetch() {
    this.setState({ loading: true });
    // Make several user calls here
    Api.getUser(this.props.params.userId).finally(() => {
      this.setState({ loading: false });
    });
  },


  render: function() {
    return <div id="user-management-edit">
      <PageHeader>User Management Edit</PageHeader>

      {(() => {
        if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

        return <h2>Editing { this.props.user.name }</h2>;
      })()}

    </div>;
  },
});


function mapStateToProps(state) {
  return {
    user: state.models.user,
  };
}

export default connect(mapStateToProps)(UserManagementEdit);
