Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer
Imports AATM.DataLayer

Namespace DataLayer

    Public Interface IDaoAccounts
        Inherits ICommonDao

    End Interface

    Public Interface IDaoJournalItems

        Function DelUpdateTvp(ByRef tvpTable As DataTable, ByVal groupIdNo As Integer) As Integer

        Function GetRecordsWithIdNo(idNo As Integer, ByRef Optional sortKey As String = Nothing) As Object

        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

    End Interface

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

        Function GetAcctReconItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of TM)

        Function GetGlItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of TM)

        Function GetReconciledRecordsWithIdNo(reconciled As Boolean, idNo As Integer, Optional sortExpression As String = Nothing) As List(Of TM)

    End Interface

    
    Public Interface IDaoCadOiItem(Of TM)

        Function GetSupplierOpenInvoices(idNo As Integer) As List(Of TM)

    End Interface


End Namespace