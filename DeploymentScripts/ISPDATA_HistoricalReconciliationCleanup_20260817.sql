/*
    Historical Account Reconciliation cleanup for IBN-SERVER.ISPDATA

    Targets verified on 2026-08-17:
      - 58 same-parent duplicate marker groups under reconciliation 13.
        Each group contains six identical rows; retain the lowest IdNo and
        archive/delete the other five (290 redundant rows total).
      - Two cross-parent transaction conflicts between reconciliations 1281
        and 1282. Reconciliation 1282 is the confirmed correct parent.
        Archive/delete reconciliation 1281, its two items, and its two markers.

    The script defaults to validation-only mode. Set @ExecuteCleanup to 1 only
    after reviewing the dry-run output and ensuring reconciliation users are
    not posting during the cleanup window.
*/

USE [ISPDATA];

SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @ExecuteCleanup bit = 0;
DECLARE @ExpectedBackup nvarchar(260) =
    N'F:\ISPDataBackup\ISPDATA_PreHistoricalReconciliationCleanup_20260817_131020.bak';

IF CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')) <> N'IBN-SERVER'
    THROW 50001, 'Safety check failed: this script must run on IBN-SERVER.', 1;

IF DB_NAME() <> N'ISPDATA'
    THROW 50002, 'Safety check failed: this script must run in ISPDATA.', 1;

IF @ExecuteCleanup NOT IN (0, 1)
    THROW 50003, 'ExecuteCleanup must be either 0 (dry run) or 1 (execute).', 1;

IF NOT EXISTS (
    SELECT 1
    FROM msdb.dbo.backupset AS backup_set
    INNER JOIN msdb.dbo.backupmediafamily AS media
        ON media.media_set_id = backup_set.media_set_id
    WHERE backup_set.database_name = N'ISPDATA'
      AND backup_set.[type] = 'D'
      AND backup_set.is_copy_only = 1
      AND backup_set.has_backup_checksums = 1
      AND backup_set.backup_finish_date >= CONVERT(datetime, '2026-08-17T13:10:24', 126)
      AND media.physical_device_name = @ExpectedBackup
)
    THROW 50004, 'Safety check failed: the expected copy-only checksum backup was not found.', 1;

IF OBJECT_ID(N'dbo.ReconciledCleanupBackup_20260817', N'U') IS NOT NULL
   OR OBJECT_ID(N'dbo.AccountReconciliationItemCleanupBackup_20260817', N'U') IS NOT NULL
   OR OBJECT_ID(N'dbo.AccountReconciliationCleanupBackup_20260817', N'U') IS NOT NULL
    THROW 50005, 'Cleanup backup tables already exist; this script may already have been executed.', 1;

DECLARE @ExpectedCross TABLE (
    JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    JournalItemIdNo int NOT NULL,
    IncorrectReconciliationIdNo int NOT NULL,
    CorrectReconciliationIdNo int NOT NULL,
    PRIMARY KEY (JournalCode, JournalItemIdNo)
);

INSERT INTO @ExpectedCross (
    JournalCode,
    JournalItemIdNo,
    IncorrectReconciliationIdNo,
    CorrectReconciliationIdNo
)
VALUES
    ('CD', 28019, 1281, 1282),
    ('CR',  2681, 1281, 1282);

DECLARE @HeadersBefore int = (SELECT COUNT(*) FROM dbo.AccountReconciliation);
DECLARE @ItemsBefore int = (SELECT COUNT(*) FROM dbo.AccountReconciliationItem);
DECLARE @MarkersBefore int = (SELECT COUNT(*) FROM dbo.Reconciled);
DECLARE @SameParentGroups int;
DECLARE @SameParentRedundantRows int;

SELECT
    @SameParentGroups = COUNT(*),
    @SameParentRedundantRows = SUM(marker_group.MarkerCount - 1)
FROM (
    SELECT
        JournalCode,
        JournalItemIdNo,
        ReconciliationIdNo,
        COUNT(*) AS MarkerCount
    FROM dbo.Reconciled
    GROUP BY JournalCode, JournalItemIdNo, ReconciliationIdNo
    HAVING COUNT(*) > 1
) AS marker_group;

