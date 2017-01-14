import React from 'react';
import { connect } from 'react-redux';
import { PageHeader } from 'react-bootstrap';

import Spinner from '../components/Spinner.jsx';

import * as Api from '../api';

var OwnersDetail = React.createClass({
  propTypes: {
    owner: React.PropTypes.object,
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
    // Make several owner calls here
    Api.getOwner(this.props.params.ownerId).finally(() => {
      this.setState({ loading: false });
    });
  },


  render: function() {
    return <div id="owners-detail">
      <PageHeader>Owner Details</PageHeader>

      {(() => {
        if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

        return <h2>Viewing { this.props.owner.name }</h2>;
      })()}

    </div>;
  },
});


function mapStateToProps(state) {
  return {
    owner: state.models.owner,
  };
}

export default connect(mapStateToProps)(OwnersDetail);
