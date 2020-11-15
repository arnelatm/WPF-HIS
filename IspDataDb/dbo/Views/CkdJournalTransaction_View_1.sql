

CREATE VIEW [dbo].[CkdJournalTransaction_View]
AS
SELECT        dbo.CheckDisbursementJournal.TransactionDate, dbo.CheckDisbursementJournal.ReferenceNo, dbo.CheckDisbursementJournal.Amount, dbo.CheckDisbursementJournal.PayeeName, 
                         dbo.CheckDisbursementJournal.CheckNumber, dbo.CheckDisbursementJournal.CheckDate, dbo.CheckDisbursementJournal.Notes, dbo.CheckDisbursementJournal.PaymentType, 
                         dbo.CheckDisbursementJournalItem.Sequence, dbo.CheckDisbursementJournalItem.Debit, dbo.CheckDisbursementJournalItem.Credit, dbo.CheckDisbursementJournalItem.Notes AS CkNotes, 
                         dbo.BankAccount.BranchName, dbo.Bank.BankName, dbo.Bank.BankNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Employee.EmployeeCode, dbo.Supplier.SupplierNameAra, 
                         dbo.Employee.EmployeeNameAra, dbo.Employee.EmployeeName, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.CheckDisbursementJournal.IdNo, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra
FROM            dbo.CheckDisbursementJournal 
				LEFT OUTER JOIN dbo.CheckDisbursementJournalItem 
					ON dbo.CheckDisbursementJournal.IdNo = dbo.CheckDisbursementJournalItem.JournalIdNo 
				Left Outer Join dbo.Supplier 
					ON dbo.CheckDisbursementJournal.PayeeIdNo = dbo.Supplier.IdNo
				Left Outer Join dbo.Customer
				    ON dbo.CheckDisbursementJournal.PayeeIdNo = dbo.Customer.IdNo 
				Left Outer Join dbo.Employee 
					ON dbo.CheckDisbursementJournal.PayeeIdNo = dbo.Employee.IdNo 
				Left Outer Join dbo.BankAccount 
					ON dbo.CheckDisbursementJournal.AccountIdNo = dbo.BankAccount.AccountIdNo 
				LEFT OUTER JOIN dbo.Account 
					ON dbo.CheckDisbursementJournalItem.AccountIdNo = dbo.Account.IdNo 
				LEFT OUTER JOIN dbo.Bank 
					ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo 
				Left Outer Join dbo.RevCostCenter
					On dbo.CheckDisbursementJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CkdJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'           End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfitCenter"
            Begin Extent = 
               Top = 6
               Left = 736
               Bottom = 136
               Right = 939
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 324
               Left = 1060
               Bottom = 506
               Right = 1258
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CkdJournalTransaction_View';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[65] 4[17] 2[3] 3) )"
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
               Bottom = 626
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CheckDisbursementJournalItem"
            Begin Extent = 
               Top = 318
               Left = 317
               Bottom = 632
               Right = 606
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BankAccount"
            Begin Extent = 
               Top = 38
               Left = 1004
               Bottom = 249
               Right = 1174
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Bank"
            Begin Extent = 
               Top = 26
               Left = 1269
               Bottom = 376
               Right = 1443
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Customer"
            Begin Extent = 
               Top = 452
               Left = 750
               Bottom = 582
               Right = 954
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 307
               Left = 744
               Bottom = 437
               Right = 935
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 168
               Left = 742
               Bottom = 298
               Right = 936
 ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CkdJournalTransaction_View';

