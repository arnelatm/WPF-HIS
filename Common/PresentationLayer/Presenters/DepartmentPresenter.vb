Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class DepartmentPresenter
        Inherits CommonPresenter(Of IDepartmentView, DepartmentModel)

        Public ParentViewList As List(Of DepartmentModel)

        Public Sub New(view As IDepartmentView)
            MyBase.New(view)
            ModelPresenter = New ModelCommon("Department")
            TableName = "Department_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "DepartmentName"
            TreeViewSecondaryField = "DepartmentCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New DepartmentModel()
            DataModel = New DepartmentModel
            TreeViewList = New List(Of DepartmentModel)
            ParentViewList = New List(Of DepartmentModel)
        End Sub

        'Public Function GetDepartmentList(Optional ByVal sortKey As String = "") As List(Of DepartmentModel)
        '    Dim xModel As New DepartmentModel
        '    Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of DepartmentModel)(sortKey, xModel)
        '    Dim modelData = Model.GetAll(Of DepartmentModel)(newSortOrderKey)
        '    If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
        '        TreeViewList.Clear()
        '    End If
        '    For Each modData In modelData
        '        Dim modelTb As New DepartmentModel
        '        MapObject(modData, modelTb)
        '        TreeViewList.Add(modelTb)
        '    Next
        '    Return TreeViewList
        'End Function

        Public Function GetParentList() As List(Of DepartmentModel)
            Dim xModel As New DepartmentModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of DepartmentModel)(SortOrderKey, xModel)
            Dim modelData = Model.GetAll(Of DepartmentModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New DepartmentModel
                GlobalVariables.Mapper.MapObject(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Model.GetRecordFieldWithKey(idNoToSearch, "Department", "ParentIdNo", "DepartmentName")
        End Function

    End Class

End Namespace