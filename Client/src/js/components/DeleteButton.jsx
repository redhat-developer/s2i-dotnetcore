import React from 'react';

import { Button, Glyphicon } from 'react-bootstrap';

import _ from 'lodash';

import Confirm from '../components/Confirm.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';


var DeleteButton = React.createClass({
  propTypes: {
    onConfirm: React.PropTypes.func.isRequired,
    name: React.PropTypes.string,
    hide: React.PropTypes.bool,
  },

  render() {
    var props = _.omit(this.props, 'onConfirm', 'hide', 'name');

    return <OverlayTrigger trigger="click" placement="top" rootClose overlay={ <Confirm onConfirm={ this.props.onConfirm }/> }>
      <Button title={ `Delete ${ this.props.name }` } bsSize="xsmall" className={ this.props.hide ? 'hidden' : '' } { ...props }><Glyphicon glyph="trash" /></Button>
    </OverlayTrigger>;
  },
});


export default DeleteButton;
