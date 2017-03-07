import React from 'react';

import { Popover, Glyphicon, OverlayTrigger } from 'react-bootstrap';

import _ from 'lodash';


var InfoButton = React.createClass({
  propTypes: {
    title: React.PropTypes.string.isRequired,
    className: React.PropTypes.string,
    children: React.PropTypes.node,
  },

  render() {
    var props = _.omit(this.props, 'className', 'children');

    return <OverlayTrigger trigger="click" placement="right" rootClose
      overlay={ <Popover id="info" title={ this.props.title }>
        { this.props.children }
      </Popover> }
    >
      <Glyphicon className={ `info-button ${this.props.className || ''}` } { ...props } glyph="info-sign" />
    </OverlayTrigger>;
  },
});


export default InfoButton;
