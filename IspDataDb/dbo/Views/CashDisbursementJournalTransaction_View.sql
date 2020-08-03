CREATE VIEW dbo.CashDisbursementJournalTransaction_View
AS
SELECT        dbo.CashDisbursementJournal.IdNo, dbo.CashDisbursementJournal.TransactionDate, dbo.CashDisbursementJournal.ReferenceNo, dbo.CashDisbursementJournal.Amount, dbo.CashDisbursementJournal.PayeeIdNo, 
                         dbo.CashDisbursementJournal.PaymentType, dbo.CashDisbursementJournal.PayeeName, dbo.CashDisbursementJournalItem.Sequence, dbo.CashDisbursementJournalItem.Debit, dbo.CashDisbursementJournalItem.Credit, 
                         dbo.CashDisbursementJournalItem.RevCostCenterIdNo, dbo.CashDisbursementJournalItem.Notes, dbo.Chart.AccountCode, dbo.Chart.AccountName, dbo.Chart.AccountNameAra, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, 
                         dbo.Employee.EmployeeNameAra, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.CashDisbursementJournal.Notes AS CdNote, dbo.BankAccount.BranchName, dbo.Bank.BankCode, 
                         dbo.Bank.BankName, dbo.Bank.BankNameAra
FROM            dbo.BankAccount LEFT OUTER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo RIGHT OUTER JOIN
                         dbo.CashDisbursementJournal ON dbo.BankAccount.AccountIdNo = dbo.CashDisbursementJournal.AccountIdNo LEFT OUTER JOIN
                         dbo.Chart RIGHT OUTER JOIN
                         dbo.CashDisbursementJournalItem ON dbo.Chart.IdNo = dbo.CashDisbursementJournalItem.AccountIdNo LEFT OUTER JOIN
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
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[23] 4[58] 2[3] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -288
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BankAccount"
            Begin Extent = 
               Top = 6
               Left = 1072
               Bottom = 397
               Right = 1242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Bank"
            Begin Extent = 
               Top = 6
               Left = 1280
               Bottom = 415
               Right = 1453
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CashDisbursementJournal"
            Begin Extent = 
               Top = 9
               Left = 14
               Bottom = 460
               Right = 263
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 4
               Left = 528
               Bottom = 134
               Right = 727
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CashDisbursementJournalItem"
            Begin Extent = 
               Top = 15
               Left = 301
               Bottom = 223
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RevCostCenter"
            Begin Extent = 
               Top = 104
               Left = 817
               Bottom = 234
               Right = 1034
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Customer"
            Begin Extent = 
               Top = 246
               Left = 752
               Bottom = 556
               Right = 956
  ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CashDisbursementJournalTransaction_View';

