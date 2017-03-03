FROM microsoft/dotnet:1.1.0-sdk-projectjson
# Dockerfile for package PDF

# Install Node.js

RUN apt-get update \
 && apt-get upgrade -y --force-yes \
 && apt-get install rlwrap bzip2 \
 && rm -rf /var/lib/apt/lists/*;
 
RUN apt-get update \
 && apt-get upgrade -y --force-yes \
 && apt-get install -y --force-yes chrpath \
 && rm -rf /var/lib/apt/lists/*;

RUN apt-get update \
 && apt-get upgrade -y --force-yes \
 && apt-get install -y --force-yes libfreetype6 libfontconfig1  \
 && rm -rf /var/lib/apt/lists/*;
 
RUN curl https://deb.nodesource.com/node_6.x/pool/main/n/nodejs/nodejs_6.7.0-1nodesource1~jessie1_amd64.deb > node.deb \
 && dpkg -i node.deb \
 && rm node.deb

RUN apt-get update \
 && apt-get upgrade -y --force-yes \
 && rm -rf /var/lib/apt/lists/*;
 
# Setup the .NET Core application

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# This setting is a workaround for issues with dotnet and certain docker versions
ENV LTTNG_UST_REGISTER_TIMEOUT 0

COPY PDF /app/PDF
WORKDIR /app/PDF/src/PDF.Server/

# setup the Node application.

ENV NODE_ENV production

RUN npm install

# setup the .NET Core application.

RUN dotnet restore

ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080

RUN dotnet publish -c Release -o /app/out
# copy the node.js portion of the application
COPY PDF/src/PDF.Server/pdf.js /app/out
COPY PDF/src/PDF.Server/package.json /app/out
COPY PDF/src/PDF.Server/Templates /app/out/Templates
WORKDIR /app/out
# restore Node packages.
RUN npm install

ENTRYPOINT ["dotnet", "/app/out/PDF.Server.dll"]
