Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class BankPresenter(Of TM As New)
        Inherits PresenterNew(Of IBankView, TM)

        Public Sub New(itemView As IBankView)
            MyBase.New(itemView)
            Service = New AccountsService("Bank")
            TableName = "Bank"
            TreeViewMainField = "BankName"
            TreeViewSecondaryField = "BankCode"
            SortOrderKey = "BankName"
        End Sub

    End Class

End Namespace