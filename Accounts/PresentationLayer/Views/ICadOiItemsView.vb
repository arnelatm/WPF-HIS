Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views


    Public Interface ICadOiItemsView
        Inherits IView

        Property CadOiItems As IList(Of CadOiItemModel)

    End Interface
End NameSpace