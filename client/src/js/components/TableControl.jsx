import PropTypes from 'prop-types';
import React from 'react';
import { Table } from 'react-bootstrap';
import _ from 'lodash';

class TableControl extends React.Component {
  static propTypes = {
    // Array of objects with key, title, style, children fields
    headers: PropTypes.array.isRequired,
    id: PropTypes.string,
    children: PropTypes.node,
  };

  render() {
    return (
      <div id={this.props.id}>
        <Table condensed striped>
          <thead>
            <tr>
              {_.map(this.props.headers, (header) => {
                return (
                  <th key={header.field} style={header.style}>
                    {header.node ? header.node : header.title}
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

export default TableControl;
