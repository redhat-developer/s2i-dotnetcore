"use strict";
const { OpenShiftClientX } = require("@bcgov/pipeline-cli");
const path = require("path");

module.exports = (settings) => {
  const phases = settings.phases;
  const options = settings.options;
  const phase = options.env;
  const changeId = phases[phase].changeId;
  const oc = new OpenShiftClientX(
    Object.assign({ namespace: phases[phase].namespace }, options)
  );

  const templatesLocalBaseUrl = oc.toFileUrl(
    path.resolve(__dirname, "../../openshift")
  );
  var objects = [];

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/api-deploy-config.yaml`,
      {
        param: {
          NAME: `${phases[phase].name}-api`,
          SUFFIX: phases[phase].suffix,
          VERSION: phases[phase].tag,
          ENV: phases[phase].phase,
          ASPNETCORE_ENVIRONMENT: phases[phase].dotnet_env,
        },
      }
    )
  );

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/pdf-deploy-config.yaml`,
      {
        param: {
          NAME: `${phases[phase].name}-pdf`,
          SUFFIX: phases[phase].suffix,
          VERSION: phases[phase].tag,
          ENV: phases[phase].phase,
        },
      }
    )
  );
  oc.applyRecommendedLabels(
    objects,
    phases[phase].name,
    phase,
    `${changeId}`,
    phases[phase].instance
  );
  oc.importImageStreams(
    objects,
    phases[phase].tag,
    phases.build.namespace,
    phases.build.tag
  );
  oc.applyAndDeploy(objects, phases[phase].instance);
};
