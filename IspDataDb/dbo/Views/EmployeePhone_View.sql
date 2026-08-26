


CREATE VIEW [dbo].[EmployeePhone_View]
AS
SELECT        dbo.PhoneType.PhoneTypeCode, dbo.PhoneType.PhoneTypeName, dbo.PhoneType.PhoneTypeNameAra, dbo.EmployeePhone.CountryTelIdNo, dbo.EmployeePhone.IdNo, dbo.EmployeePhone.EmployeeIdNo, 
                         dbo.EmployeePhone.PhoneTypeIdNo, dbo.EmployeePhone.AreaCode, dbo.EmployeePhone.PhoneNumber, dbo.Employee.EmployeeName, dbo.Employee.EmployeeNameAra, dbo.EmployeePhone.Sequence, 
                         CONVERT(NVARCHAR(15), dbo.PhoneType.PhoneTypeName) COLLATE SQL_Latin1_General_CP1_CS_AS +
						 Case 
							When dbo.EmployeePhone.CountryTelIdNo IS NULL then ' '
							Else ' ' + LTrim(dbo.Country.CountryTelCode)
						 End +
						 ' (' + dbo.EmployeePhone.AreaCode + ') ' + dbo.EmployeePhone.PhoneNumber AS FullPhone, 
                         CONVERT(NVARCHAR(15), dbo.PhoneType.PhoneTypeName) COLLATE Arabic_CI_AS +
						 Case 
							When dbo.EmployeePhone.CountryTelIdNo IS NULL then ' '
							Else ' ' + LTrim(dbo.Country.CountryTelCode)
						 End +
						 ' (' + dbo.EmployeePhone.AreaCode + ') ' + dbo.EmployeePhone.PhoneNumber AS FullPhoneAra, dbo.Country.CountryTelCode
FROM            dbo.EmployeePhone INNER JOIN
                         dbo.Employee ON dbo.EmployeePhone.EmployeeIdNo = dbo.Employee.IdNo LEFT OUTER JOIN
                         dbo.Country ON dbo.EmployeePhone.CountryTelIdNo = dbo.Country.IDNo LEFT OUTER JOIN
                         dbo.PhoneType ON dbo.EmployeePhone.PhoneTypeIdNo = dbo.PhoneType.IdNo

GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "EmployeePhone"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 304
               Right = 213
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 0
               Left = 334
               Bottom = 292
               Right = 532
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PhoneType"
            Begin Extent = 
               Top = 35
               Left = 1031
               Bottom = 263
               Right = 1229
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 127
               Left = 590
               Bottom = 316
               Right = 772
            End
            DisplayFlags = 280
            TopColumn = 5
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
         Column = 4815
         Alias = 1680
         Table = 5280
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeePhone_View';


GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeePhone_View';


GO

