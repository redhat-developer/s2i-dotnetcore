FROM centos:7
# This image provides a .NET Core 3.0 environment you can use to run your .NET
# applications.

EXPOSE 8080

ENV HOME=/opt/app-root \
    PATH=/opt/app-root/bin:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin \
    DOTNET_APP_PATH=/opt/app-root/app \
    DOTNET_DATA_PATH=/opt/app-root/data \
    DOTNET_DEFAULT_CMD=default-cmd.sh \
    DOTNET_CORE_VERSION=3.0 \
    DOTNET_FRAMEWORK=netcoreapp3.0 \
# Microsoft's images set this to enable detecting when an app is running in a container.
    DOTNET_RUNNING_IN_CONTAINER=true \
    DOTNET_SSL_CERT_DIR=/opt/app-root/ssl_dir

LABEL io.k8s.description="Platform for running .NET Core 3.0 applications" \
      io.k8s.display-name=".NET Core 3.0" \
      io.openshift.tags="runtime,.net,dotnet,dotnetcore,rh-dotnet30-runtime" \
      io.openshift.expose-services="8080:http" \
      io.openshift.s2i.scripts-url=image:///usr/libexec/s2i \
      io.s2i.scripts-url=image:///usr/libexec/s2i

# Labels consumed by Red Hat build service
LABEL name="dotnet/dotnet-30-runtime-centos7" \
      com.redhat.component="rh-dotnet30-runtime-container" \
      version="3.0" \
      release="1" \
      architecture="x86_64"

# Copy the S2I scripts from the specific language image to $STI_SCRIPTS_PATH.
COPY ./s2i/bin/ /usr/libexec/s2i

# Don't download/extract docs for nuget packages
ENV NUGET_XMLDOC_MODE=skip

# Don't do initially populate of package cache
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

## By default, ASP.NET Core runs on port 5000. We configure it to match
## the container port.
ENV ASPNETCORE_URLS=http://*:8080

# Each language image can have 'contrib' a directory with extra files needed to
# run and build the applications.
COPY ./contrib/ /opt/app-root

COPY ./root/usr/bin /usr/bin

# TODO: remove Microsoft binaries
RUN curl https://download.visualstudio.microsoft.com/download/pr/498b8b41-7626-435e-bea8-878c39ccbbf3/c8df08e881d1bcf9a49a9ff5367090cc/dotnet-sdk-3.0.100-preview9-014004-linux-x64.tar.gz -o /tmp/dotnet-sdk.tar.gz && \
    mkdir ~/dotnet-preview && \
    tar xf /tmp/dotnet-sdk.tar.gz -C ~/dotnet-preview

# TODO: update INSTALL_PKGS (2.2 to 3.0)
RUN yum install -y centos-release-dotnet && \
    INSTALL_PKGS="rh-dotnet22-dotnet-runtime-2.2 nss_wrapper tar unzip" && \
    yum install -y --setopt=tsflags=nodocs $INSTALL_PKGS && \
    rpm -V $INSTALL_PKGS && \
    yum clean all -y && \
# yum cache files may still exist (and quite large in size)
    rm -rf /var/cache/yum/*

# TODO: updated ENABLED_COLLECTIONS
# Get prefix path and path to scripts rather than hard-code them in scripts
ENV CONTAINER_SCRIPTS_PATH=/opt/app-root \
    ENABLED_COLLECTIONS="rh-dotnet22"

# When bash is started non-interactively, to run a shell script, for example it
# looks for this variable and source the content of this file. This will enable
# the SCL for all scripts without need to do 'scl enable'.
ENV BASH_ENV=${CONTAINER_SCRIPTS_PATH}/etc/scl_enable \
    ENV=${CONTAINER_SCRIPTS_PATH}/etc/scl_enable \
    PROMPT_COMMAND=". ${CONTAINER_SCRIPTS_PATH}/etc/scl_enable"

# Add default user
RUN mkdir -p ${DOTNET_APP_PATH} ${DOTNET_DATA_PATH} && \
    useradd -u 1001 -r -g 0 -d ${HOME} -s /sbin/nologin \
      -c "Default Application User" default

WORKDIR ${DOTNET_APP_PATH}
COPY default-cmd.sh ${DOTNET_DEFAULT_CMD}
CMD "./${DOTNET_DEFAULT_CMD}"

# In order to drop the root user, we have to make some directories world
# writable as OpenShift default security model is to run the container under
# random UID.
RUN chown -R 1001:0 /opt/app-root && fix-permissions /opt/app-root

ENTRYPOINT [ "container-entrypoint" ]

# Run container by default as user with id 1001 (default)
USER 1001
