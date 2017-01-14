import Moment from 'moment';

export function dateIsBetween(date, startDate, endDate) {
  if (startDate && date.isBefore(startDate)) { return false; }
  if (endDate && date.isAfter(endDate)) { return false; }
  return true;
}

export function formatDateTime(dateTime, format) {
  var dt = Moment(dateTime);
  if (!dt || !dt.isValid()) { return ''; }
  if (!format) { format = 'YYYY-MM-DDThh:mm:ss'; }
  return dt.format(format);
}

export function daysFromToday(dateTime) {
  var dt = Moment(dateTime);
  if (!dt || !dt.isValid()) { return 0; }
  var now = Moment();
  return dt.diff(now, 'days');
}

