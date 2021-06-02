Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for ApJournal
    ' ** DAO Pattern

    Public Class ApJournalDao
        Inherits AccountsDao
        Implements IDao(Of ApJournal), IDaoJournals(Of ApJournal) ', IDaoChild(Of JournalItem)

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As ApJournal _
        Implements IDao(Of ApJournal).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Approved," &
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
            Dim jiDao = New JournalItemDao({"ApJournalItem_View", "dbo.UpdateApJournalItemTVP", "dbo.InsertApJournalItemTVP"})
            data.JournalItems = jiDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
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
                    "Approved = @Approved," &
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
                    "Approved," &
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
                    "@Approved," &
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
            .AccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .Approved = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Approved")),
            .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .DueDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of DateTime?)(reader("DueDate")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .InvoiceDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of DateTime?)(reader("InvoiceDate")),
            .InvoiceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceNo")),
            .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
            .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
            .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
            .SettlementDiscount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("SettlementDiscount")),
            .SettlementDueDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("SettlementDueDate")),
            .SupplierIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("SupplierIdNo")),
            .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
            .TransactionType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("TransactionType")),
            .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("VatNumber"))
            }

        Private Function Take(apJournal As ApJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", apJournal.AccountIdNo,
                                    "@Amount", apJournal.Amount,
                                    "@Approved", apJournal.Approved,
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
            Dim series = "GL" + GlobalFunctions.GregorianYear(transactionDate).ToString() + Right("00" + GlobalFunctions.GregorianMonth(transactionDate).ToString, 2)
            Dim maxlength As Int16
            Dim prefix As String
            If _db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
                maxlength = 4
                prefix = Right("00" + GlobalFunctions.GregorianMonth(transactionDate).ToString, 2) & "-"
                Dim sql As String = "INSERT INTO [Series] " &
                    " (SeriesName,Value,MaxLength,Prefix,Description)" &
                    " VALUES (@SeriesName,@Value,@MaxLength,@Prefix,@Description)"
                Dim params() As Object = {"@SeriesName", series,
                                          "@Value", 0,
                                          "@MaxLength", 4,
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
            sql2 = "Update [ApJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        'Public Function GetRecordsWithGroupIdNo(idNo As Int32, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithGroupIdNo
        '    Dim jiDao = New ApJournalItemDao()
        '    Return jiDao.GetRecordsWithGroupIdNo(idNo, sortExpression)
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