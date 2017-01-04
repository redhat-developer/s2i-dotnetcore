import React from 'react';
import _ from 'lodash';


const Spinner = (params) => {
  var styles = _.extend({}, _.pick(params, 'width', 'height'));

  var hide = '';

  if(params.show !== undefined) {
    hide = params.show ? '' : 'hide';
  }

  if(params.size !== undefined) {
    styles.width = +params.size || 16;
    styles.height = +params.size || 16;
  }

  var spinner = <span className={`spinner ${hide}`} style={styles}></span>;
  if(params.centre) {
    return <div style={{ textAlign: 'center' }}>{spinner}</div>;
  } else {
    return spinner;
  }
};

Spinner.PropTypes = {
  width: React.PropTypes.number,
  height: React.PropTypes.number,
  show: React.PropTypes.bool,
  centre: React.PropTypes.bool,
};

export default Spinner;
