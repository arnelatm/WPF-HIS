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
        Me.floButtons = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.btnShow = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnClear = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnClose = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.lblPictureNote = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.PictureBoxImage = New AATM.Libraries.CBaseControlsLibrary.CPictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.floButtons.SuspendLayout()
        CType(Me.PictureBoxImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.floButtons, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBoxImage, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'floButtons
        '
        Me.floButtons.AutoSize = True
        Me.floButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floButtons.BackColor = System.Drawing.Color.Transparent
        Me.floButtons.Controls.Add(Me.btnShow)
        Me.floButtons.Controls.Add(Me.btnClear)
        Me.floButtons.Controls.Add(Me.btnCancel)
        Me.floButtons.Controls.Add(Me.btnClose)
        Me.floButtons.Controls.Add(Me.lblPictureNote)
        Me.floButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.floButtons.Location = New System.Drawing.Point(3, 467)
        Me.floButtons.Name = "floButtons"
        Me.floButtons.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.floButtons.Size = New System.Drawing.Size(778, 91)
        Me.floButtons.TabIndex = 2
        '
        'btnShow
        '
        Me.btnShow.DesignerSelected = False
        Me.btnShow.ImageIndex = 0
        Me.btnShow.Location = New System.Drawing.Point(642, 3)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.OriginalImageName = Nothing
        Me.btnShow.SecurityKey = ""
        Me.btnShow.Size = New System.Drawing.Size(133, 25)
        Me.btnShow.TabIndex = 0
        Me.btnShow.Text = "Select New Image"
        '
        'btnClear
        '
        Me.btnClear.DesignerSelected = False
        Me.btnClear.ImageIndex = 0
        Me.btnClear.Location = New System.Drawing.Point(507, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.OriginalImageName = Nothing
        Me.btnClear.SecurityKey = ""
        Me.btnClear.Size = New System.Drawing.Size(129, 25)
        Me.btnClear.TabIndex = 1
        Me.btnClear.Text = "Clear the Image"
        '
        'btnCancel
        '
        Me.btnCancel.DesignerSelected = False
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(431, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(70, 25)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        '
        'btnClose
        '
        Me.btnClose.DesignerSelected = False
        Me.floButtons.SetFlowBreak(Me.btnClose, True)
        Me.btnClose.ImageIndex = 0
        Me.btnClose.Location = New System.Drawing.Point(380, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.OriginalImageName = Nothing
        Me.btnClose.SecurityKey = ""
        Me.btnClose.Size = New System.Drawing.Size(45, 25)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Ok"
        '
        'lblPictureNote
        '
        Me.lblPictureNote.AutoSize = True
        Me.lblPictureNote.DisplayOnly = True
        Me.lblPictureNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPictureNote.EditingMode = False
        Me.floButtons.SetFlowBreak(Me.lblPictureNote, True)
        Me.lblPictureNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblPictureNote.Location = New System.Drawing.Point(660, 32)
        Me.lblPictureNote.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPictureNote.Name = "lblPictureNote"
        Me.lblPictureNote.Size = New System.Drawing.Size(117, 17)
        Me.lblPictureNote.TabIndex = 4
        Me.lblPictureNote.Text = "Enter Description"
        Me.lblPictureNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPictureNote.Translatable = True
        '
        'PictureBoxImage
        '
        Me.PictureBoxImage.DisplayOnly = False
        Me.PictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxImage.EditingMode = False
        Me.PictureBoxImage.Location = New System.Drawing.Point(3, 3)
        Me.PictureBoxImage.MaxImageSize = 0
        Me.PictureBoxImage.Name = "PictureBoxImage"
        Me.PictureBoxImage.Size = New System.Drawing.Size(778, 458)
        Me.PictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxImage.TabIndex = 3
        Me.PictureBoxImage.TabStop = False
        Me.PictureBoxImage.Translatable = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" &
    "s (*.*)|*.*"
        '
        'CPictureViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CPictureViewer"
        Me.Text = "Image Viewer"
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.floButtons.ResumeLayout(False)
        Me.floButtons.PerformLayout()
        CType(Me.PictureBoxImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents floButtons As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents btnShow As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnClear As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnClose As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents ColorDialog1 As Windows.Forms.ColorDialog
    Friend WithEvents lblPictureNote As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents PictureBoxImage As Libraries.CBaseControlsLibrary.CPictureBox
End Class
