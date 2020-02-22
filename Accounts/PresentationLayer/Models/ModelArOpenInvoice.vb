
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelArOpenInvoice
        Inherits ModelAccounts
        Implements IModelArOpenInvoice

        Private Shared ReadOnly Property Service As New ArOpenInvoiceService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IModelArOpenInvoice.AddInvoicePayment
            Dim updateResult As Integer
            updateResult = Service.AddInvoicePayment(idNo, amount, discountTaken)
            Return updateResult
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IModelArOpenInvoice.RemoveInvoicePayment
            Dim updateResult As Integer
            updateResult = Service.RemoveInvoicePayment(idNo, amount, discountTaken)
            Return updateResult
        End Function

    End Class

    Public Interface IModelArOpenInvoice
        Inherits IModelAccounts

        Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

        Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    End Interface
End NameSpace