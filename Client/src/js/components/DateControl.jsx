import React from "react";
import PropTypes from "prop-types";
import { ControlLabel, InputGroup, Button, Glyphicon } from "react-bootstrap";

import Moment from "moment";
import DateTime from "react-datetime";

class DateControl extends React.Component {
  static propTypes = {
    id: PropTypes.string.isRequired,
    date: PropTypes.string,
    format: PropTypes.string,
    className: PropTypes.string,
    label: PropTypes.string,
    onChange: PropTypes.func,
    updateState: PropTypes.func,
    placeholder: PropTypes.string,
    title: PropTypes.string,
    disabled: PropTypes.bool,
  };

  clicked = () => {
    if (!this.props.disabled) {
      this.input.focus();
    }
  };

  dateChanged = (date) => {
    var moment = Moment(date);
    var dateString =
      moment && moment.isValid()
        ? moment.format(this.props.format || "YYYY-MM-DD")
        : date;

    // On change listener
    if (this.props.onChange) {
      this.props.onChange(dateString, this.props.id);
    }

    // Update state
    if (this.props.updateState) {
      this.props.updateState({
        [this.props.id]: dateString,
      });
    }
  };

  render() {
    var date = Moment(this.props.date);
    if (!date || !date.isValid()) {
      date = "";
    }

    var format = this.props.format || "YYYY-MM-DD";

    var placeholder = this.props.placeholder;
    var disabled = this.props.disabled;

    return (
      <div
        className={`date-control ${this.props.className || ""}`}
        id={this.props.id}
      >
        {(() => {
          // Inline label
          if (this.props.label) {
            return <ControlLabel>{this.props.label}</ControlLabel>;
          }
        })()}
        <InputGroup>
          <DateTime
            value={date}
            dateFormat={format}
            timeFormat={false}
            closeOnSelect={true}
            onChange={this.dateChanged}
            inputProps={{
              placeholder: placeholder,
              disabled: disabled,
              ref: (input) => {
                this.input = input;
              },
            }}
          />
          <InputGroup.Button>
            <Button onClick={this.clicked}>
              <Glyphicon glyph="calendar" title={this.props.title} />
            </Button>
          </InputGroup.Button>
        </InputGroup>
      </div>
    );
  }
}

export default DateControl;
