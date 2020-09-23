Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ISalesCashItemsView
        Inherits IView

        Property SalesCashItems As IList(Of SalesCashItemModel)

    End Interface

End Namespace