Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IBankView
        Inherits IView
        Property IdNo As Int32
        Property BankCode As String
        Property BankName As String
        Property BankNameAra As String
        Property Notes As String
    End Interface

End Namespace