Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.buttonStart = New System.Windows.Forms.Button()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.labelProgress = New System.Windows.Forms.Label()
        Me.listBox = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'buttonCancel
        '
        Me.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.buttonCancel.Enabled = false
        Me.buttonCancel.Location = New System.Drawing.Point(177, 346)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
        Me.buttonCancel.TabIndex = 10
        Me.buttonCancel.Text = "&Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = true
        '
        'buttonStart
        '
        Me.buttonStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.buttonStart.Location = New System.Drawing.Point(96, 346)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 9
        Me.buttonStart.Text = "&Start"
        Me.buttonStart.UseVisualStyleBackColor = true
        '
        'progressBar
        '
        Me.progressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
                                       Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.progressBar.Enabled = false
        Me.progressBar.Location = New System.Drawing.Point(14, 317)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(321, 23)
        Me.progressBar.TabIndex = 8
        '
        'labelProgress
        '
        Me.labelProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
                                         Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.labelProgress.Location = New System.Drawing.Point(14, 301)
        Me.labelProgress.Name = "labelProgress"
        Me.labelProgress.Size = New System.Drawing.Size(321, 13)
        Me.labelProgress.TabIndex = 7
        '
        'listBox
        '
        Me.listBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
                                    Or System.Windows.Forms.AnchorStyles.Left)  _
                                   Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.listBox.Enabled = false
        Me.listBox.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.listBox.FormattingEnabled = true
        Me.listBox.ItemHeight = 14
        Me.listBox.Location = New System.Drawing.Point(14, 35)
        Me.listBox.Name = "listBox"
        Me.listBox.Size = New System.Drawing.Size(321, 256)
        Me.listBox.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.Location = New System.Drawing.Point(12, 378)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "&Start"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 404)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.progressBar)
        Me.Controls.Add(Me.labelProgress)
        Me.Controls.Add(Me.listBox)
        Me.Name = "FormMain"
        Me.Text = "Demo"
        Me.ResumeLayout(false)

    End Sub

    Private WithEvents buttonCancel As Button
    Private WithEvents buttonStart As Button
    Private WithEvents progressBar As ProgressBar
    Private WithEvents labelProgress As Label
    Private WithEvents listBox As ListBox
    Private WithEvents Button1 As Button
End Class
