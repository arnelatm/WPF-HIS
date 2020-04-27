Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class CostCenterPresenter
        Inherits CommonPresenter(Of ICostCenterView, CostCenterModel)

        Public ParentViewList As List(Of CostCenterModel)

        Public Sub New(view As ICostCenterView)
            MyBase.New(view)
            ModelPresenter = New ModelCommon("CostCenter")
            TableName = "CostCenter_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "CostCenterName"
            TreeViewSecondaryField = "CostCenterCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New CostCenterModel()
            DataModel = New CostCenterModel
            TreeViewList = New List(Of CostCenterModel)
            ParentViewList = New List(Of CostCenterModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace