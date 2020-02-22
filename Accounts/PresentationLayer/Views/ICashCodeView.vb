Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ICashCodeView
        Inherits IView

        Property AccountIdNo As Integer
        Property BankChargesAccountIdNo As Integer
        Property BankChargesVatAccountIdNo As Integer
        Property CashCode As String
        Property CashName As String
        Property CashNameAra As String
        Property IdNo As Integer
        Property Rate As Decimal

    End Interface
End NameSpace