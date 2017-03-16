import React from 'react';

import _ from 'lodash';

import * as Constant from '../constants';

import SearchControl from '../components/SearchControl.jsx';

import { padLeft } from '../utils/string';


const KEY_SEARCH_ITEMS = [
  { id: Constant.CCW_REGISTRATION, name: 'Registration' },
  { id: Constant.CCW_VIN,          name: 'VIN' },
  { id: Constant.CCW_PLATE,        name: 'Plate' },
];

var KeySearchControl = React.createClass({
  propTypes: {
    search: React.PropTypes.object.isRequired,
    updateState: React.PropTypes.func.isRequired,
    suppressPlate: React.PropTypes.bool,
  },

  getInitialState() {
    var items = KEY_SEARCH_ITEMS;
    if (this.props.suppressPlate) {
      items.pop();
    }

    var item = _.find(items, { name: this.props.search.keySearchField });

    return {
      items: items,

      key: item ? item.id : items[0].id,
      text: this.props.search.keySearchText || '',
      params: this.props.search.keySearchParams || null,
    };
  },

  updated(state) {
    // Special case for registration: zero-pad to eight digits.
    if (state.key === Constant.CCW_REGISTRATION && state.params) {
      var paramText = state.text;
      state.params[Constant.CCW_REGISTRATION] = padLeft(paramText, '0', 8);
    }
    // update local state
    this.setState(state, () => {
      // then update parent state
      var item = _.find(this.state.items, { id: this.state.key });

      this.props.updateState({
        keySearchField: item ? item.name : '',
        keySearchText: this.state.text,
        keySearchParams: this.state.params,
        // Initializing the SearchControl causes a state change to load the params, so
        // flag this in the update.
        keySearchOnMount: this.state.onMount,
      });
    });
  },

  render() {
    return <SearchControl { ...this.props } search={ this.state } updateState={ this.updated } items={ this.state.items }/>;
  },
});

export default KeySearchControl;
