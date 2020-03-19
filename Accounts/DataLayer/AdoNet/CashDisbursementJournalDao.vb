Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CashDisbursementJournal
    ' ** DAO Pattern

    Public Class CashDisbursementJournalDao
        Implements IDao(Of CashDisbursementJournal), IDaoJournals(Of CashDisbursementJournal)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo As Integer) As CashDisbursementJournal _
            Implements IDao(Of CashDisbursementJournal).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, TransactionDate, ReferenceNo, Amount, AccountIdNo, PaymentType, PayeeIdNo, PayeeName, " &
                    " ORNumber, DiscountTaken, DiscountAccountIdNo, Applied, UnApplied, Notes, VatNumber, VatAmount, Posted, Cancelled, DateCreated" &
                    "   FROM [CashDisbursementJournal]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef cashDisbursementJournal As CashDisbursementJournal) As Integer _
            Implements IDao(Of CashDisbursementJournal).UpdateRecord
            Dim sql As String =
                    " UPDATE [CashDisbursementJournal]" &
                    " SET TransactionDate = @TransactionDate," &
                    "       ReferenceNo   = @ReferenceNo," &
                    "       Amount        = @Amount," &
                    "       AccountIdNo   = @AccountIdNo," &
                    "       PaymentType   = @PaymentType," &
                    "       PayeeIdNo     = @PayeeIdNo," &
                    "       PayeeName     = @PayeeName," &
                    "       ORNumber      = @ORNumber," &
                    "       DiscountTaken = @DiscountTaken," &
                    "       DiscountAccountIdNo = @DiscountAccountIdNo," &
                    "       Applied       = @Applied," &
                    "       UnApplied     = @UnApplied," &
                    "       Notes         = @Notes," &
                    "       VatNumber     = @VatNumber," &
                    "       VatAmount     = @VatAmount," &
                    "       Posted        = @Posted," &
                    "       Cancelled     = @Cancelled" &
                    "  WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(cashDisbursementJournal))
        End Function

        Public Function AddRecord(ByRef cashDisbursementJournal As CashDisbursementJournal) As Integer _
            Implements IDao(Of CashDisbursementJournal).AddRecord
            Dim sql As String =
                    " INSERT INTO [CashDisbursementJournal] " &
                    " (TransactionDate,ReferenceNo,Amount,AccountIdNo,PaymentType,PayeeIdNo,PayeeName,ORNumber,DiscountTaken,DiscountAccountIdNo,Applied,UnApplied,Notes,VatNumber,VatAmount,Posted,Cancelled)" &
                    " VALUES (@TransactionDate,@ReferenceNo,@Amount,@AccountIdNo,@PaymentType,@PayeeIdNo,@PayeeName,@ORNumber,@DiscountTaken,@DiscountAccountIdNo,@Applied,@UnApplied,@Notes,@VatNumber,@VatAmount,@Posted,@Cancelled)"
            Return Db.Insert(sql, Take(cashDisbursementJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CashDisbursementJournal) =
                                    Function(reader) _
            New CashDisbursementJournal() With {
            .IdNo = Extensions.AsId(reader("IdNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .PayeeIdNo = Extensions.AsInt(Of Integer)(reader("PayeeIdNo")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .OrNumber = Extensions.AsString(reader("ORNumber")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .DiscountAccountIdNo = Extensions.AsInt(Of Integer)(reader("DiscountAccountIdNo")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .UnApplied = Extensions.AsDecimal(reader("UnApplied")),
            .Notes = Extensions.AsString(reader("Notes")),
            .VatNumber = Extensions.AsString(reader("VatNumber")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .Cancelled = Extensions.AsBool(reader("Cancelled"))
            }

        Private Function Take(cashDisbursementJournal As CashDisbursementJournal) As Object()
            Return New Object() {
                                    "@IdNo", cashDisbursementJournal.IdNo,
                                    "@TransactionDate", cashDisbursementJournal.TransactionDate,
                                    "@ReferenceNo", cashDisbursementJournal.ReferenceNo,
                                    "@Amount", cashDisbursementJournal.Amount,
                                    "@AccountIdNo", cashDisbursementJournal.AccountIdNo,
                                    "@PaymentType", cashDisbursementJournal.PaymentType,
                                    "@PayeeIdNo", cashDisbursementJournal.PayeeIdNo,
                                    "@PayeeName", cashDisbursementJournal.PayeeName,
                                    "@ORNumber", cashDisbursementJournal.OrNumber,
                                    "@DiscountTaken", cashDisbursementJournal.DiscountTaken,
                                    "@DiscountAccountIdNo", cashDisbursementJournal.DiscountAccountIdNo,
                                    "@Applied", cashDisbursementJournal.Applied,
                                    "@UnApplied", cashDisbursementJournal.UnApplied,
                                    "@Notes", cashDisbursementJournal.Notes,
                                    "@VatNumber", cashDisbursementJournal.VatNumber,
                                    "@VatAmount", cashDisbursementJournal.VatAmount,
                                    "@Posted", cashDisbursementJournal.Posted,
                                    "@Cancelled", cashDisbursementJournal.Cancelled,
                                    "@DateCreated", cashDisbursementJournal.DateCreated
                                }
        End Function

        'Public Function UpdateGlReferenceNumber(ByRef model) As Integer Implements IDao(Of CashDisbursementJournal).UpdateGlReferenceNumber
        '    Dim retVal As Boolean
        '    Dim sql1 As String
        '    Dim sql2 As String
        '    Dim transactionDate = model.TransactionDate
        '    Dim series = "CDJOURNAL"
        '    sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
        '    sql2 = "Update [CashDisbursementJournal] set ReferenceNo = (select value from series where seriesName = '" & series & "') where IdNo = " & model.IdNo
        '    retVal = Db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
        '    Return retVal
        'End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As CashDisbursementJournal) As Integer Implements IDaoJournals(Of CashDisbursementJournal).UpdateGlReferenceNumber
            Dim retVal As Boolean
            Dim sql1 As String
            Dim sql2 As String
            Dim transactionDate = bizObj.TransactionDate
            Dim series = "GL" + Year(transactionDate).ToString() + Right("00" + Month(transactionDate).ToString, 2)
            Dim maxlength As Int16
            Dim prefix As String
            If Db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
                maxlength = 4
                prefix = Right("00" + Month(transactionDate).ToString, 2) & "-"
                Dim sql As String = "INSERT INTO [Series] " &
                    " (SeriesName,Value,MaxLength,Prefix,Description)" &
                    " VALUES (@SeriesName,@Value,@MaxLength,@Prefix,@Description)"
                Dim params() As Object = {"@SeriesName", series,
                                          "@Value", 0,
                                          "@MaxLength", 4,
                                          "@Prefix", prefix,
                                          "@Description", "GL Series for " & Year(transactionDate).ToString() & Right("00" + Month(transactionDate).ToString, 2)
                                         }
                If Db.Insert(sql, params) Then
                    Return -1
                End If
            Else
                prefix = Db.Scalar("select prefix from series where seriesName = '" & series & "'")
                maxlength = Db.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
            End If
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            sql2 = "Update [CashDisbursementJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = Db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

    End Class

End Namespace