Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class SalesCashItemsPresenter
        Inherits AccountsPresenter(Of ISalesCashItemsView, SalesCashItemModel)

        Public ParentViewList As List(Of SalesCashItemModel)
        Private ReadOnly _vatRate As Decimal = GetVatPercentage()

        Public Sub New(view As ISalesCashItemsView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("SalesCashItem")
            TableName = "SalesCashItem"
            SortOrderKey = "Sequence"
            DataModel = New SalesCashItemModel
            '_cashCodesModel = GetCashCodesModel()
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace