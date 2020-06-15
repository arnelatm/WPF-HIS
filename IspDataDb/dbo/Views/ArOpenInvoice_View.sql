CREATE VIEW dbo.ArOpenInvoice_View
AS
SELECT        dbo.ArOpenInvoice.IdNo, dbo.ArOpenInvoice.JournalCode, dbo.ArOpenInvoice.JournalItemIdNo, dbo.ARDetails_View.Debit - dbo.ARDetails_View.Credit AS Amount, dbo.ArOpenInvoice.PaidAmount, 
                         dbo.ArOpenInvoice.DiscountTaken, dbo.ARDetails_View.Debit - dbo.ARDetails_View.Credit - dbo.ArOpenInvoice.PaidAmount - dbo.ArOpenInvoice.DiscountTaken AS Balance, 
                         dbo.ARDetails_View.Debit - dbo.ARDetails_View.Credit AS InvoiceAmount, dbo.ArOpenInvoice.JournalIdNo, dbo.ARDetails_View.AccountIdNo, dbo.ARDetails_View.CustomerIdNo, 
                         dbo.ARDetails_View.ReferenceNo, dbo.ARDetails_View.TransactionType, dbo.ARDetails_View.TransactionDate, dbo.ARDetails_View.InvoiceNo, dbo.ARDetails_View.Notes, dbo.Chart.AccountCode, 
                         dbo.Chart.AccountName, dbo.Chart.AccountNameAra, dbo.Chart.SpecialAccount, dbo.Customer.CustomerCode
FROM            dbo.Customer RIGHT OUTER JOIN
                         dbo.ARDetails_View ON dbo.Customer.IdNo = dbo.ARDetails_View.CustomerIdNo RIGHT OUTER JOIN
                         dbo.ArOpenInvoice ON dbo.ARDetails_View.IdNo = dbo.ArOpenInvoice.JournalItemIdNo AND 
                         dbo.ARDetails_View.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS = dbo.ArOpenInvoice.JournalCode LEFT OUTER JOIN
                         dbo.Chart ON dbo.ARDetails_View.AccountIdNo = dbo.Chart.IDNo

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
         Begin Table = "ArOpenInvoice"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 332
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ARDetails_View"
            Begin Extent = 
               Top = 21
               Left = 316
               Bottom = 350
               Right = 495
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 18
               Left = 590
               Bottom = 148
               Right = 788
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Customer"
            Begin Extent = 
               Top = 6
               Left = 826
               Bottom = 299
               Right = 1030
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ArOpenInvoice_View';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ArOpenInvoice_View';

