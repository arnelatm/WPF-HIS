<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CFormEntryTvNew
    Inherits CFormEntryNew

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CFormEntryTvNew))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("TableName")
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeViewTableName = New AATM.Libraries.CBaseControlsLibrary.CTreeView()
        Me.ImageListTreeView = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackgroundImage = CType(resources.GetObject("SplitContainer1.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 53)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeViewTableName)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Size = New System.Drawing.Size(800, 397)
        Me.SplitContainer1.SplitterDistance = 266
        Me.SplitContainer1.TabIndex = 4
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.BackColor = System.Drawing.Color.Honeydew
        Me.TreeViewTableName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewTableName.ImageKey = "TreeNode.ico"
        Me.TreeViewTableName.ImageList = Me.ImageListTreeView
        Me.TreeViewTableName.Location = New System.Drawing.Point(0, 0)
        Me.TreeViewTableName.Name = "TreeViewTableName"
        TreeNode1.Name = "Node0"
        TreeNode1.Tag = "root"
        TreeNode1.Text = "TableName"
        Me.TreeViewTableName.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeViewTableName.SelectedImageKey = "openbriefcase.png"
        Me.TreeViewTableName.Size = New System.Drawing.Size(266, 397)
        Me.TreeViewTableName.TabIndex = 0
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListTreeView.Images.SetKeyName(0, "TreeNode.ico")
        Me.ImageListTreeView.Images.SetKeyName(1, "openbriefcase.png")
        '
        'CFormEntryNewTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "CFormEntryNewTv"
        Me.Text = "CFormEntryNewTv"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageListTreeView As Windows.Forms.ImageList
    Public WithEvents TreeViewTableName As Libraries.CBaseControlsLibrary.CTreeView
    Public WithEvents SplitContainer1 As Windows.Forms.SplitContainer
End Class
