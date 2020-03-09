Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ProfitCenterPresenter
        Inherits CommonPresenter(Of IProfitCenterView, ProfitCenterModel)

        Public ParentViewList As List(Of ProfitCenterModel)

        Public Sub New(view As IProfitCenterView)
            MyBase.New(view)
            ModelPresenter = New ModelProfitCenter
            TableName = "ProfitCenter_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "ProfitCenterName"
            TreeViewSecondaryField = "ProfitCenterCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New ProfitCenterModel()
            DataBizObject = New ProfitCenter
            DataModel = New ProfitCenterModel
            TreeViewList = New List(Of ProfitCenterModel)
            ParentViewList = New List(Of ProfitCenterModel)
        End Sub

        Public Function GetParentList() As List(Of ProfitCenterModel)
            Dim xModel As New ProfitCenterModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of ProfitCenterModel)(SortOrderKey, xModel)
            Dim modelData = Model.GetAll(Of ProfitCenterModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New ProfitCenterModel
                GlobalVariables.Mapper.MapObject(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

        'Public Function GetProfitCenterList(Optional ByVal sortKey As String = "") As List(Of ProfitCenterModel)
        '    Dim xModel As New ProfitCenterModel
        '    Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of ProfitCenterModel)(sortKey, xModel)
        '    Dim modelData = Model.GetAll(Of ProfitCenterModel)(newSortOrderKey)
        '    If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
        '        TreeViewList.Clear()
        '    End If
        '    For Each modData In modelData
        '        Dim modelTb As New ProfitCenterModel
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