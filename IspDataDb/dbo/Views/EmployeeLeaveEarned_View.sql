
CREATE VIEW [dbo].[EmployeeLeaveEarned_View]
AS
SELECT dbo.EmployeeLeaveEarned.EmployeeIdNo, dbo.EmployeeLeaveEarned.IdNo, dbo.EmployeeLeaveEarned.LeaveIdNo, dbo.EmployeeLeaveEarned.StartDate, dbo.EmployeeLeaveEarned.EndDate, dbo.EmployeeLeaveEarned.DaysEarned, 
                  dbo.EmployeeLeaveEarned.EnteredBy, dbo.EmployeeLeaveEarned.Reason, dbo.EmployeeLeaveEarned.DateCreated, dbo.EmployeeLeaveEarned.DateTimeStamp, dbo.EmployeeLeaveEarned.IdNo AS EmployeeLeaveEarnedIdNo, 
                  IsNull(dbo.EmployeeLeaveEarnedApprovalItem.Approved,0) as Approved, IsNull(dbo.EmployeeLeaveEarnedApprovalItem.Disapproved,0) Disapproved, dbo.EmployeeLeaveEarnedApproval.ApprovedBy, dbo.EmployeeLeaveEarnedApprovalItem.ApprovalNote, 
                  dbo.Employee.SupervisorIdNo
FROM     dbo.EmployeeLeaveEarned LEFT OUTER JOIN
                  dbo.EmployeeLeaveEarnedApprovalItem ON dbo.EmployeeLeaveEarned.IdNo = dbo.EmployeeLeaveEarnedApprovalItem.EmployeeLeaveEarnedIdNo LEFT OUTER JOIN
                  dbo.Employee ON dbo.EmployeeLeaveEarned.EmployeeIdNo = dbo.Employee.IdNo LEFT OUTER JOIN
                  dbo.Leave ON dbo.EmployeeLeaveEarned.LeaveIdNo = dbo.Leave.IdNo LEFT OUTER JOIN
                  dbo.EmployeeLeaveEarnedApproval ON dbo.EmployeeLeaveEarnedApprovalItem.EmployeeLeaveEarnedApprovalIdNo = dbo.EmployeeLeaveEarnedApproval.IdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveEarned_View';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[30] 4[53] 2[2] 3) )"
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
         Begin Table = "EmployeeLeaveEarned"
            Begin Extent = 
               Top = 0
               Left = 36
               Bottom = 637
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "EmployeeLeaveEarnedApprovalItem"
            Begin Extent = 
               Top = 637
               Left = 48
               Bottom = 800
               Right = 387
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 11
               Left = 1037
               Bottom = 174
               Right = 1269
            End
            DisplayFlags = 280
            TopColumn = 45
         End
         Begin Table = "Leave"
            Begin Extent = 
               Top = 219
               Left = 1069
               Bottom = 444
               Right = 1272
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmployeeLeaveEarnedApproval"
            Begin Extent = 
               Top = 805
               Left = 48
               Bottom = 968
               Right = 251
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
         Alias = 2532
         Table = 4248
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 135', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveEarned_View';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'6
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveEarned_View';

