CREATE VIEW dbo.CashDisbursementJournalTransaction_View
AS
SELECT        dbo.CashDisbursementJournal.IdNo, dbo.CashDisbursementJournal.TransactionDate, dbo.CashDisbursementJournal.ReferenceNo, dbo.CashDisbursementJournal.Amount, dbo.CashDisbursementJournal.PayeeIdNo, 
                         dbo.CashDisbursementJournal.PaymentType, dbo.CashDisbursementJournal.PayeeName, dbo.CashDisbursementJournalItem.Sequence, dbo.CashDisbursementJournalItem.Debit, dbo.CashDisbursementJournalItem.Credit, 
                         dbo.CashDisbursementJournalItem.RevCostCenterIdNo, dbo.CashDisbursementJournalItem.Notes, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, 
                         dbo.Employee.EmployeeNameAra, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.CashDisbursementJournal.Notes AS CdNote, dbo.BankAccount.BranchName, dbo.Bank.BankCode, 
                         dbo.Bank.BankName, dbo.Bank.BankNameAra
FROM            dbo.BankAccount LEFT OUTER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo RIGHT OUTER JOIN
                         dbo.CashDisbursementJournal ON dbo.BankAccount.AccountIdNo = dbo.CashDisbursementJournal.AccountIdNo LEFT OUTER JOIN
                         dbo.Account RIGHT OUTER JOIN
                         dbo.CashDisbursementJournalItem ON dbo.Account.IdNo = dbo.CashDisbursementJournalItem.AccountIdNo LEFT OUTER JOIN
                         dbo.RevCostCenter ON dbo.CashDisbursementJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IDNo ON dbo.CashDisbursementJournal.IdNo = dbo.CashDisbursementJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Customer ON dbo.CashDisbursementJournal.PayeeIdNo = dbo.Customer.IdNo LEFT OUTER JOIN
                         dbo.Supplier ON dbo.CashDisbursementJournal.PayeeIdNo = dbo.Supplier.IdNo LEFT OUTER JOIN
                         dbo.Employee ON dbo.CashDisbursementJournal.PayeeIdNo = dbo.Employee.IdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CashDisbursementJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'          End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 246
               Left = 524
               Bottom = 545
               Right = 718
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 251
               Left = 294
               Bottom = 547
               Right = 485
            End
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
         Column = 1440
         Alias = 900
         Table = 3600
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CashDisbursementJournalTransaction_View';


GO


