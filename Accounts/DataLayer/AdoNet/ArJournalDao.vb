Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for ArJournal
    ' ** DAO Pattern

    Public Class ArJournalDao
        Inherits AccountsDao
        Implements IDao(Of ArJournal), IDaoJournals(Of ArJournal) ', IDaoChild(Of JournalItem)

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As ArJournal _
        Implements IDao(Of ArJournal).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Approved," &
                    "Cancelled," &
                    "CustomerIdNo," &
                    "DateCreated," &
                    "DueDate," &
                    "IdNo," &
                    "InvoiceNo," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "SettlementDiscount," &
                    "SettlementDueDate," &
                    "TransactionDate," &
                    "TransactionType," &
                    "VatAmount" &
                    " FROM [ArJournal]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim jiDao = New JournalItemDao({"ArJournalItem_View", "dbo.UpdateArJournalItemTVP", "dbo.InsertArJournalItemTVP"})
                data.JournalItems = jiDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
                For Each item In data.JournalItems
                    data.TotalDebits += item.Debit
                    data.TotalCredits += item.Credit
                Next
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef arJournal As ArJournal) As Integer _
            Implements IDao(Of ArJournal).UpdateRecord
            Dim sql As String =
                    "UPDATE [ArJournal] SET " &
                    "AccountIdNo = @AccountIdNo," &
                    "Amount = @Amount," &
                    "Approved = @Approved," &
                    "Cancelled = @Cancelled," &
                    "CustomerIdNo = @CustomerIdNo," &
                    "DueDate = @DueDate," &
                    "InvoiceNo = @InvoiceNo," &
                    "Notes = @Notes," &
                    "Posted = @Posted," &
                    "ReferenceNo = @ReferenceNo," &
                    "SettlementDiscount = @SettlementDiscount," &
                    "SettlementDueDate = @SettlementDueDate," &
                    "TransactionDate = @TransactionDate," &
                    "TransactionType = @TransactionType," &
                    "VatAmount = @VatAmount" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(arJournal))
        End Function

        Public Function AddRecord(ByRef arJournal As ArJournal) As Integer _
            Implements IDao(Of ArJournal).AddRecord
            Dim sql As String = "INSERT INTO [ArJournal] (" &
                    "AccountIdNo," &
                    "Amount," &
                    "Approved," &
                    "Cancelled," &
                    "CustomerIdNo," &
                    "DueDate," &
                    "InvoiceNo," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "SettlementDiscount," &
                    "SettlementDueDate," &
                    "TransactionDate," &
                    "TransactionType," &
                    "VatAmount" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@Amount," &
                    "@Approved," &
                    "@Cancelled," &
                    "@CustomerIdNo," &
                    "@DueDate," &
                    "@InvoiceNo," &
                    "@Notes," &
                    "@Posted," &
                    "@ReferenceNo," &
                    "@SettlementDiscount," &
                    "@SettlementDueDate," &
                    "@TransactionDate," &
                    "@TransactionType," &
                    "@VatAmount" &
                    ")"
            Return _db.Insert(sql, Take(arJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ArJournal) =
                                    Function(reader) _
            New ArJournal() With {
            .AccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .Approved = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Approved")),
            .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
            .CustomerIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("CustomerIdNo")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .DueDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of DateTime?)(reader("DueDate")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .InvoiceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceNo")),
            .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
            .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
            .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
            .SettlementDiscount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("SettlementDiscount")),
            .SettlementDueDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("SettlementDueDate")),
            .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
            .TransactionType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("TransactionType")),
            .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount"))
            }

        Private Function Take(arJournal As ArJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", arJournal.AccountIdNo,
                                    "@Amount", arJournal.Amount,
                                    "@Approved", arJournal.Approved,
                                    "@Cancelled", arJournal.Cancelled,
                                    "@CustomerIdNo", arJournal.CustomerIdNo,
                                    "@DueDate", arJournal.DueDate,
                                    "@IdNo", arJournal.IdNo,
                                    "@InvoiceNo", arJournal.InvoiceNo,
                                    "@Notes", arJournal.Notes,
                                    "@Posted", arJournal.Posted,
                                    "@ReferenceNo", arJournal.ReferenceNo,
                                    "@SettlementDiscount", arJournal.SettlementDiscount,
                                    "@SettlementDueDate", arJournal.SettlementDueDate,
                                    "@TransactionDate", arJournal.TransactionDate,
                                    "@TransactionType", arJournal.TransactionType,
                                    "@VatAmount", arJournal.VatAmount
                                 }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As ArJournal) As Integer Implements IDaoJournals(Of ArJournal).UpdateGlReferenceNumber
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
                                          "@Description", "GL Series for " & GlobalFunctions.GregorianYear(transactionDate).ToString() & Right("00" + GlobalFunctions.GregorianMonth(transactionDate).ToString, 2)
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
            sql2 = "Update [ArJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        'Public Function GetRecordsWithGroupIdNo(idNo As Int32, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithGroupIdNo
        '    Dim jiDao = New ArJournalItemDao()
        '    Return jiDao.GetRecordsWithGroupIdNo(idNo, sortExpression)
        'End Function

        'Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Int32) As Integer Implements IDaoChild(Of JournalItem).DelUpdateTvp
        '    Dim jiDao = New ArJournalItemDao()
        '    Return jiDao.DelUpdateTvp(tvpTable, groupIdNo)
        'End Function

        'Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of JournalItem).InsertTvp
        '    Dim jiDao = New ArJournalItemDao()
        '    Return jiDao.InsertTvp(tvpTable)
        'End Function

    End Class

End Namespace