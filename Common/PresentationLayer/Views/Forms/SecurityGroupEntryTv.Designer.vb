Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SecurityGroupEntryTv
        Inherits CFormEntryTvNew

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecurityGroupEntryTv))
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Me.SecurityGroupView = New AATM.Common.PresentationLayer.Views.SecurityGroupView()
            Me.btnCheckAllVisible = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCheckAllEditable = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnUncheckAllEditable = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnUncheckAllVisible = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.CFlowLayout1)
            Me.SplitContainer1.Panel2.Controls.Add(Me.SecurityGroupView)
            Me.SplitContainer1.Size = New System.Drawing.Size(1088, 640)
            Me.SplitContainer1.SplitterDistance = 387
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.Size = New System.Drawing.Size(387, 640)
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'SecurityGroupView
            '
            Me.SecurityGroupView.BackColor = System.Drawing.Color.Transparent
            Me.SecurityGroupView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SecurityGroupView.Location = New System.Drawing.Point(0, 0)
            Me.SecurityGroupView.Name = "SecurityGroupView"
            Me.SecurityGroupView.Size = New System.Drawing.Size(691, 640)
            Me.SecurityGroupView.TabIndex = 3
            '
            'btnCheckAllVisible
            '
            Me.btnCheckAllVisible.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnCheckAllVisible.DesignerSelected = False
            Me.btnCheckAllVisible.DisplayOnly = True
            Me.btnCheckAllVisible.ImageIndex = 0
            Me.btnCheckAllVisible.Location = New System.Drawing.Point(3, 3)
            Me.btnCheckAllVisible.Name = "btnCheckAllVisible"
            Me.btnCheckAllVisible.OriginalImageName = Nothing
            Me.btnCheckAllVisible.SecurityKey = ""
            Me.btnCheckAllVisible.Size = New System.Drawing.Size(141, 25)
            Me.btnCheckAllVisible.TabIndex = 4
            Me.btnCheckAllVisible.Text = "Check All Visible"
            '
            'btnCheckAllEditable
            '
            Me.btnCheckAllEditable.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnCheckAllEditable.DesignerSelected = False
            Me.btnCheckAllEditable.DisplayOnly = True
            Me.btnCheckAllEditable.ImageIndex = 0
            Me.btnCheckAllEditable.Location = New System.Drawing.Point(150, 3)
            Me.btnCheckAllEditable.Name = "btnCheckAllEditable"
            Me.btnCheckAllEditable.OriginalImageName = Nothing
            Me.btnCheckAllEditable.SecurityKey = ""
            Me.btnCheckAllEditable.Size = New System.Drawing.Size(155, 25)
            Me.btnCheckAllEditable.TabIndex = 5
            Me.btnCheckAllEditable.Text = "Check All Editable"
            '
            'btnUncheckAllEditable
            '
            Me.btnUncheckAllEditable.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnUncheckAllEditable.DesignerSelected = False
            Me.btnUncheckAllEditable.DisplayOnly = True
            Me.btnUncheckAllEditable.ImageIndex = 0
            Me.btnUncheckAllEditable.Location = New System.Drawing.Point(481, 3)
            Me.btnUncheckAllEditable.Name = "btnUncheckAllEditable"
            Me.btnUncheckAllEditable.OriginalImageName = Nothing
            Me.btnUncheckAllEditable.SecurityKey = ""
            Me.btnUncheckAllEditable.Size = New System.Drawing.Size(155, 25)
            Me.btnUncheckAllEditable.TabIndex = 7
            Me.btnUncheckAllEditable.Text = "Uncheck All Editable"
            '
            'btnUncheckAllVisible
            '
            Me.btnUncheckAllVisible.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnUncheckAllVisible.DesignerSelected = False
            Me.btnUncheckAllVisible.DisplayOnly = True
            Me.btnUncheckAllVisible.ImageIndex = 0
            Me.btnUncheckAllVisible.Location = New System.Drawing.Point(311, 3)
            Me.btnUncheckAllVisible.Name = "btnUncheckAllVisible"
            Me.btnUncheckAllVisible.OriginalImageName = Nothing
            Me.btnUncheckAllVisible.SecurityKey = ""
            Me.btnUncheckAllVisible.Size = New System.Drawing.Size(164, 25)
            Me.btnUncheckAllVisible.TabIndex = 6
            Me.btnUncheckAllVisible.Text = "Uncheck All Visible"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.btnCheckAllVisible)
            Me.CFlowLayout1.Controls.Add(Me.btnCheckAllEditable)
            Me.CFlowLayout1.Controls.Add(Me.btnUncheckAllVisible)
            Me.CFlowLayout1.Controls.Add(Me.btnUncheckAllEditable)
            Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.CFlowLayout1.Location = New System.Drawing.Point(0, 603)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(691, 37)
            Me.CFlowLayout1.TabIndex = 8
            '
            'SecurityGroupEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1088, 693)
            Me.Name = "SecurityGroupEntryTv"
            Me.Text = "Security Group Maintenance"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents SecurityGroupView As SecurityGroupView
        Friend WithEvents btnCheckAllVisible As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCheckAllEditable As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnUncheckAllEditable As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnUncheckAllVisible As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    End Class
End Namespace