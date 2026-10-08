CREATE PROCEDURE dbo.UpdateGjJournalAtomic
 @JournalIdNo int,@TransactionDate date,@ReferenceNo nvarchar(10)=NULL,@Notes nvarchar(300)=NULL,@Approved bit=0,@Posted bit=0,@ClosingJournal bit=0,@Cancelled bit=0,@Items dbo.JournalItemInsert READONLY
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.GeneralJournal WHERE IdNo=@JournalIdNo) THROW 51320,'General journal entry was not found.',1;
 IF EXISTS(SELECT 1 FROM dbo.GeneralJournal WHERE IdNo=@JournalIdNo AND Posted=1) THROW 51321,'Posted general journal entries cannot be edited.',1;
 IF EXISTS(SELECT 1 FROM dbo.GeneralJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='GJ' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51322,'Reconciled general journal entries cannot be edited.',1;
 IF EXISTS(SELECT 1 FROM dbo.ArOpenInvoice o JOIN dbo.CsrOiItem c ON c.ArOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='GJ' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.CdOiItem c ON c.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='GJ' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.PcOiItem p ON p.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='GJ' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.CkOiItem k ON k.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='GJ' AND o.JournalIdNo=@JournalIdNo) THROW 51333,'General journal open invoices with allocations cannot be edited.',1;
 EXEC dbo.AssertJournalNotReconciliationLocked @JournalCode='GJ', @JournalIdNo=@JournalIdNo;
 IF @TransactionDate>='20260101' AND EXISTS(SELECT 1 FROM @Items WHERE Debit<0 OR Credit<0 OR (Debit<>0 AND Credit<>0)) THROW 51324,'General journal detail lines contain invalid debit/credit values.',1;
 IF @TransactionDate>='20260101' AND EXISTS(SELECT 1 FROM @Items WHERE AccountIdNo=0 AND (Debit<>0 OR Credit<>0)) THROW 51325,'General journal detail lines require an account.',1;
 IF @TransactionDate>='20260101' AND (NOT EXISTS(SELECT 1 FROM @Items) OR ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items)) > 0.00005) THROW 51323,'General journal details are not balanced.',1;
 IF @ClosingJournal=0 AND @Cancelled=0 AND EXISTS(SELECT 1 FROM @Items i JOIN dbo.Account a ON a.IdNo=i.AccountIdNo WHERE a.SpecialAccount='AR' AND (i.Debit<>0 OR i.Credit<>0) AND dbo.FnResolveOpenInvoiceParty(i.PayIdNo,'C',NULL) IS NULL) THROW 51327,'An AR general journal line requires a customer contact.',1;
 IF @ClosingJournal=0 AND @Cancelled=0 AND EXISTS(SELECT 1 FROM @Items i JOIN dbo.Account a ON a.IdNo=i.AccountIdNo WHERE a.SpecialAccount='AP' AND (i.Debit<>0 OR i.Credit<>0) AND dbo.FnResolveOpenInvoiceParty(i.PayIdNo,'S',NULL) IS NULL) THROW 51328,'An AP general journal line requires a supplier contact.',1;
 BEGIN TRAN; BEGIN TRY
  DELETE FROM dbo.ArOpenInvoice WHERE JournalCode='GJ' AND JournalIdNo=@JournalIdNo; DELETE FROM dbo.ApOpenInvoice WHERE JournalCode='GJ' AND JournalIdNo=@JournalIdNo; DELETE FROM dbo.GeneralJournalItem WHERE JournalIdNo=@JournalIdNo;
  UPDATE dbo.GeneralJournal SET TransactionDate=@TransactionDate,ReferenceNo=@ReferenceNo,Notes=@Notes,Approved=@Approved,Posted=@Posted,ClosingJournal=@ClosingJournal,Cancelled=@Cancelled WHERE IdNo=@JournalIdNo;
  INSERT dbo.GeneralJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence) SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
  INSERT dbo.ArOpenInvoice(JournalCode,JournalIdNo,JournalItemIdNo) SELECT 'GJ',@JournalIdNo,i.IdNo FROM dbo.GeneralJournalItem i JOIN dbo.Account a ON a.IdNo=i.AccountIdNo WHERE i.JournalIdNo=@JournalIdNo AND @ClosingJournal=0 AND @Cancelled=0 AND a.SpecialAccount='AR' AND (i.Debit<>0 OR i.Credit<>0);
  INSERT dbo.ApOpenInvoice(JournalCode,JournalIdNo,JournalItemIdNo) SELECT 'GJ',@JournalIdNo,i.IdNo FROM dbo.GeneralJournalItem i JOIN dbo.Account a ON a.IdNo=i.AccountIdNo WHERE i.JournalIdNo=@JournalIdNo AND @ClosingJournal=0 AND @Cancelled=0 AND a.SpecialAccount='AP' AND (i.Debit<>0 OR i.Credit<>0); COMMIT;
 END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;THROW;END CATCH END;
GO
