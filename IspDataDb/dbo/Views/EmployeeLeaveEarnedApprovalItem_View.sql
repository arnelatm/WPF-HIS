CREATE VIEW dbo.EmployeeLeaveEarnedApprovalItem_View
AS
SELECT a.IdNo, a.EmployeeLeaveEarnedApprovalIdNo, a.EmployeeLeaveEarnedIdNo, a.Approved, a.Disapproved, e.DateCreated, e.ApprovedBy, a.ApprovalNote, dbo.EmployeeLeaveEarned.EmployeeIdNo, 
                  dbo.EmployeeLeaveEarned.LeaveIdNo, dbo.EmployeeLeaveEarned.StartDate, dbo.EmployeeLeaveEarned.EndDate, dbo.EmployeeLeaveEarned.Reason, dbo.EmployeeLeaveEarned.DaysEarned, dbo.EmployeeLeaveEarned.EnteredBy, 
                  dbo.EmployeeLeaveEarned.DateCreated AS LeaveEarnedDateCreated, dbo.Leave.LeaveCode, dbo.Leave.LeaveName, dbo.Leave.LeaveNameAra, dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, 
                  dbo.Employee.EmployeeNameAra, dbo.Employee.SupervisorIdNo
FROM     dbo.EmployeeLeaveEarnedApprovalItem AS a INNER JOIN
                  dbo.EmployeeLeaveEarnedApproval AS e ON a.EmployeeLeaveEarnedApprovalIdNo = e.IdNo INNER JOIN
                  dbo.EmployeeLeaveEarned ON a.IdNo = dbo.EmployeeLeaveEarned.IdNo INNER JOIN
                  dbo.Leave ON dbo.EmployeeLeaveEarned.LeaveIdNo = dbo.Leave.IdNo INNER JOIN
                  dbo.Employee ON dbo.EmployeeLeaveEarned.EmployeeIdNo = dbo.Employee.IdNo

GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[66] 4[5] 2[12] 3) )"
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
               Top = 7
               Left = 48
               Bottom = 318
               Right = 387
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "e"
            Begin Extent = 
               Top = 27
               Left = 713
               Bottom = 326
               Right = 916
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmployeeLeaveEarned"
            Begin Extent = 
               Top = 114
               Left = 455
               Bottom = 504
               Right = 658
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Leave"
            Begin Extent = 
               Top = 63
               Left = 1057
               Bottom = 483
               Right = 1260
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 65
               Left = 830
               Bottom = 524
               Right = 1062
            End
            DisplayFlags = 280
            TopColumn = 34
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
         Column = 7320
         Alias = 900
         Table = 3408
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveEarnedApprovalItem_View';


GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveEarnedApprovalItem_View';


GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveEarnedApprovalItem_View';


GO

