Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for CadOiItem
    ' ** DAO Pattern

    Public Class CadOiItemDao
        Inherits CommonDao
        Implements ICadOiItemDao

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "CadOiItem_View"
        Protected DboTvpUpdateFileName As String = "dbo.UpdateCadOiItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertCadOiItemTVP"

        Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of CadOiItem) _
            Implements ICadOiItemDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, Amount " &
                    "   FROM [CadOiItem] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecordById(idNo As Integer) As CadOiItem _
                        Implements ICadOiItemDao.GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Balance," &
                    "CadIdNo," &
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
            As List(Of CadOiItem)
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Balance," &
                    "CadIdNo," &
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
                    " WHERE CadIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, cadIdNo As Integer) As Integer _
            Implements ICadOiItemDao.DelUpdateTvp
            Return Db.TvpDelUpdate(DboTvpUpdateFileName, tvpTable, "@MParam", cadIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements ICadOiItemDao.InsertTvp
            Return Db.TvpInsert(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CadOiItem) =
                                    Function(reader) _
            New CadOiItem() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .CadIdNo = Extensions.AsString(reader("CadIdNo")),
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
        'Private Function Take(cadOiItem As CadOiItem) As Object()
        '    Return New Object() {
        '                            "@AccountIdNo", cadOiItem.AccountIdNo,
        '                            "@Amount", cadOiItem.Amount,
        '                            "@Balance", cadOiItem.Balance,
        '                            "@CadIdNo", cadOiItem.CadIdNo,
        '                            "@DiscountTaken", cadOiItem.DiscountTaken,
        '                            "@IdNo", cadOiItem.IdNo,
        '                            "@InvoiceNo", cadOiItem.InvoiceNo,
        '                            "@JournalItemIdNo", cadOiItem.JournalItemIdNo,
        '                            "@OpenInvoiceIdNo", cadOiItem.OpenInvoiceIdNo,
        '                            "@PreviousBalance", cadOiItem.PreviousBalance,
        '                            "@Sequence", cadOiItem.Sequence,
        '                            "@TransactionDate", cadOiItem.TransactionDate
        '                         }
        'End Function

        Public Function GetSupplierOpenInvoices(idNo As Integer) _
            As List(Of CadOiItem) Implements ICadOiItemDao.GetSupplierOpenInvoices
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
                    " FROM ApOpenInvoice_View " &
                    " WHERE Balance <> 0 and SupplierIdNo = " & idNo.ToString() &
                    " ORDER BY TransactionDate"
            Dim x = Db.Read(sql, MakeCadOiItem).ToList()
            Return x
        End Function

        Public Shared ReadOnly MakeCadOiItem As Func(Of IDataReader, CadOiItem) = Function(reader) New CadOiItem() With
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