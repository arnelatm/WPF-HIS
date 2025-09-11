Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IShiftSummaryView
        Inherits IView

        Property Cards As Decimal
        Property Cash As Decimal
        Property DateCreated As DateTime?
        Property DateEnd As DateTime
        Property DateStart As DateTime
        Property IdNo As Int32
        Property UserIdNo As Int16

    End Interface

End Namespace