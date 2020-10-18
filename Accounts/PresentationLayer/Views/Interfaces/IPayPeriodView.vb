Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayPeriodView
        Inherits IView
        Property EndDate As Date
        Property IdNo As Int32
        Property PayCycleIdNo As Int16
        Property PayPeriodCode As String
        Property PayPeriodName As String
        Property PayPeriodNameAra As String
        Property StartDate As Date
    End Interface

End Namespace