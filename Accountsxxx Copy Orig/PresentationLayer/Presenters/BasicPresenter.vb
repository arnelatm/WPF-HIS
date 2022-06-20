Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class BasicPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IBasicView, TM)

        Private ReadOnly PresenterView

        Public Sub New(view As IBasicView, tableOrViewName As String)
            MyBase.New(view)
            'Dim presenterModelName = $"AATM.Accounts.PresentationLayer.Models.ModelAccounts"
            TableName = tableOrViewName
            SortOrderKey = "Name"
            Service = New AccountsService("Basic", tableOrViewName)


        End Sub

    End Class

End Namespace