import PropTypes from 'prop-types';
import React from 'react';
import { Button, OverlayTrigger, Tooltip } from 'react-bootstrap';

const TooltipButton = ({
  className,
  style,
  bsStyle,
  bsSize,
  disabled,
  disabledTooltip,
  enabledTooltip,
  onClick,
  children,
}) => {
  var buttonStyle = disabled ? { ...style, pointerEvents: 'none' } : style;

  var button = (
    <Button
      style={buttonStyle}
      className={className}
      bsStyle={bsStyle}
      bsSize={bsSize}
      disabled={disabled}
      onClick={onClick}
    >
      {children}
    </Button>
  );

  var tooltipContent = disabled ? disabledTooltip : enabledTooltip;
  if (tooltipContent) {
    return (
      <OverlayTrigger placement="bottom" rootClose overlay={<Tooltip id="button-tooltip">{tooltipContent}</Tooltip>}>
        <div style={{ display: 'inline-block', cursor: 'not-allowed' }}>{button}</div>
      </OverlayTrigger>
    );
  } else {
    return button;
  }
};

TooltipButton.propTypes = {
  disabled: PropTypes.bool,
  children: PropTypes.node,
  enabledTooltip: PropTypes.node,
  disabledTooltip: PropTypes.node,
  onClick: PropTypes.func,
  className: PropTypes.string,
  style: PropTypes.object,
  bsSize: PropTypes.string,
  bsStyle: PropTypes.string,
};

export default TooltipButton;
