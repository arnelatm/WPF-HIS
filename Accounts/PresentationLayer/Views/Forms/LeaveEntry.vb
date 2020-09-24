Imports System.ComponentModel
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class LeaveEntry

        Protected TvMainFieldName As String
        Protected TvSecondaryFieldName As String
        Protected TvSortKey As String
        Private _bypassSelectedChange As Boolean = False

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "Leave"
            TvMainFieldName = "LeaveName"
            TvSecondaryFieldName = "LeaveCode"
            SortOrderKey = "DeductionName"
            FirstControl = LeaveView.txtLeaveCode
            PresenterObj = New LeavePresenter(LeaveView)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

        Public Sub DisplayTree(ByRef treeViewData As Object)
            Dim root As TreeNode = TreeViewLeave.Nodes(0)
            'Dim displayMainFieldName = GetTranslatedField(TvMainFieldName)
            root.Nodes.Clear()
            ' create the tree
            If GlobalVariables.RightToLeftLayout Then
                TreeViewLeave.RightToLeftLayout = True
            Else
                TreeViewLeave.RightToLeftLayout = False
            End If
            TreeViewLeave.RightToLeft = RightToLeft.Inherit
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
            TreeViewLeave.Nodes(0).Nodes.Add(treeNode)
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
                        TreeViewLeave.Nodes(TreeViewLeave.Nodes.Count - 1).Nodes.Add(treeNode)
                    Else
                        TreeViewLeave.Nodes(0).Nodes.Add(treeNode)
                    End If
                Else
                    If parentChanged Then
                        Dim foundNode As TreeNode() = TreeViewLeave.Nodes.Find(parentIdValue.ToString(), True)
                        If foundNode.Length <> 0 Then
                            foundNode(0).Nodes.Add(treeNode)
                        End If
                    End If
                End If
            End If
        End Sub

        Protected Sub BfTvEntry_AfterSelect(sender As Object, e As TreeViewEventArgs) _
        Handles TreeViewLeave.AfterSelect
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
                TreeViewLeave.ImageIndex = 1
                If TreeViewLeave.SelectedNode.Tag.ToString = "root" Then
                    PresenterObj.RecordPositionNumber = 1
                Else
                    nTag = TreeViewLeave.SelectedNode.Tag
                    PresenterObj.RecordPositionNumber = PresenterObj.GetSortedRecordPosition(nTag)
                End If
                If Not TreeViewLeave.SelectedNode.IsVisible Then
                    TreeViewLeave.SelectedNode.EnsureVisible()
                End If
            End If
        End Sub

        Protected Sub DisplayTreeViewData()
            Dim treeViewData = PresenterObj.GetTreeViewDataNew()
            DisplayTree(treeViewData)
            TreeViewLeave.ExpandAll()
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

        Protected Overrides Sub OnTextDisplayLanguageChanged() Handles Me.TextDisplayLanguageChanged
            MyBase.OnTextDisplayLanguageChanged()
            DisplayTreeViewData()
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            MyBase.RecordPositionChanged(e)
            GotoRecordInTreeView()
        End Sub

        Protected Overrides Sub RecordSaved(ByRef e As RecordSaved)
            DisplayTreeViewData()
        End Sub

        Protected Sub RemoveCurrentNode(bypassChange As Boolean)
            If bypassChange Then
                _bypassSelectedChange = True
            End If
            TreeViewLeave.Nodes.Remove(TreeViewLeave.SelectedNode)
            _bypassSelectedChange = False
        End Sub

        Protected Overridable Function TreeNodeTextDisplay(tvName As String, ByVal Optional tvAdditionalText As String = "") _
        As String
            Return tvName + If(String.IsNullOrEmpty(tvAdditionalText), "", " (" + tvAdditionalText.ToString() + ")")
        End Function

        Private Sub BfTvEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
                TreeViewLeave.Nodes(0).Text = MainTableName
                TreeViewLeave.ExpandAll()
                DisplayTreeViewData()
            End If
        End Sub

        Private Sub BfTvEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            _bypassSelectedChange = True
            If GlobalVariables.RightToLeftLayout Then
                RightToLeftLayout = True
                TreeViewLeave.RightToLeftLayout = True
                TreeViewLeave.RightToLeft = RightToLeft.Yes
            Else
                RightToLeftLayout = False
                TreeViewLeave.RightToLeftLayout = False
                TreeViewLeave.RightToLeft = RightToLeft.No
            End If
            TreeViewLeave.ExpandAll()
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
            Dim found As TreeNode() = TreeViewLeave.Nodes.Find(PresenterObj.TargetIdNo, True)
            If found.Length <> 0 Then
                With TreeViewLeave
                    _bypassSelectedChange = True
                    .SelectedNode = found(0)
                    _bypassSelectedChange = False
                    .HideSelection = False
                    .Select()
                End With
            End If
            ' update treeview text if ever name is changed
            'If Not TreeViewLeave.SelectedNode Is Nothing Then
            'TreeViewLeave.SelectedNode.Text = TreeNodeText
            'End If
            If TreeViewLeave.SelectedNode IsNot Nothing AndAlso TreeViewLeave.SelectedNode.IsVisible Then
                TreeViewLeave.SelectedNode.EnsureVisible()
            End If
        End Sub

    End Class

End Namespace