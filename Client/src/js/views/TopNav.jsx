import React from 'react';
import { Navbar, Nav, NavItem, NavDropdown, MenuItem } from 'react-bootstrap';
import { Popover, Button, Glyphicon } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import { connect } from 'react-redux';

import OverlayTrigger from '../components/OverlayTrigger.jsx';
import Spinner from '../components/Spinner.jsx';


var TopNav = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
    showWorkingIndicator: React.PropTypes.bool,
    requestError: React.PropTypes.object,
  },

  render: function () {
    return <div id="header">
      <nav id="header-main" className="navbar navbar-default navbar-fixed-top">
        <div className="container">
          <div id="logo">
            <a href="http://www2.gov.bc.ca/gov/content/home">
              <img title="Government of B.C." alt="Government of B.C." src="images/gov/gov3_bc_logo.png"/>
            </a>
          </div>
          <h1 id="banner">MOTI School Bus Inspection Tracking System</h1>
        </div>
        <Navbar id="top-nav">
          <Nav>
            <LinkContainer to={{ pathname: '/home' }}>
              <NavItem eventKey={1} href="/home">Home</NavItem>
            </LinkContainer>
            <LinkContainer to={{ pathname: '/school-buses' }}>
              <NavItem eventKey={2} href="/school-buses">School Buses</NavItem>
            </LinkContainer>
            <LinkContainer to={{ pathname: '/owners' }}>
              <NavItem eventKey={3} href="/owners">Owners</NavItem>
            </LinkContainer>
            <LinkContainer to={{ pathname: '/notifications' }}>
              <NavItem eventKey={4} href="/notifications">Notifications</NavItem>
            </LinkContainer>
            <NavDropdown id="admin-dropdown" title="Administration">
              <LinkContainer to={{ pathname: '/user-management' }}>
                <MenuItem eventKey={5} href="/user-management">User Management</MenuItem>
              </LinkContainer>
              <LinkContainer to={{ pathname: '/roles-permissions' }}>
                <MenuItem eventKey={6} href="/roles-permissions">Roles and Permissions</MenuItem>
              </LinkContainer>
            </NavDropdown>
          </Nav>
          <Nav id="navbar-current-user" pullRight>
            <NavItem>
              {this.props.currentUser.fullName} <small>{this.props.currentUser.districtName} District</small>
            </NavItem>
          </Nav>
          <OverlayTrigger trigger="click" placement="bottom" rootClose overlay={
              <Popover id="error-message" title={ this.props.requestError.status + ' – API Error' }>
                <p><small>{ this.props.requestError.message }</small></p>
              </Popover>
            }>
            <Button id="error-indicator" className={ this.props.requestError.message ? '' : 'hide' } bsStyle="danger" bsSize="xsmall">
              Error
              <Glyphicon glyph="exclamation-sign" />
            </Button>
          </OverlayTrigger>
          <div id="working-indicator" hidden={ !this.props.showWorkingIndicator }>Working <Spinner/></div>
        </Navbar>
      </nav>
    </div>;
  },
});


function mapStateToProps(state) {
  return {
    currentUser: state.user,
    showWorkingIndicator: state.ui.requests.waiting,
    requestError: state.ui.requests.error,
  };
}

export default connect(mapStateToProps, null, null, { pure:false })(TopNav);
