Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for CheckDisbursementJournal
    ' ** DAO Pattern

    Public Class CheckDisbursementJournalDao
        Implements IDao(Of CheckDisbursementJournal), IDaoJournals(Of CheckDisbursementJournal), IDaoOiItem(Of CkdOiItem)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As CheckDisbursementJournal _
            Implements IDao(Of CheckDisbursementJournal).GetRecordById
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Applied," &
                    "Cancelled," &
                    "CheckDate," &
                    "CheckNumber," &
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
                    " FROM [CheckDisbursementJournal]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim jiDao = New CheckDisbursementJournalItemDao
            Dim oiDao = New CkdOiItemDao
            Dim ji = jiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            Dim oi = oiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            data.JournalItems = ji
            data.CkdOiItems = oi
            Return data
        End Function

        Public Function UpdateRecord(ByRef checkDisbursementJournal As CheckDisbursementJournal) As Integer _
            Implements IDao(Of CheckDisbursementJournal).UpdateRecord
            Dim sql As String =
                    "UPDATE [CheckDisbursementJournal] SET " &
                    "AccountIdNo   = @AccountIdNo," &
                    "Amount        = @Amount," &
                    "Applied       = @Applied," &
                    "Cancelled     = @Cancelled," &
                    "CheckDate     = @CheckDate," &
                    "CheckNumber   = @CheckNumber," &
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
            Return _db.Update(sql, Take(checkDisbursementJournal))
        End Function

        Public Function AddRecord(ByRef checkDisbursementJournal As CheckDisbursementJournal) As Integer _
            Implements IDao(Of CheckDisbursementJournal).AddRecord
            Dim sql As String = "INSERT INTO [CheckDisbursementJournal] (" &
                    "AccountIdNo," &
                    "Amount," &
                    "Applied," &
                    "Cancelled," &
                    "CheckDate," &
                    "CheckNumber," &
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
                    "@CheckDate," &
                    "@CheckNumber," &
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
            Return _db.Insert(sql, Take(checkDisbursementJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CheckDisbursementJournal) =
                                    Function(reader) _
            New CheckDisbursementJournal() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .CheckDate = Extensions.AsDate(reader("CheckDate")),
            .CheckNumber = Extensions.AsString(reader("CheckNumber")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .DiscountAccountIdNo = Extensions.AsNullable(Of Int32?)(reader("DiscountAccountIdNo")),
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

        Private Function Take(checkDisbursementJournal As CheckDisbursementJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", checkDisbursementJournal.AccountIdNo,
                                    "@Amount", checkDisbursementJournal.Amount,
                                    "@Applied", checkDisbursementJournal.Applied,
                                    "@Cancelled", checkDisbursementJournal.Cancelled,
                                    "@CheckDate", checkDisbursementJournal.CheckDate,
                                    "@CheckNumber", checkDisbursementJournal.CheckNumber,
                                    "@DateCreated", checkDisbursementJournal.DateCreated,
                                    "@DiscountAccountIdNo", checkDisbursementJournal.DiscountAccountIdNo,
                                    "@DiscountTaken", checkDisbursementJournal.DiscountTaken,
                                    "@IdNo", checkDisbursementJournal.IdNo,
                                    "@Notes", checkDisbursementJournal.Notes,
                                    "@ORNumber", checkDisbursementJournal.OrNumber,
                                    "@PayeeIdNo", checkDisbursementJournal.PayeeIdNo,
                                    "@PayeeName", checkDisbursementJournal.PayeeName,
                                    "@PaymentType", checkDisbursementJournal.PaymentType,
                                    "@Posted", checkDisbursementJournal.Posted,
                                    "@ReferenceNo", checkDisbursementJournal.ReferenceNo,
                                    "@TransactionDate", checkDisbursementJournal.TransactionDate,
                                    "@UnApplied", checkDisbursementJournal.UnApplied,
                                    "@VatAmount", checkDisbursementJournal.VatAmount,
                                    "@VatNumber", checkDisbursementJournal.VatNumber
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As CheckDisbursementJournal) As Integer Implements IDaoJournals(Of CheckDisbursementJournal).UpdateGlReferenceNumber
            Dim retVal As Boolean
            Dim sql1 As String
            Dim sql2 As String
            Const series As String = "CKJOURNAL"
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            sql2 = "Update [CheckDisbursementJournal] set ReferenceNo = (select value from series where seriesName = '" & series & "') where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        Public Function GetOpenInvoices(idNo As Integer) As List(Of CkdOiItem) Implements IDaoOiItem(Of CkdOiItem).GetOpenInvoices
            Dim oiDao = New CkdOiItemDao
            Return oiDao.GetOpenInvoices(idNo)
        End Function

    End Class

End Namespace