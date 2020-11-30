Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for DjOiItem
    ' ** DAO Pattern

    Public Class DjOiItemDao
        Inherits DaoAccounts
        Implements IDaoChild(Of DjOiItem), IDaoOiItem(Of DjOiItem)

        Private ReadOnly _db As New Db()

        Protected _tableOrViewName As String = ""
        Protected _dboTvpUpdateName As String = ""
        Protected _dboTvpInsertName As String = ""

        Public Function GetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) As List(Of DjOiItem) Implements IDaoChild(Of DjOiItem).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "ApOpenInvoiceIdNo," &
                    "Balance," &
                    "DjIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "PreviousBalance," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & _tableOrViewName &
                    " WHERE DjIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = _db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, djIdNo As Int32) As Integer Implements IDaoChild(Of DjOiItem).DelUpdateTvp
            Return _db.DelUpdateTvp(_dboTvpUpdateName, tvpTable, "@MParam", djIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of DjOiItem).InsertTvp
            Return _db.InsertTvp(_dboTvpInsertName, tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DjOiItem) =
                                    Function(reader) _
            New DjOiItem() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .ApOpenInvoiceIdNo = Extensions.AsId(Of Int32)(reader("ApOpenInvoiceIdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .DjIdNo = Extensions.AsString(reader("DjIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsId(Of Int32)(reader("JournalIdNo")),
            .PreviousBalance = Extensions.AsDecimal(reader("PreviousBalance")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("sequence")),
            .TransactionDate = Extensions.AsDate((reader("TransactionDate")))
            }

        Public Function GetOpenInvoices(idNo As Int32) As List(Of DjOiItem) Implements IDaoOiItem(Of DjOiItem).GetOpenInvoices
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Balance," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "TransactionDate" &
                    " FROM ApOpenInvoice_View " &
                    " WHERE Balance <> 0 and SupplierIdNo = " & idNo.ToString() &
                    " ORDER BY TransactionDate"
            Dim x = _db.Read(sql, MakeDjOiItem).ToList()
            Return x
        End Function

        Public Shared ReadOnly MakeDjOiItem As Func(Of IDataReader, DjOiItem) = Function(reader) New DjOiItem() With
            {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .ApOpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .IdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

        Public Function GetTableOrViewName() As String
            Return _tableOrViewName
        End Function

        Public Sub SetTableOrViewName(AutoPropertyValue As String)
            _tableOrViewName = AutoPropertyValue
            If _tableOrViewName = "CdOiItem" Then
                _dboTvpUpdateName = "dbo.UpdateCdOiItemTVP"
                _dboTvpInsertName = "dbo.InsertCdOiItemTVP"
            ElseIf _tableOrViewName = "PcOiItem" Then
                _dboTvpUpdateName = "dbo.UpdatePcOiItemTVP"
                _dboTvpInsertName = "dbo.InsertPcOiItemTVP"
            ElseIf _tableOrViewName = "CkOiItem" Then
                _dboTvpUpdateName = "dbo.UpdateCkOiItemTVP"
                _dboTvpInsertName = "dbo.InsertCkOiItemTVP"
            End If
        End Sub

        Public Function GetDboTvpUpdateName() As String
            Return _dboTvpUpdateName
        End Function

        Public Sub SetDboTvpUpdateName(AutoPropertyValue As String)
            _dboTvpUpdateName = AutoPropertyValue
        End Sub

        Public Function GetDboTvpInsertName() As String
            Return _dboTvpInsertName
        End Function

        Public Sub SetDboTvpInsertName(AutoPropertyValue As String)
            _dboTvpInsertName = AutoPropertyValue
        End Sub

    End Class

End Namespace