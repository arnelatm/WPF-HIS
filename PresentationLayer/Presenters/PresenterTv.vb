Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Public Class PresenterTv(Of T As IViewTv, TM As New)
    Inherits PresenterNew(Of T, TM)
    Implements ISubscriber(Of TreeViewDisplay)

    Public Sub New(itemView As T)
        MyBase.New(itemView)
        Ea.SubscribeEvent(Me)
    End Sub

    Public Sub OnTvEventHandler(ByRef eventType As TreeViewDisplay) Implements ISubscriber(Of TreeViewDisplay).OnEventHandler
        eventType.TreeViewData = GetTreeViewData()
    End Sub

    Public Function GetTreeViewData()
        Dim cModel As New TM
        Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TM)(SortOrderKey, cModel)
        Dim treeMainFieldName = TranslateField(Of TM)(TreeViewMainField, cModel)
        If TreeViewParentIdField Is Nothing OrElse TreeViewParentIdField = "" Then
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                Return Model.GetLookup(TableName, newSortOrderKey, {IdFieldName, treeMainFieldName}, DataFilter)
            Else
                Return Model.GetLookup(TableName, newSortOrderKey, {IdFieldName, treeMainFieldName, TreeViewSecondaryField}, DataFilter)
            End If
        Else
            newSortOrderKey = "SortKey"
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                Return Model.GetHRecords(TableName, newSortOrderKey, {IdFieldName, treeMainFieldName, TreeViewParentIdField})
            Else
                Return Model.GetHRecords(TableName, newSortOrderKey, {IdFieldName, treeMainFieldName, TreeViewParentIdField, TreeViewSecondaryField})
            End If
        End If
    End Function

End Class

Public Class TreeViewDisplay

    Public Sub New(ByVal treeViewData As Object)
        Me.TreeViewData = treeViewData
    End Sub

    Public Property TreeViewData As Object

End Class