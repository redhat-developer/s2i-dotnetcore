Schoolbus Inspection Tracking System
======================

Backups
----------------

Deployment / Configuration
----------------
The OpenShift Deployment Template for this application will automatically deploy the Backup app.  Here is a map of the environment variables that are required by the Backup app:

| Name | Purpose |
| ---- | ------- |
| DATABASE_SERVICE_NAME | hostname for the database to backup |
| POSTGRESQL_USER | database user for the backup |
| POSTGRESQL_PASSWORD | database password for the backup |
| POSTGRESQL_DATABASE | database to backup | 
| BACKUP_DIR | directory to store the backups |

Typically BACKUP_DIR is set to a location that has persistent storage.

Backup
------
The purpose of the backup app is to do automatic backups.  Simply Deploy the Backup app to do daily backups.  Viewing the Logs for the Backup App will show a record of backups that have been completed.

The Backup app has the following sequence of operation:

1. Cull backups older than 10 days
2. Create a directory that will be used to store the backup.
3. Use the `pg_dump` and `gzip` commands to make a backup.
4. Sleep for a day and repeat

Restore
-------
Prior to a database restore, all open connections to the database will need to be closed.

1. Shut down all Apps that use the database connection
	1. This also is necessary as the Apps will need to load data from the restored backup
2. In SBI this is **server**, **ccw**
3. It is recommended that you also shut down **frontend**  so that users know the application is unavailable while the database restore is underway.
4. You may also need to restart the **postgres** pod as a quick way of closing any other database connections from users using port forward or rsh to directly connect to the database.
5. Open a command prompt connection to OpenShift using `oc login` with parameters appropriate for your OpenShift host.
6. Change to the OpenShift project containing the Backup App `oc project <Project Name>`
7. List pods using `oc get pods`
8. Open a remote shell connection to the **postgresql** pod. `oc rsh <Postgresql Pod Name>`
9. Run `psql` 
10.  Execute `drop <database name>;` to drop the database.  If any connections are open you will need to close them before doing this step, otherwise it will fail.
11.  Execute `create <database name>;` to create the database.
12.  Close psql with `\q`
13.  Open a psql connection to the newly created database with `psql <database name>`
14.  Perform post create tasks
	1.  Grant appropriate access to database users (as they lose access when the database is dropped)		
		1.  You can use `/du` from the psql prompt to list users
		2.  Use the following command to grant all to the App's database user.  This is necessary so the App's database user can properly create the database objects required by the application
			1.  `GRANT ALL ON DATABASE <Database Name> TO "<App Database User>"`;
			2.  The quotes are important if the username contains upper case
		3.  Use the following command to grant special users read only access.
			1.  `GRANT SELECT ON ALL TABLES IN SCHEMA public TO "<READ ONLY USER>";`
			2.  There may be multiple read only users that need to be configured
15.  Exit psql with `\q`
16.  Exit rsh with `exit`
17.  Execute `oc rsh <Backup Pod Name>` to remote shell into the backup app pod
18.  Change to the bash shell by entering `bash`
19.  Change to the directory containing the backup you wish to restore.
20.  Execute the following bash commands:
	1.  `PGPASSWORD=$POSTGRESQL_PASSWORD`
	2.	`export PGPASSWORD`
21.  Execute `gunzip -c <filename> | psql -h "$DATABASE_SERVICE_NAME" -U "$POSTGRESQL_USER" "$POSTGRESQL_DATABASE" "$POSTGRESQL_DATABASE"`
22.  Verify that the database restore worked
	1.  `psql -h "$DATABASE_SERVICE_NAME" -U "$POSTGRESQL_USER" "$POSTGRESQL_DATABASE"`
	2.  `\d`
	3.  Verify that application tables are shown
	3.  `SELECT * FROM <TABLE NAME>;` where TABLE NAME is a table in the database that should contain data.
	4.  Verify data is shown
	5.  `\q`
23.  Exit remote shell
24.  Start the Server app and wait for it to finish starting up.  View the logs for the Server app to verify there were no startup issues.
25.  Start the CCW app, and view the logs for the CCW app to verify there were no startup issues.
26.  Start the FrontEnd app.
27.  Verify full application functionality. 