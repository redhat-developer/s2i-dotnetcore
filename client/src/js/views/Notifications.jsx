import React from "react";
import PropTypes from "prop-types";

import { connect } from "react-redux";

import { PageHeader } from "react-bootstrap";
import { Button, ButtonGroup, Glyphicon } from "react-bootstrap";

import Unimplemented from "../components/Unimplemented.jsx";

class Notifications extends React.Component {
  static propTypes = {
    currentUser: PropTypes.object,
  };

  email = () => {};
  print = () => {};

  render() {
    var numNotifications = 0;

    return (
      <div id="notifications-list">
        <PageHeader>
          Notifications ({numNotifications})
          <ButtonGroup id="notifications-buttons">
            <Unimplemented>
              <Button onClick={this.email}>
                <Glyphicon glyph="envelope" title="E-mail" />
              </Button>
            </Unimplemented>
            <Unimplemented>
              <Button onClick={this.print}>
                <Glyphicon glyph="print" title="Print" />
              </Button>
            </Unimplemented>
          </ButtonGroup>
        </PageHeader>
        This feature has not been released yet.
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    currentUser: state.user,
  };
}

export default connect(mapStateToProps)(Notifications);
