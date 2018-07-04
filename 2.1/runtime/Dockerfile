FROM centos:7
# This image provides a .NET Core 2.1 environment you can use to run your .NET
# applications.

EXPOSE 8080

ENV HOME=/opt/app-root \
    PATH=/opt/app-root/bin:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin \
    DOTNET_APP_PATH=/opt/app-root/app \
    DOTNET_DEFAULT_CMD=default-cmd.sh \
    DOTNET_CORE_VERSION=2.1 \
    DOTNET_FRAMEWORK=netcoreapp2.1 \
# Microsoft's images set this to enable detecting when an app is running in a container.
    DOTNET_RUNNING_IN_CONTAINER=true \
    DOTNET_SSL_CERT_DIR=/opt/app-root/ssl_dir

LABEL io.k8s.description="Platform for running .NET Core 2.1 applications" \
      io.k8s.display-name=".NET Core 2.1" \
      io.openshift.tags="runtime,.net,dotnet,dotnetcore,rh-dotnet21-runtime" \
      io.openshift.expose-services="8080:http"

# Labels consumed by Red Hat build service
LABEL name="dotnet/dotnet-21-runtime-centos7" \
      com.redhat.component="rh-dotnet21-runtime-container" \
      version="2.1" \
      release="1" \
      architecture="x86_64"

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

RUN yum install -y centos-release-dotnet && \
    INSTALL_PKGS="rh-dotnet21-dotnet-runtime-2.1 nss_wrapper tar unzip" && \
    yum install -y --setopt=tsflags=nodocs $INSTALL_PKGS && \
    rpm -V $INSTALL_PKGS && \
    yum clean all -y && \
# yum cache files may still exist (and quite large in size)
    rm -rf /var/cache/yum/*

# Get prefix path and path to scripts rather than hard-code them in scripts
ENV CONTAINER_SCRIPTS_PATH=/opt/app-root \
    ENABLED_COLLECTIONS="rh-dotnet21"

# When bash is started non-interactively, to run a shell script, for example it
# looks for this variable and source the content of this file. This will enable
# the SCL for all scripts without need to do 'scl enable'.
ENV BASH_ENV=${CONTAINER_SCRIPTS_PATH}/etc/scl_enable \
    ENV=${CONTAINER_SCRIPTS_PATH}/etc/scl_enable \
    PROMPT_COMMAND=". ${CONTAINER_SCRIPTS_PATH}/etc/scl_enable"

# Add default user
RUN mkdir -p ${DOTNET_APP_PATH} && \
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
