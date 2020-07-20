import React from "react";
import PropTypes from "prop-types";
import { Label } from "react-bootstrap";

class BadgeLabel extends React.Component {
  static propTypes = {
    bsClass: PropTypes.string,
    bsStyle: PropTypes.string,
    className: PropTypes.string,
    children: PropTypes.node,
  };

  render() {
    return (
      <Label
        bsClass={this.props.bsClass}
        bsStyle={this.props.bsStyle}
        className={`badge-label ${this.props.className || ""}`}
      >
        {this.props.children}
      </Label>
    );
  }
}

export default BadgeLabel;
