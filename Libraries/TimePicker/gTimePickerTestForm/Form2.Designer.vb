<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim TimeColors1 As gTimePickerControl.TimeColors = New gTimePickerControl.TimeColors
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GTimePicker1 = New gTimePickerControl.gTimePicker
        Me.GDateTimePicker1 = New gTimePickerControl.gDateTimePicker
        Me.GDateTimePicker4 = New gTimePickerControl.gDateTimePicker
        Me.GDateTimePicker7 = New gTimePickerControl.gDateTimePicker
        Me.GDateTimePicker6 = New gTimePickerControl.gDateTimePicker
        Me.GDateTimePicker5 = New gTimePickerControl.gDateTimePicker
        Me.GDateTimePicker3 = New gTimePickerControl.gDateTimePicker
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(347, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Other NULL Examples"
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.NullValue = "--EMPTY--"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(10, 48)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(327, 164)
        Me.DataGridView1.TabIndex = 3
        '
        'GTimePicker1
        '
        Me.GTimePicker1.ButtonForeColor = System.Drawing.Color.DarkSlateBlue
        Me.GTimePicker1.Hr24 = True
        Me.GTimePicker1.Location = New System.Drawing.Point(243, 14)
        Me.GTimePicker1.Name = "GTimePicker1"
        Me.GTimePicker1.NullAlpha = 100
        Me.GTimePicker1.NullColorA = System.Drawing.Color.RoyalBlue
        Me.GTimePicker1.NullColorB = System.Drawing.Color.PeachPuff
        Me.GTimePicker1.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.SmallConfetti
        Me.GTimePicker1.NullText = "No Time"
        Me.GTimePicker1.NullTextColor = System.Drawing.Color.Red
        Me.GTimePicker1.NullTextInFront = False
        Me.GTimePicker1.Size = New System.Drawing.Size(94, 23)
        Me.GTimePicker1.TabIndex = 4
        Me.GTimePicker1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.GTimePicker1.TextBackColor = System.Drawing.Color.White
        Me.GTimePicker1.TextFont = New System.Drawing.Font("Arial", 10.0!)
        Me.GTimePicker1.TextForeColor = System.Drawing.Color.Black
        Me.GTimePicker1.Time = Nothing
        Me.GTimePicker1.TimeAMPM = gTimePickerControl.gTimePickerCntrl.eTimeAMPM.AM
        TimeColors1.BackGround = System.Drawing.Color.MistyRose
        TimeColors1.Box = System.Drawing.Color.Brown
        TimeColors1.DisplayTime = System.Drawing.Color.MistyRose
        TimeColors1.FaceInner = System.Drawing.Color.MistyRose
        TimeColors1.FaceOuter = System.Drawing.Color.Coral
        TimeColors1.FrameInner = System.Drawing.Color.LightCoral
        TimeColors1.FrameOuter = System.Drawing.Color.Red
        TimeColors1.Hour = System.Drawing.Color.DarkRed
        TimeColors1.HourHand = System.Drawing.Color.Red
        TimeColors1.Minute = System.Drawing.Color.Firebrick
        TimeColors1.MinuteHand = System.Drawing.Color.Firebrick
        TimeColors1.MinutePlus = System.Drawing.Color.MistyRose
        TimeColors1.TimeAMPM_OFF = System.Drawing.Color.RosyBrown
        TimeColors1.TimeAMPM_ON = System.Drawing.Color.MistyRose
        Me.GTimePicker1.TimeColors = TimeColors1
        Me.GTimePicker1.TrueHour = True
        '
        'GDateTimePicker1
        '
        Me.GDateTimePicker1.BackFillColor = System.Drawing.SystemColors.Window
        Me.GDateTimePicker1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GDateTimePicker1.gFormat = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.GDateTimePicker1.gFormatString = "MM/dd/yyyy"
        Me.GDateTimePicker1.gValue = Nothing
        Me.GDateTimePicker1.Location = New System.Drawing.Point(10, 14)
        Me.GDateTimePicker1.Name = "GDateTimePicker1"
        Me.GDateTimePicker1.NullAlpha = 100
        Me.GDateTimePicker1.NullColorA = System.Drawing.Color.RoyalBlue
        Me.GDateTimePicker1.NullColorB = System.Drawing.Color.PeachPuff
        Me.GDateTimePicker1.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.SmallConfetti
        Me.GDateTimePicker1.NullTextColor = System.Drawing.Color.Red
        Me.GDateTimePicker1.NullTextInFront = False
        Me.GDateTimePicker1.Size = New System.Drawing.Size(227, 23)
        Me.GDateTimePicker1.TabIndex = 0
        '
        'GDateTimePicker4
        '
        Me.GDateTimePicker4.BackColor = System.Drawing.Color.DarkOrange
        Me.GDateTimePicker4.BackFillColor = System.Drawing.SystemColors.Window
        Me.GDateTimePicker4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GDateTimePicker4.gFormat = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.GDateTimePicker4.gFormatString = "MM/dd/yyyy"
        Me.GDateTimePicker4.gValue = Nothing
        Me.GDateTimePicker4.Location = New System.Drawing.Point(350, 125)
        Me.GDateTimePicker4.Name = "GDateTimePicker4"
        Me.GDateTimePicker4.NullAlpha = 125
        Me.GDateTimePicker4.NullColorA = System.Drawing.Color.RoyalBlue
        Me.GDateTimePicker4.NullColorB = System.Drawing.Color.White
        Me.GDateTimePicker4.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.WideDownwardDiagonal
        Me.GDateTimePicker4.NullText = "No Date Chosen"
        Me.GDateTimePicker4.NullTextColor = System.Drawing.Color.DarkMagenta
        Me.GDateTimePicker4.NullTextInFront = False
        Me.GDateTimePicker4.Size = New System.Drawing.Size(200, 22)
        Me.GDateTimePicker4.TabIndex = 1
        '
        'GDateTimePicker7
        '
        Me.GDateTimePicker7.BackFillColor = System.Drawing.SystemColors.Window
        Me.GDateTimePicker7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GDateTimePicker7.gFormat = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.GDateTimePicker7.gFormatString = "MM/dd/yyyy"
        Me.GDateTimePicker7.gValue = Nothing
        Me.GDateTimePicker7.Location = New System.Drawing.Point(350, 153)
        Me.GDateTimePicker7.Name = "GDateTimePicker7"
        Me.GDateTimePicker7.NullColorA = System.Drawing.Color.White
        Me.GDateTimePicker7.NullColorB = System.Drawing.Color.ForestGreen
        Me.GDateTimePicker7.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.DarkHorizontal
        Me.GDateTimePicker7.NullText = ""
        Me.GDateTimePicker7.NullTextColor = System.Drawing.Color.Black
        Me.GDateTimePicker7.NullTextInFront = False
        Me.GDateTimePicker7.Size = New System.Drawing.Size(200, 22)
        Me.GDateTimePicker7.TabIndex = 1
        '
        'GDateTimePicker6
        '
        Me.GDateTimePicker6.BackFillColor = System.Drawing.SystemColors.Window
        Me.GDateTimePicker6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GDateTimePicker6.gFormat = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.GDateTimePicker6.gFormatString = "MM/dd/yyyy"
        Me.GDateTimePicker6.gValue = Nothing
        Me.GDateTimePicker6.Location = New System.Drawing.Point(350, 41)
        Me.GDateTimePicker6.Name = "GDateTimePicker6"
        Me.GDateTimePicker6.NullColorA = System.Drawing.Color.Silver
        Me.GDateTimePicker6.NullColorB = System.Drawing.Color.White
        Me.GDateTimePicker6.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.Percent50
        Me.GDateTimePicker6.NullTextColor = System.Drawing.Color.Black
        Me.GDateTimePicker6.NullTextInFront = False
        Me.GDateTimePicker6.Size = New System.Drawing.Size(200, 22)
        Me.GDateTimePicker6.TabIndex = 1
        '
        'GDateTimePicker5
        '
        Me.GDateTimePicker5.BackFillColor = System.Drawing.SystemColors.Window
        Me.GDateTimePicker5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GDateTimePicker5.gFormat = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.GDateTimePicker5.gFormatString = "MM/dd/yyyy"
        Me.GDateTimePicker5.gValue = Nothing
        Me.GDateTimePicker5.Location = New System.Drawing.Point(350, 97)
        Me.GDateTimePicker5.Name = "GDateTimePicker5"
        Me.GDateTimePicker5.NullAlpha = 255
        Me.GDateTimePicker5.NullColorA = System.Drawing.Color.GhostWhite
        Me.GDateTimePicker5.NullColorB = System.Drawing.Color.White
        Me.GDateTimePicker5.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.Percent10
        Me.GDateTimePicker5.NullText = "Enter Date Here"
        Me.GDateTimePicker5.NullTextColor = System.Drawing.Color.DarkSlateBlue
        Me.GDateTimePicker5.NullTextInFront = False
        Me.GDateTimePicker5.Size = New System.Drawing.Size(200, 22)
        Me.GDateTimePicker5.TabIndex = 1
        '
        'GDateTimePicker3
        '
        Me.GDateTimePicker3.BackFillColor = System.Drawing.SystemColors.Window
        Me.GDateTimePicker3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GDateTimePicker3.gFormat = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.GDateTimePicker3.gFormatString = "MM/dd/yyyy"
        Me.GDateTimePicker3.gValue = Nothing
        Me.GDateTimePicker3.Location = New System.Drawing.Point(350, 69)
        Me.GDateTimePicker3.Name = "GDateTimePicker3"
        Me.GDateTimePicker3.NullAlpha = 100
        Me.GDateTimePicker3.NullColorA = System.Drawing.Color.Snow
        Me.GDateTimePicker3.NullColorB = System.Drawing.Color.Firebrick
        Me.GDateTimePicker3.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.DottedDiamond
        Me.GDateTimePicker3.NullText = ""
        Me.GDateTimePicker3.NullTextColor = System.Drawing.Color.Black
        Me.GDateTimePicker3.NullTextInFront = False
        Me.GDateTimePicker3.Size = New System.Drawing.Size(200, 22)
        Me.GDateTimePicker3.TabIndex = 1
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(560, 221)
        Me.Controls.Add(Me.GTimePicker1)
        Me.Controls.Add(Me.GDateTimePicker1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GDateTimePicker4)
        Me.Controls.Add(Me.GDateTimePicker7)
        Me.Controls.Add(Me.GDateTimePicker6)
        Me.Controls.Add(Me.GDateTimePicker5)
        Me.Controls.Add(Me.GDateTimePicker3)
        Me.Name = "Form2"
        Me.Text = "DataBinding"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#Disable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
    Friend WithEvents GDateTimePicker3 As gTimePickerControl.gDateTimePicker
#Enable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
#Disable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
    Friend WithEvents GDateTimePicker4 As gTimePickerControl.gDateTimePicker
#Enable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
#Disable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
    Friend WithEvents GDateTimePicker5 As gTimePickerControl.gDateTimePicker
#Enable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
#Disable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
    Friend WithEvents GDateTimePicker6 As gTimePickerControl.gDateTimePicker
#Enable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
    Friend WithEvents Label1 As System.Windows.Forms.Label
#Disable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
    Friend WithEvents GDateTimePicker7 As gTimePickerControl.gDateTimePicker
#Enable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
#Disable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
    Friend WithEvents GDateTimePicker1 As gTimePickerControl.gDateTimePicker
#Enable Warning BC30002 ' Type 'gTimePickerControl.gDateTimePicker' is not defined.
#Disable Warning BC30002 ' Type 'gTimePickerControl.gTimePicker' is not defined.
    Friend WithEvents GTimePicker1 As gTimePickerControl.gTimePicker
#Enable Warning BC30002 ' Type 'gTimePickerControl.gTimePicker' is not defined.
End Class
