Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class CFormEntryTv
    Inherits CFormEntry

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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("TableName")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CFormEntryTv))
        Me.TreeViewTableName = New System.Windows.Forms.TreeView()
        Me.ImageListTreeView = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.TreeViewTableName.BackColor = System.Drawing.Color.Honeydew
        Me.TreeViewTableName.ImageKey = "TreeNode.ico"
        Me.TreeViewTableName.ImageList = Me.ImageListTreeView
        Me.TreeViewTableName.Location = New System.Drawing.Point(0, 61)
        Me.TreeViewTableName.Name = "TreeViewTableName"
        TreeNode1.Name = "Node0"
        TreeNode1.Tag = "root"
        TreeNode1.Text = "TableName"
        Me.TreeViewTableName.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeViewTableName.SelectedImageKey = "openbriefcase.png"
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 245)
        Me.TreeViewTableName.TabIndex = 2
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
        '
        'CFormEntryTv
        '
        Me.ClientSize = New System.Drawing.Size(852, 308)
        Me.Controls.Add(Me.TreeViewTableName)
        Me.Name = "CFormEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Public WithEvents TreeViewTableName As TreeView
    Friend WithEvents ImageListTreeView As ImageList
End Class
