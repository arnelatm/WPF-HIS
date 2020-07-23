CREATE VIEW dbo.PettyCashJournalTransaction_View
AS
SELECT        dbo.PettyCashJournal.IdNo, dbo.PettyCashJournal.TransactionDate, dbo.PettyCashJournal.ReferenceNo, dbo.PettyCashJournal.Amount, dbo.PettyCashJournal.PayeeIdNo, dbo.PettyCashJournal.PaymentType, 
                         dbo.PettyCashJournal.PayeeName, dbo.PettyCashJournalItem.Sequence, dbo.PettyCashJournalItem.Debit, dbo.PettyCashJournalItem.Credit, dbo.PettyCashJournalItem.ProfitCenterIdNo, 
                         dbo.PettyCashJournalItem.Notes, dbo.Chart.AccountCode, dbo.Chart.AccountName, dbo.Chart.AccountNameAra, dbo.Customer.CustomerCode, dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, 
                         dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, dbo.Employee.EmployeeNameAra, 
                         dbo.ProfitCenter.ProfitCenterCode, dbo.ProfitCenter.ProfitCenterName, dbo.PettyCashJournal.Notes AS PcNote
FROM            dbo.Chart RIGHT OUTER JOIN
                         dbo.PettyCashJournalItem ON dbo.Chart.IdNo = dbo.PettyCashJournalItem.AccountIdNo LEFT OUTER JOIN
                         dbo.ProfitCenter ON dbo.PettyCashJournalItem.ProfitCenterIdNo = dbo.ProfitCenter.IdNo RIGHT OUTER JOIN
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
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[61] 4[31] 2[5] 3) )"
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
         Top = -239
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PettyCashJournal"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 438
               Right = 245
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "PettyCashJournalItem"
            Begin Extent = 
               Top = 349
               Left = 298
               Bottom = 630
               Right = 577
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Customer"
            Begin Extent = 
               Top = 3
               Left = 896
               Bottom = 277
               Right = 1100
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 315
               Left = 899
               Bottom = 445
               Right = 1097
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "ProfitCenter"
            Begin Extent = 
               Top = 452
               Left = 653
               Bottom = 582
               Right = 856
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 198
               Left = 493
               Bottom = 328
               Right = 687
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 115
               Left = 688
               Bottom = 310
               Right = 879
            En', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PettyCashJournalTransaction_View';

