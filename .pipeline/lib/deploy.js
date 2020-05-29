"use strict";
const { OpenShiftClientX } = require("@bcgov/pipeline-cli");
const path = require("path");

const util = require("./utils");

module.exports = (settings) => {
  const phases = settings.phases;
  const options = settings.options;
  const phase = options.env;
  const changeId = phases[phase].changeId;
  const oc = new OpenShiftClientX(
    Object.assign({ namespace: phases[phase].namespace }, options)
  );

  //to keep the user and roles of the previous database
  const dbUsers = { dev: "userUXN", test: "user7KU", prod: "userKIX" };
  const dbSize = { dev: "1Gi", test: "1Gi", prod: "50Gi" };

  const templatesLocalBaseUrl = oc.toFileUrl(
    path.resolve(__dirname, "../../openshift")
  );
  var objects = [];

  const dbSecret = util.getSecret(
    oc,
    phases[phase].namespace,
    `${phases[phase].name}-db${phases[phase].suffix}`
  );

  if (!dbSecret) {
    console.log("Adding Db postgresql secret");

    objects.push(
      ...oc.processDeploymentTemplate(
        `${templatesLocalBaseUrl}/secrets/db-postgresql-secrets.yaml`,
        {
          param: {
            PROJECT_NAME: `${phases[phase].name}`,
            NAME: `${phases[phase].name}-db`,
            SUFFIX: phases[phase].suffix,
            POSTGRESQL_USER: dbUsers[phase],
          },
        }
      )
    );
  }

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/postgresql-deploy-config.yaml`,
      {
        param: {
          PROJECT_NAME: `${phases[phase].name}`,
          NAME: `${phases[phase].name}-db`,
          SUFFIX: phases[phase].suffix,
          VERSION: phases[phase].tag,
          ENV: phases[phase].phase,
          PERSISTENT_VOLUME_SIZE: dbSize[phase],
        },
      }
    )
  );

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/api-deploy-config.yaml`,
      {
        param: {
          PROJECT_NAME: `${phases[phase].name}`,
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
          PROJECT_NAME: `${phases[phase].name}`,
          NAME: `${phases[phase].name}-pdf`,
          SUFFIX: phases[phase].suffix,
          VERSION: phases[phase].tag,
          ENV: phases[phase].phase,
        },
      }
    )
  );

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/frontend-deploy-config.yaml`,
      {
        param: {
          PROJECT_NAME: `${phases[phase].name}`,
          NAME: `${phases[phase].name}-frontend`,
          SUFFIX: phases[phase].suffix,
          VERSION: phases[phase].tag,
          HOST: phases[phase].host,
          ENV: phases[phase].phase,
          ASPNETCORE_ENVIRONMENT: phases[phase].dotnet_env,
        },
      }
    )
  );

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/ccw-deploy-config.yaml`,
      {
        param: {
          PROJECT_NAME: `${phases[phase].name}`,
          NAME: `${phases[phase].name}-ccw`,
          SUFFIX: phases[phase].suffix,
          VERSION: phases[phase].tag,
          ENV: phases[phase].phase,
          ASPNETCORE_ENVIRONMENT: phases[phase].dotnet_env,
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
