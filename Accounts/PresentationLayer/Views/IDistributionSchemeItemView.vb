Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IDistributionSchemeItemView
        Inherits IView

        Property IdNo As Integer
        Property DistributionSchemeIdNo As Integer
        Property Sequence As Integer
        Property ProfitCenterIdNo As Integer
        Property ProfitCenterName As String
        Property Percentage As Decimal

    End Interface

End Namespace