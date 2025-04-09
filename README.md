![img](https://img.shields.io/badge/Lifecycle-Stable-97ca00)

# Schoolbus Inspection Tracking System

## Introduction

The approximately 3000 school buses in BC are subject to mandatory inspections under the Motor Vehicle Act Regulations. The CVSA eForm is used to record the details of school bus inspection and the data is stored in the RIP (Roadside Inspection Program) database.

The School Bus Program encompasses three major processes:

- Applying for and issuing School Bus permits;
- Scheduling and performing vehicle inspections; and
- Cancelling and/or suspending permits.

The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from systems of record, e.g. ICBC, NSC), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.

School bus permitting and inspection scheduling was previously tracked in the Automated Vehicle Inspection System on the IMS mainframe.

The application is being developed as an open source solution.

## Prerequisites

- .Net 7
- Node.JS v13.7.0 or newer
- PostgreSQL 16

## Dependencies

- Working KeyCloak Realm with BC Gov IDIR
- IDIR service account with access to CCW (Common Carrier Web Service)

## Local Development

### Configuration

Use the following steps to configure the local development environment

1. Clone the repository

   ```
   git clone https://github.com/bcgov/schoolbus.git
   ```

2. Create a local postgres database that you will use for development purposes

3. Restore latest backup of initial development database

   - Create the first admin user in `SBI_USER` table with the `System Administrator` role in the `SBI_USER_ROLE` table

4. Configure API Server settings

   - Copy `Server\SchoolBusAPI/appsettigns.json` to `Server\SchoolBusAPI/appsettigns.Development.json`
   - Update the placeholder values with real values, eg., replace the `<app-id>` with actual KeyCloak client id in the `{ "JWT": { "Audience": "<app-id>" } }` field
   - Update the connection string to match the database
   - Make note of or update the port for the API Server in Visual Studio or through the `properties/launchSettings.json` file.

5. Configure the React development settings

   - Create the `client/.env.development.local` file and add the following content

   ```
    # use port value from step 3
    REACT_APP_API_HOST=http://localhost:<api-port>

    REACT_APP_SSO_HOST=https://dev.oidc.gov.bc.ca/auth
    REACT_APP_SSO_CLIENT=<client-id>
    REACT_APP_SSO_REALM=<realm-id>

    # Optional, default port is 3000
    # PORT=3001
   ```

   - Replace the placeholder values

### Run

Use the following steps to run the local development environment

1. Run the API Server

   - F5 in Visual Studio
   - Or from console

   ```
   cd Server\SchoolBusAPI
   dotnet restore
   dotnet build
   dotnet run
   ```

2. Run the React frontend
   ```
   cd client
   npm install
   npm start
   ```

## OpenShift Deployment

Refer to [this document](openshift/README.md) for OpenShift Deployment and Pipeline related topics

## Contribution

---

Please report any [issues](https://github.com/bcgov/schoolbus/issues).

[Pull requests](https://github.com/bcgov/schoolbus/pulls) are always welcome.

If you would like to contribute, please see our [contributing](CONTRIBUTING.md) guidelines.

Please note that this project is released with a [Contributor Code of Conduct](CODE_OF_CONDUCT.md). By participating in this project you agree to abide by its terms.

## License

    Copyright 2017 Province of British Columbia

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.

## Maintenance

This repository is maintained by [BC Ministry of Transportation](http://www.th.gov.bc.ca/).
Click [here](https://github.com/orgs/bcgov/teams/tran/repositories) for a complete list of our repositories on GitHub.