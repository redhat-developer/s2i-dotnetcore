import React from 'react';
import PropTypes from 'prop-types';

import { connect } from 'react-redux';

import { PageHeader, Row, Col, Alert } from 'react-bootstrap';

import _ from 'lodash';
import Moment from 'moment';
import { formatDateTime, toZuluTime } from '../utils/date';

import * as Action from '../actionTypes';
import * as Api from '../api';
import * as Constant from '../constants';
import store from '../store';

import SortTable from '../components/SortTable.jsx';
import Markdown from 'react-markdown';

import Spinner from '../components/Spinner.jsx';
import Authorize from '../components/Authorize';
import logoImage from '../../images/logo.png';

class Home extends React.Component {
  static propTypes = {
    currentUser: PropTypes.object,
    districts: PropTypes.object,
    inspectors: PropTypes.object,
    ccwnotifications: PropTypes.object,
    search: PropTypes.object,
    ui: PropTypes.object,
  };

  constructor(props) {
    super(props);
    // var defaultSelectedDistricts = props.currentUser.isInspector ? [props.currentUser.districtId] : [];
    // var defaultSelectedInspectors = props.currentUser.isInspector ? [props.currentUser.id] : [];

    var defaultSelectedDistricts = [];
    var defaultSelectedInspectors = [];

    this.state = {
      loading: true,

      search: {
        selectedDistrictsIds: props.search.selectedDistrictsIds || defaultSelectedDistricts,
        selectedInspectorsIds: props.search.selectedInspectorsIds || defaultSelectedInspectors,
        keySearchField: props.search.keySearchField,
        keySearchText: props.search.keySearchText,
        keySearchParams: props.search.keySearchParams,
        hideRead: props.search.hideRead !== false,
        loaded: props.search.loaded === false,
      },

      ui: {
        sortField: 'dateDetected',
        sortDesc: true,
      },
    };
  }

  buildSearchParams = () => {
    if (this.state.search.keySearchParams) {
      // Use key search control params if there
      return this.state.search.keySearchParams;
    }

    var searchParams = {
      includeRead: !this.state.search.hideRead,
    };

    if (
      this.state.search.selectedDistrictsIds.length > 0 &&
      this.state.search.selectedDistrictsIds.length !== _.size(this.props.districts)
    ) {
      searchParams.districts = this.state.search.selectedDistrictsIds;
    }

    if (
      this.state.search.selectedInspectorsIds.length > 0 &&
      this.state.search.selectedInspectorsIds.length !== _.size(this.props.inspectors)
    ) {
      searchParams.inspectors = this.state.search.selectedInspectorsIds;
    }

    searchParams.dateFrom = toZuluTime(new Date('2020-09-01'));
    searchParams.dateTo = toZuluTime(Moment());

    return searchParams;
  };

  componentDidMount() {
    this.setState({ loading: true });
    this.fetch();
  }

  fetch = () => {
    this.setState({ loading: true });

    if (this.props.currentUser.isInspector) {
      return Api.getCCWNotifications(this.buildSearchParams()).finally(() => {
        this.setState({ loading: false });
      });
    } else {
      this.setState({ loading: false });
    }
  };

  updateSearchState = (state, callback) => {
    // Initializing the KeySearchControl causes a state change which we want to catch here by checking
    // state.keySearchOnMount; otherwise this will flag the search state as loaded before it actually is.
    var loaded = state.keySearchOnMount ? {} : { loaded: true };
    this.setState({ search: { ...this.state.search, ...state, ...loaded } }, () => {
      store.dispatch({
        type: Action.UPDATE_CCWNOTIFICATIONS_SEARCH,
        schoolBuses: this.state.search,
      });
      if (callback) {
        callback();
      }
    });
  };

  updateUIState = (state, callback) => {
    this.setState({ ui: { ...this.state.ui, ...state } }, () => {
      store.dispatch({
        type: Action.UPDATE_CCWNOTIFICATION_UI,
        ccwnotifications: this.state.ui,
      });
      if (callback) {
        callback();
      }
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
                        <a href={`#/${Constant.BUSES_PATHNAME}?${Constant.SCHOOL_BUS_WITHIN_30_DAYS_QUERY}=true`}>
                          {this.props.currentUser.dueWithin30DaysInspections}
                        </a>{' '}
                        inspections coming due within 30 days
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

        {(() => {
          if (this.state.loading) {
            return (
              <div style={{ textAlign: 'center' }}>
                <Spinner />
              </div>
            );
          }
          if (Object.keys(this.props.ccwnotifications).length === 0) {
            return <Alert bsStyle="success">No CCW changes</Alert>;
          }

          var ccwnotifications = _.sortBy(this.props.ccwnotifications, this.state.ui.sortField);
          if (this.state.ui.sortDesc) {
            _.reverse(ccwnotifications);
          }

          return (
            <SortTable
              sortField={this.state.ui.sortField}
              sortDesc={this.state.ui.sortDesc}
              onSort={this.updateUIState}
              headers={[
                { field: 'dateDetected', title: 'Date Detected' },
                { field: 'schoolBusRegNum', title: 'School Bus Reg#' },
                { field: 'schoolBusOwnerName', title: 'Current Owner' },
                { field: 'summary', title: 'Summary' },
              ]}
            >
              {_.map(ccwnotifications, (ccwnotification) => {
                return (
                  <tr key={ccwnotification.id}>
                    <td>{formatDateTime(ccwnotification.dateDetected, Constant.DATE_SHORT_MONTH_DAY_YEAR)}</td>
                    <td>
                      <a href={ccwnotification.schoolBusUrl}>{ccwnotification.schoolBusRegNum}</a>
                    </td>
                    <td>
                      <a href={ccwnotification.ownerURL}>{ccwnotification.schoolBusOwnerName}</a>
                    </td>
                    <td>
                      <Markdown source={ccwnotification.text}></Markdown>
                    </td>
                  </tr>
                );
              })}
            </SortTable>
          );
        })()}
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    currentUser: state.user,
    districts: state.lookups.districts,
    inspectors: state.lookups.inspectors,
    ccwnotifications: state.models.ccwnotifications,
    search: state.search.ccwnotifications,
    ui: state.ui.inspectionCounts,
  };
}

export default connect(mapStateToProps)(Home);
