Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Forms

Namespace PresentationLayer.Views.Forms

    Public Class PcDisbursementJournalEntry
        Inherits DisbursementJournalEntry

        Public Sub New()
            MyBase.New()

            MainTableName = "PcJournal"
            PresenterObj = New PcJournalPresenter(Me)

        End Sub

    End Class

End Namespace