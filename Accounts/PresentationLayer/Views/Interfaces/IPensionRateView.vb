Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPensionRateView
        Inherits IView

        Property EmployeeShare As Decimal
        Property EmployerShare As Decimal
        Property HighRange As Decimal
        Property IdNo As Int32
        Property LowRange As Decimal
        Property MaxAmount As Decimal
        Property PensionSchemeIdNo As Int16
        Property Sequence As Int16

    End Interface

End Namespace