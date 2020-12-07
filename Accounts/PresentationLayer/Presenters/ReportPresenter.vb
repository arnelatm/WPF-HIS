Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class ReportPresenter
        Inherits AccountsPresenter(Of IView, AccountModel)

        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Account"
            ModelPresenter = New ModelAccounts("Account")
            TableName = "Account"
            SortOrderKey = "IdNo"
            OriginalModel = New AccountModel()
            DataModel = New AccountModel()

        End Sub

    End Class

End Namespace