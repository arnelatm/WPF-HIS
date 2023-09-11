CREATE VIEW dbo.InvTransactionDetail_View
AS
SELECT     dbo.InvTransactionDetail.IdNo, dbo.InvTransactionDetail.Sequence, dbo.InvTransactionDetail.InvTransactionIdNo, dbo.InvTransactionDetail.ProductIdNo, dbo.InvTransactionDetail.Quantity, dbo.InvTransactionDetail.ExpiryDate, dbo.InvTransactionDetail.UnitIdNo, 
                  dbo.InvTransactionDetail.BatchNo, dbo.InvTransactionDetail.NetAmount, dbo.Product.ProductCode, dbo.Product.ProductName, dbo.Product.ProductNameAra, dbo.Product.Barcode, dbo.Product.GTIN, dbo.Product.BaseUnitIdNo, dbo.Unit.UnitCode, dbo.Unit.UnitName, dbo.Unit.UnitNameAra, 
                  dbo.Category.VatSaleAccountIdNo, dbo.Category.SaleAccountIdNo, dbo.Category.PurchaseAccountIdNo, dbo.Product.CategoryIdNo,
                      (SELECT     COUNT(ProductIdNo) 
                       FROM        dbo.ProductUnit
                       WHERE     (ProductIdNo = dbo.InvTransactionDetail.ProductIdNo)) AS UnitCount, dbo.Category.NeedsExpiryDate, dbo.InvTransactionDetail.UnitCost, dbo.InvTransactionDetail.InventoryIdNo
FROM        dbo.InvTransactionDetail LEFT OUTER JOIN
                  dbo.Unit ON dbo.InvTransactionDetail.UnitIdNo = dbo.Unit.IdNo LEFT OUTER JOIN
                  dbo.Product ON dbo.InvTransactionDetail.ProductIdNo = dbo.Product.IdNo LEFT OUTER JOIN
                  dbo.Category ON dbo.Product.CategoryIdNo = dbo.Category.IdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'InvTransactionDetail_View';


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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "InvTransactionDetail"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 642
               Right = 271
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Unit"
            Begin Extent = 
               Top = 15
               Left = 458
               Bottom = 178
               Right = 661
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 267
               Left = 333
               Bottom = 669
               Right = 542
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Category"
            Begin Extent = 
               Top = 203
               Left = 664
               Bottom = 644
               Right = 926
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'InvTransactionDetail_View';

