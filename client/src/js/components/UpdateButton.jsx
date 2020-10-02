import React from 'react';
import PropTypes from 'prop-types';

import { Button, Glyphicon } from 'react-bootstrap';

import _ from 'lodash';

import Confirm from '../components/Confirm.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';

class UpdateButton extends React.Component {
  static propTypes = {
    onConfirm: PropTypes.func.isRequired,
    name: PropTypes.string,
    hide: PropTypes.bool,
  };

  render() {
    var props = _.omit(this.props, 'onConfirm', 'hide', 'name');

    return (
      <OverlayTrigger trigger="click" placement="top" rootClose overlay={<Confirm onConfirm={this.props.onConfirm} />}>
        <Button
          title={`${this.props.name}`}
          size="sm"
          color="primary"
          className={this.props.hide ? 'hidden' : ''}
          {...props}
        >
          {this.props.name}&nbsp;&nbsp;
          <Glyphicon glyph="floppy-disk" />
        </Button>
      </OverlayTrigger>
    );
  }
}

export default UpdateButton;
