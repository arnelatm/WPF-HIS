<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DisplayProgressForm
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
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblPercentage = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 33)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(681, 23)
        Me.ProgressBar.TabIndex = 0
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = true
        Me.lblDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblDescription.ForeColor = System.Drawing.Color.Black
        Me.lblDescription.Location = New System.Drawing.Point(13, 14)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(182, 17)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "Please Wait Processing Request...."
        Me.lblDescription.UseCompatibleTextRendering = true
        '
        'lblPercentage
        '
        Me.lblPercentage.AutoSize = true
        Me.lblPercentage.BackColor = System.Drawing.Color.LightCoral
        Me.lblPercentage.Location = New System.Drawing.Point(12, 59)
        Me.lblPercentage.Name = "lblPercentage"
        Me.lblPercentage.Size = New System.Drawing.Size(121, 13)
        Me.lblPercentage.TabIndex = 2
        Me.lblPercentage.Text = "Percentage Processed :"
        '
        'DisplayProgressForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.ClientSize = New System.Drawing.Size(705, 131)
        Me.Controls.Add(Me.lblPercentage)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.ProgressBar)
        Me.DoubleBuffered = true
        Me.KeyPreview = true
        Me.Name = "DisplayProgressForm"
        Me.Text = "Form1"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Private WithEvents ProgressBar As Windows.Forms.ProgressBar
    Private WithEvents lblPercentage As Windows.Forms.Label
    Private WithEvents lblDescription As Windows.Forms.Label
End Class
