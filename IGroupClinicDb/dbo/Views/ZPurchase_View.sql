










CREATE VIEW [dbo].[ZPurchase_View]
AS
SELECT      dbo.PurchaseGroup.Trans_Key AS IdNo, iif(dbo.PurchaseGroup.BranchID='01',2,1) AS BranchIdNo, IsNull(dbo.LinkSupplier.SupplierIdNo,0) as SupplierIdNo,
			Cast(dbo.PurchaseGroup.TransDate as Date) AS TransactionDate, TransNo as ReferenceNo, dbo.PurchaseGroup.PurchaseCostAmt as AmountBeforeVat,  dbo.PurchaseGroup.InvoiceAmt AS Amount,
			DateAdd(day,30,Cast(dbo.PurchaseGroup.TransDate as Date)) AS DueDate, dbo.PurchaseGroup.InvoiceNo, Cast(dbo.PurchaseGroup.TransDate as Date) AS InvoiceDate, dbo.SupplierDetails.VATNo as VatNumber, dbo.PurchaseGroup.VATAmt AS VatAmount, 
            0 as 'ExtraDiscount',0 as 'VatAmountDiscount', dbo.LinkWarehouse.WarehouseIdNo as WarehouseIdNo, IIf(dbo.PurchaseGroup.PostInStock='Y',1,0) AS Posted, Cast(0 as Bit) as 'Cancelled', dbo.PurchaseGroup.Create_Date AS DateCreated, dbo.LinkUser.UserIdNo
FROM        dbo.PurchaseGroup 
			LEFT JOIN dbo.SupplierDetails 
			ON dbo.PurchaseGroup.SupplierId = dbo.SupplierDetails.SupplierId
			left join dbo.LinkWarehouse
			on dbo.PurchaseGroup.BranchID = dbo.LinkWarehouse.Branchid and dbo.PurchaseGroup.WarehouseID = dbo.LinkWarehouse.WareHouseId
			LEFT JOIN dbo.LinkSupplier
			ON dbo.SupplierDetails.Primary_Key = dbo.LinkSupplier.SupplierId
			LEFT JOIN dbo.LinkUser
			on dbo.purchasegroup.userid = dbo.LinkUser.UserId
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ZPurchase_View';


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
         Begin Table = "PurchaseGroup"
            Begin Extent = 
               Top = 8
               Left = 18
               Bottom = 335
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SupplierDetails"
            Begin Extent = 
               Top = 6
               Left = 253
               Bottom = 332
               Right = 455
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LinkSupplier"
            Begin Extent = 
               Top = 6
               Left = 493
               Bottom = 278
               Right = 695
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1620
         Table = 2400
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ZPurchase_View';

