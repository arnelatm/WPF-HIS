

CREATE VIEW [dbo].[SalesJournalTransaction_View]
AS
SELECT        dbo.SalesJournalItem.Sequence, dbo.SalesJournalItem.JournalIdNo, dbo.SalesJournalItem.AccountIdNo, dbo.SalesJournalItem.Debit, dbo.SalesJournalItem.Credit, 
                         dbo.SalesJournalItem.RevCostCenterIdNo, dbo.SalesJournalItem.Notes, dbo.SalesJournalItem.Posted, dbo.SalesJournal.TransactionDate, dbo.SalesJournal.Notes AS GJNotes, 
                         dbo.SalesJournal.Cancelled, dbo.SalesJournal.ReferenceNo, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, 
                         dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.RevCostCenter.RevCostCenterNameAra
FROM            dbo.RevCostCenter RIGHT OUTER JOIN
                         dbo.SalesJournalItem ON dbo.RevCostCenter.IdNo = dbo.SalesJournalItem.RevCostCenterIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.SalesJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.SalesJournal ON dbo.SalesJournalItem.JournalIdNo = dbo.SalesJournal.IdNo