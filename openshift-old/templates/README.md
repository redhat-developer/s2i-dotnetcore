Schoolbus Inspection Tracking System
======================

OpenShift Configuration and Deployment
----------------

The tran-schoolbus-tools (Tools) project contains the Build Configurations (bc) and Image Streams (is) that are referenced by the Deployment Configurations.

The following projects contain the Deployment Configurations (dc) for the various types of deployments:
- tran-schoolbus-dev (Development)
- tran-schoolbus-test (Test)
- tran-schoolbus-prod (Production)

In Schoolbus the following components are deployed
- Postgres Database, built based on the Red Hat Postgres image
- .NET Core Front End Server, which also contains the compiled UI files
- .NET Core API Server (backend)
- .NET Core PDF microservice
- .NET Core CCW microservice

Steps to configure the deployment:
----------------------------------

### Procure Environment - local or shared OpenShift

Ensure that you have access to the build and deployment templates in the openshift/templates folder in the School Bus repo.

If you are setting up a local OpenShift cluster for development, fork the main project.  You'll be using your own fork. Clone a local instance of the fork you are using.

For a local instance, get the latest version of the [OpenShift Command line tools](https://github.com/openshift/origin/releases) and start up a local instance using "oc cluster up" or using [minishift](https://github.com/minishift/minishift).

### Connect to OpenShift - Web and CLI

Connect to the OpenShift server using the CLI; either your local instance or the production instance.

If you have not connected to the production instance before, use the web interface as you will need to login though your GitHub account.  Once you login you'll be able to get the token you'll need to login to you project(s) through the CLI from here; Token Request Page.  The CLI will also give you a URL to go to if you attempt a login to the OpenShift server without a token.

The same basic procedure, minus the GitHub part, can be used to connect to your local instance.

Login to the server using the oc command from the page.

### Create the School Bus Projects

If necessary, create each of the projects listed above (e.g. tran-schoolbus-tools, tran-schoolbus-dev, etc.):

```oc new-project tran-schoolbus-tools```

### Create the Build Configs and Imagestreams

Switch to the Tools project by running:
`oc project tran-schoolbus-tools`

Use the build template in the repo openshift/templates folder. The path to the file depends where you are. Please do not commit the processed file (schoolbus-build.json in this case):

`oc process -f schoolbus/openshift/templates/schoolbus-build-template.json > schoolbus-build.json`

Create the build config and imagestream resources from the resulting file by running
`oc create -f schoolbus-build.json`

You can now login to the web interface and observe the progress of the initial build.

- Log in
- Go to the tran-schoolbus-tools project
- Go to Builds -> Builds menu and monitor the jobs

NOTE: Effective this update, all of the builds complete successfully **except** the "editor" build, which is failing on a Dockerfile step.

### Tag the Images for Dev, etc.

Once the initial build is done, create builds with tags "dev", "test", and "prod" as required for deployment (just "dev" is enough for local use). This is normally done by Jenkins (added later), but if you have not installed Jenkins yet, you can do this from the command line for each imagestream with the commands:

```oc get is # get a list of imagestreams - shows current tags, likely just "latest"```

```oc tag backup:latest backup:dev # sets "dev" tag to match "latest" on "backup" - repeat per imagestream```

Example command:

```oc tag backup:latest backup:dev;oc tag client:latest client:dev;oc tag frontend:latest frontend:dev;oc tag mock:latest mock:dev;oc tag pdf:latest pdf:dev;oc tag s2i-nginx:latest s2i-nginx:dev;oc tag  schema-spy:latest schema-spy:dev;oc tag server:latest server:dev;oc tag cerberus:latest cerberus:dev```

Rerunning ```oc get is``` should return something like this:

```
NAME           DOCKER REPO                                       TAGS         UPDATED
backup         172.30.1.1:5000/tran-schoolbus-tools/backup       dev,latest   About a minute ago
base-centos7   openshift/base-centos7                            latest       10 minutes ago
cerberus       172.30.1.1:5000/tran-schoolbus-tools/cerberus     dev,latest   2 seconds ago
client         172.30.1.1:5000/tran-schoolbus-tools/client       dev,latest   About a minute ago
dotnet         microsoft/dotnet                                  latest       10 minutes ago
editor         172.30.1.1:5000/tran-schoolbus-tools/editor
frontend       172.30.1.1:5000/tran-schoolbus-tools/frontend     dev,latest   About a minute ago
mock           172.30.1.1:5000/tran-schoolbus-tools/mock         dev,latest   About a minute ago
pdf            172.30.1.1:5000/tran-schoolbus-tools/pdf          dev,latest   About a minute ago
s2i-nginx      172.30.1.1:5000/tran-schoolbus-tools/s2i-nginx    dev,latest   About a minute ago
schema-spy     172.30.1.1:5000/tran-schoolbus-tools/schema-spy   dev,latest   About a minute ago
server         172.30.1.1:5000/tran-schoolbus-tools/server       dev,latest   25 seconds ago
```

The deployment configurations will use these tags to determine which image to load.

Once you have images tagged for dev, test and/or prod you are ready to deploy.

### Add Permission for Access to "Tools" Images

By default projects do not have permission to access images from other projects.  You will need to grant that.
Run the following:
`oc policy add-role-to-user system:image-puller system:serviceaccount:tran-schoolbus-dev:default -n tran-schoolbus-tools`

Repeat for test and prod projects as required.

### Add Secrets for the projects

*NOTE: The correctly formatted data for this data is in the repo [swcurran/schoolbus](https://github.com/swcurran/schoolbus). It will be pushed to the BCGov School Bus repo, but that has not yet happened.*

The server has several OpenShift secrets for seeding data necessary to create user accounts - we don't want them in the repo with real user IDs. To create the secrets in each environment project:

- **Log into the environment project** - e.g. ```oc project tran-schoolbus-dev```
- On the command line, goto a tmp directory (e.g. ~/tmp)
- Create a folder in the tmp directory "secrets"
- Copy files from the repo APISpec/Testdata folder into the tmp directory:
  - Copy ApiSpec/TestData/example_ccw.json to ccw.json
  - Copy ApiSpec/TestData/example_users.json to secrets/users.json
    - You can update this file to add/update the users initially loaded for testing.
  - Copy ApiSpec/TestData/Regions/Regions_Region.json to secrets/regions.json
  - Copy ApiSpec/TestData/Districts/Districts_District.json to secrets/districts.json

Once the files are in place, run the commands to add the secrets to the project:

- ```oc secrets new ccw-secret ccw.json```
- ```oc secrets new schoolbus-secret secrets```

"ccw.json" and "secrets" are the file and folder (respectively) on your system. Adjust the path and filenames as needed.

**NOTE**: Should you ever want to change the contents of the secrets data, run the OpenShift command to delete the secret (Web or from CLI: ```oc delete secrets schoolbus-secret```) and then rerun the new secret command above.

### Parse and Process the Deployment template:

Next step is to create the OpenShift resources for the environment you are creating (e.g. "dev", etc.).

Log into the correct project - e.g. for dev run:

```oc project tran-schoolbus-dev```

Parse the deployment template - substitute the correct path to the repo openshift/templates folder as you did with the build process:

`oc process -f schoolbus/openshift/templates/schoolbus-deployment-template.json >schoolbus-deployment.json`
`oc create -f schoolbus-deployment.json # Use same as output file in the previous command`

This should produce a list of deployment configurations, persistent volume claims and services being created.  

Go to the Web Interface, Overview and verify everything looks correct in the web UI for the project you provisioned

#### Ignore the failure of the CCW Deployment

**NOTE** As of the writing of this guidance, the CCW microservice is *NOT* loading. The app will operate without that, and in fact, it is a BC Gov-specific implementation. Without the service, when clicking on the details of a school bus, you will get an "Error" because of the lack of the CCW service, but the app will operate correctly.  See the user guide for information about why that is OK.

#### Fix the failure of the Postgres Deployment

**NOTE** As of the writing of this guidance, the postgres deployment is **not** working based on the steps outlined here. To get it to work:

- From the Web UI **delete** the Postgres Deployment Configuration and Service.
- From the "server" Deployment Config, Environment, get the values of the Environment Variables:
 - POSTGRESQL_USER - will be "user" plus 3 letters
 - POSTGRESQL_PASSWORD - will be a generated string
 - POSTGRESQL_DATABASE - will be "schoolbus"
- Use the "Add to Project" (top of the screen)
 - Select "Browse Catalog"
 - Select "Data Stores"
 - Select "PostgreSQL (Persistent)"
 - Fill in the User Name, Password and set the database name to "schoolbus"

The "server" deployment may have work once Postgre is running, or may have failed because of the postgres issue.  If it failed, once postgres is running, go into the Web interface and re-deploy "server".

### Add Route for the FrontEnd

The current setup does not create a route to the Web Interface for the app.  To do that, go into the Web Interface:

- Go to Overview
- Expand "frontend"
- In the Service section, click on the "Create Route" link
- Accept the defaults

To verify access use the Dev authentication mechanism and log in:

- http://frontend-tran-schoolbus-dev.10.0.75.2.nip.io/api/authentication/dev/token/SCURRAN
- http://frontend-tran-schoolbus-dev.10.0.75.2.nip.io

The application should start up as expected. Note that if you edited the example_users.json to use a different admin user then "SCURRAN", adjust the authentication URL appropriately.

If your local base URL is different from above - adjust the URL as necessary.

### Load Test Data

**NOTE**: The load scripts assume you have curl on your local system.

There is test data in the repo APISpec/TestData folder. With everything done, you should be able load that data.  Go into the folder and in a Windows command line, run "load-all.bat". Note that there is (or will be) a Readme in that folder with more details on the test data management process.

**NOTE**: The first step of the load-all.bat script loads the "SBI_CITY" table in School Bus. The command times out in the local instance, but the load seems to work fine.  If the rest of the commands run without error - (look for the HTTP status: ```HTTP/1.1 204 No Content```), all good.

Again, the user and the base URL may need to be changed if they are different in your setup. Edit the batch file as appropriate to adjust those.

Jenkins Basic Configuration
---------------------------

**NOTE: This sequence has not been tested recently. Your results may vary.**

A job will need to be setup for each Build Configuration.  This job will be used to build and promote each build configuration.

- Configure the job to promote to DEV / TEST / PROD as appropriate
- Set Properties Content to:  `OS_IMAGE_TAG=jenkins-$PROMOTED_JOB_NAME-$PROMOTED_NUMBER`
- Set Execute Shell to (this is an example):  `$oc_cmd tag "tran-schoolbus-tools/client:$OS_IMAGE_TAG" tran-schoolbus-tools/client:dev`
- Add the Openshift Build action
- Enter the name of the BuildConfig to trigger - for example, "client"
- Enter the name of the project the BuildConfig is stored on - for example "tran-schoolbus-tools"
- Enable pipe the build logs from OpenShift
- Add the Tag Openshift Image action
- Set the imagestream name to the appropriate image - for example, "client"
- Set the name of the current tag to "latest"  (ensure that the default tag for the build is also "latest")
- Set the new tag to ${BUILD_TAG}  (Jenkins will substitute appropriately)
- Set the project apropriately, for example "tran-schoolbus-tools"
- The FrontEnd build job should be configured to run after Client.  Otherwise changes to the Client code will not get deployed.
- The Client and Server jobs should be configured to auto build for the Dev instance
Jenkins Automated Builds
- Enable the GitHub plugin to Jenkins, and make note of the URL endpoint.
- The URL endpoint can be found by going to the following:
 - Jenkins Home Page
 - Manage Jenkins
 - Configure Jenkins
 - Click the (?) in the GitHub section
- An example URL endpoint is https://jenkins-tran-schoolbus-tools.pathfinder.gov.bc.ca/github-webhook/
- Request that the git repository administrator configure this as a web hook in the repository.  The following info should be sent in the request:
 - Payload URL: https://jenkins-tran-schoolbus-tools.pathfinder.gov.bc.ca/github-webhook/
 - Content type: application/json
 - Secret: blank, not used
 - SSL certificate is valid.
 - Just the push events
 - Active: Selected/Checked
- Now you can configure jobs to use the webhook.  Edit a job that builds from the repository
- In the Source Code Repositories section, enable Git
- Enter the URL of the repository, for example https://github.com/bcgov/schoolbus.git
- In the Git Additional Behaviors section, add "Polling ignores commits in certain paths" and specify an included region, which matches the area of the repo containing files for the job.
- For example Client/.*
- In the Build Triggers section, check the box for "GitHub hook trigger for GITScm polling"
- Older versions of the GitHub plugin called this "Build when a change is pushed to GitHub"
- Verify that the build automatically runs when a pull request is approved

Environment Variables
--------------------

Once the deployment configs (DC) have been created, look at the various DCs to see the environment variables and their values.

Credit:  [George Walker](https://github.com/GeorgeWalker), [Wade Barnes](https://github.com/WadeBarnes) and [Stephen Curran](https://github.com/swcurran) contributed to this page.
