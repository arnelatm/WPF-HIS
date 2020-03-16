Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Interface IModelAccounts
        Inherits IModelCommon

        Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer

    End Interface

    Public Interface IModelOpenInvoice
        Inherits IModelAccounts

        Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

        Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    End Interface

    Public Interface IModelCashCode
        Inherits IModelAccounts

    End Interface

End Namespace