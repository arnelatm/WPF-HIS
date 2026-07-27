
CREATE VIEW [dbo].[DiagnosticServicesInvoice_View]
AS
SELECT dbo.A1_Invoces.ID, 
dbo.A1_Invoces.Date AS InvoiceDate, 
dbo.A1_Invoces.CustID AS FileNumber, 
Cast(dbo.A1_Works.Name as nvarchar(255)) AS ItemName, 
dbo.Customers.CustGender AS Gender, 
dbo.Customers.CustNat AS Nationality
FROM     dbo.A1_Invoces INNER JOIN
                  dbo.A1_OrderWorks ON dbo.A1_Invoces.ID = dbo.A1_OrderWorks.OrderID INNER JOIN
                  dbo.A1_Works ON dbo.A1_OrderWorks.WorkID = dbo.A1_Works.Code INNER JOIN
                  dbo.Customers ON dbo.A1_Invoces.CustID = dbo.Customers.CustID
where dbo.A1_works.GroupCode='T'
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'DiagnosticServicesInvoice_View';


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
         Begin Table = "A1_Invoces"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 423
               Right = 372
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "A1_OrderWorks"
            Begin Extent = 
               Top = 7
               Left = 420
               Bottom = 423
               Right = 749
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "A1_Works"
            Begin Extent = 
               Top = 7
               Left = 797
               Bottom = 423
               Right = 1093
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Customers"
            Begin Extent = 
               Top = 7
               Left = 1141
               Bottom = 415
               Right = 1425
            End
            DisplayFlags = 280
            TopColumn = 4
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
         Alias = 3552
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'DiagnosticServicesInvoice_View';

