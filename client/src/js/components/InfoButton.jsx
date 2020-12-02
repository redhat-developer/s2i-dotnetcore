import React from "react";
import PropTypes from "prop-types";

import { Popover, Glyphicon, OverlayTrigger } from "react-bootstrap";

import _ from "lodash";

class InfoButton extends React.Component {
  static propTypes = {
    title: PropTypes.string.isRequired,
    className: PropTypes.string,
    children: PropTypes.node,
  };

  render() {
    var props = _.omit(this.props, "className", "children");

    return (
      <OverlayTrigger
        trigger="click"
        placement="right"
        rootClose
        overlay={
          <Popover id="info" title={this.props.title}>
            {this.props.children}
          </Popover>
        }
      >
        <Glyphicon
          className={`info-button ${this.props.className || ""}`}
          {...props}
          glyph="info-sign"
        />
      </OverlayTrigger>
    );
  }
}

export default InfoButton;
