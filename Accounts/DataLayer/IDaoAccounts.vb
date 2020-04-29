Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer

Namespace DataLayer

    Public Interface IDaoAccounts
        Inherits ICommonDao

        Function GetSupplierOpenInvoices(idNo As Int32) As List(Of CadOiItem)

    End Interface

    'Public Interface IDaoJournalItems

    '    Function DelUpdateTvp(ByRef tvpTable As DataTable, ByVal groupIdNo As Int32) As Integer

    '    Function GetRecordsWithIdNo(idNo As Int32, ByRef Optional sortKey As String = Nothing) As Object

    '    Function InsertTvp(ByRef tvpTable As DataTable) As Integer

    'End Interface

    Public Interface IDaoJournals(Of TBiz)

        Function UpdateGlReferenceNumber(ByRef bizObj As TBiz) As Integer

    End Interface

    Public Interface IDaoOpenInvoice(Of TBiz)

        Function AddRecord(ByRef openInvoice As TBiz) As Integer

        Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

        Function RemoveInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    End Interface

    Public Interface IDaoChart

        Function GetDetailAccounts(Optional sortExpression As String = Nothing) As List(Of Chart)

    End Interface

    Public Interface IDaoAccountReconciliationItem(Of TM)

        Function GetAcctReconItems(AccountIdNo as Int32, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of TM)

        Function GetGlItems(AccountIdNo as Int32, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of TM)

        Function GetReconciledRecordsWithIdNo(reconciled As Boolean, idNo As Int32, Optional sortExpression As String = Nothing) As List(Of TM)

    End Interface

    Public Interface IDaoOiItem(Of TM)

        Function GetOpenInvoices(idNo As Int32) As List(Of TM)

    End Interface

End Namespace