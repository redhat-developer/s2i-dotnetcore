import React from 'react';

import { Dropdown, MenuItem } from 'react-bootstrap';

import RootCloseMenu from './RootCloseMenu.jsx';

import _ from 'lodash';

var DropdownControl = React.createClass({
  propTypes: {
    // This is used to update state
    id: React.PropTypes.string.isRequired,

    // This can be an array of strings or objects. If the latter, will use id/name by default.
    items: React.PropTypes.array.isRequired,

    // If present, then items is an array of objects with ids
    selectedId: React.PropTypes.number,

    // If present. then items is an array of strings
    title: React.PropTypes.string,

    // Assumes item field is 'name' unless specified here.
    fieldName: React.PropTypes.string,

    // Displayed when there's no selection
    placeholder: React.PropTypes.string,

    // If true, include an "empty" line at the top;
    blankLine: React.PropTypes.bool,

    className: React.PropTypes.string,
    disabled: React.PropTypes.bool,
    onSelect: React.PropTypes.func,
    updateState: React.PropTypes.func,
  },

  getInitialState() {
    return {
      simple: _.has(this.props, 'title'),

      selectedId: this.props.selectedId || '',
      title: this.buildTitle(this.props.title),
      fieldName: this.props.fieldName || 'name',
      open: false,
    };
  },

  componentDidMount() {
    if (!this.state.simple) {
      // Have to wait until state is ready before initializing title.
      this.setState({
        title: this.buildTitle(this.state.selectedId, this.props.items),
      });
    }
  },

  componentWillReceiveProps(nextProps) {
    if (!_.isEqual(nextProps.items, this.props.items)) {
      var items = nextProps.items || [];
      this.setState({
        items: items,
        title: this.buildTitle(this.state.simple ? this.state.title : this.state.selectedId, items),
      });
    } else if (nextProps.selectedId !== this.props.selectedId) {
      this.setState({
        selectedId: nextProps.selectedId,
        title: this.buildTitle(nextProps.selectedId, this.props.items),
      });
    } else if (!_.isEqual(nextProps.title, this.props.title)) {
      this.setState({ title: this.buildTitle(nextProps.title) });
    }
  },

  buildTitle(keyEvent, items) {
    if (keyEvent) {
      if (!items || this.state.simple) {
        return keyEvent;
      } else {
        var selected = _.find(items, { id: keyEvent });
        if (selected) {
          return selected[this.state.fieldName];
        }
      }
    }
    return this.props.placeholder || 'Select item';
  },

  itemSelected(keyEvent) {
    this.toggle(false);

    this.setState({
      selectedId: keyEvent || '',
      title: this.buildTitle(keyEvent, this.props.items),
    });

    var selected = this.state.simple ? keyEvent : _.find(this.props.items, { id: keyEvent });

    // Send selected item to change listener
    if (this.props.onSelect) {
      this.props.onSelect(selected, this.props.id);
    }

    // Update state with selected key
    if (this.props.updateState) {
      this.props.updateState({
        [this.props.id]: keyEvent,
      });
    }
  },

  toggle(open) {
    this.setState({ open: open });
  },

  render() {
    var props = _.omit(this.props, 'updateState', 'onSelect', 'items', 'selectedId', 'blankLine', 'fieldName', 'placeholder');

    return <Dropdown { ...props } className={ `dropdown-control ${this.props.className || ''}` }
      title={ this.state.title } open={ this.state.open } onToggle={ this.toggle }
    >
      <Dropdown.Toggle title={ this.state.title } />
      <RootCloseMenu bsRole="menu">
        { this.props.items.length > 0 &&
          <ul>
            { this.props.blankLine &&
              <MenuItem key={ this.state.simple ? '' : 0 } eventKey={ this.state.simple ? '' : 0 } onSelect={ this.itemSelected }>
                &nbsp;
              </MenuItem>
            }
            {
              _.map(this.props.items, item => {
                return <MenuItem key={ this.state.simple ? item : item.id } eventKey={ this.state.simple ? item : item.id } onSelect={ this.itemSelected }>
                  { this.state.simple ? item : item[this.state.fieldName] }
                </MenuItem>;
              })
            }
          </ul>
        }
      </RootCloseMenu>
    </Dropdown>;
  },
});

export default DropdownControl;
