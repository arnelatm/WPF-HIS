CREATE PROCEDURE dbo.AssertJournalNotReconciliationLocked
    @JournalCode varchar(2),
    @JournalIdNo int
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Code varchar(2) = UPPER(LTRIM(RTRIM(@JournalCode)));

    /*
       AccountReconciliationItem stores the journal line reference, while
       each journal's item table stores the parent journal ID. Check the
       concrete item tables so this also covers rows that are not exposed by
       a reporting view.
    */
    IF EXISTS (
        SELECT 1
        FROM dbo.AccountReconciliationItem AS item
        INNER JOIN dbo.AccountReconciliation AS reconciliation
            ON reconciliation.IdNo = item.AccountReconciliationIdNo
        WHERE reconciliation.Status IN ('ReviewCompleted', 'Finalized')
          AND item.JournalCode = @Code COLLATE SQL_Latin1_General_CP1_CI_AS
          AND (
                (@Code = 'AP' AND EXISTS (SELECT 1 FROM dbo.ApJournalItem j WHERE j.IdNo = item.JournalItemIdNo AND j.JournalIdNo = @JournalIdNo))
             OR (@Code = 'AR' AND EXISTS (SELECT 1 FROM dbo.ArJournalItem j WHERE j.IdNo = item.JournalItemIdNo AND j.JournalIdNo = @JournalIdNo))
             OR (@Code = 'CD' AND EXISTS (SELECT 1 FROM dbo.CdJournalItem j WHERE j.IdNo = item.JournalItemIdNo AND j.JournalIdNo = @JournalIdNo))
             OR (@Code = 'CK' AND EXISTS (SELECT 1 FROM dbo.CkJournalItem j WHERE j.IdNo = item.JournalItemIdNo AND j.JournalIdNo = @JournalIdNo))
             OR (@Code = 'CR' AND EXISTS (SELECT 1 FROM dbo.CashReceiptJournalItem j WHERE j.IdNo = item.JournalItemIdNo AND j.JournalIdNo = @JournalIdNo))
             OR (@Code = 'ER' AND EXISTS (SELECT 1 FROM dbo.ErJournalItem j WHERE j.IdNo = item.JournalItemIdNo AND j.JournalIdNo = @JournalIdNo))
             OR (@Code = 'GJ' AND EXISTS (SELECT 1 FROM dbo.GeneralJournalItem j WHERE j.IdNo = item.JournalItemIdNo AND j.JournalIdNo = @JournalIdNo))
             OR (@Code = 'PC' AND EXISTS (SELECT 1 FROM dbo.PcJournalItem j WHERE j.IdNo = item.JournalItemIdNo AND j.JournalIdNo = @JournalIdNo))
             OR (@Code = 'SJ' AND EXISTS (SELECT 1 FROM dbo.SalesJournalItem j WHERE j.IdNo = item.JournalItemIdNo AND j.JournalIdNo = @JournalIdNo))
          )
    )
        THROW 51530, 'This journal is included in a completed or finalized account reconciliation. Reopen the reconciliation review before editing or deleting it.', 1;
END;
GO
