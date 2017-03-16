FROM openshift/base-centos7
# Dockerfile for a database backup pod.

# install PostgreSQL client programs
RUN yum install -y centos-release-scl && \
    INSTALL_PKGS="rsync tar gettext bind-utils rh-postgresql94 gzip" && \
    yum -y --setopt=tsflags=nodocs install $INSTALL_PKGS && \
    rpm -V $INSTALL_PKGS && \
    yum clean all 

copy backup.sh /
RUN chmod -R a+rwx /backup.sh

RUN ln -s /opt/rh/rh-postgresql94/root/usr/lib64/libpq.so.rh-postgresql94-5  /usr/lib64/libpq.so.rh-postgresql94-5 
RUN ln -s /opt/rh/rh-postgresql94/root/usr/lib64/libpq.so.rh-postgresql94-5  /usr/lib/libpq.so.rh-postgresql94-5

CMD /backup.sh


