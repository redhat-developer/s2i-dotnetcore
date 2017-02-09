import React from 'react';

import { connect } from 'react-redux';

import { PageHeader, Well, Row, Button } from 'react-bootstrap';

import $ from 'jquery';

import * as Api from '../api';

import ColField from '../components/ColField.jsx';
import ColLabel from '../components/ColLabel.jsx';
import Spinner from '../components/Spinner.jsx';

import { formatDateTime } from '../utils/date';
import { request } from '../utils/http';


var Version = React.createClass({
  propTypes: {
    version: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: false,
      showRawSection: false,
      buildtime : '',
      version : '',
      commit : '',
    };
  },

  componentDidMount() {
    this.setState({ loading: true });
    Api.getVersion().finally(() => {
      this.fetchLocal().finally(() => {
        this.setState({ loading: false });
      });
    });
  },

  fetchLocal() {
    return request('buildinfo.html', { silent: true }).then(xhr => {
      if (xhr.status === 200) {
        this.setState({
          buildTime : $(xhr.responseText).find('#buildtime').text(),
          version : $(xhr.responseText).find('#version').text(),
          commit : $(xhr.responseText).find('#commit').text(),
        });
      }
    }).catch(err => {
      console.err('Failed to find buildinfo: ', err);
    });
  },

  showRaw(e) {
    if (this.state.showRawSection) {
      this.setState({ showRawSection: false });
      e.target.textContent = 'Show Raw Versions';
    } else {
      this.setState({ showRawSection: true });
      e.target.textContent = 'Hide Raw Versions';
    }
  },

  render: function() {
    return <div id="version">
      <PageHeader>Version</PageHeader>

      {(() => {
        if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

        var applicationVersion = {};
        if (this.props.version.applicationVersions && this.props.version.applicationVersions.length > 0) {
          applicationVersion = this.props.version.applicationVersions[0];
        }
        var databaseVersion = {};
        var lastMigration = '';
        if (this.props.version.databaseVersions && this.props.version.databaseVersions.length > 0) {
          databaseVersion = this.props.version.databaseVersions[0];
          if (databaseVersion.appliedMigrations && databaseVersion.appliedMigrations.length > 0) {
            lastMigration = databaseVersion.appliedMigrations[databaseVersion.appliedMigrations.length - 1];
          }
        }

        return <div id="version-details">
          <Well>
            <h3>Client</h3>
            <Row>
              <ColLabel md={2}>Name</ColLabel>
              <ColField md={10}>MOTI School Bus Inspection Tracking System</ColField>
            </Row>
            <Row>
              <ColLabel md={2}>Build Time</ColLabel>
              <ColField md={10}>{ formatDateTime(this.state.buildTime) }</ColField>
            </Row>
{/*
            <Row>
              <ColLabel md={2}>Version</ColLabel>
              <ColField md={10}>{ this.state.version }</ColField>
            </Row>
*/}
            <Row>
              <ColLabel md={2}>Git Commit</ColLabel>
              <ColField md={10}>{ this.state.commit }</ColField>
            </Row>
            <Row>
              <ColLabel md={2}>User Agent</ColLabel>
              <ColField md={10}>{ navigator.userAgent }</ColField>
            </Row>
          </Well>
          <Well>
            <h3>Application</h3>
            <Row>
              <ColLabel md={2}>Name</ColLabel>
              <ColField md={10}>{ applicationVersion.title }</ColField>
            </Row>
            <Row>
              <ColLabel md={2}>Build Time</ColLabel>
              <ColField md={10}>{ formatDateTime(applicationVersion.fileCreationTime) }</ColField>
            </Row>
            <Row>
              <ColLabel md={2}>Version</ColLabel>
              <ColField md={10}>{ applicationVersion.informationalVersion }</ColField>
            </Row>
            <Row>
              <ColLabel md={2}>Git Commit</ColLabel>
              <ColField md={10}>{ applicationVersion.commit }</ColField>
            </Row>
          </Well>
          <Well>
            <h3>Database</h3>
            <Row>
              <ColLabel md={2}>Name</ColLabel>
              <ColField md={10}>{ databaseVersion.database }</ColField>
            </Row>
            <Row>
              <ColLabel md={2}>Server</ColLabel>
              <ColField md={10}>{ databaseVersion.server }</ColField>
            </Row>
            <Row>
              <ColLabel md={2}>Version</ColLabel>
              <ColField md={10}>{ databaseVersion.version }</ColField>
            </Row>
            <Row>
              <ColLabel md={2}>Last Migration</ColLabel>
              <ColField md={10}>{ lastMigration }</ColField>
            </Row>
          </Well>
          <Button onClick={ this.showRaw }>Show Raw Versions</Button>
          <Well style={{ marginTop: '20px' }} className={ this.state.showRawSection ? '' : 'hide' }>
            <div>{ JSON.stringify(this.props.version) }</div>
          </Well>
        </div>;
      })()}
    </div>;
  },
});


function mapStateToProps(state) {
  return {
    version: state.version,
  };
}

export default connect(mapStateToProps)(Version);

