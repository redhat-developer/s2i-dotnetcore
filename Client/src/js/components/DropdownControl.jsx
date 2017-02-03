import React from 'react';

import { Dropdown, MenuItem } from 'react-bootstrap';

import RootCloseMenu from './RootCloseMenu.jsx';

import _ from 'lodash';

var DropdownControl = React.createClass({
  propTypes: {
    id: React.PropTypes.string.isRequired,
    items: React.PropTypes.array.isRequired,
    title: React.PropTypes.string,
    className: React.PropTypes.string,
    placeholder: React.PropTypes.string,
    blankLine: React.PropTypes.bool,
    onSelect: React.PropTypes.func,
    updateState: React.PropTypes.func,
  },

  getInitialState() {
    return {
      title: this.buildTitle(this.props.title),
      open: false,
    };
  },

  buildTitle(keyEvent) {
    return keyEvent || this.props.placeholder || 'Select item';
  },

  selected(keyEvent, e) {
    this.toggle(false);

    this.setState({ title: this.buildTitle(keyEvent) });

    // On select listener
    if (this.props.onSelect) {
      this.props.onSelect(keyEvent, e);
    }

    // Update state
    if (this.props.updateState) {
      this.props.updateState({
        [this.props.id]: keyEvent,
      });
    }
  },

  toggle(open) {
    this.setState({
      open: open,
    });
  },

  render() {
    var props = _.omit(this.props, 'updateState', 'onSelect', 'items', 'title', 'blankLine');

    return <Dropdown { ...props } className={ `dropdown-control ${this.props.className || ''}` } title={ this.state.title } open={ this.state.open } onToggle={ this.toggle }>
      <Dropdown.Toggle title={ this.state.title } />
      <RootCloseMenu bsRole="menu">
        { this.props.items.length > 0 &&
          <ul>
            { this.props.blankLine &&
              <MenuItem key={ '' } eventKey={ '' } onSelect={ this.selected }>
                  &nbsp;
              </MenuItem>
            }
            {
              this.props.items.map((item) => {
                return <MenuItem key={ item } eventKey={ item } onSelect={ this.selected }>{ item }</MenuItem>;
              })
            }
          </ul>
        }
      </RootCloseMenu>
    </Dropdown>;
  },
});

export default DropdownControl;
