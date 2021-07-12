Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class JournalPrefixPresenter
        Inherits PresenterNew(Of IJournalPrefixView, JournalPrefixModel)

        Public Sub New(view As IJournalPrefixView)
            MyBase.New(view)
            Service = New ServiceAccounts("JournalPrefix")
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