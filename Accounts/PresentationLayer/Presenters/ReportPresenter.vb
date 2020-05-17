Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class ReportPresenter
        Inherits AccountsPresenter(Of IView, PettyCashJournalModel)

        Public Sub New(view As IView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PettyCashJournal")
            TableName = "PettyCashJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New PettyCashJournalModel()
            DataModel = New PettyCashJournalModel

        End Sub


    End Class
End Namespace