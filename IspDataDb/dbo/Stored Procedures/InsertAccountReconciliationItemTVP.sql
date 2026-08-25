







CREATE PROC [dbo].[InsertAccountReconciliationItemTVP]
  @MParam AccountReconciliationItemInsert READONLY
AS 
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.AccountReconciliation ar
        INNER JOIN @MParam source ON source.AccountReconciliationIdNo = ar.IdNo
        WHERE ISNULL(ar.Posted, 0) = 1
           OR ISNULL(ar.Status, 'Draft') <> 'Draft'
    )
        THROW 51510, 'Completed or finalized reconciliations cannot be changed. Reopen the review first.', 1;

    IF EXISTS (
        SELECT 1
        FROM @MParam AS source
        INNER JOIN dbo.Reconciled AS existing WITH (UPDLOCK, HOLDLOCK)
            ON existing.JournalCode = source.JournalCode
           AND existing.JournalItemIdNo = source.JournalItemIdNo
    )
        THROW 51512, 'One or more transactions are already reserved by another reconciliation.', 1;

    INSERT INTO dbo.AccountReconciliationItem
        (AccountReconciliationIdNo, Cleared, JournalCode, JournalItemIdNo, Sequence)
    SELECT AccountReconciliationIdNo, Cleared, JournalCode, JournalItemIdNo, Sequence
    FROM @MParam;
END;

