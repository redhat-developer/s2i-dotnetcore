# OpenShift Deployment and Pipeline

SBI makes use of BCDK and pipline-cli to manage OpenShift deployments. These tools enable a Github Pull Request (PR) based CI/CD pipeline. Once the Jenkins instance is configured and deployed, it will monitor Github repository for pull requests and start a new build based on that.

This document will not go into the details of how to use BCDK and pipeline-cli. For documentation on those, you can refer to the following links

- [BCDK](https://github.com/BCDevOps/bcdk)
- [pipeline-cli](https://github.com/BCDevOps/pipeline-cli)

## Prerequisites

- Admin access to OpenShift namespaces, preferably using the standard BC Gov setup of `tools`, `dev`, `test` and `prod` namespaces
- Github personal access token for an account that has contributor access to your repository. It needs to include `repo:status`, `repo_deployment`, `public_repo` and `admin:repo_hook` permissions
- Redhat image pull [service account](docs/RedhatServiceAccount.md)
- _optional, KeyCloak service account for automatically creating client Valid Redirect URIs for PR based deployments_

### Redhat Docker Images

You will need a Redhat image pull service account before you can continue. Refer to [this document](docs/RedhatServiceAccount.md) on how to create a Redhat image pull service account.

SBI uses two Redhat Docker images and they will be imported into the `tools` namespace as part of the build pipeline. This requires you to have the correct Redhat service account configured.

1. [dotnet-31-rhel7](https://access.redhat.com/containers/?tab=images#/registry.access.redhat.com/dotnet/dotnet-31-rhel7)
2. [rhel8/nginx-116](https://access.redhat.com/containers/#/registry.access.redhat.com/rhel8/nginx-116)

### Github Personal Access Token

The Github Personal Access Token is used to give Jenkins access to monitor your repository for changes and create the necessary webhooks. It is recommended to use a shared team Github account for this.

The access token must have `repo:status`, `repo_deployment`, `public_repo` and `admin:repo_hook` permissions for the pipeline to work properly.

Please refer to [Github's guide](https://help.github.com/en/articles/creating-a-personal-access-token-for-the-command-line) for more details.

## Pipeline Setup

This section will describe the necessary steps required to configure the pipeline to run in your OpenShift environment.

### Update API ConfigMap

The API Server and Hangfire Server make use of the [api-appsettings.yaml](configmaps/api-appsettings.yaml) file for runtime configurations in OpenShift.

The configmap replaces the default `appSettings.json` file from the `Server/SchoolBusAPI` project via the `s2i run` script when a pod is starting up. So it is imporant it has the correct configurations.

### Create Secret Objects

There are a few secret objects that must be created manually in the `dev`, `test`, and `prod` namespaces. These are required for the pods to function properly.

You can use the following templates to create the secret objects. Make sure to replace the parameter variables with actual values encoded to base64.

- [sso-secrets.yaml](secrets/sso-secrets.yaml)
- [service-account-secrets.yaml](secrets/service-account-secrets.yaml)
- [database-secrets.yaml](secrets/database-secrets.yaml)
- [bceid-secrets.yaml](secrets/bceid-secrets.yaml)
- [email-secrets.yaml](secrets/email-secrets.yaml)

#### Optional Step

If you want to let the pipeline automatically update the Valid Redirect URIs for PR based routes then you will need to create the following secret object in the `tools` namespace

```yaml
apiVersion: v1
data:
  clientId: <service-client-id>
  clientSecret: <service-client-secret>
  SBIPublic: <application-client-internal-id>
  host: <sso-dev.pathfinder.gov.bc.ca>
  realmId: <realm-id>
kind: Secret
metadata:
  name: keycloak-service-client
type: Opaque
```

### Configure Pipeline-cli

The `.jenkins` and `.pipeline` directories contain the scripts genereated by the BCDK tool in order to use pipeline-cli against your OpenShift namespaces. The scripts in the `.jenkins` and `.pipeline` directories in this repository are configured to run against the official SBI OpenShift namespaces (`tran-schoolbus-`).

You will need to configure the scripts in the `.jenkins` and `.pipeline` directories to work with your OpenShift namespaces. There are two ways to do this:

1. Update the namespace values in both `lib/config.js` file and create the Jenkins secret objects maually.
2. Re-run the BCDK tool to setup your namespaces and pipeline-cli automatically. However you will need to merge the generated scripts with the scripts in this repository.

#### Update Manually

This is easier method to adapt the pipeline scripts to your namespaces. The scripts need to be updated are

- [.jenkins/.pipeline/lib/config.js](/.jenkins/.pipeline/lib/config.js)
- [.pipeline/lib/config.js](/.pipeline/lib/config.js)

The values to modify are the `namespace` and `host` values. Update them to match your OpenShift namespaces.

The last step is to create the Jenkins secret objects in the `tools` namespace. Use your Github username and personal access token.

```yaml
apiVersion: template.openshift.io/v1
kind: Template
objects:
  - apiVersion: v1
    kind: Secret
    metadata:
      annotations: null
      name: template.${NAME}-slave-user
    stringData:
      metadata.name: template.${NAME}-slave-user
      username: jenkins-slave
  - apiVersion: v1
    kind: Secret
    metadata:
      annotations: null
      name: template.${NAME}-github
    stringData:
      metadata.name: template.${NAME}-github
      username: ${GH_USERNAME}
      password: ${GH_ACCESS_TOKEN}
parameters:
  - description: A name used for all objects
    displayName: Name
    name: NAME
    required: true
    value: jenkins
  - name: GH_USERNAME
    required: true
  - description: GitHub Personal Access Token
    name: GH_ACCESS_TOKEN
    required: true
```

#### Update using BCDK

Refer to the official [BCDK documentation](https://github.com/BCDevOps/bcdk) on how to use this method. After you have ran the BCDK generators, you will need to merge the generated scripts and the existing scripts in this repository.

## Deploy Jenkins

The Jenkins instance is used to run the pipeline automatically when pull requests are detected. For that to happen you will need to build and deploy Jenkins to the `tools` namespace

**IMPORTANT!** Make sure the `jenkins-prod` service account from `tools` namespace have admin access to the `dev`, `test`, and `prod` namespaces. This allows Jenkins to deploy to the namespaces and perform cleanups.

Use the following steps to deploy Jenkins. This assumes you have already logged in

```
# Switch to tools namespace
oc project <namespace>-tools

# Change working directory to .jenkins/.pipeline
cd .jenkins/.pipeline

# Install required NPM modules
npm install

# Build Jenkins from local code package
# --dev-mode=true enables uploading local source code as an archive
# dev-mode is useful for building changes without pushing to remote first
# --pr=0 indicates pull request 0, generally used for dev-mode builds
npm run build -- --pr=0 --dev-mode=true

# Wait for builds to finish and deploy
npm run deploy -- --pr=0 --env=prod

# Optionally you can deploy as dev first
# npm run deploy -- --pr=0 --env=dev
```

Once the prod Jenkins instance is running, you should see new webhooks created in your repository settings. Jenkins is now ready to monitor pull requests.

## Pull Request Build and Deploy

Once Jenkins is properly configured and deployed, it is ready to monitor pull requests.

Every pull request made to your repository will trigger a new build and create a standalone deployment in the `dev` namespace. This allows you to test new features independantly of other features.

If [configured properly](https://github.com/BCDevOps/bcdk#automatically-clean-up-pull-request-deployments), Jenkins will also automatically clean up the environments when a pull request is merged or closed.

**Note!** Pull requests to a branch other than `master` will cause the pipeline to end after deploying the `dev` namespace. Pull requests to `master` will cause Jenkins to execute all the stages in the [Jenkinsfile](/Jenkinsfile) unless manually terminated.

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
