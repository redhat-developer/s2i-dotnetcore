.NET Core Docker Image
======================

This repository contains the source for building .NET Core apps as reproducible
Docker images using
[source-to-image](https://github.com/openshift/source-to-image).  The resulting
image can be run using [Docker](http://docker.io).

Versions
----------------

.NET Core versions currently provided are:

* [RETIRED] 1.0 (RHEL 7, CentOS 7)
* [RETIRED] 1.1 (RHEL 7)
* [RETIRED] 2.0 (RHEL 7, CentOS 7)
* 2.1 (RHEL 7, RHEL 8, CentOS 7)
* [RETIRED] 2.2 (RHEL 7, CentOS 7)
* [RETIRED] 3.0 (RHEL 7, RHEL 8)
* 3.1 (RHEL 7, RHEL 8, CentOS 7, Fedora)
* 5.0 (RHEL 7, RHEL 8, CentOS 7, Fedora)

Building
----------------

```
$ git clone https://github.com/redhat-developer/s2i-dotnetcore.git
$ sudo VERSIONS=5.0 ./build.sh
```

Note: to build RHEL 7 based images, you need to run the build on a
properly subscribed RHEL 7 machine. On RHEL 8 systems, RHEL 8 images
are built by default. On non-RHEL, building CentOS images is the default.

To override the default basis of the image, set IMAGE_OS to the desired
base system, such as IMAGE_OS=CENTOS or IMAGE_OS=RHEL8.

Installing
----------------

The image streams can be installed using the `dotnet_imagestreams_*.json` files with the OpenShift client `oc`.

This repo contains a script that helps install/upgrade/remove the imagestreams.

### Linux/macOS

script: https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/install-imagestreams.sh

For example, to install the `rhel7` based images and add a secret for authenticating against the `registry.redhat.io` registry:

```sh
$ wget https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/install-imagestreams.sh
$ chmod +x install-imagestreams.sh
$ ./install-imagestreams.sh --os rhel7 -u <subscription_username> -p <subscription_password>
```

You can run `./install-imagestreams.sh --help` for more information.

### Windows

script: https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/install-imagestreams.ps1

For example, to install the `rhel7` based images and add a secret for authenticating against the `registry.redhat.io` registry:

```sh
PS > Invoke-WebRequest https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/install-imagestreams.ps1 -UseBasicParsing -OutFile install-imagestreams.ps1
PS > .\install-imagestreams.ps1 -OS rhel7 -User <subscription_username> -Password <subscription_password>
```

Running scripts may be prohibited by the `ExecutionPolicy`, you can relax the policy by running: `Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass -Force`

You can run `Get-Help .\install-imagestreams.ps1` for more information.

Usage
---------------------------------

For information about usage of Docker image for .NET Core 5.0,
see [5.0 builder usage documentation](5.0/build/README.md) and
[5.0 runtime usage documentation](5.0/runtime/README.md).

For information about usage of Docker image for .NET Core 3.1,
see [3.1 builder usage documentation](3.1/build/README.md) and
[3.1 runtime usage documentation](3.1/runtime/README.md).

For information about usage of Docker image for .NET Core 3.0,
see [3.0 builder usage documentation](3.0/build/README.md) and
[3.0 runtime usage documentation](3.0/runtime/README.md).

For information about usage of Docker image for .NET Core 2.2,
see [2.2 builder usage documentation](2.2/build/README.md) and
[2.2 runtime usage documentation](2.2/runtime/README.md).

For information about usage of Docker image for .NET Core 2.1,
see [2.1 builder usage documentation](2.1/build/README.md) and
[2.1 runtime usage documentation](2.1/runtime/README.md).

For information about usage of Docker image for .NET Core 2.0,
see [2.0 builder usage documentation](2.0/build/README.md) and
[2.0 runtime usage documentation](2.0/runtime/README.md).

For information about usage of Docker image for .NET Core 1.1,
see [1.1 usage documentation](1.1/README.md).

For information about usage of Docker image for .NET Core 1.0,
see [1.0 usage documentation](1.0/README.md).

Image name structure
------------------------

##### Structure: dotnet/1-2-3

1. Platform name: 'dotnetcore' for 1.x, 'dotnet' for 2.0+
2. Platform version (without dots)
3. Base image: 'rhel7' or 'centos7'

Examples: `dotnet/dotnetcore-10-rhel7`, `dotnet/dotnet-21-centos7`

OpenShift Templates
-------------------

The `templates` folder contains OpenShift templates. Some of these will be shipped with OpenShift.
Templates under the `templates/community` folder are provided and maintained by the community.
They are not supported or kept up-to-date by the maintainers of this repository and may fail when
used with newer versions of .NET Core.

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

**dotnet-runtime-example**

The dotnet-runtime-example template can be used to create a new .NET Core service in OpenShift. It is meant to serve as an example of
how to create a 'chained build' where one image is used to build an application but the runtime image is used to deploy the application.

For more information on build chaining in OpenShift, [please see this doc](https://docs.openshift.org/latest/dev_guide/builds/advanced_build_operations.html#dev-guide-chaining-builds).

**dotnet-pgsql-persistent**

The dotnet-pgsql-persistent creates a .NET Core service with a PostgreSQL backend. It provides parameters for all the environment
variables of the s2i-dotnetcore builder and variables to setup the database. The database connection information is passed to the
.NET application via the `ConnectionString` environment variable.

**aspnet-2.x.json**

Provides `aspnet:2.1` image streams that are built on top of `dotnet:2.1` using a `Docker` strategy and include
ASP.NET Core NuGet packages. Using these streams results in improved build speed, because the NuGet packages no longer need to be downloaded.

You can add these imagestreams by running:
```
oc create -f https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/templates/aspnet-2.x.json
```

After the file is imported in OpenShift, OpenShift will build the `aspnet:2.1` images. This will take a few minutes. Once that is
complete, they can be used as replacements for the `dotnet:2.1` image streams. For example:

```
oc new-app --name=myapp aspnet:2.1~https://github.com/redhat-developer/s2i-dotnetcore-ex#dotnetcore-2.1 --build-env DOTNET_STARTUP_PROJECT=app
```

**note**: `dotnet:3.0`+ image streams include ASP.NET Core build dependencies by default.

**community/dotnet-baget.json**

Provides templates for deploying a persistent, or ephemeral NuGet Server on OpenShift. These templates use BaGet,
an open-source NuGet server implementation. Source code for BaGet can be found at: https://github.com/loic-sharma/BaGet.git.
