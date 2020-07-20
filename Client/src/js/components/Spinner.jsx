import React from "react";
import PropTypes from "prop-types";
import _ from "lodash";

const Spinner = (params) => {
  var styles = _.extend({}, _.pick(params, "width", "height"));

  var hide = "";

  if (params.show !== undefined) {
    hide = params.show ? "" : "hide";
  }

  if (params.size !== undefined) {
    styles.width = +params.size || 16;
    styles.height = +params.size || 16;
  }

  var spinner = <span className={`spinner ${hide}`} style={styles}></span>;
  if (params.centre) {
    return <div style={{ textAlign: "center" }}>{spinner}</div>;
  } else {
    return spinner;
  }
};

Spinner.propTypes = {
  width: PropTypes.number,
  height: PropTypes.number,
  show: PropTypes.bool,
  centre: PropTypes.bool,
};

export default Spinner;
