Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPensionSchemeView
        Inherits IView

        Property AccountIdNo As Int16
        Property IdNo As Int16
        Property Notes As String
        Property PensionProviderIdNo As Int16
        Property PensionSchemeCode As String
        Property PensionSchemeName As String
        Property PensionSchemeNameAra As String
        Property PensionRates As List(Of PensionRateView)
    End Interface

End Namespace