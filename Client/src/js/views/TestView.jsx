import React from 'react';
import {connect} from 'react-redux';
import {Button} from 'react-bootstrap';

import * as api from '../api';
import store from '../store';


var TestView = React.createClass({
  propTypes: {
    testingStoreCount: React.PropTypes.number,
    numButtonClicks: React.PropTypes.number,
    actions: React.PropTypes.object,
  },

  clicked() {
    api.test();
    store.dispatch({ type: 'TEST_COUNT2', count: this.props.numButtonClicks + 1 });
  },

  render: function () {
    return <div>
      <Button onClick={this.clicked}>Click Me!</Button>
      <div>Number of times button clicked: {this.props.numButtonClicks}</div>
      <div>Count from API request: {this.props.testingStoreCount}</div>
    </div>;
  },
});



function mapStateToProps(state) {
  return {
    testingStoreCount: state.ui.testingStoreCount,
    numButtonClicks: state.ui.testingStoreCount2,
  };
}

export default connect(mapStateToProps)(TestView);
