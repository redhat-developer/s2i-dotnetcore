import React from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';
import Confirm from '../components/Confirm.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';

const UpdateButton = (props) => {
  const { onConfirm, description, name, hide, ...rest } = props;
  return (
    <OverlayTrigger trigger="click" placement="top" rootClose overlay={<Confirm onConfirm={onConfirm} />}>
      <Button title={`${description}`} size="sm" color="primary" className={hide ? 'hidden' : ''} {...rest}>
        {name}
      </Button>
    </OverlayTrigger>
  );
};

UpdateButton.propTypes = {
  onConfirm: PropTypes.func.isRequired,
  name: PropTypes.string,
  hide: PropTypes.bool,
};

export default UpdateButton;
