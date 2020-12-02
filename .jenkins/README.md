# Overview

For running locally, it is recommended to use locally installed npm/node. The command snippets provide bellow assume you have npm/node installed. Also, the command lines are provided as subshell (within parthnesis) so that it will work regardless of of your current shell work directory, as long as it is within the git working directory.

For running from a Jenkinsfile, it is recommened to replace `npm` with the provided `npmw` as it will download and install node/npm using `nvm`.

Before running in any of your projects ensure that you have created proper GitHub and Slave User secrets below:
template.<Your Jenkins>-github
template.<Your Jenkins>-slave-user

Github Webhooks are only created during the PROD deployment.

Windows users can just do the `cd` manually to the root folder of their repo and remove `$(git rev-parse --show-toplevel)/` from the commands below.

# Build
```
( cd "$(git rev-parse --show-toplevel)/.jenkins/.pipeline" && npm run build -- --pr=0 --dev-mode=true )
```
Where:
`--pr=0` is used to set the pull request number to build from.
`--dev-mode=true` is used to indicate that the build will actually take the files in the current working directory, as opposed to a fresh `git clone`

# Deploy to DEV
```
( cd "$(git rev-parse --show-toplevel)/.jenkins/.pipeline" && npm run deploy -- --pr=0 --env=dev )
```

# Deploy to PROD
```
( cd "$(git rev-parse --show-toplevel)/.jenkins/.pipeline" && npm run deploy -- --pr=0 --env=prod )
```

# Clean
The clean script can run against each persistent environment, starting from `build`.
```
( cd "$(git rev-parse --show-toplevel)/.jenkins/.pipeline" && npm run clean -- --pr=0 --env=build )
( cd "$(git rev-parse --show-toplevel)/.jenkins/.pipeline" && npm run clean -- --pr=0 --env=dev )
```

*Warning*: Do *NOT* run against `test` or `prod`. It will cause *PERMANENT* deletion of all objects including `PVC`! be warned!
