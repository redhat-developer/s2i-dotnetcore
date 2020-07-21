#!/bin/sh

echo "---> Setting window.RUNTIME_REACT_APP values ..."
JS_PATH=~/js/env.config.js

echo "window.RUNTIME_REACT_APP_SSO_HOST='${REACT_APP_SSO_HOST}';" > $JS_PATH
echo "window.RUNTIME_REACT_APP_SSO_REALM='${REACT_APP_SSO_REALM}';" >> $JS_PATH
echo "window.RUNTIME_REACT_APP_SSO_CLIENT='${REACT_APP_SSO_CLIENT}';" >> $JS_PATH
echo "window.RUNTIME_REACT_APP_API_HOST='${REACT_APP_API_HOST}';" >> $JS_PATH

echo "---> Creating nginx.conf ..."
envsubst '${DEPLOY_SUFFIX}' < /tmp/src/nginx.conf.tmpl > /etc/nginx/nginx.conf