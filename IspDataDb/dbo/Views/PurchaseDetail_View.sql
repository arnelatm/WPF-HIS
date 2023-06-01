






CREATE VIEW [dbo].[PurchaseDetail_View]
AS
SELECT        dbo.PurchaseDetail.IdNo, dbo.PurchaseDetail.Sequence, dbo.PurchaseDetail.PurchaseIdNo, dbo.PurchaseDetail.ProductIdNo, dbo.PurchaseDetail.Quantity, dbo.PurchaseDetail.BonusQuantity, dbo.PurchaseDetail.ExpiryDate, dbo.PurchaseDetail.UnitIdNo, dbo.PurchaseDetail.BatchNo,
                         dbo.PurchaseDetail.Price, dbo.PurchaseDetail.DiscountAmount, dbo.PurchaseDetail.UnitSalesPrice, dbo.PurchaseDetail.VatPercent, dbo.PurchaseDetail.VatAmount, dbo.PurchaseDetail.NetAmount, dbo.Product.ProductCode, dbo.Product.ProductName, 
                         dbo.Product.ProductNameAra, dbo.Product.Barcode, dbo.Product.GTIN, dbo.Product.BaseUnitIdNo, dbo.Unit.UnitCode, dbo.Unit.UnitName, dbo.Unit.UnitNameAra, dbo.Category.VatSaleAccountIdNo, 
                         dbo.Category.VatPurchaseAccountIdNo, dbo.Category.VatPercentage, dbo.Category.SaleAccountIdNo, dbo.Category.PurchaseAccountIdNo, dbo.Product.CategoryIdNo, (select count(dbo.ProductUnit.ProductIdNo) from dbo.ProductUnit where dbo.ProductUnit.ProductIdNo = dbo.PurchaseDetail.ProductIdNo) as UnitCount,
						 dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price as 'GrossAmount', dbo.Category.NeedsExpiryDate,
						 IIf(dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price = 0,0, dbo.PurchaseDetail.DiscountAmount / (dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price) * 100) as 'DiscountPercent',
						 IIf(dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price = 0,0, dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price) - dbo.PurchaseDetail.DiscountAmount as 'AmtBefVat',
						 IIf((dbo.PurchaseDetail.Quantity + dbo.PurchaseDetail.BonusQuantity) = 0,0,((dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price - dbo.PurchaseDetail.DiscountAmount) / (dbo.PurchaseDetail.Quantity + dbo.PurchaseDetail.BonusQuantity))) as 'UnitCost'
FROM            dbo.PurchaseDetail LEFT OUTER JOIN
                         dbo.Unit ON dbo.PurchaseDetail.UnitIdNo = dbo.Unit.IdNo LEFT OUTER JOIN
                         dbo.Product ON dbo.PurchaseDetail.ProductIdNo = dbo.Product.IdNo LEFT OUTER JOIN
                         dbo.Category ON dbo.Product.CategoryIdNo = dbo.Category.IdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PurchaseDetail_View';




GO



GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[45] 4[45] 2[3] 3) )"
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
         Begin Table = "PurchaseDetail"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 301
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Unit"
            Begin Extent = 
               Top = 9
               Left = 834
               Bottom = 139
               Right = 1004
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 19
               Left = 287
               Bottom = 315
               Right = 468
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Category"
            Begin Extent = 
               Top = 148
               Left = 553
               Bottom = 466
               Right = 778
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
         Column = 2520
         Alias = 1890
         Table = 4980
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PurchaseDetail_View';





