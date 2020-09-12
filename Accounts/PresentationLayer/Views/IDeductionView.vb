Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IDeductionView
        Inherits IView
        Property IdNo As Int32
        Property DeductionCode As String
        Property DeductionName As String
        Property DeductionNameAra As String
        Property AccountIdNo As Int32?
        Property DefaultFrequency As Char
        Property DeductionType As Char
        Property Notes As String
    End Interface

End Namespace