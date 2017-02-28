import React from 'react';

import { connect } from 'react-redux';

import { PageHeader, Well, Row, Col } from 'react-bootstrap';
import { Button, ButtonGroup, Glyphicon } from 'react-bootstrap';


import $ from 'jquery';

import * as Api from '../api';
import * as Constant from '../constants';

import ColDisplay from '../components/ColDisplay.jsx';
import Spinner from '../components/Spinner.jsx';
import Unimplemented from '../components/Unimplemented.jsx';

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

  email() {

  },

  print() {

  },

  render: function() {
    return <div id="version">
      <PageHeader>
        <Row id="version-header">
          <Col md={11}>Version</Col>
          <Col md={1}>
            <div id="version-buttons">
              <ButtonGroup>
                <Unimplemented>
                  <Button onClick={ this.email }><Glyphicon glyph="envelope" title="E-mail" /></Button>
                </Unimplemented>
                <Unimplemented>
                  <Button onClick={ this.print }><Glyphicon glyph="print" title="Print" /></Button>
                </Unimplemented>
              </ButtonGroup>
            </div>
          </Col>
        </Row>
      </PageHeader>


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
              <ColDisplay md={12} label="Name">MOTI School Bus Inspection Tracking System</ColDisplay>
            </Row>
            <Row>
              <ColDisplay md={12} label="Build Time">{ formatDateTime(this.state.buildTime, Constant.DATE_TIME_READABLE) }</ColDisplay>
            </Row>
{/*
            <Row>
              <ColDisplay md={12} label="Version">{ this.state.version }</ColDisplay>
            </Row>
*/}
            <Row>
              <ColDisplay md={12} label="Git Commit">{ this.state.commit }</ColDisplay>
            </Row>
            <Row>
              <ColDisplay md={12} label="User Agent">{ navigator.userAgent }</ColDisplay>
            </Row>
          </Well>
          <Well>
            <h3>Application</h3>
            <Row>
              <ColDisplay md={12} label="Name">{ applicationVersion.title }</ColDisplay>
            </Row>
            <Row>
              <ColDisplay md={12} label="Build Time">{ formatDateTime(applicationVersion.fileCreationTime, Constant.DATE_TIME_READABLE) }</ColDisplay>
            </Row>
            <Row>
              <ColDisplay md={12} label="Version">{ applicationVersion.informationalVersion }</ColDisplay>
            </Row>
            <Row>
              <ColDisplay md={12} label="Git Commit">{ applicationVersion.commit }</ColDisplay>
            </Row>
          </Well>
          <Well>
            <h3>Database</h3>
            <Row>
              <ColDisplay md={12} label="Name">{ databaseVersion.database }</ColDisplay>
            </Row>
            <Row>
              <ColDisplay md={12} label="Server">{ databaseVersion.server }</ColDisplay>
            </Row>
            <Row>
              <ColDisplay md={12} label="Version">{ databaseVersion.version }</ColDisplay>
            </Row>
            <Row>
              <ColDisplay md={12} label="Last Migration">{ lastMigration }</ColDisplay>
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

