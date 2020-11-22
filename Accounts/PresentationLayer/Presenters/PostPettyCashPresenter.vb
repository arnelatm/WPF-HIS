Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters
    Public Class PostPettyCashPresenter
        Inherits AccountsPresenter(Of IView, PcJournalModel)

        Public Sub New(view As IView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PcJournal")
            TableName = "PcJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New PcJournalModel()
            DataModel = New PcJournalModel

        End Sub

    End Class
End Namespace