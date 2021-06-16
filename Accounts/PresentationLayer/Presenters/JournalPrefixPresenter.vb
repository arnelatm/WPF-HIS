Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class JournalPrefixPresenter
        Inherits PresenterTv(Of IJournalPrefixView, JournalPrefixModel)

        Public Sub New(view As IJournalPrefixView)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("JournalPrefix")
            TableName = "JournalPrefix"
            TreeViewMainField = "JournalName"
            TreeViewSecondaryField = "JournalCode"
            SortOrderKey = "IdNo"
            OriginalModel = New JournalPrefixModel()
            DataModel = New JournalPrefixModel()
            QuitOnSave = False
        End Sub

    End Class

End Namespace