Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer

Namespace DataLayer.AdoNet
    ' Data access object for CkdOiItem
    ' ** DAO Pattern

    Public Class CkdOiItemDao
        Inherits CommonDao
        Implements IDaoChild(Of CkdOiItem), IDaoOiItem(of CkdOiItem)

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "CkdOiItem_View"
        Protected DboTvpUpdateFileName As String = "dbo.UpdateCkdOiItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertCkdOiItemTVP"

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) _
            As List(Of CkdOiItem) Implements IDaoChild(Of CkdOiItem).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Balance," &
                    "CkdIdNo," &
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
                    " WHERE CkdIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, ckdIdNo As Integer) As Integer _
            Implements IDaoChild(Of CkdOiItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", ckdIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of CkdOiItem).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CkdOiItem) =
                                    Function(reader) _
            New CkdOiItem() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .CkdIdNo = Extensions.AsString(reader("CkdIdNo")),
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
        'Private Function Take(ckdOiItem As CkdOiItem) As Object()
        '    Return New Object() {
        '                            "@AccountIdNo", ckdOiItem.AccountIdNo,
        '                            "@Amount", ckdOiItem.Amount,
        '                            "@Balance", ckdOiItem.Balance,
        '                            "@CkdIdNo", ckdOiItem.CkdIdNo,
        '                            "@DiscountTaken", ckdOiItem.DiscountTaken,
        '                            "@IdNo", ckdOiItem.IdNo,
        '                            "@InvoiceNo", ckdOiItem.InvoiceNo,
        '                            "@JournalItemIdNo", ckdOiItem.JournalItemIdNo,
        '                            "@OpenInvoiceIdNo", ckdOiItem.OpenInvoiceIdNo,
        '                            "@PreviousBalance", ckdOiItem.PreviousBalance,
        '                            "@Sequence", ckdOiItem.Sequence,
        '                            "@TransactionDate", ckdOiItem.TransactionDate
        '                         }
        'End Function

        Public Function GetSupplierOpenInvoices(idNo As Integer) _
            As List(Of CkdOiItem) Implements IDaoOiItem(Of CkdOiItem).GetOpenInvoices
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
            Dim x = Db.Read(sql, MakeCkdOiItem).ToList()
            Return x
        End Function

        Public Shared ReadOnly MakeCkdOiItem As Func(Of IDataReader, CkdOiItem) = Function(reader) New CkdOiItem() With
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