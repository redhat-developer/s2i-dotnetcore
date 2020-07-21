import React from "react";
import PropTypes from "prop-types";

import { Popover, ButtonGroup, Button, Glyphicon } from "react-bootstrap";

import _ from "lodash";

class Confirm extends React.Component {
  static propTypes = {
    onConfirm: PropTypes.func.isRequired,
    onCancel: PropTypes.func,
    hide: PropTypes.func,
    children: PropTypes.node,
  };

  confirmed = () => {
    this.props.onConfirm();
    this.props.hide();
  };

  canceled = () => {
    if (this.props.onCancel) {
      this.props.onCancel();
    }
    this.props.hide();
  };

  render() {
    var props = _.omit(this.props, "onConfirm", "onCancel", "hide", "children");

    return (
      <Popover id="confirm" title="Are you sure?" {...props}>
        {this.props.children}
        <div style={{ textAlign: "center", marginTop: "6px" }}>
          <ButtonGroup>
            <Button bsStyle="primary" onClick={this.confirmed}>
              <Glyphicon glyph="ok-circle" /> Yes
            </Button>
            <Button onClick={this.canceled}>
              <Glyphicon glyph="remove-circle" /> No
            </Button>
          </ButtonGroup>
        </div>
      </Popover>
    );
  }
}

export default Confirm;
