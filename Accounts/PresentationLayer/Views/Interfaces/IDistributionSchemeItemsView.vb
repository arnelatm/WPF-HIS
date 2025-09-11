Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDistributionSchemeItemsView
        Inherits IView

        Property DistributionSchemeItems As IList(Of DistributionSchemeItemModel)

    End Interface

End Namespace