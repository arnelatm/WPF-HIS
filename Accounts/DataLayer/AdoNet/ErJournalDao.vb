Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ErJournal
    ' ** DAO Pattern

    Public Class ErJournalDao
        Implements IDao(Of ErJournal), IDaoJournals(Of ErJournal) ', IDaoChild(Of JournalItem)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As ErJournal _
        Implements IDao(Of ErJournal).GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
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
            Dim jiDao = New ErJournalItemDao
            data.JournalItems = jiDao.GetRecordsWithIdNo(idNo, "Sequence")
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
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .EmployeeIdNo = Extensions.AsInt(Of Integer)(reader("EmployeeIdNo")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .TransactionType = Extensions.AsString(reader("TransactionType"))
            }

        Private Function Take(ErJournal As ErJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", ErJournal.AccountIdNo,
                                    "@Amount", ErJournal.Amount,
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
            sql2 = "Update [ErJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        'Public Function GetRecordsWithIdNo(idNo As Int32, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithIdNo
        '    Dim jiDao = New ErJournalItemDao()
        '    Return jiDao.GetRecordsWithIdNo(idNo, sortExpression)
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