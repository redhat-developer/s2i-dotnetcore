import React from 'react';
import { Form, FormControl, ControlLabel, InputGroup, Button, Glyphicon } from 'react-bootstrap';

import Moment from 'moment';
import DatePicker from 'react-datepicker';

class InputControl extends FormControl {
  focus() {
    /* eat this to squash error */
  }
}

var DateControl = React.createClass({
  propTypes: {
    date: React.PropTypes.string,
    format: React.PropTypes.string,
    className: React.PropTypes.string,
    label: React.PropTypes.string,
    onChange: React.PropTypes.func.isRequired,
    id: React.PropTypes.string,
    placeholder: React.PropTypes.string,
    title: React.PropTypes.string,
  },

  clicked() {
    this.input.focus();
  },

  dateChanged(moment) {
    var dateString = moment ? moment.format(this.props.format || 'YYYY-MM-DD') : '';
    this.props.onChange(dateString);
  },

  render() {
    var date = Moment(this.props.date);
    if (!date || !date.isValid()) { date = null; }

    var format = this.props.format || 'YYYY-MM-DD';

    return <Form inline className={ `date-control ${this.props.className || ''}` } id={ this.props.id }>
      {(() => {
        if (this.props.label) { return <ControlLabel>{ this.props.label }</ControlLabel>; }
      })()}
      <InputGroup>
        <DatePicker
          placeholderText={ this.props.placeholder }
          selected={ date }
          onChange={ this.dateChanged }
          dateformat={ format }
          popoverTargetOffset="31px 72px"
          utcOffset={ new Date().getTimezoneOffset() * -1 }
          customInput={ <InputControl inputRef={ ref => { this.input = ref; }}/> }
        />
        <InputGroup.Button>
          <Button onClick={ this.clicked }><Glyphicon glyph="calendar" title={ this.props.title }/></Button>
        </InputGroup.Button>
      </InputGroup>
    </Form>;
  },
});


export default DateControl;
