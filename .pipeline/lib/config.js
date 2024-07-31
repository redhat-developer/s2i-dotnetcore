"use strict";
const options = require("@bcgov/pipeline-cli").Util.parseArguments();

const changeId = options.pr; //aka pull-request
const version = "2.0.6";
const name = "sbi"; //project name prefix

Object.assign(options.git, { owner: "ychung-mot", repository: "schoolbus" });
const phases = {
  build: {
    namespace: "e82e9a-tools",
    name: `${name}`,
    phase: "build",
    changeId: changeId,
    suffix: `-build-${changeId}`,
    instance: `${name}-build-${changeId}`,
    version: `${version}-${changeId}`,
    tag: `build-${version}-${changeId}`,
    transient: true,
  },
  dev: {
    namespace: "e82e9a-dev",
    name: `${name}`,
    phase: "dev",
    changeId: changeId,
    suffix: `-dev-${changeId}`,
    instance: `${name}-dev-${changeId}`,
    version: `${version}-${changeId}`,
    tag: `dev-${version}-${changeId}`,
    host: `sbi-e82e9a-dev.apps.silver.devops.gov.bc.ca`,
    dotnet_env: "Development",
    dbUser: "userUXN",
    dbSize: "6Gi",
    transient: true,
    backupVolume: "schoolbus",
    backupVolumeSize: "10Gi",
    verificationVolumeSize: "10Gi",
  },
  test: {
    namespace: "e82e9a-test",
    name: `${name}`,
    phase: "test",
    changeId: changeId,
    suffix: `-test`,
    instance: `${name}-test`,
    version: `${version}`,
    tag: `test-${version}`,
    host: `sbi-e82e9a-test.apps.silver.devops.gov.bc.ca`,
    dbUser: "user7KU",
    dbSize: "6Gi",
    dotnet_env: "Staging",
    backupVolume: "schoolbus",
    backupVolumeSize: "5Gi",
    verificationVolumeSize: "5Gi",
  },
  prod: {
    namespace: "e82e9a-prod",
    name: `${name}`,
    phase: "prod",
    changeId: changeId,
    suffix: `-prod`,
    instance: `${name}-prod`,
    version: `${version}`,
    tag: `prod-${version}`,
    host: `sbi-e82e9a-prod.apps.silver.devops.gov.bc.ca`,
    dbUser: "userKIX",
    dbSize: "6Gi",
    dotnet_env: "Production",
    backupVolume: "schoolbus",
    backupVolumeSize: "5Gi",
    verificationVolumeSize: "5Gi",
  },
};

// This callback forces the node process to exit as failure.
process.on("unhandledRejection", (reason) => {
  console.log(reason);
  process.exit(1);
});

module.exports = exports = { phases, options };
