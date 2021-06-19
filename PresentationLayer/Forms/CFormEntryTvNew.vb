Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Public Class CFormEntryTvNew

    Protected TvMainFieldName As String
    Protected TvSecondaryFieldName As String
    Protected TvSortKey As String

    'Protected FormTreeView As TreeView
    Private _bypassSelectedChange As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property TreeViewData As New Object

    'Public Sub DisplayTree()
    '    Dim root As TreeNode = FormTreeView.Nodes(0)
    '    root.Nodes.Clear()
    '    ' create the tree
    '    If GlobalVariables.RightToLeftLayout Then
    '        FormTreeView.RightToLeftLayout = True
    '    Else
    '        FormTreeView.RightToLeftLayout = False
    '    End If
    '    FormTreeView.RightToLeft = RightToLeft.Inherit
    '    If ParentFieldName Is Nothing OrElse ParentFieldName = "" Then
    '        For Each dataNode In TreeViewData
    '            AddRecordToTree(dataNode)
    '        Next
    '    Else
    '        For Each dataNode In TreeViewData
    '            AddRecordToTreeHierarchical(dataNode, True)
    '        Next
    '    End If
    'End Sub

    'Protected Overloads Sub AddRecordToTree(dataNode As Object) ', mainFieldName As String)
    '    Dim idNo As Int32 = GetPropertyValue(dataNode, PresenterObj.IdFieldName)
    '    Dim mainValue As String = GetPropertyValue(dataNode, "Name")
    '    Dim secondaryValue As String = GetPropertyValue(dataNode, "Code")
    '    Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
    '    FormTreeView.Nodes(0).Nodes.Add(treeNode)
    'End Sub

    'Protected Overloads Sub AddRecordToTreeHierarchical(dataNode As Object, parentChanged As Boolean)
    '    Dim parentIdValue As Integer? = GetPropertyValue(dataNode, ParentFieldName)
    '    If parentIdValue Is Nothing OrElse parentIdValue = 0 Then
    '        AddRecordToTree(dataNode) ', "Name")
    '    Else
    '        Dim idNo As Int32 = GetPropertyValue(dataNode, "IdNo")
    '        Dim mainValue As String = GetPropertyValue(dataNode, "Name")
    '        Dim secondaryValue As String = GetPropertyValue(dataNode, "Code")
    '        Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
    '        If parentIdValue Is Nothing OrElse parentIdValue = 0 Then
    '            If parentChanged Then
    '                FormTreeView.Nodes(FormTreeView.Nodes.Count - 1).Nodes.Add(treeNode)
    '            Else
    '                FormTreeView.Nodes(0).Nodes.Add(treeNode)
    '            End If
    '        Else
    '            If parentChanged Then
    '                Dim foundNode As TreeNode() = FormTreeView.Nodes.Find(parentIdValue.ToString(), True)
    '                If foundNode.Length <> 0 Then
    '                    foundNode(0).Nodes.Add(treeNode)
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    Public Sub DisplayTreeViewData()
        'Dim tvd As New TreeViewDisplay(TreeViewData)
        If Ea IsNot Nothing Then
            Ea.PublishEvent(New TreeViewDisplay(FormTreeView))
        End If
    End Sub

    'Protected Function MakeTreeNode(mainFieldValue As String, secondaryFieldValue As String, idNo As Int32) _
    '    As TreeNode
    '    Dim treeTextDisplay As String
    '    treeTextDisplay = TreeNodeTextDisplay(mainFieldValue, secondaryFieldValue)
    '    Return New TreeNode With {
    '        .Text = treeTextDisplay,
    '        .Tag = idNo,
    '        .Name = idNo
    '        }
    'End Function

    Protected Overrides Sub OnTextDisplayLanguageChanged() Handles Me.TextDisplayLanguageChanged
        MyBase.OnTextDisplayLanguageChanged()
        DisplayTreeViewData()
    End Sub

    'Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
    '    MyBase.RecordPositionChanged(e)
    '    Debugger.Break()
    '    GotoRecordInTreeView()
    'End Sub

    'Protected Overrides Sub RecordSaved(ByRef e As RecordSaved)
    '    DisplayTreeViewData()
    'End Sub

    Protected Overridable Function TreeNodeTextDisplay(tvName As String, ByVal Optional tvAdditionalText As String = "") _
        As String
        Return tvName + If(String.IsNullOrEmpty(tvAdditionalText), "", " (" + tvAdditionalText.ToString() + ")")
    End Function

    Private Sub CFormEntryTv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            FormTreeView.Nodes(0).Text = MainTableName
            DisplayTreeViewData()
            FormTreeView.ExpandAll()
            FormTreeView.Refresh()
        End If
    End Sub

    'Public Overridable Function GoDeleteRecord() As Integer
    '    Dim record As New TM
    '    GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
    '    Dim retValue = 0
    '    Dim currentIdNo = CallByName(View, IdFieldName, CallType.Get)
    '    If IsOkToDeleteRecord() Then
    '        If Messaging.Show(True, "AskIfDeleteRecord", "Are you sure you want to delete this record?", "Please Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
    '            RaiseEvent BeforeDelete()
    '            retValue = DeleteRecord(currentIdNo)
    '            If retValue <= 0 Then
    '                Messaging.Show(True, "MsgDeleteRecordFailed", "This record was not deleted because of an error. Please try again later or ask Database Administrator for help.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Else
    '                Messaging.Show(True, "MsgRecordSuccessfullyDeleted", "Record was successfully deleted.", "Record Deleted")
    '                ' if deleted stay on that given RecordPositionNumber
    '                ' which in this case will be the next record after the deleted record
    '                TargetIdNo = GetIdNoOfSortedPositionNumber(RecordPositionNumber)
    '                If TargetIdNo = 0 Then
    '                    ' last record deleted
    '                    GoLastRecord()
    '                End If
    '                UpdateViewDisplay(TargetIdNo)
    '            End If
    '            RaiseEvent AfterDelete()
    '        End If
    '    End If
    '    Return retValue
    'End Function

    Private Sub BfTvEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        _bypassSelectedChange = True
        If GlobalVariables.RightToLeftLayout Then
            RightToLeftLayout = True
            FormTreeView.RightToLeftLayout = True
            FormTreeView.RightToLeft = RightToLeft.Yes
        Else
            RightToLeftLayout = False
            FormTreeView.RightToLeftLayout = False
            FormTreeView.RightToLeft = RightToLeft.No
        End If
        FormTreeView.ExpandAll()
        _bypassSelectedChange = False
    End Sub

    Private Function GetMainFieldName(mainFieldName As String) As String
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            If GlobalVariables.RightToLeftLayout Then
                mainFieldName = mainFieldName + "Ara"
            End If
        End If
        Return mainFieldName
    End Function

    Private Sub GotoRecordInTreeView()
        Dim found As TreeNode() = FormTreeView.Nodes.Find(PresenterObj.TargetIdNo, True)
        If found.Length <> 0 Then
            With FormTreeView
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
        If FormTreeView.SelectedNode IsNot Nothing AndAlso FormTreeView.SelectedNode.IsVisible Then
            FormTreeView.SelectedNode.EnsureVisible()
        End If
    End Sub

End Class