#!/bin/bash
set -e

# Start SQL Server
/opt/mssql/bin/sqlservr --accept-eula &

# Wait for SQL Server to start
echo "Waiting for SQL Server to start..."
sleep 30s

# Run the setup script to create the DB
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Darp1234!" -d master -i init.sql

# Wait for the SQL command to finish
wait $!
