CREATE VIEW dbo.PcJournal_View
AS
SELECT        dbo.PcJournal.IdNo, dbo.PcJournal.TransactionDate, dbo.PcJournal.ReferenceNo, dbo.PcJournal.Amount, dbo.PcJournal.AccountIdNo, dbo.PcJournal.PaymentType, dbo.PcJournal.PayeeIdNo, dbo.PcJournal.PayeeName, 
                         dbo.PcJournal.ORNumber, dbo.PcJournal.DiscountTaken, dbo.PcJournal.DiscountAccountIdNo, dbo.PcJournal.Applied, dbo.PcJournal.UnApplied, dbo.PcJournal.VatNumber, dbo.PcJournal.VatAmount, dbo.PcJournal.Notes, 
                         dbo.PcJournal.Posted, dbo.PcJournal.DateCreated, dbo.PcJournal.Cancelled, dbo.PcJournal.DateTimeStamp, dbo.currency_conversion(dbo.PcJournal.Amount) AS WordAmount, dbo.Bank.BankCode, dbo.Bank.BankNameAra, 
                         dbo.BankAccount.BranchName
FROM            dbo.Bank LEFT OUTER JOIN
                         dbo.BankAccount ON dbo.Bank.IdNo = dbo.BankAccount.BankIdNo RIGHT OUTER JOIN
                         dbo.PcJournal ON dbo.BankAccount.AccountIdNo = dbo.PcJournal.AccountIdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PcJournal_View';


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
         Begin Table = "PcJournal"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 335
               Right = 245
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BankAccount"
            Begin Extent = 
               Top = 6
               Left = 283
               Bottom = 329
               Right = 453
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Bank"
            Begin Extent = 
               Top = 18
               Left = 607
               Bottom = 278
               Right = 780
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PcJournal_View';

