Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ICkJournalView
        Inherits IDisbursementJournalView

        Property CheckDate As Date?
        Property CheckNumber As String

    End Interface

End Namespace