Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for SalesJournal
    ' ** DAO Pattern

    Public Class SalesJournalDao
        Implements IDao(Of SalesJournal), IDaoJournals(Of SalesJournal) ', IDaoChild(Of JournalItem)

        ' ReSharper disable once InconsistentNaming
        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As SalesJournal _
            Implements IDao(Of SalesJournal).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "Approved," &
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
            If data IsNot Nothing Then
                Dim jiDao = New JournalItemDao({"SalesJournalItem_View", "dbo.UpdateSalesJournalItemTVP", "dbo.InsertSalesJournalItemTVP"})
                Dim sdDao = New SalesDepositDao
                Dim ji = jiDao.GetRecordsWithGroupIdNo(data.IdNo, "sequence")
                Dim sd = sdDao.GetRecordsWithGroupIdNo(data.IdNo, "sequence")
                data.JournalItems = ji
                data.SalesDeposits = sd
                'For Each item In data.SalesDeposits
                '    item.ComputedBankCharge = item.SaleAmount *
                'Next
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef salesJournal As SalesJournal) As Integer _
            Implements IDao(Of SalesJournal).UpdateRecord
            Dim sql As String =
                    "UPDATE [SalesJournal] SET " &
                    "AccountIdNo = @AccountIdNo," &
                    "Approved = @Approved," &
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
                    "Approved," &
                    "Cancelled," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@Approved," &
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
            .Approved = Extensions.AsBool(reader("Approved")),
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
                                    "@Approved", salesJournal.Approved,
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
            Dim retVal As Integer
            Dim transactionDate As Date = bizObj.TransactionDate
            Dim referenceNo As String = ""
            Dim series As String = "Sales" + String.Format("{0:D}", bizObj.AccountIdNo)
            Dim prefix As String
            If _db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
                MessageBox.Show("No series format found for Account Id Number " + bizObj.AccountIdNo.ToString("D"))
                retVal = -1
            Else
                prefix = _db.Scalar("select prefix from series where seriesName = '" & series & "'")
                referenceNo = transactionDate.ToString(prefix, CultureInfo.InvariantCulture)
                sql = "Update [SalesJournal] set ReferenceNo = '" & referenceNo & "' where IdNo = " & bizObj.IdNo
                retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql, "")
            End If
            Return retVal
        End Function

        'Public Function GetRecordsWithGroupIdNo(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithGroupIdNo
        '    Dim jiDao = New SalesJournalItemDao()
        '    Return jiDao.GetRecordsWithGroupIdNo(idNo, sortExpression)
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