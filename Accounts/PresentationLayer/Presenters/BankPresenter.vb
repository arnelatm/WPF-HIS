Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class BankPresenter
        Inherits AccountsPresenter(Of IBankView, BankModel)

        Public ParentViewList As List(Of BankModel)

        Public Sub New(view As IBankView)
            MyBase.New(view)
            TableName = "Bank"
            SortOrderKey = "BankName"
            TreeViewMainField = "BankName"
            TreeViewSecondaryField = "BankCode"
            OriginalModel = New BankModel()
            DataModel = New BankModel
            TreeViewList = New List(Of BankModel)
            ParentViewList = New List(Of BankModel)
        End Sub

    End Class

End Namespace