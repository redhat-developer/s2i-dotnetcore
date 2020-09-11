#!/bin/bash

cat <<EOF
This is a runtime image for .NET ${DOTNET_CORE_VERSION}.

See the documentation at https://github.com/redhat-developer/s2i-dotnetcore/tree/master/${DOTNET_CORE_VERSION}/runtime.

This image can also be used as an S2I image for pre-compiled applications. Run 's2i usage <image>' for more information.
EOF
