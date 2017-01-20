import React from 'react';

import { Row } from 'react-bootstrap';

import { connect } from 'react-redux';


var Footer = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
  },

  render: function () {
    return <footer id="footer">
      <div id="footerWrapper">
        <div id="footerAdminSection">
          <div id="footerAdminLinksContainer" className="container">
            <Row id="footerAdminLinks">
              <ul className="inline">
                <li><a href="#/home">Home</a></li>
                <li><a href="http://www2.gov.bc.ca/gov/content/about-gov-bc-ca">About gov.bc.ca</a></li>
                <li><a href="http://www2.gov.bc.ca/gov/content/home/disclaimer">Disclaimer </a></li>
                <li><a href="http://www2.gov.bc.ca/gov/content/home/privacy">Privacy</a></li>
                <li><a href="http://www2.gov.bc.ca/gov/content/home/accessibility">Accessibility</a></li>
                <li><a href="http://www2.gov.bc.ca/gov/content/home/copyright">Copyright</a></li>
                <li><a href="http://www2.gov.bc.ca/gov/content/home/contact-us">Contact Us</a></li>
                <li className="pull-right" style={{ border:0 }}><a href="#/version">Version</a></li>
              </ul>
            </Row>
          </div>
        </div>
      </div>
    </footer>;
  },
});


function mapStateToProps(state) {
  return {
    currentUser: state.user,
  };
}

export default connect(mapStateToProps, null, null, { pure:false })(Footer);
