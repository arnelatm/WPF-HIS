














CREATE VIEW [dbo].[Dosage_ViewOld]
AS
SELECT a.IdNo, str(a.IdNo) as DosageCode, a.Direction, a.DosageUnit, a.Dose, a.DurationTiming, a.Frequency, a.FrequencyTiming, a.Route,
		Concat(lower(dbo.fnNumberToWords(a.Dose)), ' ' + b.ItemCodeName , ' ' + c.ItemCodeName , ', ' + d.ItemCodeName + ',' , ' ' + e.ItemCodeName , ' ' + f.ItemCodeName , ' for ' + lower(dbo.fnNumberToWords(a.Duration)), ' ' + g.ItemCodeName)  as DosageName,
		Concat(lower(dbo.numberToArabicWord(a.Dose)), ' ' + b.ItemCodeNameAra , ' ' + c.ItemCodeNameAra , ', ' + d.ItemCodeNameAra + ',' , ' ' + e.ItemCodeNameAra , ' ' + f.ItemCodeNameAra , ' ل ' + lower(dbo.numberToArabicWord(a.Duration)), ' ' + g.ItemCodeNameAra)  as DosageNameAra,
		b.ItemCodeName AS DosageUnitName, 
		c.ItemCodeName AS DirectionName, 
		d.ItemCodeName AS RouteName, 
		e.ItemCodeName AS FrequencyName, 
		f.ItemCodeName AS FrequencyTimingName, 
		a.Duration, 
		g.ItemCodeName AS DuratonTimingName,
		a.DateTimeStamp
FROM            dbo.Dosage AS a LEFT OUTER JOIN
                         dbo.ItemCode AS b ON a.DosageUnit = b.IdNo AND b.CodeGroupIdNo = 7 LEFT OUTER JOIN
                         dbo.ItemCode AS c ON a.Direction = c.IdNo AND c.CodeGroupIdNo = 10 LEFT OUTER JOIN
                         dbo.ItemCode AS d ON a.Route = d.IdNo AND d.CodeGroupIdNo = 9 LEFT OUTER JOIN
                         dbo.ItemCode AS e ON a.Frequency = e.IdNo AND e.CodeGroupIdNo = 6 LEFT OUTER JOIN
                         dbo.ItemCode AS f ON a.FrequencyTiming = f.IdNo AND f.CodeGroupIdNo = 11 LEFT OUTER JOIN
                         dbo.ItemCode AS g ON a.DurationTiming = g.IdNo AND g.CodeGroupIdNo = 8
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Dosage_ViewOld';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Dosage_ViewOld';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[68] 4[8] 2[5] 3) )"
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
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 525
               Right = 219
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 322
               Left = 784
               Bottom = 452
               Right = 975
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 2
               Left = 854
               Bottom = 132
               Right = 1045
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 107
               Left = 761
               Bottom = 237
               Right = 952
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "e"
            Begin Extent = 
               Top = 135
               Left = 488
               Bottom = 265
               Right = 679
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "f"
            Begin Extent = 
               Top = 479
               Left = 795
               Bottom = 609
               Right = 986
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "g"
            Begin Extent = 
               Top = 386
               Left = 280
               Bottom = 516
               Right = 471
            End
            DisplayFlags = 280
            TopColumn = 0
         End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Dosage_ViewOld';

