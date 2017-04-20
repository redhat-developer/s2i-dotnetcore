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

*  **For RHEL based image**

    ```
    $ sudo s2i build git://github.com/redhat-developer/s2i-dotnetcore --context-dir=1.1/test/asp-net-hello-world dotnet/dotnetcore-11-rhel7 dotnet-sample-app
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

    Used to select the project to run. This must be the folder containing
    `project.json`. Defaults to `.`.

* **DOTNET_PUBLISH**

    Used to control whether the application should be built by executing
    `dotnet build` or `dotnet publish`. To publish the application set the
    value to `true`. It is recommended to publish your application. For
    backwards compatibility, the default is `false`. In the next major release,
    this variable will be removed and the builder will always publish the
    application.

* **DOTNET_ASSEMBLY_NAME**

    Used to select the assembly to run. This must NOT include the `.dll` extension.
    Set this to the output assembly name specified in `project.json` (`name`, `buildOptions/outputName`).
    For `project.json`, the assembly name defaults to the `project.json` parent folder. The name of the
    parent folder is used as the default value for `DOTNET_ASSEMBLY_NAME`.

    When `project.json` is at the `context-dir`, the parent folder name will be 'src'. So, by
    default, this generates a 'src.dll' assembly. Setting `DOTNET_ASSEMBLY_NAME` will cause:
    - the assembly to be <DOTNET_ASSEMBLY_NAME>.dll
    - the application sources to be in subfolder `DOTNET_ASSEMBLY_NAME` in the deployed
    container.

* **DOTNET_RESTORE_SOURCES**

    Used to specify the list of NuGet package sources used during the restore operation. This overrides 
    all of the sources specified in the NuGet.config file.

* **DOTNET_NPM_TOOLS**

    Used to specify a list of npm packages to install before building the app.
    Defaults to ``.

* **DOTNET_TEST_PROJECTS**

    Used to specify the list of test projects to run. This must be folders containing
    `project.json`. `dotnet test` is invoked for each folder. Defaults to ``.

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

NPM
---

Typical modern web applications rely on javascript tools to build the front-end.
The image includes npm (node package manager) to install these tools. Packages can be
installed by setting `DOTNET_NPM_TOOLS` and by calling `npm install` in the build process.
