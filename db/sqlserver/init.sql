IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'academy_manager')
BEGIN
    CREATE DATABASE academy_manager;
END
