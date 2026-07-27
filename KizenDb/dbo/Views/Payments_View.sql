




CREATE VIEW [dbo].[Payments_View]
AS
SELECT dbo.A1_payments.ID, 
dbo.A1_payments.Date, 
dbo.A1_payments.Type, 
dbo.A1_payments.Value, 
dbo.A1_payments.OrderID, 
dbo.A1_payments.Time, 
dbo.A1_payments.UserName, 
dbo.A1_payments.Note, 
dbo.A1_payments.[Declare], 
dbo.A1_payments.Bank, 
dbo.A1_payments.ATM, 
dbo.A1_payments.Vendor, 
dbo.A1_payments.Box, 
dbo.A1_payments.VendorPercent, 
dbo.A1_payments.DrName, 
dbo.A1_payments.DrID, 
dbo.A1_payments.Details, 
dbo.A1_payments.DeviceName, 
dbo.A1_payments.BankTranID, 
dbo.A1_payments.VATPer, 
dbo.A1_payments.BoxID, 
dbo.InvoicesSummary_View.CustName, 
dbo.InvoicesSummary_View.CustId, 
dbo.InvoicesSummary_View.IsInsurance,
dbo.InvoicesSummary_View.CompanyCode, 
dbo.InvoicesSummary_View.IsReturn, 
dbo.InvoicesSummary_View.Total, 
dbo.InvoicesSummary_View.DiscountAmount, 
dbo.InvoicesSummary_View.AmountBeforeVat, 
dbo.InvoicesSummary_View.VatableAmountSA, 
dbo.InvoicesSummary_View.VatableAmountNS, 
dbo.InvoicesSummary_View.VatAmountSA, 
dbo.InvoicesSummary_View.VatAmountNS, 
dbo.InvoicesSummary_View.ZeroVatRateAmount, 
dbo.InvoicesSummary_View.VatExemption, 
dbo.InvoicesSummary_View.InvoiceDate, 
dbo.InvoicesSummary_View.InvoiceDateTime,
dbo.InvoicesSummary_View.NetAmount as InvoiceNetAmount,
Round(iif(dbo.InvoicesSummary_View.NetAmount=0,0,dbo.A1_payments.[Value] * Total / NetAmount),2) as AdjTotal,
Round(iif(dbo.InvoicesSummary_View.NetAmount=0,0,dbo.A1_payments.[Value] * DiscountAmount / NetAmount),2) as AdjDiscountAmount, 
Round(iif(dbo.InvoicesSummary_View.NetAmount=0,0,dbo.A1_payments.[Value] * AmountBeforeVat / NetAmount),2) as AdjAmountBeforeVat, 
dbo.A1_payments.[Value] as NetAmount, 
Round(iif(dbo.InvoicesSummary_View.NetAmount=0,0,dbo.A1_payments.[Value] * VatableAmountSA / NetAmount),2) as AdjVatableAmountSA, 
Round(iif(dbo.InvoicesSummary_View.NetAmount=0,0,dbo.A1_payments.[Value] * VatableAmountNS / NetAmount),2) as AdjVatableAmountNS, 
Round(iif(dbo.InvoicesSummary_View.NetAmount=0,0,dbo.A1_payments.[Value] * VatAmountSA / NetAmount),2) as AdjVatAmountSA, 
Round(iif(dbo.InvoicesSummary_View.NetAmount=0,0,dbo.A1_payments.[Value] * VatAmountNS / NetAmount),2) as AdjVatAmountNS,
Round(iif(dbo.InvoicesSummary_View.NetAmount=0,0,dbo.A1_payments.[Value] * ZeroVatRateAmount / NetAmount),2) as AdjZeroVatRateAmount,
Round(iif(dbo.InvoicesSummary_View.NetAmount=0,0,dbo.A1_payments.[Value] * VatExemption / NetAmount),2) as AdjVatExemption,
dbo.InvoicesSummary_View.Cash 
FROM dbo.A1_payments 
left join dbo.InvoicesSummary_View 
on  dbo.A1_payments.OrderID = dbo.InvoicesSummary_View.InvoiceNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Payments_View';


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
         Begin Table = "A1_payments"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 423
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "InvoicesSummary_View"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 423
               Right = 521
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
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Payments_View';

