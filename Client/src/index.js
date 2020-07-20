import "react-app-polyfill/ie11";
import "react-app-polyfill/stable";

import React from "react";
import ReactDOM from "react-dom";

import * as serviceWorker from "./serviceWorker";

import App from "./js/app";
import * as Keycloak from "./js/Keycloak";

import "bootstrap/dist/css/bootstrap.css";
import "./sass/main.scss";

Keycloak.init(() => {
  ReactDOM.render(<App />, document.getElementById("root"));
});

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
