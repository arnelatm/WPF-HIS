<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackgroundWorkerForm
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
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cancelWorkButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPercent = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(279, 23)
        Me.ProgressBar1.TabIndex = 0
        '
        'cancelWorkButton
        '
        Me.cancelWorkButton.Location = New System.Drawing.Point(207, 41)
        Me.cancelWorkButton.Name = "cancelWorkButton"
        Me.cancelWorkButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelWorkButton.TabIndex = 1
        Me.cancelWorkButton.Text = "Cancel"
        Me.cancelWorkButton.UseVisualStyleBackColor = true
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(3, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Progress : "
        '
        'lblPercent
        '
        Me.lblPercent.AutoSize = true
        Me.lblPercent.Location = New System.Drawing.Point(56, 42)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(39, 13)
        Me.lblPercent.TabIndex = 3
        Me.lblPercent.Text = "Label2"
        Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(92, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "%"
        '
        'BackgroundWorkerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 67)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblPercent)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cancelWorkButton)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Name = "BackgroundWorkerForm"
        Me.Text = "BackgroundWorkerForm"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As Windows.Forms.ProgressBar
    Friend WithEvents cancelWorkButton As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lblPercent As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
End Class
