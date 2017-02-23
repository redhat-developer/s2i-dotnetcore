import React from 'react';

import { connect } from 'react-redux';

import { PageHeader } from 'react-bootstrap';

var RolesDetail = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
    params: React.PropTypes.object,
  },

  render: function() {
    return <div id="notifications">
      <PageHeader>Editing Role</PageHeader>
      This feature has not been released yet.
    </div>;
  },
});


function mapStateToProps(state) {
  return {
    currentUser: state.user,
  };
}

export default connect(mapStateToProps)(RolesDetail);
