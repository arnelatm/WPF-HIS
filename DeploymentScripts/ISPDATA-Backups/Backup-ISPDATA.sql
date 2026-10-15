-- SQL Server 2014 SQL Agent backup-step template. Deployment preparation sets D or L.
-- Review only until approved. Never run against production merely to syntax-test it.
USE [master];
SET NOCOUNT ON;
DECLARE @ExpectedMachine sysname = N'IBN-SERVER';
DECLARE @Database sysname = N'ISPDATA';
DECLARE @BackupType char(1) = 'D';
DECLARE @ReserveFreeMB bigint = 1024;
DECLARE @MailProfile sysname = N'SQLAlerts';
DECLARE @Operator sysname = N'DBA_Alert';
DECLARE @SendFallbackWarning bit = 1;

IF CONVERT(nvarchar(128),SERVERPROPERTY('MachineName')) <> @ExpectedMachine
BEGIN
    ;THROW 51000, 'Unexpected SQL Server machine; no backup attempted.', 1;
END;
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name=@Database AND state=0 AND recovery_model=1)
BEGIN
    ;THROW 51001, 'Expected ONLINE/FULL database is unavailable; no backup attempted.', 1;
END;
IF @BackupType NOT IN ('D','L')
BEGIN
    ;THROW 51002, 'Backup type must be D or L.', 1;
END;

DECLARE @Started datetime = GETDATE();
DECLARE @Token nvarchar(32) = REPLACE(CONVERT(nvarchar(36),NEWID()),N'-',N'');
DECLARE @Stamp nvarchar(15) = CONVERT(nvarchar(8),@Started,112)+N'_'
    +REPLACE(CONVERT(nvarchar(8),@Started,108),N':',N'');
DECLARE @RequiredFreeMB bigint;
-- Conservative bound, including log allocation; compression is not relied upon for capacity.
SELECT @RequiredFreeMB=@ReserveFreeMB+CEILING(SUM(CONVERT(decimal(20,2),size))/128.0)
FROM sys.master_files WHERE database_id=DB_ID(@Database)
  AND (@BackupType='D' OR type=1);
DECLARE @LockResource nvarchar(255)=@Database+N'-ManagedBackup-'+@BackupType;
DECLARE @LockResult int;
EXEC @LockResult=sys.sp_getapplock @Resource=@LockResource,@LockMode='Exclusive',
    @LockOwner='Session',@LockTimeout=0;
IF @LockResult<0
BEGIN
    ;THROW 51003, 'Another managed backup of this type is running.', 1;
END;

