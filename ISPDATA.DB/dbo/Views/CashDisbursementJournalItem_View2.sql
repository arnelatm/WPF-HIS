
CREATE VIEW [dbo].[CashDisbursementJournalItem_View2]
AS
SELECT  dbo.CashDisbursementJournalItem.AccountIdNo, dbo.CashDisbursementJournalItem.Credit, dbo.CashDisbursementJournalItem.Debit, dbo.CashDisbursementJournalItem.IdNo, 
        dbo.CashDisbursementJournalItem.JournalIdNo, dbo.CashDisbursementJournalItem.Notes, dbo.CashDisbursementJournalItem.ProfitCenterIdNo, dbo.CashDisbursementJournalItem.Sequence, 
        dbo.Chart.AccountName, dbo.CashDisbursementJournalItem.Debit - dbo.CashDisbursementJournalItem.Credit AS OriginalAmount, dbo.Chart.PayeeType, dbo.Chart.SpecialAccount, 0 AS OpenInvoiceIdNo, 
		0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM	dbo.CashDisbursementJournalItem 
		RIGHT OUTER JOIN dbo.Chart
		ON dbo.CashDisbursementJournalItem.AccountIdNo = dbo.Chart.IDNo 
		LEFT OUTER JOIN dbo.CashDisbursementJournal 
		ON dbo.CashDisbursementJournalItem.JournalIdNo = dbo.CashDisbursementJournal.IdNo 
		LEFT OUTER JOIN dbo.ApOpenInvoice 
		ON dbo.CashDisbursementJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo AND dbo.ApOpenInvoice.[JournalCode] = 'CD'
