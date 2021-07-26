Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class DepositTypePresenter(Of TM As New)
        Inherits PresenterNew(Of IDepositTypeView, TM)

        Public Sub New(view As IDepositTypeView)
            MyBase.New(view)
            Service = New AccountsService("DepositType")
            TableName = "DepositType"
            TreeViewMainField = "DepositTypeName"
            TreeViewSecondaryField = "DepositTypeCode"
            SortOrderKey = "DepositTypeName"
        End Sub

        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not View.WithBankCharges Then
                View.Rate = 0
                View.BankChargesAccountIdNo = Nothing
                View.BankChargesVatAccountIdNo = Nothing
            End If
        End Sub

    End Class

End Namespace