DECLARE @Tasks TABLE(TaskId int PRIMARY KEY,FolderSuffix nvarchar(30),FilePrefix nvarchar(100));
IF @BackupType='L'
    INSERT INTO @Tasks VALUES(1,N'Logs\',N'ISPData_Log_'+@Stamp+N'_');
ELSE
BEGIN
    INSERT INTO @Tasks VALUES(1,N'',N'ISPData_'+@Stamp+N'_');
    -- Preserve current semantics: the 01:00 last-day archive is not financial-close evidence.
    IF EOMONTH(@Started)=CONVERT(date,@Started)
        INSERT INTO @Tasks VALUES(2,N'Monthly\',N'ISPData_MonthEnd_'
            +CONVERT(nvarchar(6),@Started,112)+N'_'+@Stamp+N'_');
END;
DECLARE @TaskId int=1,@TaskCount int=(SELECT COUNT(*) FROM @Tasks);
DECLARE @Folders TABLE(Attempt int PRIMARY KEY,RootFolder nvarchar(260));
INSERT INTO @Folders VALUES(1,N'F:\ISPDataBackup\'),(2,N'E:\SQLBackupFallback\ISPDataBackup\');
DECLARE @PathCheck TABLE(FileExists int,FileIsDirectory int,ParentDirectoryExists int);
DECLARE @Drives TABLE(Drive char(1),FreeMB int);
DECLARE @Completed bit,@Attempt int,@Path nvarchar(400),@File nvarchar(500),
    @Suffix nvarchar(30),@Prefix nvarchar(100),@BackupName nvarchar(128),
    @Position int,@BackupSetId int,@LastError nvarchar(2048),@Notice nvarchar(2048),@MailError nvarchar(2048)=NULL;

BEGIN TRY
    WHILE @TaskId<=@TaskCount
    BEGIN
        SELECT @Suffix=FolderSuffix,@Prefix=FilePrefix FROM @Tasks WHERE TaskId=@TaskId;
        SET @BackupName=N'ISPDATA managed '+@BackupType+N' '+@Token+N' task '+CONVERT(nvarchar(10),@TaskId);
        SET @Completed=0;
        SET @Attempt=1;
        SET @LastError=N'No usable backup destination.';
        WHILE @Attempt<=2 AND @Completed=0
        BEGIN
            SELECT @Path=RootFolder+@Suffix FROM @Folders WHERE Attempt=@Attempt;
            SET @File=@Path+@Prefix+@Token+CASE WHEN @BackupType='L' THEN N'.trn' ELSE N'.bak' END;
            DELETE FROM @PathCheck;
            INSERT INTO @PathCheck EXEC master.dbo.xp_fileexist @Path;
            IF NOT EXISTS (SELECT 1 FROM @PathCheck WHERE FileIsDirectory=1)
            BEGIN
                SET @LastError=N'Destination directory is unavailable: '+@Path;
                PRINT @LastError;
                SET @Attempt=@Attempt+1;
                CONTINUE;
            END;
            DELETE FROM @Drives;
            INSERT INTO @Drives EXEC master.dbo.xp_fixeddrives;
            IF NOT EXISTS (SELECT 1 FROM @Drives WHERE Drive=LEFT(@Path,1) AND FreeMB>=@RequiredFreeMB)
            BEGIN
                SET @LastError=N'Destination has insufficient/unreported free space: '+@Path;
                PRINT @LastError;
                SET @Attempt=@Attempt+1;
                CONTINUE;
            END;
            DELETE FROM @PathCheck;
            INSERT INTO @PathCheck EXEC master.dbo.xp_fileexist @File;
            IF EXISTS (SELECT 1 FROM @PathCheck WHERE FileExists=1 OR FileIsDirectory=1)
            BEGIN
                ;THROW 51004, 'Unique backup filename unexpectedly exists; no overwrite permitted.', 1;
            END;
            BEGIN TRY
                -- Actual engine writes prove writability. Failed partial files are preserved.
                -- NOINIT/NOFORMAT never overwrite existing media, even if an external race occurs.
                IF @BackupType='L'
                    BACKUP LOG @Database TO DISK=@File
                        WITH COMPRESSION,CHECKSUM,STOP_ON_ERROR,NOINIT,NOFORMAT,NOSKIP,NAME=@BackupName,STATS=5;
                ELSE
                    BACKUP DATABASE @Database TO DISK=@File
                        WITH COMPRESSION,CHECKSUM,STOP_ON_ERROR,NOINIT,NOFORMAT,NOSKIP,NAME=@BackupName,STATS=10;
                SET @Completed=1;
            END TRY
            BEGIN CATCH
                SET @LastError=LEFT(ERROR_MESSAGE(),2048);
                -- Never create another log backup after an ambiguous successful/registered write.
                -- Its first media file may be an indispensable log-chain segment.
                IF EXISTS (SELECT 1 FROM msdb.dbo.backupset AS bs
                    JOIN msdb.dbo.backupmediafamily AS mf ON mf.media_set_id=bs.media_set_id
                    WHERE bs.database_name=@Database AND bs.name=@BackupName AND mf.physical_device_name=@File)
                BEGIN
                    PRINT N'Backup metadata exists despite an error; preserve this file: '+@File;
                    PRINT @LastError;
                    ;THROW 51005, 'Backup metadata exists after an error. Preserve the file and investigate; fallback suppressed.', 1;
                END;
                PRINT N'Backup attempt failed; preserving partial file, if any: '+@File;
                PRINT @LastError;
                SET @Attempt=@Attempt+1;
            END CATCH;
        END;
        IF @Completed=0
        BEGIN
            ;THROW 51006, @LastError, 1;
        END;
        PRINT N'Backup write completed; required media awaiting verification: '+@File;
        SET @Position=NULL;
        SET @BackupSetId=NULL;
        SELECT TOP(1) @Position=bs.position,@BackupSetId=bs.backup_set_id
        FROM msdb.dbo.backupset AS bs
        JOIN msdb.dbo.backupmediafamily AS mf ON mf.media_set_id=bs.media_set_id
        WHERE bs.database_name=@Database AND bs.name=@BackupName AND bs.type=@BackupType
          AND bs.has_backup_checksums=1 AND bs.is_damaged=0 AND mf.physical_device_name=@File
        ORDER BY bs.backup_set_id DESC;
        IF @Position IS NULL
        BEGIN
            ;THROW 51007, 'Completed backup metadata could not be identified. Preserve the file; do not retry.', 1;
        END;
        -- Verification is deliberately OUTSIDE the backup-retry block.
        RESTORE VERIFYONLY FROM DISK=@File WITH FILE=@Position,CHECKSUM,STOP_ON_ERROR;
        PRINT N'Backup checksum verification succeeded: '+@File;
        SELECT @File AS BackupFile,@BackupSetId AS BackupSetId,@Position AS Position,@Attempt AS DestinationAttempt;
        IF @Attempt=2 AND @SendFallbackWarning=1
        BEGIN
            SET @Notice=N'ISPDATA backup verified on fallback storage. Required file: '+@File;
            BEGIN TRY
                EXEC msdb.dbo.sp_notify_operator @profile_name=@MailProfile,@name=@Operator,
                    @subject=N'WARNING: ISPDATA backup used fallback storage',@body=@Notice;
            END TRY
            BEGIN CATCH
                PRINT N'Fallback backup succeeded, but warning mail failed.';
                -- Complete any remaining scheduled archive before reporting notification failure.
                -- No retry or deletion of an already successful backup.
                SET @MailError=LEFT(ERROR_MESSAGE(),2048);
            END CATCH;
        END;
        SET @TaskId=@TaskId+1;
    END;
    IF @MailError IS NOT NULL
    BEGIN
        ;THROW 51008, @MailError, 1;
    END;
    EXEC sys.sp_releaseapplock @Resource=@LockResource,@LockOwner='Session';
END TRY
BEGIN CATCH
    EXEC sys.sp_releaseapplock @Resource=@LockResource,@LockOwner='Session';
    THROW;
END CATCH;
