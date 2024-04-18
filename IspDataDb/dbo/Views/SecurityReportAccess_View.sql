CREATE VIEW dbo.SecurityReportAccess_View
AS
SELECT     dbo.SecurityReportAccess.IdNo, dbo.SecurityGroup.SecurityGroupName, dbo.[User].UserName, dbo.SecurityReportAccess.ReportGroupIdNo AS Expr1, dbo.SecurityReportAccess.SecurityGroupIdNo, dbo.SecurityReportAccess.UserIdNo, dbo.ReportGroup.ReportGroupName, 
                  dbo.ReportGroup.ReportGroupNameAra, dbo.Report.ReportName, dbo.Report.ReportNameAra, dbo.Report.ReportGroupIdNo, dbo.ReportGroup.ReportGroupCode
FROM        dbo.[User] RIGHT OUTER JOIN
                  dbo.SecurityReportAccess LEFT OUTER JOIN
                  dbo.SecurityGroup ON dbo.SecurityReportAccess.SecurityGroupIdNo = dbo.SecurityGroup.IdNo ON dbo.[User].IdNo = dbo.SecurityReportAccess.UserIdNo LEFT OUTER JOIN
                  dbo.Report LEFT OUTER JOIN
                  dbo.ReportGroup ON dbo.Report.ReportGroupIdNo = dbo.ReportGroup.IdNo ON dbo.SecurityReportAccess.ReportGroupIdNo = dbo.ReportGroup.IdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'SecurityReportAccess_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'       Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'SecurityReportAccess_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[66] 4[7] 2[12] 3) )"
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
         Begin Table = "User"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 271
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SecurityReportAccess"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 308
               Right = 269
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SecurityGroup"
            Begin Extent = 
               Top = 175
               Left = 949
               Bottom = 338
               Right = 1200
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Report"
            Begin Extent = 
               Top = 0
               Left = 649
               Bottom = 323
               Right = 901
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ReportGroup"
            Begin Extent = 
               Top = 7
               Left = 317
               Bottom = 305
               Right = 516
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
         Column = 3072
         Alias = 900
         Table = 2760
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
  ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'SecurityReportAccess_View';

