Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDistributionSchemeItemView
        Inherits IView

        Property IdNo As Int32
        Property DistributionSchemeIdNo As Int32
        Property Sequence As Int16
        Property RevCostCenterIdNo As Int16
        Property RevCostCenterName As String
        Property Percentage As Decimal

    End Interface

End Namespace