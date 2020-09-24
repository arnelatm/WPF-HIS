Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SecurityGroupEntryTv
        Inherits CFormEntryTv

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.SecurityGroupView = New SecurityGroupView()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.TreeViewTableName.Dock = System.Windows.Forms.DockStyle.Left
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            Me.TreeViewTableName.Location = New System.Drawing.Point(0, 53)
            Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.TreeViewTableName.Size = New System.Drawing.Size(300, 581)
            '
            'SecurityGroupView
            '
            Me.SecurityGroupView.BackColor = System.Drawing.Color.Transparent
            Me.SecurityGroupView.Errors = Nothing
            Me.SecurityGroupView.GroupAccesses = Nothing
            Me.SecurityGroupView.IdNo = CType(0, Short)
            Me.SecurityGroupView.Location = New System.Drawing.Point(306, 53)
            Me.SecurityGroupView.MainTableName = "SecurityGroup"
            Me.SecurityGroupView.Name = "SecurityGroupView"
            Me.SecurityGroupView.Notes = ""
            Me.SecurityGroupView.ParentIdNo = Nothing
            Me.SecurityGroupView.SecurityGroupCode = ""
            Me.SecurityGroupView.SecurityGroupName = ""
            Me.SecurityGroupView.SecurityGroupNameAra = ""
            Me.SecurityGroupView.Size = New System.Drawing.Size(695, 581)
            Me.SecurityGroupView.TabIndex = 3
            '
            'SecurityGroupEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1001, 634)
            Me.Controls.Add(Me.SecurityGroupView)
            Me.Name = "SecurityGroupEntryTv"
            Me.Text = "Security Group Maintenance"
            Me.Controls.SetChildIndex(Me.SecurityGroupView, 0)
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents SecurityGroupView As SecurityGroupView
    End Class
End Namespace