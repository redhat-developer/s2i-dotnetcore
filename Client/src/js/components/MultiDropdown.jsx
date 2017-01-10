import React from 'react';
import { Dropdown, FormControl, Checkbox } from 'react-bootstrap';

import _ from 'lodash';

const MAX_ITEMS_FOR_TITLE = 3;

var MultiMenu = React.createClass({
  propTypes: {
    children: React.PropTypes.node,
  },

  render() {
    return <div className="dropdown-menu">
      {this.props.children}
    </div>;
  },
});

var MultiDropdown = React.createClass({
  propTypes: {
    items: React.PropTypes.array.isRequired,
    title: React.PropTypes.string,
    id: React.PropTypes.string,
    className: React.PropTypes.string,
    selectedIds: React.PropTypes.array,
    onChange: React.PropTypes.func,
    emptyTitle: React.PropTypes.string,
    showMaxItems: React.PropTypes.number,
  },

  getInitialState() {
    var selectedIds = this.props.selectedIds || [];
    var items = this.props.items || [];
    var title = this.buildTitle(selectedIds);

    return {
      items: items,
      selectedIds: selectedIds,
      title: title,
      filterTerm: '',
      MAX_ITEMS_FOR_TITLE: this.props.showMaxItems || MAX_ITEMS_FOR_TITLE,
      allSelected: selectedIds.length === items.length,
    };
  },

  buildTitle(selectedIds) {
    var num = selectedIds.length;

    if(num === 0) {
      return this.props.emptyTitle || 'Select one or more items';
    } else if(num > this.state.MAX_ITEMS_FOR_TITLE) {
      return `(${num}) selected`;
    } else {
      return _.map(_.pickBy(this.props.items, item => selectedIds.includes(item.id)), 'name').join(', ');
    }
  },

  itemSelected(e) {
    var id = parseInt(e.target.value, 10);
    var selectedIds = this.state.selectedIds.slice();

    if(e.target.checked) {
      selectedIds.push(id);
    } else {
      _.pull(selectedIds, id);
    }

    this.setState({
      selectedIds: selectedIds,
      title: this.buildTitle(selectedIds),
      allSelected: selectedIds.length === this.state.items.length,
    });

    this.sendSelectedIds(selectedIds);
  },

  selectAll(e) {
    var selectedIds = e.target.checked ? _.map(this.state.items, 'id') : [];

    this.setState({
      selectedIds: selectedIds,
      allSelected: e.target.checked,
      title: this.buildTitle(selectedIds),
    });

    this.sendSelectedIds(selectedIds);
  },

  sendSelectedIds(selectedIds) {
    var selected = this.state.items.filter(item => selectedIds.includes(item.id));
    if(this.props.onChange) {
      this.props.onChange(selected);
    }
  },

  filter(e) {
    this.setState({
      filterTerm: e.target.value.toLowerCase().trim(),
    });
  },

  render() {
    var items = this.state.items;

    if(this.state.filterTerm.length > 0) {
      items = _.filter(items, item => {
        return item.name.toLowerCase().indexOf(this.state.filterTerm) !== -1;
      });
    }

    return <Dropdown className={`multi-dropdown ${this.props.className || ''}`} id={ this.props.id} title={ this.state.title }>
      <Dropdown.Toggle title={this.state.title} />
      <MultiMenu bsRole="menu">
        <div className="multi-dropdown-controls clearfix">
          <FormControl type="text" placeholder="Search" onChange={this.filter} />
          <Checkbox checked={this.state.allSelected} onChange={this.selectAll}>Select All</Checkbox>
        </div>
        <ul>
          {
            _.map(items, item => {
              return <li key={ item.id }>
                <Checkbox value={item.id} checked={this.state.selectedIds.includes(item.id)} onChange={this.itemSelected}>
                  { item.name }
                </Checkbox>
              </li>;
            })
          }
        </ul>
      </MultiMenu>
    </Dropdown>;
  },
});


export default MultiDropdown;
