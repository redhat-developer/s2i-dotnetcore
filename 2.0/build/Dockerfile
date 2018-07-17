FROM centos:7
# This image provides a .NET Core 2.0 environment you can use to run your .NET
# applications.

ENV PATH=/opt/app-root/src/.local/bin:/opt/app-root/src/bin:/opt/app-root/node_modules/.bin:${PATH} \
    STI_SCRIPTS_PATH=/usr/libexec/s2i \
    ASPNETCORE_URLS=http://*:8080

LABEL io.k8s.description="Platform for building and running .NET Core 2.0 applications" \
      io.k8s.display-name=".NET Core 2.0" \
      io.openshift.s2i.scripts-url=image:///usr/libexec/s2i \
      io.openshift.tags="builder,.net,dotnet,dotnetcore,rh-dotnet20" \
      io.openshift.expose-services="8080:http" \
      io.s2i.scripts-url=image:///usr/libexec/s2i

# Labels consumed by Red Hat build service
LABEL name="dotnet/dotnet-20-centos7" \
      com.redhat.component="rh-dotnet20-docker" \
      version="2.0" \
      release="3" \
      architecture="x86_64"

# Labels consumed by Eclipse JBoss OpenShift plugin
LABEL com.redhat.dev-mode="DEV_MODE:false" \
      com.redhat.deployments-dir="/opt/app-root/src"

# Switch to root for package installs
USER 0

# Copy the S2I scripts from the specific language image to $STI_SCRIPTS_PATH.
COPY ./s2i/bin/ /usr/libexec/s2i

RUN yum install -y centos-release-dotnet centos-release-scl-rh && \
    INSTALL_PKGS="rh-nodejs6-npm rh-nodejs6-nodejs-nodemon rh-dotnet20-dotnet-sdk-2.0 rsync" && \
    yum install -y --setopt=tsflags=nodocs $INSTALL_PKGS && \
    rpm -V $INSTALL_PKGS && \
# trim nodejs dependencies to reduce image size and to avoid rebuilds on kernel CVEs.
    rpm -e --nodeps glibc-headers glibc-devel gcc gcc-c++ kernel-headers && \
    yum clean all -y && \
# yum cache files may still exist (and quite large in size)
    rm -rf /var/cache/yum/*

# Directory with the sources is set as the working directory.
RUN mkdir -p /opt/app-root/src
WORKDIR /opt/app-root/src

# Since $HOME is set to /opt/app-root, the yum install may have created config
# directories (such as ~/.pki/nssdb) there. These will be owned by root and can
# cause actions that work on all of /opt/app-root to fail. So we need to fix
# the permissions on those too.
RUN chown -R 1001:0 /opt/app-root && chmod -R og+rwx /opt/app-root

ENV ENABLED_COLLECTIONS="$ENABLED_COLLECTIONS rh-nodejs6"

# For backwards compatibility, s2i builds default to the oldest sdk in the image.
# We keep the patch at '0', the latest patch version is automatically picked up.
ENV DOTNET_SDK_BASE_VERSION=2.0.0 \
# Needed for the `dotnet watch` to detect changes in a container.
    DOTNET_USE_POLLING_FILE_WATCHER=true  \
    PATH=/opt/rh/rh-dotnet20/root/usr/bin:/opt/rh/rh-dotnet20/root/usr/sbin:/opt/rh/rh-nodejs6/root/usr/bin:$PATH \
    CPATH=/opt/rh/rh-dotnet20/root/usr/include:$CPATH \
    LD_LIBRARY_PATH=/opt/rh/rh-dotnet20/root/usr/lib64:/opt/rh/rh-nodejs6/root/usr/lib64:$LD_LIBRARY_PATH

# Run container by default as user with id 1001 (default)
USER 1001

# Set the default CMD to print the usage of the language image.
CMD /usr/libexec/s2i/usage
