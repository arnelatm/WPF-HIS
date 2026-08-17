SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @ExpectedServer sysname = N'IBN-SERVER';
DECLARE @ExpectedDatabase sysname = N'ISPDATA';
DECLARE @RequireVerifiedBackup bit = 1;

IF @@SERVERNAME <> @ExpectedServer OR DB_NAME() <> @ExpectedDatabase
BEGIN
    RAISERROR('Safety guard failed: expected IBN-SERVER.ISPDATA.', 16, 1);
    RETURN;
END;

IF @RequireVerifiedBackup = 1
   AND NOT EXISTS
(
    SELECT 1
    FROM msdb.dbo.backupset AS backup_set
    INNER JOIN msdb.dbo.backupmediafamily AS backup_media
        ON backup_media.media_set_id = backup_set.media_set_id
    WHERE backup_set.database_name = N'ISPDATA'
      AND backup_set.type = N'D'
      AND backup_set.backup_finish_date >= '20260817 12:38:32'
      AND backup_set.is_copy_only = 1
      AND backup_set.has_backup_checksums = 1
      AND backup_media.physical_device_name =
          N'F:\ISPDataBackup\ISPDATA_PreReconciliationFix_20260817_123600.bak'
)
BEGIN
    RAISERROR('The verified pre-deployment backup was not found in backup history.', 16, 1);
    RETURN;
END;

IF OBJECT_ID(N'dbo.AccountReconciliationItem_View', N'V') IS NULL
   OR OBJECT_ID(N'dbo.GlReconciliation_View', N'V') IS NULL
   OR OBJECT_ID(N'dbo.InsertReconciledTVP', N'P') IS NULL
BEGIN
    RAISERROR('One or more expected reconciliation objects do not exist.', 16, 1);
    RETURN;
END;

DECLARE @ReconciliationHeadersBefore int;
DECLARE @ReconciliationItemsBefore int;
DECLARE @MarkersBefore int;
DECLARE @SameParentDuplicateGroupsBefore int;
DECLARE @CrossParentConflictGroupsBefore int;

SELECT @ReconciliationHeadersBefore = COUNT(*)
FROM dbo.AccountReconciliation;

SELECT @ReconciliationItemsBefore = COUNT(*)
FROM dbo.AccountReconciliationItem;

SELECT @MarkersBefore = COUNT(*)
FROM dbo.Reconciled;

SELECT @SameParentDuplicateGroupsBefore = COUNT(*)
FROM
(
    SELECT JournalCode, JournalItemIdNo, ReconciliationIdNo
    FROM dbo.Reconciled
    GROUP BY JournalCode, JournalItemIdNo, ReconciliationIdNo
    HAVING COUNT(*) > 1
) AS SameParentDuplicates;

SELECT @CrossParentConflictGroupsBefore = COUNT(*)
FROM
(
    SELECT JournalCode, JournalItemIdNo
    FROM dbo.Reconciled
    GROUP BY JournalCode, JournalItemIdNo
    HAVING COUNT(DISTINCT ReconciliationIdNo) > 1
) AS CrossParentConflicts;

BEGIN TRY
    BEGIN TRANSACTION;

    EXEC sys.sp_executesql N'
ALTER VIEW [dbo].[AccountReconciliationItem_View]
AS
SELECT        dbo.AccountReconciliationItem.IdNo, dbo.AccountReconciliationItem.Sequence, dbo.GlLedgers_View.TransactionDate, dbo.GlLedgers_View.IdNo AS JournalItemIdNo, dbo.GlLedgers_View.JournalCode,
                         dbo.AccountReconciliationItem.AccountReconciliationIdNo, dbo.GlLedgers_View.Debit, dbo.GlLedgers_View.DocumentNumber, dbo.GlLedgers_View.Credit, dbo.AccountReconciliationItem.Cleared, dbo.GlLedgers_View.AccountIdNo, dbo.GlLedgers_View.PayDescription,
                         dbo.GlLedgers_View.PayDescriptionAra, dbo.GlLedgers_View.ReferenceNo, dbo.GlLedgers_View.JournalIdNo, dbo.AccountReconciliation.Posted as Reconciled, dbo.AccountReconciliation.Posted
FROM            dbo.GlLedgers_View
                  LEFT OUTER JOIN dbo.AccountReconciliationItem
                     ON dbo.GlLedgers_View.JournalCode = dbo.AccountReconciliationItem.JournalCode Collate SQL_Latin1_General_CP1_CI_AS AND dbo.GlLedgers_View.IdNo = dbo.AccountReconciliationItem.JournalItemIdNo
                  LEFT OUTER JOIN dbo.AccountReconciliation
                     ON dbo.AccountReconciliationItem.AccountReconciliationIdNo = dbo.AccountReconciliation.IdNo;
';

    EXEC sys.sp_executesql N'
