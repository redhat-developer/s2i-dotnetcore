import React from 'react';
import { connect } from 'react-redux';
import { PageHeader } from 'react-bootstrap';

var SchoolBuses = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
  },

  render: function() {
    return <div id="school-buses">
      <PageHeader>School Buses</PageHeader>
    </div>;
  },
});


function mapStateToProps(state) {
  return {
    currentUser: state.user,
  };
}

export default connect(mapStateToProps)(SchoolBuses);
