import React from 'react';
import { Col } from 'react-bootstrap';


var ColLabel = React.createClass({
  propTypes: {
    className: React.PropTypes.string,
    children: React.PropTypes.node,
  },

  render() {
    return <Col { ...this.props } className={ `text-right ${this.props.className || ''}` }>
      <strong>{ this.props.children }</strong>
    </Col>;
  },
});

export default ColLabel;
