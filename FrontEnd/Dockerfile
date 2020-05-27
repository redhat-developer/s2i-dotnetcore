FROM docker-registry.default.svc:5000/tran-schoolbus-tools/sb-client
# Dockerfile for the application front end

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# This setting is a workaround for issues with dotnet and certain docker versions
ENV LTTNG_UST_REGISTER_TIMEOUT 0

COPY Common /app/Common
WORKDIR /app/Common/src/SchoolBusCommon
RUN dotnet restore
RUN dotnet build -c Release

WORKDIR /

# COPY FrontEnd/global.json /app/FrontEnd/  already migrated FrontEnd to 1.1.11, dont need global.json any more
COPY FrontEnd /app/FrontEnd
# COPY FrontEnd/src/SchoolBusClient/project.json /app/FrontEnd/src/SchoolBusClient/

WORKDIR /app/FrontEnd/src/SchoolBusClient/

RUN dotnet restore SchoolBusClient.csproj

# compile the client
WORKDIR /app/out/src
# copy the full source for the client
COPY Client /app/out/src
RUN /bin/bash -c './node_modules/.bin/gulp --production --commit=$OPENSHIFT_BUILD_COMMIT'

WORKDIR /app/FrontEnd/src/SchoolBusClient/
COPY FrontEnd /app/FrontEnd

ENV ASPNETCORE_ENVIRONMENT Staging
ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080

RUN dotnet publish SchoolBusClient.csproj -c Release -o /app/out
WORKDIR /app/out
ENTRYPOINT ["dotnet", "/app/out/SchoolBusClient.dll"]
