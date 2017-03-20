Postgres Backups in OpenShift
----------------
An OpenShift Deployment called "backup" in the Schoolbus projects (Dev, Test, Prod) runs the backups of the Postgres database. The following are the instructions for running the backups and a restore.

Deployment / Configuration
----------------
The OpenShift Deployment Template for this application will automatically deploy the Backup app as described below.

The following environment variables are used by the Backup app.

**NOTE**: THESE ENVIRONMENT VARIABLES MUST MATCH THE VARIABLES USED BY THE postgresql DEPLOYMENT DESCRIPTOR.

| Name | Purpose |
| ---- | ------- |
| DATABASE_SERVICE_NAME | hostname for the database to backup |
| POSTGRESQL_USER | database user for the backup |
| POSTGRESQL_PASSWORD | database password for the backup |
| POSTGRESQL_DATABASE | database to backup | 
| BACKUP_DIR | directory to store the backups |

The BACKUP_DIR must be set to a location that has persistent storage.

Backup
------
The purpose of the backup app is to do automatic backups.  Deploy the Backup app to do daily backups.  Viewing the Logs for the Backup App will show a record of backups that have been completed.

The Backup app performs the following sequence of operations:

1. Cull backups older than 10 days
2. Create a directory that will be used to store the backup.
3. Use the `pg_dump` and `gzip` commands to make a backup.
4. Sleep for a day and repeat

Note that we are just using a simple "sleep" to run the backup periodically. More elegent solutions were looked at briefly, but there was not a lot of time, so OpenShift Scheduled Jobs, cron and so on are not used. With some more effort they likely could be made to work.

A separate pod is used vs. having the backups run from the Postgres Pod for fault tolerent purposes - to keep the backups separate from the database storage.  We don't want to, for example, lose the storage of the database, or have the databaes and backups storage fill up, and lose both the database and the backups.

Immediate Backup:
-----------------
To execute a backup right now, check the logs of the Backup pod to make sure a backup isn't run right now (pretty unlikely...), and then restart the "backup" using OpenShift "deploy" capabilities.

Restore
-------
These steps perform a restore of a backup.

1. Log into the OpenShift Console and log into OpenShift on the command shell window.
   1. The instructions here use a mix of the console and command line, but all could be done from a command shell using "oc" commands. We have not written a script for this as if a backup is needed, something has gone seriously wrong, and compensating steps may be needed for which the script would not account.
2. Scale to 0 all Apps that use the database connection.
   1. This is necessary as the Apps will need to restart to pull data from the restored backup.
   2. In Schoolbus this is **server**, **ccw**; for hets this is just **server**
   3. It is recommended that you also scale down to 0 **frontend**  so that users know the application is unavailable while the database restore is underway.
       1. A nice addition to this would be a user-friendly "This application is offline" message - not yet implemented.
3. Restart the **postgres** pod as a quick way of closing any other database connections from users using port forward or that have rsh'd to directly connect to the database.
4. Open an rsh into the Postgres pod.
   1. Open a command prompt connection to OpenShift using `oc login` with parameters appropriate for your OpenShift host.
   2. Change to the OpenShift project containing the Backup App `oc project <Project Name>`
   3. List pods using `oc get pods`
   4. Open a remote shell connection to the **postgresql** pod. `oc rsh <Postgresql Pod Name>`
5. In the rsh run `psql` 
6. Get the name of the database and the Application user - you need to know these for later steps.
   1. Run the shell command: `echo Database Name: $POSTGRESQL_DATABASE`
   2. Run the shell command: `echo App User: $POSTGRESQL_USER`
7. Execute `drop <database name>;` to drop the database (database name from above).
8. Execute `create <database name>;` to create a new instance of the database with the same name as the old one.
9. Close psql with `\q`
10. Open a psql connection to the newly created database with `psql <database name>`
11. Perform a series of post create tasks, as follows
    1. Grant appropriate access to database users (as they lose access when the database is dropped)		
        1. Use `\du` from the psql prompt to list users
        2. Execute the following command to grant all to the App's database user - the one with the same name echoed above.  This is necessary so the App's database user can properly create the database objects required by the application
            1. `GRANT ALL ON DATABASE <Database Name> TO "<App Database User>";`
            2. The quotes are required if the username contains upper case
    2. Use the following command to grant special users read only access - any other users other than the APP and the named "postgres".
        1. `GRANT SELECT ON ALL TABLES IN SCHEMA public TO "<READ ONLY USER>";`
        2. There may be multiple read only users that need to be configured
        3. If users have been set up with other grants, set them up as well.
12. Exit psql with `\q`
13. Exit rsh with `exit` back to your local command line
14. Execute `oc rsh <Backup Pod Name>` to remote shell into the backup app pod
15. Change to the bash shell by entering `bash`
16. Change to the directory containing the backup you wish to restore and find the name of the file.
17. Execute the following bash commands:
    1. `PGPASSWORD=$POSTGRESQL_PASSWORD`
    2. `export PGPASSWORD`
    3. `gunzip -c <filename> | psql -h "$DATABASE_SERVICE_NAME" -U "$POSTGRESQL_USER" "$POSTGRESQL_DATABASE" "$POSTGRESQL_DATABASE"`
       1. Ignore the "no privileges revoked" warnings at the end of the process.
18. Verify that the database restore worked
    1. `psql -h "$DATABASE_SERVICE_NAME" -U "$POSTGRESQL_USER" "$POSTGRESQL_DATABASE"`
    2. `\d`
    3. Verify that application tables are listed. Query a table - e.g the USER table:
    4. `SELECT * FROM "SBI_USER";` - you can look at other tables if you want.
    5. Verify data is shown.
    6. `\q`
20. Exit remote shells back to your local commmand line
21. From the Openshift Console restart the app:
    1. Scale up (or redeploy) the Server app and wait for it to finish starting up.  View the logs for the Server app to verify there were no startup issues.
    2. Scale up the CCW app, and view the logs for the CCW app to verify there were no startup issues.
    3. Scale up the FrontEnd app.
22.  Verify full application functionality.

Done!
