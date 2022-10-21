Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class CListSelector
    Inherits CForm

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
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lstItems = New AATM.Libraries.CBaseControlsLibrary.CListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CFlowLayout1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.AutoSize = True
        Me.CFlowLayout1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.TableLayoutPanel1)
        Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFlowLayout1.Location = New System.Drawing.Point(0, 0)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(381, 359)
        Me.CFlowLayout1.TabIndex = 0
        '
        'lstItems
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lstItems, 2)
        Me.lstItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstItems.FormattingEnabled = True
        Me.lstItems.Location = New System.Drawing.Point(3, 3)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(369, 315)
        Me.lstItems.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnOk, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lstItems, 0, 0)
        Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(375, 351)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DesignerSelected = False
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(234, 324)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(94, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOk.DesignerSelected = False
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(68, 324)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(50, 24)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "Ok"
        '
        'CListSelector
        '
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(381, 359)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "CListSelector"
        Me.Text = "List Selector"
        Me.CFlowLayout1.ResumeLayout(False)
        Me.CFlowLayout1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents CLabel1 As CLabel
    Friend WithEvents txtFieldToSearch As CLabel
    Friend WithEvents CFlowLayout1 As CFlowLayout
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnOk As CButton
    Friend WithEvents btnCancel As CButton
    Friend WithEvents lstItems As CListBox
End Class
