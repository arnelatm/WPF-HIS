Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IFringeBenefitView
        Inherits IView
        Property IdNo As Int32
        Property FringeBenefitCode As String
        Property FringeBenefitName As String
        Property FringeBenefitNameAra As String
        Property AccountIdNo As Int32?
        Property DefaultFrequency As Char
        Property FringeBenefitType As Char
        Property Notes As String
    End Interface

End Namespace