IF @SameParentGroups <> 58 OR @SameParentRedundantRows <> 290
    THROW 50006, 'Safety check failed: same-parent duplicate totals are not the expected 58 groups and 290 redundant rows.', 1;

IF EXISTS (
    SELECT 1
    FROM dbo.Reconciled
    GROUP BY JournalCode, JournalItemIdNo, ReconciliationIdNo
    HAVING COUNT(*) > 1
       AND (ReconciliationIdNo <> 13 OR COUNT(*) <> 6)
)
    THROW 50007, 'Safety check failed: a same-parent duplicate group is outside reconciliation 13 or does not contain six rows.', 1;

CREATE TABLE #ActualCross (
    JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    JournalItemIdNo int NOT NULL,
    PRIMARY KEY (JournalCode, JournalItemIdNo)
);

INSERT INTO #ActualCross (JournalCode, JournalItemIdNo)
SELECT JournalCode, JournalItemIdNo
FROM dbo.Reconciled
GROUP BY JournalCode, JournalItemIdNo
HAVING COUNT(DISTINCT ReconciliationIdNo) > 1;

IF (SELECT COUNT(*) FROM #ActualCross) <> 2
   OR EXISTS (
       SELECT 1
       FROM #ActualCross AS actual
       WHERE NOT EXISTS (
           SELECT 1
           FROM @ExpectedCross AS expected
           WHERE expected.JournalCode = actual.JournalCode
             AND expected.JournalItemIdNo = actual.JournalItemIdNo
       )
   )
   OR EXISTS (
       SELECT 1
       FROM @ExpectedCross AS expected
       WHERE NOT EXISTS (
           SELECT 1
           FROM #ActualCross AS actual
           WHERE actual.JournalCode = expected.JournalCode
             AND actual.JournalItemIdNo = expected.JournalItemIdNo
       )
   )
    THROW 50008, 'Safety check failed: cross-parent conflicts are not the two expected transaction references.', 1;

IF EXISTS (
    SELECT 1
    FROM @ExpectedCross AS expected
    WHERE (SELECT COUNT(*)
           FROM dbo.Reconciled AS marker
           WHERE marker.JournalCode = expected.JournalCode
             AND marker.JournalItemIdNo = expected.JournalItemIdNo
             AND marker.ReconciliationIdNo = expected.IncorrectReconciliationIdNo) <> 1
       OR (SELECT COUNT(*)
           FROM dbo.Reconciled AS marker
           WHERE marker.JournalCode = expected.JournalCode
             AND marker.JournalItemIdNo = expected.JournalItemIdNo
             AND marker.ReconciliationIdNo = expected.CorrectReconciliationIdNo) <> 1
)
    THROW 50009, 'Safety check failed: expected cross-parent marker rows do not match.', 1;

IF NOT EXISTS (
    SELECT 1
    FROM dbo.AccountReconciliation
    WHERE IdNo = 13
      AND AccountIdNo = 106
      AND ReconciliationDate = CONVERT(date, '20210531', 112)
      AND Posted = 1
)
   OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItem WHERE AccountReconciliationIdNo = 13) <> 61
   OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItem WHERE AccountReconciliationIdNo = 13 AND Cleared = 1) <> 58
   OR (SELECT COUNT(*) FROM dbo.Reconciled WHERE ReconciliationIdNo = 13) <> 348
    THROW 50010, 'Safety check failed: reconciliation 13 no longer matches the audited state.', 1;

IF NOT EXISTS (
    SELECT 1
    FROM dbo.AccountReconciliation
    WHERE IdNo = 1281
      AND AccountIdNo = 127
      AND ReconciliationDate = CONVERT(date, '20260131', 112)
      AND Posted = 1
)
   OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItem WHERE AccountReconciliationIdNo = 1281) <> 2
   OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItem WHERE AccountReconciliationIdNo = 1281 AND Cleared = 1) <> 2
   OR (SELECT COUNT(*) FROM dbo.Reconciled WHERE ReconciliationIdNo = 1281) <> 2
    THROW 50011, 'Safety check failed: incorrect reconciliation 1281 no longer matches the audited state.', 1;

