Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CashReceiptJournal
    ' ** DAO Pattern

    Public Class CashReceiptJournalDao
        Inherits AccountsDao
        Implements IDao(Of CashReceiptJournal), IDaoJournals(Of CashReceiptJournal), IDaoOiItem(Of CsrOiItem)

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As CashReceiptJournal _
            Implements IDao(Of CashReceiptJournal).GetRecordByIdNo
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
                    "UnApplied," &
                    "VatAmount," &
                    "VatNumber" &
                    " FROM [CashReceiptJournal]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim jiDao = New JournalItemDao({"CashReceiptJournalItem_View", "dbo.UpdateCashReceiptJournalItemTVP", "dbo.InsertCashReceiptJournalItemTVP"})
            Dim oiDao = New CsrOiItemDao
            Dim ji = jiDao.GetRecordsWithGroupIdNo(data.IdNo, "sequence")
            Dim oi = oiDao.GetRecordsWithGroupIdNo(data.IdNo, "sequence")
            data.JournalItems = ji
            data.CsrOiItems = oi
            Return data
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
                    "UnApplied     = @UnApplied," &
                    "VatAmount     = @VatAmount," &
                    "VatNumber     = @VatNumber" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(cashReceiptJournal))
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
                    "@PayorIdNo," &
                    "@PayorName," &
                    "@PayorType," &
                    "@Posted," &
                    "@ReferenceNo," &
                    "@TransactionDate," &
                    "@UnApplied," &
                    "@VatAmount," &
                    "@VatNumber" &
                    ")"
            Return _db.Insert(sql, Take(cashReceiptJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CashReceiptJournal) =
                                    Function(reader) _
            New CashReceiptJournal() With {
            .AccountIdNo = Extensions.AsNullable(Of Int16?)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .CheckDate = Extensions.AsDate(reader("CheckDate")),
            .CheckNumber = Extensions.AsString(reader("CheckNumber")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .DiscountAccountIdNo = Extensions.AsNullable(Of Int16?)(reader("DiscountAccountIdNo")),
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
            .UnApplied = Extensions.AsDecimal(reader("UnApplied")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = Extensions.AsString(reader("VatNumber"))
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
                                    "@UnApplied", cashReceiptJournal.UnApplied,
                                    "@VatAmount", cashReceiptJournal.VatAmount,
                                    "@VatNumber", cashReceiptJournal.VatNumber
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As CashReceiptJournal) As Integer Implements IDaoJournals(Of CashReceiptJournal).UpdateGlReferenceNumber
            Dim retVal As Integer
            Dim sql1 As String
            Dim sql2 As String
            Dim transactionDate = bizObj.TransactionDate
            Dim series = "GL" + Year(transactionDate).ToString() + Right("00" + Month(transactionDate).ToString, 2)
            Dim maxlength As Int16
            Dim prefix As String
            If _db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
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
                retVal = _db.Insert(sql, params)
                If retVal < 0 Then
                    Return retVal
                End If
            Else
                prefix = _db.Scalar("select prefix from series where seriesName = '" & series & "'")
                maxlength = _db.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
            End If
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            sql2 = "Update [CashReceiptJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        Public Function GetOpenInvoices(idNo As Integer) As List(Of CsrOiItem) Implements IDaoOiItem(Of CsrOiItem).GetOpenInvoices
            Dim oiDao = New CsrOiItemDao
            Return oiDao.GetOpenInvoices(idNo)
        End Function

    End Class

End Namespace