ALTER VIEW [dbo].[GlReconciliation_View]
AS
SELECT          dbo.GlLedgers_View.JournalCode, dbo.GlLedgers_View.IdNo, dbo.GlLedgers_View.Sequence, dbo.GlLedgers_View.JournalIdNo, dbo.GlLedgers_View.AccountIdNo, dbo.GlLedgers_View.Debit,
                dbo.GlLedgers_View.Credit, dbo.GlLedgers_View.DocumentNumber, dbo.GlLedgers_View.RevCostCenterIdNo, dbo.GlLedgers_View.Notes, dbo.GlLedgers_View.Posted, dbo.GlLedgers_View.TransactionDate, dbo.GlLedgers_View.ReferenceNo,
                dbo.GlLedgers_View.PayDescription, dbo.GlLedgers_View.PayDescriptionAra, Reconciled.IdNo AS Reconciled
FROM            dbo.GlLedgers_View
                LEFT OUTER JOIN
                (
                    SELECT JournalCode, JournalItemIdNo, MIN(IdNo) AS IdNo
                    FROM dbo.Reconciled
                    GROUP BY JournalCode, JournalItemIdNo
                ) AS Reconciled
                    ON dbo.GlLedgers_View.IdNo = Reconciled.JournalItemIdNo
                   AND dbo.GlLedgers_View.JournalCode = Reconciled.JournalCode Collate SQL_Latin1_General_CP1_CI_AS;
';

    EXEC sys.sp_executesql N'
ALTER PROC [dbo].[InsertReconciledTVP]
  @MParam ReconciledInsert READONLY
AS
BEGIN
    SET NOCOUNT OFF;

    IF EXISTS (
        SELECT JournalCode, JournalItemIdNo
        FROM @MParam
        GROUP BY JournalCode, JournalItemIdNo
        HAVING COUNT(*) > 1
    )
    BEGIN
        RAISERROR (''The reconciliation contains duplicate transaction references.'', 16, 1);
        RETURN;
    END;

    IF (
        SELECT COUNT(DISTINCT ReconciliationIdNo)
        FROM @MParam
    ) > 1
    BEGIN
        RAISERROR (''All transaction references must belong to the same reconciliation.'', 16, 1);
        RETURN;
    END;

    IF EXISTS (
        SELECT 1
        FROM @MParam AS source
        LEFT JOIN dbo.AccountReconciliation AS reconciliation WITH (UPDLOCK, HOLDLOCK)
            ON reconciliation.IdNo = source.ReconciliationIdNo
        WHERE reconciliation.IdNo IS NULL
           OR ISNULL(reconciliation.Posted, 0) = 1
    )
    BEGIN
        RAISERROR (''The reconciliation does not exist or has already been posted.'', 16, 1);
        RETURN;
    END;

    DECLARE @SourceValidation TABLE (
        JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        JournalItemIdNo int NULL,
        ReconciliationIdNo int NULL,
        SourceFound bit NOT NULL,
        LedgerAccountIdNo int NULL,
        LedgerTransactionDate date NULL,
        ReconciliationAccountIdNo int NOT NULL,
        ReconciliationDate date NOT NULL
    );

    SET NOCOUNT ON;

    INSERT INTO @SourceValidation (
        JournalCode,
        JournalItemIdNo,
        ReconciliationIdNo,
        SourceFound,
        LedgerAccountIdNo,
        LedgerTransactionDate,
        ReconciliationAccountIdNo,
        ReconciliationDate
    )
    SELECT
        source.JournalCode,
        source.JournalItemIdNo,
        source.ReconciliationIdNo,
        CASE WHEN ledger.IdNo IS NULL THEN 0 ELSE 1 END,
        ledger.AccountIdNo,
        ledger.TransactionDate,
        reconciliation.AccountIdNo,
        reconciliation.ReconciliationDate
    FROM @MParam AS source
    INNER JOIN dbo.AccountReconciliation AS reconciliation
        ON reconciliation.IdNo = source.ReconciliationIdNo
    LEFT JOIN dbo.GlLedgers_View AS ledger
        ON ledger.JournalCode = source.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS
       AND ledger.IdNo = source.JournalItemIdNo;

    SET NOCOUNT OFF;

    IF EXISTS (
        SELECT 1
        FROM @SourceValidation
        WHERE SourceFound = 0
    )
    BEGIN
        RAISERROR (''One or more reconciliation transactions are missing or cancelled.'', 16, 1);
        RETURN;
    END;

    IF EXISTS (
        SELECT 1
        FROM @SourceValidation
        WHERE SourceFound = 1
          AND LedgerAccountIdNo <> ReconciliationAccountIdNo
    )
    BEGIN
        RAISERROR (''One or more transactions belong to a different reconciliation account.'', 16, 1);
        RETURN;
    END;

    IF EXISTS (
        SELECT 1
        FROM @SourceValidation
        WHERE SourceFound = 1
          AND LedgerTransactionDate > ReconciliationDate
    )
    BEGIN
        RAISERROR (''One or more transactions are dated after the reconciliation date.'', 16, 1);
        RETURN;
    END;

    IF EXISTS (
        SELECT 1
        FROM @MParam AS source
        INNER JOIN dbo.Reconciled AS existing WITH (UPDLOCK, HOLDLOCK)
            ON existing.JournalCode = source.JournalCode
           AND existing.JournalItemIdNo = source.JournalItemIdNo
    )
    BEGIN
        RAISERROR (''One or more transactions have already been reconciled.'', 16, 1);
        RETURN;
    END;

    INSERT INTO dbo.Reconciled (JournalCode, JournalItemIdNo, ReconciliationIdNo)
        SELECT JournalCode, JournalItemIdNo, ReconciliationIdNo
        FROM @MParam;