IF EXISTS (
    SELECT 1
    FROM dbo.AccountReconciliationItem AS item
    WHERE item.AccountReconciliationIdNo = 1281
      AND NOT EXISTS (
          SELECT 1
          FROM @ExpectedCross AS expected
          WHERE expected.JournalCode = item.JournalCode
            AND expected.JournalItemIdNo = item.JournalItemIdNo
            AND expected.IncorrectReconciliationIdNo = item.AccountReconciliationIdNo
      )
)
   OR EXISTS (
       SELECT 1
       FROM @ExpectedCross AS expected
       WHERE (SELECT COUNT(*)
              FROM dbo.AccountReconciliationItem AS item
              WHERE item.AccountReconciliationIdNo = expected.IncorrectReconciliationIdNo
                AND item.JournalCode = expected.JournalCode
                AND item.JournalItemIdNo = expected.JournalItemIdNo
                AND item.Cleared = 1) <> 1
   )
    THROW 50012, 'Safety check failed: reconciliation 1281 items are not exactly the two expected cleared transactions.', 1;

IF NOT EXISTS (
    SELECT 1
    FROM dbo.AccountReconciliation
    WHERE IdNo = 1282
      AND AccountIdNo = 127
      AND ReconciliationDate = CONVERT(date, '20260228', 112)
      AND Posted = 1
)
   OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItem WHERE AccountReconciliationIdNo = 1282) <> 53
   OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItem WHERE AccountReconciliationIdNo = 1282 AND Cleared = 1) <> 51
   OR (SELECT COUNT(*) FROM dbo.Reconciled WHERE ReconciliationIdNo = 1282) <> 51
   OR EXISTS (
       SELECT 1
       FROM @ExpectedCross AS expected
       WHERE (SELECT COUNT(*)
              FROM dbo.AccountReconciliationItem AS item
              WHERE item.AccountReconciliationIdNo = expected.CorrectReconciliationIdNo
                AND item.JournalCode = expected.JournalCode
                AND item.JournalItemIdNo = expected.JournalItemIdNo
                AND item.Cleared = 1) <> 1
   )
    THROW 50013, 'Safety check failed: correct reconciliation 1282 no longer matches the audited state.', 1;

IF NOT EXISTS (
    SELECT 1
    FROM dbo.AccountReconciliation
    WHERE IdNo = 1306 AND Posted = 1
)
   OR (SELECT COUNT(*) FROM dbo.Reconciled WHERE ReconciliationIdNo = 1306) <> 62
    THROW 50014, 'Safety check failed: verified reconciliation 1306 no longer matches the post-deployment state.', 1;

IF @ExecuteCleanup = 0
BEGIN
    SELECT
        CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')) AS ServerName,
        DB_NAME() AS DatabaseName,
        N'DRY RUN PASSED - NO DATA CHANGED' AS ValidationStatus,
        @ExpectedBackup AS VerifiedBackup,
        @HeadersBefore AS HeadersBefore,
        @ItemsBefore AS ItemsBefore,
        @MarkersBefore AS MarkersBefore,
        @SameParentGroups AS SameParentDuplicateGroups,
        @SameParentRedundantRows AS SameParentRowsToDelete,
        2 AS CrossParentMarkersToDelete,
        2 AS Reconciliation1281ItemsToDelete,
        1 AS Reconciliation1281HeadersToDelete,
        @HeadersBefore - 1 AS ExpectedHeadersAfter,
        @ItemsBefore - 2 AS ExpectedItemsAfter,
        @MarkersBefore - 292 AS ExpectedMarkersAfter;

    RETURN;
END;

DECLARE @CleanupBatchId uniqueidentifier = NEWID();
DECLARE @ArchivedAt datetime2(0) = SYSDATETIME();

