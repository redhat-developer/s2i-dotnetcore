.NET Core Docker Image
======================

This repository contains the source for building .NET Core apps as reproducible
Docker images using
[source-to-image](https://github.com/openshift/source-to-image).  The resulting
image can be run using [Docker](http://docker.io).

Versions
----------------
.NET Core versions currently provided are:
* 1.0
* 1.1

RHEL versions currently supported are:
* RHEL 7

Installation
----------------

To build a RHEL 7 based .NET Core image, you need to run the build on a
properly subscribed RHEL machine.

```
$ git clone https://github.com/redhat-developer/s2i-dotnetcore.git
$ cd s2i-dotnetcore/1.0
$ sudo docker build -f Dockerfile.rhel7 -t dotnet/dotnetcore-10-rhel7 .
```

Or in order to build and test all images run:

```
sudo bash build.sh
```

Usage
---------------------------------

For information about usage of Docker image for .NET Core 1.1,
see [1.1 usage documentation](1.1/README.md).

For information about usage of Docker image for .NET Core 1.0,
see [1.0 usage documentation](1.0/README.md).

Image name structure
------------------------
##### Structure: dotnet/1-2-3

1. Platform name (lowercase) - dotnetcore
2. Platform version (without dots) - 10
3. Base builder image - rhel7

Example: `dotnet/dotnetcore-10-rhel7`

OpenShift Templates
-------------------

The `templates` folder contains OpenShift templates. Some of these will be shipped with OpenShift.
If a template is not on your OpenShift installation, you can import it:

```
oc create -f <template.json>
```

To instantiate a template you can use the `oc new-app` command:

```
oc new-app --template=<template>
```

The template can also be instantiated using the OpenShift web console. Login to the console and
navigate to the desired project. Click the **Add to Project** button. Search and select the desired template by it's name (e.g. dotnet-example).
Next, click **Create** to start a build and deploy the sample application. Once the build has and deployment
have completed, you can browse to the application using the url you find in project overview.

**dotnet-example**

The dotnet-example template can be used to create a new .NET Core service in OpenShift. It provides parameters for all the environment
variables of the s2i-dotnetcore builder. It also includes a liveness and a readiness probe.

**dotnet-pgsql-persistent**

The dotnet-pgsql-persistent creates a .NET Core service with a PostgreSQL backend. It provides parameters for all the environment
variables of the s2i-dotnetcore builder and variables to setup the database. The database connection information is passed to the
.NET application via the `ConnectionString` environment variable.
