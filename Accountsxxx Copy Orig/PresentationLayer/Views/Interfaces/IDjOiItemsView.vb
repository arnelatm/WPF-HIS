Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDjOiItemsView
        Inherits IView

        Property DjOiItems As IList(Of DjOiItemModel)

    End Interface

End Namespace