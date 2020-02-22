Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters


    Public Class BankPresenter
        Inherits AccountsPresenter(Of IBankView, Bank, BankModel)

        Public ParentViewList As List(Of BankModel)

        Public Sub New(view As IBankView)
            MyBase.New(view)
            TableName = "Bank"
            SortOrderKey = "BankName"
            TreeViewMainField = "BankName"
            TreeViewSecondaryField = "BankCode"
            OriginalModel = New BankModel()
            BizObject = New Bank
            DataModel = New BankModel
            'DbDataDao = New BankDao
            TreeViewList = New List(Of BankModel)
            ParentViewList = New List(Of BankModel)
            'Model.SetService(New BankService)
        End Sub

    End Class
End NameSpace