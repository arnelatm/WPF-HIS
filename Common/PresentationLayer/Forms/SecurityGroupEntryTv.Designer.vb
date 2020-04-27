<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SecurityGroupEntryTv
    Inherits AATM.PresentationLayer.Forms.CFormEntryTv

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SecurityGroupView1 = New AATM.Common.PresentationLayer.Forms.SecurityGroupView()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 615)
        '
        'SecurityGroupView1
        '
        Me.SecurityGroupView1.BackColor = System.Drawing.Color.Transparent
        Me.SecurityGroupView1.Errors = Nothing
        Me.SecurityGroupView1.GroupAccesses = Nothing
        Me.SecurityGroupView1.IDNo = 0
        Me.SecurityGroupView1.Location = New System.Drawing.Point(316, 64)
        Me.SecurityGroupView1.MainTableName = "SecurityGroup"
        Me.SecurityGroupView1.Name = "SecurityGroupView1"
        Me.SecurityGroupView1.Notes = ""
        Me.SecurityGroupView1.ParentIdNo = Nothing
        Me.SecurityGroupView1.SecurityGroupCode = ""
        Me.SecurityGroupView1.SecurityGroupName = ""
        Me.SecurityGroupView1.SecurityGroupNameAra = ""
        Me.SecurityGroupView1.Size = New System.Drawing.Size(694, 591)
        Me.SecurityGroupView1.TabIndex = 3
        '
        'SecurityGroupEntryTv
        '
        Me.ClientSize = New System.Drawing.Size(1033, 678)
        Me.Controls.Add(Me.SecurityGroupView1)
        Me.Name = "SecurityGroupEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.SecurityGroupView1, 0)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SecurityGroupView1 As PresentationLayer.Forms.SecurityGroupView
End Class
