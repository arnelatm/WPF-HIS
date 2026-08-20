CREATE OR ALTER PROCEDURE dbo.DeleteApJournalAtomic
    @JournalIdNo int
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.ApJournal WHERE IdNo = @JournalIdNo)
        THROW 51030, 'AP journal was not found.', 1;
    IF EXISTS (SELECT 1 FROM dbo.Reconciled r
               INNER JOIN dbo.ApJournalItem i ON i.IdNo = r.JournalItemIdNo
               WHERE r.JournalCode = 'AP' AND i.JournalIdNo = @JournalIdNo)
        THROW 51031, 'AP journal contains reconciled detail lines and cannot be deleted.', 1;
    IF EXISTS (SELECT 1 FROM dbo.ApOpenInvoice o
               WHERE o.JournalCode = 'AP' AND o.JournalIdNo = @JournalIdNo
                 AND (EXISTS (SELECT 1 FROM dbo.CdOiItem d WHERE d.ApOpenInvoiceIdNo=o.IdNo)
                   OR EXISTS (SELECT 1 FROM dbo.CkOiItem k WHERE k.ApOpenInvoiceIdNo=o.IdNo)
                   OR EXISTS (SELECT 1 FROM dbo.PcOiItem p WHERE p.ApOpenInvoiceIdNo=o.IdNo)))
        THROW 51032, 'AP journal has dependent payment records and cannot be deleted.', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        DELETE FROM dbo.ApOpenInvoice WHERE JournalCode='AP' AND JournalIdNo=@JournalIdNo;
        DELETE FROM dbo.ApJournalItem WHERE JournalIdNo=@JournalIdNo;
        DELETE FROM dbo.ApJournal WHERE IdNo=@JournalIdNo;
        IF @@ROWCOUNT <> 1 THROW 51033, 'AP journal deletion failed.', 1;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
