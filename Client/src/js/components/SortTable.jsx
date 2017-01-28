import React from 'react';

import { Table, Glyphicon } from 'react-bootstrap';

import _ from 'lodash';

var SortTable = React.createClass({
  propTypes: {
    // Array of objects with key, title, style fields
    headers: React.PropTypes.array.isRequired,
    // This should be a from a state.ui object
    sortField: React.PropTypes.object.isRequired,
    // This should be a from a state.ui object
    sortDesc: React.PropTypes.bool.isRequired,
    onSort: React.PropTypes.func.isRequired,
    maxHeight: React.PropTypes.string,
    children: React.PropTypes.node,
  },

  render() {
    return <div style={ this.props.maxHeight ? { maxHeight: this.props.maxHeight, width: '100%', overflowY: 'scroll' } : {}}>
      <Table condensed striped>
        <thead>
          <tr>
            {
              _.map(this.props.headers, (header) => {
                if (!header.title) {
                  return <th key={ header.field } style={ header.style }></th>;
                }

                var sortGlyph = '';
                if (this.props.sortField === header.field) {
                  sortGlyph = <span>&nbsp;<Glyphicon glyph={ this.props.sortDesc ? 'sort-by-attributes-alt' : 'sort-by-attributes' }/></span>;
                }
                return <th id={ header.field } key={ header.field } onClick={ this.props.onSort } style={{ ...header.style, cursor: 'pointer' }}>{ header.title }{ sortGlyph }</th>;
              })
            }
          </tr>
        </thead>
        <tbody>
          { this.props.children }
        </tbody>
      </Table>
    </div>;
  },
});

export default SortTable;
