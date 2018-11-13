.NET Core Runtime image
=================

This repository contains the source for building a container image that
can be used as a base in which to run already built .NET Core applications.

The container image can be used as a base image using [docker](http://docker.io)/[podman](https://podman.io/).
Or you can build an application image using [s2i](https://github.com/openshift/source-to-image/releases).

The image can be run using `docker`/`podman`.

Usage
---------------------

For example to create an image for [s2i-dotnetcore-ex](https://github.com/redhat-developer/s2i-dotnetcore-ex) 

Publish the application:
```
$ git clone -b dotnetcore-2.1 https://github.com/redhat-developer/s2i-dotnetcore-ex.git
$ cd s2i-dotnetcore-ex/app
$ dotnet publish -c Release /p:MicrosoftNETPlatformLibrary=Microsoft.NETCore.App
```

To create an image using `s2i`:
```
$ s2i build bin/Release/netcoreapp2.1/publish dotnet/dotnet-21-runtime-rhel7 s2i-dotnetcore-ex
```

To create an image using `docker`/`podman`:
```
$ cat > Dockerfile <<EOF
FROM dotnet/dotnet-21-runtime-rhel7
ADD bin/Release/netcoreapp2.1/publish/. .
CMD [ "dotnet", "app.dll" ]
EOF
$ docker build -t s2i-dotnetcore-ex .
```

Start a container:
```
$ docker run --rm -p 8080:8080 s2i-dotnetcore-ex
```

Visit the web application that is running in the container with a browser at [http://localhost:8080].

Repository organization
------------------------

* **Dockerfile.rhel7**

  RHEL based Dockerfile. In order to perform build or test actions on this
  Dockerfile you need to run the action on a properly subscribed RHEL machine.

* **Dockerfile**

  CentOS based Dockerfile.

* **`test/`**

  This folder contains binary archives of [S2I](https://github.com/openshift/source-to-image)
  dotnet sample applications.

  * **`asp-net-hello-world/`**

    ASP .Net hello world example app used for testing purposes. Sources are precompiled in `app.tar.gz`.
    See [build-project.sh](test/aspnet-hello-world/build-project.sh) for as to how to produce
    the binary.

Environment variables
---------------------

The following variables are set so they can be used from scripts.
They must not to be overridden.

* **ASPNETCORE_URLS**

    This variable is set to `http://*:8080` to configure ASP.NET Core to use the
    port exposed by the image.

* **DOTNET_APP_PATH,DOTNET_DEFAULT_CMD**

    These variables contain the working directory (`/opt/app-root/app`) and default CMD of the runtime image (`default-cmd.sh`).

* **DOTNET_SSL_DIRS**

    Used to specify a list of folders/files with additional certificates to trust. The certificates are trusted by each process that runs
    during the build and all processes that run in the image after the build (including the application that was built). The items
    can be absolute paths (starting with `/`) or paths in the source repository (e.g. `certificates`). Defaults to ``.

* **DOTNET_FRAMEWORK,DOTNET_CORE_VERSION**

    These variables contain the framework (`netcoreapp2.1`) and .NET Core version (`2.1`) respectively.

* **DOTNET_RUNNING_IN_CONTAINER**

    Like Microsoft images, this is set to `true` and can be used to detect the application is built/running in a container.
