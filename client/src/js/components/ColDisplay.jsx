import React from "react";
import PropTypes from "prop-types";
import { Col } from "react-bootstrap";

import _ from "lodash";

class ColDisplay extends React.Component {
  static propTypes = {
    label: PropTypes.node,
    children: PropTypes.node,
  };

  render() {
    var props = _.omit(this.props, "label", "labelProps", "fieldProps");

    return (
      <Col {...props}>
        <div
          style={{ float: "left", textAlign: "right" }}
          className="col-display-label"
        >
          <strong>{this.props.label}</strong>
        </div>
        <div
          style={{ float: "left", paddingLeft: 10 }}
          className="col-display-field"
        >
          {this.props.children}
        </div>
      </Col>
    );
  }
}

export default ColDisplay;
