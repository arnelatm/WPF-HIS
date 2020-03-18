Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Interface IModelAccounts
        Inherits IModelCommon

        Function AddApOpenInvoice(journalItemModel As JournalItemModel, journalCode As String) As Integer
        Function AddInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Integer
        Function GetCustomerOpenInvoices(Of TM)(idNo As Integer) As List(Of TM)
        Function GetSupplierOpenInvoices(Of TM)(idNo As Integer) As List(Of TM)
        Function RemoveInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Integer
        Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer


    End Interface


    'Public Interface IModelOpenInvoice
    '    Inherits IModelAccounts

    '    'Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    '    'Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    '    Function AddApOpenInvoice(journalItemModel As JournalItemModel, journalCode As String) As Integer
    '    Function GetCustomerOpenInvoices(idNo As Integer) As List(Of TM)
    '    Function GetSupplierOpenInvoices(idNo As Integer) As List(Of TM)
    '    Function AddInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Integer
    '    Function RemoveInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Integer

    'End Interface

    'Public Interface IModelCashCode
    '    Inherits IModelAccounts

    'End Interface

End Namespace