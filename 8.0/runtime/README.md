.NET Runtime image
=================

This repository contains the source for building a container image that
can be used as a base in which to run already built .NET applications.

The container image can be used as a base image using [docker](http://docker.io)/[podman](https://podman.io/).
Or you can build an application image using [s2i](https://github.com/openshift/source-to-image/releases).
The image can be run using `docker`/`podman`.

Usage
---------------------
The distributale binaries of an application should be copied to this image and
a new docker image should be created using this image as the base.

For example to create an image for [s2i-dotnetcore-ex](https://github.com/redhat-developer/s2i-dotnetcore-ex)

Publish the application:
```
$ git clone -b dotnet-8.0 https://github.com/redhat-developer/s2i-dotnetcore-ex.git
$ cd s2i-dotnetcore-ex/app
$ dotnet publish -c Release /p:MicrosoftNETPlatformLibrary=Microsoft.NETCore.App
```

To create an image using `s2i`:
```
$ s2i build bin/Release/net8.0/publish ubi8/dotnet-80-runtime s2i-dotnetcore-ex
```

To create an image using `docker`/`podman`:
```
$ cat > Dockerfile <<EOF
FROM ubi8/dotnet-80-runtime
ADD bin/Release/net8.0/publish/. .
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

* **Dockerfile.rhel8**

  UBI 8 / RHEL 8 based Dockerfile. No RHEL subscription is required, but without
  one only UBI RPMs can be added to the container.

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

* **DOTNET_APP_PATH,DOTNET_DEFAULT_CMD,DOTNET_DATA_PATH**

    These variables contain the working directory (`/opt/app-root/app`), the default CMD of the runtime image (`default-cmd.sh`)
    and an empty folder you can use to store your application data (`/opt/app-root/data`) and make persistent with a volume mount.

* **DOTNET_SSL_DIRS**

    Used to specify a list of folders/files with additional certificates to trust. The certificates are trusted by each process that runs
    during the build and all processes that run in the image after the build (including the application that was built). The items
    can be absolute paths (starting with `/`) or paths in the source repository (e.g. `certificates`). Defaults to ``.

* **DOTNET_FRAMEWORK,DOTNET_CORE_VERSION**

    These variables contain the framework (`net8.0`) and .NET version (`8.0`) respectively.

* **DOTNET_RUNNING_IN_CONTAINER**

    Like Microsoft images, this is set to `true` and can be used to detect the application is built/running in a container.

* **APP_UID**

    Like Microsoft images, this is set to the rootless user's uid to enable switching to that user
    in a Dockerfile using the the instruction: `USER $APP_UID`.
