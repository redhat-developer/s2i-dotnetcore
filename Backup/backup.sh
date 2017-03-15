#!/bin/bash

while true; do

# first cull backups older than 10 days.
find $FINAL_BACKUP_DIR"*" -type d -ctime +10 | xargs rm -rf

FINAL_BACKUP_DIR=$BACKUP_DIR"`date +\%Y-\%m-\%d-%H`/"
DBFILE=$FINAL_BACKUP_DIR"$POSTGRESQL_DATABASE`date +\%Y-\%m-\%d-%H-%M`"
echo "Making backup directory in $FINAL_BACKUP_DIR"
 
if ! mkdir -p $FINAL_BACKUP_DIR; then
	echo "Cannot create backup directory in $FINAL_BACKUP_DIR." 1>&2
	exit 1;
fi;

PGPASSWORD=$POSTGRESQL_PASSWORD
export PGPASSWORD

if ! /opt/rh/rh-postgresql94/root/usr/bin/pg_dump -Fp -h "$DATABASE_SERVICE_NAME" -U "$POSTGRESQL_USER" "$POSTGRESQL_DATABASE" | gzip > $DBFILE.sql.gz.in_progress; then
	echo "[!!ERROR!!] Failed to backup database $POSTGRESQL_DATABASE" 
else
	mv $DBFILE.sql.gz.in_progress $DBFILE.sql.gz
	echo "Database backup written to $DBFILE.sql.gz"
fi;

# 24 hrs
sleep 1d

done