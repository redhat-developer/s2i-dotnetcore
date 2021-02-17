"use strict";
const axios = require("axios");
const _ = require("lodash");

const util = require("./utils");

module.exports = class KeyCloakClient {
  constructor(settings, oc) {
    this.phases = settings.phases;
    this.options = settings.options;
    this.oc = oc;
    this.appHost = this.phases.dev.host;
  }

  async init() {
    this.getSecrets();

    this.apiTokenPath = `/auth/realms/${this.realmId}/protocol/openid-connect/token`;
    this.appClientPath = `auth/admin/realms/${this.realmId}/clients/${this.appClientId}`;
    this.api = axios.create({
      baseURL: `https://${this.ssoHost}`,
    });

    const token = await this.getAccessToken();

    this.api.defaults.headers.common = {
      Authorization: `Bearer ${token}`,
    };
  }

  getSecrets() {
    const secret = util.getSecret(
      this.oc,
      this.phases.build.namespace,
      "keycloak-service-account"
    );

    this.clientId = Buffer.from(secret.clientId, "base64").toString();
    this.clientSecret = Buffer.from(secret.clientSecret, "base64").toString();
    this.appClientId = Buffer.from(secret.appClientId, "base64").toString();
    this.realmId = Buffer.from(secret.realmId, "base64").toString();
    this.ssoHost = Buffer.from(secret.host, "base64").toString();

    if (!this.clientId || !this.clientSecret || !this.appClientId)
      throw new Error(
        "Unable to retrieve Keycloak service account info from OpenShift"
      );
  }

  getAccessToken() {
    return this.api
      .post(this.apiTokenPath, "grant_type=client_credentials", {
        headers: { "Content-Type": "application/x-www-form-urlencoded" },
        auth: {
          username: this.clientId,
          password: this.clientSecret,
        },
      })
      .then(function (response) {
        if (!response.data.access_token)
          throw new Error(
            "Unable to retrieve Keycloak service account access token"
          );

        return Promise.resolve(response.data.access_token);
      });
  }

  async getUris() {
    const response = await this.api.get(this.appClientPath);

    const data = { ...response.data };
    const redirectUris = data.redirectUris;

    return { data, redirectUris };
  }

  async addUris() {
    await this.init();

    console.log("Attempting to add RedirectUri and WebOrigins");

    const { data, redirectUris } = await this.getUris();
    const putData = { id: data.id, clientId: data.clientId };

    const hasRedirectUris = redirectUris.find((item) =>
      item.includes(this.appHost)
    );

    if (!hasRedirectUris) {
      redirectUris.push(`https://${this.appHost}/*`);
      putData.redirectUris = redirectUris;
    }

    if (!hasRedirectUris) {
      this.api
        .put(this.appClientPath, putData)
        .then(() => console.log("RedirectUri and WebOrigins added."));
    } else {
      console.log("RedirectUri and WebOrigins add skipped.");
    }
  }

  async remmoveUris() {
    await this.init();

    console.log("Attempting to remove RedirectUri and WebOrigins");

    const { data, redirectUris } = await this.getUris();
    const putData = { id: data.id, clientId: data.clientId };

    const hasRedirectUris = redirectUris.find((item) =>
      item.includes(this.appHost)
    );

    if (hasRedirectUris) {
      putData.redirectUris = redirectUris.filter(
        (item) => !item.includes(this.appHost)
      );
    }

    if (hasRedirectUris) {
      this.api
        .put(this.appClientPath, putData)
        .then(() => console.log("RedirectUri and WebOrigins removed."));
    } else {
      console.log("RedirectUri and WebOrigins remove skipped.");
    }
  }
};
