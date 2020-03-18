Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer

Namespace DataLayer.AdoNet
    ' Data access object for ChequeDisbursementJournal
    ' ** DAO Pattern

    Public Class ChequeDisbursementJournalDao
        Implements IDao(Of ChequeDisbursementJournal)

        Private Shared ReadOnly Db As New Db()

        Public Function GetRecordById(idNo As Integer) As ChequeDisbursementJournal _
            Implements IDao(Of ChequeDisbursementJournal).GetRecordById
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
                    " FROM [ChequeDisbursementJournal]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef chequeDisbursementJournal As ChequeDisbursementJournal) As Integer _
            Implements IDao(Of ChequeDisbursementJournal).UpdateRecord
            Dim sql As String =
                    "UPDATE [ChequeDisbursementJournal] SET " &
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
                    "PaymentType     = @PaymentType," &
                    "Posted        = @Posted," &
                    "ReferenceNo   = @ReferenceNo," &
                    "TransactionDate = @TransactionDate," &
                    "UnApplied     = @UnApplied," &
                    "VatAmount     = @VatAmount," &
                    "VatNumber     = @VatNumber" &
                    " WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(chequeDisbursementJournal))
        End Function

        Public Function AddRecord(ByRef chequeDisbursementJournal As ChequeDisbursementJournal) As Integer _
            Implements IDao(Of ChequeDisbursementJournal).AddRecord
            Dim sql As String = "INSERT INTO [ChequeDisbursementJournal] (" &
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
            Return Db.Insert(sql, Take(chequeDisbursementJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ChequeDisbursementJournal) =
                                    Function(reader) _
            New ChequeDisbursementJournal() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .CheckDate = Extensions.AsDate(reader("CheckDate")),
            .CheckNumber = Extensions.AsString(reader("CheckNumber")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .DiscountAccountIdNo = Extensions.AsInt(Of Integer)(reader("DiscountAccountIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OrNumber = Extensions.AsString(reader("ORNumber")),
            .PayeeIdNo = Extensions.AsInt(Of Integer)(reader("PayeeIdNo")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .UnApplied = Extensions.AsDecimal(reader("UnApplied")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = Extensions.AsString(reader("VatNumber"))
            }

        Private Function Take(chequeDisbursementJournal As ChequeDisbursementJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", chequeDisbursementJournal.AccountIdNo,
                                    "@Amount", chequeDisbursementJournal.Amount,
                                    "@Applied", chequeDisbursementJournal.Applied,
                                    "@Cancelled", chequeDisbursementJournal.Cancelled,
                                    "@CheckDate", chequeDisbursementJournal.CheckDate,
                                    "@CheckNumber", chequeDisbursementJournal.CheckNumber,
                                    "@DateCreated", chequeDisbursementJournal.DateCreated,
                                    "@DiscountAccountIdNo", chequeDisbursementJournal.DiscountAccountIdNo,
                                    "@DiscountTaken", chequeDisbursementJournal.DiscountTaken,
                                    "@IdNo", chequeDisbursementJournal.IdNo,
                                    "@Notes", chequeDisbursementJournal.Notes,
                                    "@ORNumber", chequeDisbursementJournal.OrNumber,
                                    "@PayeeIdNo", chequeDisbursementJournal.PayeeIdNo,
                                    "@PayeeName", chequeDisbursementJournal.PayeeName,
                                    "@PaymentType", chequeDisbursementJournal.PaymentType,
                                    "@Posted", chequeDisbursementJournal.Posted,
                                    "@ReferenceNo", chequeDisbursementJournal.ReferenceNo,
                                    "@TransactionDate", chequeDisbursementJournal.TransactionDate,
                                    "@UnApplied", chequeDisbursementJournal.UnApplied,
                                    "@VatAmount", chequeDisbursementJournal.VatAmount,
                                    "@VatNumber", chequeDisbursementJournal.VatNumber
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef model) As Integer Implements IDao(Of ChequeDisbursementJournal).UpdateGlReferenceNumber
            Dim retVal As Boolean
            Dim sql1 As String
            Dim sql2 As String
            Dim series = "CDJOURNAL"
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            sql2 = "Update [ChequeDisbursementJournal] set ReferenceNo = (select value from series where seriesName = '" & series & "') where IdNo = " & model.IdNo
            retVal = Db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

    End Class

End Namespace