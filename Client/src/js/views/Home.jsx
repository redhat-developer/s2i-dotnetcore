import React from 'react';
import { connect } from 'react-redux';
import { Row, Col } from 'react-bootstrap';

var Home = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
  },

  render: function() {
    return <div id="home">
      <Row>
        <Col md={8}>
          <h1>{this.props.currentUser.fullName}<br/>{this.props.currentUser.districtName} District</h1>
          <br/>
          <h2>You have <a href="#/school-buses">{this.props.currentUser.overdueInspections}</a> overdue inspections</h2>
          <h2>You have <a href="#/school-buses">{this.props.currentUser.scheduledReinspections}</a> re-inspections scheduled</h2>
          <h2>You have <a href="#/school-buses">{this.props.currentUser.dueNextMonthInspections}</a> inspections coming due in the next month</h2>
        </Col>
        <Col md={4}>
          [insert legal image here]
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

export default connect(mapStateToProps)(Home);
