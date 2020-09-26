Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDeductionView
        Inherits IView
        Property IdNo As Int16
        Property DeductionCode As String
        Property DeductionName As String
        Property DeductionNameAra As String
        Property AccountIdNo As Int16?
        Property Frequency As Char
        Property DeductionType As Char
        Property Notes As String
    End Interface

End Namespace