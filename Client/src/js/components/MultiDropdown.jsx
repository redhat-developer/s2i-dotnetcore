import React from 'react';
import { Dropdown, FormControl, MenuItem } from 'react-bootstrap';

import _ from 'lodash';

var MultiMenu = React.createClass({
  propTypes: {
    lookup: React.PropTypes.object,
    title: React.PropTypes.string,
    id: React.PropTypes.string,
  },

  render() {
    return <div>
      <FormControl type="text" placeholder="Search" />
      <ul>
      {
      }
      </ul>
    </div>;
  },
});

var MultiDropdown = React.createClass({
  propTypes: {
    lookup: React.PropTypes.object,
    title: React.PropTypes.string,
    id: React.PropTypes.string,
  },

  getInitialState() {
    return {
      selected: [],
      title: this.props.title,
    };
  },

  render() {
    return <Dropdown id={ this.props.id} title={ this.state.title }>
      <Dropdown.Toggle />
      <MultiMenu bsRole="menu">
      {
        _.map(this.props.lookup, (lookup) => {
          return <MenuItem key={ lookup.id } eventKey={ lookup.id }>{ lookup.name }</MenuItem>;
        })
      }
      </MultiMenu>
    </Dropdown>;
  },
});


export default MultiDropdown;
