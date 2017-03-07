import React from 'react';

import { PageHeader, Table } from 'react-bootstrap';


var BodyDescription = React.createClass({
  render() {
    return <div id="school-buses-body-description">
      <PageHeader>School Bus Body Description</PageHeader>

      <Table condensed>
        <tbody>
          <tr>
            <td colSpan="2"><h3>Yellow and Black</h3></td>
          </tr>
          <tr>
            <td>a.</td>
            <td className="desc">Means a bus that is identified with the colour yellow and black and on the date of its manufacture conformed to the safety standards under the <a href="http://laws-lois.justice.gc.ca/eng/acts/M-10.01/index.html" target="_blank"><i>Motor Vehicle Safety Act</i></a> (Canada) and the standards made by the Canadian Standards Association numbered CSA D250, "School Buses" that were applicable to school buses on that date.</td>
          </tr>
          <tr>
            <td colSpan="2"><h3>Bus</h3></td>
          </tr>
          <tr>
            <td>b.</td>
            <td className="desc">Means a motor vehicle designed to carry more than 10 persons, but does not include a yellow and black or coach bus. </td>
          </tr>
          <tr>
            <td colSpan="2"><h3>Coach Bus</h3></td>
          </tr>
          <tr>
            <td>c.</td>
            <td className="desc">Means a motor vehicle designed to provide intercity, commuter or charter service.</td>
          </tr>
          <tr>
            <td colSpan="2"><h3>Mobility Aid</h3></td>
          </tr>
          <tr>
            <td>d.</td>
            <td className="desc">Means a motor vehicle designed to carry persons that is designed or modified for transportation of non-ambulatory persons.</td>
          </tr>
          <tr>
            <td colSpan="2"><h3>Van</h3></td>
          </tr>
          <tr>
            <td>e.</td>
            <td className="desc">Means a vehicle that is designed to carry more than 10 persons, but the body style may not be identifiable as a bus, such as a 15 passenger van.  </td>
          </tr>
          <tr>
            <td colSpan="2"><h3>Other</h3></td>
          </tr>
          <tr>
            <td>f.</td>
            <td className="desc">Means a vehicle that requires a school bus permit and is not identified in the above listed body descriptions</td>
          </tr>
        </tbody>
      </Table>
    </div>;
  },
});


export default BodyDescription;
