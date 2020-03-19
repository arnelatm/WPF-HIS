Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IBankView
        Inherits IView
        Property IdNo As Integer
        Property BankCode As String
        Property BankName As String
        Property BankNameAra As String
        Property Notes As String
    End Interface

End Namespace