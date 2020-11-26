

CREATE VIEW [dbo].[PcJournalItem_View]
AS
SELECT        dbo.PcJournalItem.AccountIdNo, dbo.PcJournalItem.Credit, dbo.PcJournalItem.Debit, dbo.PcJournalItem.IdNo, 
                         dbo.PcJournalItem.JournalIdNo, dbo.PcJournalItem.Notes, dbo.PcJournalItem.RevCostCenterIdNo, dbo.PcJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.PcJournalItem.Debit - dbo.PcJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.PcJournal LEFT OUTER JOIN
                         dbo.PcJournalItem ON dbo.PcJournal.IdNo = dbo.PcJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.PcJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.PcJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo