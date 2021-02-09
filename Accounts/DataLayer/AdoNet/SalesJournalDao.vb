Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for SalesJournal
    ' ** DAO Pattern

    Public Class SalesJournalDao
        Implements IDao(Of SalesJournal), IDaoJournals(Of SalesJournal) ', IDaoChild(Of JournalItem)

        ' ReSharper disable once InconsistentNaming
        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As SalesJournal _
            Implements IDao(Of SalesJournal).GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "Cancelled," &
                    "DateCreated," &
                    "IdNo," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    " FROM [SalesJournal]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim jiDao = New JournalItemDao({"SalesJournalItem_View", "dbo.UpdateSalesJournalItemTVP", "dbo.InsertSalesJournalItemTVP"})
            Dim sdDao = New SalesDepositDao
            Dim ji = jiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            Dim sd = sdDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            data.JournalItems = ji
            data.SalesDeposits = sd
            'For Each item In data.SalesDeposits
            '    item.ComputedBankCharge = item.SaleAmount *
            'Next
            Return data
        End Function

        Public Function UpdateRecord(ByRef salesJournal As SalesJournal) As Integer _
            Implements IDao(Of SalesJournal).UpdateRecord
            Dim sql As String =
                    "UPDATE [SalesJournal] SET " &
                    "AccountIdNo = @AccountIdNo," &
                    "Cancelled = @Cancelled," &
                    "Notes = @Notes," &
                    "Posted = @Posted," &
                    "ReferenceNo = @ReferenceNo," &
                    "TransactionDate = @TransactionDate" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(salesJournal))
        End Function

        Public Function AddRecord(ByRef salesJournal As SalesJournal) As Integer _
            Implements IDao(Of SalesJournal).AddRecord
            Dim sql As String =
                    " INSERT INTO [SalesJournal] " &
                    "(" &
                    "AccountIdNo," &
                    "Cancelled," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@Cancelled," &
                    "@Notes," &
                    "@Posted," &
                    "@ReferenceNo," &
                    "@TransactionDate" &
                    ")"
            Return _db.Insert(sql, Take(salesJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, SalesJournal) =
                                    Function(reader) _
            New SalesJournal() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

        Private Function Take(salesJournal As SalesJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", salesJournal.AccountIdNo,
                                    "@Cancelled", salesJournal.Cancelled,
                                    "@IdNo", salesJournal.IdNo,
                                    "@Notes", salesJournal.Notes,
                                    "@Posted", salesJournal.Posted,
                                    "@ReferenceNo", salesJournal.ReferenceNo,
                                    "@TransactionDate", salesJournal.TransactionDate
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As SalesJournal) As Integer Implements IDaoJournals(Of SalesJournal).UpdateGlReferenceNumber
            Dim sql As String
            Dim transactionDate = bizObj.TransactionDate
            Dim referenceNo As String
            referenceNo = "S" + Right("00" + Month(transactionDate).ToString, 2) & "-" & Right("00" + DateAndTime.Day(transactionDate).ToString, 2)
            sql = "Update [SalesJournal] set ReferenceNo = '" & referenceNo & "' where IdNo = " & bizObj.IdNo
            Dim retVal As Boolean = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql, "")
            Return retVal
        End Function

        'Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithIdNo
        '    Dim jiDao = New SalesJournalItemDao()
        '    Return jiDao.GetRecordsWithIdNo(idNo, sortExpression)
        'End Function

        'Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of JournalItem).DelUpdateTvp
        '    Dim jiDao = New SalesJournalItemDao()
        '    Return jiDao.DelUpdateTvp(tvpTable, groupIdNo)
        'End Function

        'Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of JournalItem).InsertTvp
        '    Dim jiDao = New SalesJournalItemDao()
        '    Return jiDao.InsertTvp(tvpTable)
        'End Function

    End Class

End Namespace