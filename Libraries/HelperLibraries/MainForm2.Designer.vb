Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm2
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
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.button6 = New System.Windows.Forms.Button()
        Me.button5 = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.button4 = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = true
        Me.lblMessage.Location = New System.Drawing.Point(12, 237)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(38, 13)
        Me.lblMessage.TabIndex = 25
        Me.lblMessage.Text = "Label2"
        '
        'button6
        '
        Me.button6.Location = New System.Drawing.Point(12, 197)
        Me.button6.Name = "button6"
        Me.button6.Size = New System.Drawing.Size(260, 23)
        Me.button6.TabIndex = 24
        Me.button6.Text = "Show a wait window that cancels part way through."
        Me.button6.UseVisualStyleBackColor = true
        '
        'button5
        '
        Me.button5.Location = New System.Drawing.Point(12, 168)
        Me.button5.Name = "button5"
        Me.button5.Size = New System.Drawing.Size(260, 23)
        Me.button5.TabIndex = 23
        Me.button5.Text = "Show a wait window that throws and exception."
        Me.button5.UseVisualStyleBackColor = true
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(13, 121)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(124, 20)
        Me.textBox1.TabIndex = 21
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(143, 98)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(129, 64)
        Me.button4.TabIndex = 20
        Me.button4.Text = "Show a wait window with custom args for the worker method"
        Me.button4.UseVisualStyleBackColor = true
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(12, 69)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(260, 23)
        Me.button3.TabIndex = 19
        Me.button3.Text = "Show a wait window with a changing message"
        Me.button3.UseVisualStyleBackColor = true
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(12, 40)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(260, 23)
        Me.button2.TabIndex = 18
        Me.button2.Text = "Show a wait window with a custom message"
        Me.button2.UseVisualStyleBackColor = true
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(12, 11)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(260, 23)
        Me.button1.TabIndex = 17
        Me.button1.Text = "Show a standard wait window"
        Me.button1.UseVisualStyleBackColor = true
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(12, 98)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(100, 23)
        Me.label1.TabIndex = 22
        Me.label1.Text = "Custom args:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = true
        Me.BackgroundWorker1.WorkerSupportsCancellation = true
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(65, 237)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(207, 23)
        Me.ProgressBar1.TabIndex = 26
        '
        'MainForm2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.button6)
        Me.Controls.Add(Me.button5)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.button4)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label1)
        Me.Name = "MainForm2"
        Me.Text = "MainForm2"
        Me.ResumeLayout(false)
        Me.PerformLayout

    End Sub

    Friend WithEvents lblMessage As Label
    Private WithEvents button6 As Button
    Private WithEvents button5 As Button
    Private WithEvents textBox1 As TextBox
    Private WithEvents button4 As Button
    Private WithEvents button3 As Button
    Private WithEvents button2 As Button
    Private WithEvents button1 As Button
    Private WithEvents label1 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
