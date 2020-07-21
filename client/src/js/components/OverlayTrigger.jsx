import React, { cloneElement } from 'react';
import { Overlay, OverlayTrigger } from 'react-bootstrap';

// This is a SUPER hacky way to get around the fact that the standard (as of 0.29.5) React Bootstrap
// <OverlayTrigger> doesn't have any way of allowing the overlay to close itself. Adding hide prop
// to the `cloneElement` call that just calls the hide method on the default OverlayTrigger causes
// the overlay to be closed.

class CloseableOverlayTrigger extends OverlayTrigger {
  makeOverlay(overlay, props) {
    overlay = cloneElement(this.props.overlay, {
      // All this overriding just for this one property!
      hide: this.handleHide,
    });

    return (
      <Overlay
        {...props}
        show={this.state.show}
        onHide={this.handleHide}
        target={this}
      >
        {overlay}
      </Overlay>
    );
  }
}

export default CloseableOverlayTrigger;
