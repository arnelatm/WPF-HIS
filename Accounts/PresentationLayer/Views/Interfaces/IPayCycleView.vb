Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayCycleView
        Inherits IView
        Property PayFrequency As Char
        Property IdNo As Int16
        Property PayCycleCode As String
        Property PayCycleName As String
        Property PayCycleNameAra As String
        Property Notes As String
    End Interface

End Namespace