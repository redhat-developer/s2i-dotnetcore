import React from 'react';

import { DropdownButton } from 'react-bootstrap';

import _ from 'lodash';

var DropdownControl = React.createClass({
  propTypes: {
    updateState: React.PropTypes.func,
    onSelect: React.PropTypes.func,
    children: React.PropTypes.node,
  },

  dropdownSelected(keyEvent, e) {
    // On select listener
    if (this.props.onSelect) {
      this.props.onSelect(keyEvent, e);
    }

    // Update state
    if (this.props.updateState && e.target.name) {
      this.props.updateState({
        [e.target.name]: keyEvent,
      });
    }
  },

  render() {
    var props = _.omit(this.props, 'updateState');

    return <DropdownButton { ...props } onSelect={ this.dropdownSelected }>
      {
        // Every child item must have a 'name' attribute for UpdateState to work
      }
      { this.props.children }
    </DropdownButton>;
  },
});

export default DropdownControl;
