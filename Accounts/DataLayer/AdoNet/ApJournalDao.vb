Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ApJournal
    ' ** DAO Pattern

    Public Class ApJournalDao
        Implements IDao(Of ApJournal), IDaoJournals(Of ApJournal) ', IDaoChild(Of JournalItem)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As ApJournal _
        Implements IDao(Of ApJournal).GetRecordById
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Cancelled," &
                    "DateCreated," &
                    "DueDate," &
                    "IdNo," &
                    "InvoiceDate," &
                    "InvoiceNo," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "SettlementDiscount," &
                    "SettlementDueDate," &
                    "SupplierIdNo," &
                    "TransactionDate," &
                    "TransactionType," &
                    "VatAmount," &
                    "VatNumber" &
                    " FROM [ApJournal]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim jiDao = New ApJournalItemDao
            data.JournalItems = jiDao.GetRecordsWithIdNo(idNo, "Sequence")
            For Each item In data.JournalItems
                data.TotalDebits += item.Debit
                data.TotalCredits += item.Credit
            Next
            Return data
        End Function

        Public Function UpdateRecord(ByRef apJournal As ApJournal) As Integer _
            Implements IDao(Of ApJournal).UpdateRecord
            Dim sql As String =
                    " UPDATE [ApJournal] Set " &
                    "AccountIdNo = @AccountIdNo," &
                    "Amount = @Amount," &
                    "Cancelled = @Cancelled," &
                    "DueDate = @DueDate," &
                    "InvoiceDate = @InvoiceDate," &
                    "InvoiceNo = @InvoiceNo," &
                    "Notes = @Notes," &
                    "Posted = @Posted," &
                    "ReferenceNo = @ReferenceNo," &
                    "SettlementDiscount = @SettlementDiscount," &
                    "SettlementDueDate = @SettlementDueDate," &
                    "SupplierIdNo = @SupplierIdNo," &
                    "TransactionDate = @TransactionDate," &
                    "TransactionType = @TransactionType," &
                    "VatAmount = @VatAmount," &
                    "VatNumber = @VatNumber" &
                    "  WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(apJournal))
        End Function

        Public Function AddRecord(ByRef apJournal As ApJournal) As Integer _
            Implements IDao(Of ApJournal).AddRecord
            Dim sql As String = "INSERT INTO [ApJournal] (" &
                    "AccountIdNo," &
                    "Amount," &
                    "Cancelled," &
                    "DueDate," &
                    "InvoiceDate," &
                    "InvoiceNo," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "SettlementDiscount," &
                    "SettlementDueDate," &
                    "SupplierIdNo," &
                    "TransactionDate," &
                    "TransactionType," &
                    "VatAmount," &
                    "VatNumber" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@Amount," &
                    "@Cancelled," &
                    "@DueDate," &
                    "@InvoiceDate," &
                    "@InvoiceNo," &
                    "@Notes," &
                    "@Posted," &
                    "@ReferenceNo," &
                    "@SettlementDiscount," &
                    "@SettlementDueDate," &
                    "@SupplierIdNo," &
                    "@TransactionDate," &
                    "@TransactionType," &
                    "@VatAmount," &
                    "@VatNumber" &
                    ")"
            Return _db.Insert(sql, Take(apJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ApJournal) =
                                    Function(reader) _
            New ApJournal() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .DueDate = Extensions.AsNullable(Of DateTime?)(reader("DueDate")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .InvoiceDate = Extensions.AsNullable(Of DateTime?)(reader("InvoiceDate")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .SettlementDiscount = Extensions.AsDecimal(reader("SettlementDiscount")),
            .SettlementDueDate = Extensions.AsDate(reader("SettlementDueDate")),
            .SupplierIdNo = Extensions.AsInt(Of Integer)(reader("SupplierIdNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .TransactionType = Extensions.AsString(reader("TransactionType")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = Extensions.AsString(reader("VatNumber"))
            }

        Private Function Take(apJournal As ApJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", apJournal.AccountIdNo,
                                    "@Amount", apJournal.Amount,
                                    "@Cancelled", apJournal.Cancelled,
                                    "@DueDate", apJournal.DueDate,
                                    "@IdNo", apJournal.IdNo,
                                    "@InvoiceDate", apJournal.InvoiceDate,
                                    "@InvoiceNo", apJournal.InvoiceNo,
                                    "@Notes", apJournal.Notes,
                                    "@Posted", apJournal.Posted,
                                    "@ReferenceNo", apJournal.ReferenceNo,
                                    "@SettlementDiscount", apJournal.SettlementDiscount,
                                    "@SettlementDueDate", apJournal.SettlementDueDate,
                                    "@SupplierIdNo", apJournal.SupplierIdNo,
                                    "@TransactionDate", apJournal.TransactionDate,
                                    "@TransactionType", apJournal.TransactionType,
                                    "@VatAmount", apJournal.VatAmount,
                                    "@VatNumber", apJournal.VatNumber
                                 }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As ApJournal) As Integer Implements IDaoJournals(Of ApJournal).UpdateGlReferenceNumber
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
            sql2 = "Update [ApJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        'Public Function GetRecordsWithIdNo(idNo As Int32, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithIdNo
        '    Dim jiDao = New ApJournalItemDao()
        '    Return jiDao.GetRecordsWithIdNo(idNo, sortExpression)
        'End Function

        'Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Int32) As Integer Implements IDaoChild(Of JournalItem).DelUpdateTvp
        '    Dim jiDao = New ApJournalItemDao()
        '    Return jiDao.DelUpdateTvp(tvpTable, groupIdNo)
        'End Function

        'Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of JournalItem).InsertTvp
        '    Dim jiDao = New ApJournalItemDao()
        '    Return jiDao.InsertTvp(tvpTable)
        'End Function

    End Class

End Namespace