-- Read-only metadata diagnostics for IBN-SERVER / ISPDATA; SQL Server 2014-compatible.
-- No backups, checkpoint, shrink, DDL, job edits, transaction termination or patient queries.
USE [master];
SET NOCOUNT ON;
SET LOCK_TIMEOUT 5000;
IF CONVERT(nvarchar(128),SERVERPROPERTY('MachineName')) <> N'IBN-SERVER'
BEGIN
    ;THROW 50100, 'Wrong machine: diagnostics are restricted to IBN-SERVER.', 1;
END;
SELECT CONVERT(nvarchar(128),SERVERPROPERTY('MachineName')) AS MachineName,
       CONVERT(nvarchar(128),SERVERPROPERTY('ServerName')) AS ConnectedInstance,
       CONVERT(nvarchar(50),SERVERPROPERTY('ProductVersion')) AS ProductVersion,
       SYSDATETIMEOFFSET() AS ObservedAt;
SELECT name,recovery_model_desc,log_reuse_wait_desc,is_auto_shrink_on,is_cdc_enabled,
       is_published,is_subscribed,is_merge_published,is_broker_enabled
FROM sys.databases WHERE name=N'ISPDATA';
USE [ISPDATA];
SELECT name,type_desc,physical_name,CAST(size/128.0 AS decimal(18,2)) AS SizeMB,
       growth,is_percent_growth,
       CAST(CASE WHEN is_percent_growth=0 THEN growth/128.0 END AS decimal(18,2)) AS GrowthMB,max_size
FROM sys.database_files;
SELECT SYSDATETIMEOFFSET() AS ObservedAt,
       CAST(total_log_size_in_bytes/1048576.0 AS decimal(18,3)) AS TotalLogMB,
       CAST(used_log_space_in_bytes/1048576.0 AS decimal(18,3)) AS UsedLogMB,
       CAST(used_log_space_in_percent AS decimal(18,4)) AS UsedLogPercent,
       CAST(log_space_in_bytes_since_last_backup/1048576.0 AS decimal(18,4)) AS SinceLastBackupMB
FROM sys.dm_db_log_space_usage;
DBCC OPENTRAN WITH NO_INFOMSGS;
DBCC LOGINFO WITH NO_INFOMSGS;
SELECT transaction_id,database_transaction_begin_time,database_transaction_type,
       database_transaction_state,database_transaction_log_record_count,
       database_transaction_log_bytes_used,database_transaction_log_bytes_reserved
FROM sys.dm_tran_database_transactions WHERE database_id=DB_ID();
SELECT DISTINCT v.volume_mount_point,v.logical_volume_name,
       CAST(v.total_bytes/1073741824.0 AS decimal(18,2)) AS TotalGB,
       CAST(v.available_bytes/1073741824.0 AS decimal(18,2)) AS AvailableGB
FROM sys.database_files AS f
CROSS APPLY sys.dm_os_volume_stats(DB_ID(),f.file_id) AS v;

-- Daily backup volumes and peak backup duration; bytes are not peak retained log usage.
SELECT CAST(backup_start_date AS date) AS BackupDay,type,COUNT(*) AS BackupCount,
       CAST(SUM(backup_size)/1048576.0 AS decimal(18,3)) AS TotalUncompressedMB,
       CAST(MAX(backup_size)/1048576.0 AS decimal(18,3)) AS MaxUncompressedMB,
       MAX(DATEDIFF(second,backup_start_date,backup_finish_date)) AS MaxDurationSeconds,
       MIN(backup_start_date) AS FirstBackup,MAX(backup_finish_date) AS LastBackup
FROM msdb.dbo.backupset
WHERE database_name=N'ISPDATA' AND backup_start_date>=DATEADD(day,-31,GETDATE())
GROUP BY CAST(backup_start_date AS date),type
ORDER BY BackupDay DESC,type;

-- Largest historical logs, including out-of-job/manual backups and copy-only status.
SELECT TOP(25) bs.backup_start_date,bs.backup_finish_date,
       CAST(bs.backup_size/1048576.0 AS decimal(18,3)) AS UncompressedMB,
       CAST(bs.compressed_backup_size/1048576.0 AS decimal(18,3)) AS CompressedMB,
       bs.is_copy_only,bs.first_lsn,bs.last_lsn,bmf.physical_device_name
FROM msdb.dbo.backupset AS bs
JOIN msdb.dbo.backupmediafamily AS bmf ON bmf.media_set_id=bs.media_set_id
WHERE bs.database_name=N'ISPDATA' AND bs.type='L'
ORDER BY bs.backup_size DESC,bs.backup_start_date DESC;

-- Metadata continuity/gaps across all retained ordinary log backups, not just job files.
;WITH Logs AS
(SELECT backup_set_id,backup_start_date,backup_finish_date,first_lsn,last_lsn,
        first_recovery_fork_guid,last_recovery_fork_guid,
        LAG(backup_finish_date) OVER(ORDER BY backup_start_date,backup_set_id) AS PreviousFinish,
        LAG(last_lsn) OVER(ORDER BY backup_start_date,backup_set_id) AS PreviousLastLSN,
        LAG(last_recovery_fork_guid) OVER(ORDER BY backup_start_date,backup_set_id) AS PreviousFork
 FROM msdb.dbo.backupset
 WHERE database_name=N'ISPDATA' AND type='L' AND is_copy_only=0)
