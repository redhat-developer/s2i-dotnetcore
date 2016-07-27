.Net Core Docker Image
======================

This repository contains the source for building .Net core apps as reproducible
Docker images using
[source-to-image](https://github.com/openshift/source-to-image).  The resulting
image can be run using [Docker](http://docker.io).

Versions
----------------
.Net core versions currently provided are:
* dotnetcore-1.0

RHEL versions currently supported are:
* RHEL 7

Installation
----------------

To build a RHEL 7 based .Net image, you need to run the build on a properly
subscribed RHEL machine.

```
$ git clone https://github.com/redhat-developer/s2i-dotnetcore.git
$ cd s2i-dotnetcore/1.0
$ sudo docker build -f Dockerfile.rhel7 -t dotnet/dotnetcore-10-rhel7 .
```

Usage
---------------------------------

For information about usage of Docker image for .Net core 1.0,
see [usage documentation](1.0/README.md).

Image name structure
------------------------
##### Structure: dotnet/1-2-3

1. Platform name (lowercase) - dotnetcore
2. Platform version (without dots) - 10
3. Base builder image - rhel7

Example: `dotnet/dotnetcore-10-rhel7`
