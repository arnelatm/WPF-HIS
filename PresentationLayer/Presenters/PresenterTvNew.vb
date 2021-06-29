Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Public Class PresenterTvNew(Of T As IView, TM As New)
    Implements ISubscriber(Of EntryFormLoaded),
               ISubscriber(Of LanguageChanged)

    Protected TreeViewList
    Protected TreeViewMainField As String
    Protected TreeViewParentIdField As String
    Protected TreeViewSecondaryField As String
    Protected ParentFieldName As String = ""
    Protected WithEvents FormTreeView As TreeView
    Protected NodeToDelete As TreeNode
    Protected Property View As T
    Protected TableName As String
    Private _parentPresenter
    Private _sortOrderKey As String
    Private _idFieldName As String
    Private _targetIdNo As Integer
    Private _model As IModel
    Private _dataFilter As String
    Private _recordPositionNumber As Integer

    'Private _bypassSelectedChange As Boolean = False

    Public Sub New(parentPresenter)
        _parentPresenter = parentPresenter
        Me.View = parentPresenter.View
        If _parentPresenter.View IsNot Nothing Then
            FormTreeView = CallByName(View, "FormTreeView", CallType.Get)
        End If
        Me.TableName = _parentPresenter.TableName
        _model = parentPresenter.Model
        _sortOrderKey = parentPresenter.SortOrderKey
        _idFieldName = parentPresenter.idFieldName
        _targetIdNo = parentPresenter.TargetIdNo
        _dataFilter = parentPresenter.DataFilter
    End Sub

    Public Sub OnTvEntryFormLoaded_EventHandler(ByRef eventType As EntryFormLoaded) Implements ISubscriber(Of EntryFormLoaded).OnEventHandler
        DisplayTree()
    End Sub

    Protected Sub DisplayTree()
        Dim root As TreeNode = FormTreeView.Nodes(0)
        root.Nodes.Clear()
        root.Text = MessagingLibrary.Messaging.TranslateCaption(TableName)
        ' create the tree
        If GlobalVariables.RightToLeftLayout Then
            FormTreeView.RightToLeft = RightToLeft.Yes
            FormTreeView.RightToLeftLayout = True
        Else
            FormTreeView.RightToLeft = RightToLeft.No
            FormTreeView.RightToLeftLayout = False
        End If
        Dim treeViewData As New Object
        treeViewData = GetTreeViewData()
        If ParentFieldName Is Nothing OrElse ParentFieldName = "" Then
            For Each dataNode In treeViewData
                AddRecordToTree(dataNode)
            Next
        Else
            For Each dataNode In treeViewData
                AddRecordToTreeHierarchical(dataNode, True, FormTreeView)
            Next
        End If
        FormTreeView.ExpandAll()
        GotoRecordInTreeView()
    End Sub

    Public Function GetTreeViewData()
        Dim cModel As New TM
        Dim newSortOrderKey As String = _parentPresenter.GetTranslatedSortOrderKey(Of TM)(_sortOrderKey, cModel)
        Dim treeMainFieldName = _parentPresenter.TranslateField(Of TM)(TreeViewMainField, cModel)
        If TreeViewParentIdField Is Nothing OrElse TreeViewParentIdField = "" Then
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                Return _model.GetLookup(TableName, newSortOrderKey, {_idFieldName, treeMainFieldName}, _dataFilter)
            Else
                Return _model.GetLookup(TableName, newSortOrderKey, {_idFieldName, treeMainFieldName, TreeViewSecondaryField}, _dataFilter)
            End If
        Else
            newSortOrderKey = "SortKey"
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                Return _model.GetHRecords(TableName, newSortOrderKey, {_idFieldName, treeMainFieldName, TreeViewParentIdField})
            Else
                Return _model.GetHRecords(TableName, newSortOrderKey, {_idFieldName, treeMainFieldName, TreeViewParentIdField, TreeViewSecondaryField})
            End If
        End If
    End Function

    Protected Overloads Sub AddRecordToTreeHierarchical(dataNode As Object, parentChanged As Boolean, treeViewTableName As TreeView)
        'Dim parentFieldName As String = CallByName(View, "ParentFieldName", CallType.Get)
        Dim parentIdValue As Integer? = GetPropertyValue(dataNode, ParentFieldName)
        If parentIdValue Is Nothing OrElse parentIdValue = 0 Then
            AddRecordToTree(dataNode) ', "Name")
        Else
            Dim idNo As Int32 = GetPropertyValue(dataNode, "IdNo")
            Dim mainValue As String = GetPropertyValue(dataNode, "Name")
            Dim secondaryValue As String = GetPropertyValue(dataNode, "Code")
            Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
            If parentIdValue Is Nothing OrElse parentIdValue = 0 Then
                If parentChanged Then
                    treeViewTableName.Nodes(treeViewTableName.Nodes.Count - 1).Nodes.Add(treeNode)
                Else
                    treeViewTableName.Nodes(0).Nodes.Add(treeNode)
                End If
            Else
                If parentChanged Then
                    Dim foundNode As TreeNode() = treeViewTableName.Nodes.Find(parentIdValue.ToString(), True)
                    If foundNode.Length <> 0 Then
                        foundNode(0).Nodes.Add(treeNode)
                    End If
                End If
            End If
        End If
    End Sub

    Protected Overloads Sub AddRecordToTree(dataNode As Object) ', mainFieldName As String)
        Dim idNo As Int32 = GetPropertyValue(dataNode, _idFieldName)
        Dim mainValue As String = GetPropertyValue(dataNode, "Name")
        Dim secondaryValue As String = GetPropertyValue(dataNode, "Code")
        Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
        FormTreeView.Nodes(0).Nodes.Add(treeNode)
    End Sub

    Protected Function MakeTreeNode(mainFieldValue As String, secondaryFieldValue As String, idNo As Int32) _
        As TreeNode
        Dim treeTextDisplay As String
        treeTextDisplay = TreeNodeTextDisplay(mainFieldValue, secondaryFieldValue)
        Return New TreeNode With {
            .Text = treeTextDisplay,
            .Tag = idNo,
            .Name = idNo
            }
    End Function

    Protected Overridable Function TreeNodeTextDisplay(tvName As String, ByVal Optional tvAdditionalText As String = "") _
        As String
        Return tvName.Trim() + If(String.IsNullOrEmpty(tvAdditionalText), "", " (" + tvAdditionalText.ToString().Trim() + ")")
    End Function

    Private Sub GotoRecordInTreeView()
        Dim found As TreeNode() = FormTreeView.Nodes.Find(_targetIdNo, True)
        If found.Length <> 0 Then
            With FormTreeView
                .SelectedNode = found(0)
                .HideSelection = False
                .Select()
            End With
        End If
        If FormTreeView.SelectedNode IsNot Nothing AndAlso FormTreeView.SelectedNode.IsVisible Then
            FormTreeView.SelectedNode.EnsureVisible()
        End If
    End Sub

    Public Function GetTreeNodeText()
        Dim cModel As New TM
        Dim cText As String
        Dim treeMainFieldName = _parentPresenter.TranslateField(Of TM)(TreeViewMainField, cModel)
        If String.IsNullOrEmpty(TreeViewSecondaryField) Then
            cText = CallByName(View, treeMainFieldName, CallType.Get).Trim() + " | " + CType(CallByName(View, _idFieldName, CallType.Get), String).Trim()
        Else
            Dim addText = CallByName(View, TreeViewSecondaryField, CallType.Get)
            cText = CallByName(View, treeMainFieldName, CallType.Get).Trim() + " | " + CType(CallByName(View, _idFieldName, CallType.Get), String).Trim() +
                    If(String.IsNullOrEmpty(addText), "", " (" + addText.ToString().Trim() + ")")
        End If
        Return cText
    End Function

    Public Sub UpdateViewDisplay(idNo As Int32)
        GotoRecordInTreeView()
    End Sub

    Protected Sub BfTvEntry_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles FormTreeView.AfterSelect
        Select Case e.Action
            Case TreeViewAction.ByKeyboard
                    'MessageBox.Show("You like the keyboard!")

            Case TreeViewAction.ByMouse
                'MessageBox.Show("You like the mouse!")
            Case Else
                ' A problem here is causing a windows handle error when executing the below code.
                ' Therefore since this is just a selection change during initialization no need
                ' to execute the codes below so just exit the sub. This will also make initialization
                ' faster because no more need to move the database anyway at initialization the
                ' first record will be the one to be shown.
                Exit Sub
        End Select
        Dim nTag As Integer
        FormTreeView.ImageIndex = 1
        If FormTreeView.SelectedNode.Tag Is Nothing Then
            _recordPositionNumber = 1
        Else
            nTag = FormTreeView.SelectedNode.Tag
            Dim x = _parentPresenter.GetSortedRecordPosition(nTag)
            _recordPositionNumber = x
        End If
        If Not FormTreeView.SelectedNode.IsVisible Then
            FormTreeView.SelectedNode.EnsureVisible()
        End If
    End Sub

    Private Sub FormTreeViewBeforeSelect(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs) Handles FormTreeView.BeforeSelect
        If _parentPresenter.EditMode Or _parentPresenter.AddMode Then
            e.Cancel = True
        End If
    End Sub

    Public Sub OnBeforeDelete() Handles MyBase.BeforeDelete
        NodeToDelete = FormTreeView.SelectedNode()
    End Sub

    Public Sub OnAfterDelete(retVal As Integer) Handles MyBase.AfterDelete
        If retVal > 0 Then
            FormTreeView.Nodes.Remove(NodeToDelete)
        End If
    End Sub

    Private Sub OnAfterSave() Handles MyBase.AfterSave
        DisplayTree()
    End Sub

    Public Sub OnLanguageChangedEventHandler(ByRef eventType As LanguageChanged) Implements ISubscriber(Of LanguageChanged).OnEventHandler
        DisplayTree()
    End Sub

End Class