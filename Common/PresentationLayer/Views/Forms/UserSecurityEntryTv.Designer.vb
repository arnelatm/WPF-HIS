<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserSecurityEntryTv
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserSecurityEntryTv))
        Me.btnCheckAllVisible = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCheckAllEditable = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnUncheckAllVisible = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnUncheckAllEditable = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.UserSecurityView = New AATM.Common.PresentationLayer.Views.UserSecurityView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.UserSecurityView)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnUncheckAllEditable)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCheckAllVisible)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCheckAllEditable)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnUncheckAllVisible)
        Me.SplitContainer1.Size = New System.Drawing.Size(1071, 670)
        Me.SplitContainer1.SplitterDistance = 356
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        Me.FormTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FormTreeView.Size = New System.Drawing.Size(356, 670)
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "TreeNode.ico")
        Me.ImageListTreeView.Images.SetKeyName(1, "openbriefcase.png")
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = ""
        '
        'btnCheckAllVisible
        '
        Me.btnCheckAllVisible.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCheckAllVisible.DesignerSelected = False
        Me.btnCheckAllVisible.ImageIndex = 0
        Me.btnCheckAllVisible.Location = New System.Drawing.Point(20, 633)
        Me.btnCheckAllVisible.Name = "btnCheckAllVisible"
        Me.btnCheckAllVisible.OriginalImageName = Nothing
        Me.btnCheckAllVisible.SecurityKey = ""
        Me.btnCheckAllVisible.Size = New System.Drawing.Size(141, 25)
        Me.btnCheckAllVisible.TabIndex = 7
        Me.btnCheckAllVisible.Text = "Check All Visible"
        '
        'btnCheckAllEditable
        '
        Me.btnCheckAllEditable.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCheckAllEditable.DesignerSelected = False
        Me.btnCheckAllEditable.ImageIndex = 0
        Me.btnCheckAllEditable.Location = New System.Drawing.Point(167, 633)
        Me.btnCheckAllEditable.Name = "btnCheckAllEditable"
        Me.btnCheckAllEditable.OriginalImageName = Nothing
        Me.btnCheckAllEditable.SecurityKey = ""
        Me.btnCheckAllEditable.Size = New System.Drawing.Size(155, 25)
        Me.btnCheckAllEditable.TabIndex = 8
        Me.btnCheckAllEditable.Text = "Check All Editable"
        '
        'btnUncheckAllVisible
        '
        Me.btnUncheckAllVisible.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnUncheckAllVisible.DesignerSelected = False
        Me.btnUncheckAllVisible.ImageIndex = 0
        Me.btnUncheckAllVisible.Location = New System.Drawing.Point(328, 633)
        Me.btnUncheckAllVisible.Name = "btnUncheckAllVisible"
        Me.btnUncheckAllVisible.OriginalImageName = Nothing
        Me.btnUncheckAllVisible.SecurityKey = ""
        Me.btnUncheckAllVisible.Size = New System.Drawing.Size(164, 25)
        Me.btnUncheckAllVisible.TabIndex = 9
        Me.btnUncheckAllVisible.Text = "Uncheck All Visible"
        '
        'btnUncheckAllEditable
        '
        Me.btnUncheckAllEditable.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnUncheckAllEditable.DesignerSelected = False
        Me.btnUncheckAllEditable.ImageIndex = 0
        Me.btnUncheckAllEditable.Location = New System.Drawing.Point(498, 633)
        Me.btnUncheckAllEditable.Name = "btnUncheckAllEditable"
        Me.btnUncheckAllEditable.OriginalImageName = Nothing
        Me.btnUncheckAllEditable.SecurityKey = ""
        Me.btnUncheckAllEditable.Size = New System.Drawing.Size(155, 25)
        Me.btnUncheckAllEditable.TabIndex = 10
        Me.btnUncheckAllEditable.Text = "Uncheck All Editable"
        '
        'UserSecurityView
        '
        Me.UserSecurityView.Location = New System.Drawing.Point(0, 0)
        Me.UserSecurityView.Margin = New System.Windows.Forms.Padding(0)
        Me.UserSecurityView.Name = "UserSecurityView"
        Me.UserSecurityView.Size = New System.Drawing.Size(694, 591)
        Me.UserSecurityView.TabIndex = 11
        '
        'UserSecurityEntryTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1071, 725)
        Me.Name = "UserSecurityEntryTv"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCheckAllVisible As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnCheckAllEditable As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnUncheckAllVisible As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnUncheckAllEditable As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents UserSecurityView As PresentationLayer.Views.UserSecurityView
End Class
