Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPcsOiItemsView
        Inherits IView

        Property PcsOiItems As IList(Of PcsOiItemModel)

    End Interface

End Namespace