CREATE VIEW dbo.CBCResult_View
AS
SELECT        dbo.IBSamplePrinting_View.LabSeries, dbo.IBSamplePrinting_View.RegistrationNo, dbo.IBSamplePrinting_View.LabReportNo, dbo.IBSamplePrinting_View.PatientName, dbo.CBCResults.WBC, dbo.CBCResults.Neutrophils, 
                         dbo.CBCResults.Lymphocytes, dbo.CBCResults.Monocytes, dbo.CBCResults.RBC, dbo.CBCResults.Hemoglobin, dbo.CBCResults.Hematocrit, dbo.CBCResults.MCV, dbo.CBCResults.MCH, dbo.CBCResults.RDWCV, 
                         dbo.CBCResults.RDWSD, dbo.CBCResults.Platelets, dbo.CBCResults.PCT, dbo.CBCResults.MPV, dbo.CBCResults.PDW, dbo.IBSamplePrinting_View.TransDateEnglish, dbo.IBSamplePrinting_View.CompanyID, 
                         dbo.IBSamplePrinting_View.Age, dbo.IBSamplePrinting_View.AgeYMD, dbo.IBSamplePrinting_View.Sex, dbo.IBSamplePrinting_View.TakenBy, dbo.IBSamplePrinting_View.TakenDate, dbo.IBSamplePrinting_View.TakenTime, 
                         dbo.IBSamplePrinting_View.TransType, dbo.InsuranceDetails.NameEnglish AS CompanyName, dbo.IBSamplePrinting_View.Phone, dbo.IBSamplePrinting_View.Border_Iqama, dbo.CBCResults.IdNo, dbo.CBCResults.InvoiceNo, 
                         dbo.CBCResults.SampleId, dbo.IBSamplePrinting_View.TransNBR, dbo.IBSamplePrinting_View.SampleNo
FROM            dbo.CBCResults INNER JOIN
                         dbo.IBSamplePrinting_View ON dbo.CBCResults.InvoiceNo = dbo.IBSamplePrinting_View.TransNBR LEFT OUTER JOIN
                         dbo.InsuranceDetails ON dbo.IBSamplePrinting_View.CompanyID = dbo.InsuranceDetails.InsuranceID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CBCResult_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[54] 4[25] 2[11] 3) )"
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
         Begin Table = "CBCResults"
            Begin Extent = 
               Top = 7
               Left = 18
               Bottom = 351
               Right = 188
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "IBSamplePrinting_View"
            Begin Extent = 
               Top = 15
               Left = 252
               Bottom = 492
               Right = 462
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "InsuranceDetails"
            Begin Extent = 
               Top = 6
               Left = 500
               Bottom = 492
               Right = 709
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
         Alias = 1440
         Table = 2325
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CBCResult_View';

