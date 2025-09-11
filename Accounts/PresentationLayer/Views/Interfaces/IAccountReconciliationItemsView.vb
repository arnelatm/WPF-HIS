Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IAccountReconciliationItemsView
        Inherits IView

        Property AccountReconciliationItems As IList(Of AccountReconciliationItemModel)

    End Interface

End Namespace