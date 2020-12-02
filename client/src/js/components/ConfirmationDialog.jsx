import React from 'react';
import PropTypes from 'prop-types';

import { Button, Form, Row, Col } from 'react-bootstrap';
import ModalDialog from './ModalDialog.jsx';

const ConfirmationDialog = ({ title, children, onConfirm, onReject, show }) => {
  return (
    <ModalDialog
      id="confirmation-dialog"
      backdrop="static"
      bsSize="sm"
      show={show}
      onClose={onReject}
      title={title}
      footer={
        <span>
          <Button title="yes" bsStyle="primary" onClick={onConfirm}>
            Yes
          </Button>
          <Button title="no" onClick={onReject}>
            No
          </Button>
        </span>
      }
    >
      <Form>
        <Row>
          <Col md={12}>{children}</Col>
        </Row>
      </Form>
    </ModalDialog>
  );
};

ConfirmationDialog.propTypes = {
  title: PropTypes.string.isRequired,
  onConfirm: PropTypes.func.isRequired,
  onReject: PropTypes.func.isRequired,
  show: PropTypes.bool,
};

export default ConfirmationDialog;
