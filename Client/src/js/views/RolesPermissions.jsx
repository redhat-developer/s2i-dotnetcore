import React from 'react';
import { connect } from 'react-redux';
import { Row, Col } from 'react-bootstrap';

var RolesPermissions = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
  },

  render: function() {
    return <div id="roles-permissions">
      <Row>
        <Col md={8}>
          <h1>Roles and Permissions</h1>
        </Col>
      </Row>
    </div>;
  },
});


function mapStateToProps(state) {
  return {
    currentUser: state.user,
  };
}

export default connect(mapStateToProps)(RolesPermissions);
