Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class RevenueGroupPresenter
        Inherits CommonPresenter(Of IRevenueGroupView, RevenueGroupModel)

        Public ParentViewList As List(Of RevenueGroupModel)

        Public Sub New(view As IRevenueGroupView)
            MyBase.New(view)
            TableName = "RevenueGroup_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "RevenueGroupName"
            TreeViewSecondaryField = "RevenueGroupCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New RevenueGroupModel()
            DataBizObject = New RevenueGroup
            DataModel = New RevenueGroupModel
            'DbDataDao = New RevenueGroupDao
            TreeViewList = New List(Of RevenueGroupModel)
            ParentViewList = New List(Of RevenueGroupModel)
            'Model.SetService(New RevenueGroupService)
        End Sub

        Public Function GetParentList() As List(Of RevenueGroupModel)
            Dim xModel As New RevenueGroupModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of RevenueGroupModel)(SortOrderKey, xModel)
            Dim modelData = Model.GetAll(Of RevenueGroupModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New RevenueGroupModel
                GlobalVariables.Mapper.MapObject(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

        'Public Function GetRevenueGroupList(Optional ByVal sortKey As String = "") As List(Of RevenueGroupModel)
        '    Dim xModel As New RevenueGroupModel
        '    Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of RevenueGroupModel)(sortKey, xModel)
        '    Dim modelData = Model.GetAll(Of RevenueGroupModel)(newSortOrderKey)
        '    If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
        '        TreeViewList.Clear()
        '    End If
        '    For Each modData In modelData
        '        Dim modelTb As New RevenueGroupModel
        '        MapObject(modData, modelTb)
        '        TreeViewList.Add(modelTb)
        '    Next
        '    Return TreeViewList
        'End Function

        Public Function GetLastSortKey(ByVal searchValue As String) As String
            Return Model.GetLastSortKey(searchValue, TableName)
        End Function

    End Class

End Namespace