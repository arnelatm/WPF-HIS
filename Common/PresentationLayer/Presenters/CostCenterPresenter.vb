Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class CostCenterPresenter
        Inherits CommonPresenter(Of ICostCenterView, CostCenterModel)

        Public ParentViewList As List(Of CostCenterModel)

        Public Sub New(view As ICostCenterView)
            MyBase.New(view)
            ModelPresenter = New ModelCostCenter
            TableName = "CostCenter_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "CostCenterName"
            TreeViewSecondaryField = "CostCenterCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New CostCenterModel()
            DataModel = New CostCenterModel
            TreeViewList = New List(Of CostCenterModel)
            ParentViewList = New List(Of CostCenterModel)
        End Sub

        Public Function GetParentList() As List(Of CostCenterModel)
            Dim xModel As New CostCenterModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of CostCenterModel)(SortOrderKey, xModel)
            Dim modelData = Model.GetAll(Of CostCenterModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New CostCenterModel
                GlobalVariables.Mapper.MapObject(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

    End Class

End Namespace