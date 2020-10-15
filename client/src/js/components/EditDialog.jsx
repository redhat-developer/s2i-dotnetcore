import React from 'react';
import PropTypes from 'prop-types';

import { Button } from 'react-bootstrap';

import _ from 'lodash';

import ModalDialog from './ModalDialog.jsx';

class EditDialog extends React.Component {
  static propTypes = {
    title: PropTypes.node,
    didChange: PropTypes.func.isRequired,
    isValid: PropTypes.func.isRequired,
    needConfirmation: PropTypes.func,
    onSave: PropTypes.func.isRequired,
    onClose: PropTypes.func.isRequired,
    show: PropTypes.bool.isRequired,
    className: PropTypes.string,
    readOnly: PropTypes.bool,
    saveText: PropTypes.string,
    closeText: PropTypes.string,
    children: PropTypes.node,
  };

  save = () => {
    if (this.props.isValid() === true) {
      if (this.props.didChange() === true) {
        this.handleConfirmation();
      } else {
        this.props.onClose();
      }
    }
  };

  handleConfirmation = () => {
    if (typeof this.props.needConfirmation !== 'function') {
      this.props.onSave();
      return;
    }

    if (!this.props.needConfirmation()) {
      this.props.onSave();
      return;
    }
  };

  render() {
    var props = _.omit(
      this.props,
      'className',
      'onSave',
      'didChange',
      'isValid',
      'needConfirmation',
      'updateState',
      'saveText',
      'closeText'
    );

    return (
      <ModalDialog
        backdrop="static"
        className={`edit-dialog ${this.props.className || ''}`}
        {...props}
        footer={
          <span>
            <Button onClick={this.props.onClose}>{this.props.closeText || 'Close'}</Button>
            {this.props.readOnly || (
              <Button bsStyle="primary" onClick={this.save}>
                {this.props.saveText || 'Save'}
              </Button>
            )}
          </span>
        }
      />
    );
  }
}

export default EditDialog;
