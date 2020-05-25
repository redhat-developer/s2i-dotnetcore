FROM jenkins/core/there

USER 0
COPY ./contrib/jenkins/configuration $JENKINS_REF_HOME

RUN set -x && \
    chgrp -R 0 $JENKINS_REF_HOME && \
    chmod -R 644 $JENKINS_REF_HOME && \
    chmod -R g+rwX $JENKINS_REF_HOME

USER 1001
