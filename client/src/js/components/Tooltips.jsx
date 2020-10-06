import React from 'react';
import PropTypes from 'prop-types';

import { OverlayTrigger, Tooltip } from 'react-bootstrap';

class Tooltips extends React.Component {
  static propTypes = {
    children: PropTypes.node,
  };

  render() {
    return (
      <OverlayTrigger
        trigger={['hover', 'click']}
        placement={this.props.placement}
        rootClose
        overlay={<Tooltip id="tooltips">{this.props.tooltips}</Tooltip>}
      >
        {this.props.children}
      </OverlayTrigger>
    );
  }
}

export default Tooltips;
