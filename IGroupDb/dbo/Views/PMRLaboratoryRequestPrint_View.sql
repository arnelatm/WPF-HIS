CREATE VIEW dbo.PMRLaboratoryRequestPrint_View
AS
SELECT        A.Trans_Key, A.TransNBR, A.TransType, A.TransDateEnglish, A.PatientType, A.BillType, A.Series, A.RegistrationNo, A.InsuranceID, A.InsuranceGroupID, A.DoctorID, A.VisitType, C.PatientNameEnglish, C.Age, C.Sex, C.AgeYMD, 
                         D.CountryNameEng, E.EmpNameEnglish, E.OPDNo, F.NameEnglish AS Company, C.InsCardExpiry, dbo.MedicalServices.ServiceNameEnglish, dbo.MedicalServices.ServiceNameArabic, dbo.PMRPatientInvestigation.Item_Code, 
                         A.VisitNo, A.Diagnosis
FROM            dbo.PMRPatientGeneralInfo AS A INNER JOIN
                         dbo.PMRPatientInvestigation ON A.Trans_Key = dbo.PMRPatientInvestigation.Trans_Key INNER JOIN
                         dbo.MedicalServices ON dbo.PMRPatientInvestigation.Item_Code = dbo.MedicalServices.ServiceID LEFT OUTER JOIN
                         dbo.PatientDetails AS C ON A.RegistrationNo = C.RegistrationNo AND A.Series = C.Series LEFT OUTER JOIN
                         dbo.CountryMaster AS D ON C.CountryIOTA = D.CountryIOTA LEFT OUTER JOIN
                         dbo.EmployeeDetails AS E ON A.DoctorID = E.EmpID LEFT OUTER JOIN
                         dbo.InsuranceDetails AS F ON A.InsuranceID = F.InsuranceID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PMRLaboratoryRequestPrint_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'          TopColumn = 0
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PMRLaboratoryRequestPrint_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[90] 4[3] 2[3] 3) )"
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
         Top = -384
         Left = 0
      End
      Begin Tables = 
         Begin Table = "A"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 775
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "PMRPatientInvestigation"
            Begin Extent = 
               Top = 317
               Left = 253
               Bottom = 729
               Right = 450
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "MedicalServices"
            Begin Extent = 
               Top = 189
               Left = 926
               Bottom = 775
               Right = 1122
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "C"
            Begin Extent = 
               Top = 292
               Left = 562
               Bottom = 422
               Right = 760
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "D"
            Begin Extent = 
               Top = 0
               Left = 549
               Bottom = 130
               Right = 747
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "E"
            Begin Extent = 
               Top = 1
               Left = 782
               Bottom = 131
               Right = 1028
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "F"
            Begin Extent = 
               Top = 142
               Left = 577
               Bottom = 272
               Right = 786
            End
            DisplayFlags = 280
  ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PMRLaboratoryRequestPrint_View';

