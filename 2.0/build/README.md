.Net Docker image
=================

This repository contains the source for building .Net applications
as a reproducible Docker image using
[source-to-image](https://github.com/openshift/source-to-image).
The resulting image can be run using [Docker](http://docker.io).


Usage
---------------------
To build a simple [dotnet-sample-app](test/asp-net-hello-world) application
using standalone [S2I](https://github.com/openshift/source-to-image) and then run the
resulting image with [Docker](http://docker.io) execute:

    ```
    $ sudo s2i build git://github.com/redhat-developer/s2i-dotnetcore --context-dir=2.0/test/asp-net-hello-world dotnet/dotnet-20-rhel7 dotnet-sample-app
    $ sudo docker run -p 8080:8080 dotnet-sample-app
    ```

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

* **Dockerfile**

  CentOS based Dockerfile.

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

    .Net Core "Hello World" used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

  * **`qotd/`**

    .Net Core Quote of the Day example app used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

  * **`asp-net-hello-world/`**

    ASP .Net hello world example app used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

  * **`asp-net-hello-world-envvar/`**

    ASP .Net hello world example app used for testing purposes by the [S2I](https://github.com/openshift/source-to-image) test framework.

Environment variables
---------------------

To set these environment variables, you can place them as a key value pair into
a `.s2i/environment` file inside your source code repository.

* **DOTNET_STARTUP_PROJECT**

    Used to select the project to run. This must be a project file (e.g. csproj, fsproj) or a folder containing a single project file. Defaults to `.`.

* **DOTNET_ASSEMBLY_NAME**

    Used to select the assembly to run. This must NOT include the `.dll` extension.
    Set this to the output assembly name specified in the project file (`PropertyGroup/AssemblyName`). This defaults
    to the project filename.

* **DOTNET_RESTORE_SOURCES**

    Used to specify the list of NuGet package sources used during the restore operation. This overrides 
    all of the sources specified in the NuGet.config file.

* **DOTNET_NPM_TOOLS**

    Used to specify a list of npm packages to install before building the app.
    Defaults to ``.

* **DOTNET_TEST_PROJECTS**

    Used to specify the list of test projects to run. This must be project files or folders containing a
    single project file. `dotnet test` is invoked for each item. Defaults to ``.

* **DOTNET_CONFIGURATION**

    Used to run the application in Debug or Release mode. This should be either
    `Release` or `Debug`.  This is passed to the `dotnet publish` invocation.
    Defaults to `Release`.

* **ASPNETCORE_URLS**

    This variable is set to `http://*:8080` to configure ASP.NET Core to use the
    port exposed by the image.

* **HTTP_PROXY, HTTPS_PROXY**

    Configures the HTTP/HTTPS proxy used when building and running the application.

* **NPM_MIRROR**

    Use a custom NPM registry mirror to download packages during the build process.

* **DOTNET_ASPNET_STORE**

    Publish assuming the runtime image contains the ASP.NET Core runtime store. Defaults to `false`.

* **DOTNET_PACK**

    When set to `true` creates a tar.gz file at `/opt/app-root/app.tar.gz` that contains the published application.

* **DEV_MODE**

    When set to `true`, the application restart automatically when the source code changes. `dotnet run`
    is used to start the application.

* **DOTNET_NO_RESTORE** (dotnet 2.0 only)

  Can be set to `--no-restore`, will be passed to the `dotnet publish` command in `assemble`. Intended to be used for
  situations where not attempting to connect to an external `nuget.org` site is useful. An example of this
  would be a disconnected build configuration where all desired nuget packages are already accessible to the
  build either on the host or in the image.

* **DOTNET_VERBOSITY** (dotnet 2.0 only)

  Will be passed to `assemble` script `dotnet publish` command allowing additional build related descriptive output.
  Example values are `-v  [ q | n | d | diag ]` (for quiet, minimal, normal, detailed and diagnostic levels).

NPM
---

Typical modern web applications rely on javascript tools to build the front-end.
The image includes npm (node package manager) to install these tools. Packages can be
installed by setting `DOTNET_NPM_TOOLS` and by calling `npm install` in the build process.
