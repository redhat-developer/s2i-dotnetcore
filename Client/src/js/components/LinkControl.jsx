import React from 'react';

import { FormControl, InputGroup, ControlLabel, Button, Glyphicon } from 'react-bootstrap';

import _ from 'lodash';

var LinkControl = React.createClass({
  propTypes: {
    // url(value) returns a URL, default is value.
    url: React.PropTypes.func,
    value: React.PropTypes.string,
    id: React.PropTypes.string,
    label: React.PropTypes.string,
    title: React.PropTypes.string,
    className: React.PropTypes.string,
    updateState: React.PropTypes.func,
    onChange: React.PropTypes.func,
  },

  getInitialState() {
    return {
      url: this.getUrl(this.props.value),
    };
  },

  getUrl(value) {
    return this.props.url ? this.props.url(value) : value;
  },

  changed(e) {
    // On change listener
    if (this.props.onChange) {
      this.props.onChange(e);
    }

    // Update state
    if (this.props.updateState && e.target.id) {
      // Use e.target.id insted of this.props.id because it comes from the controlId.
      this.props.updateState({ [e.target.id]: e.target.value });
    }

    // Update href
    this.setState({
      url: this.getUrl(e.target.value),
    });
  },

  render() {
    var props = _.omit(this.props, 'updateState', 'url', 'id');

    return <div className={ `link-control ${this.props.className || ''}` } id={ this.props.id }>
      {(() => {
        // Inline label
        if (this.props.label) { return <ControlLabel>{ this.props.label }</ControlLabel>; }
      })()}
      <InputGroup>
        <FormControl { ...props } type="text" onChange={ this.changed }/>
        <InputGroup.Button>
          <Button target="_blank" href={ this.state.url }><Glyphicon glyph="link" title={ this.props.title }/></Button>
        </InputGroup.Button>
      </InputGroup>
    </div>;
  },
});

export default LinkControl;
