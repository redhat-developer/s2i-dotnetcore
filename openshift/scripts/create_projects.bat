oc new-project tran-schoolbus-tools --display-name="Schoolbus (tools)" --description="Ministry of Transportation Schoolbus Inspection System (tools)"
oc new-project tran-schoolbus-dev --display-name="Schoolbus (dev)" --description="Ministry of Transportation Schoolbus Inspection System (dev)"
oc new-project tran-schoolbus-test --display-name="Schoolbus (test)" --description="Ministry of Transportation Schoolbus Inspection System (test)"
oc new-project tran-schoolbus-prod --display-name="Schoolbus (prod)" --description="Ministry of Transportation Schoolbus Inspection System (prod)"

oc project tran-schoolbus-tools
oc import-image dotnet --from=docker.io/microsoft/dotnet:1.1.0-sdk-projectjson --confirm
