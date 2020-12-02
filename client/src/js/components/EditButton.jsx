import React from "react";
import PropTypes from "prop-types";

import { Button, Glyphicon } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";

import _ from "lodash";

class EditButton extends React.Component {
  static propTypes = {
    pathname: PropTypes.string,
    onClick: PropTypes.func,
    // view as opposed to edit, i.e. read only
    view: PropTypes.bool,
    name: PropTypes.string,
    hide: PropTypes.bool,
  };

  render() {
    var props = _.omit(this.props, "view", "name", "hide", "pathname");

    var button = (
      <Button
        title={`${this.props.view ? "View" : "Edit"} ${this.props.name}`}
        bsSize="xsmall"
        className={this.props.hide ? "hidden" : ""}
        {...props}
      >
        <Glyphicon glyph={this.props.view ? "edit" : "pencil"} />
      </Button>
    );

    return this.props.pathname ? (
      <LinkContainer to={{ pathname: this.props.pathname }}>
        {button}
      </LinkContainer>
    ) : (
      button
    );
  }
}

export default EditButton;
