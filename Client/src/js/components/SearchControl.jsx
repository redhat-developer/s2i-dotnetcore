import React from 'react';

import { InputGroup } from 'react-bootstrap';

import DropdownControl from '../components/DropdownControl.jsx';
import FormInputControl from '../components/FormInputControl.jsx';

import _ from 'lodash';

import { notBlank } from '../utils/string';


var searchControl = React.createClass({
  propTypes: {
    // This is an array of objects { id, name }
    items: React.PropTypes.array.isRequired,

    search: React.PropTypes.object.isRequired,
    updateState: React.PropTypes.func.isRequired,
  },

  getInitialState() {
    return {
      key: this.props.search.key || '',
      text: this.props.search.text || '',
      params: this.props.search.params || null,
    };
  },

  componentDidMount() {
    this.updated({
      params: this.getParams(),
    });
  },

  getParams() {
    var params = null;

    if (notBlank(this.state.key) && notBlank(this.state.text)) {
      params = {};
      params[this.state.key] = this.state.text;
    }

    return params;
  },

  updated(state) {
    if (state.text) {
      state.text = state.text.trim();
    }
    // update state
    this.setState(state, () => {
      // then update params
      this.setState({
        params: this.getParams(),
      }, () => {
        // then update parent state
        this.props.updateState(this.state);
      });
    });
  },

  render() {
    var props = _.omit(this.props, 'updateState', 'search', 'items');

    return <div className="search-control">
      <InputGroup { ...props }>
        <DropdownControl id="key" componentClass={ InputGroup.Button } updateState={ this.updated }
          selectedId={ this.state.key } items={ this.props.items }
        />
        <FormInputControl id="text" type="text" value={ this.state.text } updateState={ this.updated }/>
      </InputGroup>
    </div>;
  },
});

export default searchControl;
