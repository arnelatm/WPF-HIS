Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class StockInventoryPresenter(Of TM As New)
        Inherits CommonPresenter(Of IStockInventoryView, TM)

        Public Sub New(itemView As IStockInventoryView)
            MyBase.New(itemView)
            Service = New AccountsService("StockInventory")
            TableName = "StockInventory_View"
            SortOrderKey = "ItemNameEnglish"
            WithTreeView = False
            AddHandler View.FinderValueChanged, AddressOf OnFinderValueChanged

        End Sub

        Public Sub OnFinderValueChanged(idNo As Int16)
            If idNo <> 0 Then
                RecordPositionNumber = GetSortedRecordPosition(idNo)
            End If
        End Sub

    End Class

End Namespace