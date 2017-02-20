import React from 'react';
import { Col } from 'react-bootstrap';

import _ from 'lodash';


var ColDisplay = React.createClass({
  propTypes: {
    label: React.PropTypes.node,
    children: React.PropTypes.node,
  },

  render() {
    var props = _.omit(this.props, 'label', 'labelProps', 'fieldProps');

    return <Col { ...props }>
        <div style={{ float: 'left', textAlign: 'right'}} className="col-display-label">
          <strong>{ this.props.label }</strong>
        </div>
        <div style={{ float: 'left', paddingLeft: 10 }} className="col-display-field">
          { this.props.children }
        </div>
    </Col>;
  },
});


export default ColDisplay;
