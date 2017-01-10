import React from 'react';
import { connect } from 'react-redux';
import { Well, Alert, Table, Row, Col } from 'react-bootstrap';
import { ButtonToolbar, DropdownButton, MenuItem, Form, FormControl, Button, Glyphicon } from 'react-bootstrap';

import _ from 'lodash';
import Moment from 'moment';

import Spinner from '../components/Spinner.jsx';
import MultiDropdown from '../components/MultiDropdown.jsx';

import * as Api from '../api';

/*
Some notes on the searching:

* Service Area, Inspector, Cities, School District should be a multi-select - list with text search
* Key Search options are "Regi", "VIN" and "Plate" and correspond to those values from the SB table.
* Owner searching is allowed, but not driven by this screen.  The API needs to support it so that if a user clicks on their count of buses, the list of active buses for that Owner is returned.
* Date Range is based on just "Next Inspection"
** "Select Range" in UI is for named ranges (e.g. "Custom", "This Month", "Next Month", "This Quarter" etc.)
** Only show the From/To date fields if "Custom" is selected.
** Leave it to the server to convert so Favs can use the named range
** Need to include "Before Today" and "Before End of Month" and "Before End of Quarter" to include overdue inspections
** Could be others, but I don't see any likely candidates
* System default should be:
** If user is an inspector, Inspector == Current User else not used
** If the user is not an inspector, Service Areas in home district, else not used
** Next Inspection Date - "Before the End of the Month"
** Hide Inactive is checked

Logic: OR the values within a field, AND between fields.

Hopefully the Date thing makes sense - but basically, if the user selects anything other than "Custom", the Fav needs to save the Text selected (e.g. "Next Month"), not the specific dates.  That's the only way that Fav is useful.

I said in the JIRA let the server handle the conversion to From/To, but that's not crucial, as long as the Fav records the name of the date range.
*/

var SchoolBuses = React.createClass({
  propTypes: {
    schoolBuses: React.PropTypes.object,
    serviceAreas: React.PropTypes.object,
    inspectors: React.PropTypes.object,
    cities: React.PropTypes.object,
    schoolDistricts: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: false,
      selectedServiceAreasIds: [],
      selectedInspectorsIds: [],
      selectedCitiesIds: [],
      selectedSchoolDistrictsIds: [],
    };
  },

  componentDidMount() {
    this.fetch();
  },

  fetch(params) {
    this.setState({ loading: true });
    Api.getSchoolBuses(params).finally(() => {
      this.setState({ loading: false });
    });
  },

  serviceAreaChanged(selectedIds) {
    this.setState({
      selectedServiceAreasIds: selectedIds,
    });
  },

  inspectorsChanged(selectedIds) {
    this.setState({
      selectedInspectorsIds: selectedIds,
    });
  },

  citiesChanged(selectedIds) {
    this.setState({
      selectedCitiesIds: selectedIds,
    });
  },

  schoolDistrictsChanged(selectedIds) {
    this.setState({
      selectedSchoolDistrictsIds: selectedIds,
    });
  },

  render: function() {
    var serviceAreas = _.sortBy(this.props.serviceAreas, 'name');
    var inspectors = _.sortBy(this.props.inspectors, 'name');
    var cities = _.sortBy(this.props.cities, 'name');
    var schoolDistricts = _.sortBy(this.props.schoolDistricts, 'name');

    return <div id="school-buses">
      <Well id="school-buses-bar" bsSize="small" className="clearfix">
        <Row>
          <Col md={10}>
            <ButtonToolbar id="school-buses-search">
              <MultiDropdown id="service-areas-dropdown" placeholder="Service Areas" items={ serviceAreas } onChange={this.serviceAreasChanged} showMaxItems={1} />
              <MultiDropdown id="inspectors-dropdown" placeholder="Inspectors" items={ inspectors } onChange={this.inspectorsChanged} showMaxItems={1} />
              <MultiDropdown id="cities-dropdown" placeholder="Cities" items={ cities } onChange={this.citiesChanged} showMaxItems={1} />
              <MultiDropdown id="school-districts-dropdown" placeholder="School Districts" items={ schoolDistricts } onChange={this.schoolDistrictsChanged} showMaxItems={1} />
              <div className="search-label">Key Search By:</div>
              <DropdownButton id="school-buses-key-dropdown" title="Regi">
                <MenuItem key="regi" eventKey="1">Regi</MenuItem>
                <MenuItem key="win" eventKey="2">VIN</MenuItem>
                <MenuItem key="place" eventKey="3">Plate</MenuItem>
              </DropdownButton>
              <Form inline>
                <FormControl id="key-search-text" type="text" placeholder="" />
              </Form>
              <div>
              </div>
            </ButtonToolbar>
          </Col>
          <Col md={2}>
            <div id="school-buses-utils" className="pull-right">
              <Button><Glyphicon glyph="envelope" title="E-mail" /></Button>
              <Button><Glyphicon glyph="print" title="Print" /></Button>
              <DropdownButton id="school-buses-faves-dropdown" title="Faves">
                <MenuItem key="1" eventKey="1" disabled>No favourites</MenuItem>
              </DropdownButton>
            </div>
          </Col>
        </Row>
        <Row>
          <Col md={10}>
          </Col>
          <Col md={2}>
            <Button className="pull-right">Search</Button>
          </Col>
        </Row>
      </Well>

      {(() => {
        if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }
        if (Object.keys(this.props.schoolBuses).length === 0) { return <Alert bsStyle="info">No school buses</Alert>; }

        return <Table condensed striped>
          <thead>
            <tr>
              <th>Regi</th>
              <th>Owner</th>
              <th>Local Area</th>
              <th>Bus Location</th>
              <th>Fleet Unit #</th>
              <th>Permit</th>
              <th>Next Inspection</th>
              <th>Inspector</th>
            </tr>
          </thead>
          <tbody>
          {
            _.map(this.props.schoolBuses, (bus) => {
              var editPath = '#/school-buses/' + bus.id;
              var inspectionDt = Moment(bus.nextInspectionDate);
              return <tr key={ bus.id } className={ bus.status != 'active' ? 'info' : null }>
                <td><a href={ editPath }>{ bus.regi }</a></td>
                <td><a href='#'>{ bus.schoolBusOwner }</a></td>
                <td>{ bus.location }</td>
                <td>{ bus.busLocationCity }, { bus.busLocationPostCode }</td>
                <td></td>
                <td>{ bus.permitNumber }</td>
                <td>{ inspectionDt.format('MM/DD/YYYY') }</td>
                <td></td>
              </tr>;
            })
          }
          </tbody>
        </Table>;
      })()}

    </div>;
  },
});


function mapStateToProps(state) {
  var inspectors = {
    1: { id: 1, name: 'Fred Smith' },
    2: { id: 2, name: 'Joe Black' },
  };

  return {
    schoolBuses: state.models.schoolBuses,
    serviceAreas: state.lookups.serviceAreas,
    inspectors: inspectors,
    cities: state.lookups.cities,
    schoolDistricts: state.lookups.schoolDistricts,
  };
}

export default connect(mapStateToProps)(SchoolBuses);
