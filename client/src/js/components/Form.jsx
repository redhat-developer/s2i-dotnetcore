import PropTypes from 'prop-types';
import React from 'react';
import { Form as BootstrapForm } from 'react-bootstrap';

const Form = (props) => {
  const { children, onSubmit, ...rest } = props;

  function formSubmited(e) {
    e.preventDefault();

    if (onSubmit) {
      onSubmit(e);
    }
  }

  return (
    <BootstrapForm {...rest} data-react-form="true" onSubmit={formSubmited}>
      {children}
    </BootstrapForm>
  );
};

Form.propTypes = {
  children: PropTypes.node,
  onSubmit: PropTypes.func,
};

export default Form;
