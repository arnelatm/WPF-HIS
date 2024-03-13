
CREATE VIEW [dbo].[EmployeeLeave_View]
AS
SELECT	dbo.EmployeeLeave.EmployeeIdNo,
		dbo.EmployeeLeave.IdNo, 
		dbo.EmployeeLeave.LeaveIdNo, 
		dbo.EmployeeLeave.StartDate, 
		dbo.EmployeeLeave.EndDate, 
		dbo.EmployeeLeave.FullDay, 
		dbo.EmployeeLeave.EnteredBy, 
		dbo.EmployeeLeave.Reason, 
		dbo.EmployeeLeave.LeaveReason, 
		dbo.EmployeeLeave.DateCreated, 
		dbo.EmployeeLeave.DateTimeStamp, 
		dbo.EmployeeLeave.HolidayIdNo, 
		dbo.EmployeeLeave.DateCreated AS LeaveDate, 
		dbo.EmployeeLeave.IdNo AS EmployeeLeaveIdNo, 
		dbo.Employee.SupervisorIdNo, 
		ISNULL(dbo.LatestApproval_View.Status, '0') AS Status, 
		ISNULL(dbo.LatestApproval_View.LeaveStatus, '0') AS LeaveStatus, 
        dbo.LatestApproval_View.DateCreated AS LatestStatusUpdate, 
		dbo.LatestApproval_View.ApprovedBy, 
		dbo.LatestApproval_View.EmployeeLeaveApprovalIdNo, 
		dbo.Leave.Holiday, 
		dbo.EmployeeLeave.NoOfDays
FROM    dbo.EmployeeLeave 
		INNER JOIN dbo.Employee 
		ON dbo.EmployeeLeave.EmployeeIdNo = dbo.Employee.IdNo 
		LEFT OUTER JOIN dbo.Leave 
		ON dbo.EmployeeLeave.LeaveIdNo = dbo.Leave.IdNo 
		LEFT OUTER JOIN dbo.LatestApproval_View 
		ON dbo.EmployeeLeave.IdNo = dbo.LatestApproval_View.EmployeeLeaveIdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeave_View';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[82] 4[9] 2[6] 3) )"
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
         Begin Table = "EmployeeLeave"
            Begin Extent = 
               Top = 3
               Left = 38
               Bottom = 378
               Right = 263
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 6
               Left = 748
               Bottom = 264
               Right = 946
            End
            DisplayFlags = 280
            TopColumn = 45
         End
         Begin Table = "Leave"
            Begin Extent = 
               Top = 272
               Left = 608
               Bottom = 486
               Right = 781
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LatestApproval_View"
            Begin Extent = 
               Top = 140
               Left = 251
               Bottom = 363
               Right = 538
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 18
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4044
         Alias = 2916
         Table = 4272
         Output = 1476', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeave_View';


























GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeave_View';





