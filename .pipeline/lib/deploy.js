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

  console.log("Adding Db postgresql secret");

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/secrets/db-postgresql-secrets.yaml`,
      {
        param: {
          PROJECT_NAME: `${phases[phase].name}`,
          NAME: `${phases[phase].name}-db`,
          SUFFIX: phases[phase].suffix,
          POSTGRESQL_USER: phases[phase].dbUser,
          ENV: phases[phase].phase,
        },
      }
    )
  );

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
          PERSISTENT_VOLUME_SIZE: phases[phase].dbSize,
        },
      }
    )
  );

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/backup-deploy-config.yaml`,
      {
        param: {
          PROJECT_NAME: `${phases[phase].name}`,
          NAME: `${phases[phase].name}-backup`,
          SUFFIX: phases[phase].suffix,
          VERSION: phases[phase].tag,
          ENV: phases[phase].phase,
          BACKUP_VOLUME_NAME: phases[phase].backupVolume,
          BACKUP_VOLUME_SIZE: phases[phase].backupVolumeSize,
          VERIFICATION_VOLUME_SIZE: phases[phase].verificationVolumeSize,
        },
      }
    )
  );

  objects.push(
    ...oc.processDeploymentTemplate(
      `${templatesLocalBaseUrl}/configmaps/api-appsettings.yaml`,
      {
        param: {
          ENV: phases[phase].phase,
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
      `${templatesLocalBaseUrl}/client-deploy-config.yaml`,
      {
        param: {
          PROJECT_NAME: `${phases[phase].name}`,
          NAME: `${phases[phase].name}-client`,
          SUFFIX: phases[phase].suffix,
          VERSION: phases[phase].tag,
          ENV: phases[phase].phase,
          HOST: phases[phase].host,
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
