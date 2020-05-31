Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CkdOiItem
    ' ** DAO Pattern

    Public Class CkdOiItemDao
        Inherits CommonDao
        Implements IDaoChild(Of CkdOiItem), IDaoOiItem(Of CkdOiItem)

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "CkdOiItem_View"
        Protected DboTvpUpdateFileName As String = "dbo.UpdateCkdOiItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertCkdOiItemTVP"

        Public Function GetRecordsWithIdNo(idNo As Int32, Optional sortExpression As String = Nothing) _
            As List(Of CkdOiItem) Implements IDaoChild(Of CkdOiItem).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "ApOpenInvoiceIdNo," &
                    "Balance," &
                    "CkdIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "PreviousBalance," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableFileName &
                    " WHERE CkdIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, ckdIdNo As Int32) As Integer _
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
            .ApOpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("ApOpenInvoiceIdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .CkdIdNo = Extensions.AsString(reader("CkdIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsId(Of Int32)(reader("JournalIdNo")),
            .PreviousBalance = Extensions.AsDecimal(reader("PreviousBalance")),
            .Sequence = Extensions.AsInt(Of Integer)(reader("sequence")),
            .TransactionDate = Extensions.AsDate((reader("TransactionDate")))
            }

        Public Function GetOpenInvoices(idNo As Int32) _
            As List(Of CkdOiItem) Implements IDaoOiItem(Of CkdOiItem).GetOpenInvoices
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "IdNo," &
                    "Balance," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
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
            .ApOpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

    End Class

End Namespace