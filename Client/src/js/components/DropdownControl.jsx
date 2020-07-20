import React from "react";
import PropTypes from "prop-types";

import { Dropdown, MenuItem, Popover, OverlayTrigger } from "react-bootstrap";

import RootCloseMenu from "./RootCloseMenu.jsx";

import _ from "lodash";

class DropdownControl extends React.Component {
  static propTypes = {
    // This is used to update state
    id: PropTypes.string.isRequired,

    // This can be an array of strings or objects. If the latter, will use id/name by default.
    items: PropTypes.array.isRequired,

    // If present, then items is an array of objects with ids
    selectedId: PropTypes.any,

    // If present. then items is an array of strings
    title: PropTypes.string,

    // Assumes item field is 'name' unless specified here.
    fieldName: PropTypes.string,

    // Displayed when there's no selection
    placeholder: PropTypes.string,

    // If blankLine is supplied, include an "empty" line at the top;
    // If it has a string value, use that in place of blank.
    blankLine: PropTypes.any,

    className: PropTypes.string,
    disabled: PropTypes.bool,
    onSelect: PropTypes.func,
    updateState: PropTypes.func,
  };

  componentDidMount() {
    if (!this.state.simple) {
      // Have to wait until state is ready before initializing title.
      this.setState({
        title: this.buildTitle(this.state.selectedId, this.props.items),
      });
    }
  }

  UNSAFE_componentWillReceiveProps(nextProps) {
    if (!_.isEqual(nextProps.items, this.props.items)) {
      var items = nextProps.items || [];
      this.setState({
        items: items,
        title: this.buildTitle(
          this.state.simple ? this.state.title : this.state.selectedId,
          items
        ),
      });
    } else if (nextProps.selectedId !== this.props.selectedId) {
      this.setState({
        selectedId: nextProps.selectedId,
        title: this.buildTitle(nextProps.selectedId, this.props.items),
      });
    } else if (!_.isEqual(nextProps.title, this.props.title)) {
      this.setState({ title: this.buildTitle(nextProps.title) });
    }
  }

  buildTitle = (keyEvent, items) => {
    if (keyEvent) {
      if (!items || this.state.simple) {
        return keyEvent;
      } else {
        var selected = _.find(items, { id: keyEvent });
        if (selected) {
          return selected[this.state.fieldName];
        }
      }
    }
    return this.props.placeholder || "Select item";
  };

  itemSelected = (keyEvent) => {
    this.toggle(false);

    this.setState({
      selectedId: keyEvent || "",
      title: this.buildTitle(keyEvent, this.props.items),
    });

    var selected = this.state.simple
      ? keyEvent
      : _.find(this.props.items, { id: keyEvent });

    // Send selected item to change listener
    if (this.props.onSelect) {
      this.props.onSelect(selected, this.props.id);
    }

    // Update state with selected key
    if (this.props.updateState) {
      this.props.updateState({
        [this.props.id]: keyEvent,
      });
    }
  };

  toggle = (open) => {
    this.setState({ open: open });
  };

  state = {
    simple: _.has(this.props, "title"),

    selectedId: this.props.selectedId || "",
    title: this.buildTitle(this.props.title),
    fieldName: this.props.fieldName || "name",
    open: false,
  };

  render() {
    var props = _.omit(
      this.props,
      "updateState",
      "onSelect",
      "items",
      "selectedId",
      "blankLine",
      "fieldName",
      "placeholder"
    );

    return (
      <Dropdown
        {...props}
        className={`dropdown-control ${this.props.className || ""}`}
        title={this.state.title}
        open={this.state.open}
        onToggle={this.toggle}
      >
        <Dropdown.Toggle title={this.state.title} />
        <RootCloseMenu bsRole="menu">
          {this.props.items.length > 0 && (
            <ul>
              {this.props.blankLine && (
                <MenuItem
                  key={this.state.simple ? "" : 0}
                  eventKey={this.state.simple ? "" : 0}
                  onSelect={this.itemSelected}
                >
                  {typeof this.props.blankLine === "string"
                    ? this.props.blankLine
                    : " "}
                </MenuItem>
              )}
              {_.map(this.props.items, (item) => {
                var menuItem = (
                  <MenuItem
                    key={this.state.simple ? item : item.id}
                    eventKey={this.state.simple ? item : item.id}
                    onSelect={this.itemSelected}
                  >
                    {this.state.simple ? item : item[this.state.fieldName]}
                  </MenuItem>
                );
                // Check for hover items
                if (!this.state.simple && item.hoverText) {
                  return (
                    <OverlayTrigger
                      trigger={["hover", "focus"]}
                      placement="right"
                      rootClose
                      key={this.state.simple ? item : item.id}
                      overlay={
                        <Popover
                          id={`popover-${item.id}`}
                          title={item[this.state.fieldName]}
                        >
                          {item.hoverText}
                        </Popover>
                      }
                    >
                      {menuItem}
                    </OverlayTrigger>
                  );
                }
                return menuItem;
              })}
            </ul>
          )}
        </RootCloseMenu>
      </Dropdown>
    );
  }
}

export default DropdownControl;
