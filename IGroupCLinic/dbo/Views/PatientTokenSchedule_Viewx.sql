CREATE VIEW dbo.[PatientTokenSchedule_Viewx]
AS
SELECT        dbo.BookingShiftDetails.LunchStart, dbo.BookingShiftDetails.LunchEnd, dbo.BookingShiftDetails.Activate, dbo.BookingShiftDetails.UserId, dbo.BookingShiftDetails.Create_date, dbo.BookingShiftDetails.MachineId, 
                         dbo.BookingShiftDetails.LunchStart AS Expr8, dbo.BookingShiftDetails.LunchEnd AS Expr9, dbo.BookingShiftDetails.Activate AS Expr10, dbo.BookingShiftDetails.UserId AS Expr11, 
                         dbo.BookingShiftDetails.Create_date AS Expr12, dbo.BookingShiftDetails.MachineId AS Expr13, dbo.PatientTokenSchedule.ScheduleDate, dbo.PatientTokenSchedule.TokenNo, dbo.PatientTokenSchedule.ShiftId AS Expr14, 
                         dbo.BookingShiftDetails.ShiftStart, dbo.BookingShiftDetails.shiftEnd, dbo.BookingShiftDetails.DIrectShift, dbo.BookingShiftDetails.Description, dbo.BookingShiftDetails.BranchId, dbo.BookingShiftDetails.Trans_key, 
                         dbo.PatientTokenSchedule.DoctorId AS Expr1, dbo.PatientTokenSchedule.Trans_key AS Expr2, dbo.BookingShiftDetails.DoctorId
FROM            dbo.BookingShiftDetails INNER JOIN
                         dbo.PatientTokenSchedule ON dbo.BookingShiftDetails.ShiftId = dbo.PatientTokenSchedule.ShiftId

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[80] 4[3] 2[3] 3) )"
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
         Begin Table = "BookingShiftDetails"
            Begin Extent = 
               Top = 32
               Left = 607
               Bottom = 589
               Right = 959
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PatientTokenSchedule"
            Begin Extent = 
               Top = 7
               Left = 37
               Bottom = 352
               Right = 207
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
      Begin ColumnWidths = 9
         Width = 284
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
         Column = 1440
         Alias = 900
         Table = 2640
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PatientTokenSchedule_Viewx';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PatientTokenSchedule_Viewx';

