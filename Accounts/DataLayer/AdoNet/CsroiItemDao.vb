Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CsrOiItem
    ' ** DAO Pattern

    Public Class CsrOiItemDao
        Inherits CommonDao
        Implements IDaoChild(Of CsrOiItem), IDaoOiItem(Of CsrOiItem)

        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()

        Protected TableFileName As String = "CsrOiItem_View"
        Protected DboTvpUpdateFileName As String = "dbo.UpdateCsrOiItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertCsrOiItemTVP"

        Public Function GetRecordsWithIdNo(idNo As Int32, Optional sortExpression As String = Nothing) _
            As List(Of CsrOiItem) Implements IDaoChild(Of CsrOiItem).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
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
                    "PreviousBalance," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableFileName &
                    " WHERE CsrIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, csrIdNo As Int32) As Integer _
            Implements IDaoChild(Of CsrOiItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", csrIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of CsrOiItem).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CsrOiItem) =
                                    Function(reader) _
            New CsrOiItem() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .ArOpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .CsrIdNo = Extensions.AsString(reader("CsrIdNo")),
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
            As List(Of CsrOiItem) Implements IDaoOiItem(Of CsrOiItem).GetOpenInvoices
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Balance," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
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
            .ArOpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .IdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

    End Class

End Namespace