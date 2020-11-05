Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class SalesDepositPresenter
        Inherits AccountsPresenter(Of ISalesDepositsView, SalesDepositModel)

        Public ParentViewList As List(Of SalesDepositModel)
        Private ReadOnly _vatRate As Decimal 

        Public Sub New(view As ISalesDepositsView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("SalesDeposit")
            TableName = "SalesDeposit"
            SortOrderKey = "Sequence"
            DataModel = New SalesDepositModel
            '_cashCodesModel = GetCashCodesModel()
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
            _vatRate = GetAppSetting("VATR","VAT","VAT Percentage Rate")/100D
        End Sub

    End Class

End Namespace