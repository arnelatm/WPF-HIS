Imports AATM.PresentationLayer.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LeaveEntry
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
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("TableName")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("TableName")
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.LeaveTreeView = New System.Windows.Forms.TreeView()
        Me.LeaveView = New AATM.Accounts.PresentationLayer.Views.LeaveView()
        Me.LeaveView1 = New AATM.Accounts.PresentationLayer.Views.LeaveView()
        Me.TreeViewLeave = New System.Windows.Forms.TreeView()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 53)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.LeaveTreeView)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.LeaveView)
        Me.SplitContainer1.Size = New System.Drawing.Size(939, 397)
        Me.SplitContainer1.SplitterDistance = 313
        Me.SplitContainer1.TabIndex = 4
        '
        'LeaveTreeView
        '
        Me.LeaveTreeView.BackColor = System.Drawing.Color.Honeydew
        Me.LeaveTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeaveTreeView.ImageKey = "TreeNode.ico"
        Me.LeaveTreeView.Location = New System.Drawing.Point(0, 0)
        Me.LeaveTreeView.Name = "LeaveTreeView"
        TreeNode3.Name = "Node0"
        TreeNode3.Tag = "root"
        TreeNode3.Text = "TableName"
        Me.LeaveTreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3})
        Me.LeaveTreeView.SelectedImageKey = "openbriefcase.png"
        Me.LeaveTreeView.Size = New System.Drawing.Size(313, 397)
        Me.LeaveTreeView.TabIndex = 3
        '
        'LeaveView
        '
        Me.LeaveView.BackColor = System.Drawing.Color.Olive
        Me.LeaveView.Cumulative = False
        Me.LeaveView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeaveView.Errors = Nothing
        Me.LeaveView.IdNo = CType(0, Short)
        Me.LeaveView.LeaveCode = ""
        Me.LeaveView.LeaveName = ""
        Me.LeaveView.LeaveNameAra = ""
        Me.LeaveView.Location = New System.Drawing.Point(0, 0)
        Me.LeaveView.MainTableName = "Leave"
        Me.LeaveView.Name = "LeaveView"
        Me.LeaveView.Notes = ""
        Me.LeaveView.PaidPercent = New Decimal(New Integer() {0, 0, 0, 0})
        Me.LeaveView.Size = New System.Drawing.Size(622, 397)
        Me.LeaveView.TabIndex = 0
        '
        'LeaveView1
        '
        Me.LeaveView1.BackColor = System.Drawing.Color.Olive
        Me.LeaveView1.Cumulative = False
        Me.LeaveView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeaveView1.Errors = Nothing
        Me.LeaveView1.IdNo = CType(0, Short)
        Me.LeaveView1.LeaveCode = ""
        Me.LeaveView1.LeaveName = ""
        Me.LeaveView1.LeaveNameAra = ""
        Me.LeaveView1.Location = New System.Drawing.Point(0, 0)
        Me.LeaveView1.MainTableName = "Leave"
        Me.LeaveView1.Name = "LeaveView1"
        Me.LeaveView1.Notes = ""
        Me.LeaveView1.PaidPercent = New Decimal(New Integer() {0, 0, 0, 0})
        Me.LeaveView1.Size = New System.Drawing.Size(622, 397)
        Me.LeaveView1.TabIndex = 0
        '
        'TreeViewLeave
        '
        Me.TreeViewLeave.BackColor = System.Drawing.Color.Honeydew
        Me.TreeViewLeave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewLeave.ImageKey = "TreeNode.ico"
        Me.TreeViewLeave.Location = New System.Drawing.Point(0, 0)
        Me.TreeViewLeave.Name = "TreeViewLeave"
        TreeNode4.Name = "Node0"
        TreeNode4.Tag = "root"
        TreeNode4.Text = "TableName"
        Me.TreeViewLeave.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4})
        Me.TreeViewLeave.SelectedImageKey = "openbriefcase.png"
        Me.TreeViewLeave.Size = New System.Drawing.Size(313, 397)
        Me.TreeViewLeave.TabIndex = 3
        '
        'LeaveEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 450)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "LeaveEntry"
        Me.Text = "LeaveEntry"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Public WithEvents LeaveTreeView As TreeView
    Friend WithEvents LeaveView As PresentationLayer.Views.LeaveView
    Friend WithEvents LeaveView1 As PresentationLayer.Views.LeaveView
    Public WithEvents TreeViewLeave As TreeView
End Class