BEGIN TRY
    BEGIN TRANSACTION;

    IF (SELECT COUNT(*)
        FROM dbo.AccountReconciliation WITH (UPDLOCK, HOLDLOCK)
        WHERE IdNo IN (13, 1281, 1282, 1306)) <> 4
        THROW 50015, 'Concurrent-state check failed for the guarded reconciliation headers.', 1;

    CREATE TABLE dbo.ReconciledCleanupBackup_20260817 (
        IdNo int NOT NULL,
        JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        JournalItemIdNo int NOT NULL,
        ReconciliationIdNo int NOT NULL,
        CleanupReason varchar(50) NOT NULL,
        CleanupBatchId uniqueidentifier NOT NULL,
        ArchivedAt datetime2(0) NOT NULL,
        CONSTRAINT PK_ReconciledCleanupBackup_20260817 PRIMARY KEY CLUSTERED (IdNo)
    );

    CREATE TABLE dbo.AccountReconciliationItemCleanupBackup_20260817 (
        IdNo int NOT NULL,
        AccountReconciliationIdNo int NULL,
        JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        JournalItemIdNo int NULL,
        Cleared bit NULL,
        Sequence int NULL,
        CleanupReason varchar(50) NOT NULL,
        CleanupBatchId uniqueidentifier NOT NULL,
        ArchivedAt datetime2(0) NOT NULL,
        CONSTRAINT PK_AccountReconciliationItemCleanupBackup_20260817 PRIMARY KEY CLUSTERED (IdNo)
    );

    CREATE TABLE dbo.AccountReconciliationCleanupBackup_20260817 (
        IdNo int NOT NULL,
        AccountIdNo int NOT NULL,
        ReconciliationDate date NOT NULL,
        Balance money NOT NULL,
        Posted bit NULL,
        DateCreated date NOT NULL,
        DateTimeStamp binary(8) NULL,
        CleanupReason varchar(50) NOT NULL,
        CleanupBatchId uniqueidentifier NOT NULL,
        ArchivedAt datetime2(0) NOT NULL,
        CONSTRAINT PK_AccountReconciliationCleanupBackup_20260817 PRIMARY KEY CLUSTERED (IdNo)
    );

    ;WITH RankedMarkers AS (
        SELECT
            marker.IdNo,
            marker.JournalCode,
            marker.JournalItemIdNo,
            marker.ReconciliationIdNo,
            ROW_NUMBER() OVER (
                PARTITION BY marker.JournalCode, marker.JournalItemIdNo, marker.ReconciliationIdNo
                ORDER BY marker.IdNo
            ) AS DuplicateRank
        FROM dbo.Reconciled AS marker WITH (UPDLOCK, HOLDLOCK)
    )
    INSERT INTO dbo.ReconciledCleanupBackup_20260817 (
        IdNo,
        JournalCode,
        JournalItemIdNo,
        ReconciliationIdNo,
        CleanupReason,
        CleanupBatchId,
        ArchivedAt
    )
    SELECT
        IdNo,
        JournalCode,
        JournalItemIdNo,
        ReconciliationIdNo,
        'SameParentDuplicate',
        @CleanupBatchId,
        @ArchivedAt
    FROM RankedMarkers
    WHERE DuplicateRank > 1;

    INSERT INTO dbo.ReconciledCleanupBackup_20260817 (
        IdNo,
        JournalCode,
        JournalItemIdNo,
        ReconciliationIdNo,
        CleanupReason,
        CleanupBatchId,
        ArchivedAt
    )
    SELECT
        marker.IdNo,
        marker.JournalCode,
        marker.JournalItemIdNo,
        marker.ReconciliationIdNo,
        'IncorrectParent1281',
        @CleanupBatchId,
        @ArchivedAt
    FROM dbo.Reconciled AS marker WITH (UPDLOCK, HOLDLOCK)
    INNER JOIN @ExpectedCross AS expected
        ON expected.JournalCode = marker.JournalCode
       AND expected.JournalItemIdNo = marker.JournalItemIdNo
       AND expected.IncorrectReconciliationIdNo = marker.ReconciliationIdNo;

    IF (SELECT COUNT(*) FROM dbo.ReconciledCleanupBackup_20260817 WHERE CleanupBatchId = @CleanupBatchId) <> 292
       OR (SELECT COUNT(*) FROM dbo.ReconciledCleanupBackup_20260817 WHERE CleanupBatchId = @CleanupBatchId AND CleanupReason = 'SameParentDuplicate') <> 290
       OR (SELECT COUNT(*) FROM dbo.ReconciledCleanupBackup_20260817 WHERE CleanupBatchId = @CleanupBatchId AND CleanupReason = 'IncorrectParent1281') <> 2
        THROW 50016, 'Archive validation failed for reconciliation markers.', 1;

    INSERT INTO dbo.AccountReconciliationItemCleanupBackup_20260817 (
        IdNo,
        AccountReconciliationIdNo,
        JournalCode,
        JournalItemIdNo,
        Cleared,
        Sequence,
        CleanupReason,
        CleanupBatchId,
        ArchivedAt
    )
    SELECT
        item.IdNo,
        item.AccountReconciliationIdNo,
        item.JournalCode,
        item.JournalItemIdNo,
        item.Cleared,
        item.Sequence,
        'IncorrectReconciliation1281',
        @CleanupBatchId,
        @ArchivedAt
    FROM dbo.AccountReconciliationItem AS item WITH (UPDLOCK, HOLDLOCK)
    WHERE item.AccountReconciliationIdNo = 1281;

    IF @@ROWCOUNT <> 2
        THROW 50017, 'Archive validation failed for reconciliation 1281 items.', 1;

    INSERT INTO dbo.AccountReconciliationCleanupBackup_20260817 (
        IdNo,
        AccountIdNo,
        ReconciliationDate,
        Balance,
        Posted,
        DateCreated,
        DateTimeStamp,
        CleanupReason,
        CleanupBatchId,
        ArchivedAt
    )
    SELECT
        reconciliation.IdNo,
        reconciliation.AccountIdNo,
        reconciliation.ReconciliationDate,
        reconciliation.Balance,
        reconciliation.Posted,
        reconciliation.DateCreated,
        CONVERT(binary(8), reconciliation.DateTimeStamp),
        'IncorrectReconciliation1281',
        @CleanupBatchId,
        @ArchivedAt
    FROM dbo.AccountReconciliation AS reconciliation WITH (UPDLOCK, HOLDLOCK)
    WHERE reconciliation.IdNo = 1281;

    IF @@ROWCOUNT <> 1
        THROW 50018, 'Archive validation failed for reconciliation 1281 header.', 1;

    DELETE marker
    FROM dbo.Reconciled AS marker
    INNER JOIN dbo.ReconciledCleanupBackup_20260817 AS archived
        ON archived.IdNo = marker.IdNo
       AND archived.CleanupBatchId = @CleanupBatchId;

    IF @@ROWCOUNT <> 292
        THROW 50019, 'Delete validation failed for reconciliation markers.', 1;

    DELETE item
    FROM dbo.AccountReconciliationItem AS item
    INNER JOIN dbo.AccountReconciliationItemCleanupBackup_20260817 AS archived
        ON archived.IdNo = item.IdNo
       AND archived.CleanupBatchId = @CleanupBatchId;

    IF @@ROWCOUNT <> 2
        THROW 50020, 'Delete validation failed for reconciliation 1281 items.', 1;

    DELETE reconciliation
    FROM dbo.AccountReconciliation AS reconciliation
    INNER JOIN dbo.AccountReconciliationCleanupBackup_20260817 AS archived
        ON archived.IdNo = reconciliation.IdNo
       AND archived.CleanupBatchId = @CleanupBatchId;

    IF @@ROWCOUNT <> 1
        THROW 50021, 'Delete validation failed for reconciliation 1281 header.', 1;

    IF (SELECT COUNT(*) FROM dbo.AccountReconciliation) <> @HeadersBefore - 1
       OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItem) <> @ItemsBefore - 2
       OR (SELECT COUNT(*) FROM dbo.Reconciled) <> @MarkersBefore - 292
        THROW 50022, 'Post-cleanup table counts do not match the expected changes.', 1;

    IF EXISTS (
        SELECT 1
        FROM dbo.Reconciled
        GROUP BY JournalCode, JournalItemIdNo, ReconciliationIdNo
        HAVING COUNT(*) > 1
    )
        THROW 50023, 'Post-cleanup validation found remaining same-parent duplicate markers.', 1;

    IF EXISTS (
        SELECT 1
        FROM dbo.Reconciled
        GROUP BY JournalCode, JournalItemIdNo
        HAVING COUNT(DISTINCT ReconciliationIdNo) > 1
    )
        THROW 50024, 'Post-cleanup validation found remaining cross-parent conflicts.', 1;

    IF EXISTS (SELECT 1 FROM dbo.AccountReconciliation WHERE IdNo = 1281)
       OR EXISTS (SELECT 1 FROM dbo.AccountReconciliationItem WHERE AccountReconciliationIdNo = 1281)
       OR EXISTS (SELECT 1 FROM dbo.Reconciled WHERE ReconciliationIdNo = 1281)
        THROW 50025, 'Post-cleanup validation found remaining reconciliation 1281 records.', 1;

    IF (SELECT COUNT(*) FROM dbo.Reconciled WHERE ReconciliationIdNo = 13) <> 58
       OR EXISTS (
           SELECT 1
           FROM dbo.AccountReconciliationItem AS item
           WHERE item.AccountReconciliationIdNo = 13
             AND item.Cleared = 1
             AND NOT EXISTS (
                 SELECT 1
                 FROM dbo.Reconciled AS marker
                 WHERE marker.ReconciliationIdNo = 13
                   AND marker.JournalCode = item.JournalCode
                   AND marker.JournalItemIdNo = item.JournalItemIdNo
             )
       )
        THROW 50026, 'Post-cleanup validation failed for reconciliation 13.', 1;

    IF (SELECT COUNT(*) FROM dbo.AccountReconciliation WHERE IdNo = 1282 AND Posted = 1) <> 1
       OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItem WHERE AccountReconciliationIdNo = 1282) <> 53
       OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItem WHERE AccountReconciliationIdNo = 1282 AND Cleared = 1) <> 51
       OR (SELECT COUNT(*) FROM dbo.Reconciled WHERE ReconciliationIdNo = 1282) <> 51
        THROW 50027, 'Post-cleanup validation failed for correct reconciliation 1282.', 1;

    IF (SELECT COUNT(*) FROM dbo.Reconciled WHERE ReconciliationIdNo = 1306) <> 62
       OR (SELECT COUNT(*) FROM dbo.AccountReconciliation WHERE IdNo = 1306 AND Posted = 1) <> 1
        THROW 50028, 'Post-cleanup validation failed for reconciliation 1306.', 1;

    IF (SELECT COUNT(IdNo) FROM dbo.AccountReconciliationItem_View)
       <> (SELECT COUNT(DISTINCT IdNo) FROM dbo.AccountReconciliationItem_View)
        THROW 50029, 'Post-cleanup validation found duplicate item IDs in AccountReconciliationItem_View.', 1;

    COMMIT TRANSACTION;

    SELECT
        CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')) AS ServerName,
        DB_NAME() AS DatabaseName,
        N'CLEANUP SUCCEEDED' AS CleanupStatus,
        @CleanupBatchId AS CleanupBatchId,
        @ExpectedBackup AS DatabaseBackup,
        @HeadersBefore - 1 AS HeadersAfter,
        @ItemsBefore - 2 AS ItemsAfter,
        @MarkersBefore - 292 AS MarkersAfter,
        0 AS SameParentDuplicateGroupsAfter,
        0 AS CrossParentConflictGroupsAfter,
        N'dbo.ReconciledCleanupBackup_20260817' AS MarkerArchiveTable,
        N'dbo.AccountReconciliationItemCleanupBackup_20260817' AS ItemArchiveTable,
        N'dbo.AccountReconciliationCleanupBackup_20260817' AS HeaderArchiveTable;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
