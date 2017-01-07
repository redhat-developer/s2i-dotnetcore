REM Work in progress, not totally safe to run from beginning to end yet.

REM TODO:
REM - Add support for creating the initial tools environment.
set defaultRepoName=bcgov

REM Create the projects
oc new-project tran-schoolbus-tools --display-name="Schoolbus (tools)" --description="Ministry of Transportation Schoolbus Inspection System (tools)"
oc new-project tran-schoolbus-dev --display-name="Schoolbus (dev)" --description="Ministry of Transportation Schoolbus Inspection System (dev)"
oc new-project tran-schoolbus-test --display-name="Schoolbus (test)" --description="Ministry of Transportation Schoolbus Inspection System (test)"
oc new-project tran-schoolbus-prod --display-name="Schoolbus (prod)" --description="Ministry of Transportation Schoolbus Inspection System (prod)"

REM Import required image(s) into the tools project
oc project tran-schoolbus-tools
oc import-image dotnet --from=docker.io/microsoft/dotnet:1.1.0-sdk-projectjson --confirm

REM Grant the deployment environment projects access to the images in the tools project
oc policy add-role-to-user system:image-puller system:serviceaccount:tran-schoolbus-dev:default -n tran-schoolbus-tools
oc policy add-role-to-user system:image-puller system:serviceaccount:tran-schoolbus-test:default -n tran-schoolbus-tools
oc policy add-role-to-user system:image-puller system:serviceaccount:tran-schoolbus-prod:default -n tran-schoolbus-tools

REM DEV - Configure Deployments
REM Options
REM - schoolbus-deployment-template-emptydir.json
REM - schoolbus-deployment-template.json
oc project tran-schoolbus-dev
oc process -f https://raw.githubusercontent.com/bcgov/schoolbus/master/openshift/templates/schoolbus-deployment-template-emptydir.json > schoolbus-deployment-dev-emptydir.json
oc create -f schoolbus-deployment-dev-emptydir.json 

REM TEST - Configure Deployments


REM PROD - Configure Deployments