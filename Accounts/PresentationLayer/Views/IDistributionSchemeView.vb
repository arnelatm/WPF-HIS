Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IDistributionSchemeView
        Inherits IView
        Property IdNo As Integer
        Property DistributionSchemeCode As String
        Property DistributionSchemeName As String
        Property DistributionSchemeNameAra As String
        Property ValidityStartDate As Date?
        Property ValidityEndDate As Date?
        Property Notes As String
        Property TotalPercentage As Decimal
    End Interface

End Namespace