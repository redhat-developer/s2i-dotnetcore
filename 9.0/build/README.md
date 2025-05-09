.NET SDK image
=================

This repository contains the source for building .NET applications
as a reproducible container image using
[source-to-image](https://github.com/openshift/source-to-image).
The resulting image can be run using [docker](http://docker.io)/[podman](https://podman.io/).


Usage
---------------------
To build a simple [dotnet-sample-app](test/asp-net-hello-world) application
using standalone [S2I](https://github.com/openshift/source-to-image) and then run the
resulting image with `docker`/`podman` execute:

    ```
    $ sudo s2i build git://github.com/redhat-developer/s2i-dotnetcore --context-dir=9.0/build/test/asp-net-hello-world ubi8/dotnet-90 dotnet-sample-app
    $ sudo docker run -p 8080:8080 dotnet-sample-app
    ```

**Accessing the application:**

HTTP:

```
$ curl http://127.0.0.1:8080
```

Incremental builds
------------------

The s2i image supports incremental builds. For incremental builds, NuGet packages
will be re-used. To keep NuGet packages so they can be reused, you must set
`DOTNET_INCREMENTAL` to `true`.

Repository organization
------------------------

* **Dockerfile.rhel8**

  UBI 8 / RHEL 8 based Dockerfile. No RHEL subscription is required, but without
  one only UBI RPMs can be added to the container.

* **`root/usr/bin/`**

  This folder contains common scripts.

* **`s2i/bin/`**

  This folder contains scripts that are run by [S2I](https://github.com/openshift/source-to-image):

  *   **assemble**

      Used to install the sources into the location where the application
      will be run and prepare the application for deployment

  *   **run**

      This script is responsible for running the application

  *   **usage**

      This script prints the usage of this image.

* **`contrib/`**

  This folder contains scripts under the app source tree.

* **`test/`**

  This folder contains [S2I](https://github.com/openshift/source-to-image)
  dotnet sample applications.

  * **`helloworld/`**

    .Net "Hello World" used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

  * **`qotd/`**

    .Net Quote of the Day example app used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

  * **`asp-net-hello-world/`**

    ASP .Net hello world example app used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

  * **`asp-net-hello-world-envvar/`**

    ASP .Net hello world example app used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

Environment variables
---------------------

To set environment variables, you can place them as a key value pair into
an `.s2i/environment` file inside your source code repository.

* **DOTNET_STARTUP_PROJECT**

    Used to select the project to run. This must be a project file (e.g. csproj, fsproj) or a folder containing a single project file. Defaults to `.`.

* **DOTNET_ASSEMBLY_NAME**

    Used to select the assembly to run. This must NOT include the `.dll` extension.
    Set this to the output assembly name specified in the project file (`PropertyGroup/AssemblyName`). This defaults
    to the project filename.

* **DOTNET_PUBLISH_READYTORUN**

    When set to `true`, the application will be compiled ahead-of-time. This reduces startup time by reducing the amount of work
    the JIT needs to do when the application is loading. Defaults to ``.

* **DOTNET_RESTORE_SOURCES**

    Used to specify the list of NuGet package sources used during the restore operation. This overrides 
    all of the sources specified in the NuGet.config file. This variable cannot be combined with `DOTNET_RESTORE_CONFIGFILE`.

* **DOTNET_RESTORE_CONFIGFILE**

    Specifies a NuGet.Config file to be used for restore operations.
    This variable cannot be combined with `DOTNET_RESTORE_SOURCES`.

* **DOTNET_RESTORE_DISABLE_PARALLEL**

    When set to true disables restoring multiple projects in parallel. This reduces restore timeout errors when the build container is running with low cpu limits. 
    Defaults to `false`.

* **DOTNET_TOOLS**

    Used to specify a list of .NET tools to install before building the app. It is possible to install a specific version by postpending
    the package name with `@<version>`. Defaults to ``.

* **DOTNET_TEST_PROJECTS**

    Used to specify the list of test projects to run. This must be project files or folders containing a
    single project file. `dotnet test` is invoked for each item. Defaults to ``.

* **DOTNET_VERBOSITY**

    Used to specify the verbosity of the dotnet build commands. When set, the environment variables are printed at the start
    of the build. This variable can be set to one of the msbuild verbosity values (`q[uiet]`, `m[inimal]`, `n[ormal]`,
    `d[etailed]`, and `diag[nostic]`). Defaults to ``.

* **DOTNET_INFO**

    Used to print information about the .NET environment at the start of the build, and before executing the application.
    The variable can be set to any string to print the information. Defaults to ``.

* **DOTNET_CONFIGURATION**

    Used to run the application in Debug or Release mode. This should be either
    `Release` or `Debug`.  This is passed to the `dotnet publish` invocation.
    Defaults to `Release`.

* **ASPNETCORE_URLS**

    This variable is set to `http://*:8080` to configure ASP.NET Core to use the
    port exposed by the image.

* **HTTP_PROXY, HTTPS_PROXY**

    Configures the HTTP/HTTPS proxy used when building and running the application.

* **DOTNET_RM_SRC**

    When set to `true`, the source code will not be included in the image. Defaults to ``.

* **DOTNET_INCREMENTAL**

    When set to `true`, the NuGet packages will be kept so they can be re-used for an incremental build.
    Defaults to `false`.

* **DOTNET_STARTUP_ASSEMBLY**

    Used to specify the path of the entrypoint assembly within the source repository. When set,
    the source repository must contain a pre-built application. Defaults to ``.

* **DOTNET_PACK**

    When set to `true` creates a tar.gz file at `/opt/app-root/app.tar.gz` that contains the published application.

* **DOTNET_USE_POLLING_FILE_WATCHER**

    This is set to `true` to ensure the `dotnet watch` command works in a container. This command is not used by the default scripts.

* **DOTNET_SDK_VERSION**

    This variable contains the version of the SDK.
