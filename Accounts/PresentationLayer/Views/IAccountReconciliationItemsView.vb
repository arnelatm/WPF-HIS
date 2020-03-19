Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IAccountReconciliationItemsView
        Inherits IView

        Property AccountReconciliationItems As IList(Of AccountReconciliationItemModel)

    End Interface

End Namespace