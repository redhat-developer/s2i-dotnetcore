import React from 'react';

import { connect } from 'react-redux';

import { PageHeader } from 'react-bootstrap';

var Notifications = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
  },

  render: function() {
    return <div id="notifications">
      <PageHeader>Notifications</PageHeader>
    </div>;
  },
});


function mapStateToProps(state) {
  return {
    currentUser: state.user,
  };
}

export default connect(mapStateToProps)(Notifications);
