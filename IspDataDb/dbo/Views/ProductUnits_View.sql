CREATE VIEW dbo.ProductUnits_View
AS
SELECT   dbo.Unit.UnitName, dbo.Product.ProductName, dbo.Product.ProductCode, dbo.Product.BaseUnitIdNo, Unit_1.UnitName AS BaseUnitName, dbo.ProductUnit.UnitIdNo, dbo.Unit.UnitCode, 
                         Unit_1.UnitCode AS Expr2, dbo.ProductUnit.UnitQty, dbo.ProductUnit.BaseQty, dbo.Product.IdNo
FROM         dbo.Unit AS Unit_1 INNER JOIN
                         dbo.Product ON Unit_1.IdNo = dbo.Product.BaseUnitIdNo INNER JOIN
                         dbo.ProductUnit INNER JOIN
                         dbo.Unit ON dbo.ProductUnit.UnitIdNo = dbo.Unit.IdNo ON dbo.Product.IdNo = dbo.ProductUnit.ProductIdNo

GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[68] 4[12] 2[10] 3) )"
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
         Begin Table = "Unit_1"
            Begin Extent = 
               Top = 228
               Left = 255
               Bottom = 358
               Right = 428
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 6
               Left = 28
               Bottom = 306
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "ProductUnit"
            Begin Extent = 
               Top = 0
               Left = 261
               Bottom = 204
               Right = 431
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Unit"
            Begin Extent = 
               Top = 11
               Left = 494
               Bottom = 202
               Right = 667
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
         Alias = 1665
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ProductUnits_View';


GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ProductUnits_View';


GO

