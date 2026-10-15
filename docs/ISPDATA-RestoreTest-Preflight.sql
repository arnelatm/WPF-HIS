-- Read-only preflight. Run in SSMS connected to ISPADMIN2 with Windows authentication.
-- Does not create a database, copy files, restore a database/log, or alter backups.
-- SQL Server 2014-compatible. Results contain only server/storage/backup metadata.
-- The UNC share mapping is provisional: headers must confirm ISPDATA and the expected chain.
-- Stop on any error. Do not substitute a production instance or change these identity guards.
USE [master];
SET NOCOUNT ON;

IF CONVERT(nvarchar(128), SERVERPROPERTY('MachineName')) <> N'ISPADMIN2'
BEGIN
    ;THROW 50000, 'Wrong machine: this preflight is restricted to ISPADMIN2.', 1;
END;
IF CONVERT(int, SERVERPROPERTY('ProductMajorVersion')) < 12
BEGIN
    ;THROW 50001, 'The target engine is older than the SQL Server 2014 source.', 1;
END;
IF DB_ID(N'ISPDATA_RestoreTest') IS NOT NULL
BEGIN
    ;THROW 50002, 'ISPDATA_RestoreTest already exists. Choose and review another name; do not overwrite it.', 1;
END;

SELECT @@SERVERNAME AS RegisteredServerName,
       SERVERPROPERTY('MachineName') AS MachineName,
       SERVERPROPERTY('ServerName') AS ConnectedInstance,
       SERVERPROPERTY('InstanceName') AS InstanceName,
       SERVERPROPERTY('ProductVersion') AS ProductVersion,
       SERVERPROPERTY('Edition') AS Edition,
       SERVERPROPERTY('InstanceDefaultDataPath') AS DefaultDataPath,
       SERVERPROPERTY('InstanceDefaultLogPath') AS DefaultLogPath,
       SYSDATETIMEOFFSET() AS TargetLocalTime;

SELECT servicename, status_desc, service_account
FROM sys.dm_server_services;

-- Known existing volumes. Default folders may be on other volumes: confirm separately.
SELECT DISTINCT v.volume_mount_point, v.logical_volume_name,
       CAST(v.total_bytes / 1073741824.0 AS decimal(18,2)) AS TotalGB,
       CAST(v.available_bytes / 1073741824.0 AS decimal(18,2)) AS AvailableGB
FROM sys.master_files AS f
CROSS APPLY sys.dm_os_volume_stats(f.database_id, f.file_id) AS v;

DECLARE @DataFolder nvarchar(4000) = CONVERT(nvarchar(4000), SERVERPROPERTY('InstanceDefaultDataPath'));
DECLARE @LogFolder nvarchar(4000) = CONVERT(nvarchar(4000), SERVERPROPERTY('InstanceDefaultLogPath'));
IF NULLIF(@DataFolder, N'') IS NULL OR NULLIF(@LogFolder, N'') IS NULL
BEGIN
    ;THROW 50003, 'Default paths are unavailable. Obtain explicit test-only destination paths.', 1;
END;
IF RIGHT(@DataFolder, 1) <> N'\' SET @DataFolder = @DataFolder + N'\';
IF RIGHT(@LogFolder, 1) <> N'\' SET @LogFolder = @LogFolder + N'\';
-- The preflight confirmed ample space on D: and this existing test folder.
DECLARE @DataFile nvarchar(4000) = N'D:\Ispadmin2-Ispdata-Test\ISPDATA_RestoreTest.mdf';
DECLARE @LogFile nvarchar(4000) = N'D:\Ispadmin2-Ispdata-Test\ISPDATA_RestoreTest_log.ldf';

SELECT N'ISPDATA_RestoreTest' AS ProposedDatabase,
       @DataFile AS ProposedDataFile, @LogFile AS ProposedLogFile;
SELECT DB_NAME(database_id) AS ExistingDatabase, name, physical_name
FROM sys.master_files
WHERE physical_name IN (@DataFile, @LogFile);

-- Read-only filesystem checks from the database engine account.
-- Target files must be absent and parent directories present.
-- These checks alone do not prove directory writability or network-copy permission.
EXEC master.dbo.xp_fileexist @DataFile;
EXEC master.dbo.xp_fileexist @LogFile;

-- Actual backup headers establish identity, FILE position, fork and LSN coverage.
-- The full backup predates the manual afternoon log backups; those files are not needed here.
RESTORE HEADERONLY FROM DISK = N'\\ibn-server\ExternalHdBackup\ISPDataBackup\ISPData_20261014.BAK';
RESTORE HEADERONLY FROM DISK = N'\\ibn-server\ExternalHdBackup\ISPDataBackup\Logs\ISPData_Log_20261014_011500.trn';
RESTORE HEADERONLY FROM DISK = N'\\ibn-server\ExternalHdBackup\ISPDataBackup\Logs\ISPData_Log_20261014_013000.trn';
RESTORE HEADERONLY FROM DISK = N'\\ibn-server\ExternalHdBackup\ISPDataBackup\Logs\ISPData_Log_20261014_014500.trn';

-- After inspecting full-backup headers, run FILELISTONLY separately with FILE = its Position.
-- Do not assume Position = 1 or that there are only two logical files.
-- Expected proposed sequence, not executed here:
-- full WITH MOVE for every logical file, NORECOVERY;
-- 01:15 LOG WITH NORECOVERY; 01:30 LOG WITH NORECOVERY; 01:45 LOG WITH RECOVERY.
-- Final commands require reviewed paths, disk capacity and user approval.
