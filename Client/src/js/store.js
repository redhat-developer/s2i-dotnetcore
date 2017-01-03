import { createStore } from 'redux';
import allReducers from './reducers/all';

const store = createStore(allReducers);

store.getModel = function storeGetModel(modelType, id) {
  var models = store.getState().models;

  if(!modelType) {
    throw new TypeError('param modelType required');
  }

  if(!id) {
    throw new TypeError('param id required');
  }

  if(!(modelType in models)) {
    throw new Error(`No model of type ${modelType} in store`);
  }

  var model = (models[modelType] || {})[id];

  if(!model) {
    throw new Error(`No ${modelType} model with id of ${id} in store`);
  }

  return model;
};

export default store;
