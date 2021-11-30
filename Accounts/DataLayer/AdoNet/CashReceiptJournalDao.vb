Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

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
                    "Approved," &
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
            If data IsNot Nothing Then
                Dim jiDao = New JournalItemDao({"CashReceiptJournalItem_View", "dbo.UpdateCashReceiptJournalItemTVP", "dbo.InsertCashReceiptJournalItemTVP"})
                Dim oiDao = New CsrOiItemDao
                Dim ji = jiDao.GetRecordsWithGroupIdNo(data.IdNo, "sequence")
                Dim oi = oiDao.GetRecordsWithGroupIdNo(data.IdNo, "sequence")
                data.JournalItems = ji
                data.CsrOiItems = oi
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef cashReceiptJournal As CashReceiptJournal) As Integer _
            Implements IDao(Of CashReceiptJournal).UpdateRecord
            Dim sql As String =
                    " UPDATE [CashReceiptJournal] SET " &
                    "AccountIdNo   = @AccountIdNo," &
                    "Amount        = @Amount," &
                    "Applied       = @Applied," &
                    "Approved      = @Approved," &
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
                    "Approved," &
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
                    "@Approved," &
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
            .AccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int16?)(reader("AccountIdNo")),
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .Applied = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Applied")),
            .Approved = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Approved")),
            .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
            .CheckDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("CheckDate")),
            .CheckNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("CheckNumber")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .DiscountAccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int16?)(reader("DiscountAccountIdNo")),
            .DiscountTaken = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
            .OrNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ORNumber")),
            .PayorIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("PayorIdNo")),
            .PayorName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayorName")),
            .PayorType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayorType")),
            .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
            .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
            .UnApplied = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnApplied")),
            .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("VatNumber"))
            }

        Private Function Take(cashReceiptJournal As CashReceiptJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", cashReceiptJournal.AccountIdNo,
                                    "@Amount", cashReceiptJournal.Amount,
                                    "@Applied", cashReceiptJournal.Applied,
                                    "@Approved", cashReceiptJournal.Approved,
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
            Dim series = "GL" + GlobalFunctions.GregorianYear(transactionDate).ToString() + Right("00" + GlobalFunctions.GregorianMonth(transactionDate).ToString, 2)
            Dim maxlength As Int16
            Dim prefix As String
            If _db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
                maxlength = 3
                prefix = Right("00" + GlobalFunctions.GregorianMonth(transactionDate).ToString, 2) & "-"
                Dim sql As String = "INSERT INTO [Series] " &
                    " (SeriesName,Value,MaxLength,Prefix,Description)" &
                    " VALUES (@SeriesName,@Value,@MaxLength,@Prefix,@Description)"
                Dim params() As Object = {"@SeriesName", series,
                                          "@Value", 0,
                                          "@MaxLength", 3,
                                          "@Prefix", prefix,
                                          "@Description", "GL Series for " & GlobalFunctions.GregorianMonth(transactionDate).ToString() & Right("00" + GlobalFunctions.GregorianMonth(transactionDate).ToString, 2)
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