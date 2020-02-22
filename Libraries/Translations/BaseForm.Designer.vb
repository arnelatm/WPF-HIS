<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbLanguagePicker = New System.Windows.Forms.ComboBox()
        Me.TranslatorDAC = New AATM.Libraries.Translations.Dac()
        Me.AppdataDAC = New AATM.Libraries.Translations.Dac()
        Me.StoreCaptions1 = New AATM.Libraries.Translations.StoreCaptions()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.SuspendLayout
        '
        'cmbLanguagePicker
        '
        Me.cmbLanguagePicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cmbLanguagePicker.FormattingEnabled = true
        Me.cmbLanguagePicker.Location = New System.Drawing.Point(677, 1)
        Me.cmbLanguagePicker.Name = "cmbLanguagePicker"
        Me.cmbLanguagePicker.Size = New System.Drawing.Size(121, 21)
        Me.cmbLanguagePicker.TabIndex = 1
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = ""
        Me.TranslatorDAC.DacAccessType = Nothing
        Me.TranslatorDAC.DacDatabase = Nothing
        Me.TranslatorDAC.DacFileName = Nothing
        Me.TranslatorDAC.DacPassword = Nothing
        Me.TranslatorDAC.DacServer = Nothing
        Me.TranslatorDAC.DacUid = Nothing
        Me.TranslatorDAC.DacServerType = Nothing
        '
        'AppdataDAC
        '
        Me.AppdataDAC.Cs = ""
        Me.AppdataDAC.DacAccessType = Nothing
        Me.AppdataDAC.DacDatabase = Nothing
        Me.AppdataDAC.DacFileName = Nothing
        Me.AppdataDAC.DacPassword = Nothing
        Me.AppdataDAC.DacServer = Nothing
        Me.AppdataDAC.DacUid = Nothing
        Me.AppdataDAC.DacServerType = Nothing
        '
        'CLabel2
        '
        Me.CLabel2.AutoSize = true
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(507, 2)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(166, 17)
        Me.CLabel2.TabIndex = 8
        Me.CLabel2.Text = "Language for this screen"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BaseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CLabel2)
        Me.Controls.Add(Me.cmbLanguagePicker)
        Me.Name = "BaseForm"
        Me.Text = "BaseForm"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents cmbLanguagePicker As Windows.Forms.ComboBox
    Friend WithEvents TranslatorDAC As Dac
    Friend WithEvents AppdataDAC As Dac
    Friend WithEvents StoreCaptions1 As StoreCaptions
    Friend WithEvents CLabel2 As CBaseControlsLibrary.CLabel
End Class
