import Moment from 'moment';

export function dateIsBetween(date, startDate, endDate) {
  if (startDate && date.isBefore(startDate)) { return false; }
  if (endDate && date.isAfter(endDate)) { return false; }
  return true;
}

export function formatDateTime(dateTime, format) {
  if (!dateTime) { return ''; }
  var dt = Moment(dateTime);
  if (!dt) { return ''; }
  return dt.format(format);
}

export function daysFromToday(dateTime) {
  if (!dateTime) { return ''; }
  var dt = Moment(dateTime);
  if (!dt) { return 0; }
  var now = Moment();
  return dt.diff(now, 'days');
}
