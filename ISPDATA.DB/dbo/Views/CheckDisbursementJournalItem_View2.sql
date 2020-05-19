
CREATE VIEW [dbo].[CheckDisbursementJournalItem_View2]
AS
SELECT        dbo.CheckDisbursementJournalItem.AccountIdNo, dbo.CheckDisbursementJournalItem.Credit, dbo.CheckDisbursementJournalItem.Debit, dbo.CheckDisbursementJournalItem.IdNo, 
              dbo.CheckDisbursementJournalItem.JournalIdNo, dbo.CheckDisbursementJournalItem.Notes, dbo.CheckDisbursementJournalItem.ProfitCenterIdNo, dbo.CheckDisbursementJournalItem.Sequence, 
              dbo.Chart.AccountName, dbo.CheckDisbursementJournalItem.Debit - dbo.CheckDisbursementJournalItem.Credit AS OriginalAmount, dbo.Chart.PayeeType, dbo.Chart.SpecialAccount, 0 AS OpenInvoiceIdNo, 
              0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM          dbo.CheckDisbursementJournal 
				LEFT OUTER JOIN dbo.CheckDisbursementJournalItem 
				ON dbo.CheckDisbursementJournal.IdNo = dbo.CheckDisbursementJournalItem.JournalIdNo 
				LEFT OUTER JOIN dbo.Chart 
				ON dbo.CheckDisbursementJournalItem.AccountIdNo = dbo.Chart.IDNo 
				LEFT OUTER JOIN dbo.ApOpenInvoice 
				ON dbo.CheckDisbursementJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo AND dbo.ApOpenInvoice.JournalCode = 'CK'
