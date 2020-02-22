Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for CsrOiItem
    ' ** DAO Pattern

    Public Class CsrOiItemDao
        Inherits CommonDao
        Implements ICsrOiItemDao

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "CsrOiItem_View"
        Protected DboTvpUpdateFileName As String = "dbo.UpdateCsrOiItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertCsrOiItemTVP"

        Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of CsrOiItem) _
            Implements ICsrOiItemDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, Amount " &
                    "   FROM [CsrOiItem] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecordById(idNo As Integer) As CsrOiItem _
                        Implements ICsrOiItemDao.GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Balance," &
                    "CsrIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "OpenInvoiceIdNo" &
                    "PreviousBalance," &
                    "Sequence," &
                    "TransactionDate" &
                    "   FROM " & TableFileName &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = "Sequence") _
            As List(Of CsrOiItem)
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Balance," &
                    "CsrIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "OpenInvoiceIdNo," &
                    "PreviousBalance," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableFileName &
                    " WHERE CsrIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, csrIdNo As Integer) As Integer _
            Implements ICsrOiItemDao.DelUpdateTvp
            Return Db.TvpDelUpdate(DboTvpUpdateFileName, tvpTable, "@MParam", csrIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements ICsrOiItemDao.InsertTvp
            Return Db.TvpInsert(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CsrOiItem) =
                                    Function(reader) _
            New CsrOiItem() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .CsrIdNo = Extensions.AsString(reader("CsrIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsId(reader("JournalIdNo")),
            .JournalItemIdNo = Extensions.AsId(reader("JournalItemIdNo")),
            .OpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("OpenInvoiceIdNo")),
            .PreviousBalance = Extensions.AsDecimal(reader("PreviousBalance")),
            .Sequence = Extensions.AsInt(Of Integer)(reader("sequence")),
            .TransactionDate = Extensions.AsDate((reader("TransactionDate")))
            }

        '' ReSharper disable once UnusedMember.Local
        'Private Function Take(csrOiItem As CsrOiItem) As Object()
        '    Return New Object() {
        '                            "@AccountIdNo", csrOiItem.AccountIdNo,
        '                            "@Amount", csrOiItem.Amount,
        '                            "@Balance", csrOiItem.Balance,
        '                            "@CsrIdNo", csrOiItem.CsrIdNo,
        '                            "@DiscountTaken", csrOiItem.DiscountTaken,
        '                            "@IdNo", csrOiItem.IdNo,
        '                            "@InvoiceNo", csrOiItem.InvoiceNo,
        '                            "@JournalItemIdNo", csrOiItem.JournalItemIdNo,
        '                            "@OpenInvoiceIdNo", csrOiItem.OpenInvoiceIdNo,
        '                            "@PreviousBalance", csrOiItem.PreviousBalance,
        '                            "@Sequence", csrOiItem.Sequence,
        '                            "@TransactionDate", csrOiItem.TransactionDate
        '                         }
        'End Function

        Public Function GetCustomerOpenInvoices(idNo As Integer) _
            As List(Of CsrOiItem) Implements ICsrOiItemDao.GetCustomerOpenInvoices
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Balance," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "TransactionDate" &
                    " FROM ArOpenInvoice_View " &
                    " WHERE Balance <> 0 and CustomerIdNo = " & idNo.ToString() &
                    " ORDER BY TransactionDate"
            Dim x = Db.Read(sql, MakeCsrOiItem).ToList()
            Return x
        End Function

        Public Shared ReadOnly MakeCsrOiItem As Func(Of IDataReader, CsrOiItem) = Function(reader) New CsrOiItem() With
            {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .OpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .JournalItemIdNo = Extensions.AsInt(Of Integer)(reader("JournalItemIdNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

    End Class

End Namespace