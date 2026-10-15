-- Executed successfully with approval on ISPADMIN2, 2026-10-14.
-- Retained as execution evidence; do not rerun against the existing test database.
-- Use sqlcmd -S ISPADMIN2 -E -d master -b -i <this file>, or SSMS SQLCMD mode.
:ON ERROR EXIT
USE [master];
SET NOCOUNT ON;
IF CONVERT(nvarchar(128), SERVERPROPERTY('MachineName')) <> N'ISPADMIN2'
BEGIN
    ;THROW 50000, 'Wrong machine: restore is restricted to ISPADMIN2.', 1;
END;
IF DB_ID(N'ISPDATA_RestoreTest') IS NOT NULL
BEGIN
    ;THROW 50001, 'Test database exists; no overwrite is authorized.', 1;
END;
IF EXISTS (SELECT 1 FROM sys.master_files WHERE physical_name IN
    (N'D:\Ispadmin2-Ispdata-Test\ISPDATA_RestoreTest.mdf',
     N'D:\Ispadmin2-Ispdata-Test\ISPDATA_RestoreTest_log.ldf'))
BEGIN
    ;THROW 50002, 'A destination is registered to an existing database.', 1;
END;
DECLARE @FileCheck TABLE (FileExists int, FileIsDirectory int, ParentDirectoryExists int);
INSERT INTO @FileCheck EXEC master.dbo.xp_fileexist N'D:\Ispadmin2-Ispdata-Test\ISPDATA_RestoreTest.mdf';
INSERT INTO @FileCheck EXEC master.dbo.xp_fileexist N'D:\Ispadmin2-Ispdata-Test\ISPDATA_RestoreTest_log.ldf';
IF (SELECT COUNT(*) FROM @FileCheck) <> 2
   OR EXISTS (SELECT 1 FROM @FileCheck WHERE FileExists <> 0 OR FileIsDirectory <> 0 OR ParentDirectoryExists <> 1)
BEGIN
    ;THROW 50003, 'A target file exists or its parent directory is unavailable.', 1;
END;

BEGIN TRY
    RESTORE DATABASE [ISPDATA_RestoreTest]
      FROM DISK = N'\\ibn-server\ExternalHdBackup\ISPDataBackup\ISPData_20261014.BAK'
      WITH FILE = 1, CHECKSUM, NORECOVERY,
      MOVE N'ISPDATA' TO N'D:\Ispadmin2-Ispdata-Test\ISPDATA_RestoreTest.mdf',
      MOVE N'ISPDATA_log' TO N'D:\Ispadmin2-Ispdata-Test\ISPDATA_RestoreTest_log.ldf',
      STATS = 10;

    RESTORE LOG [ISPDATA_RestoreTest]
      FROM DISK = N'\\ibn-server\ExternalHdBackup\ISPDataBackup\Logs\ISPData_Log_20261014_011500.trn'
      WITH FILE = 1, CHECKSUM, NORECOVERY;
    RESTORE LOG [ISPDATA_RestoreTest]
      FROM DISK = N'\\ibn-server\ExternalHdBackup\ISPDataBackup\Logs\ISPData_Log_20261014_013000.trn'
      WITH FILE = 1, CHECKSUM, NORECOVERY;
    RESTORE LOG [ISPDATA_RestoreTest]
      FROM DISK = N'\\ibn-server\ExternalHdBackup\ISPDataBackup\Logs\ISPData_Log_20261014_014500.trn'
      WITH FILE = 1, CHECKSUM, RECOVERY;

    SELECT name, state_desc, recovery_model_desc, compatibility_level
    FROM sys.databases WHERE name = N'ISPDATA_RestoreTest';
    -- Resolve the database only after RESTORE has created it.
    EXEC(N'USE [ISPDATA_RestoreTest];
        SELECT name, type_desc, physical_name,
               CAST(size / 128.0 AS decimal(18,2)) AS SizeMB
        FROM sys.database_files;');
    DBCC CHECKDB(N'ISPDATA_RestoreTest') WITH NO_INFOMSGS, ALL_ERRORMSGS;
    SELECT TOP (4) restore_date, destination_database_name, restore_type,
           backup_set_id, recovery, replace
    FROM msdb.dbo.restorehistory
    WHERE destination_database_name = N'ISPDATA_RestoreTest'
    ORDER BY restore_history_id DESC;
END TRY
BEGIN CATCH
    -- Retain the incomplete test database for diagnosis; do not drop, overwrite or restart automatically.
    THROW;
END CATCH;
