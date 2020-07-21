import React from "react";
import PropTypes from "prop-types";

import { Table, Glyphicon } from "react-bootstrap";

import _ from "lodash";

class SortTable extends React.Component {
  static propTypes = {
    // Array of objects with key, title, style, children fields
    headers: PropTypes.array.isRequired,
    // This should be a from a state.ui object
    sortField: PropTypes.string.isRequired,
    // This should be a from a state.ui object
    sortDesc: PropTypes.bool.isRequired,
    onSort: PropTypes.func.isRequired,
    id: PropTypes.string,
    children: PropTypes.node,
  };

  sort = (e) => {
    this.props.onSort({
      sortField: e.currentTarget.id,
      sortDesc:
        this.props.sortField !== e.currentTarget.id
          ? false
          : !this.props.sortDesc,
    });
  };

  render() {
    return (
      <div id={this.props.id}>
        <Table condensed striped hover>
          <thead>
            <tr>
              {_.map(this.props.headers, (header) => {
                if (header.node) {
                  return (
                    <th key={header.field} style={header.style}>
                      {header.node}
                    </th>
                  );
                }

                var sortGlyph = "";
                if (this.props.sortField === header.field) {
                  sortGlyph = (
                    <span>
                      &nbsp;
                      <Glyphicon
                        glyph={
                          this.props.sortDesc
                            ? "sort-by-attributes-alt"
                            : "sort-by-attributes"
                        }
                      />
                    </span>
                  );
                }
                return (
                  <th
                    id={header.field}
                    key={header.field}
                    onClick={header.noSort ? () => {} : this.sort}
                    style={{ ...header.style, cursor: "pointer" }}
                  >
                    {header.title}
                    {sortGlyph}
                  </th>
                );
              })}
            </tr>
          </thead>
          <tbody>{this.props.children}</tbody>
        </Table>
      </div>
    );
  }
}

export default SortTable;
