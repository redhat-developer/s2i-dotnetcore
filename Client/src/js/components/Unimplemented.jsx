import React from 'react';

import { OverlayTrigger, Tooltip } from 'react-bootstrap';

var Unimplemented = React.createClass({
  propTypes: {
    children: React.PropTypes.node,
  },

  render() {
    return <OverlayTrigger trigger={['hover', 'click']} placement="bottom" rootClose overlay={
      <Tooltip id="unimplemented">This feature has not been released yet.</Tooltip>
    }>
      { this.props.children }
    </OverlayTrigger>;
  },
});


export default Unimplemented;
