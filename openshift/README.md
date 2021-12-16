# OpenShift Deployment and Pipeline

SBI (School Bus Inspection Tracking System) makes use of BCDK and pipline-cli to manage OpenShift deployments. These tools enable a Github Pull Request (PR) based CI/CD pipeline. Github Actions will monitor Github repository for pull requests and start a new build based on that.

This document will not go into the details of how to use Github Actions and pipeline-cli. For documentation on those, you can refer to the following links

- [Github Actions](https://docs.github.com/en/actions)
- [pipeline-cli](https://github.com/BCDevOps/pipeline-cli)

## Prerequisites

- Admin access to OpenShift namespaces, preferably using the standard BC Gov setup of `tools`, `dev`, `test` and `prod` namespaces
- Redhat image pull [service account](docs/RedhatServiceAccount.md)
- _optional, KeyCloak service account for automatically creating client Valid Redirect URIs for PR based deployments_

### Redhat Docker Images

You will need a Redhat image pull service account before you can continue. Refer to [this document](docs/RedhatServiceAccount.md) on how to create a Redhat image pull service account.

SBI uses 3 Redhat Docker images and they will be imported into the `tools` namespace as part of the build pipeline. This requires you to have the correct Redhat service account configured.

1. [dotnet-31-rhel7](https://access.redhat.com/containers/?tab=images#/registry.access.redhat.com/dotnet/dotnet-31-rhel7)
2. [rhel8/nginx-116](https://access.redhat.com/containers/#/registry.access.redhat.com/rhel8/nginx-116)
3. [postgresql-10](https://catalog.redhat.com/software/containers/rhel8/postgresql-10/5ba0ae0ddd19c70b45cbf4cd)

### Openshift Service Account Access Token

The Openshift Service Account Access Token is used to give Github Actions access to login Openshift and build and deploy CRT application. In order to create the service account, roles and rolebindings, cd into openshift folder and login Openshift and run the following commands.

```
oc project e82e9a-tools

oc process -f moti-cicd-service-account.yaml -p NAME=moti-cicd -p PROJECT=e82e9a | oc apply -f -

oc process -f moti-cicd-role-binding.yaml -p NAME=moti-cicd -p NAMESPACE=e82e9a-tools -p PROJECT=e82e9a | oc apply -f -

oc process -f moti-cicd-role-binding.yaml -p NAME=moti-cicd -p NAMESPACE=e82e9a-dev -p PROJECT=e82e9a | oc apply -f -

oc process -f moti-cicd-role-binding.yaml -p NAME=moti-cicd -p NAMESPACE=e82e9a-test -p PROJECT=e82e9a | oc apply -f -

oc process -f moti-cicd-role-binding.yaml -p NAME=moti-cicd -p NAMESPACE=e82e9a-prod -p PROJECT=e82e9a | oc apply -f -
```

## Pipeline Setup

This section will describe the necessary steps required to configure the pipeline to run in your OpenShift environment.

### Update API ConfigMap

The API Server and Hangfire Server make use of the [api-appsettings.yaml](configmaps/api-appsettings.yaml) file for runtime configurations in OpenShift.

The configmap replaces the default `appSettings.json` file from the `Server/SchoolBusAPI` project via the `s2i run` script when a pod is starting up. So it is imporant it has the correct configurations.

### Create Secret Objects

There are a few secret objects that must be created manually in the `dev`, `test`, and `prod` namespaces. These are required for the pods to function properly.

You can use the following templates to create the secret objects. Make sure to replace the parameter variables with actual values encoded to base64.

- [sso-secrets.yaml](secrets/sso-secrets.yaml)
- [ccw-secrets.yaml](secrets/ccw-secrets.yaml)
- [db-postgresql-secrets.yaml](secrets/db-postgresql-secrets.yaml)
- [ftp-secrets.yaml](secrets/ftp-secrets.yaml)

#### Optional Step

If you want to let the pipeline automatically update the Valid Redirect URIs (after a successful login to Keycloak) for PR based routes then you will need to create the following secret object in the `tools` namespace

```yaml
apiVersion: v1
data:
  appClientId: <application-client-internal-id>
  clientId: <service-client-id>
  clientSecret: <service-client-secret>
  host: <dev.oidc.gov.bc.ca>
  realmId: <realm-id>
kind: Secret
metadata:
  name: keycloak-service-client
type: Opaque
```

### Configure Pipeline-cli

The `.pipeline` directory contains the scripts for running pipeline-cli against your OpenShift namespaces. The scripts in the `.pipeline` directories in this repository are configured to run against the official CRT OpenShift namespaces (`e82e9a-`).

You will need to configure the scripts in the `.pipeline` directory to work with your OpenShift namespaces.

The scripts need to be updated are

- [.pipeline/lib/config.js](/.pipeline/lib/config.js)

The values to modify are the `namespace` and `host` values. Update them to match your OpenShift namespaces.

## Pull Request Build and Deploy

Once Github Actions Workflow is properly configured, it is ready to monitor pull requests.

Every pull request made to your repository will trigger a new build and create a standalone deployment in the `dev` namespace. This allows you to test new features independantly of other features.

If [configured properly](https://github.com/BCDevOps/bcdk#automatically-clean-up-pull-request-deployments), you can clean up the environments when a pull request is merged or closed using

```
npm run clean -- --pr=<pr#> ---env=<env>

# Alternative you can use --env=all if you have the transient option configured properly
npm run clean -- --pr=<pr#> --env=all
```

## Manually Build and Deploy

Use the following steps to manually build and deploy. This assumes you have already logged in.

```
# Change directory to .pipeline
cd .pipeline

# Installed the required NPM packages
npm install

# Create build for a particular PR on Github
npm run build -- --pr=<pr#>

# Deploy to dev, test, or prod
npm run deploy -- --pr=<pr#> --env=<env>
```

You can also build from your local source code using the `--dev-mode=true` flag. This will upload your local source repository instead of cloning the repository from Github. You may need to delete the `client/node_modules` directory before using `dev-mode`. The `node_modules` directory contains too many files and will often cause the build to fail.

`dev-mode` is useful for testing the pipeline without pushing any changes to the remote repository.

```
npm run build --pr=0 --dev-mode=true
```

You can clean up builds and deployments using

```
npm run clean -- --pr=<pr#> ---env=<env>

# Alternative you can use --env=all if you have the transient option configured properly
npm run clean -- --pr=<pr#> --env=all
```
