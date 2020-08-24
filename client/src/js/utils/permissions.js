const stringToArray = (input) => {
  if (Array.isArray(input)) return input;
  else if (typeof input === 'string') return [input];
  else throw new Error('Parameter is not a string or array');
};

export const hasAllPermissions = (userPermissions, requiredPermissions) => {
  let permissionsToCheck = stringToArray(requiredPermissions);

  return permissionsToCheck.every((item) => userPermissions.includes(item));
};

export const hasSomePermissions = (userPermissions, requiredPermissions) => {
  let permissionsToCheck = stringToArray(requiredPermissions);

  return permissionsToCheck.some((item) => userPermissions.includes(item));
};
