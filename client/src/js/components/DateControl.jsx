import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { ControlLabel, InputGroup, Button, Glyphicon } from 'react-bootstrap';

import Moment from 'moment';
import DateTime from 'react-datetime';

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
    showClear: PropTypes.bool,
  };

  constructor(props) {
    super(props);

    this.state = {
      date: this.getInitialDate(),
    };
  }

  dateChanged = (date) => {
    var moment = Moment(date);
    var dateString = moment && moment.isValid() ? moment.format(this.props.format || 'YYYY-MM-DD') : date;

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

    this.setState({ date });
  };

  getInitialDate = () => {
    var date = Moment(this.props.date);
    if (!date || !date.isValid()) {
      date = '';
    }
    return date;
  };

  render() {
    var format = this.props.format || 'YYYY-MM-DD';

    var placeholder = this.props.placeholder;
    var disabled = this.props.disabled;

    return (
      <div className={`date-control ${this.props.className || ''}`} id={this.props.id}>
        {(() => {
          // Inline label
          if (this.props.label) {
            return <ControlLabel>{this.props.label}</ControlLabel>;
          }
        })()}
        <InputGroup>
          <DateTime
            value={this.state.date}
            dateFormat={format}
            timeFormat={false}
            closeOnSelect={true}
            onChange={this.dateChanged}
            inputProps={{
              placeholder: placeholder,
              disabled: disabled,
            }}
            renderInput={this.rendorInput.bind(this)}
          />
        </InputGroup>
      </div>
    );
  }

  rendorInput(props, openCalendar) {
    const clear = () => props.onChange({ target: { value: '' } });

    return (
      <Fragment>
        <input {...props} />
        <InputGroup.Button>
          {this.props.showClear && this.state.date !== '' && (
            <Button onClick={clear}>
              <Glyphicon glyph="ban-circle" title="Clear" />
            </Button>
          )}
          <Button onClick={openCalendar}>
            <Glyphicon glyph="calendar" title={this.props.title} />
          </Button>
        </InputGroup.Button>
      </Fragment>
    );
  }
}

export default DateControl;
