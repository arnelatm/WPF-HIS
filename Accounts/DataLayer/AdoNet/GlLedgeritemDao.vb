Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for GlLedgerItem
    ' ** DAO Pattern

    Public Class GlLedgerItemDao
        Inherits CommonDao
        Implements IGlLedgerItemDao

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "GlLedger_View"
        Protected DboTvpUpdateFileName As String = ""
        Protected DboTvpInsertFileName As String = ""

        'Public Sub New()
        '    DbCommon = Db
        'End Sub

        Public Function GetRecordById(idNo As Integer) As GlLedgerItem Implements IGlLedgerItemDao.GetRecordById
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "AccountName," &
                    "Credit," &
                    "DiscountTaken," &
                    "Debit," &
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
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetGlLedgerItems(journalIdNo As Integer) As List(Of GlLedgerItem)
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Credit," &
                    "Debit," &
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
                    " ORDER BY Sequence"
            Dim params() As Object = {"@JournalIdNo", journalIdNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of GlLedgerItem) _
            Implements IGlLedgerItemDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, JournalIdNo,  " &
                    "   FROM " & TableFileName & " order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = "Sequence") _
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
                    " WHERE JournalIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
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

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, glLedgerItemIdNo As Integer) As Integer _
            Implements IGlLedgerItemDao.DelUpdateTvp
            Return Db.TvpDelUpdate(DboTvpUpdateFileName, tvpTable, "@MParam", glLedgerItemIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IGlLedgerItemDao.InsertTvp
            Return Db.TvpInsert(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, GlLedgerItem) =
                                    Function(reader) _
            New GlLedgerItem() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Credit = Extensions.AsDecimal(reader("Credit")),
            .Debit = Extensions.AsDecimal(reader("Debit")),
            .IdNo = Extensions.AsId(reader("IDNo")),
            .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .ProfitCenterIdNo = Extensions.AsInt(Of Integer)(reader("ProfitCenterIdNo")),
            .Sequence = Extensions.AsInt(Of Integer)(reader("Sequence"))
            }

        Private Function Take(glLedgerItem As GlLedgerItem) As Object()
            Return New Object() {
                                    "@AccountIdNo", glLedgerItem.AccountIdNo,
                                    "@Credit", glLedgerItem.Credit,
                                    "@Debit", glLedgerItem.Debit,
                                    "@IDNo", glLedgerItem.IdNo,
                                    "@JournalIdNo", glLedgerItem.JournalIdNo,
                                    "@Notes", glLedgerItem.Notes,
                                    "@ProfitCenterIdNo", glLedgerItem.ProfitCenterIdNo,
                                    "@Sequence", glLedgerItem.Sequence
                                }
        End Function

    End Class

End Namespace