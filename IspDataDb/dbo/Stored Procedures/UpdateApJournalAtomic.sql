CREATE OR ALTER PROCEDURE dbo.UpdateApJournalAtomic
    @JournalIdNo int,
    @SupplierIdNo int,
    @TransactionDate date,
    @ReferenceNo varchar(15) = NULL,
    @TransactionType char(1) = NULL,
    @Amount money,
    @AccountIdNo int,
    @DueDate date = NULL,
    @SettlementDueDate date = NULL,
    @SettlementDiscount decimal(5,2) = NULL,
    @InvoiceNo varchar(15),
    @InvoiceDate date = NULL,
    @VatNumber varchar(15) = NULL,
    @VatAmount money = NULL,
    @Notes nvarchar(600),
    @Approved bit = 0,
    @Posted bit = 0,
    @Items dbo.JournalItemInsert READONLY
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.ApJournal WHERE IdNo = @JournalIdNo)
        THROW 51020, 'AP journal was not found.', 1;
    IF EXISTS (SELECT 1 FROM dbo.Reconciled r
               INNER JOIN dbo.ApJournalItem i ON i.IdNo = r.JournalItemIdNo
               WHERE r.JournalCode = 'AP' AND i.JournalIdNo = @JournalIdNo)
        THROW 51025, 'AP journal contains reconciled detail lines and cannot be edited.', 1;
    IF @TransactionDate >= '20260101' AND NOT EXISTS (SELECT 1 FROM @Items)
        THROW 51021, 'AP journal must contain at least one detail line.', 1;
    IF EXISTS (SELECT 1 FROM dbo.ApOpenInvoice o
               WHERE o.JournalCode = 'AP' AND o.JournalIdNo = @JournalIdNo
                 AND (EXISTS (SELECT 1 FROM dbo.CdOiItem d WHERE d.ApOpenInvoiceIdNo=o.IdNo)
                   OR EXISTS (SELECT 1 FROM dbo.CkOiItem k WHERE k.ApOpenInvoiceIdNo=o.IdNo)
                   OR EXISTS (SELECT 1 FROM dbo.PcOiItem p WHERE p.ApOpenInvoiceIdNo=o.IdNo)))
        THROW 51022, 'AP journal has dependent payment records and cannot be edited.', 1;
    IF @TransactionDate >= '20260101' AND EXISTS (
        SELECT 1 FROM @Items WHERE Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0))
        THROW 51023, 'AP detail lines contain invalid debit/credit values.', 1;
    IF @TransactionDate >= '20260101' AND
       ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items) -
           (SELECT COALESCE(SUM(Credit),0) FROM @Items)) > 0.01
        THROW 51024, 'AP journal debits and credits are not balanced.', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE dbo.ApJournal SET SupplierIdNo=@SupplierIdNo, TransactionDate=@TransactionDate,
            ReferenceNo=@ReferenceNo, TransactionType=@TransactionType, Amount=@Amount,
            AccountIdNo=@AccountIdNo, DueDate=@DueDate, SettlementDueDate=@SettlementDueDate,
            SettlementDiscount=@SettlementDiscount, InvoiceNo=@InvoiceNo, InvoiceDate=@InvoiceDate,
            VatNumber=@VatNumber, VatAmount=@VatAmount, Notes=@Notes, Approved=@Approved, Posted=@Posted
        WHERE IdNo=@JournalIdNo;

        DELETE FROM dbo.ApOpenInvoice WHERE JournalCode='AP' AND JournalIdNo=@JournalIdNo;
        DELETE FROM dbo.ApJournalItem WHERE JournalIdNo=@JournalIdNo;
        INSERT dbo.ApJournalItem (AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence)
        SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
        INSERT dbo.ApOpenInvoice (JournalCode,JournalIdNo,JournalItemIdNo,PaidAmount,DiscountTaken)
        SELECT 'AP',@JournalIdNo,i.IdNo,0,0 FROM dbo.ApJournalItem i
        INNER JOIN dbo.Account a ON a.IdNo=i.AccountIdNo
        WHERE i.JournalIdNo=@JournalIdNo AND a.SpecialAccount='AP';
        IF @VatNumber IS NOT NULL AND LTRIM(RTRIM(@VatNumber)) <> ''
            UPDATE dbo.Supplier SET VatNumber=@VatNumber
            WHERE IdNo=@SupplierIdNo AND (VatNumber IS NULL OR VatNumber='');
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
