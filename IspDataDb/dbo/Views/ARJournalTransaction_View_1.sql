CREATE VIEW dbo.ARJournalTransaction_View
AS
SELECT        dbo.ArJournalItem.Sequence, dbo.ArJournalItem.JournalIdNo, dbo.ArJournalItem.Debit, dbo.ArJournalItem.Credit, dbo.ArJournalItem.Notes, dbo.ArJournalItem.Posted, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.ArJournal.TransactionDate, dbo.ArJournal.ReferenceNo, dbo.ArJournal.Amount, dbo.ArJournal.InvoiceNo, dbo.ArJournal.InvoiceDate, 
                         dbo.ArJournal.Notes AS Expr1, dbo.ArJournal.Posted AS Expr2, dbo.ArJournal.Cancelled, dbo.Chart.AccountCode, dbo.Chart.AccountName, dbo.Chart.AccountNameAra, dbo.ProfitCenter.ProfitCenterCode
FROM            dbo.ProfitCenter RIGHT OUTER JOIN
                         dbo.ArJournalItem ON dbo.ProfitCenter.IdNo = dbo.ArJournalItem.ProfitCenterIdNo LEFT OUTER JOIN
                         dbo.Chart ON dbo.ArJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.ArJournal LEFT OUTER JOIN
                         dbo.Customer ON dbo.ArJournal.CustomerIdNo = dbo.Customer.IdNo ON dbo.ArJournalItem.JournalIdNo = dbo.ArJournal.IDNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ARJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'  Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ARJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[70] 4[5] 2[8] 3) )"
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
         Begin Table = "ArJournal"
            Begin Extent = 
               Top = 19
               Left = 248
               Bottom = 325
               Right = 441
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Customer"
            Begin Extent = 
               Top = 9
               Left = 740
               Bottom = 139
               Right = 944
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 242
               Left = 497
               Bottom = 372
               Right = 695
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfitCenter"
            Begin Extent = 
               Top = 191
               Left = 723
               Bottom = 321
               Right = 926
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ArJournalItem"
            Begin Extent = 
               Top = 6
               Left = 19
               Bottom = 326
               Right = 198
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
       ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ARJournalTransaction_View';



