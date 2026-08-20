CREATE OR ALTER PROCEDURE dbo.UpdateArJournalAtomic
 @JournalIdNo int,@CustomerIdNo int,@TransactionDate date,@ReferenceNo varchar(15)=NULL,@TransactionType char(1)=NULL,@Amount money,@AccountIdNo int,@DueDate date=NULL,@SettlementDueDate date=NULL,@SettlementDiscount decimal(5,2)=NULL,@InvoiceNo varchar(15),@InvoiceDate date=NULL,@Notes nvarchar(600),@VatAmount money=NULL,@Approved bit=0,@Posted bit=0,@Items dbo.JournalItemInsert READONLY
AS
BEGIN
 SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.ArJournal WHERE IdNo=@JournalIdNo) THROW 51110,'AR journal was not found.',1;
 IF EXISTS(SELECT 1 FROM dbo.Reconciled r INNER JOIN dbo.ArJournalItem i ON i.IdNo=r.JournalItemIdNo WHERE r.JournalCode='AR' AND i.JournalIdNo=@JournalIdNo) THROW 51111,'AR journal contains reconciled detail lines and cannot be edited.',1;
 IF EXISTS(SELECT 1 FROM dbo.ArOpenInvoice o WHERE o.JournalCode='AR' AND o.JournalIdNo=@JournalIdNo AND EXISTS(SELECT 1 FROM dbo.CsrOiItem c WHERE c.ArOpenInvoiceIdNo=o.IdNo)) THROW 51112,'AR journal has CR collections and cannot be edited.',1;
 IF @TransactionDate>='20260101' AND (NOT EXISTS(SELECT 1 FROM @Items) OR ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items))>.01) THROW 51113,'AR journal details are not balanced.',1;
 BEGIN TRANSACTION;
 BEGIN TRY
  UPDATE dbo.ArJournal SET CustomerIdNo=@CustomerIdNo,TransactionDate=@TransactionDate,ReferenceNo=@ReferenceNo,TransactionType=@TransactionType,Amount=@Amount,AccountIdNo=@AccountIdNo,DueDate=@DueDate,SettlementDueDate=@SettlementDueDate,SettlementDiscount=@SettlementDiscount,InvoiceNo=@InvoiceNo,InvoiceDate=@InvoiceDate,Notes=@Notes,VatAmount=@VatAmount,Approved=@Approved,Posted=@Posted WHERE IdNo=@JournalIdNo;
  DELETE FROM dbo.ArOpenInvoice WHERE JournalCode='AR' AND JournalIdNo=@JournalIdNo;
  DELETE FROM dbo.ArJournalItem WHERE JournalIdNo=@JournalIdNo;
  INSERT dbo.ArJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence) SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
  INSERT dbo.ArOpenInvoice(JournalCode,JournalIdNo,JournalItemIdNo,PaidAmount,DiscountTaken) SELECT 'AR',@JournalIdNo,i.IdNo,0,0 FROM dbo.ArJournalItem i INNER JOIN dbo.Account a ON a.IdNo=i.AccountIdNo WHERE i.JournalIdNo=@JournalIdNo AND a.SpecialAccount='AR';
  COMMIT TRANSACTION;
 END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK TRANSACTION; THROW; END CATCH;
END;
GO
