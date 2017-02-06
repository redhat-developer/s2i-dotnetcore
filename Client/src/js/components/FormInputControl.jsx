import React from 'react';

import { FormControl } from 'react-bootstrap';

import _ from 'lodash';

var FormInputControl = React.createClass({
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
      var value = e.target.value;
      if (this.props.type === 'number' ) {
        value = parseInt(value, 10);
        if (_.isNaN(value)) {
          value = '';
        }
      }
      this.props.updateState({ [e.target.id]: value });
    }
  },

  render() {
    var props = _.omit(this.props, 'updateState');

    return <FormControl { ...props } onChange={ this.changed }>
      { this.props.children }
    </FormControl>;
  },
});

export default FormInputControl;
