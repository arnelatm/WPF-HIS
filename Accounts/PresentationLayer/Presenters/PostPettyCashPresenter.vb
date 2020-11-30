Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class PostPettyCashPresenter
        Inherits AccountsPresenter(Of IView, DisbursementJournalModel)

        Public Sub New(view As IView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("DisburementJournal")
            TableName = "DisbursementJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New DisbursementJournalModel()
            DataModel = New DisbursementJournalModel

        End Sub

    End Class

End Namespace