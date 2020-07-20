import React from "react";
import PropTypes from "prop-types";

import { Modal } from "react-bootstrap";

import _ from "lodash";

class ModalDialog extends React.Component {
  static propTypes = {
    title: PropTypes.node,
    footer: PropTypes.node,
    onClose: PropTypes.func.isRequired,
    show: PropTypes.bool.isRequired,
    children: PropTypes.node,
  };

  render() {
    var props = _.omit(this.props, "title", "footer", "onClose");

    return (
      <Modal onHide={this.props.onClose} {...props}>
        <Modal.Header closeButton>
          {this.props.title && <Modal.Title>{this.props.title}</Modal.Title>}
        </Modal.Header>
        <Modal.Body>{this.props.children}</Modal.Body>
        {this.props.footer && <Modal.Footer>{this.props.footer}</Modal.Footer>}
      </Modal>
    );
  }
}

export default ModalDialog;
