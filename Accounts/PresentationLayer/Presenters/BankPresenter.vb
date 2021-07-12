Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.PresentationLayer.Presenters
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

    Public Class BankPresenter
        Inherits PresenterNew(Of IBankView, BankModel)

        Public Sub New(view As IBankView)
            MyBase.New(view)
            If view IsNot Nothing Then
                Service = New ServiceAccounts("Bank")
                'ModelOfPresenter = New ModelAccounts("Bank")
                TableName = "Bank"
                TreeViewMainField = "BankName"
                TreeViewSecondaryField = "BankCode"
                SortOrderKey = "BankName"
                OriginalModel = New BankModel()
                DataModel = New BankModel()
            End If
        End Sub

    End Class

End Namespace