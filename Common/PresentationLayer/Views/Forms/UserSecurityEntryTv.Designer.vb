Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UserSecurityEntryTv
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserSecurityEntryTv))
            Me.btnCheckAllVisible = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCheckAllEditable = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnUncheckAllEditable = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnUncheckAllVisible = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.UserSecurityView = New AATM.Common.PresentationLayer.Views.UserSecurityView()
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
            Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(5)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.UserSecurityView)
            Me.SplitContainer1.Panel2.Controls.Add(Me.CFlowLayout1)
            Me.SplitContainer1.Size = New System.Drawing.Size(1458, 798)
            Me.SplitContainer1.SplitterDistance = 518
            Me.SplitContainer1.SplitterWidth = 17
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.Margin = New System.Windows.Forms.Padding(5)
            Me.FormTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.FormTreeView.Size = New System.Drawing.Size(518, 798)
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = ""
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = ""
            '
            'btnCheckAllVisible
            '
            Me.btnCheckAllVisible.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnCheckAllVisible.DesignerSelected = False
            Me.btnCheckAllVisible.ImageIndex = 0
            Me.btnCheckAllVisible.Location = New System.Drawing.Point(4, 4)
            Me.btnCheckAllVisible.Margin = New System.Windows.Forms.Padding(4)
            Me.btnCheckAllVisible.Name = "btnCheckAllVisible"
            Me.btnCheckAllVisible.OriginalImageName = Nothing
            Me.btnCheckAllVisible.SecurityKey = ""
            Me.btnCheckAllVisible.Size = New System.Drawing.Size(188, 31)
            Me.btnCheckAllVisible.TabIndex = 4
            Me.btnCheckAllVisible.Text = "Check All Visible"
            '
            'btnCheckAllEditable
            '
            Me.btnCheckAllEditable.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnCheckAllEditable.DesignerSelected = False
            Me.btnCheckAllEditable.ImageIndex = 0
            Me.btnCheckAllEditable.Location = New System.Drawing.Point(200, 4)
            Me.btnCheckAllEditable.Margin = New System.Windows.Forms.Padding(4)
            Me.btnCheckAllEditable.Name = "btnCheckAllEditable"
            Me.btnCheckAllEditable.OriginalImageName = Nothing
            Me.btnCheckAllEditable.SecurityKey = ""
            Me.btnCheckAllEditable.Size = New System.Drawing.Size(207, 31)
            Me.btnCheckAllEditable.TabIndex = 5
            Me.btnCheckAllEditable.Text = "Check All Editable"
            '
            'btnUncheckAllEditable
            '
            Me.btnUncheckAllEditable.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnUncheckAllEditable.DesignerSelected = False
            Me.btnUncheckAllEditable.ImageIndex = 0
            Me.btnUncheckAllEditable.Location = New System.Drawing.Point(642, 4)
            Me.btnUncheckAllEditable.Margin = New System.Windows.Forms.Padding(4)
            Me.btnUncheckAllEditable.Name = "btnUncheckAllEditable"
            Me.btnUncheckAllEditable.OriginalImageName = Nothing
            Me.btnUncheckAllEditable.SecurityKey = ""
            Me.btnUncheckAllEditable.Size = New System.Drawing.Size(207, 31)
            Me.btnUncheckAllEditable.TabIndex = 7
            Me.btnUncheckAllEditable.Text = "Uncheck All Editable"
            '
            'btnUncheckAllVisible
            '
            Me.btnUncheckAllVisible.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnUncheckAllVisible.DesignerSelected = False
            Me.btnUncheckAllVisible.ImageIndex = 0
            Me.btnUncheckAllVisible.Location = New System.Drawing.Point(415, 4)
            Me.btnUncheckAllVisible.Margin = New System.Windows.Forms.Padding(4)
            Me.btnUncheckAllVisible.Name = "btnUncheckAllVisible"
            Me.btnUncheckAllVisible.OriginalImageName = Nothing
            Me.btnUncheckAllVisible.SecurityKey = ""
            Me.btnUncheckAllVisible.Size = New System.Drawing.Size(219, 31)
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
            Me.CFlowLayout1.Location = New System.Drawing.Point(0, 752)
            Me.CFlowLayout1.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(923, 46)
            Me.CFlowLayout1.TabIndex = 8
            '
            'UserSecurityView
            '
            Me.UserSecurityView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.UserSecurityView.Location = New System.Drawing.Point(0, 0)
            Me.UserSecurityView.Margin = New System.Windows.Forms.Padding(4)
            Me.UserSecurityView.Name = "UserSecurityView"
            Me.UserSecurityView.Size = New System.Drawing.Size(923, 752)
            Me.UserSecurityView.TabIndex = 9
            '
            'UserSecurityEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.ClientSize = New System.Drawing.Size(1458, 853)
            Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
            Me.Name = "UserSecurityEntryTv"
            Me.Text = "Security Group Maintenance"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnCheckAllVisible As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCheckAllEditable As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnUncheckAllEditable As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnUncheckAllVisible As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents UserSecurityView As UserSecurityView
    End Class
End Namespace