Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for JournalItem
    ' ** DAO Pattern

    Public Class TestDao

        Public Sub New()
            MessageBox.Show("Passed Here")
        End Sub

        Public Sub New(ParamArray data As Object())
            Dim test
            test = data
            MessageBox.Show(test)
        End Sub

        'Public Sub New(ByVal dataProperties As Object())
        '    TableOrViewName = dataProperties(0).ToString()
        '    DboTvpUpdateName = dataProperties(1).ToString()
        '    DboTvpInsertName = dataProperties(2).ToString()
        'End Sub

        'Inherits AccountsDao
        'Implements IDaoChild(Of JournalItem)

        'Private ReadOnly _db As New Db()
        'Protected TableOrViewName As String = ""
        'Protected DboTvpUpdateName As String = ""
        'Protected DboTvpInsertName As String = ""

        'Public Sub New(ByVal dataProperties As Object())
        '    TableOrViewName = dataProperties(0).ToString()
        '    DboTvpUpdateName = dataProperties(1).ToString()
        '    DboTvpInsertName = dataProperties(2).ToString()
        'End Sub

        ''Public Sub New(ByVal dataProperties As Object())
        ''    TableOrViewName = dataProperties(0).ToString()
        ''    DboTvpUpdateName = dataProperties(1).ToString()
        ''    DboTvpInsertName = dataProperties(2).ToString()
        ''End Sub

        'Public Sub New()

        'End Sub

        'Public Function GetRecordsWithIdNo(journalIdNo, Optional sortKey = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithIdNo
        '    If sortKey Is Nothing Then
        '        sortKey = "Sequence"
        '    End If
        '    Dim sql As String =
        '            "SELECT " &
        '            "AccountIdNo," &
        '            "AccountName," &
        '            "Credit," &
        '            "Debit," &
        '            "DiscountTaken," &
        '            "IdNo," &
        '            "JournalIdNo," &
        '            "Notes," &
        '            "OpenInvoiceIdNo," &
        '            "OriginalAmount," &
        '            "PaidAmount," &
        '            "PayeeType," &
        '            "RevCostCenterIdNo," &
        '            "Sequence," &
        '            "SpecialAccount" &
        '            " FROM " & TableOrViewName &
        '            " WHERE JournalIdNo = @JournalIdNo" &
        '            " ORDER BY " & sortKey.ToString()
        '    Dim params() As Object = {"@JournalIdNo", journalIdNo}
        '    Return _db.Read(sql, Make, params).ToList()
        'End Function

        'Public Function DelUpdateTvp(ByRef tvpTable As DataTable, journalItemIdNo As Int32) As Integer _
        '    Implements IDaoChild(Of JournalItem).DelUpdateTvp
        '    Return _db.DelUpdateTvp(DboTvpUpdateName, tvpTable, "@MParam", journalItemIdNo)
        'End Function

        'Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer _
        '    Implements IDaoChild(Of JournalItem).InsertTvp
        '    Return _db.InsertTvp(DboTvpInsertName, tvpTable)
        'End Function

        'Private Shared ReadOnly Make As Func(Of IDataReader, JournalItem) =
        '                            Function(reader) _
        '    New JournalItem() With {
        '    .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
        '    .AccountName = Extensions.AsString(reader("AccountName")),
        '    .Credit = Extensions.AsDecimal(reader("Credit")),
        '    .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
        '    .Debit = Extensions.AsDecimal(reader("Debit")),
        '    .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
        '    .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
        '    .Notes = Extensions.AsString(reader("Notes")),
        '    .OriginalAmount = Extensions.AsDecimal(reader("OriginalAmount")),
        '    .OpenInvoiceIdNo = Extensions.AsDecimal(reader("OpenInvoiceIdNo")),
        '    .PaidAmount = Extensions.AsDecimal(reader("PaidAmount")),
        '    .PayeeType = Extensions.AsString(reader("PayeeType")),
        '    .RevCostCenterIdNo = Extensions.AsInt(Of Integer)(reader("RevCostCenterIdNo")),
        '    .Sequence = Extensions.AsInt(Of Int16)(reader("sequence")),
        '    .SpecialAccount = Extensions.AsString(reader("SpecialAccount"))
        '    }

        'Public Function GetTableOrViewName() As String
        '    Return TableOrViewName
        'End Function

        'Public Sub SetTableOrViewName(AutoPropertyValue As String)
        '    TableOrViewName = AutoPropertyValue
        '    If TableOrViewName = "CkJournalItem_View" Then
        '        DboTvpUpdateName = "UpdateCdJournalItemTVP"
        '        DboTvpInsertName = "InsertCdJournalItemTVP"
        '    ElseIf TableOrViewName = "CdJournalItem_View" Then
        '        DboTvpUpdateName = "UpdateCdJournalItemTVP"
        '        DboTvpInsertName = "InsertCdJournalItemTVP"
        '    ElseIf TableOrViewName = "CkJournalItem_View" Then
        '        DboTvpUpdateName = "UpdateCkJournalItemTVP"
        '        DboTvpInsertName = "InsertCkJournalItemTVP"
        '    End If
        'End Sub

    End Class

End Namespace