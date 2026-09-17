Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer
    Public Class KizenCreditSalesImportService
        Private Const ArAccountCode As String = "112"
        Private Const OutputVatAccountCode As String = "232"
        Private Const VatExemptionAccountCode As String = "233"
        Private Const VatableRevenueAccountCode As String = "403"
        Private Const VatExemptRevenueAccountCode As String = "408"
        Private Const SaudiRevenueAccountCode As String = "491"
        Private Const DefaultCostCenterCode As String = "000"
        Private Const UnknownCostCenterCode As String = "999"

        Private Shared ReadOnly SourceSql As String =
            "SELECT v.InvoiceNo, v.InvoiceDate, v.CompanyCode, v.CompanyName, v.DrCode, " &
            "v.AmountBeforeVat, v.NetAmount, v.VatableAmountSA, v.VatableAmountNS, " &
            "v.VatValue, v.VatExemption, v.VatExemptAmt, invoice.ENumber AS ZatcaNumber " &
            "FROM dbo.InvoicesCredit_View v " &
            "OUTER APPLY (" &
            "SELECT TOP (1) ii.ENumber " &
            "FROM dbo.InsuranceInvoice ii " &
            "INNER JOIN dbo.Insurance_Company ic ON ic.ID = ii.InsuranceCompanyID " &
            "WHERE ic.Code = v.CompanyCode " &
            "AND ii.SupplyPeriodEndDate >= DATEADD(day, -1, @EndDate) " &
            "AND ii.SupplyPeriodEndDate < @EndDate " &
            "ORDER BY ii.ID DESC" &
            ") invoice " &
            "WHERE v.InvoiceDate >= @StartDate AND v.InvoiceDate < @EndDate " &
            "AND v.IsInsurance = 1 " &
            "AND NULLIF(LTRIM(RTRIM(v.CompanyCode)), '') IS NOT NULL " &
            "ORDER BY v.CompanyCode, v.InvoiceNo"

        Public Function LoadBatch(sourcePeriodStart As DateTime, sourcePeriodEnd As DateTime) As KizenCreditSalesBatch
            ValidateMonth(sourcePeriodStart, sourcePeriodEnd)
            Dim batch As New KizenCreditSalesBatch(sourcePeriodStart.Date, sourcePeriodEnd.Date)
            Dim workByCompany As New Dictionary(Of String, CompanyWork)(StringComparer.OrdinalIgnoreCase)
            Dim invoiceNumbers As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

            Using cn As New SqlConnection(New Db("KIZEN").GetConnectionString()), cmd As New SqlCommand(SourceSql, cn)
                cmd.CommandType = CommandType.Text
                cmd.CommandTimeout = 120
                AddDate(cmd, "@StartDate", batch.SourcePeriodStart)
                AddDate(cmd, "@EndDate", batch.SourcePeriodEnd.AddDays(1))
                cn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        batch.SourceDetailCount += 1
                        Dim invoiceNo = ReadText(reader, "InvoiceNo")
                        If Not String.IsNullOrWhiteSpace(invoiceNo) Then invoiceNumbers.Add(invoiceNo)

                        Dim companyCode = ReadText(reader, "CompanyCode").Trim()
                        Dim zatcaNumber = ReadText(reader, "ZatcaNumber").Trim()
                        Dim work As CompanyWork = Nothing
                        If Not workByCompany.TryGetValue(companyCode, work) Then
                            work = New CompanyWork With {
                                .CompanyCode = companyCode,
                                .CompanyName = ReadText(reader, "CompanyName"),
                                .ZatcaNumber = zatcaNumber
                            }
                            workByCompany.Add(companyCode, work)
                        End If

                        If Not String.IsNullOrWhiteSpace(zatcaNumber) Then
                            If Not String.IsNullOrWhiteSpace(work.ZatcaNumber) AndAlso
                               Not String.Equals(work.ZatcaNumber, zatcaNumber, StringComparison.OrdinalIgnoreCase) Then
                                Throw New InvalidOperationException(String.Format("Kizen company {0} has more than one ZATCA number in dbo.InsuranceInvoice.ENumber ({1} and {2}).", companyCode, work.ZatcaNumber, zatcaNumber))
                            End If
                            work.ZatcaNumber = zatcaNumber
                        End If

                        work.Amount += ReadDecimal(reader, "NetAmount")
                        work.VatAmount += ReadDecimal(reader, "VatValue")
                        work.Add("NS", ReadText(reader, "DrCode"), ReadDecimal(reader, "VatableAmountNS"))
                        work.Add("SA", ReadText(reader, "DrCode"), ReadDecimal(reader, "VatableAmountSA"))
                        work.Add("EX", ReadText(reader, "DrCode"), ReadDecimal(reader, "VatExemptAmt"))
                        work.Add("VAT", DefaultCostCenterCode, ReadDecimal(reader, "VatValue"))
                        work.Add("EXVAT", DefaultCostCenterCode, ReadDecimal(reader, "VatExemption"))
                        batch.SourceAmount += ReadDecimal(reader, "NetAmount")
                        batch.SourceVatAmount += ReadDecimal(reader, "VatValue")
                    End While
                End Using
            End Using

            batch.SourceInvoiceCount = invoiceNumbers.Count
            batch.SourceAmount = RoundMoney(batch.SourceAmount)
            batch.SourceVatAmount = RoundMoney(batch.SourceVatAmount)
            If workByCompany.Count = 0 Then Throw New InvalidOperationException("No insured credit sales were found for the selected month.")

            Dim accountIds = LoadAccountIds()
            Dim customerIds = LoadCustomerIds()
            Dim costCenterIds = LoadCostCenterIds()
            Dim defaultCostCenterId = RequireCostCenter(costCenterIds, DefaultCostCenterCode)
            Dim unknownCostCenterId = RequireCostCenter(costCenterIds, UnknownCostCenterCode)

            Dim batchSequence As Integer = 0
            For Each work In SortedCompanies(workByCompany)
                work.Amount = RoundMoney(work.Amount)
                work.VatAmount = RoundMoney(work.VatAmount)
                If work.Amount < 0D Then
                    Throw New InvalidOperationException(String.Format("Kizen company {0} has a negative net AR amount ({1:N2}). Resolve the source returns before importing.", work.CompanyCode, work.Amount))
                End If

                Dim customer As KizenCustomerMapping = Nothing
                If Not customerIds.TryGetValue(Normalize(work.CompanyCode), customer) Then
                    Throw New InvalidOperationException(String.Format("Kizen company code {0} ({1}) is not mapped to an ISPData customer.", work.CompanyCode, work.CompanyName))
                End If
                If String.IsNullOrWhiteSpace(work.ZatcaNumber) Then
                    Throw New InvalidOperationException(String.Format("Kizen insurance invoice for company {0} ({1}) has no ZATCA number in dbo.InsuranceInvoice.ENumber for the selected supply period.", work.CompanyCode, work.CompanyName))
                End If
                If work.ZatcaNumber.Length > 15 Then
                    Throw New InvalidOperationException(String.Format("ZATCA number {0} for company {1} exceeds the 15-character AR invoice-number limit.", work.ZatcaNumber, work.CompanyCode))
                End If

                Dim company As New KizenCreditSalesCompany With {
                    .BatchSequence = batchSequence + 1,
                    .CompanyCode = work.CompanyCode,
                    .CompanyName = work.CompanyName,
                    .ZatcaNumber = work.ZatcaNumber,
                    .CustomerIdNo = customer.CustomerIdNo,
                    .AccountIdNo = accountIds(ArAccountCode),
                    .DueDate = batch.SourcePeriodEnd.AddDays(customer.PaymentDueDays),
                    .Amount = work.Amount,
                    .VatAmount = work.VatAmount
                }
                batchSequence = company.BatchSequence
                AddItem(company, accountIds(ArAccountCode), work.Amount, 0D, defaultCostCenterId, "AR - " & work.CompanyCode)

                For Each bucket In work.Buckets.Values
                    Dim amount = RoundMoney(bucket.Amount)
                    If amount < 0D Then
                        Throw New InvalidOperationException(String.Format("Kizen company {0} has a negative posting amount for {1} ({2:N2}). Resolve the source returns before importing.", work.CompanyCode, bucket.Category, amount))
                    End If
                    If amount = 0D Then Continue For

                    Dim costCenterId = If(String.Equals(bucket.Category, "VAT", StringComparison.OrdinalIgnoreCase) OrElse
                                          String.Equals(bucket.Category, "EXVAT", StringComparison.OrdinalIgnoreCase),
                                          defaultCostCenterId,
                                          ResolveCostCenter(costCenterIds, bucket.CostCenterCode, unknownCostCenterId, work.CompanyCode))
                    Select Case bucket.Category
                        Case "NS"
                            AddItem(company, accountIds(VatableRevenueAccountCode), 0D, amount, costCenterId, "VATable non-Saudi - " & bucket.CostCenterCode)
                        Case "SA"
                            AddItem(company, accountIds(SaudiRevenueAccountCode), 0D, amount, costCenterId, "VATable Saudi - " & bucket.CostCenterCode)
                        Case "EX"
                            AddItem(company, accountIds(VatExemptRevenueAccountCode), 0D, amount, costCenterId, "VAT exempt - " & bucket.CostCenterCode)
                        Case "VAT"
                            AddItem(company, accountIds(OutputVatAccountCode), 0D, amount, defaultCostCenterId, "Output VAT")
                        Case "EXVAT"
                            AddItem(company, accountIds(VatExemptionAccountCode), amount, 0D, defaultCostCenterId, "Saudi VAT exemption")
                    End Select
                Next

                Dim debitTotal = RoundMoney(SumDebit(company.Items))
                Dim creditTotal = RoundMoney(SumCredit(company.Items))
                If Math.Abs(debitTotal - creditTotal) > 0.005D Then
                    Throw New InvalidOperationException(String.Format("Kizen company {0} is out of balance by {1:N2} after two-decimal posting conversion.", work.CompanyCode, debitTotal - creditTotal))
                End If
                If company.Items.Count > 0 AndAlso (debitTotal <> 0D OrElse creditTotal <> 0D) Then batch.Companies.Add(company)
            Next

            If batch.Companies.Count = 0 Then Throw New InvalidOperationException("The selected Kizen month contains no non-zero customer postings.")
            Dim headerTotal = RoundMoney(batch.Companies.Sum(Function(c) c.Amount))
            If Math.Abs(headerTotal - batch.SourceAmount) > 0.005D Then
                Throw New InvalidOperationException(String.Format("The Kizen AR total is {0:N2}, but the customer headers total {1:N2}.", batch.SourceAmount, headerTotal))
            End If
            Return batch
        End Function

        Public Function Import(batch As KizenCreditSalesBatch) As KizenCreditSalesImportResult
            If batch Is Nothing Then Throw New ArgumentNullException(NameOf(batch))
            If batch.Companies Is Nothing OrElse batch.Companies.Count = 0 Then Throw New InvalidOperationException("Preview the Kizen month before importing.")
            Dim headers = CreateHeaders(batch)
            Dim items = CreateItems(batch)
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("dbo.ImportKizenCreditSalesAtomic", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 120
                AddDate(cmd, "@SourcePeriodStart", batch.SourcePeriodStart)
                AddDate(cmd, "@SourcePeriodEnd", batch.SourcePeriodEnd)
                Add(cmd, "@SourceInvoiceCount", batch.SourceInvoiceCount, SqlDbType.Int)
                Add(cmd, "@SourceDetailCount", batch.SourceDetailCount, SqlDbType.Int)
                Add(cmd, "@SourceAmount", batch.SourceAmount, SqlDbType.Money)
                Add(cmd, "@CreatedBy", Environment.UserName, SqlDbType.NVarChar, 128)
                Dim headerParameter = cmd.Parameters.Add("@Headers", SqlDbType.Structured)
                headerParameter.TypeName = "dbo.KizenArJournalHeaderInsert"
                headerParameter.Value = headers
                Dim itemParameter = cmd.Parameters.Add("@Items", SqlDbType.Structured)
                itemParameter.TypeName = "dbo.KizenArJournalItemInsert"
                itemParameter.Value = items
                Dim referenceParameter = cmd.Parameters.Add("@ReferenceNo", SqlDbType.VarChar, 15)
                referenceParameter.Direction = ParameterDirection.Output
                Dim journalCountParameter = cmd.Parameters.Add("@JournalCount", SqlDbType.Int)
                journalCountParameter.Direction = ParameterDirection.Output
                cn.Open()
                AATM.DataLayer.AdoNet.AuditContext.Apply(cn)
                cmd.ExecuteNonQuery()
                Return New KizenCreditSalesImportResult With {
                    .ReferenceNo = Convert.ToString(referenceParameter.Value),
                    .JournalCount = Convert.ToInt32(journalCountParameter.Value),
                    .SourceInvoiceCount = batch.SourceInvoiceCount,
                    .SourceDetailCount = batch.SourceDetailCount,
                    .SourceAmount = batch.SourceAmount
                }
            End Using
        End Function

        Private Shared Function CreateHeaders(batch As KizenCreditSalesBatch) As DataTable
            Dim table As New DataTable()
            table.Columns.Add("BatchSequence", GetType(Integer))
            table.Columns.Add("CustomerIdNo", GetType(Integer))
            table.Columns.Add("AccountIdNo", GetType(Integer))
            table.Columns.Add("DueDate", GetType(DateTime))
            table.Columns.Add("Amount", GetType(Decimal))
            table.Columns.Add("VatAmount", GetType(Decimal))
            table.Columns.Add("InvoiceNo", GetType(String))
            table.Columns.Add("InvoiceDate", GetType(DateTime))
            table.Columns.Add("Notes", GetType(String))
            For Each company In batch.Companies
                table.Rows.Add(company.BatchSequence, company.CustomerIdNo, company.AccountIdNo, company.DueDate, company.Amount, company.VatAmount,
                               company.ZatcaNumber, batch.SourcePeriodEnd, "Credit Sales batch " & batch.SourcePeriodStart.ToString("yyyy-MM") & " - " & company.CompanyCode)
            Next
            Return table
        End Function

        Private Shared Function CreateItems(batch As KizenCreditSalesBatch) As DataTable
            Dim table As New DataTable()
            table.Columns.Add("BatchSequence", GetType(Integer))
            table.Columns.Add("Sequence", GetType(Integer))
            table.Columns.Add("AccountIdNo", GetType(Integer))
            table.Columns.Add("Debit", GetType(Decimal))
            table.Columns.Add("Credit", GetType(Decimal))
            table.Columns.Add("RevCostCenterIdNo", GetType(Integer))
            table.Columns.Add("Notes", GetType(String))
            For Each company In batch.Companies
                For Each item In company.Items
                    table.Rows.Add(company.BatchSequence, item.Sequence, item.AccountIdNo, item.Debit, item.Credit, item.RevCostCenterIdNo, item.Notes)
                Next
            Next
            Return table
        End Function

        Private Shared Sub AddItem(company As KizenCreditSalesCompany, accountIdNo As Integer, debit As Decimal, credit As Decimal, costCenterIdNo As Integer, notes As String)
            If debit = 0D AndAlso credit = 0D Then Return
            company.Items.Add(New KizenCreditSalesItem With {
                .Sequence = company.Items.Count + 1,
                .AccountIdNo = accountIdNo,
                .Debit = RoundMoney(debit),
                .Credit = RoundMoney(credit),
                .RevCostCenterIdNo = costCenterIdNo,
                .Notes = notes
            })
        End Sub

        Private Shared Function LoadAccountIds() As Dictionary(Of String, Integer)
            Dim result As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("SELECT IdNo, AccountCode FROM dbo.Account WHERE AccountCode IN ('112','232','233','403','408','491')", cn)
                cn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        result(Convert.ToString(reader("AccountCode")).Trim()) = Convert.ToInt32(reader("IdNo"))
                    End While
                End Using
            End Using
            For Each code In {ArAccountCode, OutputVatAccountCode, VatExemptionAccountCode, VatableRevenueAccountCode, VatExemptRevenueAccountCode, SaudiRevenueAccountCode}
                If Not result.ContainsKey(code) Then Throw New InvalidOperationException("ISPData account mapping is missing for account code " & code & ".")
            Next
            Return result
        End Function

        Private Shared Function LoadCustomerIds() As Dictionary(Of String, KizenCustomerMapping)
            Dim result As New Dictionary(Of String, KizenCustomerMapping)(StringComparer.OrdinalIgnoreCase)
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("SELECT IdNo, CustomerCode, PaymentDueDays FROM dbo.Customer WHERE CustomerCode IS NOT NULL", cn)
                cn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim code = Normalize(Convert.ToString(reader("CustomerCode")))
                        If code <> "" Then
                            result(code) = New KizenCustomerMapping With {
                                .CustomerIdNo = Convert.ToInt32(reader("IdNo")),
                                .PaymentDueDays = If(reader("PaymentDueDays") Is DBNull.Value, 0, Convert.ToInt32(reader("PaymentDueDays")))
                            }
                        End If
                    End While
                End Using
            End Using
            Return result
        End Function

        Private Shared Function LoadCostCenterIds() As Dictionary(Of String, Integer)
            Dim result As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("SELECT IDNo, RevCostCenterCode FROM dbo.RevCostCenter", cn)
                cn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        result(Normalize(Convert.ToString(reader("RevCostCenterCode")))) = Convert.ToInt32(reader("IDNo"))
                    End While
                End Using
            End Using
            Return result
        End Function

        Private Shared Function ResolveCostCenter(ids As Dictionary(Of String, Integer), sourceCode As String, unknownId As Integer, companyCode As String) As Integer
            Dim result As Integer = 0
            If ids.TryGetValue(Normalize(sourceCode), result) Then Return result
            If String.IsNullOrWhiteSpace(sourceCode) Then Return unknownId
            Throw New InvalidOperationException(String.Format("Kizen doctor/revenue code {0} for company {1} is not mapped to an ISPData revenue cost center.", sourceCode, companyCode))
        End Function

        Private Shared Function RequireCostCenter(ids As Dictionary(Of String, Integer), code As String) As Integer
            Dim result As Integer = 0
            If Not ids.TryGetValue(code, result) Then Throw New InvalidOperationException("ISPData revenue cost center " & code & " is required for Kizen imports.")
            Return result
        End Function

        Private Shared Function SortedCompanies(values As Dictionary(Of String, CompanyWork)) As List(Of CompanyWork)
            Dim result = New List(Of CompanyWork)(values.Values)
            result.Sort(Function(left, right) StringComparer.OrdinalIgnoreCase.Compare(left.CompanyCode, right.CompanyCode))
            Return result
        End Function

        Private Shared Sub ValidateMonth(sourcePeriodStart As DateTime, sourcePeriodEnd As DateTime)
            If sourcePeriodStart.Day <> 1 OrElse sourcePeriodEnd.Date <> sourcePeriodStart.Date.AddMonths(1).AddDays(-1) Then
                Throw New ArgumentException("Select the first through last day of one calendar month.")
            End If
        End Sub

        Private Shared Function ReadText(reader As SqlDataReader, columnName As String) As String
            Dim value = reader(columnName)
            Return If(value Is DBNull.Value, "", Convert.ToString(value))
        End Function

        Private Shared Function ReadDecimal(reader As SqlDataReader, columnName As String) As Decimal
            Dim value = reader(columnName)
            Return If(value Is DBNull.Value, 0D, Convert.ToDecimal(value))
        End Function

        Private Shared Function RoundMoney(value As Decimal) As Decimal
            Return Decimal.Round(value, 2, MidpointRounding.AwayFromZero)
        End Function

        Private Shared Function Normalize(value As String) As String
            Return If(value, "").Trim().ToUpperInvariant()
        End Function

        Private Shared Function SumDebit(items As IEnumerable(Of KizenCreditSalesItem)) As Decimal
            Dim total As Decimal = 0D
            For Each item In items : total += item.Debit : Next
            Return total
        End Function

        Private Shared Function SumCredit(items As IEnumerable(Of KizenCreditSalesItem)) As Decimal
            Dim total As Decimal = 0D
            For Each item In items : total += item.Credit : Next
            Return total
        End Function

        Private Shared Sub AddDate(command As SqlCommand, name As String, value As DateTime)
            command.Parameters.Add(name, SqlDbType.Date).Value = value.Date
        End Sub

        Private Shared Sub Add(command As SqlCommand, name As String, value As Object, type As SqlDbType, Optional size As Integer = 0)
            Dim parameter = If(size > 0, command.Parameters.Add(name, type, size), command.Parameters.Add(name, type))
            parameter.Value = If(value Is Nothing, DBNull.Value, value)
        End Sub

        Private Class CompanyWork
            Public Property CompanyCode As String
            Public Property CompanyName As String
            Public Property ZatcaNumber As String
            Public Property Amount As Decimal
            Public Property VatAmount As Decimal
            Public ReadOnly Property Buckets As New Dictionary(Of String, AmountBucket)(StringComparer.OrdinalIgnoreCase)

            Public Sub Add(category As String, costCenterCode As String, amount As Decimal)
                Dim normalizedCode = If(String.IsNullOrWhiteSpace(costCenterCode), UnknownCostCenterCode, costCenterCode.Trim())
                Dim key = category & ChrW(9) & normalizedCode
                Dim bucket As AmountBucket = Nothing
                If Not Buckets.TryGetValue(key, bucket) Then
                    bucket = New AmountBucket With {.Category = category, .CostCenterCode = normalizedCode}
                    Buckets.Add(key, bucket)
                End If
                bucket.Amount += amount
            End Sub
        End Class

        Private Class AmountBucket
            Public Property Category As String
            Public Property CostCenterCode As String
            Public Property Amount As Decimal
        End Class
    End Class
End Namespace
