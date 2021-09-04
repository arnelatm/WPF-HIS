Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services

Public Class DefaultFieldValuePresenter(Of TM As New)
    Inherits Presenter(Of IDefaultFieldValueView, TM)

    Public Sub New(view As IDefaultFieldValueView)
        MyBase.New(view)
        Service = New Service("DefaultFieldValue")
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