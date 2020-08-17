Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Public Class CFormEntryTv

    Private _bypassSelectedChange As Boolean = False
    Protected TvMainFieldName As String
    Protected TvSecondaryFieldName As String
    Protected TvSortKey As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' GlobalVariables.EventAggregator.SubscribeEvent(Me)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub BfTvEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            TreeViewTableName.Nodes(0).Text = MainTableName
            TreeViewTableName.ExpandAll()
            DisplayTreeViewData()
        End If
    End Sub

    Protected Sub BfTvEntry_AfterSelect(sender As Object, e As TreeViewEventArgs) _
        Handles TreeViewTableName.AfterSelect
        If Not _bypassSelectedChange Then
            Select Case (e.Action)
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
            If Not PresenterObj.OkToMove() Then
                Exit Sub
            End If
            Dim nTag As Integer
            TreeViewTableName.ImageIndex = 1
            If TreeViewTableName.SelectedNode.Tag.ToString = "root" Then
                PresenterObj.RecordPositionNumber = 1
            Else
                nTag = TreeViewTableName.SelectedNode.Tag
                PresenterObj.RecordPositionNumber = PresenterObj.GetSortedRecordPosition(nTag)
            End If
            If Not TreeViewTableName.SelectedNode.IsVisible Then
                TreeViewTableName.SelectedNode.EnsureVisible()
            End If
        End If
    End Sub

    Protected Overrides Sub OnTextDisplayLanguageChanged() Handles Me.TextDisplayLanguageChanged
        MyBase.OnTextDisplayLanguageChanged()
        DisplayTreeViewData()
    End Sub

    Private Sub GotoRecordInTreeView()
        Dim found As TreeNode() = TreeViewTableName.Nodes.Find(PresenterObj.TargetIdNo, True)
        If found.Length <> 0 Then
            With TreeViewTableName
                _bypassSelectedChange = True
                .SelectedNode = found(0)
                _bypassSelectedChange = False
                .HideSelection = False
                .Select()
            End With
        End If
        ' update treeview text if ever name is changed
        'If Not TreeViewTableName.SelectedNode Is Nothing Then
        'TreeViewTableName.SelectedNode.Text = TreeNodeText
        'End If
        If TreeViewTableName.SelectedNode IsNot Nothing AndAlso TreeViewTableName.SelectedNode.IsVisible Then
            TreeViewTableName.SelectedNode.EnsureVisible()
        End If
    End Sub

    Private Sub BfTvEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        _bypassSelectedChange = True
        If GlobalVariables.RightToLeftLayout Then
            RightToLeftLayout = True
            TreeViewTableName.RightToLeftLayout = True
            TreeViewTableName.RightToLeft = RightToLeft.Yes
        Else
            RightToLeftLayout = False
            TreeViewTableName.RightToLeftLayout = False
            TreeViewTableName.RightToLeft = RightToLeft.No
        End If
        TreeViewTableName.ExpandAll()
        _bypassSelectedChange = False
    End Sub

    Protected Overridable Function TreeNodeTextDisplay(tvName As String, ByVal Optional tvAdditionalText As String = "") _
        As String
        Return tvName + If(String.IsNullOrEmpty(tvAdditionalText), "", " (" + tvAdditionalText.ToString() + ")")
    End Function

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

    Protected Sub RemoveCurrentNode(bypassChange As Boolean)
        If bypassChange Then
            _bypassSelectedChange = True
        End If
        TreeViewTableName.Nodes.Remove(TreeViewTableName.SelectedNode)
        _bypassSelectedChange = False
    End Sub


    'Protected Overrides Sub RecordDeleted()
    '    RemoveCurrentNode(True)
    'End Sub

    'Private Sub BfTvEntry_SuccessfulDelete(idNoOfDeletedRecord As Integer) Handles MyBase.SuccessfulDelete

    'End Sub

    ' ReSharper disable once UnusedMember.Local
    Private Function GetMainFieldName(mainFieldName As String) As String
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            If GlobalVariables.RightToLeftLayout Then
                mainFieldName = mainFieldName + "Ara"
            End If
        End If
        Return mainFieldName
    End Function

    'Public Sub OnSuccessfulUpdate() Handles MyBase.SuccessfulUpdate
    '    PresenterObj.RecordPositionNumber = PresenterObj.GetSortedRecordPosition(PresenterObj.TargetIdNo)
    '    'GetAndSetPresenterObj.RecordPositionNumber()
    '    DisplayTreeViewData()
    '    GotoRecordInTreeView()
    'End Sub

    'Public Sub OnSuccessfulAdd() Handles MyBase.SuccessfulAdd
    '    PresenterObj.RecordPositionNumber = PresenterObj.GetSortedRecordPosition(PresenterObj.TargetIdNo)
    '    DisplayTreeViewData()
    '    GotoRecordInTreeView()
    '    'GetAndSetPresenterObj.RecordPositionNumber()
    'End Sub

    'Protected Overrides Sub DisplayView(ByVal idNoOfRecord As Integer)
    '    Debugger.Break()
    '    PresenterObj.UpdateViewDisplay(idNoOfRecord)
    '    GotoRecordInTreeView()
    'End Sub

    Protected Sub DisplayTreeViewData()
        Dim treeViewData = PresenterObj.GetTreeViewDataNew()
        DisplayTree(treeViewData)
        TreeViewTableName.ExpandAll()
        GotoRecordInTreeView()
    End Sub

    Public Sub DisplayTree(ByRef treeViewData As Object)
        Dim root As TreeNode = TreeViewTableName.Nodes(0)
        'Dim displayMainFieldName = GetTranslatedField(TvMainFieldName)
        root.Nodes.Clear()
        ' create the tree
        If GlobalVariables.RightToLeftLayout Then
            TreeViewTableName.RightToLeftLayout = True
        Else
            TreeViewTableName.RightToLeftLayout = False
        End If
        TreeViewTableName.RightToLeft = RightToLeft.Inherit
        If ParentFieldName Is Nothing OrElse ParentFieldName = "" Then
            For Each dataNode In treeViewData
                AddRecordToTree(dataNode)
            Next
        Else
            For Each dataNode In treeViewData
                AddRecordToTreeHierarchical(dataNode, True)
            Next
        End If
    End Sub

    Protected Overloads Sub AddRecordToTree(dataNode As Object) ', mainFieldName As String)
        Dim idNo As Int32 = GetPropertyValue(dataNode, PresenterObj.IdFieldName)
        Dim mainValue As String = GetPropertyValue(dataNode, "Name")
        Dim secondaryValue As String = GetPropertyValue(dataNode, "Code")
        Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
        TreeViewTableName.Nodes(0).Nodes.Add(treeNode)
    End Sub

    Protected Overloads Sub AddRecordToTreeHierarchical(dataNode As Object, parentChanged As Boolean)
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
                    TreeViewTableName.Nodes(TreeViewTableName.Nodes.Count - 1).Nodes.Add(treeNode)
                Else
                    TreeViewTableName.Nodes(0).Nodes.Add(treeNode)
                End If
            Else
                If parentChanged Then
                    Dim foundNode As TreeNode() = TreeViewTableName.Nodes.Find(parentIdValue.ToString(), True)
                    If foundNode.Length <> 0 Then
                        foundNode(0).Nodes.Add(treeNode)
                    End If
                End If
            End If
        End If
    End Sub

    Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
        GotoRecordInTreeView()
    End Sub

    Protected Overrides Sub RecordSaved()
        MyBase.RecordSaved()
        DisplayTreeViewData()
    End Sub

    'Public Sub OeHCfTvSavedRecord(ByRef e As RecordSaved) Implements ISubscriber(Of RecordSaved).OnEventHandler
    '    DisplayTreeViewData()
    'End Sub

    'Public Sub OeHCfTvRecordAdded(ByRef eventType As RecordAdded) Implements ISubscriber(Of RecordAdded).OnEventHandler
    '    DisplayTreeViewData()
    '    GotoRecordInTreeView()
    'End Sub

End Class