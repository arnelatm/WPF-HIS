

CREATE VIEW [dbo].[EmployeeIdPrinting_View]
AS
SELECT        dbo.EmployeeIdPrinting.EmployeeIdNo, dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, dbo.Employee.EmployeeNameAra, dbo.Employee.Gender, dbo.Employee.NationalIdNo, dbo.Employee.BloodType, 
                         dbo.EmployeeIdPrinting.TransactionNumber, dbo.Country.NationalityAra, dbo.Employee.NationalityCode, dbo.Employee.DesignationIdNo, dbo.Designation.DesignationNameAra, IsNull(dbo.Designation.DesignationNameFemaleAra,dbo.Designation.DesignationNameFemaleAra) as DesignationNameFemaleAra, 
                         dbo.Employee.Picture, IsNull(dbo.Designation.DesignationNameFemale,dbo.Designation.DesignationName) as DesignationNameFemale, dbo.Designation.DesignationName, dbo.EmployeeIdPrinting.IdNo, dbo.Country.CountryNameAra, ISNULL(dbo.List.ListName, '') AS Title, 
                         ISNULL(dbo.List.ListNameAra, '') AS TitleAra, dbo.List.ListName, dbo.List.ListNameAra
FROM            dbo.Employee 
				LEFT OUTER JOIN dbo.List ON dbo.Employee.Title = dbo.List.IdNo and dbo.List.ListIdNo = 1 
				LEFT OUTER JOIN dbo.Country ON dbo.Employee.NationalityCode = dbo.Country.CountryCode COLLATE SQL_Latin1_General_CP1_CI_AS 
				LEFT OUTER JOIN dbo.Designation ON dbo.Employee.DesignationIdNo = dbo.Designation.IdNo 
				RIGHT OUTER JOIN dbo.EmployeeIdPrinting ON dbo.Employee.IdNo = dbo.EmployeeIdPrinting.EmployeeIdNo

GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[65] 4[23] 2[3] 3) )"
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
               Top = 6
               Left = 270
               Bottom = 481
               Right = 468
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "List"
            Begin Extent = 
               Top = 302
               Left = 779
               Bottom = 611
               Right = 949
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 7
               Left = 519
               Bottom = 332
               Right = 701
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Designation"
            Begin Extent = 
               Top = 21
               Left = 773
               Bottom = 245
               Right = 1013
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmployeeIdPrinting"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 273
               Right = 232
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
         Column = 3345
         Alias = 3600
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
     ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeIdPrinting_View';


GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'    Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeIdPrinting_View';


GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeIdPrinting_View';


GO

