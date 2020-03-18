Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IDistributionSchemeItemView
        Inherits IView
        Property DistributionSchemeItems As IList(Of DistributionSchemeItemModel)

    End Interface

End Namespace