Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ICashCodeView
        Inherits IView

        Property AccountIdNo as Int32
        Property BankChargesAccountIdNo as Int32
        Property BankChargesVatAccountIdNo as Int32
        Property CashCode As String
        Property CashName As String
        Property CashNameAra As String
        Property IdNo As Integer
        Property Rate As Decimal

    End Interface

End Namespace