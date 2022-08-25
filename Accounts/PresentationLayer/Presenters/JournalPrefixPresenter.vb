Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class JournalPrefixPresenter(Of TM As New)
        Inherits CommonPresenter(Of IJournalPrefixView, TM)

        Public Sub New(view As IJournalPrefixView)
            MyBase.New(view)
            Service = New AccountsService("JournalPrefix")
            TableName = "JournalPrefix"
            TreeViewMainField = "JournalName"
            'TreeViewSecondaryField = "JournalCode"
            SortOrderKey = "IdNo"
            'QuitOnSave = False
        End Sub

    End Class

End Namespace