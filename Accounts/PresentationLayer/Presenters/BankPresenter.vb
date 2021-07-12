Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

    Public Class BankPresenter(Of TM As New)
        Inherits PresenterNew(Of IBankView, TM)

        Public Sub New(itemView As IBankView)
            MyBase.New(itemView)
            If itemView IsNot Nothing Then
                Service = New ServiceAccounts("Bank")
                'ModelOfPresenter = New ModelAccounts("Bank")
                TableName = "Bank"
                TreeViewMainField = "BankName"
                TreeViewSecondaryField = "BankCode"
                SortOrderKey = "BankName"
            End If
        End Sub

    End Class

End Namespace