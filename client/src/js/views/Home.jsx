import React from 'react';
import PropTypes from 'prop-types';

import { connect } from 'react-redux';

import { PageHeader, Row, Col } from 'react-bootstrap';

import * as Constant from '../constants';
import * as Api from '../api.js';
import Spinner from '../components/Spinner.jsx';
import Authorize from '../components/Authorize';
import logoImage from '../../images/logo.png';

class Home extends React.Component {
  static propTypes = {
    currentUser: PropTypes.object,
  };

  state = {
    loading: true,
  };

  componentDidMount() {
    this.fetch();
  }

  fetch = () => {
    this.setState({ loading: true });
    return Api.getCurrentUser().finally(() => {
      this.setState({ loading: false });
    });
  };

  render() {
    return (
      <div id="home">
        <Row>
          <Col md={8}>
            <Row>
              <PageHeader>
                {this.props.currentUser.fullName}
                <br />
                {this.props.currentUser.districtName} District
              </PageHeader>
            </Row>

            {(() => {
              if (this.state.loading) {
                return (
                  <div style={{ textAlign: 'center' }}>
                    <Spinner />
                  </div>
                );
              } else {
                return (
                  <Authorize permissions={Constant.PERMISSION_HOME}>
                    <Row id="home-summary">
                      <h2>
                        You have{' '}
                        <a href={`#/${Constant.BUSES_PATHNAME}?${Constant.SCHOOL_BUS_OVERDUE_QUERY}=true`}>
                          {this.props.currentUser.overdueInspections}
                        </a>{' '}
                        overdue inspections
                      </h2>
                      <h2>
                        You have{' '}
                        <a href={`#/${Constant.BUSES_PATHNAME}?${Constant.SCHOOL_BUS_REINSPECTIONS_QUERY}=true`}>
                          {this.props.currentUser.reInspections}
                        </a>{' '}
                        re-inspections scheduled
                      </h2>
                      <h2>
                        You have{' '}
                        <a href={`#/${Constant.BUSES_PATHNAME}?${Constant.SCHOOL_BUS_NEXT_MONTH_QUERY}=true`}>
                          {this.props.currentUser.dueNextMonthInspections}
                        </a>{' '}
                        inspections coming due in the next month
                      </h2>
                    </Row>
                  </Authorize>
                );
              }
            })()}
          </Col>
          <Col md={4}>
            <img id="home-logo" src={logoImage} alt="" />
          </Col>
        </Row>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    currentUser: state.user,
  };
}

export default connect(mapStateToProps)(Home);
