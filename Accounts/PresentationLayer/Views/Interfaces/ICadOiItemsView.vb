Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ICadOiItemsView
        Inherits IView

        Property CadOiItems As IList(Of CadOiItemModel)

    End Interface

End Namespace