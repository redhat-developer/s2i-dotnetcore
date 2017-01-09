import React from 'react';
import { connect } from 'react-redux';
import { PageHeader } from 'react-bootstrap';

var Owners = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
  },

  render: function() {
    return <div id="owners">
      <PageHeader>Owners</PageHeader>
    </div>;
  },
});


function mapStateToProps(state) {
  return {
    currentUser: state.user,
  };
}

export default connect(mapStateToProps)(Owners);
