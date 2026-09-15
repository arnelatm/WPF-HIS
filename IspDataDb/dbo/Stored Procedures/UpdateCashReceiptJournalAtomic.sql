CREATE PROCEDURE dbo.UpdateCashReceiptJournalAtomic
 @JournalIdNo int,@TransactionDate date,@ReferenceNo varchar(15)=NULL,@Amount money,@AccountIdNo smallint,@PayorType char(1)=NULL,@PayorIdNo int=NULL,@PayorName nvarchar(50)=NULL,@CheckNumber varchar(10)=NULL,@CheckDate date=NULL,@ORNumber varchar(15)=NULL,@DiscountTaken money=NULL,@DiscountAccountIdNo smallint=NULL,@Applied money=NULL,@UnApplied money=NULL,@VatAmount money=NULL,@VatNumber varchar(15)=NULL,@Notes nvarchar(300)=NULL,@Posted bit=0,@Approved bit=0,@Cancelled bit=0,@Items dbo.JournalItemInsert READONLY,@OiItems dbo.CsrOiItemInsert READONLY
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.CashReceiptJournal WHERE IdNo=@JournalIdNo) THROW 51120,'Cash receipt was not found.',1;
 IF EXISTS(SELECT 1 FROM dbo.CashReceiptJournal WHERE IdNo=@JournalIdNo AND Posted=1) THROW 51121,'Posted cash receipts cannot be edited.',1;
 IF EXISTS(SELECT 1 FROM dbo.CashReceiptJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='CR' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51122,'Reconciled cash receipts cannot be edited.',1;
 EXEC dbo.AssertJournalNotReconciliationLocked @JournalCode='CR', @JournalIdNo=@JournalIdNo;
 IF @TransactionDate>='20260101' AND (NOT EXISTS(SELECT 1 FROM @Items) OR ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items)) > 0.00005) THROW 51123,'Cash receipt details are not balanced.',1;
 IF @TransactionDate >= '20260101' AND ABS(COALESCE(@Applied,0)+COALESCE(@UnApplied,0)-COALESCE(@Amount,0)) > 0.00005 THROW 51124,'Cash receipt applied and unapplied amounts do not equal the receipt amount.',1;
 IF @TransactionDate >= '20260101' AND @PayorType='A' AND ABS((SELECT COALESCE(SUM(Amount),0) FROM @OiItems)-COALESCE(@Applied,0)) > 0.00005 THROW 51125,'Cash receipt allocations do not equal the applied amount.',1;
 IF @TransactionDate >= '20260101' AND EXISTS (SELECT 1 FROM @OiItems WHERE COALESCE(Amount,0)=0 AND COALESCE(DiscountTaken,0)=0) THROW 51126,'Cash receipt contains a zero-value invoice allocation.',1;
 IF @TransactionDate >= '20260101' AND @PayorType='A' AND EXISTS (SELECT 1 FROM @OiItems i LEFT JOIN dbo.ArOpenInvoice_View v ON v.IdNo=i.ArOpenInvoiceIdNo WHERE v.IdNo IS NULL OR v.CustomerIdNo IS NULL OR @PayorIdNo IS NULL OR v.CustomerIdNo<>@PayorIdNo) THROW 51127,'Cash receipt allocation does not belong to the selected customer.',1;
 IF @TransactionDate >= '20260101' AND NULLIF(LTRIM(RTRIM(@ReferenceNo)), '') IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.CashReceiptJournal r WHERE r.IdNo<>@JournalIdNo AND r.TransactionDate=@TransactionDate AND ISNULL(r.ReferenceNo,'')=ISNULL(@ReferenceNo,'') AND r.PayorType=@PayorType AND ISNULL(r.PayorIdNo,0)=ISNULL(@PayorIdNo,0) AND r.Amount=@Amount AND r.Cancelled=0) THROW 51128,'A matching cash receipt already exists.',1;
 BEGIN TRAN; BEGIN TRY
  DELETE FROM dbo.CsrOiItem WHERE CsrIdNo=@JournalIdNo; DELETE FROM dbo.CashReceiptJournalItem WHERE JournalIdNo=@JournalIdNo;
  UPDATE dbo.CashReceiptJournal SET TransactionDate=@TransactionDate,ReferenceNo=@ReferenceNo,Amount=@Amount,AccountIdNo=@AccountIdNo,PayorType=@PayorType,PayorIdNo=@PayorIdNo,Payorname=@PayorName,CheckNumber=@CheckNumber,CheckDate=@CheckDate,ORNumber=@ORNumber,DiscountTaken=@DiscountTaken,DiscountAccountIdNo=@DiscountAccountIdNo,Applied=@Applied,UnApplied=@UnApplied,VatAmount=@VatAmount,VatNumber=@VatNumber,Notes=@Notes,Posted=@Posted,Approved=@Approved,Cancelled=@Cancelled WHERE IdNo=@JournalIdNo;
  INSERT dbo.CashReceiptJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence) SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
  INSERT dbo.CsrOiItem(Amount,ArOpenInvoiceIdNo,CsrIdNo,DiscountTaken,Sequence) SELECT Amount,ArOpenInvoiceIdNo,@JournalIdNo,DiscountTaken,Sequence FROM @OiItems;
  COMMIT;
 END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK; THROW; END CATCH END;
GO
