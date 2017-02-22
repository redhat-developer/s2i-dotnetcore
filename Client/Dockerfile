FROM microsoft/dotnet:1.1.0-sdk-projectjson
# Dockerfile for package SchoolBusClient

# install rlwrap

RUN apt-get update \
 && apt-get upgrade -y --force-yes \
 && apt-get install rlwrap bzip2 \
 && rm -rf /var/lib/apt/lists/*;

# install Node.js

RUN curl https://deb.nodesource.com/node_6.x/pool/main/n/nodejs/nodejs_6.7.0-1nodesource1~jessie1_amd64.deb > node.deb \
 && dpkg -i node.deb \
 && rm node.deb

RUN apt-get update \
 && apt-get upgrade -y --force-yes \
 && rm -rf /var/lib/apt/lists/*;

# copy Node.js packages

COPY /package.json /app/out/src/
WORKDIR /app/out/src

ENV NODE_ENV production

RUN npm install

# compile will happen at the next build stage (frontend)
# otherwise there is no git commit in the environment.



