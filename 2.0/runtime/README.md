.Net Docker image
=================

This repository contains the source for building a docker image that
can be used as a base in which to run already built .Net applications.

The image can be run using [Docker](http://docker.io).

Usage
---------------------
The distributale binaries of an application should be copied to this image and
a new docker image should be created using this image as the base. As an
example, given an archive of the binaries of a simple [dotnet-sample-app](test/asp-net-hello-world)
application, the following Dockerfile could be used.

**Sample Dockerfile**
```
FROM dotnet-20-rhel7-runtime
RUN mkdir -p '/opt/app-root/publish'
WORKDIR /opt/app-root/publish
COPY asp-net-hello-world.tar.gz asp-net-hello-world.tar.gz
RUN tar xvf asp-net-hello-world.tar.gz
CMD /opt/app-root/publish/s2i_run
```

As for generating the binary archives in the first place, often this can be
accomplished by running a dotnet restore and a dotnet publish to a single
directory and then archiving that directories contents.

**Example Binary Archive Creation**
``` sh
cd asp-net-hello-world
dotnet restore "." -r "rhel.7-x64"
dotnet publish "." -f "netcoreapp2.0" -c "Release" -r "rhel.7-x64" --self-contained false /p:TargetManifestFiles= -o "./publish"
tar zcvpf "./asp-net-hello-world.tar.gz" -C ./publish .
```

This example cds into the project's directory, restores the projects NuGet dependencies, and then publishes the project to a publish directory. Finally, a tar command is used to create a gzipped tar file containing the content of the publish directory. This tar file is what is copied and extracted to create the apps runtime image, using the sample dockerfile given above.

**Accessing the application:**

HTTP:

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

* **HTTP_PROXY, HTTPS_PROXY**

    Configures the HTTP/HTTPS proxy used when running the application.
