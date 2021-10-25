<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DropDowngTimeEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim TimeColors1 As gTimePickerControl.TimeColors = New gTimePickerControl.TimeColors
        Me.DDgTimePickerCntrl = New gTimePickerControl.gTimePickerCntrl
        Me.butClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'DDgTimePickerCntrl
        '
        Me.DDgTimePickerCntrl.Hr24 = True
        Me.DDgTimePickerCntrl.Location = New System.Drawing.Point(3, 29)
        Me.DDgTimePickerCntrl.Name = "DDgTimePickerCntrl"
        Me.DDgTimePickerCntrl.Size = New System.Drawing.Size(214, 214)
        Me.DDgTimePickerCntrl.TabIndex = 0
        Me.DDgTimePickerCntrl.Time = "07:00"
        Me.DDgTimePickerCntrl.TimeAMPM = gTimePickerControl.gTimePickerCntrl.eTimeAMPM.AM
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
        Me.DDgTimePickerCntrl.TimeColors = TimeColors1
        Me.DDgTimePickerCntrl.TrueHour = True
        '
        'butClose
        '
        Me.butClose.Location = New System.Drawing.Point(78, 3)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(62, 23)
        Me.butClose.TabIndex = 1
        Me.butClose.Text = "Close"
        Me.butClose.UseVisualStyleBackColor = True
        '
        'DropDowngTimeEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.butClose)
        Me.Controls.Add(Me.DDgTimePickerCntrl)
        Me.Name = "DropDowngTimeEditor"
        Me.Size = New System.Drawing.Size(219, 240)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DDgTimePickerCntrl As gTimePickerControl.gTimePickerCntrl
    Friend WithEvents butClose As System.Windows.Forms.Button

End Class
