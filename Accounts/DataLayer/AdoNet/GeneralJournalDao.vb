Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for GeneralJournal
    ' ** DAO Pattern

    Public Class GeneralJournalDao
        Implements IDao(Of GeneralJournal), IDaoJournals(Of GeneralJournal), IDaoChild(Of JournalItem)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As GeneralJournal _
            Implements IDao(Of GeneralJournal).GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "Cancelled," &
                    "ClosingJournal," &
                    "DateCreated," &
                    "IdNo," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    " FROM [GeneralJournal]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            Dim jiDao = New GeneralJournalItemDao()
            data.JournalItems = GetRecordsWithIdNo(idNo, "Sequence")
            For Each item In data.JournalItems
                data.TotalDebits += item.Debit
                data.TotalCredits += item.Credit
            Next
            Return data
        End Function

        Public Function UpdateRecord(ByRef generalJournal As GeneralJournal) As Integer _
            Implements IDao(Of GeneralJournal).UpdateRecord
            Dim sql As String =
                    "UPDATE [GeneralJournal] SET " &
                    "Cancelled = @Cancelled," &
                    "ClosingJournal = @ClosingJournal," &
                    "Notes = @Notes," &
                    "Posted = @Posted," &
                    "ReferenceNo = @ReferenceNo," &
                    "TransactionDate = @TransactionDate" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(generalJournal))
        End Function

        Public Function AddRecord(ByRef generalJournal As GeneralJournal) As Integer _
            Implements IDao(Of GeneralJournal).AddRecord
            Dim sql As String =
                    " INSERT INTO [GeneralJournal] " &
                    "(" &
                    "Cancelled," &
                    "ClosingJournal," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    ") VALUES (" &
                    "@Cancelled," &
                    "@ClosingJournal," &
                    "@Notes," &
                    "@Posted," &
                    "@ReferenceNo," &
                    "@TransactionDate" &
                    ")"
            Return Db.Insert(sql, Take(generalJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, GeneralJournal) =
                                    Function(reader) _
            New GeneralJournal() With {
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .ClosingJournal = Extensions.AsBool(reader("ClosingJournal")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

        Private Function Take(generalJournal As GeneralJournal) As Object()
            Return New Object() {
                                    "@Cancelled", generalJournal.Cancelled,
                                    "@ClosingJournal", generalJournal.ClosingJournal,
                                    "@DateCreated", generalJournal.DateCreated,
                                    "@IdNo", generalJournal.IdNo,
                                    "@Notes", generalJournal.Notes,
                                    "@Posted", generalJournal.Posted,
                                    "@ReferenceNo", generalJournal.ReferenceNo,
                                    "@TransactionDate", generalJournal.TransactionDate
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As GeneralJournal) As Integer Implements IDaoJournals(Of GeneralJournal).UpdateGlReferenceNumber
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
            sql2 = "Update [GeneralJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = Db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        Public Function GetRecordsWithIdNo(idNo As Int32, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithIdNo
            Dim jiDao = New GeneralJournalItemDao()
            Return jiDao.GetRecordsWithIdNo(idNo, sortExpression)
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Int32) As Integer Implements IDaoChild(Of JournalItem).DelUpdateTvp
            Dim jiDao = New GeneralJournalItemDao()
            Return jiDao.DelUpdateTvp(tvpTable, groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of JournalItem).InsertTvp
            Dim jiDao = New GeneralJournalItemDao()
            Return jiDao.InsertTvp(tvpTable)
        End Function

    End Class

End Namespace