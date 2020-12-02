"use strict";
const { OpenShiftClientX } = require("@bcgov/pipeline-cli");

const getTargetPhases = (env, phases) => {
  let target_phase = [];
  for (const phase in phases) {
    if (env.match(/^(all|transient)$/) && phases[phase].transient) {
      target_phase.push(phase);
    } else if (env === phase) {
      target_phase.push(phase);
      break;
    }
  }

  return target_phase;
};

module.exports = settings => {
  const phases = settings.phases;
  const options = settings.options;
  const oc = new OpenShiftClientX(Object.assign({ namespace: phases.build.namespace }, options));
  const target_phases = getTargetPhases(options.env, phases);

  target_phases.forEach(k => {
    if (phases.hasOwnProperty(k)) {
      const phase = phases[k];

      let buildConfigs = oc.get("bc", {
        selector: `app=${phase.instance},env-id=${phase.changeId},!shared,github-repo=${oc.git.repository},github-owner=${oc.git.owner}`,
        namespace: phase.namespace,
      });
      buildConfigs.forEach(bc => {
        if (bc.spec.output.to.kind == "ImageStreamTag") {
          oc.delete([`ImageStreamTag/${bc.spec.output.to.name}`], {
            "ignore-not-found": "true",
            wait: "true",
            namespace: phase.namespace,
          });
        }
      });

      let deploymentConfigs = oc.get("dc", {
        selector: `app=${phase.instance},env-id=${phase.changeId},env-name=${k},!shared,github-repo=${oc.git.repository},github-owner=${oc.git.owner}`,
        namespace: phase.namespace,
      });
      deploymentConfigs.forEach(dc => {
        dc.spec.triggers.forEach(trigger => {
          if (
            trigger.type == "ImageChange" &&
            trigger.imageChangeParams.from.kind == "ImageStreamTag"
          ) {
            oc.delete([`ImageStreamTag/${trigger.imageChangeParams.from.name}`], {
              "ignore-not-found": "true",
              wait: "true",
              namespace: phase.namespace,
            });
          }
        });
      });

      oc.raw("delete", ["all"], {
        selector: `app=${phase.instance},env-id=${phase.changeId},!shared,github-repo=${oc.git.repository},github-owner=${oc.git.owner}`,
        wait: "true",
        namespace: phase.namespace,
      });
      oc.raw(
        "delete",
        ["pvc,Secret,configmap,endpoints,RoleBinding,role,ServiceAccount,Endpoints"],
        {
          selector: `app=${phase.instance},env-id=${phase.changeId},!shared,github-repo=${oc.git.repository},github-owner=${oc.git.owner}`,
          wait: "true",
          namespace: phase.namespace,
        },
      );
    }
  });
};
