# Database for Study Scheduler

This directory contains the database configuration for the Study Scheduler application. It uses Prisma as a database toolkit, and a PostgreSQL database for persistent storage.

## Prerequisites

- Docker installed on your system.
- Node.js 12.0+ and npm 6.0+ installed on your system.
- Prisma CLI installed on your system. You can install it using `npm install @prisma/cli --save-dev`.

## Setup for local development

1. Install dependencies:

   ```
   cd db
   npm install
   ```

2. Create .env inside the db folder:

   ```
   DATABASE_URL="postgresql://postgres:postgres@localhost:5432/academy_scheduler"
   SQLSERVER_URL="sqlserver://localhost:1433;databaseName=academy_scheduler;user=sa;password=Dapr1234!"
   ```

3. Generate Prisma Client:

   ```
   npx prisma generate
   ```

4. Run migrations to update the database schema:

   ```
   npx prisma migrate deploy
   ```

## How to run the migrations with Docker

1. Build and run the Docker containers:

   ```
   docker-compose up
   ```

2. This will run the migrations in a separate container, then exit once the migrations are complete.

## Directory structure

- `prisma` - This directory contains Prisma configuration and migration files.
- `package.json` - Defines npm dependencies and scripts.
- `schema.prisma` - The Prisma schema file that defines your database tables.
- `Dockerfile` - Dockerfile for building the database Docker image.
- `docker-compose.yml` - Docker Compose file for running the database and migrations containers.

## How to create new migrations

You can create a new migration by modifying `schema.prisma` and then running the following command:

`npx prisma migrate dev --name name_of_your_migration`

The `name_of_your_migration` should be a descriptive name for the changes you made to the schema. This will create a new directory under `prisma/migrations` with SQL files that represent the changes to the schema.
