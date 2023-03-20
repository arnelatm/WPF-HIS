
CREATE VIEW [dbo].[DrugListComparison_View]
AS
SELECT        dbo.DrugList.IdNo, dbo.DrugList.RegistrationNo, dbo.DrugList2020.REGISTRATIONNO AS RegistrationNo2, dbo.DrugList.GTIN, dbo.DrugList2020.GTIN AS GTin2, dbo.DrugList.[Trade name], 
                         dbo.DrugList2020.[Trade name] AS [Trade name2], dbo.DrugList.[Strength value], dbo.DrugList2020.[Strength Value] AS [Strength Value2], dbo.DrugList.[Unit of strength], 
                         dbo.DrugList2020.[Unit of strength] AS [Unit of Strength2], dbo.DrugList.Volume, dbo.DrugList2020.Volume AS Volume2, dbo.DrugList.[Unit of volume], dbo.DrugList2020.[Unit of volume] AS [Unit of volume2], 
                         dbo.DrugList.[Dosage Form], dbo.DrugList2020.[Dosage form] AS [Dosage Form2], dbo.DrugList.[Package type], dbo.DrugList.[Package size]
FROM            dbo.DrugList FULL OUTER JOIN
                         dbo.DrugList2020 ON dbo.DrugList.RegistrationNo = dbo.DrugList2020.REGISTRATIONNO
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'DrugListComparison_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[23] 4[62] 2[12] 3) )"
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
         Begin Table = "DrugList"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 489
               Right = 259
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Sept2020GTIN"
            Begin Extent = 
               Top = 6
               Left = 297
               Bottom = 465
               Right = 482
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
         Column = 2370
         Alias = 4155
         Table = 1170
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'DrugListComparison_View';

