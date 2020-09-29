Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEarningView
        Inherits IView
        Property AccountIdNo As Int16
        Property EarningCode As String
        Property EarningName As String
        Property EarningNameAra As String
        Property EarningType As Char
        Property Frequency As Char
        Property IdNo As Int16
        Property Notes As String
        Property PayrollEarnAccounts As List(Of PayrollEarnAccountView)
    End Interface

End Namespace