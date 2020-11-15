Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer

Namespace DataLayer

    Public Interface IDaoAccounts
        Inherits ICommonDao

    End Interface

    Public Interface IDaoContacts(Of TBiz)

        Function UpdateOpeningBalance(ByRef bizObj As TBiz) As Integer

    End Interface

    Public Interface IDaoJournals(Of TBiz)

        Function UpdateGlReferenceNumber(ByRef bizObj As TBiz) As Integer

    End Interface

    Public Interface IDaoOpenInvoice(Of TBiz)

        Function AddRecord(ByRef openInvoice As TBiz) As Integer

    End Interface

    Public Interface IDaoAccount

        Function GetDetailAccounts(Optional sortExpression As String = Nothing) As List(Of Account)

    End Interface

    Public Interface IDaoAccountReconciliationItem(Of TM)

        Function GetAcctReconItems(AccountIdNo As Int16, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of TM)

        Function GetGlItems(AccountIdNo As Int16, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of TM)

        Function GetReconciledRecordsWithIdNo(reconciled As Boolean, idNo As Int32, Optional sortExpression As String = Nothing) As List(Of TM)

    End Interface

    Public Interface IDaoOiItem(Of TM)

        Function GetOpenInvoices(idNo As Int32) As List(Of TM)

    End Interface

End Namespace