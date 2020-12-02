"use strict";
const { OpenShiftClientX } = require("@bcgov/pipeline-cli");
const path = require("path");

module.exports = (settings) => {
  const phases = settings.phases;
  const options = settings.options;
  const oc = new OpenShiftClientX(
    Object.assign({ namespace: phases.build.namespace }, options)
  );
  const phase = "build";
  let objects = [];
  const templatesLocalBaseUrl = oc.toFileUrl(
    path.resolve(__dirname, "../../openshift")
  );

  // objects.push(
  //   ...oc.processDeploymentTemplate(
  //     `${templatesLocalBaseUrl}/backup-build-config.yaml`,
  //     {
  //       param: {
  //         NAME: `${settings.phases[phase].name}-backup`,
  //         SUFFIX: settings.phases[phase].suffix,
  //         VERSION: settings.phases[phase].tag,
  //       },
  //     }
  //   )
  // );

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/api-build-config.yaml`,
      {
        param: {
          PROJECT_NAME: `${phases[phase].name}`,
          NAME: `${settings.phases[phase].name}-api`,
          SUFFIX: settings.phases[phase].suffix,
          VERSION: settings.phases[phase].tag,
          SOURCE_REPOSITORY_URL: `${oc.git.uri}`,
          SOURCE_REPOSITORY_REF: `${oc.git.branch_ref}`,
        },
      }
    )
  );

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/pdf-build-config.yaml`,
      {
        param: {
          PROJECT_NAME: `${phases[phase].name}`,
          NAME: `${settings.phases[phase].name}-pdf`,
          SUFFIX: settings.phases[phase].suffix,
          VERSION: settings.phases[phase].tag,
          SOURCE_REPOSITORY_URL: `${oc.git.uri}`,
          SOURCE_REPOSITORY_REF: `${oc.git.branch_ref}`,
        },
      }
    )
  );

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/client-build-config.yaml`,
      {
        param: {
          NAME: `${settings.phases[phase].name}-client`,
          SUFFIX: settings.phases[phase].suffix,
          VERSION: settings.phases[phase].tag,
          SOURCE_REPOSITORY_URL: `${oc.git.uri}`,
          SOURCE_REPOSITORY_REF: `${oc.git.branch_ref}`,
        },
      }
    )
  );

  oc.applyRecommendedLabels(
    objects,
    phases[phase].name,
    phase,
    phases[phase].changeId,
    phases[phase].instance
  );
  oc.applyAndBuild(objects);
};
