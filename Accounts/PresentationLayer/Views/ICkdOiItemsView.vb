Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ICkdOiItemsView
        Inherits IView

        Property CkdOiItems As IList(Of CkdOiItemModel)

    End Interface
End NameSpace