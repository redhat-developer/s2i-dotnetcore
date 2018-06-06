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
          return <strong>Deselect Primary Contact?</strong>;
        }
        if(!isPrimary && checkboxValue && hasPrimary){
          return <strong>Change Primary Contact?</strong>;
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
                return <div><h4>This action will leave the school bus owner without a primary contact.</h4>
                <h4>Are you sure you wish to deselect a primary contact from the school bus owner?</h4></div>;
              }
              if(!isPrimary && checkboxValue && hasPrimary){
                return <div><h4>A school bus owner can have only one primary contact.</h4>
                <h4>Do you want to change the school bus owner's primary contact to the current contact?</h4></div>;
              }
            })()}
          </Col>
        </Row>
      </Form>
    </ModalDialog>;
  },
});

export default PrimaryChangeConfirmDialog;