import React from 'react';
import { connect } from 'react-redux';
import { PageHeader } from 'react-bootstrap';

import Spinner from '../components/Spinner.jsx';


var SchoolBusesEdit = React.createClass({
  propTypes: {
    schoolBus: React.PropTypes.object,
    params: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: false,
    };
  },

  render: function() {
    return <div id="school-buses-edit">
      <PageHeader>School Buses Detail</PageHeader>

      {(() => {
        if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

        return <h2>Editing { this.props.params.schoolBusId }</h2>;
      })()}

    </div>;
  },
});


function mapStateToProps(state) {
  return {
    schoolBus: state.models.schoolBuses,
  };
}

export default connect(mapStateToProps)(SchoolBusesEdit);
