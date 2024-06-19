




CREATE VIEW [dbo].[IBLabResultList_View]
AS
SELECT CAST(b.TransDateEnglish AS Date) AS TransactionDate,a.PassportNumber, CAST(ISNULL(b.LabSeries, 0) AS VarChar(10)) 
                  + '-' + CASE WHEN b.IBTYPE = 1 THEN 'I' WHEN b.IBTYPE = 2 THEN 'B' WHEN b.IBTYPE = 3 THEN 'D' WHEN b.IBTYPE = 4 THEN 'FD' END AS LabNo, b.Border_Iqama, b.PatientName, c.CountryNameEng, b.Profession, Clinical, 
                  XRay, TBSputum, HIVEliza, HCVEliza, HBSAgEliza, Malaria, VDRL, Widal, Pregnancy, BilharziasisUrine, BilharziasisStool, Shigella, Cholera, b.IBType, a.IdNo, b.Trans_Key, b.Sex
FROM     dbo.IBLabResult AS a RIGHT OUTER JOIN
                  dbo.IBInvoiceGroup AS b ON a.Trans_Key = b.Trans_Key LEFT OUTER JOIN
                  dbo.CountryMaster AS c ON b.CountryIOTA = c.CountryIOTA
WHERE  (b.Rejected = 0) AND (b.IBType = 1) OR
                  (b.IBType = 2)
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'IBLabResultList_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[51] 4[12] 2[20] 3) )"
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
         Begin Table = "a"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 330
               Right = 251
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 15
               Left = 322
               Bottom = 410
               Right = 541
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 54
               Left = 768
               Bottom = 217
               Right = 997
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
         Column = 3084
         Alias = 2400
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'IBLabResultList_View';

