<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTimeColors
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
        Dim TimeColors1 As TimeColors = New TimeColors
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboColorTheme = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.gTimePickerColors = New gTimePickerCntrl
        Me.Label15 = New System.Windows.Forms.Label
        Me.butExit = New System.Windows.Forms.Button
        Me.ccbBackColor = New ColorComboBox
        Me.ccbMinuteNum = New ColorComboBox
        Me.ccbTimeAMPMOff = New ColorComboBox
        Me.ccbClockFrameInner = New ColorComboBox
        Me.ccbMinuteHand = New ColorComboBox
        Me.ccbTimeAMPMOn = New ColorComboBox
        Me.ccbClockFrameOuter = New ColorComboBox
        Me.ccbHourNum = New ColorComboBox
        Me.ccbDisplayTime = New ColorComboBox
        Me.ccbClockFaceInner = New ColorComboBox
        Me.ccbMinutePlus = New ColorComboBox
        Me.ccbHourHand = New ColorComboBox
        Me.ccbBox = New ColorComboBox
        Me.ccbClockFaceOuter = New ColorComboBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Clock Face Outer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Clock Face Inner"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Clock Face Frame Inner"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Clock Face Frame Outer"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 258)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Box Color Inside"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 285)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Display Time"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 312)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "AM-PM On"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 339)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "AM-PM Off"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(12, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Hour Hand"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(12, 150)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Hour Numbers"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(12, 177)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Minute Hand"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(12, 204)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Minute Numbers"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboColorTheme
        '
        Me.cboColorTheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboColorTheme.FormattingEnabled = True
        Me.cboColorTheme.Items.AddRange(New Object() {"Default", "Blue", "Red", "Green", "Yellow"})
        Me.cboColorTheme.Location = New System.Drawing.Point(388, 42)
        Me.cboColorTheme.Name = "cboColorTheme"
        Me.cboColorTheme.Size = New System.Drawing.Size(120, 28)
        Me.cboColorTheme.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(12, 231)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Mid Minute Dots"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(12, 366)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 13)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Background"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.gTimePickerColors)
        Me.Panel1.Location = New System.Drawing.Point(338, 87)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(216, 213)
        Me.Panel1.TabIndex = 12
        '
        'gTimePickerColors
        '
        Me.gTimePickerColors.Hr24 = True
        Me.gTimePickerColors.Location = New System.Drawing.Point(0, 0)
        Me.gTimePickerColors.Name = "gTimePickerColors"
        Me.gTimePickerColors.ShowMidMins = True
        Me.gTimePickerColors.Size = New System.Drawing.Size(214, 210)
        Me.gTimePickerColors.TabIndex = 0
        Me.gTimePickerColors.Time = "07:00"
        Me.gTimePickerColors.TimeAMPM = gTimePickerCntrl.eTimeAMPM.AM
        TimeColors1.BackGround = System.Drawing.Color.White
        TimeColors1.Box = System.Drawing.Color.White
        TimeColors1.DisplayTime = System.Drawing.Color.Red
        TimeColors1.FaceInner = System.Drawing.Color.White
        TimeColors1.FaceOuter = System.Drawing.Color.LightGoldenrodYellow
        TimeColors1.FrameInner = System.Drawing.Color.AliceBlue
        TimeColors1.FrameOuter = System.Drawing.Color.CornflowerBlue
        TimeColors1.Hour = System.Drawing.Color.DarkBlue
        TimeColors1.HourHand = System.Drawing.Color.DarkBlue
        TimeColors1.Minute = System.Drawing.Color.Blue
        TimeColors1.MinuteHand = System.Drawing.Color.OrangeRed
        TimeColors1.MinutePlus = System.Drawing.Color.Blue
        TimeColors1.TimeAMPM_OFF = System.Drawing.Color.LightSteelBlue
        TimeColors1.TimeAMPM_ON = System.Drawing.Color.Red
        Me.gTimePickerColors.TimeColors = TimeColors1
        Me.gTimePickerColors.TrueHour = True
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(326, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "QuickSet"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'butExit
        '
        Me.butExit.Location = New System.Drawing.Point(514, 366)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(53, 23)
        Me.butExit.TabIndex = 14
        Me.butExit.Text = "Exit"
        Me.butExit.UseVisualStyleBackColor = True
        '
        'ccbBackColor
        '
        Me.ccbBackColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbBackColor.DropDownHeight = 250
        Me.ccbBackColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbBackColor.DropDownWidth = 150
        Me.ccbBackColor.FormattingEnabled = True
        Me.ccbBackColor.IntegralHeight = False
        Me.ccbBackColor.Location = New System.Drawing.Point(116, 362)
        Me.ccbBackColor.Name = "ccbBackColor"
        Me.ccbBackColor.Size = New System.Drawing.Size(187, 21)
        Me.ccbBackColor.TabIndex = 10
        '
        'ccbMinuteNum
        '
        Me.ccbMinuteNum.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbMinuteNum.DropDownHeight = 150
        Me.ccbMinuteNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbMinuteNum.DropDownWidth = 150
        Me.ccbMinuteNum.FormattingEnabled = True
        Me.ccbMinuteNum.IntegralHeight = False
        Me.ccbMinuteNum.Location = New System.Drawing.Point(116, 200)
        Me.ccbMinuteNum.Name = "ccbMinuteNum"
        Me.ccbMinuteNum.Size = New System.Drawing.Size(187, 21)
        Me.ccbMinuteNum.TabIndex = 4
        '
        'ccbTimeAMPMOff
        '
        Me.ccbTimeAMPMOff.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbTimeAMPMOff.DropDownHeight = 150
        Me.ccbTimeAMPMOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbTimeAMPMOff.DropDownWidth = 150
        Me.ccbTimeAMPMOff.FormattingEnabled = True
        Me.ccbTimeAMPMOff.IntegralHeight = False
        Me.ccbTimeAMPMOff.Location = New System.Drawing.Point(116, 335)
        Me.ccbTimeAMPMOff.Name = "ccbTimeAMPMOff"
        Me.ccbTimeAMPMOff.Size = New System.Drawing.Size(187, 21)
        Me.ccbTimeAMPMOff.TabIndex = 4
        '
        'ccbClockFrameInner
        '
        Me.ccbClockFrameInner.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbClockFrameInner.DropDownHeight = 150
        Me.ccbClockFrameInner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbClockFrameInner.DropDownWidth = 150
        Me.ccbClockFrameInner.FormattingEnabled = True
        Me.ccbClockFrameInner.IntegralHeight = False
        Me.ccbClockFrameInner.Location = New System.Drawing.Point(116, 92)
        Me.ccbClockFrameInner.Name = "ccbClockFrameInner"
        Me.ccbClockFrameInner.Size = New System.Drawing.Size(187, 21)
        Me.ccbClockFrameInner.TabIndex = 4
        '
        'ccbMinuteHand
        '
        Me.ccbMinuteHand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbMinuteHand.DropDownHeight = 150
        Me.ccbMinuteHand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbMinuteHand.DropDownWidth = 150
        Me.ccbMinuteHand.FormattingEnabled = True
        Me.ccbMinuteHand.IntegralHeight = False
        Me.ccbMinuteHand.Location = New System.Drawing.Point(116, 173)
        Me.ccbMinuteHand.Name = "ccbMinuteHand"
        Me.ccbMinuteHand.Size = New System.Drawing.Size(187, 21)
        Me.ccbMinuteHand.TabIndex = 3
        '
        'ccbTimeAMPMOn
        '
        Me.ccbTimeAMPMOn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbTimeAMPMOn.DropDownHeight = 150
        Me.ccbTimeAMPMOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbTimeAMPMOn.DropDownWidth = 150
        Me.ccbTimeAMPMOn.FormattingEnabled = True
        Me.ccbTimeAMPMOn.IntegralHeight = False
        Me.ccbTimeAMPMOn.Location = New System.Drawing.Point(116, 308)
        Me.ccbTimeAMPMOn.Name = "ccbTimeAMPMOn"
        Me.ccbTimeAMPMOn.Size = New System.Drawing.Size(187, 21)
        Me.ccbTimeAMPMOn.TabIndex = 3
        '
        'ccbClockFrameOuter
        '
        Me.ccbClockFrameOuter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbClockFrameOuter.DropDownHeight = 150
        Me.ccbClockFrameOuter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbClockFrameOuter.DropDownWidth = 150
        Me.ccbClockFrameOuter.FormattingEnabled = True
        Me.ccbClockFrameOuter.IntegralHeight = False
        Me.ccbClockFrameOuter.Location = New System.Drawing.Point(116, 65)
        Me.ccbClockFrameOuter.Name = "ccbClockFrameOuter"
        Me.ccbClockFrameOuter.Size = New System.Drawing.Size(187, 21)
        Me.ccbClockFrameOuter.TabIndex = 3
        '
        'ccbHourNum
        '
        Me.ccbHourNum.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbHourNum.DropDownHeight = 150
        Me.ccbHourNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbHourNum.DropDownWidth = 150
        Me.ccbHourNum.FormattingEnabled = True
        Me.ccbHourNum.IntegralHeight = False
        Me.ccbHourNum.Location = New System.Drawing.Point(116, 146)
        Me.ccbHourNum.Name = "ccbHourNum"
        Me.ccbHourNum.Size = New System.Drawing.Size(187, 21)
        Me.ccbHourNum.TabIndex = 2
        '
        'ccbDisplayTime
        '
        Me.ccbDisplayTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbDisplayTime.DropDownHeight = 150
        Me.ccbDisplayTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbDisplayTime.DropDownWidth = 150
        Me.ccbDisplayTime.FormattingEnabled = True
        Me.ccbDisplayTime.IntegralHeight = False
        Me.ccbDisplayTime.Location = New System.Drawing.Point(116, 281)
        Me.ccbDisplayTime.Name = "ccbDisplayTime"
        Me.ccbDisplayTime.Size = New System.Drawing.Size(187, 21)
        Me.ccbDisplayTime.TabIndex = 2
        '
        'ccbClockFaceInner
        '
        Me.ccbClockFaceInner.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbClockFaceInner.DropDownHeight = 150
        Me.ccbClockFaceInner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbClockFaceInner.DropDownWidth = 150
        Me.ccbClockFaceInner.FormattingEnabled = True
        Me.ccbClockFaceInner.IntegralHeight = False
        Me.ccbClockFaceInner.Location = New System.Drawing.Point(116, 38)
        Me.ccbClockFaceInner.Name = "ccbClockFaceInner"
        Me.ccbClockFaceInner.Size = New System.Drawing.Size(187, 21)
        Me.ccbClockFaceInner.TabIndex = 2
        '
        'ccbMinutePlus
        '
        Me.ccbMinutePlus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbMinutePlus.DropDownHeight = 150
        Me.ccbMinutePlus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbMinutePlus.DropDownWidth = 150
        Me.ccbMinutePlus.FormattingEnabled = True
        Me.ccbMinutePlus.IntegralHeight = False
        Me.ccbMinutePlus.Location = New System.Drawing.Point(116, 227)
        Me.ccbMinutePlus.Name = "ccbMinutePlus"
        Me.ccbMinutePlus.Size = New System.Drawing.Size(187, 21)
        Me.ccbMinutePlus.TabIndex = 1
        '
        'ccbHourHand
        '
        Me.ccbHourHand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbHourHand.DropDownHeight = 150
        Me.ccbHourHand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbHourHand.DropDownWidth = 150
        Me.ccbHourHand.FormattingEnabled = True
        Me.ccbHourHand.IntegralHeight = False
        Me.ccbHourHand.Location = New System.Drawing.Point(116, 119)
        Me.ccbHourHand.Name = "ccbHourHand"
        Me.ccbHourHand.Size = New System.Drawing.Size(187, 21)
        Me.ccbHourHand.TabIndex = 1
        '
        'ccbBox
        '
        Me.ccbBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbBox.DropDownHeight = 150
        Me.ccbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbBox.DropDownWidth = 150
        Me.ccbBox.FormattingEnabled = True
        Me.ccbBox.IntegralHeight = False
        Me.ccbBox.Location = New System.Drawing.Point(116, 254)
        Me.ccbBox.Name = "ccbBox"
        Me.ccbBox.Size = New System.Drawing.Size(187, 21)
        Me.ccbBox.TabIndex = 1
        '
        'ccbClockFaceOuter
        '
        Me.ccbClockFaceOuter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ccbClockFaceOuter.DropDownHeight = 150
        Me.ccbClockFaceOuter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ccbClockFaceOuter.DropDownWidth = 150
        Me.ccbClockFaceOuter.FormattingEnabled = True
        Me.ccbClockFaceOuter.IntegralHeight = False
        Me.ccbClockFaceOuter.Location = New System.Drawing.Point(116, 11)
        Me.ccbClockFaceOuter.Name = "ccbClockFaceOuter"
        Me.ccbClockFaceOuter.Size = New System.Drawing.Size(187, 21)
        Me.ccbClockFaceOuter.TabIndex = 1
        '
        'dlgTimeColors
        '
        Me.AcceptButton = Me.butExit
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 399)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ccbBackColor)
        Me.Controls.Add(Me.cboColorTheme)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ccbMinuteNum)
        Me.Controls.Add(Me.ccbTimeAMPMOff)
        Me.Controls.Add(Me.ccbClockFrameInner)
        Me.Controls.Add(Me.ccbMinuteHand)
        Me.Controls.Add(Me.ccbTimeAMPMOn)
        Me.Controls.Add(Me.ccbClockFrameOuter)
        Me.Controls.Add(Me.ccbHourNum)
        Me.Controls.Add(Me.ccbDisplayTime)
        Me.Controls.Add(Me.ccbClockFaceInner)
        Me.Controls.Add(Me.ccbMinutePlus)
        Me.Controls.Add(Me.ccbHourHand)
        Me.Controls.Add(Me.ccbBox)
        Me.Controls.Add(Me.ccbClockFaceOuter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgTimeColors"
        Me.Text = "Color Editor"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gTimePickerColors As gTimePickerCntrl
    Friend WithEvents ccbClockFaceOuter As ColorComboBox
    Friend WithEvents ccbClockFaceInner As ColorComboBox
    Friend WithEvents ccbClockFrameOuter As ColorComboBox
    Friend WithEvents ccbClockFrameInner As ColorComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ccbBox As ColorComboBox
    Friend WithEvents ccbDisplayTime As ColorComboBox
    Friend WithEvents ccbTimeAMPMOn As ColorComboBox
    Friend WithEvents ccbTimeAMPMOff As ColorComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ccbHourHand As ColorComboBox
    Friend WithEvents ccbHourNum As ColorComboBox
    Friend WithEvents ccbMinuteHand As ColorComboBox
    Friend WithEvents ccbMinuteNum As ColorComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboColorTheme As System.Windows.Forms.ComboBox
    Friend WithEvents ccbMinutePlus As ColorComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ccbBackColor As ColorComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents butExit As System.Windows.Forms.Button
End Class
