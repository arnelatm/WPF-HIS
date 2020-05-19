
CREATE VIEW [dbo].[GeneralJournalItem_View]
AS
SELECT        dbo.GeneralJournalItem.IdNo, dbo.GeneralJournalItem.Sequence, dbo.GeneralJournalItem.JournalIdNo, dbo.GeneralJournalItem.AccountIdNo, dbo.GeneralJournalItem.Debit, dbo.GeneralJournalItem.Credit, 
                         dbo.GeneralJournalItem.ProfitCenterIdNo, dbo.GeneralJournalItem.Notes, dbo.Chart.AccountName, dbo.GeneralJournalItem.Debit - dbo.GeneralJournalItem.Credit AS OriginalAmount, dbo.Chart.PayeeType, 
                         dbo.Chart.SpecialAccount, 0 AS OpenInvoiceIdNo, 0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.GeneralJournalItem LEFT OUTER JOIN
                         dbo.Chart ON dbo.GeneralJournalItem.AccountIdNo = dbo.Chart.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.GeneralJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo AND dbo.ApOpenInvoice.JournalCode = 'GJ'
