Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer

Namespace PresentationLayer.Presenters

    Public Class DefaultFieldValuePresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IDefaultFieldValueView, TM)

        Public Sub New(view As IDefaultFieldValueView)
            MyBase.New(view)
            Service = New CommonService("DefaultFieldValue")
            TableName = "DefaultFieldValue"
            SortOrderKey = "ViewName + FieldName"
            TreeViewMainField = "ViewName"
            TreeViewSecondaryField = "FieldName"
        End Sub

        'Public Function GetDefaultFieldValueList(Optional ByVal sortKey As String = "") As List(Of DefaultFieldValueModel)
        '    Dim xModel As New DefaultFieldValueModel
        '    Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of DefaultFieldValueModel)(sortKey, xModel)
        '    Dim modelData = Service.GetAll(Of DefaultFieldValueModel)(newSortOrderKey)
        '    If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
        '        TreeViewList.Clear()
        '    End If
        '    For Each modData In modelData
        '        Dim modelTb As New DefaultFieldValueModel
        '        GlobalVariables.Mapper.Map(modData, modelTb)
        '        TreeViewList.Add(modelTb)
        '    Next
        '    Return TreeViewList
        'End Function

    End Class

End Namespace