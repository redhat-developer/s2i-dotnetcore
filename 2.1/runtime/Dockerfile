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
    DOTNET_RUNNING_IN_CONTAINER=true

LABEL io.k8s.description="Platform for running .NET Core 2.1 applications" \
      io.k8s.display-name=".NET Core 2.1" \
      io.openshift.tags="runtime,.net,dotnet,dotnetcore,rh-dotnet21-runtime" \
      io.openshift.expose-services="8080:http"

# Labels consumed by Red Hat build service
LABEL name="dotnet/dotnet-21-runtime-centos7" \
      com.redhat.component="rh-dotnet21-runtime-docker" \
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

# TODO: install 2.1 runtime
# The 'rm -rf /var/cache/yum' line is there to clean out orphaned yum cache files,
# which can be quite large in size.
RUN yum install -y centos-release-dotnet && \
    INSTALL_PKGS="rh-dotnet20-dotnet-runtime-2.0 nss_wrapper tar unzip" && \
    yum install -y --setopt=tsflags=nodocs $INSTALL_PKGS && \
    rpm -V $INSTALL_PKGS && \
    yum clean all -y && \
    rm -rf /var/cache/yum/*

# TODO: remove Microsoft binaries
RUN curl https://download.microsoft.com/download/3/7/C/37C0D2E3-2056-4F9A-A67C-14DEFBD70F06/dotnet-sdk-2.1.300-preview2-008530-linux-x64.tar.gz -o /tmp/dotnet-sdk.tar.gz && \
    mkdir ~/dotnet-preview2 && \
    tar xf /tmp/dotnet-sdk.tar.gz -C ~/dotnet-preview2 && \
    rm -rf ~/dotnet-preview2/shared/Microsoft.AspNetCore.*

# TODO: enable rh-dotnet21 scl
# Get prefix path and path to scripts rather than hard-code them in scripts
ENV CONTAINER_SCRIPTS_PATH=/opt/app-root \
    ENABLED_COLLECTIONS="rh-dotnet20"

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
