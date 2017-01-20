import React from 'react';
import { Col } from 'react-bootstrap';


var ColField = React.createClass({
  propTypes: {
    style: React.PropTypes.object,
    children: React.PropTypes.node,
  },

  render() {
    return <Col { ...this.props } style={ { ...{ paddingLeft: 5 }, ...this.props.style } }>
      { this.props.children }
    </Col>;
  },
});

export default ColField;
