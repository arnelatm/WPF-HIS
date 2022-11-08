Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class DrugSalePresenter(Of TM As New)
        Inherits CommonPresenter(Of IDrugSaleView, TM)

        Public Sub New(itemView As IDrugSaleView)
            MyBase.New(itemView)
            Service = New AccountsService("DrugSale")
            TableName = "DrugSale_View"
            SortOrderKey = "IdNo"
            WithTreeView = False
            AddHandler View.FinderValueChanged, AddressOf OnFinderValueChanged
            AddHandler View.GetDrugName, AddressOf OnGetDrugName
        End Sub

        Public Sub OnFinderValueChanged(idNo As Int16)
            If idNo <> 0 Then
                RecordPositionNumber = GetSortedRecordPosition(idNo)
            End If
        End Sub

        Public Sub OnGetDrugName()
            View.ItemNameEnglish = Service.GetField(View.GTin, "DrugList", "GTIN", "[Trade Name]")
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.SaleDate = Today()
            View.QrCode = ""
        End Sub

    End Class

End Namespace