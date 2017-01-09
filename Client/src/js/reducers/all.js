import { combineReducers } from 'redux';

import uiReducer     from './ui';
import userReducer   from './user';
import modelsReducer from './models';


export default combineReducers({
  user   : userReducer,
  models : modelsReducer,
  ui     : uiReducer,
});
