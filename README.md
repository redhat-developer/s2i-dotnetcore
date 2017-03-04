Schoolbus Inspection Tracking System
======================

Introduction
----------------

This project is to replace the existing permitting and inspection scheduling functionality in AVIS such that the mainframe application can be retired.

Repository Map
--------------
- **ApiSpec**: The API Specification, in OpenAPI (Swagger) format.  This folder also includes a system to create the OpenAPI files from Excel format input, as well as test data.
- **CCW**: A microservice that provides a SOAP client to ICBC CCW data
- **Client**: The javascript source for the user interface
- **Common**: A library of common methods used by various components
- **FrontEnd**: The Front End server that hosts static content and proxies the API
- **Jenkins**: Jenkins configuration data
- **openshift**: OpenShift templates
- **PDF**: A microservice for PDF rendering
- **Server**: The API Server 

Installation
------------
This application is meant to be deployed to RedHat OpenShift version 3.  The full application will require 8 Cores of CPU and at least 8 GB of RAM, plus sufficient Persistent Volume storage for the database and configuration secrets.

Two OpenShift templates are provided, one for the build and one for the deploy.  Full details are here: [OpenShift]

**CCW Jurisdiction Changes**
In the event that CCW Jurisdiction changes occur, instructions are available at the following location to update the seed data for CCW Jurisdictions.  [CCW Jurisdiction Changes]

Developer Prerequisites
-----------------------

**Client**
- Node.js
- Text editor such as NetBeans

**Server**
- .Net Core SDK (.NET Core App 1.1 is used for all components)
- Node.js
- .NET Core IDE such as Visual Studio
- PostgreSQL 9.4 or newer

**DevOps**
- RedHat OpenShift tools
- Docker
- A familiarity with Jenkins

Development
-----------
**Client Code**
The client code is tested using a Node.js application.  Node.js is also used to build the client code into the deployable JavaScript application.

Run npm install from the Client directory to configure the Client build environment

The frameworks used for this application are React/Redux.
 
**API Services**

- Create a local postgres database that you will use for development purposes
- Edit the project launch settings such that the same [environment variables] set during deployment are set on your development environment
- Run the code in Development mode, which will allow you to get a Developer Token allowing the application to run outside of a SiteMinder environment.
- A developer token is obtained by going to the following url, where <UserId> is a valid SiteMinder UserId field in the database.
	- /api/authentication/dev/token?userid=<UserId>
- The MicroServices "CCW" and "PDF" require an instance of the "Server" component in order to be tested.  However you can run all three applications at once on the same computer, with each running on different TCP ports.  Configure the [Environment Variables] with appropriate settings for each service.

**SonarQube**

SonarQube is a code quality service that helps identify problem areas in code through static analysis.

A batch file is provided in the Server code directory that can be used to run SonarQube code analysis on the API Server code.

Before running this batch file, "sonar.bat", ensure that you have a valid SonarQube account (can be your GitHub account once registered with SonarQube.com) and that your SonarQube token is installed properly on your computer.  You will also need the SonarQube Scanner for C# to be installed on your local computer.

The file sonar.bat will start the SonarQube scanner, execute a build, and stop the scanner.  You may then go to the SonarQube.com website to view the results of the scan.

**Viewing the Database**

This application utilizes the [SchemaSpy] OpenShift image to provide an easy way for stakeholders to view the database schema.  The SchemaSpy component is a self contained schema viewer application that can be rapidly deployed to analyze the database structure and provide a website to review details of the database.

Contribution
------------

Please report any [issues](https://github.com/bcgov/schoolbus/issues).

[Pull requests](https://github.com/bcgov/schoolbus/pulls) are always welcome.

If you would like to contribute, please see our [contributing](CONTRIBUTING.md) guidelines.

Please note that this project is released with a [Contributor Code of Conduct](CODE_OF_CONDUCT.md). By participating in this project you agree to abide by its terms.

License
-------

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

Maintenance
-----------

This repository is maintained by [BC Ministry of Transportation](http://www.th.gov.bc.ca/).
Click [here](https://github.com/orgs/bcgov/teams/tran/repositories) for a complete list of our repositories on GitHub.

[environment variables]: linktoenvironmentvariableshere
[openshift]: openshiftinfo
[SchemaSpy]: schemaspy
[CCW Jurisdiction Changes]: ccwjurisdiction