


CREATE VIEW [dbo].[PettyCashJournalItem_View]
AS
SELECT        dbo.PettyCashJournalItem.AccountIdNo, dbo.PettyCashJournalItem.Credit, dbo.PettyCashJournalItem.Debit, dbo.PettyCashJournalItem.IdNo, 
                         dbo.PettyCashJournalItem.JournalIdNo, dbo.PettyCashJournalItem.Notes, dbo.PettyCashJournalItem.RevCostCenterIdNo, dbo.PettyCashJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.PettyCashJournalItem.Debit - dbo.PettyCashJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.PettyCashJournal LEFT OUTER JOIN
                         dbo.PettyCashJournalItem ON dbo.PettyCashJournal.IdNo = dbo.PettyCashJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.PettyCashJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.PettyCashJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo AND dbo.ApOpenInvoice.[JournalCode] = 'PC'
