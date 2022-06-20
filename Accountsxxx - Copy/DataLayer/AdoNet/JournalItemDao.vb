Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for JournalItem
    ' ** DAO Pattern

    Public Class JournalItemDao
        Inherits AccountsDao
        Implements IDaoChild(Of JournalItem)

        Private ReadOnly _db As New Db()
        Protected TableOrViewName As String = ""
        Protected DboTvpUpdateName As String = ""
        Protected DboTvpInsertName As String = ""

        Public Sub New(ByVal dataNames As Object())
            'TableOrViewName = AutoPropertyValue
            'If TableOrViewName = "CkJournalItem_View" Then
            '    DboTvpUpdateName = "UpdateCdJournalItemTVP"
            '    DboTvpInsertName = "InsertCdJournalItemTVP"
            'ElseIf TableOrViewName = "CdJournalItem_View" Then
            '    DboTvpUpdateName = "UpdateCdJournalItemTVP"
            '    DboTvpInsertName = "InsertCdJournalItemTVP"
            'ElseIf TableOrViewName = "CkJournalItem_View" Then
            '    DboTvpUpdateName = "UpdateCkJournalItemTVP"
            '    DboTvpInsertName = "InsertCkJournalItemTVP"
            'End If
            TableOrViewName = dataNames(0).ToString()
            DboTvpUpdateName = dataNames(1).ToString()
            DboTvpInsertName = dataNames(2).ToString()

        End Sub

        Public Sub New()
        End Sub

        Public Function GetRecordsWithGroupIdNo(journalIdNo, Optional sortKey = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsWithGroupIdNo
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
                    "IdNo," &
                    "JournalIdNo," &
                    "Notes," &
                    "OpenInvoiceIdNo," &
                    "OriginalAmount," &
                    "PaidAmount," &
                    "PayeeType," &
                    "PayIdNo," &
                    "RevCostCenterIdNo," &
                    "Sequence," &
                    "SpecialAccount" &
                    " FROM " & TableOrViewName &
                    " WHERE JournalIdNo = @JournalIdNo" &
                    " ORDER BY " & sortKey.ToString()
            Dim params() As Object = {"@JournalIdNo", journalIdNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, journalItemIdNo As Int32) As Integer _
            Implements IDaoChild(Of JournalItem).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateName, tvpTable, "@MParam", journalItemIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer _
            Implements IDaoChild(Of JournalItem).InsertTvp
            Return _db.InsertTvp(DboTvpInsertName, tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, JournalItem) =
                                    Function(reader) _
            New JournalItem() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .AccountName = Extensions.AsString(reader("AccountName")),
            .Credit = Extensions.AsDecimal(reader("Credit")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .Debit = Extensions.AsDecimal(reader("Debit")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OriginalAmount = Extensions.AsDecimal(reader("OriginalAmount")),
            .OpenInvoiceIdNo = Extensions.AsDecimal(reader("OpenInvoiceIdNo")),
            .PaidAmount = Extensions.AsDecimal(reader("PaidAmount")),
            .PayeeType = Extensions.AsString(reader("PayeeType")),
            .PayIdNo = Extensions.AsInt(Of Int32)(reader("PayIdNo")),
            .RevCostCenterIdNo = Extensions.AsInt(Of Integer)(reader("RevCostCenterIdNo")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("sequence")),
            .SpecialAccount = Extensions.AsString(reader("SpecialAccount"))
            }

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