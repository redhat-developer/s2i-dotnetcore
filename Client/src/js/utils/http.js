import _ from 'lodash';
import Promise from 'bluebird';

import * as Action from '../actionTypes';
import store from '../store';

const ROOT_API_PREFIX = location.pathname === '/' ? '' : location.pathname.split('/').slice(0, -1).join('/');

var numRequestsInFlight = 0;

function incrementRequests() {
  numRequestsInFlight += 1;
  if(numRequestsInFlight === 1) {
    store.dispatch({ type: Action.REQUESTS_BEGIN });
  }
}

function decrementRequests() {
  numRequestsInFlight -= 1;
  if(numRequestsInFlight <= 0) {
    numRequestsInFlight = 0; // sanity check;
    store.dispatch({ type: Action.REQUESTS_END });
  }
}


export const HttpError = function(msg, method, path, status, body) {
  this.message = msg || '';
  this.method = method;
  this.path = path;
  this.status = status || null;
  this.body = body;
};

HttpError.prototype = Object.create(Error.prototype, {
  constructor: { value: HttpError },
});


export const ApiError = function(msg, method, path, status, html) {
  this.message = msg || '';
  this.method = method;
  this.path = path;
  this.status = status || null;
  this.html = html;
};

ApiError.prototype = Object.create(Error.prototype, {
  constructor: { value: ApiError },
});


export const Resource404 = function(name, id) {
  this.name = name;
  this.id = id;
};

Resource404.prototype = Object.create(Error.prototype, {
  constructor: { value: Resource404 },
  toString: { value() {
    return `Resouce ${this.name} #${this.id} Not Found`;
  }},
});


export function request(path, options) {
  options = options || {};
  options.headers = Object.assign({
    'Content-Type': 'application/x-www-form-urlencoded',
  }, options.headers || {});
  var xhr = new XMLHttpRequest();
  var method = (options.method || 'GET').toUpperCase();

  return new Promise((resolve, reject, onCancel) => {
    onCancel(function() {
      if(!options.silent) { decrementRequests(); }
      xhr.abort();
    });
    xhr.addEventListener('load', function() {
      if(xhr.status >= 400) {
        var err = new HttpError(`API ${method} ${path} failed (${xhr.status}) "${xhr.responseText}"`, method, path, xhr.status, xhr.responseText);
        reject(err);
      } else {
        resolve(xhr);
      }
    });

    xhr.addEventListener('error', function() {
      reject(new HttpError(`Request ${method} ${path} failed to send`, method, path));
    });

    var qs = _.map(options.querystring, (value, key) => `${encodeURIComponent(key)}=${encodeURIComponent(value)}`).join('&');
    xhr.open(method, `${path}${qs ? '?' : ''}${qs}`, true);

    Object.keys(options.headers).forEach(key => {
      xhr.setRequestHeader(key, options.headers[key]);
    });

    if(!options.silent) {
      incrementRequests();
    }

    xhr.send(options.body || null);
  }).finally(() => {
    if(!options.silent) { decrementRequests(); }
  });
}


export function jsonRequest(path, options) {
  var jsonHeaders = {
    'Accept': 'application/json',
  };

  if(options.body) {
    options.body = JSON.stringify(options.body);
    jsonHeaders['Content-Type'] = 'application/json';
  }

  options.headers = Object.assign(options.headers || {}, jsonHeaders);

  return request(path, options).then(xhr => {
    if (xhr.status === 204) {
      return;
    } else {
      return xhr.responseText ? JSON.parse(xhr.responseText) : null;
    }
  }).catch(err => {
    if (err instanceof HttpError) {
      var apiError = new ApiError(`API ${err.method} ${err.path} failed (${err.status})`, err.method, err.path, err.status, err.body);

      store.dispatch({ type: Action.REQUESTS_ERROR, error: apiError });

      throw apiError;
    } else {
      throw err;
    }
  });
}


export function ApiRequest(path) {
  this.path = `${ROOT_API_PREFIX}/api/${path}`.replace('//', '/'); // remove double slashes
}

ApiRequest.prototype.get = function apiGet(params) {
  return jsonRequest(this.path, { method: 'GET', querystring: params });
};

ApiRequest.prototype.post = function apiPost(data) {
  return jsonRequest(this.path, { method: 'POST', body: data });
};

ApiRequest.prototype.put = function apiPut(data) {
  return jsonRequest(this.path, { method: 'PUT', body: data });
};

ApiRequest.prototype.delete = function apiDelete(data) {
  return jsonRequest(this.path, { method: 'DELETE', body: data });
};
