Imports AATM.HIS.Common.BusinessLayer
Imports AATM.HIS.Common.DataLayer.AdoNet
Imports AATM.HIS.Common.PresentationLayer.Models
Imports AATM.HIS.Common.PresentationLayer.Views
Imports AATM.HIS.Common.ServiceLayer.ActionService

Namespace PresentationLayer.Presenters

    Public Class DepartmentPresenter
        Inherits CommonPresenterOld(Of IDepartmentView, Department, DepartmentModel)

        Public ParentViewList As List(Of DepartmentModel)

        Public Sub New(view As IDepartmentView)
            MyBase.New(view)
            TableName = "Department_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "DepartmentName"
            TreeViewSecondaryField = "DepartmentCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New DepartmentModel()
            BizObject = New Department
            DataModel = New DepartmentModel
            DbDataDao = New DepartmentDao
            TreeViewList = New List(Of DepartmentModel)
            ParentViewList = New List(Of DepartmentModel)
            Model.SetService(New DepartmentService)
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
                MapObject(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Model.GetRecordFieldWithKey(idNoToSearch, "Department", "ParentIdNo", "DepartmentName")
        End Function

    End Class

End Namespace