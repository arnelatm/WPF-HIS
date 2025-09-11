Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ICsrOiItemsView
        Inherits IView

        Property CsrOiItems As IList(Of CsrOiItemModel)

    End Interface

End Namespace