Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPaymentTypeView
        Inherits IView

        Property AccountIdNo As Int16
        Property BankChargesAccountIdNo As Int16
        Property BankChargesVatAccountIdNo As Int16
        Property PaymentTypeCode As String
        Property PaymentTypeName As String
        Property PaymentTypeNameAra As String
        Property IdNo As Int16
        Property Rate As Decimal

    End Interface

End Namespace