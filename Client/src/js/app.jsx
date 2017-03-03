import React from 'react';
import { Provider } from 'react-redux';
import { Router, Route, Redirect, hashHistory } from 'react-router';

import * as Constant from './constants';
import store from './store';

import Main from './views/Main.jsx';
import Home from './views/Home.jsx';
import SchoolBuses from './views/SchoolBuses.jsx';
import SchoolBusesDetail from './views/SchoolBusesDetail.jsx';
import Owners from './views/Owners.jsx';
import OwnersDetail from './views/OwnersDetail.jsx';
import Notifications from './views/Notifications.jsx';
import Users from './views/Users.jsx';
import UsersDetail from './views/UsersDetail.jsx';
import Roles from './views/Roles.jsx';
import RolesDetail from './views/RolesDetail.jsx';
import Version from './views/Version.jsx';
import FourOhFour from './views/404.jsx';


const App = <Provider store={ store }>
  <Router history={ hashHistory }>
    <Redirect from="/" to={`/${ Constant.HOME_PATHNAME }`}/>
    <Route path="/" component={ Main }>
      <Route path={ Constant.HOME_PATHNAME } component={ Home }/>
      <Route path={ Constant.BUSES_PATHNAME } component={ SchoolBuses }/>
      <Route path={ `${ Constant.BUSES_PATHNAME }/:schoolBusId` } component={ SchoolBusesDetail }/>
      <Route path={ Constant.OWNERS_PATHNAME } component={ Owners }/>
      <Route path={ `${ Constant.OWNERS_PATHNAME }/:ownerId` } component={ OwnersDetail }/>
      <Route path={ Constant.NOTIFICATIONS_PATHNAME } component={ Notifications }/>
      <Route path={ Constant.USERS_PATHNAME } component={ Users }/>
      <Route path={ `${ Constant.USERS_PATHNAME }/:userId` } component={ UsersDetail }/>
      <Route path={ Constant.ROLES_PATHNAME } component={ Roles }/>
      <Route path={ `${ Constant.USERS_PATHNAME }/:roleId` } component={ RolesDetail }/>
      <Route path={ Constant.VERSION_PATHNAME } component={ Version }/>
      <Route path="*" component={ FourOhFour }/>
    </Route>
  </Router>
</Provider>;


export default App;
