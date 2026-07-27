





CREATE VIEW [dbo].[InvoicesList_View]
AS
SELECT dbo.A1_Invoces.ID AS InvoiceNo, Cast(dbo.A1_Invoces.Date as Date) as InvoiceDate, dbo.A1_Invoces.CustID, dbo.A1_Invoces.CustName, dbo.A1_Invoces.Type, dbo.A1_Invoces.DrName, dbo.A1_Invoces.DrID, dbo.A1_Invoces.IsInsurance, 
                  dbo.A1_Invoces.InsuranceCompany AS CompanyCode, dbo.A1_Invoces.CustIdentity, dbo.A1_Invoces.CustNat, dbo.A1_Invoces.Clinic, dbo.A1_Invoces.IsReturn, dbo.A1_OrderWorks.ID AS InvoiceDetailId, dbo.A1_Works.Code, 
                  dbo.A1_Works.Name AS ItemName, dbo.A1_OrderWorks.Count, dbo.A1_OrderWorks.Price, dbo.A1_OrderWorks.Total, dbo.A1_OrderWorks.DiscNet AS DiscountAmount, dbo.A1_OrderWorks.InsuranceTahamalAfterVAT AS NetAmount, 
                  dbo.A1_OrderWorks.VATPer, dbo.A1_OrderWorks.Total * abs(dbo.A1_OrderWorks.VATPer/100) as VatValue, dbo.A1_OrderWorks.TotalNoVAT,Round(-1 * (dbo.A1_OrderWorks.InsuranceTahamalAfterVAT - dbo.A1_OrderWorks.InsuranceTahamal - dbo.A1_OrderWorks.Total * abs(dbo.A1_OrderWorks.VATPer/100)),2) as VatExemption, dbo.Insurance_Company.LatinName AS CompanyName
FROM     dbo.A1_Invoces INNER JOIN
                  dbo.A1_OrderWorks ON dbo.A1_Invoces.ID = dbo.A1_OrderWorks.OrderID INNER JOIN
                  dbo.A1_Works ON dbo.A1_OrderWorks.WorkID = dbo.A1_Works.Code INNER JOIN
                  dbo.Insurance_Company ON dbo.A1_Invoces.InsuranceCompany = dbo.Insurance_Company.Code
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'InvoicesList_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' 11
         Column = 2472
         Alias = 900
         Table = 4932
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'InvoicesList_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[26] 4[39] 2[20] 3) )"
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
         Begin Table = "A1_Invoces"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 472
               Right = 372
            End
            DisplayFlags = 280
            TopColumn = 16
         End
         Begin Table = "A1_OrderWorks"
            Begin Extent = 
               Top = 7
               Left = 420
               Bottom = 472
               Right = 749
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "A1_Works"
            Begin Extent = 
               Top = 7
               Left = 797
               Bottom = 472
               Right = 1093
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Insurance_Company"
            Begin Extent = 
               Top = 15
               Left = 1130
               Bottom = 475
               Right = 1439
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
      Begin ColumnWidths = 22
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths =', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'InvoicesList_View';

