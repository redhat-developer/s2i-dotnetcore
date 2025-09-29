.NET Runtime image
==================

This repository contains the source for building a container image that
can be used as a base for framework-dependent .NET Core applications.
For framework dependent ASP.NET Core applications, use the "ASP.NET Core Runtime image" instead.

Usage
---------------------

To containerize a .NET console application, you can use the .NET (10+) SDK's `PublishContainer` target with the `ContainerBaseImage` property set to the desired base image.

For example:

```
dotnet publish /p:ContainerBaseImage=registry.access.redhat.com/ubi9/dotnet-100-runtime /t:PublishContainer -v detailed
```


Repository organization
------------------------

* **Dockerfile.rhel9**

  UBI 9 / RHEL 9 based Dockerfile. No RHEL subscription is required, but without
  one only UBI RPMs can be added to the container.

* **`test/`**

  This folder contains binary archives of [S2I](https://github.com/openshift/source-to-image)
  dotnet sample applications.

  * **`console-hello-world/`**

    ASP .Net hello world example app used for testing purposes. Sources are precompiled in `app.tar.gz`.
    See [build-project.sh](test/console-hello-world/build-project.sh) for as to how to produce
    the binary.

Environment variables
---------------------

The following variables are set so they can be used from scripts.
They must not to be overridden.

* **ASPNETCORE_URLS**

    This variable is set to `http://*:8080` to configure ASP.NET Core to use the
    port exposed by the image.

* **DOTNET_APP_PATH,DOTNET_DEFAULT_CMD,DOTNET_DATA_PATH**

    These variables contain the working directory (`/opt/app-root/app`), the default CMD of the runtime image (`default-cmd.sh`)
    and an empty folder you can use to store your application data (`/opt/app-root/data`) and make persistent with a volume mount.

* **SSL_CERT_DIR**

    Used to specify a list of colon (`:`) separated directories with certificates to trust.
    To load the default system directory, you can include `/etc/ssl/certs`.
    Adding directories that do not exist does not cause errors.

    It's recommended to use absolute paths.
    If you use an s2i build, you can refer to a directory that is part of the s2i source repository using `/opt/app-root/src` as the base directory.
    To refer to a directory that is part of the s2i application, you can use `/opt/app-root/app` as the base directory.
    Note that these certificates from the source repository will be loaded when the application runs unless `DOTNET_RM_SRC`
    is set to `true` to remove the application sources from the application image.

    **Breaking change** Since .NET 9, trusting certificates using `DOTNET_SSL_DIRS` is no longer supported and `SSL_CERT_DIR` must be used instead.

* **DOTNET_RUNNING_IN_CONTAINER**

    Like Microsoft images, this is set to `true` and can be used to detect the application is built/running in a container.

* **APP_UID**

    Like Microsoft images, this is set to the rootless user's uid to enable switching to that user
    in a Dockerfile using the the instruction: `USER $APP_UID`.

* **DOTNET_VERSION**, **ASPNET_VERSION**

    These variables contain the version of the .NET runtime and ASP.NET Core runtime.
