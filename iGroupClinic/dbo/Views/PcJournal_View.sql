CREATE VIEW dbo.PcJournal_View
AS
SELECT        a.IdNo, a.TransactionDate, a.ReferenceNo, a.Amount, a.AccountIdNo, a.PaymentType, a.PayeeIdNo, CASE WHEN a.PaymentType = 'A' OR
                         a.PaymentTYpe = 'S' THEN s.SupplierName WHEN a.PaymentType = 'R' THEN c.CustomerName WHEN a.PaymentType = 'E' THEN e.EMployeeName ELSE a.PayeeName END AS PayeeName, 
                         CASE WHEN a.PaymentType = 'A' OR
                         a.PaymentTYpe = 'S' THEN s.SupplierNameAra WHEN a.PaymentType = 'R' THEN c.CustomerNameAra WHEN a.PaymentType = 'E' THEN e.EMployeeNameAra ELSE a.PayeeName END AS PayeeNameAra, a.ORNumber, 
                         a.DiscountTaken, a.DiscountAccountIdNo, a.Applied, a.UnApplied, a.VatNumber, a.VatAmount, a.Notes, a.Posted, a.DateCreated, a.Cancelled, a.DateTimeStamp, a.PcClosed, a.CdJournalIdNo, a.PayType
FROM            dbo.PcJournal AS a LEFT OUTER JOIN
                         dbo.Supplier AS S ON a.PayeeIdNo = S.IdNo AND (a.PaymentType = 'A' OR
                         a.PaymentType = 'S') LEFT OUTER JOIN
                         dbo.Customer AS C ON a.PayeeIdNo = C.IdNo AND a.PaymentType = 'R' LEFT OUTER JOIN
                         dbo.Employee AS E ON a.PayeeIdNo = E.IdNo AND a.PaymentType = 'E'
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[30] 4[56] 2[3] 3) )"
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
         Top = -2304
         Left = 0
      End
      Begin Tables = 
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 565
               Right = 245
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "S"
            Begin Extent = 
               Top = 15
               Left = 973
               Bottom = 221
               Right = 1167
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "C"
            Begin Extent = 
               Top = 312
               Left = 470
               Bottom = 690
               Right = 674
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "E"
            Begin Extent = 
               Top = 146
               Left = 594
               Bottom = 276
               Right = 792
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
         Alias = 2535
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PcJournal_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PcJournal_View';

