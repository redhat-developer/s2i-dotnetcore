import React from 'react';

import { Button } from 'react-bootstrap';

import _ from 'lodash';

import ModalDialog from './ModalDialog.jsx';

var EditDialog = React.createClass({
  propTypes: {
    title: React.PropTypes.node,
    didChange: React.PropTypes.func.isRequired,
    isValid: React.PropTypes.func.isRequired,
    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool.isRequired,
    className: React.PropTypes.string,
    readOnly: React.PropTypes.bool,
    saveText: React.PropTypes.string,
    closeText: React.PropTypes.string,
    children: React.PropTypes.node,
  },

  save() {
    if (this.props.isValid() === true) {
      if (this.props.didChange() === true) {
        this.props.onSave();
      } else {
        this.props.onClose();
      }
    }
  },

  render() {
    var props = _.omit(this.props, 'className', 'onSave', 'didChange', 'isValid', 'updateState', 'saveText', 'closeText');

    return <ModalDialog backdrop="static" className={ `edit-dialog ${this.props.className || ''}` } { ...props } footer={
      <span>
        <Button onClick={ this.props.onClose }>{ this.props.closeText || 'Close' }</Button>
        {
          this.props.readOnly || <Button bsStyle="primary" onClick={ this.save }>{ this.props.saveText || 'Save' }</Button>
        }
      </span>
    }/>;
  },
});

export default EditDialog;
