Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class RevenueGroupPresenter
        Inherits CommonPresenter(Of IRevenueGroupView, RevenueGroupModel)

        Public ParentViewList As List(Of RevenueGroupModel)

        Public Sub New(view As IRevenueGroupView)
            MyBase.New(view)
            ModelPresenter = New ModelCommon("RevenueGroup")
            TableName = "RevenueGroup_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "RevenueGroupName"
            TreeViewSecondaryField = "RevenueGroupCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New RevenueGroupModel()
            DataModel = New RevenueGroupModel
            TreeViewList = New List(Of RevenueGroupModel)
            ParentViewList = New List(Of RevenueGroupModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Function GetLastSortKey(ByVal searchValue As String) As String
            Return Model.GetLastSortKey(searchValue, TableName)
        End Function

    End Class

End Namespace