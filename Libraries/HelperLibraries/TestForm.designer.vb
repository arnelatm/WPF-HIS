Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestForm
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
        Me.button6 = New System.Windows.Forms.Button()
        Me.button5 = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.button4 = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout
        '
        'button6
        '
        Me.button6.Location = New System.Drawing.Point(12, 212)
        Me.button6.Name = "button6"
        Me.button6.Size = New System.Drawing.Size(260, 23)
        Me.button6.TabIndex = 15
        Me.button6.Text = "Show a wait window that cancels part way through."
        Me.button6.UseVisualStyleBackColor = true
        '
        'button5
        '
        Me.button5.Location = New System.Drawing.Point(12, 183)
        Me.button5.Name = "button5"
        Me.button5.Size = New System.Drawing.Size(260, 23)
        Me.button5.TabIndex = 14
        Me.button5.Text = "Show a wait window that throws and exception."
        Me.button5.UseVisualStyleBackColor = true
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(13, 136)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(124, 20)
        Me.textBox1.TabIndex = 12
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(143, 113)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(129, 64)
        Me.button4.TabIndex = 11
        Me.button4.Text = "Show a wait window with custom args for the worker method"
        Me.button4.UseVisualStyleBackColor = true
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(12, 84)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(260, 23)
        Me.button3.TabIndex = 10
        Me.button3.Text = "Show a wait window with a changing message"
        Me.button3.UseVisualStyleBackColor = true
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(12, 55)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(260, 23)
        Me.button2.TabIndex = 9
        Me.button2.Text = "Show a wait window with a custom message"
        Me.button2.UseVisualStyleBackColor = true
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(12, 26)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(260, 23)
        Me.button1.TabIndex = 8
        Me.button1.Text = "Show a standard wait window"
        Me.button1.UseVisualStyleBackColor = true
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(12, 113)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(100, 23)
        Me.label1.TabIndex = 13
        Me.label1.Text = "Custom args:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = true
        Me.lblMessage.Location = New System.Drawing.Point(12, 252)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(38, 13)
        Me.lblMessage.TabIndex = 16
        Me.lblMessage.Text = "Label2"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 277)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.button6)
        Me.Controls.Add(Me.button5)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.button4)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label1)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.ResumeLayout(false)
        Me.PerformLayout

    End Sub

    Private WithEvents button6 As Button
    Private WithEvents button5 As Button
    Private WithEvents textBox1 As TextBox
    Private WithEvents button4 As Button
    Private WithEvents button3 As Button
    Private WithEvents button2 As Button
    Private WithEvents button1 As Button
    Private WithEvents label1 As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
