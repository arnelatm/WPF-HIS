Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class RevCostCenterPresenter
        Inherits CommonPresenter(Of IRevCostCenterView, RevCostCenterModel)

        Public ParentViewList As List(Of RevCostCenterModel)

        Public Sub New(view As IRevCostCenterView)
            MyBase.New(view)
            ModelOfPresenter = New ModelCommon("RevCostCenter")
            TableName = "RevCostCenter_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "RevCostCenterName"
            TreeViewSecondaryField = "RevCostCenterCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New RevCostCenterModel()
            DataModel = New RevCostCenterModel
            TreeViewList = New List(Of RevCostCenterModel)
            ParentViewList = New List(Of RevCostCenterModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace