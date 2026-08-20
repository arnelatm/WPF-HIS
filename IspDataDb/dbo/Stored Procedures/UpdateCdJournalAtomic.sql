CREATE PROCEDURE dbo.UpdateCdJournalAtomic
 @JournalIdNo int,@TransactionDate date,@ReferenceNo varchar(15)=NULL,@Amount money,@AccountIdNo smallint,@PaymentType char(1)=NULL,@PayType char(1)=NULL,@PayeeIdNo int=NULL,@PayeeName nvarchar(100)=NULL,@CheckNumber varchar(10)=NULL,@CheckDate date=NULL,@ORNumber varchar(15)=NULL,@DiscountTaken money=NULL,@DiscountAccountIdNo int=NULL,@Applied money=NULL,@UnApplied money=NULL,@VatNumber varchar(15)=NULL,@VatAmount money=NULL,@Notes nvarchar(300)=NULL,@PcClosed bit=0,@Approved bit=0,@Posted bit=0,@Cancelled bit=0,@Items dbo.JournalItemInsert READONLY,@OiItems dbo.CdOiItemInsert READONLY
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.CdJournal WHERE IdNo=@JournalIdNo) THROW 51220,'Cash disbursement was not found.',1;
 IF EXISTS(SELECT 1 FROM dbo.CdJournal WHERE IdNo=@JournalIdNo AND (Posted=1 OR PcClosed=1)) THROW 51221,'Posted or closed cash disbursements cannot be edited.',1;
 IF EXISTS(SELECT 1 FROM dbo.CdJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='CD' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51222,'Reconciled cash disbursements cannot be edited.',1;
 IF @TransactionDate>='20260101' AND (NOT EXISTS(SELECT 1 FROM @Items) OR ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items))>.01) THROW 51223,'Cash disbursement details are not balanced.',1;
 BEGIN TRAN; BEGIN TRY
  DELETE FROM dbo.CdOiItem WHERE DjIdNo=@JournalIdNo; DELETE FROM dbo.CdJournalItem WHERE JournalIdNo=@JournalIdNo;
  UPDATE dbo.CdJournal SET TransactionDate=@TransactionDate,ReferenceNo=@ReferenceNo,Amount=@Amount,AccountIdNo=@AccountIdNo,PaymentType=@PaymentType,PayType=@PayType,PayeeIdNo=@PayeeIdNo,PayeeName=@PayeeName,CheckNumber=@CheckNumber,CheckDate=@CheckDate,ORNumber=@ORNumber,DiscountTaken=@DiscountTaken,DiscountAccountIdNo=@DiscountAccountIdNo,Applied=@Applied,UnApplied=@UnApplied,VatNumber=@VatNumber,VatAmount=@VatAmount,Notes=@Notes,PcClosed=@PcClosed,Approved=@Approved,Posted=@Posted,Cancelled=@Cancelled WHERE IdNo=@JournalIdNo;
  INSERT dbo.CdJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence) SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
  INSERT dbo.CdOiItem(Amount,ApOpenInvoiceIdNo,DiscountTaken,DjIdNo,Sequence) SELECT Amount,ApOpenInvoiceIdNo,DiscountTaken,@JournalIdNo,Sequence FROM @OiItems;
  COMMIT;
 END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;THROW;END CATCH END;
GO
