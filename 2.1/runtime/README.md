.Net Docker image
=================

This repository contains the source for building a docker image that
can be used as a base in which to run already built .Net applications.

The image can be run using [Docker](http://docker.io).

Usage
---------------------
The distributale binaries of an application should be copied to this image and
a new docker image should be created using this image as the base.

For example to create a Docker image for [s2i-dotnetcore-ex](https://github.com/redhat-developer/s2i-dotnetcore-ex) 

Publish the application:
```
$ git clone -b dotnetcore-2.1 https://github.com/redhat-developer/s2i-dotnetcore-ex.git
$ cd s2i-dotnetcore-ex/app
$ dotnet restore -r rhel.7-x64
$ dotnet publish -f netcoreapp2.1 -c Release -r rhel.7-x64 --self-contained false
```

Create the Docker image:
```
$ cat > Dockerfile <<EOF
FROM dotnet/dotnet-21-runtime-rhel7
ADD bin/Release/netcoreapp2.1/rhel.7-x64/publish/. .
CMD [ "dotnet", "app.dll" ]
EOF
$ docker build -t s2i-dotnetcore-ex .
```

Start a container:
```
$ docker run --rm -p 8080:8080 s2i-dotnetcore-ex
```

Visit the web application that is running in the docker container with a browser at [http://localhost:8080].

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
