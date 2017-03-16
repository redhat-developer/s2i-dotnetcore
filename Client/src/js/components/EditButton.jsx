import React from 'react';

import { Button, Glyphicon } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import _ from 'lodash';


var EditButton = React.createClass({
  propTypes: {
    pathname: React.PropTypes.string,
    onClick: React.PropTypes.func,
    // view as opposed to edit, i.e. read only
    view: React.PropTypes.bool,
    name: React.PropTypes.string,
    hide: React.PropTypes.bool,
  },

  render() {
    var props = _.omit(this.props, 'view', 'name', 'hide', 'pathname');

    var button = <Button title={ `${ this.props.view ? 'View' : 'Edit' } ${ this.props.name }` } bsSize="xsmall" className={ this.props.hide ? 'hidden' : '' } { ...props }>
      <Glyphicon glyph={ this.props.view ? 'edit' : 'pencil' } />
    </Button>;

    return this.props.pathname ? <LinkContainer to={{ pathname: this.props.pathname }}>{ button }</LinkContainer> : button;
  },
});


export default EditButton;
