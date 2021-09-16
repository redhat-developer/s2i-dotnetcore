FROM image-registry.openshift-image-registry.svc:5000/e82e9a-tools/node:1 AS builder
LABEL maintainer="young-jin.chung@gov.bc.ca"

COPY . ./src

RUN cd ./src && \
    apk add --no-cache --virtual .gyp \
    python \
    make \
    g++ && \
    npm ci && \
    npm run build

FROM image-registry.openshift-image-registry.svc:5000/e82e9a-tools/nginx-116-rhel8:1

COPY --from=builder /src/build/. /tmp/src
COPY --from=builder /src/nginx-start/. /tmp/src/nginx-start
COPY --from=builder /src/nginx.conf.tmpl /tmp/src/nginx.conf.tmpl

RUN $STI_SCRIPTS_PATH/assemble

CMD $STI_SCRIPTS_PATH/run