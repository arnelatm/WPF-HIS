Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayElementItemView
        Inherits IView
        Property ParentIdNo As Int16
        Property PayElementIdNo As Int16
        Property IdNo As Int16
        Property FactorType As String
        Property FactorValue As Decimal
        Property Sequence As Int16
    End Interface

End Namespace