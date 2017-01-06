import React from 'react';
import { Popover, ButtonGroup, Button, Glyphicon } from 'react-bootstrap';

import _ from 'lodash';


var Confirm = React.createClass({
  propTypes: {
    params: React.PropTypes.object,
    onConfirm: React.PropTypes.func,
    onCancel: React.PropTypes.func,
    hide: React.PropTypes.func,
  },

  confirmed() {
    if (this.props.onConfirm) { this.props.onConfirm(this.props.params); }
    this.props.hide();
  },

  canceled() {
    if (this.props.onCancel) { this.props.onCancel(this.props.params); }
    this.props.hide();
  },

  render() {
    var props = _.omit(this.props, 'onConfirm', 'onCancel', 'hide', 'params');

    return <Popover id="confirm" title="Are you sure?" {...props}>
      <ButtonGroup>
        <Button bsStyle="primary" onClick={ this.confirmed }><Glyphicon glyph="ok-circle" /> Yes</Button>
        <Button onClick={ this.canceled }><Glyphicon glyph="remove-circle" /> No</Button>
      </ButtonGroup>
    </Popover>;
  },
});


export default Confirm;
