

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
        Me.floShortDate = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.txtDate = New AATM.Libraries.CBaseControlsLibrary.CMaskedTextBox()
        Me.btnCalendarType = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.dtp = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.txtTime = New AATM.Libraries.CBaseControlsLibrary.gTimePicker()
        Me.floDatePicker.SuspendLayout()
        Me.floShortDate.SuspendLayout()
        Me.SuspendLayout()
        '
        'floDatePicker
        '
        Me.floDatePicker.AutoSize = True
        Me.floDatePicker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floDatePicker.BackColor = System.Drawing.Color.Transparent
        Me.floDatePicker.Controls.Add(Me.txtLongDate)
        Me.floDatePicker.Controls.Add(Me.floShortDate)
        Me.floDatePicker.Controls.Add(Me.txtTime)
        Me.floDatePicker.Location = New System.Drawing.Point(0, 0)
        Me.floDatePicker.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.floDatePicker.Name = "floDatePicker"
        Me.floDatePicker.Size = New System.Drawing.Size(362, 23)
        Me.floDatePicker.TabIndex = 21
        '
        'txtLongDate
        '
        Me.txtLongDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtLongDate.BackColor = System.Drawing.Color.White
        Me.txtLongDate.BegFindValue = Nothing
        Me.txtLongDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDate.ComputedValue = False
        Me.txtLongDate.CustomFormat = Nothing
        Me.txtLongDate.DataBoundControl = True
        Me.txtLongDate.EditingMode = True
        Me.txtLongDate.EndFindValue = Nothing
        Me.txtLongDate.FieldDescription = Nothing
        Me.txtLongDate.FieldName = Nothing
        Me.txtLongDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLongDate.FindEnabled = True
        Me.txtLongDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtLongDate.ForeColor = System.Drawing.Color.Black
        Me.txtLongDate.LinkedLabel = Nothing
        Me.txtLongDate.Location = New System.Drawing.Point(0, 0)
        Me.txtLongDate.Margin = New System.Windows.Forms.Padding(0)
        Me.txtLongDate.MaximumValue = Nothing
        Me.txtLongDate.MinimumValue = Nothing
        Me.txtLongDate.Name = "txtLongDate"
        Me.txtLongDate.OldValue = Nothing
        Me.txtLongDate.ReadOnly = True
        Me.txtLongDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLongDate.Size = New System.Drawing.Size(110, 23)
        Me.txtLongDate.TabIndex = 16
        Me.txtLongDate.Translatable = False
        '
        'floShortDate
        '
        Me.floShortDate.AutoSize = True
        Me.floShortDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floShortDate.BackColor = System.Drawing.Color.Transparent
        Me.floShortDate.Controls.Add(Me.txtDate)
        Me.floShortDate.Controls.Add(Me.btnCalendarType)
        Me.floShortDate.Controls.Add(Me.dtp)
        Me.floShortDate.Location = New System.Drawing.Point(110, 0)
        Me.floShortDate.Margin = New System.Windows.Forms.Padding(0)
        Me.floShortDate.Name = "floShortDate"
        Me.floShortDate.Size = New System.Drawing.Size(119, 23)
        Me.floShortDate.TabIndex = 22
        '
        'txtDate
        '
        Me.txtDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtDate.BackColor = System.Drawing.Color.White
        Me.txtDate.BegFindValue = Nothing
        Me.txtDate.DateField = False
        Me.txtDate.DateTimePickerParent = Nothing
        Me.txtDate.DefaultValue = Nothing
        Me.txtDate.DisplayOnly = False
        Me.txtDate.EditingMode = True
        Me.txtDate.EditsAllowed = True
        Me.txtDate.EmptyMask = ""
        Me.txtDate.EndFindValue = Nothing
        Me.txtDate.FieldDescription = Nothing
        Me.txtDate.FieldName = Nothing
        Me.txtDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[Date]
        Me.txtDate.FindEnabled = False
        Me.txtDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.ForeColor = System.Drawing.Color.Black
        Me.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtDate.LinkedLabel = Nothing
        Me.txtDate.Location = New System.Drawing.Point(0, 0)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDate.MaximumValue = Nothing
        Me.txtDate.MinimumValue = Nothing
        Me.txtDate.Name = "txtDate"
        Me.txtDate.SearchField = Nothing
        Me.txtDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDate.SecurityKey = Nothing
        Me.txtDate.Size = New System.Drawing.Size(80, 23)
        Me.txtDate.TabIndex = 15
        Me.txtDate.Translatable = False
        Me.txtDate.ValueIsMandatory = False
        Me.txtDate.ValueIsNullable = True
        Me.txtDate.ValueIsNumeric = False
        '
        'btnCalendarType
        '
        Me.btnCalendarType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCalendarType.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCalendarType.DesignerSelected = False
        Me.btnCalendarType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalendarType.ImageIndex = 0
        Me.btnCalendarType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCalendarType.Location = New System.Drawing.Point(80, 2)
        Me.btnCalendarType.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCalendarType.Name = "btnCalendarType"
        Me.btnCalendarType.OriginalImageName = Nothing
        Me.btnCalendarType.SecurityKey = ""
        Me.btnCalendarType.Size = New System.Drawing.Size(18, 19)
        Me.btnCalendarType.TabIndex = 21
        Me.btnCalendarType.TabStop = False
        Me.btnCalendarType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'dtp
        '
        Me.dtp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtp.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.dtp.DesignerSelected = False
        Me.floShortDate.SetFlowBreak(Me.dtp, True)
        Me.dtp.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp.Image = Global.AATM.Libraries.CBaseControlsLibrary.My.Resources.Resources.Calendar18x18
        Me.dtp.ImageIndex = 0
        Me.dtp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtp.Location = New System.Drawing.Point(98, 2)
        Me.dtp.Margin = New System.Windows.Forms.Padding(0)
        Me.dtp.Name = "dtp"
        Me.dtp.OriginalImageName = Nothing
        Me.dtp.SecurityKey = ""
        Me.dtp.Size = New System.Drawing.Size(21, 19)
        Me.dtp.TabIndex = 19
        Me.dtp.TabStop = False
        Me.dtp.Text = ""
        Me.dtp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'txtTime
        '
        Me.txtTime.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtTime.BackColor = System.Drawing.Color.Transparent
        Me.txtTime.ButtonForeColor = System.Drawing.Color.DarkSlateBlue
        Me.txtTime.Hr24 = False
        Me.txtTime.Location = New System.Drawing.Point(229, 0)
        Me.txtTime.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.NullColorA = System.Drawing.Color.LightSteelBlue
        Me.txtTime.NullColorB = System.Drawing.Color.White
        Me.txtTime.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.WideDownwardDiagonal
        Me.txtTime.NullTextColor = System.Drawing.Color.Black
        Me.txtTime.NullTextInFront = False
        Me.txtTime.oldTimeAmPM = AATM.Libraries.CBaseControlsLibrary.gTimePickerCntrl.eTimeAMPM.am
        Me.txtTime.ShowMidMins = True
        Me.txtTime.Size = New System.Drawing.Size(133, 23)
        Me.txtTime.TabIndex = 22
        Me.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTime.TextBackColor = System.Drawing.Color.White
        Me.txtTime.TextFont = New System.Drawing.Font("Arial", 10.0!)
        Me.txtTime.TextForeColor = System.Drawing.Color.Black
        Me.txtTime.Time = "07:00"
        Me.txtTime.TimeAMPM = AATM.Libraries.CBaseControlsLibrary.gTimePickerCntrl.eTimeAMPM.am
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
        Me.txtTime.TrueHour = True
        '
        'CCustomDateTimePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.floDatePicker)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "CCustomDateTimePicker"
        Me.Size = New System.Drawing.Size(364, 23)
        Me.floDatePicker.ResumeLayout(False)
        Me.floDatePicker.PerformLayout()
        Me.floShortDate.ResumeLayout(False)
        Me.floShortDate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtp As CButton
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents txtLongDate As CTextBox
    Friend WithEvents txtDate As CMaskedTextBox
    Friend WithEvents floDatePicker As CFlowLayout
    Friend WithEvents btnCalendarType As CButton
    Friend WithEvents txtTime As gTimePicker
    Friend WithEvents floShortDate As CFlowLayout
End Class
