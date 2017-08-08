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
$ git clone -b dotnetcore-2.0 https://github.com/redhat-developer/s2i-dotnetcore-ex.git
$ cd s2i-dotnetcore-ex/app
$ dotnet restore -r rhel.7-x64
$ dotnet publish -f netcoreapp2.0 -c Release -r rhel.7-x64 --self-contained false /p:PublishWithAspNetCoreTargetManifest=false
```

Create the Docker image:
```
$ cat > Dockerfile <<EOF
FROM dotnet/dotnet-20-runtime-rhel7
ADD bin/Release/netcoreapp2.0/rhel.7-x64/publish/. .
CMD [ "dotnet", "app.dll" ]
EOF
$ docker build -t s2i-dotnetcore-ex .
```

Start a container:
```
$ docker run -p 8080:8080 s2i-dotnetcore-ex
```

Fetch a webpage:
```
$ curl http://127.0.0.1:8080
```

Repository organization
------------------------

* **Dockerfile.rhel7**

  RHEL based Dockerfile. In order to perform build or test actions on this
  Dockerfile you need to run the action on a properly subscribed RHEL machine.

* **`test/`**

  This folder contains binary archives of [S2I](https://github.com/openshift/source-to-image)
  dotnet sample applications.

  * **`helloworld/`**

    .Net Core "Hello World" used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

  * **`qotd/`**

    .Net Core Quote of the Day example app used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

  * **`asp-net-hello-world/`**

    ASP .Net hello world example app used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

  * **`asp-net-hello-world-envvar/`**

    ASP .Net hello world example app used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

Environment variables
---------------------

* **ASPNETCORE_URLS**

    This variable is set to `http://*:8080` to configure ASP.NET Core to use the
    port exposed by the image.
