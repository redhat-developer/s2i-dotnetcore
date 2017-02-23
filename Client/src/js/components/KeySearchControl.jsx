import React from 'react';

import _ from 'lodash';

import SearchControl from '../components/SearchControl.jsx';


const KEY_SEARCH_ITEMS = [
  { id: 'regi',  name: 'Registration' },
  { id: 'vin',   name: 'VIN' },
  { id: 'plate', name: 'Plate' },
];

var KeySearchControl = React.createClass({
  propTypes: {
    search: React.PropTypes.object.isRequired,
    updateState: React.PropTypes.func.isRequired,
  },

  getInitialState() {
    var item = _.find(KEY_SEARCH_ITEMS, { name: this.props.search.keySearchField });

    return {
      key: item ? item.id : KEY_SEARCH_ITEMS[0].id,
      text: this.props.search.keySearchText || '',
      params: this.props.search.keySearchParams || null,
    };
  },

  updated(state) {
    // update local state
    this.setState(state, () => {
      // then update parent state
      var item = _.find(KEY_SEARCH_ITEMS, { id: this.state.key });

      this.props.updateState({
        keySearchField: item ? item.name : '',
        keySearchText: this.state.text,
        keySearchParams: this.state.params,
      });
    });
  },

  render() {
    return <SearchControl { ...this.props } search={ this.state } updateState={ this.updated } items={ KEY_SEARCH_ITEMS }/>;
  },
});

export default KeySearchControl;
