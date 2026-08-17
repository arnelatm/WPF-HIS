CREATE VIEW dbo.EmployeeInfo_View3
AS
SELECT        dbo.Employee.IdNo, dbo.Employee.EmployeeCode, dbo.Employee.Title, dbo.Employee.EmployeeName, dbo.Employee.EmployeeNameAra, dbo.Employee.Gender, dbo.Employee.MaritalStatus, dbo.Employee.NationalityCode, 
                         dbo.Employee.NationalityId, dbo.Employee.ReligionIdNo, dbo.Employee.ReligionId, dbo.Employee.NationalIdNo, dbo.Employee.Street, dbo.Employee.District, dbo.Employee.TownCity, dbo.Employee.ProvinceState, 
                         dbo.Employee.CountryCode, dbo.Employee.PoBox, dbo.Employee.ZipCode, dbo.Employee.Phone1, dbo.Employee.Phone2, dbo.Employee.Email, dbo.Employee.DepartmentIdNo, dbo.Employee.DesignationIdNo, 
                         dbo.Employee.HiredDate, dbo.Employee.ReleasedDate, dbo.Employee.ArAccountIdNo, dbo.Employee.BankIdNo, dbo.Employee.BankAccountNo, dbo.Employee.IBAN, dbo.Employee.Notes, dbo.Employee.OpeningBalance, 
                         dbo.Employee.Balance, dbo.Employee.PaymentMethod, dbo.Employee.PayCycleIdNo, dbo.Employee.PayGroupIdNo, dbo.Employee.PaySalariedOrHourly, dbo.Employee.PayRateType, dbo.Employee.SponsorType, 
                         dbo.Employee.PayRateAmount, dbo.Employee.OTRateRegular, dbo.Employee.OTRateHoliday, dbo.Employee.DutyHours, dbo.Employee.OTRateSpecial, dbo.Employee.BloodType, dbo.Employee.Supervisor, 
                         dbo.Employee.SupervisorIdNo, dbo.Employee.Picture, dbo.Employee.Active, dbo.Employee.Create_Date, dbo.Country.Nationality, dbo.Country.NationalityAra, Country_1.CountryName, Country_1.CountryNameAra, 
                         Employee_1.EmployeeName AS SupervisorName, Employee_1.EmployeeNameAra AS SupervisorNameAra, dbo.Employee.BirthDate
FROM            dbo.Employee LEFT OUTER JOIN
                         dbo.Country AS Country_1 ON dbo.Employee.CountryCode = Country_1.CountryCode COLLATE SQL_Latin1_General_CP1_CI_AS LEFT OUTER JOIN
                         dbo.Country ON dbo.Employee.NationalityCode = dbo.Country.CountryCode COLLATE SQL_Latin1_General_CP1_CI_AS LEFT OUTER JOIN
                         dbo.Employee AS Employee_1 ON dbo.Employee.SupervisorIdNo = Employee_1.IdNo

GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[89] 4[3] 2[3] 3) )"
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
               Top = 114
               Left = 1607
               Bottom = 244
               Right = 1805
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country_1"
            Begin Extent = 
               Top = 534
               Left = 38
               Bottom = 664
               Right = 220
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 534
               Left = 258
               Bottom = 664
               Right = 440
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee_1"
            Begin Extent = 
               Top = 666
               Left = 38
               Bottom = 796
               Right = 236
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
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeInfo_View3';


GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeInfo_View3';


GO

