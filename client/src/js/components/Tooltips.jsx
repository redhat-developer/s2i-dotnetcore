import React from 'react';
import PropTypes from 'prop-types';
import { OverlayTrigger, Tooltip } from 'react-bootstrap';

const Tooltips = ({ placement, text, children }) => {
  return (
    <OverlayTrigger
      trigger={['hover', 'click']}
      placement={placement}
      rootClose
      overlay={<Tooltip id="tooltips">{text}</Tooltip>}
    >
      {children}
    </OverlayTrigger>
  );
};

Tooltips.propTypes = {
  children: PropTypes.node,
};

export default Tooltips;
