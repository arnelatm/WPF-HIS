



CREATE VIEW [dbo].[PrintSetup_View]
AS
SELECT        dbo.Computer.ComputerCode, dbo.PrintJob.PrintJobCode, dbo.PrintSetup.IdNo, dbo.PrintSetup.ComputerIdNo, dbo.PrintSetup.PrintJobIdNo, dbo.PrintSetup.PrinterIdNo, dbo.PrintSetup.PaperSource, 
                         dbo.PrintSetup.PaperOrientation, dbo.PrintSetup.PaperSize, dbo.PrintSetup.DateTimeStamp,
						 Concat(dbo.Computer.ComputerCode,'-',dbo.PrintJob.PrintJobCode) as PrintSetupName
FROM            dbo.PrintSetup left JOIN
                         dbo.PrintJob ON dbo.PrintSetup.PrintJobIdNo = dbo.PrintJob.IdNo left JOIN
                         dbo.Computer ON dbo.PrintSetup.ComputerIdNo = dbo.Computer.IdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PrintSetup_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[25] 4[36] 2[20] 3) )"
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
         Begin Table = "PrintSetup"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 333
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PrintJob"
            Begin Extent = 
               Top = 90
               Left = 287
               Bottom = 351
               Right = 469
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Computer"
            Begin Extent = 
               Top = 48
               Left = 572
               Bottom = 178
               Right = 765
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
         Column = 3090
         Alias = 2265
         Table = 1170
         Output = 2640
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PrintSetup_View';

