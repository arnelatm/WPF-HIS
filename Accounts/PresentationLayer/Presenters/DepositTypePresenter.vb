Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class DepositTypePresenter
        Inherits AccountsPresenter(Of IDepositTypeView, DepositTypeModel)

        Public Sub New(view As IDepositTypeView)
            MyBase.New(view)
            InitializerWithTv("DepositType")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not View.WithBankCharges Then
                View.Rate = 0
                View.BankChargesAccountIdNo = Nothing
                View.BankChargesVatAccountIdNo = Nothing
            End If
        End Sub

    End Class

    Public Class DepositTypePresenterNew
        Inherits PresenterNew(Of IDepositTypeView, DepositTypeModel)

        Public Sub New(view As IView)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("DepositType")
            TableName = "SalaryLoanSchedule"
            SortOrderKey = "IdNo"
            OriginalModel = New DepositTypeModel()
            DataModel = New DepositTypeModel()
            QuitOnSave = False
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