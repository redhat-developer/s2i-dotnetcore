import React from 'react';
import { Label } from 'react-bootstrap';


var BadgeLabel = React.createClass({
  propTypes: {
    bsClass: React.PropTypes.string,
    bsStyle: React.PropTypes.string,
    children: React.PropTypes.node,
  },

  render() {
    return <Label bsClass={ this.props.bsClass } bsStyle={ this.props.bsStyle } className="badge-label">
      { this.props.children }
    </Label>;
  },
});


export default BadgeLabel;
