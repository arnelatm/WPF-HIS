Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayPeriodView
        Inherits IView
        Property IdNo As Int32
        Property PayCycleIdNo As Int16
        Property StartDate As Date
        Property EndDate As Date
        Property Description As String
    End Interface

End Namespace