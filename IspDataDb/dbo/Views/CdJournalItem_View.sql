
CREATE VIEW [dbo].[CdJournalItem_View]
AS
SELECT        dbo.CdJournalItem.AccountIdNo, dbo.CdJournalItem.Credit, dbo.CdJournalItem.Debit, dbo.CdJournalItem.IdNo, 
                         dbo.CdJournalItem.JournalIdNo, dbo.CdJournalItem.Notes, dbo.CdJournalItem.RevCostCenterIdNo, dbo.CdJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.CdJournalItem.Debit - dbo.CdJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CdJournal LEFT OUTER JOIN
                         dbo.CdJournalItem ON dbo.CdJournal.IdNo = dbo.CdJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.CdJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CdJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo