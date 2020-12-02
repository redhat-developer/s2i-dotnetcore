import 'react-app-polyfill/ie11';
import 'react-app-polyfill/stable';

import React, { lazy, Suspense } from 'react';
import ReactDOM from 'react-dom';

import * as serviceWorker from './serviceWorker';

/* eslint-disable import/first */
const App = lazy(() => import('./js/app'));

import * as Keycloak from './js/Keycloak';

import 'bootstrap/dist/css/bootstrap.css';
import './sass/main.scss';

Keycloak.init(() => {
  ReactDOM.render(
    <Suspense fallback={<div></div>}>
      <App />
    </Suspense>,
    document.getElementById('root')
  );
});

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
