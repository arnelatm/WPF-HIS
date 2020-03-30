<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SampleMessagingForm
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
        Me.button4 = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.checkBoxUseOtherFont = New System.Windows.Forms.CheckBox()
        Me.labelMaxWidthInPercent = New System.Windows.Forms.Label()
        Me.labelMaxHeightInPercent = New System.Windows.Forms.Label()
        Me.trackBarMaxHeight = New System.Windows.Forms.TrackBar()
        Me.trackBarMaxWidth = New System.Windows.Forms.TrackBar()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label1 = New System.Windows.Forms.Label()
        CType(Me.trackBarMaxHeight,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.trackBarMaxWidth,System.ComponentModel.ISupportInitialize).BeginInit
        Me.groupBox1.SuspendLayout
        Me.panel1.SuspendLayout
        Me.SuspendLayout
        '
        'button4
        '
        Me.button4.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.button4.Location = New System.Drawing.Point(323, 176)
        Me.button4.Margin = New System.Windows.Forms.Padding(4)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(224, 100)
        Me.button4.TabIndex = 8
        Me.button4.Text = "FlexibleMessageBox many rows: "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"One box to rule them all... :-)"
        Me.button4.UseVisualStyleBackColor = false
        '
        'button3
        '
        Me.button3.BackColor = System.Drawing.Color.Tomato
        Me.button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.button3.Location = New System.Drawing.Point(323, 61)
        Me.button3.Margin = New System.Windows.Forms.Padding(4)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(224, 100)
        Me.button3.TabIndex = 7
        Me.button3.Text = "Wrong .NET MessageBox: "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Too many rows to show..."
        Me.button3.UseVisualStyleBackColor = false
        '
        'button2
        '
        Me.button2.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.button2.Location = New System.Drawing.Point(26, 176)
        Me.button2.Margin = New System.Windows.Forms.Padding(4)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(224, 100)
        Me.button2.TabIndex = 6
        Me.button2.Text = "FlexibleMessageBox: "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Using more parameters and a dialog result..."
        Me.button2.UseVisualStyleBackColor = false
        '
        'button1
        '
        Me.button1.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.button1.Location = New System.Drawing.Point(26, 61)
        Me.button1.Margin = New System.Windows.Forms.Padding(4)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(224, 100)
        Me.button1.TabIndex = 5
        Me.button1.Text = "FlexibleMessageBox: "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"A simple call..."
        Me.button1.UseVisualStyleBackColor = false
        '
        'checkBoxUseOtherFont
        '
        Me.checkBoxUseOtherFont.AutoSize = true
        Me.checkBoxUseOtherFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.checkBoxUseOtherFont.Location = New System.Drawing.Point(21, 298)
        Me.checkBoxUseOtherFont.Margin = New System.Windows.Forms.Padding(4)
        Me.checkBoxUseOtherFont.Name = "checkBoxUseOtherFont"
        Me.checkBoxUseOtherFont.Size = New System.Drawing.Size(304, 20)
        Me.checkBoxUseOtherFont.TabIndex = 9
        Me.checkBoxUseOtherFont.Text = "Example: Use italic style 12-point ""Impact"" Font"
        Me.checkBoxUseOtherFont.UseVisualStyleBackColor = true
        '
        'labelMaxWidthInPercent
        '
        Me.labelMaxWidthInPercent.AutoSize = true
        Me.labelMaxWidthInPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.labelMaxWidthInPercent.Location = New System.Drawing.Point(287, 245)
        Me.labelMaxWidthInPercent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelMaxWidthInPercent.Name = "labelMaxWidthInPercent"
        Me.labelMaxWidthInPercent.Size = New System.Drawing.Size(81, 16)
        Me.labelMaxWidthInPercent.TabIndex = 8
        Me.labelMaxWidthInPercent.Text = "<MaxWidth>"
        '
        'labelMaxHeightInPercent
        '
        Me.labelMaxHeightInPercent.AutoSize = true
        Me.labelMaxHeightInPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.labelMaxHeightInPercent.Location = New System.Drawing.Point(19, 30)
        Me.labelMaxHeightInPercent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelMaxHeightInPercent.Name = "labelMaxHeightInPercent"
        Me.labelMaxHeightInPercent.Size = New System.Drawing.Size(86, 16)
        Me.labelMaxHeightInPercent.TabIndex = 5
        Me.labelMaxHeightInPercent.Text = "<MaxHeight>"
        '
        'trackBarMaxHeight
        '
        Me.trackBarMaxHeight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trackBarMaxHeight.LargeChange = 2
        Me.trackBarMaxHeight.Location = New System.Drawing.Point(22, 55)
        Me.trackBarMaxHeight.Margin = New System.Windows.Forms.Padding(4)
        Me.trackBarMaxHeight.Minimum = 2
        Me.trackBarMaxHeight.Name = "trackBarMaxHeight"
        Me.trackBarMaxHeight.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trackBarMaxHeight.Size = New System.Drawing.Size(45, 200)
        Me.trackBarMaxHeight.TabIndex = 6
        Me.trackBarMaxHeight.Value = 2
        '
        'trackBarMaxWidth
        '
        Me.trackBarMaxWidth.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trackBarMaxWidth.LargeChange = 2
        Me.trackBarMaxWidth.Location = New System.Drawing.Point(84, 245)
        Me.trackBarMaxWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.trackBarMaxWidth.Minimum = 2
        Me.trackBarMaxWidth.Name = "trackBarMaxWidth"
        Me.trackBarMaxWidth.Size = New System.Drawing.Size(221, 45)
        Me.trackBarMaxWidth.TabIndex = 7
        Me.trackBarMaxWidth.Value = 2
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.panel1)
        Me.groupBox1.Controls.Add(Me.checkBoxUseOtherFont)
        Me.groupBox1.Controls.Add(Me.labelMaxWidthInPercent)
        Me.groupBox1.Controls.Add(Me.labelMaxHeightInPercent)
        Me.groupBox1.Controls.Add(Me.trackBarMaxHeight)
        Me.groupBox1.Controls.Add(Me.trackBarMaxWidth)
        Me.groupBox1.Location = New System.Drawing.Point(594, 6)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(396, 334)
        Me.groupBox1.TabIndex = 9
        Me.groupBox1.TabStop = false
        Me.groupBox1.Text = "Change common static parameters"
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Location = New System.Drawing.Point(84, 55)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(201, 179)
        Me.panel1.TabIndex = 5
        '
        'label1
        '
        Me.label1.AutoSize = true
        Me.label1.Location = New System.Drawing.Point(26, 58)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(154, 52)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Please choose the maximum "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"width and height for all "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"FlexibleMessageBox instanc"& _ 
    "es "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"in percent of the working area."
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SampleMessagingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 356)
        Me.Controls.Add(Me.button4)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "SampleMessagingForm"
        Me.Text = "SampleMessagingForm"
        CType(Me.trackBarMaxHeight,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.trackBarMaxWidth,System.ComponentModel.ISupportInitialize).EndInit
        Me.groupBox1.ResumeLayout(false)
        Me.groupBox1.PerformLayout
        Me.panel1.ResumeLayout(false)
        Me.panel1.PerformLayout
        Me.ResumeLayout(false)

End Sub

    Private WithEvents button4 As Button
    Private WithEvents button3 As Button
    Private WithEvents button2 As Button
    Private WithEvents button1 As Button
    Private WithEvents checkBoxUseOtherFont As CheckBox
    Private WithEvents labelMaxWidthInPercent As Label
    Private WithEvents labelMaxHeightInPercent As Label
    Private WithEvents trackBarMaxHeight As TrackBar
    Private WithEvents trackBarMaxWidth As TrackBar
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents panel1 As Panel
    Private WithEvents label1 As Label
End Class
