#!/bin/bash

# Start the SQL Server
/opt/mssql/bin/sqlservr &

# Wait for SQL Server to start
echo "Waiting for SQL Server to start..."
sleep 30s

# Run the SQL script
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'Darp1234!' -d master -i init.sql

# Wait for SQL Server to start
sleep 10s

# Run the Node.js migration
npm run migrate
