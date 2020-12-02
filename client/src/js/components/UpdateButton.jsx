import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

import Confirm from '../components/Confirm.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';

import TooltipButton from './TooltipButton.jsx';

const UpdateButton = (props) => {
  const { onConfirm, enabledTooltip, disabledTooltip, hide, disabled, className, children, ...rest } = props;
  return (
    <OverlayTrigger trigger="click" placement="top" rootClose overlay={<Confirm onConfirm={onConfirm} />}>
      <TooltipButton
        className={classNames(hide ? 'hidden update-button' : 'update-button', className)}
        disabled={disabled}
        disabledTooltip={disabledTooltip}
        enabledTooltip={enabledTooltip}
        {...rest}
      >
        <span>{children}</span>
      </TooltipButton>
    </OverlayTrigger>
  );
};

UpdateButton.propTypes = {
  onConfirm: PropTypes.func.isRequired,
  disabledTooltip: PropTypes.node,
  enabledTooltip: PropTypes.node,
  hide: PropTypes.bool,
  disabled: PropTypes.bool,
};

export default UpdateButton;
