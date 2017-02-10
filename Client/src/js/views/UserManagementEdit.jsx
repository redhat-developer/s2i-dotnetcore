import React from 'react';

import { connect } from 'react-redux';

import { PageHeader } from 'react-bootstrap';

import * as Api from '../api';

import Spinner from '../components/Spinner.jsx';

/*

For a given user (accessed by clicking on a user from the user search screen) show:
  First Name
  Surname
  SM Id (IDIR)
  Home Service Area
  Active/Not Active status

Enable editing the data so that the user can update all the fields.

It should be possible to invoke the screen in add mode for adding a new user to the system.

*/

var UserManagementEdit = React.createClass({
  propTypes: {
    user: React.PropTypes.object,
    params: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: true,
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
