<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WaitingForm
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
        Me.label2 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.panel1.SuspendLayout
        Me.SuspendLayout
        '
        'label2
        '
        Me.label2.AutoSize = true
        Me.label2.Font = New System.Drawing.Font("Microsoft YaHei", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.label2.Location = New System.Drawing.Point(43, 57)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(110, 21)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Please Wait..."
        '
        'panel1
        '
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.ProgressBar1)
        Me.panel1.Controls.Add(Me.label2)
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(215, 100)
        Me.panel1.TabIndex = 2
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(4, 22)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(206, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 1
        '
        'WaitingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(213, 98)
        Me.ControlBox = false
        Me.Controls.Add(Me.panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "WaitingForm"
        Me.panel1.ResumeLayout(false)
        Me.panel1.PerformLayout
        Me.ResumeLayout(false)

End Sub

    Private WithEvents label2 As Windows.Forms.Label
    Private WithEvents panel1 As Windows.Forms.Panel
    Friend WithEvents ProgressBar1 As Windows.Forms.ProgressBar
End Class
