


CREATE VIEW [dbo].[PMRMedicineDetails_View]
AS
SELECT        A.Trans_Key, A.TransNBR, A.TransDateEnglish, A.PatientType, A.Series, A.RegistrationNo, A.DoctorID, A.BillAmt, A.Issue_Flag, A.Dsh_Key, A.Remarks, A.UserID, A.Create_Date, A.MachineID, b.IdNo as PrescriptionItemIdNo, B.RowNBR, B.Item_Code, B.Qty, 
                         B.Unit, B.SalePrice, B.DiscountPer, B.DiscountAmt, B.Days, B.DosageID, C.ItemNameEnglish, C.ItemNameArabic, C.Pack1, C.Pack2, C.Pack3, C.Acct_Dept, CASE WHEN d .itemnameenglish IS NULL 
                         THEN b.DosageID ELSE d .ItemNameEnglish END AS DosageEnglish, CASE WHEN d .itemnamearabic IS NULL THEN b.DosageID ELSE d .ItemNameArabic END AS DosageArabic, E.DescriptionEnglish AS Duration, 
                         'PHR' AS DepartmentID, g.PharmacyTransNBR, g.Printed, IsNull(B.LabelPrinted,0) as LabelPrinted
FROM            dbo.PMRMedicineGroup AS A LEFT OUTER JOIN
                         dbo.PMRMedicineDetails AS B ON A.Trans_Key = B.Group_Key LEFT OUTER JOIN
                         dbo.ItemDetails AS C ON B.Item_Code = C.Item_Code AND C.BranchID = '01' LEFT OUTER JOIN
                         dbo.MedicineDosageMaster AS D ON B.DosageID = D.ItemID LEFT OUTER JOIN
                         dbo.PMRQtyDays AS E ON B.Days = E.id LEFT OUTER JOIN
                         dbo.EmployeeDetails AS F ON A.DoctorID = F.EmpID LEFT OUTER JOIN
                         dbo.PMRPharmacyInvoiceGenerated AS g ON A.Trans_Key = g.PMRTrans_Key AND B.Item_Code = g.Item_Code
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PMRMedicineDetails_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'     End
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PMRMedicineDetails_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[45] 4[16] 2[20] 3) )"
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
               Bottom = 125
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 10
         End
         Begin Table = "B"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 307
               Right = 425
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "C"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 239
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "D"
            Begin Extent = 
               Top = 138
               Left = 277
               Bottom = 268
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "E"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 383
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "F"
            Begin Extent = 
               Top = 384
               Left = 38
               Bottom = 514
               Right = 284
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "g"
            Begin Extent = 
               Top = 516
               Left = 38
               Bottom = 646
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
 ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PMRMedicineDetails_View';

