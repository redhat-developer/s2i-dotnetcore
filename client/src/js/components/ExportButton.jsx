import PropTypes from 'prop-types';
import React from 'react';
import classNames from 'classnames';
import { Glyphicon } from 'react-bootstrap';

import TooltipButton from './TooltipButton.jsx';

const ExportButton = ({ id, className, disabled, disabledTooltip, children, onClick }) => {
  return (
    <TooltipButton
      id={id}
      className={classNames('export-button', 'hidden-export', className)}
      onClick={onClick}
      disabled={disabled}
      disabledTooltip={disabledTooltip}
    >
      <Glyphicon glyph="download-alt" title="Export" />
      <span>{children}</span>
    </TooltipButton>
  );
};

ExportButton.propTypes = {
  id: PropTypes.string,
  className: PropTypes.string,
  title: PropTypes.string,
  disabled: PropTypes.bool,
  disabledTooltip: PropTypes.node,
  children: PropTypes.node,
};

ExportButton.defaultProps = {
  //disabledTooltip: 'Please perform a search to Export',
  disabledTooltip: 'This feature has not been released yet.',
};

export default ExportButton;
