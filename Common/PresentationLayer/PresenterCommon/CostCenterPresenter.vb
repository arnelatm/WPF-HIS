Imports AATM.HIS.Common.BusinessLayer
Imports AATM.HIS.Common.DataLayer.AdoNet
Imports AATM.HIS.Common.PresentationLayer.Models
Imports AATM.HIS.Common.PresentationLayer.Views
Imports AATM.HIS.Common.ServiceLayer.ActionService

Namespace PresentationLayer.Presenters

    Public Class CostCenterPresenter
        Inherits CommonPresenterOld(Of ICostCenterView, CostCenter, CostCenterModel)

        Public ParentViewList As List(Of CostCenterModel)

        Public Sub New(view As ICostCenterView)
            MyBase.New(view)
            TableName = "CostCenter_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "CostCenterName"
            TreeViewSecondaryField = "CostCenterCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New CostCenterModel()
            BizObject = New CostCenter
            DataModel = New CostCenterModel
            DbDataDao = New CostCenterDao
            TreeViewList = New List(Of CostCenterModel)
            ParentViewList = New List(Of CostCenterModel)
            Model.SetService(New CostCenterService)
        End Sub

        'Public Function GetCostCenterList(Optional ByVal sortKey As String = "") As List(Of CostCenterModel)
        '    Dim xModel As New CostCenterModel
        '    Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of CostCenterModel)(sortKey, xModel)
        '    Dim modelData = Model.GetAll(Of CostCenterModel)(newSortOrderKey)
        '    If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
        '        TreeViewList.Clear()
        '    End If
        '    For Each modData In modelData
        '        Dim modelTb As New CostCenterModel
        '        MapObject(modData, modelTb)
        '        TreeViewList.Add(modelTb)
        '    Next
        '    Return TreeViewList
        'End Function

        Public Function GetParentList() As List(Of CostCenterModel)
            Dim xModel As New CostCenterModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of CostCenterModel)(SortOrderKey, xModel)
            Dim modelData = Model.GetAll(Of CostCenterModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New CostCenterModel
                MapObject(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

    End Class

End Namespace