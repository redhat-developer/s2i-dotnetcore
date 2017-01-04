import React from 'react';
import { connect } from 'react-redux';
import { Row, Col } from 'react-bootstrap';

var Owners = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
  },

  render: function() {
    return <div id="owners">
      <Row>
        <Col md={8}>
          <h1>Owners</h1>
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

export default connect(mapStateToProps)(Owners);
