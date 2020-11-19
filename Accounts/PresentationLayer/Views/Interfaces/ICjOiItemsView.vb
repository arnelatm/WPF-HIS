Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ICjOiItemsView
        Inherits IView

        Property CjOiItems As IList(Of CjOiItemModel)

    End Interface

End Namespace