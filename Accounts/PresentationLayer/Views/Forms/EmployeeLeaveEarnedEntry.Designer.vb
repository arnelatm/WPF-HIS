<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeeLeaveEarnedEntry
    Inherits AATM.PresentationLayer.Forms.CFormEntry

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
        Me.components = New System.ComponentModel.Container()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.lblLeaveName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboLeaveIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblDaysEarned = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDaysEarned = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblReason = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtReason = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblenteredBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboenteredBy = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CFlowLayout1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblEmployeeIdNo)
        Me.CFlowLayout1.Controls.Add(Me.cboEmployeeIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblLeaveName)
        Me.CFlowLayout1.Controls.Add(Me.cboLeaveIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblStartDate)
        Me.CFlowLayout1.Controls.Add(Me.dtpStartDate)
        Me.CFlowLayout1.Controls.Add(Me.lblEndDate)
        Me.CFlowLayout1.Controls.Add(Me.dtpEndDate)
        Me.CFlowLayout1.Controls.Add(Me.lblDaysEarned)
        Me.CFlowLayout1.Controls.Add(Me.txtDaysEarned)
        Me.CFlowLayout1.Controls.Add(Me.lblReason)
        Me.CFlowLayout1.Controls.Add(Me.txtReason)
        Me.CFlowLayout1.Controls.Add(Me.lblenteredBy)
        Me.CFlowLayout1.Controls.Add(Me.cboenteredBy)
        Me.CFlowLayout1.Controls.Add(Me.lblPosted)
        Me.CFlowLayout1.Controls.Add(Me.chkActive)
        Me.CFlowLayout1.Controls.Add(Me.lblDateCreated)
        Me.CFlowLayout1.Controls.Add(Me.txtDateCreated)
        Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFlowLayout1.Location = New System.Drawing.Point(0, 55)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(743, 327)
        Me.CFlowLayout1.TabIndex = 4
        '
        'lblIdNo
        '
        Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblIdNo.DisplayOnly = True
        Me.lblIdNo.EditingMode = False
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(1, 10)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1, 10, 1, 1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(190, 23)
        Me.lblIdNo.TabIndex = 315
        Me.lblIdNo.Text = "ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdNo.Translatable = True
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = False
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = True
        Me.TxtIdNo.DisplayOnly = True
        Me.TxtIdNo.EditingMode = True
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.TxtIdNo, True)
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.Location = New System.Drawing.Point(193, 10)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1, 10, 1, 1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.OverrideMaxLength = 0
        Me.TxtIdNo.ReadOnly = True
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIdNo.TabIndex = 305
        Me.TxtIdNo.TabStop = False
        Me.TxtIdNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtIdNo.Translatable = False
        Me.TxtIdNo.ValueIsNumeric = True
        '
        'lblEmployeeIdNo
        '
        Me.lblEmployeeIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblEmployeeIdNo.DisplayOnly = True
        Me.lblEmployeeIdNo.EditingMode = False
        Me.lblEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblEmployeeIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEmployeeIdNo.Location = New System.Drawing.Point(1, 35)
        Me.lblEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
        Me.lblEmployeeIdNo.Size = New System.Drawing.Size(190, 23)
        Me.lblEmployeeIdNo.TabIndex = 316
        Me.lblEmployeeIdNo.Text = "Employee Name"
        Me.lblEmployeeIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEmployeeIdNo.Translatable = True
        '
        'cboEmployeeIdNo
        '
        Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
        Me.cboEmployeeIdNo.BegFindValue = Nothing
        Me.cboEmployeeIdNo.ChangingSearchValueOnly = False
        Me.cboEmployeeIdNo.CurrentSearchTerm = ""
        Me.cboEmployeeIdNo.DataValue = Nothing
        Me.cboEmployeeIdNo.DefaultValue = Nothing
        Me.cboEmployeeIdNo.DisplayMember = "Name"
        Me.cboEmployeeIdNo.Editable = True
        Me.cboEmployeeIdNo.EditingMode = True
        Me.cboEmployeeIdNo.EndFindValue = Nothing
        Me.cboEmployeeIdNo.FieldDescription = Nothing
        Me.cboEmployeeIdNo.FieldName = Nothing
        Me.cboEmployeeIdNo.FilterRule = Nothing
        Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboEmployeeIdNo.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.cboEmployeeIdNo, True)
        Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboEmployeeIdNo.FormattingEnabled = True
        Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = False
        Me.cboEmployeeIdNo.IgnoreCase = False
        Me.cboEmployeeIdNo.IntegralHeight = False
        Me.cboEmployeeIdNo.LimitToList = False
        Me.cboEmployeeIdNo.LinkedLabel = Me.lblEmployeeIdNo
        Me.cboEmployeeIdNo.Location = New System.Drawing.Point(193, 35)
        Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
        Me.cboEmployeeIdNo.OldValue = 0
        Me.cboEmployeeIdNo.OriginalDataSource = Nothing
        Me.cboEmployeeIdNo.OriginalList = Nothing
        Me.cboEmployeeIdNo.OverrideDropDownStyleList = False
        Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
        Me.cboEmployeeIdNo.PropertySelector = Nothing
        Me.cboEmployeeIdNo.Size = New System.Drawing.Size(539, 24)
        Me.cboEmployeeIdNo.SuggestBoxHeight = 200
        Me.cboEmployeeIdNo.SuggestCharCount = 0
        Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
        Me.cboEmployeeIdNo.TabIndex = 306
        Me.cboEmployeeIdNo.TextToSearch = Nothing
        Me.cboEmployeeIdNo.Translatable = False
        Me.cboEmployeeIdNo.ValueIsMandatory = False
        Me.cboEmployeeIdNo.ValueIsNullable = False
        Me.cboEmployeeIdNo.ValueIsNumeric = False
        Me.cboEmployeeIdNo.ValueMember = "IdNo"
        '
        'lblLeaveName
        '
        Me.lblLeaveName.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveName.DisplayOnly = True
        Me.lblLeaveName.EditingMode = False
        Me.lblLeaveName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblLeaveName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLeaveName.Location = New System.Drawing.Point(1, 61)
        Me.lblLeaveName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblLeaveName.Name = "lblLeaveName"
        Me.lblLeaveName.Size = New System.Drawing.Size(190, 23)
        Me.lblLeaveName.TabIndex = 319
        Me.lblLeaveName.Text = "Leave Name"
        Me.lblLeaveName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLeaveName.Translatable = True
        '
        'cboLeaveIdNo
        '
        Me.cboLeaveIdNo.BackColor = System.Drawing.Color.White
        Me.cboLeaveIdNo.BegFindValue = Nothing
        Me.cboLeaveIdNo.ChangingSearchValueOnly = False
        Me.cboLeaveIdNo.CurrentSearchTerm = ""
        Me.cboLeaveIdNo.DataValue = Nothing
        Me.cboLeaveIdNo.DefaultValue = Nothing
        Me.cboLeaveIdNo.DisplayMember = "Name"
        Me.cboLeaveIdNo.Editable = True
        Me.cboLeaveIdNo.EditingMode = True
        Me.cboLeaveIdNo.EndFindValue = Nothing
        Me.cboLeaveIdNo.FieldDescription = Nothing
        Me.cboLeaveIdNo.FieldName = Nothing
        Me.cboLeaveIdNo.FilterRule = Nothing
        Me.cboLeaveIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboLeaveIdNo.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.cboLeaveIdNo, True)
        Me.cboLeaveIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboLeaveIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboLeaveIdNo.FormattingEnabled = True
        Me.cboLeaveIdNo.HideWhenNotEditingOrAdding = False
        Me.cboLeaveIdNo.IgnoreCase = False
        Me.cboLeaveIdNo.IntegralHeight = False
        Me.cboLeaveIdNo.LimitToList = False
        Me.cboLeaveIdNo.LinkedLabel = Me.lblLeaveName
        Me.cboLeaveIdNo.Location = New System.Drawing.Point(193, 61)
        Me.cboLeaveIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboLeaveIdNo.Name = "cboLeaveIdNo"
        Me.cboLeaveIdNo.OldValue = 0
        Me.cboLeaveIdNo.OriginalDataSource = Nothing
        Me.cboLeaveIdNo.OriginalList = Nothing
        Me.cboLeaveIdNo.OverrideDropDownStyleList = False
        Me.cboLeaveIdNo.PreviousSearchTerm = Nothing
        Me.cboLeaveIdNo.PropertySelector = Nothing
        Me.cboLeaveIdNo.Size = New System.Drawing.Size(539, 24)
        Me.cboLeaveIdNo.SuggestBoxHeight = 200
        Me.cboLeaveIdNo.SuggestCharCount = 0
        Me.cboLeaveIdNo.SuggestListOrderRule = Nothing
        Me.cboLeaveIdNo.TabIndex = 307
        Me.cboLeaveIdNo.TextToSearch = Nothing
        Me.cboLeaveIdNo.Translatable = False
        Me.cboLeaveIdNo.ValueIsMandatory = False
        Me.cboLeaveIdNo.ValueIsNullable = False
        Me.cboLeaveIdNo.ValueIsNumeric = False
        Me.cboLeaveIdNo.ValueMember = "IdNo"
        '
        'lblStartDate
        '
        Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
        Me.lblStartDate.DisplayOnly = True
        Me.lblStartDate.EditingMode = False
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblStartDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStartDate.Location = New System.Drawing.Point(1, 87)
        Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(190, 23)
        Me.lblStartDate.TabIndex = 317
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStartDate.Translatable = True
        '
        'dtpStartDate
        '
        Me.dtpStartDate.AutoSize = True
        Me.dtpStartDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpStartDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpStartDate.DefaultValue = Nothing
        Me.dtpStartDate.DisplayOnly = False
        Me.dtpStartDate.DtpDefaultValue = Nothing
        Me.dtpStartDate.EditingMode = True
        Me.dtpStartDate.EditsAllowed = False
        Me.CFlowLayout1.SetFlowBreak(Me.dtpStartDate, True)
        Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
        Me.dtpStartDate.LinkedLabel = Me.lblStartDate
        Me.dtpStartDate.Location = New System.Drawing.Point(193, 87)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ReadOnlyDp = False
        Me.dtpStartDate.SecurityKey = Nothing
        Me.dtpStartDate.ShowLongDate = False
        Me.dtpStartDate.ShowTime = False
        Me.dtpStartDate.Size = New System.Drawing.Size(118, 23)
        Me.dtpStartDate.TabIndex = 308
        Me.dtpStartDate.TargetCalendar = Nothing
        Me.dtpStartDate.Translatable = False
        Me.dtpStartDate.Value = Nothing
        Me.dtpStartDate.ValueIsMandatory = False
        Me.dtpStartDate.ValueIsNullable = False
        '
        'lblEndDate
        '
        Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEndDate.DisplayOnly = True
        Me.lblEndDate.EditingMode = False
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblEndDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEndDate.Location = New System.Drawing.Point(1, 112)
        Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(190, 23)
        Me.lblEndDate.TabIndex = 320
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndDate.Translatable = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.AutoSize = True
        Me.dtpEndDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpEndDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndDate.DefaultValue = Nothing
        Me.dtpEndDate.DisplayOnly = False
        Me.dtpEndDate.DtpDefaultValue = Nothing
        Me.dtpEndDate.EditingMode = True
        Me.dtpEndDate.EditsAllowed = False
        Me.CFlowLayout1.SetFlowBreak(Me.dtpEndDate, True)
        Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndDate.LinkedLabel = Me.lblEndDate
        Me.dtpEndDate.Location = New System.Drawing.Point(193, 112)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ReadOnlyDp = False
        Me.dtpEndDate.SecurityKey = Nothing
        Me.dtpEndDate.ShowLongDate = False
        Me.dtpEndDate.ShowTime = False
        Me.dtpEndDate.Size = New System.Drawing.Size(118, 23)
        Me.dtpEndDate.TabIndex = 309
        Me.dtpEndDate.TargetCalendar = Nothing
        Me.dtpEndDate.Translatable = False
        Me.dtpEndDate.Value = Nothing
        Me.dtpEndDate.ValueIsMandatory = False
        Me.dtpEndDate.ValueIsNullable = False
        '
        'lblDaysEarned
        '
        Me.lblDaysEarned.BackColor = System.Drawing.Color.Transparent
        Me.lblDaysEarned.DisplayOnly = True
        Me.lblDaysEarned.EditingMode = False
        Me.lblDaysEarned.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblDaysEarned.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDaysEarned.Location = New System.Drawing.Point(1, 137)
        Me.lblDaysEarned.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDaysEarned.Name = "lblDaysEarned"
        Me.lblDaysEarned.Size = New System.Drawing.Size(190, 23)
        Me.lblDaysEarned.TabIndex = 323
        Me.lblDaysEarned.Text = "Days Earned"
        Me.lblDaysEarned.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDaysEarned.Translatable = True
        '
        'txtDaysEarned
        '
        Me.txtDaysEarned.BackColor = System.Drawing.Color.White
        Me.txtDaysEarned.BegFindValue = Nothing
        Me.txtDaysEarned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDaysEarned.ComputedValue = False
        Me.txtDaysEarned.CustomFormat = Nothing
        Me.txtDaysEarned.DataBoundControl = True
        Me.txtDaysEarned.DisplayOnly = True
        Me.txtDaysEarned.EditingMode = True
        Me.txtDaysEarned.EndFindValue = Nothing
        Me.txtDaysEarned.FieldDescription = Nothing
        Me.txtDaysEarned.FieldName = Nothing
        Me.txtDaysEarned.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDaysEarned.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.txtDaysEarned, True)
        Me.txtDaysEarned.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtDaysEarned.ForeColor = System.Drawing.Color.Black
        Me.txtDaysEarned.LinkedLabel = Me.lblIdNo
        Me.txtDaysEarned.Location = New System.Drawing.Point(193, 137)
        Me.txtDaysEarned.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDaysEarned.MaximumValue = Nothing
        Me.txtDaysEarned.MinimumValue = Nothing
        Me.txtDaysEarned.Name = "txtDaysEarned"
        Me.txtDaysEarned.OldValue = Nothing
        Me.txtDaysEarned.OverrideMaxLength = 0
        Me.txtDaysEarned.ReadOnly = True
        Me.txtDaysEarned.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDaysEarned.Size = New System.Drawing.Size(62, 23)
        Me.txtDaysEarned.TabIndex = 310
        Me.txtDaysEarned.TabStop = False
        Me.txtDaysEarned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDaysEarned.Translatable = False
        Me.txtDaysEarned.ValueIsNumeric = True
        '
        'lblReason
        '
        Me.lblReason.BackColor = System.Drawing.Color.Transparent
        Me.lblReason.DisplayOnly = True
        Me.lblReason.EditingMode = False
        Me.lblReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblReason.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReason.Location = New System.Drawing.Point(1, 162)
        Me.lblReason.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(190, 23)
        Me.lblReason.TabIndex = 321
        Me.lblReason.Text = "Reason "
        Me.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblReason.Translatable = True
        '
        'txtReason
        '
        Me.txtReason.BackColor = System.Drawing.Color.White
        Me.txtReason.BegFindValue = Nothing
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.ComputedValue = False
        Me.txtReason.CustomFormat = Nothing
        Me.txtReason.DataBoundControl = True
        Me.txtReason.EditingMode = True
        Me.txtReason.EndFindValue = Nothing
        Me.txtReason.FieldDescription = Nothing
        Me.txtReason.FieldName = Nothing
        Me.txtReason.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtReason.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.txtReason, True)
        Me.txtReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtReason.ForeColor = System.Drawing.Color.Black
        Me.txtReason.LinkedLabel = Me.lblReason
        Me.txtReason.Location = New System.Drawing.Point(193, 162)
        Me.txtReason.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReason.MaximumValue = Nothing
        Me.txtReason.MinimumValue = Nothing
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.OldValue = Nothing
        Me.txtReason.OverrideMaxLength = 0
        Me.txtReason.ReadOnly = True
        Me.txtReason.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtReason.Size = New System.Drawing.Size(539, 48)
        Me.txtReason.TabIndex = 311
        Me.txtReason.Translatable = False
        Me.txtReason.ValueIsMandatory = True
        '
        'lblenteredBy
        '
        Me.lblenteredBy.BackColor = System.Drawing.Color.Transparent
        Me.lblenteredBy.DisplayOnly = True
        Me.lblenteredBy.EditingMode = False
        Me.lblenteredBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblenteredBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblenteredBy.Location = New System.Drawing.Point(1, 212)
        Me.lblenteredBy.Margin = New System.Windows.Forms.Padding(1)
        Me.lblenteredBy.Name = "lblenteredBy"
        Me.lblenteredBy.Size = New System.Drawing.Size(190, 23)
        Me.lblenteredBy.TabIndex = 322
        Me.lblenteredBy.Text = "Entered By"
        Me.lblenteredBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblenteredBy.Translatable = True
        '
        'cboenteredBy
        '
        Me.cboenteredBy.BackColor = System.Drawing.Color.White
        Me.cboenteredBy.BegFindValue = Nothing
        Me.cboenteredBy.ChangingSearchValueOnly = False
        Me.cboenteredBy.CurrentSearchTerm = ""
        Me.cboenteredBy.DataValue = Nothing
        Me.cboenteredBy.DefaultValue = Nothing
        Me.cboenteredBy.DisplayMember = "Name"
        Me.cboenteredBy.DisplayOnly = True
        Me.cboenteredBy.DropDownHeight = 21
        Me.cboenteredBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboenteredBy.Editable = True
        Me.cboenteredBy.EditingMode = True
        Me.cboenteredBy.EndFindValue = Nothing
        Me.cboenteredBy.FieldDescription = Nothing
        Me.cboenteredBy.FieldName = Nothing
        Me.cboenteredBy.FilterRule = Nothing
        Me.cboenteredBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboenteredBy.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.cboenteredBy, True)
        Me.cboenteredBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboenteredBy.ForeColor = System.Drawing.Color.Black
        Me.cboenteredBy.FormattingEnabled = True
        Me.cboenteredBy.HideWhenNotEditingOrAdding = False
        Me.cboenteredBy.IgnoreCase = False
        Me.cboenteredBy.IntegralHeight = False
        Me.cboenteredBy.LimitToList = False
        Me.cboenteredBy.LinkedLabel = Me.lblEmployeeIdNo
        Me.cboenteredBy.Location = New System.Drawing.Point(193, 212)
        Me.cboenteredBy.Margin = New System.Windows.Forms.Padding(1)
        Me.cboenteredBy.MaxDropDownItems = 1
        Me.cboenteredBy.Name = "cboenteredBy"
        Me.cboenteredBy.OldValue = 0
        Me.cboenteredBy.OriginalDataSource = Nothing
        Me.cboenteredBy.OriginalList = Nothing
        Me.cboenteredBy.OverrideDropDownStyleList = False
        Me.cboenteredBy.PreviousSearchTerm = Nothing
        Me.cboenteredBy.PropertySelector = Nothing
        Me.cboenteredBy.Size = New System.Drawing.Size(539, 26)
        Me.cboenteredBy.SuggestBoxHeight = 200
        Me.cboenteredBy.SuggestCharCount = 0
        Me.cboenteredBy.SuggestListOrderRule = Nothing
        Me.cboenteredBy.TabIndex = 312
        Me.cboenteredBy.TextToSearch = Nothing
        Me.cboenteredBy.Translatable = False
        Me.cboenteredBy.ValueIsMandatory = False
        Me.cboenteredBy.ValueIsNullable = False
        Me.cboenteredBy.ValueIsNumeric = False
        Me.cboenteredBy.ValueMember = "IdNo"
        '
        'lblPosted
        '
        Me.lblPosted.BackColor = System.Drawing.Color.Transparent
        Me.lblPosted.DisplayOnly = True
        Me.lblPosted.EditingMode = False
        Me.lblPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblPosted.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPosted.Location = New System.Drawing.Point(1, 240)
        Me.lblPosted.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPosted.Name = "lblPosted"
        Me.lblPosted.Size = New System.Drawing.Size(190, 24)
        Me.lblPosted.TabIndex = 324
        Me.lblPosted.Text = "Posted?"
        Me.lblPosted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPosted.Translatable = True
        '
        'chkActive
        '
        Me.chkActive.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkActive.AutoCheck = False
        Me.chkActive.BackColor = System.Drawing.Color.White
        Me.chkActive.BegFindValue = Nothing
        Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActive.DisplayOnly = False
        Me.chkActive.EditingMode = False
        Me.chkActive.EndFindValue = Nothing
        Me.chkActive.FieldDescription = Nothing
        Me.chkActive.FieldName = Nothing
        Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkActive.FindEnabled = True
        Me.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout1.SetFlowBreak(Me.chkActive, True)
        Me.chkActive.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkActive.ForeColor = System.Drawing.Color.Black
        Me.chkActive.IFindableControl_FindEnabled = False
        Me.chkActive.IgnoreCase = False
        Me.chkActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkActive.LinkedLabel = Me.lblPosted
        Me.chkActive.Location = New System.Drawing.Point(193, 240)
        Me.chkActive.Margin = New System.Windows.Forms.Padding(1)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.NoLabel = False
        Me.chkActive.OldValue = ""
        Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkActive.Size = New System.Drawing.Size(14, 13)
        Me.chkActive.TabIndex = 313
        Me.chkActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActive.Translatable = False
        Me.chkActive.UseVisualStyleBackColor = False
        '
        'lblDateCreated
        '
        Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
        Me.lblDateCreated.DisplayOnly = True
        Me.lblDateCreated.EditingMode = False
        Me.lblDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblDateCreated.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDateCreated.Location = New System.Drawing.Point(1, 266)
        Me.lblDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDateCreated.Name = "lblDateCreated"
        Me.lblDateCreated.Size = New System.Drawing.Size(190, 23)
        Me.lblDateCreated.TabIndex = 318
        Me.lblDateCreated.Text = "Date Created"
        Me.lblDateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDateCreated.Translatable = True
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.Color.White
        Me.txtDateCreated.BegFindValue = Nothing
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.ComputedValue = False
        Me.txtDateCreated.CustomFormat = Nothing
        Me.txtDateCreated.DataBoundControl = True
        Me.txtDateCreated.DisplayOnly = True
        Me.txtDateCreated.EditingMode = True
        Me.txtDateCreated.EndFindValue = Nothing
        Me.txtDateCreated.FieldDescription = Nothing
        Me.txtDateCreated.FieldName = Nothing
        Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDateCreated.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.txtDateCreated, True)
        Me.txtDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
        Me.txtDateCreated.Location = New System.Drawing.Point(193, 266)
        Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.OverrideMaxLength = 0
        Me.txtDateCreated.ReadOnly = True
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.Size = New System.Drawing.Size(129, 23)
        Me.txtDateCreated.TabIndex = 314
        Me.txtDateCreated.Translatable = False
        Me.txtDateCreated.ValueIsMandatory = True
        '
        'EmployeeLeaveEarnedEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 382)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "EmployeeLeaveEarnedEntry"
        Me.Text = "Employee Leave Earned Entry"
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CFlowLayout1.ResumeLayout(False)
        Me.CFlowLayout1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
    Public WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblEmployeeIdNo As Libraries.CBaseControlsLibrary.CLabel
    Public WithEvents cboEmployeeIdNo As Libraries.CBaseControlsLibrary.CtComboBox
    Friend WithEvents lblLeaveName As Libraries.CBaseControlsLibrary.CLabel
    Public WithEvents cboLeaveIdNo As Libraries.CBaseControlsLibrary.CtComboBox
    Friend WithEvents lblStartDate As Libraries.CBaseControlsLibrary.CLabel
    Public WithEvents dtpStartDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
    Friend WithEvents lblEndDate As Libraries.CBaseControlsLibrary.CLabel
    Public WithEvents dtpEndDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
    Friend WithEvents lblDaysEarned As Libraries.CBaseControlsLibrary.CLabel
    Public WithEvents txtDaysEarned As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblReason As Libraries.CBaseControlsLibrary.CLabel
    Public WithEvents txtReason As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblenteredBy As Libraries.CBaseControlsLibrary.CLabel
    Public WithEvents cboenteredBy As Libraries.CBaseControlsLibrary.CtComboBox
    Friend WithEvents lblPosted As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents chkActive As Libraries.CBaseControlsLibrary.CCheckBox
    Friend WithEvents lblDateCreated As Libraries.CBaseControlsLibrary.CLabel
    Public WithEvents txtDateCreated As Libraries.CBaseControlsLibrary.CTextBox
End Class
