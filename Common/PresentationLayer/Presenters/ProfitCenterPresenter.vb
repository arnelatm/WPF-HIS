Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ProfitCenterPresenter
        Inherits CommonPresenter(Of IProfitCenterView, ProfitCenterModel)

        Public ParentViewList As List(Of ProfitCenterModel)

        Public Sub New(view As IProfitCenterView)
            MyBase.New(view)
            ModelPresenter = New ModelCommon("ProfitCenter")
            TableName = "ProfitCenter_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "ProfitCenterName"
            TreeViewSecondaryField = "ProfitCenterCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New ProfitCenterModel()
            DataModel = New ProfitCenterModel
            TreeViewList = New List(Of ProfitCenterModel)
            ParentViewList = New List(Of ProfitCenterModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub


        Public Function GetLastSortKey(ByVal searchValue As String) As String
            Return Model.GetLastSortKey(searchValue, TableName)
        End Function

    End Class

End Namespace