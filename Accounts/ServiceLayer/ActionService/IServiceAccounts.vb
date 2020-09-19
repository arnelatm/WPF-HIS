Imports AATM.Common.ServiceLayer

Namespace ServiceLayer.ActionService

    Public Interface IServiceAccounts
        Inherits IServiceCommon

        'Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal)

        Function GetAcctReconItems(Of TM)(AccountIdNo As Int16, reconciliationDate As Date, Optional sortOrder As String = Nothing) As List(Of TM)

        Function GetReconciledRecordsWithIdNo(Of TM)(ByVal reconciled As Boolean, ByVal idNo As Int32, ByVal Optional sortOrder As String = Nothing) As List(Of TM)

        'Function RemoveInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal)

        Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer

        Function UpdateOpeningBalance(Of TM)(ByRef model As TM) As Integer

        Function GetOpenInvoices(Of TM)(idNo As Int32) As List(Of TM)

        'Function GetSupplierOpenInvoices(Of TM)(idNo As Int32) As List(Of TM)

    End Interface

    'Friend Interface IOpenInvoiceService

    'End Interface

    'Public Interface IAccountReconciliationItemService(Of TBo)

    '    Function GetAcctReconItems(AccountIdNo As Int16, reconciliationDate As Date, Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItem)

    '    Function GetReconciledRecordsWithIdNo(ByVal reconciled As Boolean, ByVal idNo As Int32, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItem)

    'End Interface

End Namespace