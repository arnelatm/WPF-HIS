Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer
    Public Class KizenPharmacyJournalImportService
        Private Shared ReadOnly SourceSql As String =
            "SELECT LTRIM(RTRIM(COALESCE(d.CustomField1,''))) AS DoctorCode, " &
            "COUNT(*) AS ReceiptCount, COUNT(DISTINCT p.OrderID) AS InvoiceCount, " &
            "SUM(ISNULL(p.AdjAmountBeforeVat,0)-ISNULL(p.AdjZeroVatRateAmount,0)) AS Taxable, " &
            "SUM(ISNULL(p.AdjZeroVatRateAmount,0)) AS ZeroRated, " &
            "SUM(ISNULL(p.NetAmount,0)-ISNULL(p.AdjAmountBeforeVat,0)) AS Vat, " &
            "SUM(ISNULL(p.NetAmount,0)) AS WithVat " &
            "FROM dbo.Payments_View p " &
            "INNER JOIN dbo.A1_Invoces i ON i.ID=p.OrderID " &
            "LEFT JOIN dbo.Drs d ON d.DrID=i.DrID " &
            "WHERE p.Date>=@StartDate AND p.Date<@EndDate " &
            "AND (ISNULL(i.Clinic,'') LIKE N'%Pharmacy%' OR ISNULL(i.Clinic,'') LIKE N'%الصيدلية%') " &
            "GROUP BY LTRIM(RTRIM(COALESCE(d.CustomField1,''))) " &
            "HAVING SUM(ROUND(ISNULL(p.NetAmount,0),2))<>0 " &
            "ORDER BY DoctorCode"

        Public Function LoadBatch(startDate As DateTime, endDate As DateTime) As KizenRevenueJournalBatch
            If startDate.Day <> 1 OrElse endDate.Date <> startDate.Date.AddMonths(1).AddDays(-1) Then Throw New ArgumentException("Select the first through last day of one calendar month.")
            Dim batch As New KizenRevenueJournalBatch(startDate, endDate)
            Dim rows As New List(Of KizenRevenueCostCenter)()
            Using cn As New SqlConnection(New Db("KIZEN").GetConnectionString()), cmd As New SqlCommand(SourceSql, cn)
                cmd.CommandTimeout = 120
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate.Date
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate.Date.AddDays(1)
                cn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim code = Convert.ToString(reader("DoctorCode")).Trim()
                        If code = "" Then Throw New InvalidOperationException("A Pharmacy invoice has no Drs.CustomField1 doctor/revenue code.")
                        Dim amount = Money(reader("WithVat"))
                        rows.Add(New KizenRevenueCostCenter With {.DoctorCode = code, .RevCostCenterCode = code, .WithVat = amount, .Taxable = Money(reader("Taxable")), .ZeroRated = Money(reader("ZeroRated")), .Vat = Money(reader("Vat"))})
                        batch.ReceiptCount += Convert.ToInt32(reader("ReceiptCount"))
                        batch.InvoiceCount += Convert.ToInt32(reader("InvoiceCount"))
                    End While
                End Using
            End Using
            If rows.Count = 0 Then Throw New InvalidOperationException("No Kizen Pharmacy receipt sales were found for the selected month.")

            Dim accountIds = LoadAccountIds()
            Dim costCenterIds = LoadCostCenterIds()
            For Each row In rows
                Dim centerId As Integer
                If Not costCenterIds.TryGetValue(Normalize(row.DoctorCode), centerId) Then Throw New InvalidOperationException("Pharmacy doctor/revenue code " & row.DoctorCode & " has no ISPData RevCostCenter mapping.")
                row.RevCostCenterIdNo = centerId
                row.RevCostCenterName = LoadCostCenterName(centerId)
                batch.CostCenters.Add(row)
                batch.Taxable += row.Taxable
                batch.Vat += row.Vat
                batch.ZeroRated += row.ZeroRated
                batch.WithVat += row.WithVat
                AddItem(batch, accountIds("402"), row.Taxable, False, centerId, "Kizen Pharmacy - Taxable")
                AddItem(batch, accountIds("414"), row.ZeroRated, False, centerId, "Kizen Pharmacy - Zero-rated")
            Next
            batch.ZeroRated = Money(batch.ZeroRated)
            batch.WithVat = Money(batch.WithVat)
            batch.Taxable = Money(batch.Taxable) : batch.Vat = Money(batch.Vat)
            Dim difference = batch.WithVat - batch.Taxable - batch.ZeroRated - batch.Vat
            If Math.Abs(difference) > 0.1D Then Throw New InvalidOperationException("Pharmacy classifications do not reconcile to the receipt total.")
            If difference <> 0D Then
                batch.RoundingAdjustment = difference
                AddItem(batch, accountIds("402"), difference, False, batch.CostCenters.Last().RevCostCenterIdNo, "Pharmacy rounding adjustment")
            End If
            AddItem(batch, accountIds("232"), batch.Vat, False, 0, "Kizen Pharmacy - VAT")
            AddItem(batch, accountIds("419"), batch.WithVat, True, 0, "Kizen Pharmacy - Total receipts")
            batch.TotalLineCount = batch.Items.Count
            If batch.Items.Sum(Function(i) i.Debit) <> batch.Items.Sum(Function(i) i.Credit) Then Throw New InvalidOperationException("Pharmacy General Journal preview is out of balance.")
            Return batch
        End Function

        Public Function IsMonthImported(sourcePeriodStart As DateTime) As Boolean
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("SELECT COUNT(*) FROM dbo.KizenPharmacyJournalImport WHERE SourcePeriodStart=@SourcePeriodStart", cn)
                cmd.Parameters.Add("@SourcePeriodStart", SqlDbType.Date).Value = New DateTime(sourcePeriodStart.Year, sourcePeriodStart.Month, 1)
                cn.Open()
                Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        End Function

        Public Function Import(batch As KizenRevenueJournalBatch) As KizenRevenueJournalImportResult
            If batch Is Nothing OrElse batch.Items.Count = 0 Then Throw New InvalidOperationException("Preview the Pharmacy month before importing.")
            If IsMonthImported(batch.SourcePeriodStart) Then Return New KizenRevenueJournalImportResult With {.AlreadyImported = True}
            Dim table As New DataTable()
            table.Columns.Add("Sequence", GetType(Integer)) : table.Columns.Add("AccountIdNo", GetType(Integer))
            table.Columns.Add("Debit", GetType(Decimal)) : table.Columns.Add("Credit", GetType(Decimal))
            table.Columns.Add("RevCostCenterIdNo", GetType(Integer)) : table.Columns.Add("Notes", GetType(String))
            For Each item In batch.Items
                table.Rows.Add(item.Sequence, item.AccountIdNo, item.Debit, item.Credit, item.RevCostCenterIdNo, item.Notes)
            Next
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("dbo.ImportKizenPharmacyJournalAtomic", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@SourcePeriodStart", SqlDbType.Date).Value = batch.SourcePeriodStart
                cmd.Parameters.Add("@SourcePeriodEnd", SqlDbType.Date).Value = batch.SourcePeriodEnd
                cmd.Parameters.Add("@ReceiptCount", SqlDbType.Int).Value = batch.ReceiptCount
                cmd.Parameters.Add("@InvoiceCount", SqlDbType.Int).Value = batch.InvoiceCount
                cmd.Parameters.Add("@Taxable", SqlDbType.Money).Value = batch.Taxable
                cmd.Parameters.Add("@Vat", SqlDbType.Money).Value = batch.Vat
                cmd.Parameters.Add("@ZeroRated", SqlDbType.Money).Value = batch.ZeroRated
                cmd.Parameters.Add("@WithVat", SqlDbType.Money).Value = batch.WithVat
                Dim itemsParameter = cmd.Parameters.Add("@Items", SqlDbType.Structured)
                itemsParameter.TypeName = "dbo.KizenRevenueJournalItemInsert"
                itemsParameter.Value = table
                Dim journalId = cmd.Parameters.Add("@JournalIdNo", SqlDbType.Int) : journalId.Direction = ParameterDirection.Output
                Dim reference = cmd.Parameters.Add("@ReferenceNo", SqlDbType.NVarChar, 10) : reference.Direction = ParameterDirection.Output
                cn.Open() : cmd.ExecuteNonQuery()
                Return New KizenRevenueJournalImportResult With {.JournalIdNo = Convert.ToInt32(journalId.Value), .ReferenceNo = Convert.ToString(reference.Value)}
            End Using
        End Function

        Private Shared Function LoadAccountIds() As Dictionary(Of String, Integer)
            Dim result As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("SELECT IdNo,AccountCode FROM dbo.Account WHERE AccountCode IN ('419','414','402','232') AND DetailAccount=1 AND ISNULL(Active,1)=1", cn)
                cn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read() : result(Convert.ToString(reader("AccountCode"))) = Convert.ToInt32(reader("IdNo")) : End While
                End Using
            End Using
            For Each code In {"419", "414", "402", "232"}
                If Not result.ContainsKey(code) Then Throw New InvalidOperationException("Required active detail account " & code & " is missing in ISPData.")
            Next
            Return result
        End Function

        Private Shared Function LoadCostCenterIds() As Dictionary(Of String, Integer)
            Dim result As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("SELECT IDNo,RevCostCenterCode FROM dbo.RevCostCenter", cn)
                cn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read() : result(Normalize(Convert.ToString(reader("RevCostCenterCode")))) = Convert.ToInt32(reader("IDNo")) : End While
                End Using
            End Using
            Return result
        End Function

        Private Shared Function LoadCostCenterName(id As Integer) As String
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("SELECT RevCostCenterName FROM dbo.RevCostCenter WHERE IDNo=@IdNo", cn)
                cmd.Parameters.Add("@IdNo", SqlDbType.Int).Value = id : cn.Open()
                Return Convert.ToString(cmd.ExecuteScalar())
            End Using
        End Function

        Private Shared Sub AddItem(batch As KizenRevenueJournalBatch, accountId As Integer, amount As Decimal, debit As Boolean, centerId As Integer, notes As String)
            amount = Money(amount)
            If amount = 0D Then Return
            Dim itemDebit = If(debit, Math.Abs(amount), 0D), itemCredit = If(debit, 0D, Math.Abs(amount))
            If amount < 0D Then
                Dim oldDebit = itemDebit : itemDebit = itemCredit : itemCredit = oldDebit
            End If
            batch.Items.Add(New KizenRevenueJournalItem With {.Sequence = batch.Items.Count + 1, .AccountIdNo = accountId, .Debit = itemDebit, .Credit = itemCredit, .RevCostCenterIdNo = centerId, .Notes = notes})
        End Sub

        Private Shared Function Money(value As Object) As Decimal
            If value Is DBNull.Value Then Return 0D
            Return Decimal.Round(Convert.ToDecimal(value), 2, MidpointRounding.AwayFromZero)
        End Function
        Private Shared Function Normalize(value As String) As String
            Return If(value, "").Trim().ToUpperInvariant()
        End Function
    End Class
End Namespace
