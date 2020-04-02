Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Public Class SecurityObjectPresenter
    Inherits Presenter(Of ISecurityObjectView, SecurityObjectModel)

    Public Sub New(view As ISecurityObjectView)
        MyBase.New(view)
        ModelPresenter = New ModelSecurityObject
        TableName = "SecurityObject_View"
        SortOrderKey = "SecurityObjectName"
        TreeViewMainField = "SecurityObjectName"
	TreeViewSecondaryField = "IdNo"
        TreeViewParentIdField = "ParentIdNo"
        OriginalModel = New SecurityObjectModel()
        DataModel = New SecurityObjectModel
        TreeViewList = New List(Of SecurityObjectModel)
    End Sub

    
     
        Public Function GetParentList() As List(Of SecurityObjectModel)
            Dim xModel As New SecurityObjectModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of SecurityObjectModel)(SortOrderKey, xModel)
            Dim modelData = Model.GetAll(Of SecurityObjectModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New SecurityObjectModel
                GlobalVariables.Mapper.Map(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

End Class