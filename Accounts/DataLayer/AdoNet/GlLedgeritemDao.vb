Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for GlLedgerItem
    ' ** DAO Pattern

    Public Class GlLedgerItemDao
        Inherits CommonDao
        Implements IDaoChild(Of GlLedgerItem)

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "GlLedger_View"
        Protected DboTvpUpdateFileName As String = ""
        Protected DboTvpInsertFileName As String = ""

        'Public Sub New()
        '    DbCommon = Db
        'End Sub

        'Public Function GetRecordById(idNo As Integer) As GlLedgerItem Implements IDaoChild(Of GlLedgerItem).GetRecordById
        '    Dim sql As String =
        '            "SELECT " &
        '            "AccountIdNo," &
        '            "AccountName," &
        '            "Credit," &
        '            "DiscountTaken," &
        '            "Debit," &
        '            "IDNo," &
        '            "JournalIdNo," &
        '            "Notes," &
        '            "OpenInvoiceIdNo," &
        '            "OriginalAmount," &
        '            "PaidAmount," &
        '            "PayeeType," &
        '            "ProfitCenterIdNo," &
        '            "Sequence," &
        '            "SpecialAccount" &
        '            " FROM " & TableFileName &
        '            " WHERE IDNo = @IDNo"
        '    Dim params() As Object = {"@IDNo", idNo}
        '    Return Db.Read(sql, Make, params).FirstOrDefault()
        'End Function

        'Public Function GetGlLedgerItems(journalIdNo As Integer) As List(Of GlLedgerItem)
        '    Dim sql As String =
        '            "SELECT " &
        '            "AccountIdNo," &
        '            "Credit," &
        '            "Debit," &
        '            "IDNo," &
        '            "JournalIdNo," &
        '            "Notes," &
        '            "OpenInvoiceIdNo," &
        '            "OriginalAmount," &
        '            "PaidAmount," &
        '            "PayeeType," &
        '            "ProfitCenterIdNo," &
        '            "Sequence," &
        '            "SpecialAccount" &
        '            " FROM " & TableFileName &
        '            " WHERE JournalIdNo = @JournalIdNo" &
        '            " ORDER BY Sequence"
        '    Dim params() As Object = {"@JournalIdNo", journalIdNo}
        '    Return Db.Read(sql, Make, params).ToList()
        'End Function

        Private Function GetRecordsWithIdNo(journalIdNo As Integer, Optional sortExpression As String = Nothing) As List(Of GlLedgerItem) Implements IDaoChild(Of GlLedgerItem).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Credit," &
                    "Debit," &
                    "IDNo," &
                    "JournalIdNo," &
                    "Notes," &
                    "PaidAmount," &
                    "PayDescription," &
                    "PayDescriptionAra," &
                    "PayeeType," &
                    "Posted," &
                    "ProfitCenterIdNo," &
                    "ReferenceNo," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableFileName &
                    " WHERE JournalIdNo = @JournalIdNo" &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@JournalIdNo", journalIdNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, glLedgerItemIdNo As Integer) As Integer _
            Implements IDaoChild(Of GlLedgerItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", glLedgerItemIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of GlLedgerItem).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Public Function GetGlLedger(ByRef accountIdNo As Integer, transactionDate As Date, Optional sortExpression As String = "TransactionDate") _
            As List(Of GlLedgerItem)
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Credit," &
                    "Debit," &
                    "IDNo," &
                    "JournalIdNo," &
                    "Notes," &
                    "PaidAmount," &
                    "PayDescription," &
                    "PayDescriptionAra," &
                    "PayeeType," &
                    "Posted," &
                    "ProfitCenterIdNo," &
                    "ReferenceNo," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableFileName &
                    " WHERE TransactionDate <= " & DtoS(transactionDate) &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, GlLedgerItem) =
                                    Function(reader) _
            New GlLedgerItem() With {
            .AccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Credit = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Credit")),
            .Debit = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Debit")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(reader("IDNo")),
            .JournalIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
            .ProfitCenterIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("ProfitCenterIdNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("Sequence"))
            }

        'Private Function Take(glLedgerItem As GlLedgerItem) As Object()
        '    Return New Object() {
        '                            "@AccountIdNo", glLedgerItem.AccountIdNo,
        '                            "@Credit", glLedgerItem.Credit,
        '                            "@Debit", glLedgerItem.Debit,
        '                            "@IDNo", glLedgerItem.IdNo,
        '                            "@JournalIdNo", glLedgerItem.JournalIdNo,
        '                            "@Notes", glLedgerItem.Notes,
        '                            "@ProfitCenterIdNo", glLedgerItem.ProfitCenterIdNo,
        '                            "@Sequence", glLedgerItem.Sequence
        '                        }
        'End Function

    End Class

End Namespace