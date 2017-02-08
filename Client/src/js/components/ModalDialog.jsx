import React from 'react';

import { Modal } from 'react-bootstrap';

import _ from 'lodash';

var ModalDialog = React.createClass({
  propTypes: {
    title: React.PropTypes.node,
    footer: React.PropTypes.node,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool.isRequired,
    children: React.PropTypes.node,
  },

  render() {
    var props = _.omit(this.props, 'title', 'footer', 'onClose');

    return <Modal onHide={ this.props.onClose } { ...props }>
      <Modal.Header closeButton>
        { this.props.title &&
          <Modal.Title>
            { this.props.title }
          </Modal.Title>
        }
      </Modal.Header>
      <Modal.Body>
        { this.props.children }
      </Modal.Body>
      { this.props.footer &&
        <Modal.Footer>
          { this.props.footer }
        </Modal.Footer>
      }
    </Modal>;
  },
});

export default ModalDialog;
