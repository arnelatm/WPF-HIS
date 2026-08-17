/*
    Add database-level uniqueness protection for reconciliation markers.

    A journal transaction may belong to only one reconciliation. The unique
    constraint blocks both repeated markers under the same reconciliation and
    conflicting markers under different reconciliations.

    Defaults to validation-only mode. Set @ExecuteDeployment to 1 only during
    the controlled deployment window.
*/

USE [ISPDATA];

SET NOCOUNT ON;
SET XACT_ABORT ON;
SET LOCK_TIMEOUT 30000;

DECLARE @ExecuteDeployment bit = 0;
DECLARE @ExpectedServer nvarchar(128) = N'IBN-SERVER';
DECLARE @RequireVerifiedBackup bit = 1;
DECLARE @ExpectedBackup nvarchar(260) =
    N'F:\ISPDataBackup\ISPDATA_PreReconciledUniqueConstraint_20260817_133028.bak';
DECLARE @ConstraintName sysname = N'UQ_Reconciled_JournalCode_JournalItemIdNo';

IF CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')) <> @ExpectedServer
    THROW 51001, 'Safety check failed: connected server does not match ExpectedServer.', 1;

IF DB_NAME() <> N'ISPDATA'
    THROW 51002, 'Safety check failed: this script must run in ISPDATA.', 1;

IF @ExecuteDeployment NOT IN (0, 1)
    THROW 51003, 'ExecuteDeployment must be either 0 (dry run) or 1 (execute).', 1;

IF @RequireVerifiedBackup NOT IN (0, 1)
    THROW 51004, 'RequireVerifiedBackup must be either 0 or 1.', 1;

IF @RequireVerifiedBackup = 1
   AND NOT EXISTS (
       SELECT 1
       FROM msdb.dbo.backupset AS backup_set
       INNER JOIN msdb.dbo.backupmediafamily AS media
           ON media.media_set_id = backup_set.media_set_id
       WHERE backup_set.database_name = N'ISPDATA'
         AND backup_set.[type] = 'D'
         AND backup_set.is_copy_only = 1
         AND backup_set.has_backup_checksums = 1
         AND backup_set.backup_finish_date >= CONVERT(datetime, '2026-08-17T13:30:33', 126)
         AND media.physical_device_name = @ExpectedBackup
   )
    THROW 51005, 'Safety check failed: the expected copy-only checksum backup was not found.', 1;

IF OBJECT_ID(N'dbo.Reconciled', N'U') IS NULL
    THROW 51006, 'Safety check failed: dbo.Reconciled does not exist.', 1;

IF EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE object_id = OBJECT_ID(N'dbo.Reconciled')
      AND name = @ConstraintName
)
    THROW 51007, 'The reconciliation uniqueness constraint already exists; deployment stopped.', 1;

IF EXISTS (
    SELECT 1
    FROM dbo.Reconciled
    GROUP BY JournalCode, JournalItemIdNo
    HAVING COUNT(*) > 1
)
    THROW 51008, 'Safety check failed: duplicate transaction markers exist and must be resolved before adding the constraint.', 1;

IF EXISTS (
    SELECT 1
    FROM sys.columns
    WHERE object_id = OBJECT_ID(N'dbo.Reconciled')
      AND name IN (N'JournalCode', N'JournalItemIdNo')
      AND is_nullable = 1
)
   OR (SELECT COUNT(*)
       FROM sys.columns
       WHERE object_id = OBJECT_ID(N'dbo.Reconciled')
         AND name IN (N'JournalCode', N'JournalItemIdNo')) <> 2
    THROW 51009, 'Safety check failed: reconciliation key columns are missing or nullable.', 1;

IF @ExpectedServer = N'IBN-SERVER'
BEGIN
    IF (SELECT COUNT(*) FROM dbo.AccountReconciliation) <> 201
       OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItem) <> 48029
       OR (SELECT COUNT(*) FROM dbo.Reconciled) <> 36731
        THROW 51010, 'Safety check failed: live reconciliation table counts changed after the audited cleanup.', 1;

    IF OBJECT_ID(N'dbo.ReconciledCleanupBackup_20260817', N'U') IS NULL
       OR OBJECT_ID(N'dbo.AccountReconciliationItemCleanupBackup_20260817', N'U') IS NULL
       OR OBJECT_ID(N'dbo.AccountReconciliationCleanupBackup_20260817', N'U') IS NULL
       OR (SELECT COUNT(*) FROM dbo.ReconciledCleanupBackup_20260817) <> 292
       OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItemCleanupBackup_20260817) <> 2
       OR (SELECT COUNT(*) FROM dbo.AccountReconciliationCleanupBackup_20260817) <> 1
        THROW 51011, 'Safety check failed: historical cleanup archives do not match the verified state.', 1;

    IF EXISTS (SELECT 1 FROM dbo.AccountReconciliation WHERE IdNo = 1281)
       OR EXISTS (SELECT 1 FROM dbo.AccountReconciliationItem WHERE AccountReconciliationIdNo = 1281)
       OR EXISTS (SELECT 1 FROM dbo.Reconciled WHERE ReconciliationIdNo = 1281)
        THROW 51012, 'Safety check failed: incorrect reconciliation 1281 is present.', 1;

    IF (SELECT COUNT(*) FROM dbo.Reconciled WHERE ReconciliationIdNo = 13) <> 58
       OR (SELECT COUNT(*) FROM dbo.Reconciled WHERE ReconciliationIdNo = 1282) <> 51
       OR (SELECT COUNT(*) FROM dbo.Reconciled WHERE ReconciliationIdNo = 1306) <> 62
        THROW 51013, 'Safety check failed: protected reconciliation marker counts changed.', 1;
