Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for CashDisbursementJournal
    ' ** DAO Pattern

    Public Class CashDisbursementJournalDao
        Inherits DaoAccounts
        Implements IDao(Of CashDisbursementJournal), IDaoJournals(Of CashDisbursementJournal), IDaoChild(Of JournalItem)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo As Integer) As CashDisbursementJournal _
            Implements IDao(Of CashDisbursementJournal).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, TransactionDate, ReferenceNo, Amount, AccountIdNo, PaymentType, PayeeIdNo, PayeeName, " &
                    " ORNumber, DiscountTaken, DiscountAccountIdNo, Applied, UnApplied, Notes, VatNumber, VatAmount, Posted, Cancelled, DateCreated" &
                    "   FROM [CashDisbursementJournal]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
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
            Return _db.Update(sql, Take(cashDisbursementJournal))
        End Function

        Public Function AddRecord(ByRef cashDisbursementJournal As CashDisbursementJournal) As Integer _
            Implements IDao(Of CashDisbursementJournal).AddRecord
            Dim sql As String =
                    " INSERT INTO [CashDisbursementJournal] " &
                    " (TransactionDate,ReferenceNo,Amount,AccountIdNo,PaymentType,PayeeIdNo,PayeeName,ORNumber,DiscountTaken,DiscountAccountIdNo,Applied,UnApplied,Notes,VatNumber,VatAmount,Posted,Cancelled)" &
                    " VALUES (@TransactionDate,@ReferenceNo,@Amount,@AccountIdNo,@PaymentType,@PayeeIdNo,@PayeeName,@ORNumber,@DiscountTaken,@DiscountAccountIdNo,@Applied,@UnApplied,@Notes,@VatNumber,@VatAmount,@Posted,@Cancelled)"
            Return _db.Insert(sql, Take(cashDisbursementJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CashDisbursementJournal) =
                                    Function(reader) _
            New CashDisbursementJournal() With {
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(reader("IdNo")),
            .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
            .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .AccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .PaymentType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PaymentType")),
            .PayeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("PayeeIdNo")),
            .PayeeName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayeeName")),
            .OrNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ORNumber")),
            .DiscountTaken = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DiscountTaken")),
            .DiscountAccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int32?)(reader("DiscountAccountIdNo")),
            .Applied = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Applied")),
            .UnApplied = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnApplied")),
            .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
            .VatNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("VatNumber")),
            .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
            .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("DateCreated")),
            .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled"))
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

        Public Function UpdateGlReferenceNumber(ByRef bizObj As CashDisbursementJournal) As Integer Implements IDaoJournals(Of CashDisbursementJournal).UpdateGlReferenceNumber
            Dim retVal As Boolean
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
                If _db.Insert(sql, params) Then
                    Return -1
                End If
            Else
                prefix = _db.Scalar("select prefix from series where seriesName = '" & series & "'")
                maxlength = _db.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
            End If
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            sql2 = "Update [CashDisbursementJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithIdNo
            Dim jiDao = New CashDisbursementJournalItemDao()
            Return jiDao.GetRecordsWithIdNo(idNo, sortExpression)
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of JournalItem).DelUpdateTvp
            Dim jiDao = New CashDisbursementJournalItemDao()
            Return jiDao.DelUpdateTvp(tvpTable, groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of JournalItem).InsertTvp
            Dim jiDao = New CashDisbursementJournalItemDao()
            Return jiDao.InsertTvp(tvpTable)
        End Function

    End Class

End Namespace