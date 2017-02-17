FROM openshift/base-centos7
# Dockerfile for a database backup pod.

# install PostgreSQL client programs
RUN yum -y install postgresql

# install cron
RUN yum -y install cronie
CMD /usr/sbin/crond 

# setup the SQL backup process




