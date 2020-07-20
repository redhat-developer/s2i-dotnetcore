import React from "react";
import PropTypes from "prop-types";

import { Button, Form, Row, Col } from "react-bootstrap";
import ModalDialog from "../../components/ModalDialog.jsx";

class EmailSendFailDialog extends React.Component {
  static propTypes = {
    errorMessage: PropTypes.string,
    onRetry: PropTypes.func.isRequired,
    onClose: PropTypes.func.isRequired,
    show: PropTypes.bool,
  };

  onRetry = () => {
    this.props.onRetry();
  };

  onClose = () => {
    this.props.onClose();
  };

  render() {
    var errorMessage = this.props.errorMessage;
    return (
      <ModalDialog
        id="emailSendFailDialog"
        backdrop="static"
        bsSize="lg"
        show={this.props.show}
        onClose={this.props.onClose}
        title={<strong>Message</strong>}
        footer={
          <span>
            <Button title="yes" bsStyle="primary" onClick={this.onRetry}>
              Retry
            </Button>
            <Button title="no" onClick={this.onClose}>
              Close
            </Button>
          </span>
        }
      >
        <Form>
          <Row>
            <Col md={12}>
              {(() => {
                return (
                  <div>
                    <h4>Email send fail.</h4>
                    <h4>{errorMessage}</h4>
                  </div>
                );
              })()}
            </Col>
          </Row>
        </Form>
      </ModalDialog>
    );
  }
}

export default EmailSendFailDialog;
