import React from "react";
import PropTypes from "prop-types";

import { connect } from "react-redux";

import * as Api from "../api";

import TopNav from "./TopNav.jsx";
import Footer from "./Footer.jsx";

class Main extends React.Component {
  static propTypes = {
    children: PropTypes.object,
  };

  componentDidMount() {
    Api.getVersion();
  }

  render() {
    return (
      <div id="main">
        <TopNav />
        <div id="screen" className="template container">
          {this.props.children}
        </div>
        <Footer />
      </div>
    );
  }
}

export default connect()(Main);
