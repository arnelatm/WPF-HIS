Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDistributionSchemeView
        Inherits IView
        Property IdNo As Int32
        Property DistributionSchemeCode As String
        Property DistributionSchemeName As String
        Property DistributionSchemeNameAra As String
        Property ValidityStartDate As Date?
        Property ValidityEndDate As Date?
        Property Notes As String
        Property TotalPercentage As Decimal
        Property DistributionSchemeItems As List(Of DistributionSchemeItemView)
        Property RevCostCenterByCode
    End Interface

End Namespace