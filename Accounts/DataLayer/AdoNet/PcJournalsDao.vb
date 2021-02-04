Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PcJournal
    ' ** DAO Pattern

    Public Class PcJournalsDao
        Inherits DaoAccounts
        Implements IDaoChild(Of PcJournal)

        Private ReadOnly _db As New Db()
        Protected TableOrViewName As String = ""
        Protected DboTvpUpdateName As String = ""

        Public Sub New(ByVal dataNames As Object())
            TableOrViewName = dataNames(0).ToString()
            DboTvpUpdateName = dataNames(1).ToString()
        End Sub

        Public Sub New()
        End Sub

        Public Function GetRecordsWithIdNo(journalIdNo, Optional sortKey = Nothing) As List(Of PcJournal) Implements IDaoChild(Of PcJournal).GetRecordsWithIdNo
            If sortKey Is Nothing Then
                sortKey = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "Amount," &
                    "CdJournalIdNo," &
                    "PcClosed," &
                    "IdNo," &
                    "Notes," &
                    "PayeeName," &
                    "PayeeNameAra," &
                    "PaymentType," &
                    "PayType," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    " FROM PcJournal_View" &
                    " WHERE IsNull(PcClosed,0) = 0 " &
                    " ORDER BY IdNo"
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, cdJournalIdNo As Integer) As Integer Implements IDaoChild(Of PcJournal).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateName, tvpTable, "@MParam", cdJournalIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PcJournal).InsertTvp
            Return 0
        End Function

        'Public Function DelUpdateTvp(ByRef tvpTable As DataTable, PcJournalIdNo As Int32) As Integer _
        '    Implements IDaoChild(Of PcJournal).DelUpdateTvp
        '    Return _db.DelUpdateTvp(DboTvpUpdateName, tvpTable, "@MParam", PcJournalIdNo)
        'End Function

        'Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer _
        '    Implements IDaoChild(Of PcJournal).InsertTvp
        '    Return _db.InsertTvp(DboTvpInsertName, tvpTable)
        'End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PcJournal) =
                                    Function(reader) _
            New PcJournal() With {
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .CdJournalIdNo = Extensions.AsInt(Of Int32)(reader("CdJournalIdNo")),
            .PcClosed = Extensions.AsBool(reader("PcClosed")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PayeeNameAra = Extensions.AsString(reader("PayeeNameAra")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .PayType = Extensions.AsString(reader("PayType")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

    End Class

End Namespace