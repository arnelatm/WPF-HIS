Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views


    Public Interface ICsrOiItemsView
        Inherits IView

        Property CsrOiItems As IList(Of CsrOiItemModel)

    End Interface
End NameSpace