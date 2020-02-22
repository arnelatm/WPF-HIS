Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class BFScTvEntrySc
    Inherits BfEntry

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim TreeNode1 As TreeNode = New TreeNode("TableName")
        Me.SplitContainer1 = New SplitContainer()
        Me.TreeViewTableName = New TreeView()
        CType(Me.MyErrorProvider, ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = DockStyle.Fill
        Me.SplitContainer1.Location = New Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeViewTableName)
        Me.SplitContainer1.Size = New Size(852, 464)
        Me.SplitContainer1.SplitterDistance = 284
        Me.SplitContainer1.TabIndex = 1
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.Dock = DockStyle.Fill
        Me.TreeViewTableName.ImageKey = "TreeNode.ico"
        Me.TreeViewTableName.Location = New Point(0, 0)
        Me.TreeViewTableName.Name = "TreeViewTableName"
        TreeNode1.Name = "Node0"
        TreeNode1.Tag = "root"
        TreeNode1.Text = "TableName"
        Me.TreeViewTableName.Nodes.AddRange(New TreeNode() {TreeNode1})
        Me.TreeViewTableName.RightToLeft = RightToLeft.Yes
        Me.TreeViewTableName.RightToLeftLayout = True
        Me.TreeViewTableName.SelectedImageKey = "openbriefcase.png"
        Me.TreeViewTableName.Size = New Size(284, 464)
        Me.TreeViewTableName.TabIndex = 2
        '
        'BFScTvEntrySc
        '
        Me.ClientSize = New Size(852, 528)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "BFScTvEntrySc"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        CType(Me.MyErrorProvider, ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Public WithEvents TreeViewTableName As TreeView
End Class
