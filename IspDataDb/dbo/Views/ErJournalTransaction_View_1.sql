
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
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ErJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'  Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ErJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[61] 4[3] 2[17] 3) )"
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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ProfitCenter"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 241
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ErJournalItem"
            Begin Extent = 
               Top = 6
               Left = 279
               Bottom = 136
               Right = 458
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ErJournal"
            Begin Extent = 
               Top = 138
               Left = 274
               Bottom = 268
               Right = 451
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 488
               Right = 229
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
         Table = 3225
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
       ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ErJournalTransaction_View';



