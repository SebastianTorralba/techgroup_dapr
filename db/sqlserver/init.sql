IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'academy_scheduler')
BEGIN
    CREATE DATABASE academy_scheduler;
END
