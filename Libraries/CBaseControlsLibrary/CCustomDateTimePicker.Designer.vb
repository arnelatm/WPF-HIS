

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CCustomDateTimePicker
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    '<System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TimeColors1 As AATM.Libraries.CBaseControlsLibrary.TimeColors = New AATM.Libraries.CBaseControlsLibrary.TimeColors()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.floDatePicker = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.txtLongDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDate = New AATM.Libraries.CBaseControlsLibrary.CMaskedTextBox()
        Me.dtp = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCalendarType = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.txtTime = New AATM.Libraries.CBaseControlsLibrary.gTimePicker()
        Me.floDatePicker.SuspendLayout
        Me.SuspendLayout
        '
        'floDatePicker
        '
        Me.floDatePicker.BackColor = System.Drawing.Color.Transparent
        Me.floDatePicker.Controls.Add(Me.txtLongDate)
        Me.floDatePicker.Controls.Add(Me.txtDate)
        Me.floDatePicker.Controls.Add(Me.btnCalendarType)
        Me.floDatePicker.Controls.Add(Me.dtp)
        Me.floDatePicker.Controls.Add(Me.txtTime)
        Me.floDatePicker.Location = New System.Drawing.Point(0, 0)
        Me.floDatePicker.Margin = New System.Windows.Forms.Padding(0)
        Me.floDatePicker.Name = "floDatePicker"
        Me.floDatePicker.Size = New System.Drawing.Size(309, 23)
        Me.floDatePicker.TabIndex = 21
        '
        'txtLongDate
        '
        Me.txtLongDate.BackColor = System.Drawing.Color.White
        Me.txtLongDate.BegFindValue = Nothing
        Me.txtLongDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDate.ComputedValue = false
        Me.txtLongDate.CustomFormat = Nothing
        Me.txtLongDate.DataBoundControl = true
        Me.txtLongDate.EditingMode = true
        Me.txtLongDate.EndFindValue = Nothing
        Me.txtLongDate.FieldDescription = Nothing
        Me.txtLongDate.FieldName = Nothing
        Me.txtLongDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLongDate.FindEnabled = true
        Me.txtLongDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtLongDate.ForeColor = System.Drawing.Color.Black
        Me.txtLongDate.LinkedLabel = Nothing
        Me.txtLongDate.Location = New System.Drawing.Point(0, 0)
        Me.txtLongDate.Margin = New System.Windows.Forms.Padding(0)
        Me.txtLongDate.MaximumValue = Nothing
        Me.txtLongDate.MinimumValue = Nothing
        Me.txtLongDate.Name = "txtLongDate"
        Me.txtLongDate.OldValue = Nothing
        Me.txtLongDate.ReadOnly = true
        Me.txtLongDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLongDate.Size = New System.Drawing.Size(110, 23)
        Me.txtLongDate.TabIndex = 16
        Me.txtLongDate.Translatable = false
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.Color.White
        Me.txtDate.BegFindValue = Nothing
        Me.txtDate.DateField = false
        Me.txtDate.DateTimePickerParent = Nothing
        Me.txtDate.DefaultValue = Nothing
        Me.txtDate.DisplayOnly = false
        Me.txtDate.EditingMode = true
        Me.txtDate.EditsAllowed = true
        Me.txtDate.EmptyMask = ""
        Me.txtDate.EndFindValue = Nothing
        Me.txtDate.FieldDescription = Nothing
        Me.txtDate.FieldName = Nothing
        Me.txtDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[Date]
        Me.txtDate.FindEnabled = false
        Me.txtDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDate.ForeColor = System.Drawing.Color.Black
        Me.txtDate.LinkedLabel = Nothing
        Me.txtDate.Location = New System.Drawing.Point(110, 0)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDate.MaximumValue = Nothing
        Me.txtDate.MinimumValue = Nothing
        Me.txtDate.Name = "txtDate"
        Me.txtDate.SearchField = Nothing
        Me.txtDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDate.SecurityKey = Nothing
        Me.txtDate.Size = New System.Drawing.Size(75, 23)
        Me.txtDate.TabIndex = 15
        Me.txtDate.Translatable = false
        Me.txtDate.ValueIsMandatory = false
        Me.txtDate.ValueIsNullable = true
        Me.txtDate.ValueIsNumeric = false
        '
        'dtp
        '
        Me.dtp.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.dtp.DesignerSelected = false
        Me.dtp.DisplayOnly = true
        Me.dtp.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dtp.Image = Global.AATM.Libraries.CBaseControlsLibrary.My.Resources.Resources.Calendar18x18
        Me.dtp.ImageIndex = 0
        Me.dtp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtp.Location = New System.Drawing.Point(203, 0)
        Me.dtp.Margin = New System.Windows.Forms.Padding(0)
        Me.dtp.Name = "dtp"
        Me.dtp.OriginalImageName = Nothing
        Me.dtp.SecurityKey = ""
        Me.dtp.Size = New System.Drawing.Size(21, 19)
        Me.dtp.TabIndex = 19
        Me.dtp.TabStop = false
        Me.dtp.Text = ""
        Me.dtp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCalendarType
        '
        Me.btnCalendarType.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCalendarType.DesignerSelected = false
        Me.btnCalendarType.DisplayOnly = true
        Me.btnCalendarType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnCalendarType.ImageIndex = 0
        Me.btnCalendarType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCalendarType.Location = New System.Drawing.Point(185, 0)
        Me.btnCalendarType.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCalendarType.Name = "btnCalendarType"
        Me.btnCalendarType.OriginalImageName = Nothing
        Me.btnCalendarType.SecurityKey = ""
        Me.btnCalendarType.Size = New System.Drawing.Size(18, 19)
        Me.btnCalendarType.TabIndex = 21
        Me.btnCalendarType.TabStop = false
        Me.btnCalendarType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'txtTime
        '
        Me.txtTime.ButtonForeColor = System.Drawing.Color.DarkSlateBlue
        Me.txtTime.Hr24 = false
        Me.txtTime.Location = New System.Drawing.Point(227, 0)
        Me.txtTime.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.NullColorA = System.Drawing.Color.LightSteelBlue
        Me.txtTime.NullColorB = System.Drawing.Color.White
        Me.txtTime.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.WideDownwardDiagonal
        Me.txtTime.NullTextColor = System.Drawing.Color.Black
        Me.txtTime.NullTextInFront = false
        Me.txtTime.oldTimeAmPM = AATM.Libraries.CBaseControlsLibrary.gTimePickerCntrl.eTimeAMPM.AM
        Me.txtTime.ShowMidMins = true
        Me.txtTime.Size = New System.Drawing.Size(75, 23)
        Me.txtTime.TabIndex = 22
        Me.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTime.TextBackColor = System.Drawing.Color.White
        Me.txtTime.TextFont = New System.Drawing.Font("Arial", 10!)
        Me.txtTime.TextForeColor = System.Drawing.Color.Black
        Me.txtTime.Time = "07:00"
        Me.txtTime.TimeAMPM = AATM.Libraries.CBaseControlsLibrary.gTimePickerCntrl.eTimeAMPM.AM
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
        TimeColors1.MinutePlus = System.Drawing.Color.LightSlateGray
        TimeColors1.TimeAMPM_OFF = System.Drawing.Color.LightSteelBlue
        TimeColors1.TimeAMPM_ON = System.Drawing.Color.MediumBlue
        Me.txtTime.TimeColors = TimeColors1
        Me.txtTime.TrueHour = true
        '
        'CCustomDateTimePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.floDatePicker)
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "CCustomDateTimePicker"
        Me.Size = New System.Drawing.Size(309, 23)
        Me.floDatePicker.ResumeLayout(false)
        Me.floDatePicker.PerformLayout
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents dtp As CButton
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents txtLongDate As CTextBox
    Friend WithEvents txtDate As CMaskedTextBox
    Friend WithEvents floDatePicker As CFlowLayout
    Friend WithEvents btnCalendarType As CButton
    Friend WithEvents txtTime As gTimePicker
End Class
