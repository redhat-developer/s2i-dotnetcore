FROM node:13.7-alpine3.11 AS builder
LABEL maintainer="neal.li@gov.bc.ca"

COPY . ./src

RUN cd ./src && npm ci && \
    npm run build


FROM docker-registry.default.svc:5000/tran-schoolbus-tools/nginx-116-rhel8:1

COPY --from=builder /src/build/. /tmp/src
COPY --from=builder /src/nginx-start/. /tmp/src/nginx-start
COPY --from=builder /src/nginx.conf.tmpl /tmp/src/nginx.conf.tmpl

RUN $STI_SCRIPTS_PATH/assemble

CMD $STI_SCRIPTS_PATH/run