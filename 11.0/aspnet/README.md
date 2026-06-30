ASP.NET Core Runtime image
==================

This repository contains the source for building a container image that
can be used as a base for framework-dependent ASP.NET Core applications.

Usage
---------------------

To containerize a .NET application, you can use the .NET (10+) SDK's `PublishContainer` target with the `ContainerBaseImage` property set to the desired base image.

For example:

```
dotnet publish /p:ContainerBaseImage=registry.access.redhat.com/ubi9/dotnet-100-aspnet /t:PublishContainer -v detailed
```

Repository organization
------------------------

* **Dockerfile.rhel9**

  UBI 9 / RHEL 9 based Dockerfile. No RHEL subscription is required, but without
  one only UBI RPMs can be added to the container.

* **`test/`**

  This folder contains binary archives of [S2I](https://github.com/openshift/source-to-image)
  dotnet sample applications.

  * **`aspnet-hello-world/`**

    ASP .Net hello world example app used for testing purposes. Sources are precompiled in `app.tar.gz`.
    See [build-project.sh](test/aspnet-hello-world/build-project.sh) for as to how to produce
    the binary.

Environment variables
---------------------

The following variables are set so they can be used from scripts.
They must not to be overridden.

**ASPNET_VERSION**

    These variable contains the version of the ASP.NET Core runtime.
