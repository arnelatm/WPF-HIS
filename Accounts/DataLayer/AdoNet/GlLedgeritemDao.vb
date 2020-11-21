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

        'Public Function GetRecordById(idNo) As GlLedgerItem Implements IDaoChild(Of GlLedgerItem).GetRecordById
        '    Dim sql As String =
        '            "SELECT " &
        '            "AccountIdNo," &
        '            "AccountName," &
        '            "Credit," &
        '            "DiscountTaken," &
        '            "Debit," &
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
        '            " FROM " & TableName &
        '            " WHERE IdNo = @IdNo"
        '    Dim params() As Object = {"@IdNo", idNo}
        '    Return Db.Read(sql, Make, params).FirstOrDefault()
        'End Function

        'Public Function GetGlLedgerItems(journalIdNo As Int32) As List(Of GlLedgerItem)
        '    Dim sql As String =
        '            "SELECT " &
        '            "AccountIdNo," &
        '            "Credit," &
        '            "Debit," &
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
        '            " FROM " & TableName &
        '            " WHERE JournalIdNo = @JournalIdNo" &
        '            " ORDER BY Sequence"
        '    Dim params() As Object = {"@JournalIdNo", journalIdNo}
        '    Return Db.Read(sql, Make, params).ToList()
        'End Function

        Private Function GetRecordsWithIdNo(journalIdNo, Optional sortExpression = Nothing) As List(Of GlLedgerItem) Implements IDaoChild(Of GlLedgerItem).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Credit," &
                    "Debit," &
                    "IdNo," &
                    "JournalIdNo," &
                    "Notes," &
                    "PaidAmount," &
                    "PayDescription," &
                    "PayDescriptionAra," &
                    "PayeeType," &
                    "Posted," &
                    "RevCostCenterIdNo," &
                    "ReferenceNo," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableFileName &
                    " WHERE JournalIdNo = @JournalIdNo" &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@JournalIdNo", journalIdNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, glLedgerItemIdNo As Int32) As Integer _
            Implements IDaoChild(Of GlLedgerItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", glLedgerItemIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of GlLedgerItem).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Public Function GetGlLedger(ByRef AccountIdNo As Int16, transactionDate As Date, Optional sortExpression As String = "TransactionDate") _
            As List(Of GlLedgerItem)
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Credit," &
                    "Debit," &
                    "IdNo," &
                    "JournalIdNo," &
                    "Notes," &
                    "PaidAmount," &
                    "PayDescription," &
                    "PayDescriptionAra," &
                    "PayeeType," &
                    "Posted," &
                    "RevCostCenterIdNo," &
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
            .AccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .Credit = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Credit")),
            .Debit = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Debit")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .JournalIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
            .RevCostCenterIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("RevCostCenterIdNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("sequence"))
            }

        'Private Function Take(glLedgerItem As GlLedgerItem) As Object()
        '    Return New Object() {
        '                            "@AccountIdNo", glLedgerItem.AccountIdNo,
        '                            "@Credit", glLedgerItem.Credit,
        '                            "@Debit", glLedgerItem.Debit,
        '                            "@IdNo", glLedgerItem.IdNo,
        '                            "@JournalIdNo", glLedgerItem.JournalIdNo,
        '                            "@Notes", glLedgerItem.Notes,
        '                            "@RevCostCenterIdNo", glLedgerItem.RevCostCenterIdNo,
        '                            "@Sequence", glLedgerItem.Sequence
        '                        }
        'End Function

    End Class

End Namespace