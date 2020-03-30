Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CFormEntryTv

    Private _bypassSelectedChange As Boolean = False
    Protected TvMainFieldName As String
    Protected TvSecondaryFieldName As String
    Protected TvSortKey As String


    
    Private Sub BfTvEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            TreeViewTableName.Nodes(0).Text = MainTableName
            TreeViewTableName.ExpandAll()
            DisplayTreeViewData()
            GotoRecordInTreeView()
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
            If Not OkToMove() Then
                Exit Sub
            End If
            Dim nTag As Integer
            TreeViewTableName.ImageIndex = 1
            If TreeViewTableName.SelectedNode.Tag.ToString = "root" Then
                RecordPositionNumber = 1
            Else
                nTag = TreeViewTableName.SelectedNode.Tag
                TargetIdNo = nTag
                'CurrentIDNo = nTag
                GetAndSetRecordPositionNumber()
            End If
            GetAndDisplayRecordForGivenRecordPosition()
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
        Dim found As TreeNode() = TreeViewTableName.Nodes.Find(TargetIdNo, True)
        If found.Length <> 0 Then
            With TreeViewTableName
                _bypassSelectedChange = True
                .SelectedNode = found(0)
                _bypassSelectedChange = False
                .HideSelection = False
                .Select()
            End With
        End If
        ' dupdate treeview text if ever name is changed
        'If Not TreeViewTableName.SelectedNode Is Nothing Then
        '    'TreeViewTableName.SelectedNode.Text = TreeNodeText
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

    '    Try
    '        If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then
    '            If GlobalVariables.RightToLeftLayout Then
    '                TreeViewTableName.RightToLeftLayout = True
    '                TreeViewTableName.RightToLeft = RightToLeft.Yes
    '            Else
    '                TreeViewTableName.RightToLeftLayout = False
    '                TreeViewTableName.RightToLeft = RightToLeft.No
    '            End If
    '        End If
    '        Dim myNode As TreeNode = TreeViewTableName.Nodes(0)
    '        myNode.Expand()
    '        myNode.EnsureVisible()
    '    Catch ex As Exception
    '        ' need to do this because derived forms would not open in designer. don't know why?
    '    End Try
    'End Sub

    'Protected Overridable ReadOnly Property TreeNodeText As String
    '    Get
    '        Return ""
    '    End Get
    'End Property

    Protected Overridable Function TreeNodeTextDisplay(tvName As String, ByVal Optional tvAdditionalText As String = "") _
        As String
        Return tvName + If(String.IsNullOrEmpty(tvAdditionalText), "", " (" + tvAdditionalText.ToString() + ")")
    End Function

    'Protected Overridable Sub AddRecordToTree(tvText As String, tvTag As Integer)
    '    Dim treeNode As New TreeNode With {
    '            .Text = TVText,
    '            .Tag = TVTag,
    '            .Name = TVTag
    '            }
    '    TreeViewTableName.Nodes(0).Nodes.Add(TreeNode)
    'End Sub

    Protected Function MakeTreeNode(mainFieldValue As String, secondaryFieldValue As String, idNo As Integer) _
        As TreeNode
        Dim treeTextDisplay As String
        treeTextDisplay = TreeNodeTextDisplay(mainFieldValue, secondaryFieldValue)
        Return New TreeNode With {
            .Text = treeTextDisplay,
            .Tag = idNo,
            .Name = idNo
            }
    End Function

    'Protected Overrides Sub GotoTargetIdNo()
    '    MyBase.GotoTargetIDNo()
    '    GotoRecordInTreeView()
    'End Sub

    Protected Sub RemoveCurrentNode(bypassChange As Boolean)
        If bypassChange Then
            _bypassSelectedChange = True
        End If
        TreeViewTableName.Nodes.Remove(TreeViewTableName.SelectedNode)
        _bypassSelectedChange = False
    End Sub

    Private Sub BfTvEntry_SuccessfulDelete(idNoOfDeletedRecord As Integer) Handles MyBase.SuccessfulDelete
        RemoveCurrentNode(True)
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

    Public Sub OnSuccessfulUpdate() Handles MyBase.SuccessfulUpdate
        GetAndSetRecordPositionNumber()
        DisplayTreeViewData()
    End Sub

    Public Sub OnSuccessfulAdd() Handles MyBase.SuccessfulAdd
        DisplayTreeViewData()
        GotoRecordInTreeView()
        GetAndSetRecordPositionNumber()
    End Sub

    Protected Overrides Sub DisplayView()
        MyBase.DisplayView()
        GotoRecordInTreeView()
    End Sub

    Protected Sub DisplayTreeViewData()
        Dim treeViewData = PresenterObj.GetTreeViewDataNew()
        DisplayTree(treeViewData)
        TreeViewTableName.ExpandAll()
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
        Dim idNo As Int32 = GetPropertyValue(dataNode, IdFieldName)
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
                    If foundNode.Count() <> 0 Then
                        foundNode(0).Nodes.Add(treeNode)
                    End If
                End If
            End If
        End If
    End Sub

    ''Protected Overloads Sub AddRecordToTreeHierarchical(dataNode As Object, mainFieldName As String,
    ''                                                    parentChanged As Boolean)
    ''    Dim parentIdValue As Integer? = GetPropertyValue(dataNode, ParentFieldName)
    ''    If parentIdValue Is Nothing OrElse parentIdValue = 0 Then
    ''        AddRecordToTree(dataNode, mainFieldName)
    ''    Else
    ''        Dim idNo As Int32 = GetPropertyValue(dataNode, IdFieldName)
    ''        Dim mainValue As String = GetPropertyValue(dataNode, mainFieldName)
    ''        Dim secondaryValue As String = GetPropertyValue(dataNode, TvSecondaryFieldName)
    ''        Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
    ''        If parentIdValue Is Nothing OrElse parentIdValue = 0 Then
    ''            If parentChanged Then
    ''                TreeViewTableName.Nodes(TreeViewTableName.Nodes.Count - 1).Nodes.Add(treeNode)
    ''            Else
    ''                TreeViewTableName.Nodes(0).Nodes.Add(treeNode)
    ''            End If
    ''        Else
    ''            If parentChanged Then
    ''                Dim foundNode As TreeNode() = TreeViewTableName.Nodes.Find(parentIdValue.ToString(), True)
    ''                If foundNode.Count() <> 0 Then
    ''                    foundNode(0).Nodes.Add(treeNode)
    ''                End If
    ''            End If
    ''        End If
    ''    End If
    ''End Sub

    'Protected Overrides Sub ChangeToRtlDisplay()
    '    Dim ltrCultureInfoStr = GlobalVariables.DefaultUnmirroredCultureInfoStr
    '    GlobalVariables.RightToLeftLayout = False
    '    If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
    '        Dim currentCultureInfo As New CultureInfo(ltrCultureInfoStr)
    '        If CultureInfo.CurrentCulture.Name <> currentCultureInfo.Name Then
    '            CultureInfo.CurrentCulture = currentCultureInfo
    '        End If
    '        If CultureInfo.CurrentUICulture.Name <> currentCultureInfo.Name Then
    '            CultureInfo.CurrentUICulture = currentCultureInfo
    '        End If
    '        CultureInfo.DefaultThreadCurrentCulture = currentCultureInfo
    '        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
    '            GlobalVariables.RightToLeftLayout = True
    '        Else
    '            GlobalVariables.RightToLeftLayout = False
    '        End If
    '    Else
    '        '' you're ok you're using RightToLeft culture
    '    End If
    '    TreeViewTableName.RightToLeftLayout = True
    '    TreeViewTableName.RightToLeft = RightToLeft.Inherit
    '    RightToLeftLayout = True
    '    RightToLeft = System.Windows.Forms.RightToLeft.Inherit
    '    'TreeViewTableName.Visible = True

    'End Sub

End Class