Schoolbus Inspection Tracking System
======================

OpenShift Configuration and Deployment
----------------

The tran-schoolbus-tools (Tools) project contains the Build Configurations (bc) and Image Streams (is) that are referenced by the Deployment Configurations.

The following projects contain the Deployment Configurations (dc) for the various types of deployments:
- tran-schoolbus-dev (Development)
- tran-schoolbus-test (Test)
- tran-schoolbus-prod (Production)
 
In Schoolbus there are 6 components that are deployed 
- nginx reverse proxy
- Postgres Database, built based on the Red Hat Postgres image
- .NET Core Front End Server, which also contains the compiled UI files
- .NET Core API Server
- .NET Core PDF microservice
- .NET Core CCW microservice

Steps to configure the deployment:
----------------------------------

Ensure that you have access to the build and deployment templates.

These can be found in the openshift/templates folder of the project repository.

If you are setting up a local OpenShift cluster for development, fork the main project.  You'll be using your own fork.

Connect to the OpenShift server using the CLI; either your local instance or the production instance. 
If you have not connected to the production instance before, use the web interface as you will need to login though your GitHub account.  Once you login you'll be able to get the token you'll need to login to you project(s) through the CLI from here; Token Request Page.  The CLI will also give you a URL to go to if you attempt a login to the OpenShift server without a token.

The same basic procedure, minus the GitHub part, can be used to connect to your local instance.

Login to the server using the oc command from the page.
Switch to the Tools project by running:
`oc project tran-schoolbus-tools`

`oc process -f https://raw.githubusercontent.com/bcgov/schoolbus/master/openshift/templates/schoolbus-build-template.json > schoolbus-build.json`
 
Create the resources from the resulting file by running
`oc create -f schoolbus-build.json`

This will produce several builds and image streams.

 You can now login to the web interface and observe the progress of the initial build.
Once the initial build is done, create builds with tags "dev", "test", and "prod" as required for deployment.  The deployment configurations will use these tags to determine which image to load.
You can edit a build to change the tag.

Once you have images tagged for dev, test or prod you are ready to deploy.
Open a command prompt and login as above to OpenShift
Change to the project for the type of deployment you are configuring.  For example, to configure a dev build, switch to tran-schoolbus-dev

In the command prompt, type
`oc project tran-schoolbus-dev`
By default projects do not have permission to access images from other projects.  You will need to grant that.
Run the following:
`oc policy add-role-to-user system:image-puller system:serviceaccount:<project_identifier>:default -n <project namespace where project_identifier needs access>`

EXAMPLE - to allow the production project access to the images, run:

`oc policy add-role-to-user system:image-puller system:serviceaccount:tran-schoolbus-prod:default -n tran-schoolbus-tools`

Decide which Deployment Template you will use.

For local test deployments to an environment that does not support persistent volumes, use schoolbus-deployment-template-emptydir.json

For any deployment to an environment that does support persistent volumes (such as production), use `schoolbus-deployment-template.json`
Parse the deployment template:
In the command prompt, type:
`oc process -f <deployment template> <target-file>`
(where target file is an appropriate filename for the deployment implementation .json)
Create the output of the parse:
 In the command prompt, type:
`oc create -f <target-file>`
This should produce several deployment configurations, persistent volume claims and services.  
Verify that the Overview looks correct in the web UI for the project you provisioned
If there are any orphan services (a service without a deployment configuration), edit the YAML for the DC and SVC so that the selectors match the labels.  
If this is not done, then it will not be possible to route traffic to the pod containing the application component for the service

You can now trigger deployments.

-Go to the Deployments page
-Select the component to deploy by clicking the name
-Click Deploy

If any builds or deployments fail, you can use the events view to see detailed errors.

The Postgresql deployment does not automatically run - be sure to deploy it otherwise the Server component will not be able to connect to the database.

Secrets
-------

Secrets must be manually added to the environment, using an account that has the authority to add secrets.
There are several secret files used by the application:

**Users.json**
`[
{
"active": true,
"email": ""email address,
"givenName": "Given Name",
"id": "Id field",
"initials": "Initials",
"smUserID": "Siteminder User ID",
"surname": "Surname",
"groupMemberships": [{"Group" : {"name": "Group Name"}}],
"userRoles": [{"Role": {"Name": "Role Name"}}]
 },
<other users>
]`

**districts.json**

`[
{
"endDate": null,
"id": "1",
"ministryDistrict": "1",
"name": "Lower Mainland",
"region": {
"id": "1",
"ministryRegionID": "1"
},
"startDate": "1/1/2009"
},
<other districts>`
]`

**regions.json**

`[
{
"Name": "South Coast",
"endDate": null,
"id": "1",
"ministryRegionID": "1",
"startDate": "1/1/2009"
},
<other regions>
]`

**CCW.json**

`{
"CCW_userId":"Siteminder User ID for the user that will login to CCW",
"CCW_guid":"Siteminder GUID for the user that will login to CCW",
"CCW_directory":"Siteminder directory for the user that will login to CCW",
"CCW_endpointURL":"Endpoint assigned to the application for CCW access",
"CCW_applicationIdentifier":"Application Identifier assigned to the application",
"CCW_basicAuth_username":"Basic auth username for CCW",
"CCW_basicAuth_password":"Basic auth password for CCW"
}`

In order to provision these secrets, files will need to be created in a secure area of your PC.
Then execute the following commands:
`oc secrets new ccw-secret ccw.json`
Put the remaining secrets inside a folder, which in this example is called secrets
`oc secrets new schoolbus-secret secrets`

Jenkins Basic Configuration
---------------------------

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

The following environment variables are used by the application:

| Environment Variable | Purpose | Example | Notes |
| ---------------------| ------- | ------- | ----- |
| DATABASE_SERVICE_NAME | Database service | postgresql | set to localhost for local development |
| POSTGRESQL_USER | PGSQL User | test | Must have enough access to create tables |
| POSTGRESQL_PASSWORD | PGSQL User's Password | test | |
| POSTGRESQL_DATABASE | Database name | schoolbus | |
| UserInitializationFile | Location of user seed data | /secrets/users.json | Json format following the User model definition |
| DistrictInitializationFile | Location of District seed data | /secrets/districts.json | Json format following the District model definition |
| RegionInitializationFile | Location of Region seed data | /secrets/regions.json | Json format following the Region model definition |
| CCWJurisdictionInitializationFile | Location of CCW Jurisdiction seed data | /secrets/ccwjurisdictions.json | Json format following the CCW Jurisdiction model definition |
| CCW_SERVICE_NAME | CCW microservice location | http://ccw:8080 | |
| PDF_SERVICE_NAME | PDF microservice location | http://pdf:8080 | |
| ASPNETCORE_ENVIRONMENT | Type of deployment | Development | Set to other Production (or anything other than Development) to disable development features such as user visible stack traces. |

Credit:  @GeorgeWalker, @WadeBarnes contributed to this page.