
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelApOpenInvoice
        Inherits ModelAccounts
        Implements IModelApOpenInvoice

        Private Shared ReadOnly Property Service As New ApOpenInvoiceService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IModelApOpenInvoice.AddInvoicePayment
            Dim updateResult As Integer
            updateResult = Service.AddInvoicePayment(idNo, amount, discountTaken)
            Return updateResult
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IModelApOpenInvoice.RemoveInvoicePayment
            Dim updateResult As Integer
            updateResult = Service.RemoveInvoicePayment(idNo, amount, discountTaken)
            Return updateResult
        End Function

    End Class

    Public Interface IModelApOpenInvoice
        Inherits IModelAccounts

        Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

        Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    End Interface
End NameSpace