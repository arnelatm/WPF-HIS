
CREATE VIEW [dbo].[GeneralJournalTransaction_View]
AS
SELECT        dbo.GeneralJournalItem.Sequence, dbo.GeneralJournalItem.JournalIdNo, dbo.GeneralJournalItem.AccountIdNo, dbo.GeneralJournalItem.Debit, dbo.GeneralJournalItem.Credit, 
                         dbo.GeneralJournalItem.RevCostCenterIdNo, dbo.GeneralJournalItem.Notes, dbo.GeneralJournalItem.Posted, dbo.GeneralJournal.TransactionDate, dbo.GeneralJournal.Notes AS GJNotes, 
                         dbo.GeneralJournal.ClosingJournal, dbo.GeneralJournal.Cancelled, dbo.GeneralJournal.ReferenceNo, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, 
                         dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.RevCostCenter.RevCostCenterNameAra
FROM            dbo.RevCostCenter RIGHT OUTER JOIN
                         dbo.GeneralJournalItem ON dbo.RevCostCenter.IdNo = dbo.GeneralJournalItem.RevCostCenterIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.GeneralJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.GeneralJournal ON dbo.GeneralJournalItem.JournalIdNo = dbo.GeneralJournal.IdNo

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'GeneralJournalTransaction_View';

