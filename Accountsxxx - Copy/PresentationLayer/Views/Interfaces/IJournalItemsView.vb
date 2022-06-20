Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IJournalItemsView
        Inherits IView

        Property JournalItems As IList(Of JournalItemModel)

    End Interface

End Namespace