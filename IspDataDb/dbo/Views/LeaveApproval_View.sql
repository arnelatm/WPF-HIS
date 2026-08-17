

CREATE VIEW [dbo].[LeaveApproval_View]
AS
SELECT	dbo.EmployeeLeave.EmployeeIdNo, 
		dbo.EmployeeLeave.LeaveIdNo, 
		dbo.EmployeeLeave.StartDate, 
		dbo.EmployeeLeave.EndDate, 
		dbo.EmployeeLeave.FullDay, 
		dbo.EmployeeLeave.EnteredBy, 
		dbo.EmployeeLeave.Reason, 
        dbo.EmployeeLeave.DateCreated, 
		ISNULL(dbo.EmployeeLeaveApprovalItem.Status, '0') AS 'Status', 
		ISNULL(dbo.EmployeeLeaveApprovalItem.Status, '0') AS 'LeaveStatus', 
		dbo.EmployeeLeaveApprovalItem.ApprovalNote, 
		dbo.Employee.SupervisorIdNo, 
		dbo.EmployeeLeave.DateTimeStamp, 
        dbo.EmployeeLeaveApprovalItem.EmployeeLeaveApprovalIdNo, 
		dbo.EmployeeLeaveApprovalItem.EmployeeLeaveIdNo, 
		dbo.EmployeeLeaveApprovalItem.IdNo, 
		dbo.[User].UserName as 'ApprovedByName', 
        dbo.EmployeeLeaveApproval.ApprovedBy, 
		dbo.EmployeeLeaveApproval.DateCreated as 'ApprovalDate'
FROM    dbo.EmployeeLeaveApproval RIGHT OUTER JOIN
		dbo.EmployeeLeaveApprovalItem 
		ON dbo.EmployeeLeaveApproval.IdNo = dbo.EmployeeLeaveApprovalItem.EmployeeLeaveApprovalIdNo 
		LEFT OUTER JOIN dbo.EmployeeLeave 
		ON dbo.EmployeeLeaveApprovalItem.EmployeeLeaveIdNo = dbo.EmployeeLeave.IdNo 
		LEFT OUTER JOIN dbo.Employee 
		ON dbo.EmployeeLeave.EmployeeIdNo = dbo.Employee.IdNo 
		LEFT OUTER JOIN dbo.[User] 
		ON dbo.EmployeeLeaveApproval.ApprovedBy = dbo.[User].IdNo

GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[71] 4[5] 2[8] 3) )"
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
         Begin Table = "EmployeeLeaveApproval"
            Begin Extent = 
               Top = 7
               Left = 335
               Bottom = 170
               Right = 538
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmployeeLeaveApprovalItem"
            Begin Extent = 
               Top = 23
               Left = 6
               Bottom = 289
               Right = 287
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmployeeLeave"
            Begin Extent = 
               Top = 216
               Left = 366
               Bottom = 558
               Right = 601
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 193
               Left = 756
               Bottom = 448
               Right = 954
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 0
               Left = 633
               Bottom = 163
               Right = 856
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
         Column = 2880
         Alias = 2316
         Table = 3600
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'LeaveApproval_View';


GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'      Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'LeaveApproval_View';


GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'LeaveApproval_View';


GO

