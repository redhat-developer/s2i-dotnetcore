FROM docker-registry.default.svc:5000/tran-schoolbus-tools/dotnet-31-rhel7:3.1

# Dockerfile for package SchoolBusAPI

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# This setting is a workaround for issues with dotnet and certain docker versions
ENV LTTNG_UST_REGISTER_TIMEOUT 0

COPY Common /app/Common

WORKDIR /app/Common/src/SchoolBusCommon
RUN dotnet restore

COPY Server /app/Server
WORKDIR /app/Server/src/SchoolBusAPI/
RUN dotnet restore SchoolBusAPI.csproj

ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080

RUN dotnet publish SchoolBusAPI.csproj -c Release -o /app/out
WORKDIR /app/out
ENTRYPOINT ["dotnet", "/app/out/SchoolBusAPI.dll"]
