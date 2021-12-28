CREATE VIEW dbo.EmployeeLeaveLatestApproval_View
AS
SELECT        a.LeaveIdNo, a.StartDate, a.EndDate, a.FullDay, b.EmployeeLeaveIdNo, b.LatestStatusUpdate, dbo.EmployeeLeave.EmployeeIdNo, dbo.EmployeeLeave.LeaveReason, dbo.Employee.SupervisorIdNo, 
                         a.EmployeeLeaveApprovalIdNo, a.LeaveStatus, a.ApprovedBy, a.EnteredBy, a.ApprovalNote, a.LeaveDate, a.ApprovalDate
FROM            dbo.Employee RIGHT OUTER JOIN
                         dbo.EmployeeLeave RIGHT OUTER JOIN
                         dbo.EmployeeLeaveApprovalList_View AS a LEFT OUTER JOIN
                             (SELECT        c.EmployeeLeaveIdNo, MAX(d.DateCreated) AS LatestStatusUpdate
                               FROM            dbo.EmployeeLeaveApprovalItem AS c LEFT OUTER JOIN
                                                         dbo.EmployeeLeaveApproval AS d ON c.EmployeeLeaveApprovalIdNo = d.IdNo
                               GROUP BY c.EmployeeLeaveIdNo) AS b ON a.EmployeeLeaveIdNo = b.EmployeeLeaveIdNo ON dbo.EmployeeLeave.IdNo = a.EmployeeLeaveIdNo ON dbo.Employee.IdNo = dbo.EmployeeLeave.EmployeeIdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveLatestApproval_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[57] 4[36] 2[3] 3) )"
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
         Begin Table = "Employee"
            Begin Extent = 
               Top = 34
               Left = 859
               Bottom = 436
               Right = 1057
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmployeeLeave"
            Begin Extent = 
               Top = 37
               Left = 554
               Bottom = 309
               Right = 727
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "a"
            Begin Extent = 
               Top = 47
               Left = 38
               Bottom = 743
               Right = 283
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 338
               Left = 465
               Bottom = 704
               Right = 662
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
         Column = 2715
         Alias = 3405
         Table = 3300
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeLeaveLatestApproval_View';



