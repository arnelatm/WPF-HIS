Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPensionRatesView
        Inherits IView

        Property PensionRates As IList(Of PensionRateModel)

    End Interface

End Namespace