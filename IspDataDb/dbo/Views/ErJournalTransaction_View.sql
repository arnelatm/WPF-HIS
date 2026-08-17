
CREATE VIEW [dbo].[ErJournalTransaction_View]
AS
SELECT        dbo.ErJournalItem.Sequence, dbo.ErJournalItem.JournalIdNo, dbo.ErJournalItem.Debit, dbo.ErJournalItem.Credit, dbo.ErJournalItem.Notes, dbo.ErJournalItem.Posted, dbo.Employee.EmployeeCode, 
                         dbo.ErJournal.TransactionDate, dbo.ErJournal.ReferenceNo, dbo.ErJournal.Amount, dbo.ErJournal.Notes AS ErNotes, dbo.ErJournal.Cancelled, dbo.Account.AccountCode, dbo.Account.AccountName, 
                         dbo.Account.AccountNameAra, dbo.RevCostCenter.RevCostCenterCode, dbo.Employee.EmployeeNameAra, dbo.Employee.Title, dbo.Employee.EmployeeName
FROM            dbo.RevCostCenter RIGHT OUTER JOIN
                         dbo.ErJournalItem ON dbo.RevCostCenter.IdNo = dbo.ErJournalItem.RevCostCenterIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.ErJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ErJournal LEFT OUTER JOIN
                         dbo.Employee ON dbo.ErJournal.EmployeeIdNo = dbo.Employee.IdNo ON dbo.ErJournalItem.JournalIdNo = dbo.ErJournal.IDNo

GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'  Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ErJournalTransaction_View';


GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ErJournalTransaction_View';


GO

