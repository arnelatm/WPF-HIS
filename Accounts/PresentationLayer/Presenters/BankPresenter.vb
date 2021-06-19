Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class BankPresenter
        Inherits PresenterTv(Of IBankView, BankModel)

        Public Sub New(view As IBankView)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("Bank")
            TableName = "Bank"
            TreeViewMainField = "BankName"
            TreeViewSecondaryField = "BankCode"
            SortOrderKey = "IdNo"
            OriginalModel = New BankModel()
            DataModel = New BankModel()

        End Sub

    End Class

End Namespace