import React from 'react';

import SearchControl from '../components/SearchControl.jsx';


var KeySearchControl = React.createClass({
  propTypes: {
    search: React.PropTypes.object.isRequired,
    updateState: React.PropTypes.func.isRequired,
  },

  getInitialState() {
    return {
      key: this.props.search.keySearchField || 'regi',
      text: this.props.search.keySearchText || '',
      params: this.props.search.keySearchParams || null,
    };
  },

  updated(state) {
    // update local state
    this.setState(state, () => {
      // then update parent state
      this.props.updateState({
        keySearchField: this.state.key,
        keySearchText: this.state.text,
        keySearchParams: this.state.params,
      });
    });
  },

  render() {
    return <SearchControl { ...this.props } search={ this.state } updateState={ this.updated }
      items={[
        { id: 'regi',  name: 'Registration' },
        { id: 'vin',   name: 'VIN' },
        { id: 'plate', name: 'Plate' },
      ]}
    />;
  },
});

export default KeySearchControl;
