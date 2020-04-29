Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CashReceiptJournal
    ' ** DAO Pattern

    Public Class CashReceiptJournalDao
        Implements IDao(Of CashReceiptJournal), IDaoJournals(Of CashReceiptJournal)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As CashReceiptJournal _
            Implements IDao(Of CashReceiptJournal).GetRecordById
            Dim sql As String = " SELECT " &
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
                    "PayorIdNo," &
                    "PayorName," &
                    "PayorType," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate," &
                    "UnApplied" &
                    " FROM [CashReceiptJournal]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef cashReceiptJournal As CashReceiptJournal) As Integer _
            Implements IDao(Of CashReceiptJournal).UpdateRecord
            Dim sql As String =
                    " UPDATE [CashReceiptJournal] SET " &
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
                    "PayorIdNo     = @PayorIdNo," &
                    "PayorName     = @PayorName," &
                    "PayorType   = @PayorType," &
                    "Posted        = @Posted," &
                    "ReferenceNo   = @ReferenceNo," &
                    "TransactionDate = @TransactionDate," &
                    "UnApplied     = @UnApplied" &
                    " WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(cashReceiptJournal))
        End Function

        Public Function AddRecord(ByRef cashReceiptJournal As CashReceiptJournal) As Integer _
            Implements IDao(Of CashReceiptJournal).AddRecord
            Dim sql As String = "INSERT INTO [CashReceiptJournal] (" &
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
                    "PayorIdNo," &
                    "PayorName," &
                    "PayorType," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate," &
                    "UnApplied" &
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
                    "@PayorIdNo," &
                    "@PayorName," &
                    "@PayorType," &
                    "@Posted," &
                    "@ReferenceNo," &
                    "@TransactionDate," &
                    "@UnApplied" &
                    ")"
            Return Db.Insert(sql, Take(cashReceiptJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CashReceiptJournal) =
                                    Function(reader) _
            New CashReceiptJournal() With {
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
            .PayorIdNo = Extensions.AsInt(Of Integer)(reader("PayorIdNo")),
            .PayorName = Extensions.AsString(reader("PayorName")),
            .PayorType = Extensions.AsString(reader("PayorType")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .UnApplied = Extensions.AsDecimal(reader("UnApplied"))
            }

        Private Function Take(cashReceiptJournal As CashReceiptJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", cashReceiptJournal.AccountIdNo,
                                    "@Amount", cashReceiptJournal.Amount,
                                    "@Applied", cashReceiptJournal.Applied,
                                    "@Cancelled", cashReceiptJournal.Cancelled,
                                    "@CheckDate", cashReceiptJournal.CheckDate,
                                    "@CheckNumber", cashReceiptJournal.CheckNumber,
                                    "@DateCreated", cashReceiptJournal.DateCreated,
                                    "@DiscountAccountIdNo", cashReceiptJournal.DiscountAccountIdNo,
                                    "@DiscountTaken", cashReceiptJournal.DiscountTaken,
                                    "@IdNo", cashReceiptJournal.IdNo,
                                    "@Notes", cashReceiptJournal.Notes,
                                    "@ORNumber", cashReceiptJournal.OrNumber,
                                    "@PayorIdNo", cashReceiptJournal.PayorIdNo,
                                    "@PayorName", cashReceiptJournal.PayorName,
                                    "@PayorType", cashReceiptJournal.PayorType,
                                    "@Posted", cashReceiptJournal.Posted,
                                    "@ReferenceNo", cashReceiptJournal.ReferenceNo,
                                    "@TransactionDate", cashReceiptJournal.TransactionDate,
                                    "@UnApplied", cashReceiptJournal.UnApplied
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As CashReceiptJournal) As Integer Implements IDaoJournals(Of CashReceiptJournal).UpdateGlReferenceNumber
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
            sql2 = "Update [CashReceiptJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = Db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

    End Class

End Namespace