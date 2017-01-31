import Moment from 'moment';

export function dateIsBetween(date, startDate, endDate) {
  if (startDate && date.isBefore(startDate)) { return false; }
  if (endDate && date.isAfter(endDate)) { return false; }
  return true;
}

export function formatDateTime(dateTime, format) {
  if (!dateTime) { return ''; }
  var dt = Moment(dateTime);
  if (!dt || !dt.isValid()) { return ''; }
  if (!format) { format = 'YYYY-MM-DDTHH:mm:ss'; }
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
  var now = Moment();
  return dt.diff(now, 'days');
}

export function hoursAgo(dateTime) {
  var dt = Moment(dateTime);
  if (!dt || !dt.isValid()) { return 0; }
  var now = Moment();
  return now.diff(dt, 'hours');
}

export function today(format) {
  if (!format) { format = 'YYYY-MM-DDTHH:mm:ss'; }
  var dt = Moment();
  return dt.format(format);
}
