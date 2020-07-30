

CREATE VIEW [dbo].[SalesJournalItem_View]
AS
SELECT        dbo.SalesJournalItem.IdNo, dbo.SalesJournalItem.Sequence, dbo.SalesJournalItem.JournalIdNo, dbo.SalesJournalItem.AccountIdNo, dbo.SalesJournalItem.Debit, dbo.SalesJournalItem.Credit, 
                         dbo.SalesJournalItem.RevCostCenterIdNo, dbo.Chart.AccountName, dbo.SalesJournalItem.Debit - dbo.SalesJournalItem.Credit AS OriginalAmount, dbo.Chart.PayeeType, dbo.Chart.SpecialAccount, dbo.SalesJournalItem.Notes, 
                         0 AS OpenInvoiceIdNo, 0 AS PaidAmount, 0 AS DiscountTaken
FROM            dbo.SalesJournalItem INNER JOIN
                         dbo.Chart ON dbo.SalesJournalItem.AccountIdNo = dbo.Chart.IDNo
