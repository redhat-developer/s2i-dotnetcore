import React from 'react';

import { Button, Form, Row, Col } from 'react-bootstrap';
import ModalDialog from '../../components/ModalDialog.jsx';

var PrimaryChangeConfirmDialog = React.createClass({
  propTypes: {
    isPrimary: React.PropTypes.bool,
    hasPrimary: React.PropTypes.bool,
    checkboxValue: React.PropTypes.bool,

    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
  },
  
  onConfirm(){
    this.props.onSave(this.props.checkboxValue);
  },
  
  onReject(){
    this.props.onSave(!this.props.checkboxValue);
  },
  
  render(){
    var isPrimary = this.props.isPrimary;
    var checkboxValue = this.props.checkboxValue;
    var hasPrimary = this.props.hasPrimary;

    return <ModalDialog id="primaryChangeConfirm" backdrop="static" bsSize="sm" show={this.props.show} onClose={this.props.onClose}
      title={ (() => {
        if(isPrimary && !checkboxValue){
          return <strong>Remove primary contact</strong>;
        }
        if(!isPrimary && checkboxValue && hasPrimary){
          return <strong>Primary contact already existed</strong>;
        }
      })() } footer={
        <span>
            <Button title="yes" bsStyle="primary" onClick={ this.onConfirm }>Yes</Button>
            <Button title="no" onClick={ this.onReject }>No</Button>
        </span>
      }>
      <Form>
        <Row>
          <Col md={12}>
            {(() => {
              if(isPrimary && !checkboxValue){
                return <h4>Current contact is primary contact, do you wish to remove primary contact for current owner?</h4>;
              }
              if(!isPrimary && checkboxValue && hasPrimary){
                return <h4>Do you wish to update current contact to primary contact for current owner?</h4>;
              }
            })()}
          </Col>
        </Row>
      </Form>
    </ModalDialog>;
  },
});

export default PrimaryChangeConfirmDialog;