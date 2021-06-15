Imports AATM.Accounts.Interfaces
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class JournalPrefixPresenter
        Inherits PresenterNew(Of IJournalPrefixView, JournalPrefixModel)

        Public Sub New(view As IJournalPrefixView)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("JournalPrefix")
            TableName = "JournalPrefix"
            SortOrderKey = "IdNo"
            OriginalModel = New JournalPrefixModel()
            DataModel = New JournalPrefixModel()
            QuitOnSave = False
        End Sub

    End Class

End Namespace