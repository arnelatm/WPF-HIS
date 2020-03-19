Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IPcsOiItemsView
        Inherits IView

        Property PcsOiItems As IList(Of PcsOiItemModel)

    End Interface

End Namespace