Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPcJournalsView
        Inherits IView

        Property PcJournals As IList(Of PcJournalModel)

    End Interface

End Namespace