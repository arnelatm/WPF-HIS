Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.ServiceLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionService

    Public Interface IServiceAccounts
        Inherits IServiceCommon

        Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer

    End Interface

    Friend Interface IOpenInvoiceService

        Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal)

        Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal)

    End Interface

    Public Interface IAccountReconciliationItemService(Of TBo)

        Function GetAcctReconItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItem)

        Function GetReconciledRecordsWithIdNo(ByVal reconciled As Boolean, ByVal idNo As Integer, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItem)

    End Interface

End Namespace