Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ICashCodeView
        Inherits IView

        Property AccountIdNo As Int32?
        Property BankChargesAccountIdNo As Int32?
        Property BankChargesVatAccountIdNo As Int32?
        Property CashCode As String
        Property CashName As String
        Property CashNameAra As String
        Property IdNo As Int32
        Property Rate As Decimal

    End Interface

End Namespace