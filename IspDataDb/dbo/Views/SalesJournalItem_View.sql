

CREATE VIEW [dbo].[SalesJournalItem_View]
AS
SELECT        dbo.SalesJournalItem.IdNo, dbo.SalesJournalItem.Sequence, dbo.SalesJournalItem.JournalIdNo, dbo.SalesJournalItem.AccountIdNo, dbo.SalesJournalItem.Debit, dbo.SalesJournalItem.Credit, 
                         dbo.SalesJournalItem.RevCostCenterIdNo, dbo.Account.AccountName, dbo.SalesJournalItem.Debit - dbo.SalesJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, dbo.SalesJournalItem.Notes, 
                         0 AS OpenInvoiceIdNo, 0 AS PaidAmount, 0 AS DiscountTaken
FROM            dbo.SalesJournalItem INNER JOIN
                         dbo.Account ON dbo.SalesJournalItem.AccountIdNo = dbo.Account.IDNo
