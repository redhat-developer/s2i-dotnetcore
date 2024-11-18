# .NET S2I Container Images

This repository contains the sources for building .NET SDK and runtime container images.

The images support OpenShift [source-to-image](https://github.com/openshift/source-to-image).

## Supported Versions

| Version | OS | Documentation
|--|--|--|
| 8.0 | UBI 8         | [SDK image](8.0/build/README.md) <br/> [Runtime image](8.0/runtime/README.md)
| 9.0 | UBI 8         | [SDK image](9.0/build/README.md) <br/> [Runtime image](9.0/runtime/README.md)

## EOL Versions

| Version | OS | Documentation
|--|--|--|
| 1.0 | RHEL 7, CentOS 7 | [SDK image](1.0/build/README.md) <br/> [Runtime image](1.0/runtime/README.md)
| 1.1 | RHEL 7 | [SDK image](1.1/build/README.md) <br/> [Runtime image](1.1/runtime/README.md)
| 2.0 | RHEL 7, CentOS 7 | [SDK image](2.0/build/README.md) <br/> [Runtime image](2.0/runtime/README.md)
| 2.1 | RHEL 7, UBI 8, <br/>  CentOS 7 | [SDK image](2.1/build/README.md) <br/> [Runtime image](2.1/runtime/README.md)
| 2.2 | RHEL 7, CentOS 7 | [SDK image](2.2/build/README.md) <br/> [Runtime image](2.2/runtime/README.md)
| 3.0 | RHEL 7, UBI 8 | [SDK image](3.0/build/README.md) <br/> [Runtime image](3.0/runtime/README.md)
| 3.1 | RHEL 7, UBI 8,  <br/> CentOS 7, Fedora | [SDK image](3.1/build/README.md) <br/> [Runtime image](3.1/runtime/README.md)
| 5.0 | UBI 8, CentOS 7,  <br/> Fedora | [SDK image](5.0/build/README.md) <br/> [Runtime image](5.0/runtime/README.md)
| 6.0 | UBI 8, Fedora | [SDK image](6.0/build/README.md) <br/> [Runtime image](6.0/runtime/README.md)
| 7.0 | UBI 8, Fedora | [SDK image](7.0/build/README.md) <br/> [Runtime image](7.0/runtime/README.md)

Building
----------------

You can build (and test) the images by executing the `build.sh` script and pass it the versions to build.

```
$ git clone https://github.com/redhat-developer/s2i-dotnetcore.git
$ ./build.sh --ci 8.0 9.0
```

To override the default basis of the image, you can use the `--base-os` argument. For example: `--base-os fedora` or `--base-os rhel8`.

For an overview of all build script arguments, run: `./build.sh --help`.

Installing
----------------

The image streams can be added to OpenShift by importing an `dotnet_imagestreams_*.json` file with the OpenShift client `oc`.

```
oc apply -f https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/main/dotnet_imagestreams.json
```

The `dotnet_imagestreams_*.json` files define the supported .NET versions for a specific architecture:

| Architecture | File |
|--|--|
| x64 | https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/main/dotnet_imagestreams.json |
| arm64 | https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/main/dotnet_imagestreams_aarch64.json |
| ppc64le | https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/main/dotnet_imagestreams_ppc64le.json |
| s390x | https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/main/dotnet_imagestreams_s390x.json |
