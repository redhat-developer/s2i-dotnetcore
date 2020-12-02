import PropTypes from 'prop-types';
import React from 'react';
import classNames from 'classnames';
import { Modal, Button } from 'react-bootstrap';

import Form from './Form.jsx';
import Spinner from './Spinner.jsx';

const FormDialog = (props) => {
  const {
    children,
    saveButtonLabel,
    closeButtonLabel,
    isReadOnly,
    isSaving,
    onSubmit,
    onClose,
    id,
    className,
    title,
    show,
    bsSize,
  } = props;

  const closeDialog = () => {
    onClose();
  };

  const formSubmitted = () => {
    if (!isSaving) {
      onSubmit();
    }
  };

  const renderBody = () => {
    return (
      <Form onSubmit={formSubmitted}>
        <Modal.Body>{children}</Modal.Body>
        <Modal.Footer>
          <Button onClick={closeDialog}>{closeButtonLabel || 'Close'}</Button>
          {!isReadOnly && (
            <Button bsStyle="primary" type="submit" disabled={isSaving}>
              {saveButtonLabel || 'Save'}
              {isSaving && <Spinner />}
            </Button>
          )}
        </Modal.Footer>
      </Form>
    );
  };

  return (
    <Modal
      backdrop="static"
      id={id}
      bsSize={bsSize}
      className={classNames('form-dialog', className)}
      show={show}
      onHide={closeDialog}
    >
      <Modal.Header closeButton>{title && <Modal.Title>{title}</Modal.Title>}</Modal.Header>
      {show && renderBody()}
    </Modal>
  );
};

FormDialog.propTypes = {
  show: PropTypes.bool.isRequired,
  title: PropTypes.node,
  id: PropTypes.string,
  className: PropTypes.string,
  bsSize: PropTypes.string,
  isReadOnly: PropTypes.bool,
  isSaving: PropTypes.bool,
  onClose: PropTypes.func.isRequired,
  onSubmit: PropTypes.func,
  saveButtonLabel: PropTypes.string,
  closeButtonLabel: PropTypes.string,
  children: PropTypes.node,
};

export default FormDialog;
