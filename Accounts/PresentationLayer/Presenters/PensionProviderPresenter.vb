Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class PensionProviderPresenter(Of TM As New)
        Inherits PresenterNew(Of IPensionProviderView, TM)

        Public Sub New(view As IPensionProviderView)
            MyBase.New(view)
            Service = New AccountsService("PensionProvider")
            TableName = "PensionProvider"
            TreeViewMainField = "PensionProviderName"
            TreeViewSecondaryField = "PensionProviderCode"
            SortOrderKey = "PensionProviderName"
        End Sub

    End Class

End Namespace