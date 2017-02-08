import React from 'react';

import { InputGroup } from 'react-bootstrap';

import DropdownControl from '../components/DropdownControl.jsx';
import FormInputControl from '../components/FormInputControl.jsx';

import _ from 'lodash';

import { notBlank } from '../utils/string';


const KEY_SEARCH_REGI = 'Registration';
const KEY_SEARCH_VIN = 'VIN';
const KEY_SEARCH_PLATE = 'Plate';

var KeySearchControl = React.createClass({
  propTypes: {
    search: React.PropTypes.object.isRequired,
    updateState: React.PropTypes.func.isRequired,
  },

  getInitialState() {
    return {
      keySearchField: this.props.search.keySearchField || KEY_SEARCH_REGI,
      keySearchText: this.props.search.keySearchText || '',
      keySearchParams: this.props.search.keySearchParams || null,
    };
  },

  componentDidMount() {
    this.updated({
      keySearchParams: this.getParams(),
    });
  },

  getParams() {
    if (notBlank(this.state.keySearchText)) {
      switch (this.state.keySearchField) {
        case KEY_SEARCH_REGI: return { regi: this.state.keySearchText };
        case KEY_SEARCH_VIN: return { vin: this.state.keySearchText };
        case KEY_SEARCH_PLATE: return { plate: this.state.keySearchText };
        // Let this fall through if key search field is not set for some reason.
      }
    }
    return null;
  },

  updated(state, callback) {
    // update state
    this.setState(state, () => {
      // then update params
      this.setState({
        keySearchParams: this.getParams(),
      }, () => {
        // then update parent state
        this.props.updateState(this.state, callback);
      });
    });
  },

  render() {
    var props = _.omit(this.props, 'updateState', 'search');

    return <div className="key-search-control">
      <InputGroup { ...props }>
        <DropdownControl id="keySearchField" componentClass={ InputGroup.Button } title={ this.state.keySearchField }
          updateState={ this.updated } items={[ KEY_SEARCH_REGI, KEY_SEARCH_VIN, KEY_SEARCH_PLATE ]}
        />
        <FormInputControl id="keySearchText" type="text" value={ this.state.keySearchText } updateState={ this.updated }/>
      </InputGroup>
    </div>;
  },
});

export default KeySearchControl;
