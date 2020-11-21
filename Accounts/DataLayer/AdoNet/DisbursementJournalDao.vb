Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for DisbursementJournal
    ' ** DAO Pattern

    Public MustInherit Class DisbursementJournalDao
        Inherits DaoAccounts
        Implements IDao(Of DisbursementJournal), IDaoJournals(Of DisbursementJournal), IDaoOiItem(Of CjOiItem)

        Private ReadOnly _db As New Db()
        Protected TableName As String
        Protected SeriesName As String

        Public Function GetRecordById(idNo) As DisbursementJournal _
            Implements IDao(Of DisbursementJournal).GetRecordById
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Applied," &
                    "Cancelled," &
                    "DateCreated," &
                    "DiscountAccountIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "Notes," &
                    "ORNumber," &
                    "PayeeIdNo," &
                    "PayeeName," &
                    "PaymentType," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate," &
                    "UnApplied," &
                    "VatAmount," &
                    "VatNumber" &
                    " FROM " & TableName &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim jiDao = GetJiDao()
            Dim oiDao = GetCjOiItemDao()
            Dim ji = jiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            Dim oi = oiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            data.JournalItems = ji
            data.CjOiItems = oi
            Return data
        End Function

        Protected MustOverride Function GetJiDao()

        Protected MustOverride Function GetCjOiItemDao()

        Public Function UpdateRecord(ByRef DisbursementJournal As DisbursementJournal) As Integer _
            Implements IDao(Of DisbursementJournal).UpdateRecord
            Dim sql As String =
                    " UPDATE " & TableName & " SET " &
                    "AccountIdNo   = @AccountIdNo," &
                    "Amount        = @Amount," &
                    "Applied       = @Applied," &
                    "Cancelled     = @Cancelled," &
                    "DiscountAccountIdNo = @DiscountAccountIdNo," &
                    "DiscountTaken = @DiscountTaken," &
                    "Notes         = @Notes," &
                    "ORNumber      = @ORNumber," &
                    "PayeeIdNo     = @PayeeIdNo," &
                    "PayeeName     = @PayeeName," &
                    "PaymentType   = @PaymentType," &
                    "Posted        = @Posted," &
                    "ReferenceNo   = @ReferenceNo," &
                    "TransactionDate = @TransactionDate," &
                    "UnApplied     = @UnApplied," &
                    "VatAmount     = @VatAmount," &
                    "VatNumber     = @VatNumber" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(DisbursementJournal))
        End Function

        Public Function AddRecord(ByRef disbursementJournal As DisbursementJournal) As Integer _
            Implements IDao(Of DisbursementJournal).AddRecord
            Dim sql As String = " INSERT INTO " & TableName &
                    "AccountIdNo," &
                    "Amount," &
                    "Applied," &
                    "Cancelled," &
                    "DiscountAccountIdNo," &
                    "DiscountTaken," &
                    "Notes," &
                    "ORNumber," &
                    "PayeeIdNo," &
                    "PayeeName," &
                    "PaymentType," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate," &
                    "UnApplied," &
                    "VatAmount," &
                    "VatNumber" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@Amount," &
                    "@Applied," &
                    "@Cancelled," &
                    "@DiscountAccountIdNo," &
                    "@DiscountTaken," &
                    "@Notes," &
                    "@ORNumber," &
                    "@PayeeIdNo," &
                    "@PayeeName," &
                    "@PaymentType," &
                    "@Posted," &
                    "@ReferenceNo," &
                    "@TransactionDate," &
                    "@UnApplied," &
                    "@VatAmount," &
                    "@VatNumber" &
                    ")"
            Return _db.Insert(sql, Take(disbursementJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DisbursementJournal) =
                                    Function(reader) _
            New DisbursementJournal() With {
            .AccountIdNo = Extensions.AsNullable(Of Int16?)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .DiscountAccountIdNo = Extensions.AsNullable(Of Int16?)(reader("DiscountAccountIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OrNumber = Extensions.AsString(reader("ORNumber")),
            .PayeeIdNo = Extensions.AsNullable(Of Int32)(reader("PayeeIdNo")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .UnApplied = Extensions.AsDecimal(reader("UnApplied")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = Extensions.AsString(reader("VatNumber"))
            }

        Private Function Take(disbursementJournal As DisbursementJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", disbursementJournal.AccountIdNo,
                                    "@Amount", disbursementJournal.Amount,
                                    "@Applied", disbursementJournal.Applied,
                                    "@Cancelled", disbursementJournal.Cancelled,
                                    "@DateCreated", disbursementJournal.DateCreated,
                                    "@DiscountAccountIdNo", disbursementJournal.DiscountAccountIdNo,
                                    "@DiscountTaken", disbursementJournal.DiscountTaken,
                                    "@IdNo", disbursementJournal.IdNo,
                                    "@Notes", disbursementJournal.Notes,
                                    "@ORNumber", disbursementJournal.OrNumber,
                                    "@PayeeIdNo", disbursementJournal.PayeeIdNo,
                                    "@PayeeName", disbursementJournal.PayeeName,
                                    "@PaymentType", disbursementJournal.PaymentType,
                                    "@Posted", disbursementJournal.Posted,
                                    "@ReferenceNo", disbursementJournal.ReferenceNo,
                                    "@TransactionDate", disbursementJournal.TransactionDate,
                                    "@UnApplied", disbursementJournal.UnApplied,
                                    "@VatAmount", disbursementJournal.VatAmount,
                                    "@VatNumber", disbursementJournal.VatNumber
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As DisbursementJournal) As Integer Implements IDaoJournals(Of DisbursementJournal).UpdateGlReferenceNumber
            Dim retVal As Boolean
            Dim sql1 As String
            Dim sql2 As String
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & SeriesName & "'"
            sql2 = "Update [disbursementJournal] set ReferenceNo = (select value from series where seriesName = '" & SeriesName & "') where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        Public Function GetOpenInvoices(idNo As Integer) As List(Of CjOiItem) Implements IDaoOiItem(Of CjOiItem).GetOpenInvoices
            Dim oiDao = GetCjOiItemDao()
            Return oiDao.GetOpenInvoices(idNo)
        End Function

    End Class

End Namespace