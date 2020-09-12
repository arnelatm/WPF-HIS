Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IEarningView
        Inherits IView
        Property IdNo As Int32
        Property EarningCode As String
        Property EarningName As String
        Property EarningNameAra As String
        Property AccountIdNo As Int32?
        Property DefaultFrequency As Char
        Property EarningType As Char
        Property Notes As String
    End Interface

End Namespace