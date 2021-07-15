Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer

Namespace PresentationLayer.Presenters

    Public Class RevCostCenterPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IRevCostCenterView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(itemView As IRevCostCenterView)
            MyBase.New(itemView)
            Service = New ServiceCommon("RevCostCenter")
            TableName = "RevCostCenter_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "RevCostCenterName"
            TreeViewSecondaryField = "RevCostCenterCode"
            ParentFieldName = "ParentIdNo"
            ParentViewList = New List(Of TM)
        End Sub

    End Class

End Namespace