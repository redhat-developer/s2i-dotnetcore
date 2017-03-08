import React from 'react';

import { Table, Glyphicon } from 'react-bootstrap';

import _ from 'lodash';

var SortTable = React.createClass({
  propTypes: {
    // Array of objects with key, title, style, children fields
    headers: React.PropTypes.array.isRequired,
    // This should be a from a state.ui object
    sortField: React.PropTypes.string.isRequired,
    // This should be a from a state.ui object
    sortDesc: React.PropTypes.bool.isRequired,
    onSort: React.PropTypes.func.isRequired,
    id: React.PropTypes.string,
    children: React.PropTypes.node,
  },

  sort(e) {
    this.props.onSort({
      sortField: e.currentTarget.id,
      sortDesc: this.props.sortField !== e.currentTarget.id ? false : !this.props.sortDesc,
    });
  },

  render() {
    return <div id={ this.props.id }>
      <Table condensed striped hover>
        <thead>
          <tr>
            {
              _.map(this.props.headers, (header) => {
                if (header.node) {
                  return <th key={ header.field } style={ header.style }>{ header.node }</th>;
                }

                var sortGlyph = '';
                if (this.props.sortField === header.field) {
                  sortGlyph = <span>&nbsp;<Glyphicon glyph={ this.props.sortDesc ? 'sort-by-attributes-alt' : 'sort-by-attributes' }/></span>;
                }
                return <th id={ header.field } key={ header.field } onClick={ header.noSort ? '' : this.sort } style={{ ...header.style, cursor: 'pointer' }}>{ header.title }{ sortGlyph }</th>;
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
