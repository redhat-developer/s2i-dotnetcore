import React from 'react';
import RootCloseWrapper from 'react-overlays/lib/RootCloseWrapper';

var RootCloseMenu = React.createClass({
  propTypes: {
    open: React.PropTypes.bool,
    pullRight: React.PropTypes.bool,
    onClose: React.PropTypes.func,
    children: React.PropTypes.node,
  },

  render() {
    return <RootCloseWrapper disabled={ !this.props.open } onRootClose={ this.props.onClose }>
      <div className={ `dropdown-menu ${ this.props.pullRight ? 'dropdown-menu-right' : '' }`}>
        { this.props.children }
      </div>
    </RootCloseWrapper>;
  },
});


export default RootCloseMenu;
