"use strict";

function getSecret(oc, namespace, secretId) {
  let secret = null;

  try {
    const raw = oc.raw("get", [
      "-n",
      namespace,
      "secret",
      secretId,
      "-o",
      "json",
    ]);

    secret = JSON.parse(raw.stdout).data;
  } catch (error) {
    console.log(
      `Error: Unable to retrieve secret ${secretId} from ${namespace}`
    );
  }

  return secret;
}

module.exports = {
  getSecret,
};
