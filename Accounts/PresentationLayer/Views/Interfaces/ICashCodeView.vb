Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ICashCodeView
        Inherits IView

        Property AccountIdNo As Int16?
        Property BankChargesAccountIdNo As Int16?
        Property BankChargesVatAccountIdNo As Int16?
        Property CashCode As String
        Property CashName As String
        Property CashNameAra As String
        Property IdNo As Int32
        Property Rate As Decimal

    End Interface

End Namespace