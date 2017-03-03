import React from 'react';

var Main = React.createClass({
  propTypes: {
    location: React.PropTypes.object,
  },

  getInitialState() {
    return {
      path: this.props.location.pathname,
    };
  },

  render: function () {
    return <div id="not-found-screen">
      <h1>Not found <span>:(</span></h1>

      <p>Sorry, but the page you were trying to view ({ this.state.path }) does not exist. You can try going to the <a href="#">Home</a> page.</p>
    </div>;
  },
});

export default Main;
