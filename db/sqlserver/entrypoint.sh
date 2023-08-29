#!/bin/bash

# Wait for SQL Server to be ready
until /opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P Dapr1234! -Q 'SELECT 1;' >/dev/null 2>&1; do
    echo "Waiting for SQL Server to be ready..."
    sleep 1
done

echo "SQL Server connected successfully."

# Run the SQL script
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P 'Dapr1234!' -d academy_manager -i init.sql

# Wait for SQL Server to start
sleep 10s

# Run the Node.js migration
npm run migrate
