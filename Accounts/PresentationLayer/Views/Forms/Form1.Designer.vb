<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits AATM.Libraries.CBaseControlsLibrary.CForm

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
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CTextBox2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtOldNote = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnQuit = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnTranslate = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.SuspendLayout
        '
        'CTextBox1
        '
        Me.CTextBox1.BackColor = System.Drawing.Color.White
        Me.CTextBox1.BegFindValue = Nothing
        Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox1.ComputedValue = false
        Me.CTextBox1.CustomFormat = Nothing
        Me.CTextBox1.DataBoundControl = true
        Me.CTextBox1.EditingMode = true
        Me.CTextBox1.EndFindValue = Nothing
        Me.CTextBox1.FieldName = Nothing
        Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CTextBox1.FindEnabled = false
        Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox1.ForeColor = System.Drawing.Color.Black
        Me.CTextBox1.LinkedLabel = Nothing
        Me.CTextBox1.Location = New System.Drawing.Point(206, 31)
        Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox1.MaximumValue = Nothing
        Me.CTextBox1.MinimumValue = Nothing
        Me.CTextBox1.Name = "CTextBox1"
        Me.CTextBox1.OldValue = Nothing
        Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CTextBox1.Size = New System.Drawing.Size(430, 23)
        Me.CTextBox1.TabIndex = 0
        '
        'CTextBox2
        '
        Me.CTextBox2.BackColor = System.Drawing.Color.White
        Me.CTextBox2.BegFindValue = Nothing
        Me.CTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox2.ComputedValue = false
        Me.CTextBox2.CustomFormat = Nothing
        Me.CTextBox2.DataBoundControl = true
        Me.CTextBox2.EditingMode = true
        Me.CTextBox2.EndFindValue = Nothing
        Me.CTextBox2.FieldName = Nothing
        Me.CTextBox2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CTextBox2.FindEnabled = false
        Me.CTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox2.ForeColor = System.Drawing.Color.Black
        Me.CTextBox2.LinkedLabel = Nothing
        Me.CTextBox2.Location = New System.Drawing.Point(206, 56)
        Me.CTextBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox2.MaximumValue = Nothing
        Me.CTextBox2.MinimumValue = Nothing
        Me.CTextBox2.Name = "CTextBox2"
        Me.CTextBox2.OldValue = Nothing
        Me.CTextBox2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CTextBox2.Size = New System.Drawing.Size(430, 23)
        Me.CTextBox2.TabIndex = 1
        '
        'txtOldNote
        '
        Me.txtOldNote.AutoSize = true
        Me.txtOldNote.BackColor = System.Drawing.Color.Transparent
        Me.txtOldNote.DisplayOnly = true
        Me.txtOldNote.EditingMode = false
        Me.txtOldNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtOldNote.Location = New System.Drawing.Point(13, 37)
        Me.txtOldNote.Margin = New System.Windows.Forms.Padding(1)
        Me.txtOldNote.Name = "txtOldNote"
        Me.txtOldNote.Size = New System.Drawing.Size(42, 17)
        Me.txtOldNote.TabIndex = 2
        Me.txtOldNote.Text = "Note "
        Me.txtOldNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(13, 56)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(172, 17)
        Me.CLabel1.TabIndex = 3
        Me.CLabel1.Text = "Note Translation in Arabic"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnQuit
        '
        Me.btnQuit.DesignerSelected = false
        Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnQuit.DisplayOnly = true
        Me.btnQuit.ImageIndex = 0
        Me.btnQuit.Location = New System.Drawing.Point(252, 83)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.OriginalImageName = Nothing
        Me.btnQuit.SecurityKey = ""
        Me.btnQuit.Size = New System.Drawing.Size(90, 25)
        Me.btnQuit.TabIndex = 4
        Me.btnQuit.Text = "Quit"
        '
        'btnTranslate
        '
        Me.btnTranslate.DesignerSelected = true
        Me.btnTranslate.DisplayOnly = true
        Me.btnTranslate.ImageIndex = 0
        Me.btnTranslate.Location = New System.Drawing.Point(363, 83)
        Me.btnTranslate.Name = "btnTranslate"
        Me.btnTranslate.OriginalImageName = Nothing
        Me.btnTranslate.SecurityKey = ""
        Me.btnTranslate.Size = New System.Drawing.Size(90, 25)
        Me.btnTranslate.TabIndex = 5
        Me.btnTranslate.Text = "Translate"
        '
        'Form1
        '
        Me.AcceptButton = Me.btnTranslate
        Me.CancelButton = Me.btnQuit
        Me.ClientSize = New System.Drawing.Size(705, 119)
        Me.Controls.Add(Me.btnTranslate)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.txtOldNote)
        Me.Controls.Add(Me.CTextBox2)
        Me.Controls.Add(Me.CTextBox1)
        Me.Name = "Form1"
        Me.Text = "Notes Translator"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents CTextBox1 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents CTextBox2 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents txtOldNote As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents btnQuit As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnTranslate As Libraries.CBaseControlsLibrary.CButton
End Class
