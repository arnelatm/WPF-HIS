

CREATE VIEW [dbo].[PMRPharmacyMedicinePrint_View]
AS
SELECT        A.Trans_Key, A.TransNBR, A.TransType, A.TransDateEnglish, A.PatientType, A.BillType, A.Series, A.RegistrationNo, A.TokenNo, A.InsuranceID, A.InsuranceGroupID, A.DoctorID, A.bp, A.Breathing, A.Height, A.Weight, 
                         A.Temprature, A.PulseRate, A.Respiratory, A.VisitNo, A.VisitType, A.DurationOfIllness, A.DurationYMD, A.AdmissionType, A.FixedAlergies, A.DrugAlergies, A.OtherAlergies, A.ChiefComplaint, A.NoteAlergies, A.SignificantSign, 
                         A.OtherCondition, A.Diagnosis, A.DX_Code1, A.DX_Code2, A.DX_Code3, A.DX_Code4, A.MedicationNote, A.IllnessType, A.Lmp, A.LmpDate, A.Cmf, A.CmfNote, A.Los, A.Eda, A.DoctorRemark, A.UserID, A.Create_Date, A.MachineID, 
                         B.PrescriptionItemIdNo, B.RowNBR, B.Item_Code, B.Qty, B.Unit, B.SalePrice, B.DiscountPer, B.DiscountAmt, B.BillAmt, B.ItemNameEnglish, B.ItemNameArabic, B.DosageID, B.DosageEnglish, B.DosageArabic, B.Duration, C.PatientNameEnglish, 
                         C.Age, C.Sex, C.AgeYMD, D.CountryNameEng, E.EmpNameEnglish, E.OPDNo, F.NameEnglish AS Company, g.PharmacyTransNBR, g.Printed, C.InsCardExpiry, k.RegistrationNo AS SFDACode, ISNULL(m.[Generic name], 
                         n.[Generic name]) AS GenericName, ISNULL(m.[Trade name], n.[Trade name]) AS TradeName, ISNULL(m.[Strength value], n.[Strength value]) AS StrengthValue, ISNULL(m.[Unit of strength], n.[Unit of strength]) AS UnitOfStrength, 
                         ISNULL(m.[Dosage Form], n.[Dosage Form]) AS DosageForm, ISNULL(m.Volume, n.Volume) AS Volume, ISNULL(m.[Unit of volume], n.[Unit of volume]) AS UnitOfVolume, ISNULL(m.[Package type], n.[Package type]) 
                         AS PackageType, ISNULL(m.[Package size], n.[Package size]) AS PackageSize, B.LabelPrinted
FROM            dbo.PMRPatientGeneralInfo AS A INNER JOIN
                         dbo.PMRMedicineDetails_View AS B ON A.Trans_Key = B.Trans_Key LEFT OUTER JOIN
                         dbo.PatientDetails AS C ON A.RegistrationNo = C.RegistrationNo AND A.Series = C.Series LEFT OUTER JOIN
                         dbo.CountryMaster AS D ON C.CountryIOTA = D.CountryIOTA LEFT OUTER JOIN
                         dbo.EmployeeDetails AS E ON A.DoctorID = E.EmpID LEFT OUTER JOIN
                         dbo.InsuranceDetails AS F ON A.InsuranceID = F.InsuranceID LEFT OUTER JOIN
                         dbo.PMRPharmacyInvoiceGenerated AS g ON A.Trans_Key = g.PMRTrans_Key AND B.Item_Code = g.Item_Code LEFT OUTER JOIN
                         dbo.ItemRegistration AS k ON B.Item_Code COLLATE database_DEFAULT = k.Item_Code COLLATE database_DEFAULT LEFT OUTER JOIN
                         dbo.ItemDetails AS o ON o.Item_Code = B.Item_Code AND o.BranchID = '01' LEFT OUTER JOIN
                         dbo.DrugList AS m ON m.GTIN = o.GTIN LEFT OUTER JOIN
                         dbo.DrugList AS n ON k.RegistrationNo COLLATE database_DEFAULT = n.RegistrationNo COLLATE database_DEFAULT
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PMRPharmacyMedicinePrint_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'       Begin Table = "k"
            Begin Extent = 
               Top = 138
               Left = 274
               Bottom = 268
               Right = 444
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "o"
            Begin Extent = 
               Top = 798
               Left = 38
               Bottom = 928
               Right = 239
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "m"
            Begin Extent = 
               Top = 930
               Left = 38
               Bottom = 1060
               Right = 259
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "n"
            Begin Extent = 
               Top = 1062
               Left = 38
               Bottom = 1192
               Right = 259
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PMRPharmacyMedicinePrint_View';


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
         Begin Table = "A"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "B"
            Begin Extent = 
               Top = 6
               Left = 260
               Bottom = 136
               Right = 453
            End
            DisplayFlags = 280
            TopColumn = 32
         End
         Begin Table = "C"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "D"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 400
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "E"
            Begin Extent = 
               Top = 402
               Left = 38
               Bottom = 532
               Right = 284
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "F"
            Begin Extent = 
               Top = 534
               Left = 38
               Bottom = 664
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "g"
            Begin Extent = 
               Top = 666
               Left = 38
               Bottom = 796
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
  ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PMRPharmacyMedicinePrint_View';