END;

DECLARE @MarkersBefore int = (SELECT COUNT(*) FROM dbo.Reconciled);

IF @ExecuteDeployment = 0
BEGIN
    SELECT
        CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')) AS ServerName,
        DB_NAME() AS DatabaseName,
        N'DRY RUN PASSED - NO SCHEMA OR DATA CHANGED' AS ValidationStatus,
        @ExpectedBackup AS VerifiedBackup,
        @MarkersBefore AS MarkerRows,
        0 AS DuplicateTransactionGroups,
        @ConstraintName AS ConstraintToCreate;

    RETURN;
END;

BEGIN TRY
    BEGIN TRANSACTION;

    IF EXISTS (
        SELECT 1
        FROM dbo.Reconciled WITH (UPDLOCK, HOLDLOCK)
        GROUP BY JournalCode, JournalItemIdNo
        HAVING COUNT(*) > 1
    )
        THROW 51014, 'Concurrent-state check failed: duplicate transaction markers appeared before index creation.', 1;

    ALTER TABLE dbo.Reconciled
        ADD CONSTRAINT UQ_Reconciled_JournalCode_JournalItemIdNo
        UNIQUE NONCLUSTERED (JournalCode ASC, JournalItemIdNo ASC);

    IF NOT EXISTS (
        SELECT 1
        FROM sys.key_constraints AS key_constraint
        INNER JOIN sys.indexes AS index_definition
            ON index_definition.object_id = key_constraint.parent_object_id
           AND index_definition.index_id = key_constraint.unique_index_id
        WHERE key_constraint.parent_object_id = OBJECT_ID(N'dbo.Reconciled')
          AND key_constraint.[type] = 'UQ'
          AND key_constraint.name = @ConstraintName
          AND index_definition.is_unique = 1
          AND index_definition.is_disabled = 0
    )
        THROW 51015, 'Deployment verification failed: unique constraint metadata is missing or disabled.', 1;

    IF (SELECT COUNT(*)
        FROM sys.index_columns AS index_column
        INNER JOIN sys.indexes AS index_definition
            ON index_definition.object_id = index_column.object_id
           AND index_definition.index_id = index_column.index_id
        WHERE index_definition.object_id = OBJECT_ID(N'dbo.Reconciled')
          AND index_definition.name = @ConstraintName
          AND index_column.key_ordinal > 0) <> 2
       OR NOT EXISTS (
           SELECT 1
           FROM sys.index_columns AS index_column
           INNER JOIN sys.indexes AS index_definition
               ON index_definition.object_id = index_column.object_id
              AND index_definition.index_id = index_column.index_id
           INNER JOIN sys.columns AS column_definition
               ON column_definition.object_id = index_column.object_id
              AND column_definition.column_id = index_column.column_id
           WHERE index_definition.object_id = OBJECT_ID(N'dbo.Reconciled')
             AND index_definition.name = @ConstraintName
             AND index_column.key_ordinal = 1
             AND column_definition.name = N'JournalCode'
       )
       OR NOT EXISTS (
           SELECT 1
           FROM sys.index_columns AS index_column
           INNER JOIN sys.indexes AS index_definition
               ON index_definition.object_id = index_column.object_id
              AND index_definition.index_id = index_column.index_id
           INNER JOIN sys.columns AS column_definition
               ON column_definition.object_id = index_column.object_id
              AND column_definition.column_id = index_column.column_id
           WHERE index_definition.object_id = OBJECT_ID(N'dbo.Reconciled')
             AND index_definition.name = @ConstraintName
             AND index_column.key_ordinal = 2
             AND column_definition.name = N'JournalItemIdNo'
       )
        THROW 51016, 'Deployment verification failed: unique constraint key columns are incorrect.', 1;

    IF (SELECT COUNT(*) FROM dbo.Reconciled) <> @MarkersBefore
        THROW 51017, 'Deployment verification failed: marker row count changed.', 1;

    COMMIT TRANSACTION;

    SELECT
        CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')) AS ServerName,
        DB_NAME() AS DatabaseName,
        N'DEPLOYMENT SUCCEEDED' AS DeploymentStatus,
        @ConstraintName AS ConstraintName,
        @MarkersBefore AS MarkerRowsUnchanged,
        0 AS DuplicateTransactionGroups,
        @ExpectedBackup AS DatabaseBackup;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
