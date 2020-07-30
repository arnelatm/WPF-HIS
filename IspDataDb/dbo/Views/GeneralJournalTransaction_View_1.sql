
CREATE VIEW [dbo].[GeneralJournalTransaction_View]
AS
SELECT        dbo.GeneralJournalItem.Sequence, dbo.GeneralJournalItem.JournalIdNo, dbo.GeneralJournalItem.AccountIdNo, dbo.GeneralJournalItem.Debit, dbo.GeneralJournalItem.Credit, 
                         dbo.GeneralJournalItem.RevCostCenterIdNo, dbo.GeneralJournalItem.Notes, dbo.GeneralJournalItem.Posted, dbo.GeneralJournal.TransactionDate, dbo.GeneralJournal.Notes AS GJNotes, 
                         dbo.GeneralJournal.ClosingJournal, dbo.GeneralJournal.Cancelled, dbo.GeneralJournal.ReferenceNo, dbo.Chart.AccountCode, dbo.Chart.AccountName, dbo.Chart.AccountNameAra, 
                         dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.RevCostCenter.RevCostCenterNameAra
FROM            dbo.RevCostCenter RIGHT OUTER JOIN
                         dbo.GeneralJournalItem ON dbo.RevCostCenter.IdNo = dbo.GeneralJournalItem.RevCostCenterIdNo LEFT OUTER JOIN
                         dbo.Chart ON dbo.GeneralJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.GeneralJournal ON dbo.GeneralJournalItem.JournalIdNo = dbo.GeneralJournal.IdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'GeneralJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "Chart"
            Begin Extent = 
               Top = 151
               Left = 566
               Bottom = 281
               Right = 764
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "GeneralJournalItem"
            Begin Extent = 
               Top = 13
               Left = 280
               Bottom = 318
               Right = 459
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfitCenter"
            Begin Extent = 
               Top = 6
               Left = 774
               Bottom = 258
               Right = 977
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GeneralJournal"
            Begin Extent = 
               Top = 21
               Left = 55
               Bottom = 309
               Right = 230
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
         Alias = 3270
         Table = 3420
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'GeneralJournalTransaction_View';



