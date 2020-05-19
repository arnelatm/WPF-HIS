CREATE VIEW dbo.CashDisbursementJournalItem_View
AS
SELECT        dbo.CashDisbursementJournalItem.AccountIdNo, dbo.CashDisbursementJournalItem.Credit, dbo.CashDisbursementJournalItem.Debit, dbo.CashDisbursementJournalItem.IdNo, 
                         dbo.CashDisbursementJournalItem.JournalIdNo, dbo.CashDisbursementJournalItem.Notes, dbo.CashDisbursementJournalItem.ProfitCenterIdNo, dbo.CashDisbursementJournalItem.Sequence, 
                         dbo.Chart.AccountName, dbo.CashDisbursementJournalItem.Debit - dbo.CashDisbursementJournalItem.Credit AS OriginalAmount, dbo.Chart.PayeeType, dbo.Chart.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CashDisbursementJournalItem LEFT OUTER JOIN
                         dbo.Chart ON dbo.CashDisbursementJournalItem.AccountIdNo = dbo.Chart.IDNo LEFT OUTER JOIN
                         dbo.CashDisbursementJournal ON dbo.CashDisbursementJournalItem.JournalIdNo = dbo.CashDisbursementJournal.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CashDisbursementJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo AND dbo.ApOpenInvoice.JournalCode = 'CD'

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
         Begin Table = "CashDisbursementJournalItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 331
               Right = 303
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 202
               Left = 355
               Bottom = 332
               Right = 553
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CashDisbursementJournal"
            Begin Extent = 
               Top = 142
               Left = 596
               Bottom = 312
               Right = 846
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 8
               Left = 1051
               Bottom = 266
               Right = 1228
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CashDisbursementJournalItem_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CashDisbursementJournalItem_View';

