Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Interface IModelAccounts
        Inherits IModelCommon

        'Function AddApOpenInvoice(journalItemModel As JournalItemModel, journalCode As String) As Integer

        'Function AddInvoicePayment(idNo As Int32, amount As Decimal, discountTaken As Decimal) As Integer

        Function GetCustomerOpenInvoices(Of TM)(idNo As Int32) As List(Of TM)

        Function GetSupplierOpenInvoices(Of TM)(idNo As Int32) As List(Of TM)

        'Function RemoveInvoicePayment(idNo As Int32, amount As Decimal, discountTaken As Decimal) As Integer

        Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer

        Function UpdateOpeningBalance(Of TM)(ByRef model As TM) As Integer

        Function GetAcctReconItems(Of TM)(AccountIdNo As Int16, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of TM)

    End Interface

    'Public Interface IModelOpenInvoice
    '    Inherits IModelAccounts

    '    'Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    '    'Function RemoveInvoiceCollection(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    '    Function AddApOpenInvoice(journalItemModel As JournalItemModel, journalCode As String) As Integer
    '    Function GetCustomerOpenInvoices(idNo As Int32) As List(Of TM)
    '    Function GetSupplierOpenInvoices(idNo As Int32) As List(Of TM)
    '    Function AddInvoicePayment(idNo As Int32, amount As Decimal, discountTaken As Decimal) As Integer
    '    Function RemoveInvoiceCollection(idNo As Int32, amount As Decimal, discountTaken As Decimal) As Integer

    'End Interface

    'Public Interface IModelCashCode
    '    Inherits IModelAccounts

    'End Interface

End Namespace