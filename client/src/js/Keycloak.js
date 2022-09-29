import Keycloak from 'keycloak-js';

const keycloakConfig = {
  url: window.RUNTIME_REACT_APP_SSO_HOST ? window.RUNTIME_REACT_APP_SSO_HOST : process.env.REACT_APP_SSO_HOST,
  realm: window.RUNTIME_REACT_APP_SSO_REALM ? window.RUNTIME_REACT_APP_SSO_REALM : process.env.REACT_APP_SSO_REALM,
  clientId: window.RUNTIME_REACT_APP_SSO_CLIENT
    ? window.RUNTIME_REACT_APP_SSO_CLIENT
    : process.env.REACT_APP_SSO_CLIENT,
};

export const keycloak = Keycloak(keycloakConfig);

export const init = (onSuccess) => {
  keycloak.init({ onLoad: 'login-required', promiseType: 'native', pkceMethod: 'S256' }).then((authenticated) => {
    if (authenticated && onSuccess) {
      onSuccess();
    }
  });

  keycloak.onAuthLogout = () => {
    window.location.reload();
  };
};

export const logout = () => {
  keycloak.logout();
};
