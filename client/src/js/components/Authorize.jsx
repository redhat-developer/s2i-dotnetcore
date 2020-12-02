import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';

import { hasAllPermissions, hasSomePermissions } from '../utils/permissions';

const Authorize = ({ children, userPermissions, permissions, matchAll }) => {
  let valid = false;

  if (matchAll) valid = hasAllPermissions(userPermissions, permissions);
  else valid = hasSomePermissions(userPermissions, permissions);

  if (valid) return <>{children}</>;
  else return <></>;
};

Authorize.propTypes = {
  children: PropTypes.element.isRequired,
  // required permissions can be passed in as a single string or array of strings
  permissions: PropTypes.oneOfType([PropTypes.string, PropTypes.arrayOf(PropTypes.string)]).isRequired,
  matchAll: PropTypes.bool,
};

Authorize.defaultProps = {
  matchAll: true,
};

const mapStateToProps = (state) => {
  return {
    userPermissions: state.user.permissions,
  };
};

export default connect(mapStateToProps, null)(Authorize);
