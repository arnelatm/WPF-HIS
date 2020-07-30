Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IDistributionSchemeItemView
        Inherits IView

        Property IdNo As Int32
        Property DistributionSchemeIdNo As Int32
        Property Sequence As Integer
        Property RevCostCenterIdNo As Int32
        Property RevCostCenterName As String
        Property Percentage As Decimal

    End Interface

End Namespace