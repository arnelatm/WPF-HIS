Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.LIBRARIES.CBaseControlsLibrary
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class CrReportViewer
    Inherits BfMain

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CrReportViewer))
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CrystalReportViewer1 = New CrystalReportViewer()
        Me.btnQuit = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOk.BackColor = System.Drawing.Color.Transparent
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOk.DesignerSelected = True
        Me.btnOk.DisplayOnly = True
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(106, 187)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.DesignerSelected = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.DisplayOnly = True
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(187, 187)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.EnableDrillDown = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(353, 181)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
        '
        'btnQuit
        '
        Me.btnQuit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuit.BackColor = System.Drawing.Color.Transparent
        Me.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnQuit.DesignerSelected = False
        Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnQuit.DisplayOnly = True
        Me.btnQuit.Image = CType(resources.GetObject("btnQuit.Image"), System.Drawing.Image)
        Me.btnQuit.ImageIndex = 0
        Me.btnQuit.Location = New System.Drawing.Point(353, 0)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.OriginalImageName = Nothing
        Me.btnQuit.SecurityKey = ""
        Me.btnQuit.Size = New System.Drawing.Size(22, 23)
        Me.btnQuit.TabIndex = 5
        Me.btnQuit.Visible = False
        '
        'CrReportViewer
        '
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(374, 222)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "CrReportViewer"
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(false)

End Sub
    Protected WithEvents btnOk As CButton
    Protected WithEvents btnCancel As CButton
    Protected WithEvents btnQuit As CButton
    Protected WithEvents CrystalReportViewer1 As CrystalReportViewer
End Class
