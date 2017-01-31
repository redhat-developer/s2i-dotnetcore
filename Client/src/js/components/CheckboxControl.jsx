import React from 'react';

import { Checkbox } from 'react-bootstrap';

import _ from 'lodash';

var CheckboxControl = React.createClass({
  propTypes: {
    type: React.PropTypes.string,
    updateState: React.PropTypes.func,
    onChange: React.PropTypes.func,
    children: React.PropTypes.node,
  },

  changed(e) {
    // On change listener
    if (this.props.onChange) {
      this.props.onChange(e);
    }

    // Update state
    if (this.props.updateState && e.target.id) {
      // Use e.target.id insted of this.props.id because it comes from the controlId.
      this.props.updateState({ [e.target.id]: e.target.checked });
    }
  },

  render() {
    var props = _.omit(this.props, 'updateState');

    return <Checkbox { ...props } onChange={ this.changed }>
      { this.props.children }
    </Checkbox>;
  },
});

export default CheckboxControl;
