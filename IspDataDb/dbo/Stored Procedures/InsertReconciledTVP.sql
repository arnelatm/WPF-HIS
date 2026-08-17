









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
