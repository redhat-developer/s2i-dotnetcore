FROM microsoft/dotnet:1.1.0-sdk-projectjson
# Dockerfile for package SchoolBusClient

# install Node.js

RUN curl https://deb.nodesource.com/node_6.x/pool/main/n/nodejs/nodejs_6.7.0-1nodesource1~jessie1_amd64.deb > node.deb \
 && dpkg -i node.deb \
 && rm node.deb

RUN npm install -g pangyp\
 && ln -s $(which pangyp) $(dirname $(which pangyp))/node-gyp\
 && npm cache clear\
 && node-gyp configure || echo ""

RUN apt-get update \
 && apt-get upgrade -y --force-yes \
 && rm -rf /var/lib/apt/lists/*;

# copy Node.js packages

COPY ./src/package.json /app/src 
WORKDIR /app/src


ENV NODE_ENV production

RUN "npm install"

# copy the full source
COPY ./src /app/src 

# compile the source

RUN "./node_modules/.bin/gulp --production"  

# End of Node.js portion.

# .NET Core MVC app settings
 
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

COPY . /app


RUN dotnet restore

ENV ASPNETCORE_ENVIRONMENT Staging
ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080

RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/app.dll"]
