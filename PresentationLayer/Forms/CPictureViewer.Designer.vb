<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CPictureViewer
    Inherits BFMain

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CPictureBox1 = New AATM.Libraries.CBaseControlsLibrary.CPictureBox()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.btnShow = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnClear = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnClose = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.lblPictureNote = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.cCheckBox = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.CPictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.CFlowLayout2.SuspendLayout
        Me.SuspendLayout
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85!))
        Me.TableLayoutPanel1.Controls.Add(Me.CPictureBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CFlowLayout1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CFlowLayout2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(684, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CPictureBox1
        '
        Me.CPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.CPictureBox1, 2)
        Me.CPictureBox1.DisplayOnly = false
        Me.CPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CPictureBox1.EditingMode = false
        Me.CPictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.CPictureBox1.MaxImageSize = 0
        Me.CPictureBox1.Name = "CPictureBox1"
        Me.CPictureBox1.Size = New System.Drawing.Size(678, 498)
        Me.CPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CPictureBox1.TabIndex = 0
        Me.CPictureBox1.TabStop = false
        Me.CPictureBox1.Translatable = false
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.btnShow)
        Me.CFlowLayout1.Controls.Add(Me.btnClear)
        Me.CFlowLayout1.Controls.Add(Me.btnCancel)
        Me.CFlowLayout1.Controls.Add(Me.btnClose)
        Me.CFlowLayout1.Controls.Add(Me.lblPictureNote)
        Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFlowLayout1.Location = New System.Drawing.Point(105, 507)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CFlowLayout1.Size = New System.Drawing.Size(576, 51)
        Me.CFlowLayout1.TabIndex = 2
        '
        'btnShow
        '
        Me.btnShow.DesignerSelected = true
        Me.btnShow.ImageIndex = 0
        Me.btnShow.Location = New System.Drawing.Point(440, 3)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.OriginalImageName = Nothing
        Me.btnShow.SecurityKey = ""
        Me.btnShow.Size = New System.Drawing.Size(133, 25)
        Me.btnShow.TabIndex = 0
        Me.btnShow.Text = "Select New Image"
        '
        'btnClear
        '
        Me.btnClear.DesignerSelected = false
        Me.btnClear.ImageIndex = 0
        Me.btnClear.Location = New System.Drawing.Point(305, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.OriginalImageName = Nothing
        Me.btnClear.SecurityKey = ""
        Me.btnClear.Size = New System.Drawing.Size(129, 25)
        Me.btnClear.TabIndex = 1
        Me.btnClear.Text = "Clear the Image"
        '
        'btnCancel
        '
        Me.btnCancel.DesignerSelected = false
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(188, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(111, 25)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        '
        'btnClose
        '
        Me.btnClose.DesignerSelected = false
        Me.CFlowLayout1.SetFlowBreak(Me.btnClose, true)
        Me.btnClose.ImageIndex = 0
        Me.btnClose.Location = New System.Drawing.Point(92, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.OriginalImageName = Nothing
        Me.btnClose.SecurityKey = ""
        Me.btnClose.Size = New System.Drawing.Size(90, 25)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Ok"
        '
        'lblPictureNote
        '
        Me.lblPictureNote.AutoSize = true
        Me.lblPictureNote.DisplayOnly = true
        Me.lblPictureNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPictureNote.EditingMode = false
        Me.lblPictureNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPictureNote.Location = New System.Drawing.Point(458, 32)
        Me.lblPictureNote.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPictureNote.Name = "lblPictureNote"
        Me.lblPictureNote.Size = New System.Drawing.Size(117, 17)
        Me.lblPictureNote.TabIndex = 4
        Me.lblPictureNote.Text = "Enter Description"
        Me.lblPictureNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPictureNote.Translatable = true
        '
        'CFlowLayout2
        '
        Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout2.Controls.Add(Me.cCheckBox)
        Me.CFlowLayout2.Controls.Add(Me.CLabel1)
        Me.CFlowLayout2.Location = New System.Drawing.Point(3, 507)
        Me.CFlowLayout2.Name = "CFlowLayout2"
        Me.CFlowLayout2.Size = New System.Drawing.Size(96, 28)
        Me.CFlowLayout2.TabIndex = 3
        '
        'cCheckBox
        '
        Me.cCheckBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.cCheckBox.BegFindValue = Nothing
        Me.cCheckBox.Checked = false
        Me.cCheckBox.EditingMode = true
        Me.cCheckBox.EndFindValue = Nothing
        Me.cCheckBox.FieldDescription = Nothing
        Me.cCheckBox.FieldName = Nothing
        Me.cCheckBox.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cCheckBox.FindEnabled = false
        Me.cCheckBox.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.cCheckBox.IgnoreCase = false
        Me.cCheckBox.LinkedLabel = Nothing
        Me.cCheckBox.Location = New System.Drawing.Point(3, 3)
        Me.cCheckBox.Name = "cCheckBox"
        Me.cCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cCheckBox.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.cCheckBox.Size = New System.Drawing.Size(13, 13)
        Me.cCheckBox.TabIndex = 0
        Me.cCheckBox.Text = "CCheckBox1"
        Me.cCheckBox.Translatable = false
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(20, 1)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(53, 17)
        Me.CLabel1.TabIndex = 1
        Me.CLabel1.Text = "Stretch"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file"& _ 
    "s (*.*)|*.*"
        '
        'CPictureViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CPictureViewer"
        Me.Text = "Image Viewer"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        CType(Me.CPictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents CPictureBox1 As Libraries.CBaseControlsLibrary.CPictureBox
    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents btnShow As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnClear As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnClose As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents ColorDialog1 As Windows.Forms.ColorDialog
    Friend WithEvents CFlowLayout2 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents cCheckBox As Libraries.CBaseControlsLibrary.UCCheckBox
    Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents lblPictureNote As Libraries.CBaseControlsLibrary.CLabel
End Class
