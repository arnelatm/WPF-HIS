
CREATE VIEW [dbo].[ApInvoices_View]
AS
SELECT        dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.JournalItemIdNo, dbo.APDetails_View.AccountIdNo, dbo.APDetails_View.Debit, dbo.APDetails_View.Credit, dbo.APDetails_View.RevCostCenterIdNo, 
                         dbo.APDetails_View.Notes, dbo.APDetails_View.Posted, dbo.Chart.AccountCode, dbo.Chart.AccountName, dbo.Chart.AccountNameAra, dbo.APDetails_View.SupplierIdNo, dbo.APDetails_View.InvoiceNo, 
                         dbo.APDetails_View.TransactionDate, dbo.APDetails_View.ReferenceNo, dbo.APDetails_View.TransactionType, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.Chart.SpecialAccount, 
                         dbo.ApOpenInvoice.IdNo, dbo.ApOpenInvoice.JournalIdNo, dbo.Supplier.SupplierCode
FROM            dbo.Supplier RIGHT OUTER JOIN
                         dbo.APDetails_View ON dbo.Supplier.IdNo = dbo.APDetails_View.SupplierIdNo RIGHT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.APDetails_View.IdNo = dbo.ApOpenInvoice.JournalItemIdNo AND 
                         dbo.APDetails_View.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS = dbo.ApOpenInvoice.JournalCode LEFT OUTER JOIN
                         dbo.Chart ON dbo.APDetails_View.AccountIdNo = dbo.Chart.IDNo

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[61] 4[11] 3[6] 2) )"
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
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 255
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "APDetails_View"
            Begin Extent = 
               Top = 36
               Left = 280
               Bottom = 504
               Right = 459
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 6
               Left = 603
               Bottom = 335
               Right = 801
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 6
               Left = 839
               Bottom = 519
               Right = 1033
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
         Column = 4470
         Alias = 900
         Table = 3780
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ApInvoices_View';






GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ApInvoices_View';

