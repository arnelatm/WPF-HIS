Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for GeneralJournal
    ' ** DAO Pattern

    Public Class GeneralJournalDao
        Implements IDao(Of GeneralJournal), IDaoJournals(Of GeneralJournal) ', IDaoChild(Of JournalItem)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As GeneralJournal _
            Implements IDao(Of GeneralJournal).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " &
                    "Approved," &
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
            Dim jiDao = New JournalItemDao({"GeneralJournalItem_View", "dbo.UpdateGeneralJournalItemTVP", "dbo.InsertGeneralJournalItemTVP"})
            data.JournalItems = jiDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
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
                    "Approved = @Approved," &
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
                    "Approved," &
                    "Cancelled," &
                    "ClosingJournal," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    ") VALUES (" &
                    "Approved," &
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
            .Approved = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Approved")),
            .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
            .ClosingJournal = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("ClosingJournal")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
            .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
            .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate"))
            }

        Private Function Take(generalJournal As GeneralJournal) As Object()
            Return New Object() {
                                    "@Approved", generalJournal.Approved,
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
            Dim retVal As Integer
            Dim sql1 As String
            Dim sql2 As String
            Dim transactionDate = bizObj.TransactionDate
            Dim series = "GL" + GlobalFunctions.GregorianYear(transactionDate).ToString() + Right("00" + GlobalFunctions.GregorianMonth(transactionDate).ToString, 2)
            Dim maxlength As Int16
            Dim prefix As String
            If Db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
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
                retVal = Db.Insert(sql, params)
                If retVal < 0 Then
                    Return retVal
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

        'Public Function GetRecordsWithGroupIdNo(idNo As Int32, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithGroupIdNo
        '    Dim jiDao = New GeneralJournalItemDao()
        '    Return jiDao.GetRecordsWithGroupIdNo(idNo, sortExpression)
        'End Function

        'Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Int32) As Integer Implements IDaoChild(Of JournalItem).DelUpdateTvp
        '    Dim jiDao = New GeneralJournalItemDao()
        '    Return jiDao.DelUpdateTvp(tvpTable, groupIdNo)
        'End Function

        'Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of JournalItem).InsertTvp
        '    Dim jiDao = New GeneralJournalItemDao()
        '    Return jiDao.InsertTvp(tvpTable)
        'End Function

    End Class

End Namespace