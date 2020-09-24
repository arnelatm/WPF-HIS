Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CFormEntryNew
    Inherits CFormEntry

    Protected TvMainFieldName As String
    Protected TvSecondaryFieldName As String
    Protected TvSortKey As String
    Private _bypassSelectedChange As Boolean = False
    Public Property TreeViewObj As New TreeView

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub DisplayTree(ByRef treeViewData As Object)
        Dim root As TreeNode = TreeViewObj.Nodes(0)
        'Dim displayMainFieldName = GetTranslatedField(TvMainFieldName)
        root.Nodes.Clear()
        ' create the tree
        If GlobalVariables.RightToLeftLayout Then
            TreeViewObj.RightToLeftLayout = True
        Else
            TreeViewObj.RightToLeftLayout = False
        End If
        TreeViewObj.RightToLeft = RightToLeft.Inherit
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
        TreeViewObj.Nodes(0).Nodes.Add(treeNode)
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
                    TreeViewObj.Nodes(TreeViewObj.Nodes.Count - 1).Nodes.Add(treeNode)
                Else
                    TreeViewObj.Nodes(0).Nodes.Add(treeNode)
                End If
            Else
                If parentChanged Then
                    Dim foundNode As TreeNode() = TreeViewObj.Nodes.Find(parentIdValue.ToString(), True)
                    If foundNode.Length <> 0 Then
                        foundNode(0).Nodes.Add(treeNode)
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub BfTvEntry_AfterSelect(sender As Object, e As TreeViewEventArgs)

    End Sub

    Protected Sub DisplayTreeViewData()
        Dim treeViewData = PresenterObj.GetTreeViewDataNew()
        DisplayTree(treeViewData)
        TreeViewObj.ExpandAll()
        GotoRecordInTreeView()
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

    Protected Overrides Sub OnTextDisplayLanguageChanged() Handles MyBase.TextDisplayLanguageChanged
        MyBase.OnTextDisplayLanguageChanged()
        DisplayTreeViewData()
    End Sub

    'Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
    '    MyBase.RecordPositionChanged(e)
    '    GotoRecordInTreeView()
    'End Sub

    'Protected Overrides Sub RecordSaved(ByRef e As RecordSaved)
    '    DisplayTreeViewData()
    'End Sub

    Protected Sub RemoveCurrentNode(bypassChange As Boolean)
        If bypassChange Then
            _bypassSelectedChange = True
        End If
        TreeViewObj.Nodes.Remove(TreeViewObj.SelectedNode)
        _bypassSelectedChange = False
    End Sub

    Protected Overridable Function TreeNodeTextDisplay(tvName As String, ByVal Optional tvAdditionalText As String = "") _
        As String
        Return tvName + If(String.IsNullOrEmpty(tvAdditionalText), "", " (" + tvAdditionalText.ToString() + ")")
    End Function

    Private Sub BfTvEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            TreeViewObj.Nodes(0).Text = MainTableName
            TreeViewObj.ExpandAll()
            DisplayTreeViewData()
        End If
    End Sub

    Private Sub BfTvEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        _bypassSelectedChange = True
        If GlobalVariables.RightToLeftLayout Then
            RightToLeftLayout = True
            TreeViewObj.RightToLeftLayout = True
            TreeViewObj.RightToLeft = RightToLeft.Yes
        Else
            RightToLeftLayout = False
            TreeViewObj.RightToLeftLayout = False
            TreeViewObj.RightToLeft = RightToLeft.No
        End If
        TreeViewObj.ExpandAll()
        _bypassSelectedChange = False
    End Sub

    ' ReSharper disable once UnusedMember.Local
    Private Function GetMainFieldName(mainFieldName As String) As String
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            If GlobalVariables.RightToLeftLayout Then
                mainFieldName = mainFieldName + "Ara"
            End If
        End If
        Return mainFieldName
    End Function

    Private Sub GotoRecordInTreeView()
        Dim found As TreeNode() = TreeViewObj.Nodes.Find(PresenterObj.TargetIdNo, True)
        If found.Length <> 0 Then
            With TreeViewObj
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
        If TreeViewObj.SelectedNode IsNot Nothing AndAlso TreeViewObj.SelectedNode.IsVisible Then
            TreeViewObj.SelectedNode.EnsureVisible()
        End If
    End Sub

End Class