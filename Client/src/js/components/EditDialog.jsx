import React from 'react';

import { Modal, Button } from 'react-bootstrap';

import _ from 'lodash';

var EditDialog = React.createClass({
  propTypes: {
    title: React.PropTypes.node,
    didChange: React.PropTypes.func.isRequired,
    isValid: React.PropTypes.func.isRequired,
    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool.isRequired,
    children: React.PropTypes.node,
  },

  save() {
    if (this.props.isValid()) {
      if (this.props.didChange()) {
        this.props.onSave();
      } else {
        this.props.onClose();
      }
    }
  },

  render() {
    var props = _.omit(this.props, 'title', 'body', 'onSave', 'onClose', 'didChange', 'isValid', 'updateState');

    return <Modal onHide={ this.props.onClose } { ...props }>
      <Modal.Header closeButton>
        <Modal.Title>
          { this.props.title }
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        { this.props.children }
      </Modal.Body>
      <Modal.Footer>
        <Button onClick={ this.props.onClose }>Close</Button>
        <Button bsStyle="primary" onClick={ this.save }>Save</Button>
      </Modal.Footer>
    </Modal>;
  },
});

export default EditDialog;
