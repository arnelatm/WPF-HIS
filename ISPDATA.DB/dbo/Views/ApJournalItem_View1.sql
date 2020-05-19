CREATE VIEW [dbo].[ApJournalItem_View1]
AS
SELECT        dbo.ApJournalItem.IdNo, dbo.ApJournalItem.Sequence, dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.AccountIdNo, dbo.ApJournalItem.Debit, dbo.ApJournalItem.Credit, dbo.ApJournalItem.ProfitCenterIdNo, 
                         dbo.ApJournalItem.Notes, dbo.ApJournalItem.Posted, dbo.ApJournalItem.DateTimeStamp, dbo.Chart.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                         dbo.ApJournalItem.Credit - dbo.ApJournalItem.Debit AS OriginalAmount, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.Chart.SpecialAccount, dbo.Chart.AccountNameAra, dbo.Chart.PayeeType
FROM            dbo.ApJournalItem LEFT OUTER JOIN
                         dbo.Chart ON dbo.ApJournalItem.AccountIdNo = dbo.Chart.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.ApJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[49] 4[28] 2[6] 3) )"
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
         Begin Table = "ApJournalItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 156
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 0
               Left = 269
               Bottom = 130
               Right = 467
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 0
               Left = 644
               Bottom = 188
               Right = 821
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
         Column = 7905
         Alias = 2400
         Table = 2250
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ApJournalItem_View1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ApJournalItem_View1';

