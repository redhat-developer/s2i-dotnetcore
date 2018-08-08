import React from 'react';

import { Button, Form, Row, Col } from 'react-bootstrap';
import ModalDialog from '../../components/ModalDialog.jsx';

var EmailSendSuccessDialog = React.createClass({
  propTypes: {
    onConfirm: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
  },
  
  onConfirm(){
    this.props.onConfirm();
  },

  render(){
    return <ModalDialog id="emailSendConfirm" backdrop="static" bsSize="sm" show={this.props.show} onClose={this.onConfirm}
      title={<strong>Message</strong>} footer={
        <span>
            <Button title="ok" bsStyle="primary" onClick={ this.onConfirm }>Ok</Button>
        </span>
      }>
      <Form>
        <Row>
          <Col md={12}>
            {(() => {
              return <div><h4>Email has been sent successfully!</h4></div>;
            })()}
          </Col>
        </Row>
      </Form>
    </ModalDialog>;
  },
});

export default EmailSendSuccessDialog;