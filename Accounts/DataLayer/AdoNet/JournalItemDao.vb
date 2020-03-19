Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for JournalItem
    ' ** DAO Pattern

    Public Class JournalItemDao
        Inherits DaoAccounts
        Implements IDaoChild(Of JournalItem)

        Private ReadOnly Db As New Db()
        Protected TableFileName As String = ""
        Protected DboTvpUpdateFileName As String = ""
        Protected DboTvpInsertFileName As String = ""

        Public Function GetRecordsWithIdNo(journalIdNo As Integer, Optional sortKey As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithIdNo
            If sortKey Is Nothing Then
                sortKey = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "AccountName," &
                    "Credit," &
                    "Debit," &
                    "DiscountTaken," &
                    "IDNo," &
                    "JournalIdNo," &
                    "Notes," &
                    "OpenInvoiceIdNo," &
                    "OriginalAmount," &
                    "PaidAmount," &
                    "PayeeType," &
                    "ProfitCenterIdNo," &
                    "Sequence," &
                    "SpecialAccount" &
                    " FROM " & TableFileName &
                    " WHERE JournalIdNo = @JournalIdNo" &
                    " ORDER BY " & sortKey
            Dim params() As Object = {"@JournalIdNo", journalIdNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, journalItemIdNo As Integer) As Integer _
            Implements IDaoChild(Of JournalItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", journalItemIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer _
            Implements IDaoChild(Of JournalItem).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, JournalItem) =
                                    Function(reader) _
            New JournalItem() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .AccountName = Extensions.AsString(reader("AccountName")),
            .Credit = Extensions.AsDecimal(reader("Credit")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .Debit = Extensions.AsDecimal(reader("Debit")),
            .IdNo = Extensions.AsId(reader("IDNo")),
            .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OriginalAmount = Extensions.AsDecimal(reader("OriginalAmount")),
            .OpenInvoiceIdNo = Extensions.AsDecimal(reader("OpenInvoiceIdNo")),
            .PaidAmount = Extensions.AsDecimal(reader("PaidAmount")),
            .PayeeType = Extensions.AsString(reader("PayeeType")),
            .ProfitCenterIdNo = Extensions.AsInt(Of Integer)(reader("ProfitCenterIdNo")),
            .Sequence = Extensions.AsInt(Of Integer)(reader("Sequence")),
            .SpecialAccount = Extensions.AsString(reader("SpecialAccount"))
            }

    End Class

End Namespace