SELECT TOP(40) backup_start_date,backup_finish_date,PreviousFinish,
       DATEDIFF(second,PreviousFinish,backup_start_date) AS GapSeconds,
       first_lsn,last_lsn,PreviousLastLSN,first_recovery_fork_guid,last_recovery_fork_guid,
       CASE WHEN PreviousLastLSN<first_lsn THEN 1 ELSE 0 END AS PossibleLSNGap,
       CASE WHEN PreviousFork<>first_recovery_fork_guid THEN 1 ELSE 0 END AS ForkChanged
FROM Logs
WHERE DATEDIFF(second,PreviousFinish,backup_start_date)>1200
   OR PreviousLastLSN<first_lsn OR PreviousFork<>first_recovery_fork_guid
ORDER BY backup_start_date DESC;

SELECT MIN(backup_start_date) AS EarliestRetainedBackupHistory,
       MAX(backup_finish_date) AS LatestRetainedBackupHistory,
       COUNT(*) AS BackupSets
FROM msdb.dbo.backupset WHERE database_name=N'ISPDATA';

DECLARE @TracePath nvarchar(260);
SELECT TOP(1) @TracePath=path FROM sys.traces WHERE is_default=1;
SELECT @TracePath AS DefaultTracePath;
IF @TracePath IS NOT NULL
BEGIN
    SELECT MIN(StartTime) AS EarliestTraceEvent,MAX(StartTime) AS LatestTraceEvent,COUNT(*) AS TraceEvents
    FROM sys.fn_trace_gettable(@TracePath,DEFAULT);
    SELECT TOP(100) StartTime,DatabaseName,Filename,EventClass,IntegerData,
           CAST(IntegerData*8.0/1024 AS decimal(18,3)) AS SizeChangeMB,
           CAST(Duration/1000000.0 AS decimal(18,3)) AS DurationSeconds,
           ApplicationName,HostName
    FROM sys.fn_trace_gettable(@TracePath,DEFAULT)
    WHERE DatabaseName=N'ISPDATA' AND EventClass IN(92,93,94,95)
    ORDER BY StartTime DESC;
END;

-- Job inventory excludes step command text and free-form messages to avoid exposing secrets.
SELECT j.name,j.enabled,s.step_id,s.step_name,s.subsystem,s.database_name
FROM msdb.dbo.sysjobs AS j
JOIN msdb.dbo.sysjobsteps AS s ON s.job_id=j.job_id
ORDER BY j.name,s.step_id;
SELECT TOP(60) j.name,h.step_id,h.run_date,h.run_time,h.run_duration,h.run_status,h.sql_message_id
FROM msdb.dbo.sysjobhistory AS h
JOIN msdb.dbo.sysjobs AS j ON j.job_id=h.job_id
WHERE h.step_id=0 AND (j.name LIKE N'%ISP%' OR h.run_status<>1)
ORDER BY h.instance_id DESC;


-- Follow-up history: these aggregates identified the legacy allocation and reduction interval.
SELECT bs.recovery_model,
       CAST(bf.file_size/1048576.0 AS decimal(18,3)) AS LogFileMB,
       MIN(bs.backup_start_date) AS FirstRecorded,
       MAX(bs.backup_start_date) AS LastRecorded,COUNT(*) AS FullBackupCount
FROM msdb.dbo.backupset AS bs
JOIN msdb.dbo.backupfile AS bf ON bf.backup_set_id=bs.backup_set_id
WHERE bs.database_name=N'ISPDATA' AND bs.type='D' AND bf.file_type='L'
GROUP BY bs.recovery_model,bf.file_size ORDER BY FirstRecorded;
SELECT DATEFROMPARTS(YEAR(backup_start_date),MONTH(backup_start_date),1) AS BackupMonth,
       COUNT(*) AS LogBackups,MIN(backup_start_date) AS FirstLog,
       MAX(backup_finish_date) AS LastLog,
       CAST(MAX(backup_size)/1048576.0 AS decimal(18,3)) AS LargestLogMB
FROM msdb.dbo.backupset WHERE database_name=N'ISPDATA' AND type='L'
GROUP BY YEAR(backup_start_date),MONTH(backup_start_date) ORDER BY BackupMonth;
SELECT TOP(6) bs.backup_start_date,
       CAST(bf.file_size/1048576.0 AS decimal(18,3)) AS LogFileMB,
       bmf.physical_device_name
FROM msdb.dbo.backupset AS bs
JOIN msdb.dbo.backupfile AS bf ON bf.backup_set_id=bs.backup_set_id
JOIN msdb.dbo.backupmediafamily AS bmf ON bmf.media_set_id=bs.media_set_id
WHERE bs.database_name=N'ISPDATA' AND bs.type='D' AND bf.file_type='L'
  AND bs.backup_start_date>='20260305' AND bs.backup_start_date<'20260309'
ORDER BY bs.backup_start_date DESC;
SELECT j.name,j.date_created,j.date_modified,j.notify_level_email,
       o.name AS OperatorName,o.enabled AS OperatorEnabled,
       CASE WHEN NULLIF(o.email_address,N'') IS NOT NULL THEN 1 ELSE 0 END AS OperatorAddressConfigured
FROM msdb.dbo.sysjobs AS j
LEFT JOIN msdb.dbo.sysoperators AS o ON o.id=j.notify_email_operator_id
WHERE j.name LIKE N'ISPData%';
SELECT TOP(10) rh.restore_date,rh.restore_type,rh.destination_database_name,
       bs.database_name,bs.backup_start_date,bs.server_name,bs.first_lsn,bs.last_lsn
FROM msdb.dbo.restorehistory AS rh
LEFT JOIN msdb.dbo.backupset AS bs ON bs.backup_set_id=rh.backup_set_id
WHERE rh.destination_database_name=N'ISPDATA' ORDER BY rh.restore_date;
SELECT name FROM msdb.dbo.sysmaintplan_plans;
