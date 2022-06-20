<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CbcFlagSelector
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
        Me.components = New System.ComponentModel.Container()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.WbcFlag = New AATM.Libraries.CBaseControlsLibrary.CGroupBox()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CRadioButton1 = New AATM.Libraries.CBaseControlsLibrary.CRadioButton()
        Me.CRadioButton2 = New AATM.Libraries.CBaseControlsLibrary.CRadioButton()
        Me.CRadioButton3 = New AATM.Libraries.CBaseControlsLibrary.CRadioButton()
        Me.CRadioButton4 = New AATM.Libraries.CBaseControlsLibrary.CRadioButton()
        Me.WbcFlag.SuspendLayout
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(10, 10)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(295, 17)
        Me.CLabel1.TabIndex = 1
        Me.CLabel1.Text = "Please select the result you want to generate!"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = false
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(109, 382)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(90, 25)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DesignerSelected = false
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(241, 382)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'WbcFlag
        '
        Me.WbcFlag.AutoSize = true
        Me.WbcFlag.BackColor = System.Drawing.Color.Transparent
        Me.WbcFlag.Controls.Add(Me.CFlowLayout1)
        Me.WbcFlag.DisplayOnly = true
        Me.WbcFlag.Location = New System.Drawing.Point(12, 49)
        Me.WbcFlag.Name = "WbcFlag"
        Me.WbcFlag.Size = New System.Drawing.Size(235, 139)
        Me.WbcFlag.TabIndex = 5
        Me.WbcFlag.TabStop = false
        Me.WbcFlag.Text = "WBC Flag"
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.CRadioButton1)
        Me.CFlowLayout1.Controls.Add(Me.CRadioButton2)
        Me.CFlowLayout1.Controls.Add(Me.CRadioButton3)
        Me.CFlowLayout1.Controls.Add(Me.CRadioButton4)
        Me.CFlowLayout1.Location = New System.Drawing.Point(7, 20)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(200, 100)
        Me.CFlowLayout1.TabIndex = 0
        '
        'CRadioButton1
        '
        Me.CRadioButton1.AutoSize = true
        Me.CRadioButton1.Enabled = false
        Me.CRadioButton1.Location = New System.Drawing.Point(3, 3)
        Me.CRadioButton1.Name = "CRadioButton1"
        Me.CRadioButton1.Size = New System.Drawing.Size(97, 17)
        Me.CRadioButton1.TabIndex = 0
        Me.CRadioButton1.TabStop = true
        Me.CRadioButton1.Text = "CRadioButton1"
        Me.CRadioButton1.UseVisualStyleBackColor = true
        '
        'CRadioButton2
        '
        Me.CRadioButton2.AutoSize = true
        Me.CRadioButton2.Enabled = false
        Me.CRadioButton2.Location = New System.Drawing.Point(3, 26)
        Me.CRadioButton2.Name = "CRadioButton2"
        Me.CRadioButton2.Size = New System.Drawing.Size(97, 17)
        Me.CRadioButton2.TabIndex = 1
        Me.CRadioButton2.TabStop = true
        Me.CRadioButton2.Text = "CRadioButton2"
        Me.CRadioButton2.UseVisualStyleBackColor = true
        '
        'CRadioButton3
        '
        Me.CRadioButton3.AutoSize = true
        Me.CRadioButton3.Enabled = false
        Me.CRadioButton3.Location = New System.Drawing.Point(3, 49)
        Me.CRadioButton3.Name = "CRadioButton3"
        Me.CRadioButton3.Size = New System.Drawing.Size(97, 17)
        Me.CRadioButton3.TabIndex = 2
        Me.CRadioButton3.TabStop = true
        Me.CRadioButton3.Text = "CRadioButton3"
        Me.CRadioButton3.UseVisualStyleBackColor = true
        '
        'CRadioButton4
        '
        Me.CRadioButton4.AutoSize = true
        Me.CRadioButton4.Enabled = false
        Me.CRadioButton4.Location = New System.Drawing.Point(3, 72)
        Me.CRadioButton4.Name = "CRadioButton4"
        Me.CRadioButton4.Size = New System.Drawing.Size(97, 17)
        Me.CRadioButton4.TabIndex = 3
        Me.CRadioButton4.TabStop = true
        Me.CRadioButton4.Text = "CRadioButton4"
        Me.CRadioButton4.UseVisualStyleBackColor = true
        '
        'CbcFlagSelector
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(470, 419)
        Me.Controls.Add(Me.WbcFlag)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.CLabel1)
        Me.Name = "CbcFlagSelector"
        Me.Text = "Cbc Report Selector"
        Me.WbcFlag.ResumeLayout(false)
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents WbcFlag As Libraries.CBaseControlsLibrary.CGroupBox
    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents CRadioButton1 As Libraries.CBaseControlsLibrary.CRadioButton
    Friend WithEvents CRadioButton2 As Libraries.CBaseControlsLibrary.CRadioButton
    Friend WithEvents CRadioButton3 As Libraries.CBaseControlsLibrary.CRadioButton
    Friend WithEvents CRadioButton4 As Libraries.CBaseControlsLibrary.CRadioButton
End Class
