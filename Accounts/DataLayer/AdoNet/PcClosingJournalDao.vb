Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PcClosingJournal
    ' ** DAO Pattern

    Public Class PcClosingJournalDao
        Inherits AccountsDao
        Implements IDaoChild(Of PcClosingJournal)

        Private ReadOnly _db As New Db()
        Protected TableOrViewName As String = ""
        Protected DboTvpUpdateName As String = ""

        Public Sub New(ByVal dataNames As Object())
            TableOrViewName = dataNames(0).ToString()
            DboTvpUpdateName = dataNames(1).ToString()
        End Sub

        Public Sub New()
        End Sub

        Public Function GetRecordsWithGroupIdNo(journalIdNo, Optional sortKey = Nothing) As List(Of PcClosingJournal) Implements IDaoChild(Of PcClosingJournal).GetRecordsWithGroupIdNo
            If sortKey Is Nothing Then
                sortKey = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "Amount," &
                    "CdJournalIdNo," &
                    "IdNo," &
                    "Notes," &
                    "PayeeName," &
                    "PayeeNameAra," &
                    "PaymentType," &
                    "PayType," &
                    "PcClosed," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    " FROM PcJournal_View" &
                    " WHERE IsNull(PcClosed,0) = 0 " &
                    " ORDER BY IdNo"
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, cdJournalIdNo As Integer) As Integer Implements IDaoChild(Of PcClosingJournal).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateName, tvpTable, "@MParam", cdJournalIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PcClosingJournal).InsertTvp
            Return 0
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PcClosingJournal) =
                                    Function(reader) _
            New PcClosingJournal() With {
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .CdJournalIdNo = Extensions.AsInt(Of Int32)(reader("CdJournalIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PayeeNameAra = Extensions.AsString(reader("PayeeNameAra")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .PayType = Extensions.AsString(reader("PayType")),
            .PcClosed = Extensions.AsBool(reader("PcClosed")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

    End Class

End Namespace