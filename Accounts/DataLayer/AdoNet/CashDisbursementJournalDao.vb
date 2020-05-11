Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for CashDisbursementJournal
    ' ** DAO Pattern

    Public Class CashDisbursementJournalDao
        Inherits DaoAccounts
        Implements IDao(Of CashDisbursementJournal), IDaoJournals(Of CashDisbursementJournal), IDaoChild(Of JournalItem), IDaoOiItem(Of CadOiItem)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As CashDisbursementJournal _
            Implements IDao(Of CashDisbursementJournal).GetRecordById
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
                    " FROM [CashDisbursementJournal]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim jiDao = New CashDisbursementJournalItemDao
            Dim oiDao = New CadOiItemDao
            Dim ji = jiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            Dim oi = oiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            data.JournalItems = ji
            data.CadOiItems = oi
            Return data
        End Function

        Public Function UpdateRecord(ByRef cashDisbursementJournal As CashDisbursementJournal) As Integer _
            Implements IDao(Of CashDisbursementJournal).UpdateRecord
            Dim sql As String =
                    " UPDATE [CashDisbursementJournal] SET " &
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
            Return _db.Update(sql, Take(cashDisbursementJournal))
        End Function

        Public Function AddRecord(ByRef cashDisbursementJournal As CashDisbursementJournal) As Integer _
            Implements IDao(Of CashDisbursementJournal).AddRecord
            Dim sql As String = " INSERT INTO [CashDisbursementJournal] (" &
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
            Return _db.Insert(sql, Take(cashDisbursementJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CashDisbursementJournal) =
                                    Function(reader) _
            New CashDisbursementJournal() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .DiscountAccountIdNo = Extensions.AsNullable(Of Int32?)(reader("DiscountAccountIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
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

        Private Function Take(cashDisbursementJournal As CashDisbursementJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", cashDisbursementJournal.AccountIdNo,
                                    "@Amount", cashDisbursementJournal.Amount,
                                    "@Applied", cashDisbursementJournal.Applied,
                                    "@Cancelled", cashDisbursementJournal.Cancelled,
                                    "@DateCreated", cashDisbursementJournal.DateCreated,
                                    "@DiscountAccountIdNo", cashDisbursementJournal.DiscountAccountIdNo,
                                    "@DiscountTaken", cashDisbursementJournal.DiscountTaken,
                                    "@IdNo", cashDisbursementJournal.IdNo,
                                    "@Notes", cashDisbursementJournal.Notes,
                                    "@ORNumber", cashDisbursementJournal.OrNumber,
                                    "@PayeeIdNo", cashDisbursementJournal.PayeeIdNo,
                                    "@PayeeName", cashDisbursementJournal.PayeeName,
                                    "@PaymentType", cashDisbursementJournal.PaymentType,
                                    "@Posted", cashDisbursementJournal.Posted,
                                    "@ReferenceNo", cashDisbursementJournal.ReferenceNo,
                                    "@TransactionDate", cashDisbursementJournal.TransactionDate,
                                    "@UnApplied", cashDisbursementJournal.UnApplied,
                                    "@VatAmount", cashDisbursementJournal.VatAmount,
                                    "@VatNumber", cashDisbursementJournal.VatNumber
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As CashDisbursementJournal) As Integer Implements IDaoJournals(Of CashDisbursementJournal).UpdateGlReferenceNumber
            Dim retVal As Boolean
            Dim sql1 As String
            Dim sql2 As String
            Const series As String = "CDJOURNAL"
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            sql2 = "Update [CashDisbursementJournal] set ReferenceNo = (select value from series where seriesName = '" & series & "') where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal

            'Dim retVal As Boolean
            'Dim sql1 As String
            'Dim sql2 As String
            'Dim transactionDate = bizObj.TransactionDate
            'Dim series = "GL" + Year(transactionDate).ToString() + Right("00" + Month(transactionDate).ToString, 2)
            'Dim maxlength As Int16
            'Dim prefix As String
            'If _db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
            '    maxlength = 4
            '    prefix = Right("00" + Month(transactionDate).ToString, 2) & "-"
            '    Dim sql As String = "INSERT INTO [Series] " &
            '        " (SeriesName,Value,MaxLength,Prefix,Description)" &
            '        " VALUES (@SeriesName,@Value,@MaxLength,@Prefix,@Description)"
            '    Dim params() As Object = {"@SeriesName", series,
            '                              "@Value", 0,
            '                              "@MaxLength", 4,
            '                              "@Prefix", prefix,
            '                              "@Description", "GL Series for " & Year(transactionDate).ToString() & Right("00" + Month(transactionDate).ToString, 2)
            '                             }
            '    If _db.Insert(sql, params) Then
            '        Return -1
            '    End If
            'Else
            '    prefix = _db.Scalar("select prefix from series where seriesName = '" & series & "'")
            '    maxlength = _db.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
            'End If
            'sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            'sql2 = "Update [CashDisbursementJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
            '       ")) where IdNo = " & bizObj.IdNo
            'retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            'Return retVal
        End Function

        Public Function GetRecordsWithIdNo(idNo As Int32, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithIdNo
            Dim jiDao = New CashDisbursementJournalItemDao()
            Return jiDao.GetRecordsWithIdNo(idNo, sortExpression)
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Int32) As Integer Implements IDaoChild(Of JournalItem).DelUpdateTvp
            Dim jiDao = New CashDisbursementJournalItemDao()
            Return jiDao.DelUpdateTvp(tvpTable, groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of JournalItem).InsertTvp
            Dim jiDao = New CashDisbursementJournalItemDao()
            Return jiDao.InsertTvp(tvpTable)
        End Function

        Public Function GetOpenInvoices(idNo As Integer) As List(Of CadOiItem) Implements IDaoOiItem(Of CadOiItem).GetOpenInvoices
            Dim oiDao = New CadOiItemDao
            Return oiDao.GetOpenInvoices(idNo)
        End Function

    End Class

End Namespace