import React from 'react';
import { Popover, ButtonGroup, Button, Glyphicon } from 'react-bootstrap';

import _ from 'lodash';


var Confirm = React.createClass({
  propTypes: {
    onConfirm: React.PropTypes.func.isRequired,
    onCancel: React.PropTypes.func,
    hide: React.PropTypes.func,
    children: React.PropTypes.node,
  },

  confirmed() {
    this.props.onConfirm();
    this.props.hide();
  },

  canceled() {
    if (this.props.onCancel) { this.props.onCancel(); }
    this.props.hide();
  },

  render() {
    var props = _.omit(this.props, 'onConfirm', 'onCancel', 'hide', 'children');

    return <Popover id="confirm" title="Are you sure?" { ...props }>
      { this.props.children }
      <div style={{ textAlign: 'center', marginTop: '6px' }}>
        <ButtonGroup>
          <Button bsStyle="primary" onClick={ this.confirmed }><Glyphicon glyph="ok-circle" /> Yes</Button>
          <Button onClick={ this.canceled }><Glyphicon glyph="remove-circle" /> No</Button>
        </ButtonGroup>
      </div>
    </Popover>;
  },
});


export default Confirm;
