
CREATE VIEW [dbo].[ApJournalTransaction_View]
AS
SELECT        dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.AccountIdNo AS ApAccountIdNo, dbo.ApJournalItem.Debit, dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, dbo.ApJournalItem.Notes AS ApNotes, 
                         dbo.ApJournalItem.Sequence, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Chart.AccountCode, dbo.Chart.AccountName, dbo.Chart.AccountNameAra, 
                         dbo.ApJournal.TransactionDate, dbo.ApJournal.ReferenceNo, dbo.ApJournal.TransactionType, dbo.ApJournal.Amount, dbo.ApJournal.AccountIdNo, dbo.ApJournal.InvoiceNo, dbo.ApJournal.InvoiceDate, 
                         dbo.ApJournal.VatNumber, dbo.ApJournal.VatAmount, dbo.ApJournal.Notes, dbo.ApJournal.DueDate, dbo.ApJournal.SettlementDueDate, dbo.ApJournal.SettlementDiscount, dbo.ApJournal.Posted, 
                         dbo.ApJournal.DateCreated, dbo.RevCostCenter.RevCostCenterNameAra, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName
FROM            dbo.ApJournalItem LEFT OUTER JOIN
                         dbo.RevCostCenter ON dbo.ApJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IdNo LEFT OUTER JOIN
                         dbo.Chart ON dbo.ApJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.ApJournal INNER JOIN
                         dbo.Supplier ON dbo.ApJournal.SupplierIdNo = dbo.Supplier.IdNo ON dbo.ApJournalItem.JournalIdNo = dbo.ApJournal.IDNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ApJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'    Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ApJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[35] 4[28] 2[21] 3) )"
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
               Top = 16
               Left = 25
               Bottom = 265
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 0
               Left = 614
               Bottom = 130
               Right = 812
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "ApJournal"
            Begin Extent = 
               Top = 0
               Left = 247
               Bottom = 275
               Right = 440
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 143
               Left = 574
               Bottom = 273
               Right = 768
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfitCenter"
            Begin Extent = 
               Top = 6
               Left = 850
               Bottom = 271
               Right = 1053
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
         Alias = 1560
         Table = 2760
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
     ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ApJournalTransaction_View';



