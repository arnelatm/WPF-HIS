-- Read-only SQL Server 2014 Agent-step candidate. No job is created by this file.
-- A future monitoring job should run every 5 minutes and use existing failure notifications.
USE [master];
SET NOCOUNT ON;
IF CONVERT(nvarchar(128),SERVERPROPERTY('MachineName'))<>N'IBN-SERVER'
BEGIN
    ;THROW 51200, 'Unexpected machine; freshness check stopped.', 1;
END;
DECLARE @LastLog datetime,@LastFull datetime,@LogFile nvarchar(4000),@FullFile nvarchar(4000);
DECLARE @Family uniqueidentifier,@Fork uniqueidentifier;
SELECT @Family=family_guid,@Fork=recovery_fork_guid
FROM sys.database_recovery_status WHERE database_id=DB_ID(N'ISPDATA');
IF @Family IS NULL OR NOT EXISTS(SELECT 1 FROM sys.databases WHERE name=N'ISPDATA' AND state=0 AND recovery_model=1)
BEGIN
    ;THROW 51201, 'Expected ONLINE/FULL database identity unavailable.', 1;
END;
SELECT TOP(1) @LastLog=bs.backup_finish_date,@LogFile=mf.physical_device_name
FROM msdb.dbo.backupset bs JOIN msdb.dbo.backupmediafamily mf ON mf.media_set_id=bs.media_set_id
WHERE bs.database_name=N'ISPDATA' AND bs.type='L' AND bs.is_copy_only=0
  AND bs.family_guid=@Family AND bs.last_recovery_fork_guid=@Fork
  AND bs.has_backup_checksums=1 AND bs.is_damaged=0 AND mf.device_type=2
ORDER BY bs.backup_finish_date DESC,bs.backup_set_id DESC;
SELECT TOP(1) @LastFull=bs.backup_finish_date,@FullFile=mf.physical_device_name
FROM msdb.dbo.backupset bs JOIN msdb.dbo.backupmediafamily mf ON mf.media_set_id=bs.media_set_id
WHERE bs.database_name=N'ISPDATA' AND bs.type='D'
  AND bs.family_guid=@Family AND bs.last_recovery_fork_guid=@Fork
  AND bs.has_backup_checksums=1 AND bs.is_damaged=0 AND mf.device_type=2
ORDER BY bs.backup_finish_date DESC,bs.backup_set_id DESC;
SELECT GETDATE() AS ObservedAt,@LastLog AS LastLogFinish,@LastFull AS LastFullFinish,
       DATEDIFF(second,@LastLog,GETDATE()) AS LogAgeSeconds,
       DATEDIFF(second,@LastFull,GETDATE()) AS FullAgeSeconds;
IF @LastLog IS NULL OR @LastLog<DATEADD(minute,-30,GETDATE())
BEGIN
    ;THROW 51202, 'ISPDATA log backup is missing or older than 30 minutes.', 1;
END;
IF @LastFull IS NULL OR @LastFull<DATEADD(hour,-26,GETDATE())
BEGIN
    ;THROW 51203, 'ISPDATA full backup is missing or older than 26 hours.', 1;
END;
DECLARE @Check TABLE(FileExists int,FileIsDirectory int,ParentDirectoryExists int);
INSERT INTO @Check EXEC master.dbo.xp_fileexist @LogFile;
IF NOT EXISTS(SELECT 1 FROM @Check WHERE FileExists=1)
BEGIN
    ;THROW 51204, 'Latest log backup media is not accessible to the database engine.', 1;
END;
DELETE FROM @Check;
INSERT INTO @Check EXEC master.dbo.xp_fileexist @FullFile;
IF NOT EXISTS(SELECT 1 FROM @Check WHERE FileExists=1)
BEGIN
    ;THROW 51205, 'Latest full backup media is not accessible to the database engine.', 1;
END;
PRINT N'Latest ISPDATA backups are timely and engine-readable. This does not replace chain restore testing.';
