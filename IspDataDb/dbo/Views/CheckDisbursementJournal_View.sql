CREATE VIEW dbo.CheckDisbursementJournal_View
AS
SELECT        dbo.CheckDisbursementJournal.IdNo, dbo.CheckDisbursementJournal.TransactionDate, dbo.CheckDisbursementJournal.ReferenceNo, dbo.CheckDisbursementJournal.Amount, 
                         dbo.CheckDisbursementJournal.AccountIdNo, dbo.CheckDisbursementJournal.PaymentType, dbo.CheckDisbursementJournal.PayeeIdNo, dbo.CheckDisbursementJournal.PayeeName, 
                         dbo.CheckDisbursementJournal.CheckNumber, dbo.CheckDisbursementJournal.CheckDate, dbo.CheckDisbursementJournal.ORNumber, dbo.CheckDisbursementJournal.DiscountTaken, 
                         dbo.CheckDisbursementJournal.DiscountAccountIdNo, dbo.CheckDisbursementJournal.Applied, dbo.CheckDisbursementJournal.UnApplied, dbo.CheckDisbursementJournal.VatNumber, 
                         dbo.CheckDisbursementJournal.VatAmount, dbo.CheckDisbursementJournal.Notes, dbo.CheckDisbursementJournal.Posted, dbo.CheckDisbursementJournal.DateCreated, 
                         dbo.CheckDisbursementJournal.Cancelled, dbo.CheckDisbursementJournal.DateTimeStamp, dbo.currency_conversion(dbo.CheckDisbursementJournal.Amount) AS WordAmount, dbo.Bank.BankNameAra, 
                         dbo.BankAccount.BranchName
FROM            dbo.CheckDisbursementJournal INNER JOIN
                         dbo.BankAccount ON dbo.CheckDisbursementJournal.AccountIdNo = dbo.BankAccount.AccountIdNo INNER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[47] 4[29] 2[6] 3) )"
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
         Begin Table = "CheckDisbursementJournal"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 372
               Right = 245
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BankAccount"
            Begin Extent = 
               Top = 73
               Left = 336
               Bottom = 338
               Right = 506
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Bank"
            Begin Extent = 
               Top = 187
               Left = 723
               Bottom = 317
               Right = 897
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CheckDisbursementJournal_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CheckDisbursementJournal_View';

