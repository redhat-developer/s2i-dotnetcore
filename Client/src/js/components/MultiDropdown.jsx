import React from 'react';
import { Well, Dropdown, FormControl, Checkbox } from 'react-bootstrap';

import RootCloseMenu from './RootCloseMenu.jsx';

import _ from 'lodash';

const MAX_ITEMS_FOR_TITLE = 3;

var MultiDropdown = React.createClass({
  propTypes: {
    items: React.PropTypes.array.isRequired,
    placeholder: React.PropTypes.string,
    id: React.PropTypes.string.isRequired,
    className: React.PropTypes.string,
    fieldName: React.PropTypes.string,
    selectedIds: React.PropTypes.array,
    onChange: React.PropTypes.func,
    updateState: React.PropTypes.func,
    showMaxItems: React.PropTypes.number,
  },

  getInitialState() {
    var selectedIds = this.props.selectedIds || [];
    var items = this.props.items || [];
    var fieldName = this.props.fieldName || 'name';

    return {
      items: items,
      selectedIds: selectedIds,
      title: '',
      filterTerm: '',
      maxItemsForTitle: this.props.showMaxItems || MAX_ITEMS_FOR_TITLE,
      allSelected: selectedIds.length === items.length,
      fieldName: fieldName,
    };
  },

  componentDidMount() {
    // Have to wait until state is ready before initializing title.
    var title = this.buildTitle(this.state.selectedIds);
    this.setState({ title: title });
  },

  componentWillReceiveProps(nextProps) {
    if (!_.isEqual(nextProps.items, this.props.items)) {
      var items = nextProps.items || [];
      var title = this.buildTitle(this.state.selectedIds);

      this.setState({
        items: items,
        title: title,
      });
    } else if (!_.isEqual(nextProps.selectedIds, this.props.selectedIds)) {
      title = this.buildTitle(nextProps.selectedIds);

      this.setState({
        selectedIds: nextProps.selectedIds,
        title: title,
      });
    }
  },

  buildTitle(selectedIds) {
    var num = selectedIds.length;

    if (num === 0) {
      return this.props.placeholder || 'Select one or more items';
    } else if (num > this.state.maxItemsForTitle) {
      return `(${num}) selected`;
    } else {
      return _.map(_.pickBy(this.props.items, item => selectedIds.includes(item.id)), this.state.fieldName).join(', ');
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

    this.sendSelected(selectedIds);
  },

  selectAll(e) {
    var selectedIds = e.target.checked ? _.map(this.state.items, 'id') : [];

    this.setState({
      selectedIds: selectedIds,
      allSelected: e.target.checked,
      title: this.buildTitle(selectedIds),
    });

    this.sendSelected(selectedIds);
  },

  sendSelected(selectedIds) {
    var selected = this.state.items.filter(item => selectedIds.includes(item.id));

    // Send selected items to change listener
    if (this.props.onChange) {
      this.props.onChange(selected, this.props.id);
    }

    // Update state with selected Ids
    if (this.props.updateState) {
      this.props.updateState({
        [this.props.id]: selectedIds,
      });
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
        return item[this.state.fieldName].toLowerCase().indexOf(this.state.filterTerm) !== -1;
      });
    }

    return <Dropdown className={ `multi-dropdown ${this.props.className || ''}` } id={ this.props.id } title={ this.state.title }>
      <Dropdown.Toggle title={this.state.title} />
      <RootCloseMenu bsRole="menu">
        <Well bsSize="small">
          <FormControl type="text" placeholder="Search" onChange={ this.filter } />
          <Checkbox className="select-all" checked={ this.state.allSelected } onChange={ this.selectAll }>Select All</Checkbox>
        </Well>
        {(() => {
          if(items.length > 0) {
            return <ul>
              {
                _.map(items, item => {
                  return <li key={ item.id }>
                    <Checkbox value={ item.id } checked={ this.state.selectedIds.includes(item.id) } onChange={ this.itemSelected }>
                      { item[this.state.fieldName] }
                    </Checkbox>
                  </li>;
                })
              }
            </ul>;
          }
        })()}
      </RootCloseMenu>
    </Dropdown>;
  },
});


export default MultiDropdown;
