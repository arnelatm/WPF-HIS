









CREATE   PROC [dbo].[InsertReconciledTVP]
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
        RAISERROR ('The reconciliation contains duplicate transaction references.', 16, 1);
        RETURN;
    END;

    IF (
        SELECT COUNT(DISTINCT ReconciliationIdNo)
        FROM @MParam
    ) > 1
    BEGIN
        RAISERROR ('All transaction references must belong to the same reconciliation.', 16, 1);
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
        RAISERROR ('The reconciliation does not exist or has already been posted.', 16, 1);
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
        RAISERROR ('One or more reconciliation transactions are missing or cancelled.', 16, 1);
        RETURN;
    END;

    IF EXISTS (
        SELECT 1
        FROM @SourceValidation
        WHERE SourceFound = 1
          AND LedgerAccountIdNo <> ReconciliationAccountIdNo
    )
    BEGIN
        RAISERROR ('One or more transactions belong to a different reconciliation account.', 16, 1);
        RETURN;
    END;

    IF EXISTS (
        SELECT 1
        FROM @SourceValidation
        WHERE SourceFound = 1
          AND LedgerTransactionDate > ReconciliationDate
    )
    BEGIN
        RAISERROR ('One or more transactions are dated after the reconciliation date.', 16, 1);
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
        RAISERROR ('One or more transactions have already been reconciled.', 16, 1);
        RETURN;
    END;

    INSERT INTO dbo.Reconciled (JournalCode, JournalItemIdNo, ReconciliationIdNo)
        SELECT JournalCode, JournalItemIdNo, ReconciliationIdNo
        FROM @MParam;
END;
