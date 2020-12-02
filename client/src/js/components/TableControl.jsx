import PropTypes from 'prop-types';
import React from 'react';
import { Table } from 'react-bootstrap';
import _ from 'lodash';

const TableControl = ({ id, headers, children }) => {
  return (
    <div id={id}>
      <Table condensed striped>
        <thead>
          <tr>
            {_.map(headers, (header) => {
              return (
                <th key={header.field} style={header.style}>
                  {header.node ? header.node : header.title}
                </th>
              );
            })}
          </tr>
        </thead>
        <tbody>{children}</tbody>
      </Table>
    </div>
  );
};

TableControl.propTypes = {
  // Array of objects with key, title, style, children fields
  headers: PropTypes.array.isRequired,
  id: PropTypes.string,
  children: PropTypes.node,
};

export default TableControl;
