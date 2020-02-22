Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.ServiceLayer.ActionServices

Namespace PresentationLayer.Presenters

    Public Class ProfitCenterPresenter
        Inherits CommonPresenterOld(Of IProfitCenterView, ProfitCenter, ProfitCenterModel)

        Public ParentViewList As List(Of ProfitCenterModel)

        Public Sub New(view As IProfitCenterView)
            MyBase.New(view)
            TableName = "ProfitCenter_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "ProfitCenterName"
            TreeViewSecondaryField = "ProfitCenterCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New ProfitCenterModel()
            BizObject = New ProfitCenter
            DataModel = New ProfitCenterModel
            DbDataDao = New ProfitCenterDao
            TreeViewList = New List(Of ProfitCenterModel)
            ParentViewList = New List(Of ProfitCenterModel)
            Model.SetService(New ProfitCenterService)
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
                MapObject(modData, modelTb)
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