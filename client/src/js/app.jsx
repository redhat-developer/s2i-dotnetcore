import React, { useState, useEffect } from 'react';
import { Provider } from 'react-redux';
import { Router, Route, Redirect, hashHistory } from 'react-router';
import { ProgressBar } from 'react-bootstrap';

import * as Constant from './constants';
import store from './store';

import * as Api from './api';
import { ApiError } from './utils/http';
import { hasAllPermissions } from './utils/permissions';

import Main from './views/Main.jsx';
import Home from './views/Home.jsx';
import SchoolBuses from './views/SchoolBuses.jsx';
import SchoolBusesDetail from './views/SchoolBusesDetail.jsx';
import Owners from './views/Owners.jsx';
import OwnersDetail from './views/OwnersDetail.jsx';
import CCWNotifications from './views/CCWNotifications.jsx';
import Users from './views/Users.jsx';
import UsersDetail from './views/UsersDetail.jsx';
import Roles from './views/Roles.jsx';
import RolesDetail from './views/RolesDetail.jsx';
import Version from './views/Version.jsx';
import FourOhFour from './views/404.jsx';

import addIconsToLibrary from './fontAwesome';

const App = () => {
  const [loading, setLoading] = useState(true);
  const [apiError, setApiError] = useState(null);
  const [loadProgress, setLoadProgress] = useState(5);

  addIconsToLibrary();
  
  useEffect(() => {
    Api.getCurrentUser()
      .then(() => {
        setLoadProgress(50);
        // Check permissions?

        // Get lookups.
        var citiesPromise = Api.getCities();
        var districtsPromise = Api.getDistricts();
        var regionsPromise = Api.getRegions();
        var schoolDistrictsPromise = Api.getSchoolDistricts();
        var serviceAreasPromise = Api.getServiceAreas();
        var permissionsPromise = Api.getPermissions();

        return Promise.all([
          citiesPromise,
          districtsPromise,
          regionsPromise,
          schoolDistrictsPromise,
          serviceAreasPromise,
          permissionsPromise,
        ]).then(() => {
          setLoadProgress(75);
          setLoading(false);
        });
      })
      .catch((err) => {
        console.error(err);
        if (err instanceof ApiError) {
          if (err.status) {
            switch (err.status) {
              case 401:
                setApiError('If you feel you are receiving this message in error, please contact ');
                break;
              default:
                setApiError(
                  'An unknown error has occoured. Please try again later. If the problem persists, please contact '
                );
                break;
            }
          } else {
            setApiError(
              'An unknown error has occoured. Please try again later. If the problem persists, please contact '
            );
          }
        }
      });
  }, []);

  if (loading)
    return (
      <div id="initialization">
        <p id="init-message">Loading School Bus&hellip;</p>

        <div id="init-process" className="progress">
          <ProgressBar
            bsStyle={apiError === null ? 'info' : 'danger'}
            striped
            active={apiError === null}
            now={loadProgress}
            min={0}
            max={100}
            label={`${loadProgress}% Complete`}
            srOnly
          ></ProgressBar>
        </div>

        <div id="init-error">
          {apiError != null && (
            <div id="loading-error-message">
              <h4>Error loading application</h4>
              <p>
                {apiError}
                <a href="mailto:tranit@gov.bc.ca" target="_top">
                  TRANIT
                </a>
              </p>
            </div>
          )}
        </div>
      </div>
    );

  return (
    <Provider store={store}>
      <Router history={hashHistory}>
        <Redirect from="/" to={`/${Constant.HOME_PATHNAME}`} />
        <Route path="/" component={Main}>
          <Route path={Constant.HOME_PATHNAME} component={Home} />
          <Route path={Constant.BUSES_PATHNAME} component={SchoolBuses} />
          <Route path={`${Constant.BUSES_PATHNAME}/:schoolBusId`} component={SchoolBusesDetail} />
          <Route
            path={`${Constant.BUSES_PATHNAME}/:schoolBusId/${Constant.INSPECTION_PATHNAME}/:inspectionId`}
            component={SchoolBusesDetail}
          />
          <Route path={Constant.OWNERS_PATHNAME} component={Owners} />
          <Route path={`${Constant.OWNERS_PATHNAME}/:ownerId`} component={OwnersDetail} />
          <Route
            path={`${Constant.OWNERS_PATHNAME}/:ownerId/${Constant.CONTACT_PATHNAME}/:contactId`}
            component={OwnersDetail}
          />
          <Route path={Constant.CCWNOTIFICATIONS_PATHNAME} component={CCWNotifications} />
          {hasAllPermissions(store.getState().user.permissions, Constant.PERMISSION_USER_R) && (
            <>
              <Route path={Constant.USERS_PATHNAME} component={Users} />
              <Route path={`${Constant.USERS_PATHNAME}/:userId`} component={UsersDetail} />
            </>
          )}
          {hasAllPermissions(store.getState().user.permissions, Constant.PERMISSION_ROLE_R) && (
            <>
              <Route path={Constant.ROLES_PATHNAME} component={Roles} />
              <Route path={`${Constant.ROLES_PATHNAME}/:roleId`} component={RolesDetail} />
            </>
          )}

          <Route path={Constant.VERSION_PATHNAME} component={Version} />
          <Route path="*" component={FourOhFour} />
        </Route>
      </Router>
    </Provider>
  );
};

export default App;
