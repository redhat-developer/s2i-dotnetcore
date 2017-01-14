import React from 'react';
import { connect } from 'react-redux';
import { PageHeader } from 'react-bootstrap';

var RolesPermissions = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
  },

  render: function() {
    return <div id="roles-permissions">
      <PageHeader>Roles and Permissions</PageHeader>
    </div>;
  },
});


function mapStateToProps(state) {
  return {
    currentUser: state.user,
  };
}

export default connect(mapStateToProps)(RolesPermissions);
