

CREATE VIEW [dbo].[EmployeeLeaveList_View]
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
		dbo.EmployeeLeaveApproval.ApprovedBy, 
		dbo.EmployeeLeaveApprovalItem.Status, 
		dbo.EmployeeLeaveApprovalItem.Status as 'LeaveStatus', 
		dbo.EmployeeLeaveApprovalItem.ApprovalNote, 
		dbo.EmployeeLeaveApproval.DateCreated AS LeaveStatusDate, 
		dbo.Employee.SupervisorIdNo, 
		dbo.EmployeeLeave.DateTimeStamp, 
		dbo.EmployeeLeaveApprovalItem.EmployeeLeaveApprovalIdNo
FROM    dbo.EmployeeLeave 
		INNER JOIN dbo.Employee 
		ON dbo.EmployeeLeave.EmployeeIdNo = dbo.Employee.IdNo 
		LEFT OUTER JOIN dbo.EmployeeLeaveApprovalItem 
		ON dbo.EmployeeLeave.IdNo = dbo.EmployeeLeaveApprovalItem.EmployeeLeaveIdNo 
		LEFT OUTER JOIN dbo.EmployeeLeaveApproval 
		ON dbo.EmployeeLeaveApprovalItem.EmployeeLeaveApprovalIdNo = dbo.EmployeeLeaveApproval.IdNo
GO



GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveList_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[50] 4[11] 2[20] 3) )"
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
               Top = 6
               Left = 38
               Bottom = 325
               Right = 291
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 131
               Left = 357
               Bottom = 261
               Right = 555
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmployeeLeaveApprovalItem"
            Begin Extent = 
               Top = 21
               Left = 627
               Bottom = 151
               Right = 872
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmployeeLeaveApproval"
            Begin Extent = 
               Top = 0
               Left = 985
               Bottom = 130
               Right = 1158
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
         Table = 1176
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveList_View';