END;
';

    IF OBJECT_DEFINITION(OBJECT_ID(N'dbo.AccountReconciliationItem_View')) LIKE N'%RIGHT OUTER JOIN dbo.GlLedgers_View%'
        RAISERROR('AccountReconciliationItem_View still contains the duplicate-producing marker join.', 16, 1);

    IF OBJECT_DEFINITION(OBJECT_ID(N'dbo.GlReconciliation_View')) NOT LIKE N'%MIN(IdNo)%'
        RAISERROR('GlReconciliation_View grouped-marker verification failed.', 16, 1);

    IF OBJECT_DEFINITION(OBJECT_ID(N'dbo.InsertReconciledTVP')) NOT LIKE N'%DECLARE @SourceValidation TABLE%'
       OR OBJECT_DEFINITION(OBJECT_ID(N'dbo.InsertReconciledTVP')) NOT LIKE N'%already been reconciled%'
       OR OBJECT_DEFINITION(OBJECT_ID(N'dbo.InsertReconciledTVP')) NOT LIKE N'%SET NOCOUNT ON;%INSERT INTO @SourceValidation%'
        RAISERROR('InsertReconciledTVP verification failed.', 16, 1);

    IF (SELECT COUNT(*) FROM dbo.AccountReconciliation) <> @ReconciliationHeadersBefore
       OR (SELECT COUNT(*) FROM dbo.AccountReconciliationItem) <> @ReconciliationItemsBefore
       OR (SELECT COUNT(*) FROM dbo.Reconciled) <> @MarkersBefore
        RAISERROR('Reconciliation table counts changed unexpectedly during schema deployment.', 16, 1);

    IF
    (
        SELECT COUNT(*)
        FROM
        (
            SELECT JournalCode, JournalItemIdNo, ReconciliationIdNo
            FROM dbo.Reconciled
            GROUP BY JournalCode, JournalItemIdNo, ReconciliationIdNo
            HAVING COUNT(*) > 1
        ) AS SameParentDuplicates
    ) <> @SameParentDuplicateGroupsBefore
        RAISERROR('Same-reconciliation duplicate groups changed unexpectedly.', 16, 1);

    IF
    (
        SELECT COUNT(*)
        FROM
        (
            SELECT JournalCode, JournalItemIdNo
            FROM dbo.Reconciled
            GROUP BY JournalCode, JournalItemIdNo
            HAVING COUNT(DISTINCT ReconciliationIdNo) > 1
        ) AS CrossParentConflicts
    ) <> @CrossParentConflictGroupsBefore
        RAISERROR('Cross-reconciliation conflict groups changed unexpectedly.', 16, 1);

    IF (SELECT COUNT(*) FROM dbo.GlReconciliation_View)
       <> (SELECT COUNT(*) FROM dbo.GlLedgers_View)
        RAISERROR('GlReconciliation_View does not return one row per ledger row.', 16, 1);

    IF (SELECT COUNT(IdNo) FROM dbo.AccountReconciliationItem_View)
       <> (SELECT COUNT(DISTINCT IdNo) FROM dbo.AccountReconciliationItem_View)
        RAISERROR('AccountReconciliationItem_View still repeats reconciliation item IDs.', 16, 1);

    COMMIT TRANSACTION;

    SELECT
        @@SERVERNAME AS ServerName,
        DB_NAME() AS DatabaseName,
        N'DEPLOYMENT SUCCEEDED' AS DeploymentStatus,
        @ReconciliationHeadersBefore AS ReconciliationHeadersUnchanged,
        @ReconciliationItemsBefore AS ReconciliationItemsUnchanged,
        @MarkersBefore AS MarkersUnchanged,
        @SameParentDuplicateGroupsBefore AS SameParentDuplicateGroupsUnchanged,
        @CrossParentConflictGroupsBefore AS CrossParentConflictGroupsUnchanged;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
