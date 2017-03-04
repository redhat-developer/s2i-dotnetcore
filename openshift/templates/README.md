Schoolbus Inspection Tracking System
======================

OpenShift
----------------

Environment Variables
--------------------

The following environment variables are used by the application:

| Environment Variable | Purpose | Example | Notes |
| ---------------------| ------- | ------- | ----- |
| DATABASE_SERVICE_NAME | Database service | postgresql | set to localhost for local development |
| POSTGRESQL_USER | PGSQL User | test | Must have enough access to create tables |
| POSTGRESQL_PASSWORD | PGSQL User's Password | test | |
| POSTGRESQL_DATABASE | Database name | schoolbus | |
| UserInitializationFile | Location of user seed data | /secrets/users.json | Json format following the User model definition |
| DistrictInitializationFile | Location of District seed data | /secrets/districts.json | Json format following the District model definition |
| RegionInitializationFile | Location of Region seed data | /secrets/regions.json | Json format following the Region model definition |
| CCWJurisdictionInitializationFile | Location of CCW Jurisdiction seed data | /secrets/ccwjurisdictions.json | Json format following the CCW Jurisdiction model definition |
| CCW_SERVICE_NAME | CCW microservice location | http://ccw:8080 | |
| PDF_SERVICE_NAME | PDF microservice location | http://pdf:8080 | |
| ASPNETCORE_ENVIRONMENT | Type of deployment | Development | Set to other Production (or anything other than Development) to disable development features such as user visible stack traces. |