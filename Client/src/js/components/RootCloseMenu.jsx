import React from "react";
import PropTypes from "prop-types";
import RootCloseWrapper from "react-overlays/lib/RootCloseWrapper";

class RootCloseMenu extends React.Component {
  static propTypes = {
    open: PropTypes.bool,
    pullRight: PropTypes.bool,
    onClose: PropTypes.func,
    children: PropTypes.node,
  };

  render() {
    return (
      <RootCloseWrapper
        disabled={!this.props.open}
        onRootClose={this.props.onClose}
      >
        <div
          className={`dropdown-menu ${
            this.props.pullRight ? "dropdown-menu-right" : ""
          }`}
        >
          {this.props.children}
        </div>
      </RootCloseWrapper>
    );
  }
}

export default RootCloseMenu;
