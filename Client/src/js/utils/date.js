import Moment from 'moment';

import * as Constant from '../constants';


export function dateIsBetween(date, startDate, endDate) {
  if (startDate && date.isBefore(startDate)) { return false; }
  if (endDate && date.isAfter(endDate)) { return false; }
  return true;
}

export function formatDateTime(dateTime, format) {
  if (!dateTime) { return ''; }
  var dt = Moment(dateTime);
  if (!dt || !dt.isValid()) { return ''; }
  if (!format) { format = Constant.DATE_TIME_ISO_8601; }
  return dt.format(format);
}

export function sortableDateTime(dateTime) {
  if (!dateTime) { return 0; }
  var dt = Moment(dateTime);
  if (!dt || !dt.isValid()) { return 0; }
  return dt.unix();
}


export function daysFromToday(dateTime) {
  var dt = Moment(dateTime);
  if (!dt || !dt.isValid()) { return 0; }
  var today = Moment().startOf('d');
  return dt.startOf('d').diff(today, 'd');
}

export function hoursAgo(dateTime) {
  var dt = Moment(dateTime);
  if (!dt || !dt.isValid()) { return 0; }
  var now = Moment();
  return now.diff(dt, 'h');
}

export function today(format) {
  if (!format) { format = Constant.DATE_TIME_ISO_8601; }
  var dt = Moment().startOf('d');
  return dt.format(format);
}

export function businessDayOnOrBefore(dateTime, format) {
  var dt = Moment(dateTime);
  if (!dt || !dt.isValid()) { return ''; }
  if (dt.day() === 6) {
    // Saturday
    dt.subtract(1, 'd');
  } else if (dt.day() === 0) {
    // Sunday
    dt.subtract(2, 'd');
  }
  // TODO: Holidays
  if (!format) { format = Constant.DATE_TIME_ISO_8601; }
  return dt.format(format);
}

export function isValidDate(dateTime) {
  var dt = Moment(dateTime);
  return (dt && dt.isValid());
}

export function toUTC(dateTime) {
  var dt = Moment(dateTime);
  if (!dt || !dt.isValid()) { return ''; }
  return dt.utc().format(Constant.DATE_ZULU);
}
