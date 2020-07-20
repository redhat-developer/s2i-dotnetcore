import React from "react";
import PropTypes from "prop-types";

import { OverlayTrigger, Tooltip } from "react-bootstrap";

class Unimplemented extends React.Component {
  static propTypes = {
    children: PropTypes.node,
  };

  render() {
    return (
      <OverlayTrigger
        trigger={["hover", "click"]}
        placement="bottom"
        rootClose
        overlay={
          <Tooltip id="unimplemented">
            This feature has not been released yet.
          </Tooltip>
        }
      >
        {this.props.children}
      </OverlayTrigger>
    );
  }
}

export default Unimplemented;
