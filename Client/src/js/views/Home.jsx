import React from 'react';

import { connect } from 'react-redux';

import { PageHeader, Row, Col } from 'react-bootstrap';

import * as Constant from '../constants';


var Home = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
  },

  render: function() {
    return <div id="home">
      <Row>
        <Col md={8}>
          <Row>
            <PageHeader>
              {this.props.currentUser.fullName}<br/>{this.props.currentUser.districtName} District
            </PageHeader>
          </Row>
          { this.props.currentUser.isInspector &&
            <Row id="home-summary">
              <h2>You have <a href={ `#/school-buses?${ Constant.SCHOOL_BUS_OVERDUE_QUERY }=true` }>{this.props.currentUser.overdueInspections}</a> overdue inspections</h2>
              <h2>You have <a href={ `#/school-buses?${ Constant.SCHOOL_BUS_REINSPECTIONS_QUERY }=true` }>{this.props.currentUser.reInspections}</a> re-inspections scheduled</h2>
              <h2>You have <a href={ `#/school-buses?${ Constant.SCHOOL_BUS_NEXT_30_DAYS_QUERY }=true` }>{this.props.currentUser.dueNextMonthInspections}</a> inspections coming due in the next month</h2>
            </Row>
          }
        </Col>
        <Col md={4}>
          <img id="home-logo" src="images/logo.png"/>
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
