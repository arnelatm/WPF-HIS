
CREATE VIEW [dbo].[PettyCashJournalTransaction_View]
AS
SELECT        dbo.PettyCashJournal.IdNo, dbo.PettyCashJournal.TransactionDate, dbo.PettyCashJournal.ReferenceNo, dbo.PettyCashJournal.Amount, dbo.PettyCashJournal.PayeeIdNo, dbo.PettyCashJournal.PaymentType, 
                         dbo.PettyCashJournal.PayeeName, dbo.PettyCashJournalItem.Sequence, dbo.PettyCashJournalItem.Debit, dbo.PettyCashJournalItem.Credit, dbo.PettyCashJournalItem.RevCostCenterIdNo, 
                         dbo.PettyCashJournalItem.Notes, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.Customer.CustomerCode, dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, 
                         dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, dbo.Employee.EmployeeNameAra, 
                         dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.PettyCashJournal.Notes AS PcNote
FROM            dbo.Account RIGHT OUTER JOIN
                         dbo.PettyCashJournalItem ON dbo.Account.IdNo = dbo.PettyCashJournalItem.AccountIdNo LEFT OUTER JOIN
                         dbo.RevCostCenter ON dbo.PettyCashJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IdNo RIGHT OUTER JOIN
                         dbo.PettyCashJournal ON dbo.PettyCashJournalItem.JournalIdNo = dbo.PettyCashJournal.IdNo LEFT OUTER JOIN
                         dbo.Customer ON dbo.PettyCashJournal.PayeeIdNo = dbo.Customer.IdNo LEFT OUTER JOIN
                         dbo.Supplier ON dbo.PettyCashJournal.PayeeIdNo = dbo.Supplier.IdNo LEFT OUTER JOIN
                         dbo.Employee ON dbo.PettyCashJournal.PayeeIdNo = dbo.Employee.IdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PettyCashJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'd
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2430
         Alias = 1620
         Table = 3180
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PettyCashJournalTransaction_View';


GO




