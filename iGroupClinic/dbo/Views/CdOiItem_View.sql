CREATE VIEW [dbo].[CdOiItem_View]
AS
SELECT        dbo.CdOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, dbo.ApOpenInvoice_View.Balance + dbo.CdOiItem.Amount + dbo.CdOiItem.DiscountTaken AS PreviousBalance, 
                         dbo.CdOiItem.Amount, dbo.CdOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, 
                         dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.CdOiItem.IdNo, dbo.CdOiItem.ApOpenInvoiceIdNo, 
                         dbo.ApOpenInvoice_View.SupplierIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo, dbo.CdOiItem.DjIdNo
FROM            dbo.CdOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.CdOiItem.ApOpenInvoiceIdNo = dbo.ApOpenInvoice_View.IdNo

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
         Begin Table = "ApOpenInvoice_View"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 335
               Right = 457
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CdOiItem"
            Begin Extent = 
               Top = 6
               Left = 23
               Bottom = 296
               Right = 235
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CdOiItem_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CdOiItem_View';

