
CREATE VIEW [dbo].[LabReportStatus_View]
AS
SELECT dbo.VisitAnalysesData.PatID AS MRN, dbo.VisitAnalysesData.PatName AS PatientName, dbo.VisitAnalysesData.RegUserName AS RequestedBy, dbo.VisitAnalysesData.ResultTakenDate AS ValidatedDateTime, 
                  dbo.VisitAnalysesData.ResultTakenEnb AS Completed, Convert(Varchar,dbo.VisitAnalysesData.RegDate)+' '+ COnvert(VarChar, dbo.VisitAnalysesData.RegTime) as RequestedDateTime, dbo.VisitAnalysesData.ReceivedDate AS CollectedDateTime, dbo.VisitAnalysesData.ReceivedUser AS CollectedBy, 
                  dbo.VisitAnalysesData.CollectedDate AS ProcessedDateTime, dbo.VisitAnalysesData.CollectedUser AS ProcessedBy, dbo.VisitAnalysesData.LastEditUser AS ValidatedBy, dbo.Customers.CustName AS PatientNameMRN, 
                  dbo.Customers.CustGender AS Gender, dbo.Customers.CustNat AS Nationality, dbo.DateToAge(dbo.Customers.CustBirthday, dbo.VisitAnalysesData.RegDate) AS Age, dbo.VisitAnalysesData.ID AS SampleNo, 
                  dbo.VisitAnalysesData.OrderID AS InvoiceNo
FROM     dbo.VisitAnalysesData INNER JOIN
                  dbo.Customers ON dbo.VisitAnalysesData.PatID = dbo.Customers.CustID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'LabReportStatus_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[32] 4[52] 2[1] 3) )"
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
         Top = -120
         Left = 0
      End
      Begin Tables = 
         Begin Table = "VisitAnalysesData"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 563
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Customers"
            Begin Extent = 
               Top = 7
               Left = 302
               Bottom = 563
               Right = 586
            End
            DisplayFlags = 280
            TopColumn = 23
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
         Column = 4476
         Alias = 3432
         Table = 4608
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'LabReportStatus_View';

