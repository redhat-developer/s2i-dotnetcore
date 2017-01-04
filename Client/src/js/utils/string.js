export function dasherize(str) {
  return str.trim().replace(/([A-Z])/g, '-$1').replace(/[-_\s]+/g, '-').toLowerCase();
}

export function plural(num, singular, plural) {
  return num === 1 ? singular : plural;
}
