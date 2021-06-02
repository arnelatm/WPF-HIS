Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for ErJournal
    ' ** DAO Pattern

    Public Class ErJournalDao
        Implements IDao(Of ErJournal), IDaoJournals(Of ErJournal) ', IDaoChild(Of JournalItem)

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As ErJournal _
        Implements IDao(Of ErJournal).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "Approved," &
                    "Amount," &
                    "Cancelled," &
                    "EmployeeIdNo," &
                    "DateCreated," &
                    "IdNo," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate," &
                    "TransactionType" &
                    " FROM [ErJournal]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim jiDao = New JournalItemDao({"ErJournalItem_View", "dbo.UpdateErJournalItemTVP", "dbo.InsertErJournalItemTVP"})
            data.JournalItems = jiDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
            For Each item In data.JournalItems
                data.TotalDebits += item.Debit
                data.TotalCredits += item.Credit
            Next
            Return data
        End Function

        Public Function UpdateRecord(ByRef ErJournal As ErJournal) As Integer _
            Implements IDao(Of ErJournal).UpdateRecord
            Dim sql As String =
                    "UPDATE [ErJournal] SET " &
                    "AccountIdNo = @AccountIdNo," &
                    "Amount = @Amount," &
                    "Approved = @Approved," &
                    "Cancelled = @Cancelled," &
                    "EmployeeIdNo = @EmployeeIdNo," &
                    "Notes = @Notes," &
                    "Posted = @Posted," &
                    "ReferenceNo = @ReferenceNo," &
                    "TransactionDate = @TransactionDate," &
                    "TransactionType = @TransactionType" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(ErJournal))
        End Function

        Public Function AddRecord(ByRef ErJournal As ErJournal) As Integer _
            Implements IDao(Of ErJournal).AddRecord
            Dim sql As String = "INSERT INTO [ErJournal] (" &
                    "AccountIdNo," &
                    "Amount," &
                    "Approved," &
                    "Cancelled," &
                    "EmployeeIdNo," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate," &
                    "TransactionType" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@Amount," &
                    "@Approved," &
                    "@Cancelled," &
                    "@EmployeeIdNo," &
                    "@Notes," &
                    "@Posted," &
                    "@ReferenceNo," &
                    "@TransactionDate," &
                    "@TransactionType" &
                    ")"
            Return _db.Insert(sql, Take(ErJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ErJournal) =
                                    Function(reader) _
            New ErJournal() With {
            .AccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .Approved = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Approved")),
            .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("EmployeeIdNo")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
            .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
            .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
            .TransactionType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("TransactionType"))
            }

        Private Function Take(ErJournal As ErJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", ErJournal.AccountIdNo,
                                    "@Amount", ErJournal.Amount,
                                    "@Approved", ErJournal.Approved,
                                    "@Cancelled", ErJournal.Cancelled,
                                    "@EmployeeIdNo", ErJournal.EmployeeIdNo,
                                    "@IdNo", ErJournal.IdNo,
                                    "@Notes", ErJournal.Notes,
                                    "@Posted", ErJournal.Posted,
                                    "@ReferenceNo", ErJournal.ReferenceNo,
                                    "@TransactionDate", ErJournal.TransactionDate,
                                    "@TransactionType", ErJournal.TransactionType
                                 }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As ErJournal) As Integer Implements IDaoJournals(Of ErJournal).UpdateGlReferenceNumber
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
            sql2 = "Update [ErJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        'Public Function GetRecordsWithGroupIdNo(idNo As Int32, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithGroupIdNo
        '    Dim jiDao = New ErJournalItemDao()
        '    Return jiDao.GetRecordsWithGroupIdNo(idNo, sortExpression)
        'End Function

        'Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Int32) As Integer Implements IDaoChild(Of JournalItem).DelUpdateTvp
        '    Dim jiDao = New ErJournalItemDao()
        '    Return jiDao.DelUpdateTvp(tvpTable, groupIdNo)
        'End Function

        'Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of JournalItem).InsertTvp
        '    Dim jiDao = New ErJournalItemDao()
        '    Return jiDao.InsertTvp(tvpTable)
        'End Function

    End Class

End Namespace