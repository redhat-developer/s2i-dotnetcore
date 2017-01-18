export function dasherize(str) {
  return str.trim().replace(/([A-Z])/g, '-$1').replace(/[-_\s]+/g, '-').toLowerCase();
}

export function plural(num, singular, plural) {
  return num === 1 ? singular : plural;
}

export function concat(left, right, sep) {
  if (!sep) { sep = ' '; }
  var a = left ? left.trim() : null;
  var b = right ? right.trim() : null;
  if (a && b) { return `${a}${sep}${b}`; }
  if (a) { return a; }
  if (b) { return b; }
  return '';
}

export function firstLastName(first, last) {
  return concat(first, last);
}

export function lastFirstName(last, first) {
  return concat(last, first, ', ');
}

export function isBlank(str) {
  return str.trim().length === 0;
}

export function notBlank(str) {
  return str.trim().length > 0;
}
