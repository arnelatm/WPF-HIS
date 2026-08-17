CREATE VIEW dbo.EmployeeLeaveApprovalItem_View
AS
SELECT b.EnteredBy, b.LeaveIdNo, b.StartDate, b.EndDate, b.FullDay, a.Status, a.Status AS LeaveStatus, a.ApprovalNote, a.EmployeeLeaveApprovalIdNo, b.EmployeeIdNo, b.DateCreated, b.Reason, c.SupervisorIdNo, c.EmployeeName, 
                  c.EmployeeNameAra, d.LeaveName, d.LeaveNameAra, a.EmployeeLeaveIdNo, a.IdNo, b.NoOfDays
FROM     dbo.EmployeeLeave AS b INNER JOIN
                  dbo.EmployeeLeaveApprovalItem AS a ON b.IdNo = a.EmployeeLeaveIdNo LEFT OUTER JOIN
                  dbo.Leave AS d ON b.LeaveIdNo = d.IdNo LEFT OUTER JOIN
                  dbo.Employee AS c ON b.EmployeeIdNo = c.IdNo

GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[49] 4[34] 2[3] 3) )"
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
         Begin Table = "b"
            Begin Extent = 
               Top = 126
               Left = 315
               Bottom = 413
               Right = 481
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "a"
            Begin Extent = 
               Top = 7
               Left = 32
               Bottom = 264
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 17
               Left = 783
               Bottom = 327
               Right = 956
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 95
               Left = 538
               Bottom = 424
               Right = 736
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
         Column = 3372
         Alias = 2652
         Table = 2220
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveApprovalItem_View';


GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveApprovalItem_View';


GO

