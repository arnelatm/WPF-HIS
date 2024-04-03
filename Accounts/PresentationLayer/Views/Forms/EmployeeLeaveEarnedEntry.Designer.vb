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
        Me.lblApproved = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkApproved = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblDisapproved = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkDisapproved = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblApprovedBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboApprovedBy = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.lblApprovalNote = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtApprovalNote = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
        Me.CFlowLayout1.Controls.Add(Me.lblApproved)
        Me.CFlowLayout1.Controls.Add(Me.chkApproved)
        Me.CFlowLayout1.Controls.Add(Me.lblDisapproved)
        Me.CFlowLayout1.Controls.Add(Me.chkDisapproved)
        Me.CFlowLayout1.Controls.Add(Me.lblApprovedBy)
        Me.CFlowLayout1.Controls.Add(Me.cboApprovedBy)
        Me.CFlowLayout1.Controls.Add(Me.lblApprovalNote)
        Me.CFlowLayout1.Controls.Add(Me.txtApprovalNote)
        Me.CFlowLayout1.Controls.Add(Me.lblDateCreated)
        Me.CFlowLayout1.Controls.Add(Me.txtDateCreated)
        Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFlowLayout1.Location = New System.Drawing.Point(0, 59)
        Me.CFlowLayout1.Margin = New System.Windows.Forms.Padding(4)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(991, 484)
        Me.CFlowLayout1.TabIndex = 4
        '
        'lblIdNo
        '
        Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblIdNo.DisplayOnly = True
        Me.lblIdNo.EditingMode = False
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(1, 12)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1, 12, 1, 1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(253, 28)
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
        Me.TxtIdNo.Location = New System.Drawing.Point(256, 12)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1, 12, 1, 1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.OverrideMaxLength = 0
        Me.TxtIdNo.ReadOnly = True
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(82, 26)
        Me.TxtIdNo.TabIndex = 0
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
        Me.lblEmployeeIdNo.Location = New System.Drawing.Point(1, 42)
        Me.lblEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
        Me.lblEmployeeIdNo.Size = New System.Drawing.Size(253, 28)
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
        Me.cboEmployeeIdNo.DisplayOnly = True
        Me.cboEmployeeIdNo.DropDownHeight = 24
        Me.cboEmployeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboEmployeeIdNo.Editable = True
        Me.cboEmployeeIdNo.EditingMode = False
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
        Me.cboEmployeeIdNo.Location = New System.Drawing.Point(256, 42)
        Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboEmployeeIdNo.MaxDropDownItems = 1
        Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
        Me.cboEmployeeIdNo.OldValue = 0
        Me.cboEmployeeIdNo.OriginalDataSource = Nothing
        Me.cboEmployeeIdNo.OriginalList = Nothing
        Me.cboEmployeeIdNo.OverrideDropDownStyleList = False
        Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
        Me.cboEmployeeIdNo.PropertySelector = Nothing
        Me.cboEmployeeIdNo.Size = New System.Drawing.Size(717, 29)
        Me.cboEmployeeIdNo.SuggestBoxHeight = 200
        Me.cboEmployeeIdNo.SuggestCharCount = 0
        Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
        Me.cboEmployeeIdNo.TabIndex = 1
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
        Me.lblLeaveName.Location = New System.Drawing.Point(1, 73)
        Me.lblLeaveName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblLeaveName.Name = "lblLeaveName"
        Me.lblLeaveName.Size = New System.Drawing.Size(253, 28)
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
        Me.cboLeaveIdNo.Location = New System.Drawing.Point(256, 73)
        Me.cboLeaveIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboLeaveIdNo.Name = "cboLeaveIdNo"
        Me.cboLeaveIdNo.OldValue = 0
        Me.cboLeaveIdNo.OriginalDataSource = Nothing
        Me.cboLeaveIdNo.OriginalList = Nothing
        Me.cboLeaveIdNo.OverrideDropDownStyleList = False
        Me.cboLeaveIdNo.PreviousSearchTerm = Nothing
        Me.cboLeaveIdNo.PropertySelector = Nothing
        Me.cboLeaveIdNo.Size = New System.Drawing.Size(717, 28)
        Me.cboLeaveIdNo.SuggestBoxHeight = 200
        Me.cboLeaveIdNo.SuggestCharCount = 0
        Me.cboLeaveIdNo.SuggestListOrderRule = Nothing
        Me.cboLeaveIdNo.TabIndex = 2
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
        Me.lblStartDate.Location = New System.Drawing.Point(1, 103)
        Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(253, 28)
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
        Me.dtpStartDate.Location = New System.Drawing.Point(256, 103)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ReadOnlyDp = False
        Me.dtpStartDate.SecurityKey = Nothing
        Me.dtpStartDate.ShowLongDate = False
        Me.dtpStartDate.ShowTime = False
        Me.dtpStartDate.Size = New System.Drawing.Size(119, 27)
        Me.dtpStartDate.TabIndex = 3
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
        Me.lblEndDate.Location = New System.Drawing.Point(1, 133)
        Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(253, 28)
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
        Me.dtpEndDate.Location = New System.Drawing.Point(256, 133)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ReadOnlyDp = False
        Me.dtpEndDate.SecurityKey = Nothing
        Me.dtpEndDate.ShowLongDate = False
        Me.dtpEndDate.ShowTime = False
        Me.dtpEndDate.Size = New System.Drawing.Size(119, 27)
        Me.dtpEndDate.TabIndex = 4
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
        Me.lblDaysEarned.Location = New System.Drawing.Point(1, 163)
        Me.lblDaysEarned.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDaysEarned.Name = "lblDaysEarned"
        Me.lblDaysEarned.Size = New System.Drawing.Size(253, 28)
        Me.lblDaysEarned.TabIndex = 323
        Me.lblDaysEarned.Text = "Leave Days Earned"
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
        Me.txtDaysEarned.Location = New System.Drawing.Point(256, 163)
        Me.txtDaysEarned.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDaysEarned.MaximumValue = Nothing
        Me.txtDaysEarned.MinimumValue = Nothing
        Me.txtDaysEarned.Name = "txtDaysEarned"
        Me.txtDaysEarned.OldValue = Nothing
        Me.txtDaysEarned.OverrideMaxLength = 0
        Me.txtDaysEarned.ReadOnly = True
        Me.txtDaysEarned.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDaysEarned.Size = New System.Drawing.Size(82, 26)
        Me.txtDaysEarned.TabIndex = 5
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
        Me.lblReason.Location = New System.Drawing.Point(1, 193)
        Me.lblReason.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(253, 28)
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
        Me.txtReason.Location = New System.Drawing.Point(256, 193)
        Me.txtReason.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReason.MaximumValue = Nothing
        Me.txtReason.MinimumValue = Nothing
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.OldValue = Nothing
        Me.txtReason.OverrideMaxLength = 0
        Me.txtReason.ReadOnly = True
        Me.txtReason.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtReason.Size = New System.Drawing.Size(718, 59)
        Me.txtReason.TabIndex = 6
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
        Me.lblenteredBy.Location = New System.Drawing.Point(1, 254)
        Me.lblenteredBy.Margin = New System.Windows.Forms.Padding(1)
        Me.lblenteredBy.Name = "lblenteredBy"
        Me.lblenteredBy.Size = New System.Drawing.Size(253, 28)
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
        Me.cboenteredBy.DropDownHeight = 24
        Me.cboenteredBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboenteredBy.Editable = True
        Me.cboenteredBy.EditingMode = False
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
        Me.cboenteredBy.LinkedLabel = Me.lblenteredBy
        Me.cboenteredBy.Location = New System.Drawing.Point(256, 254)
        Me.cboenteredBy.Margin = New System.Windows.Forms.Padding(1)
        Me.cboenteredBy.MaxDropDownItems = 1
        Me.cboenteredBy.Name = "cboenteredBy"
        Me.cboenteredBy.OldValue = 0
        Me.cboenteredBy.OriginalDataSource = Nothing
        Me.cboenteredBy.OriginalList = Nothing
        Me.cboenteredBy.OverrideDropDownStyleList = False
        Me.cboenteredBy.PreviousSearchTerm = Nothing
        Me.cboenteredBy.PropertySelector = Nothing
        Me.cboenteredBy.Size = New System.Drawing.Size(717, 31)
        Me.cboenteredBy.SuggestBoxHeight = 200
        Me.cboenteredBy.SuggestCharCount = 0
        Me.cboenteredBy.SuggestListOrderRule = Nothing
        Me.cboenteredBy.TabIndex = 7
        Me.cboenteredBy.TextToSearch = Nothing
        Me.cboenteredBy.Translatable = False
        Me.cboenteredBy.ValueIsMandatory = False
        Me.cboenteredBy.ValueIsNullable = False
        Me.cboenteredBy.ValueIsNumeric = False
        Me.cboenteredBy.ValueMember = "IdNo"
        '
        'lblApproved
        '
        Me.lblApproved.BackColor = System.Drawing.Color.Transparent
        Me.lblApproved.DisplayOnly = True
        Me.lblApproved.EditingMode = False
        Me.lblApproved.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblApproved.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblApproved.Location = New System.Drawing.Point(1, 287)
        Me.lblApproved.Margin = New System.Windows.Forms.Padding(1)
        Me.lblApproved.Name = "lblApproved"
        Me.lblApproved.Size = New System.Drawing.Size(253, 30)
        Me.lblApproved.TabIndex = 324
        Me.lblApproved.Text = "Approved?"
        Me.lblApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblApproved.Translatable = True
        '
        'chkApproved
        '
        Me.chkApproved.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkApproved.AutoCheck = False
        Me.chkApproved.BackColor = System.Drawing.Color.White
        Me.chkApproved.BegFindValue = Nothing
        Me.chkApproved.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkApproved.DisplayOnly = True
        Me.chkApproved.EditingMode = False
        Me.chkApproved.EndFindValue = Nothing
        Me.chkApproved.FieldDescription = Nothing
        Me.chkApproved.FieldName = Nothing
        Me.chkApproved.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkApproved.FindEnabled = True
        Me.chkApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout1.SetFlowBreak(Me.chkApproved, True)
        Me.chkApproved.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkApproved.ForeColor = System.Drawing.Color.Black
        Me.chkApproved.IFindableControl_FindEnabled = False
        Me.chkApproved.IgnoreCase = False
        Me.chkApproved.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkApproved.LinkedLabel = Me.lblApproved
        Me.chkApproved.Location = New System.Drawing.Point(256, 287)
        Me.chkApproved.Margin = New System.Windows.Forms.Padding(1)
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.NoLabel = False
        Me.chkApproved.OldValue = ""
        Me.chkApproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkApproved.Size = New System.Drawing.Size(19, 16)
        Me.chkApproved.TabIndex = 8
        Me.chkApproved.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkApproved.Translatable = False
        Me.chkApproved.UseVisualStyleBackColor = False
        '
        'lblDisapproved
        '
        Me.lblDisapproved.BackColor = System.Drawing.Color.Transparent
        Me.lblDisapproved.DisplayOnly = True
        Me.lblDisapproved.EditingMode = False
        Me.lblDisapproved.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblDisapproved.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDisapproved.Location = New System.Drawing.Point(1, 319)
        Me.lblDisapproved.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDisapproved.Name = "lblDisapproved"
        Me.lblDisapproved.Size = New System.Drawing.Size(253, 30)
        Me.lblDisapproved.TabIndex = 330
        Me.lblDisapproved.Text = "Disapproved?"
        Me.lblDisapproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDisapproved.Translatable = True
        '
        'chkDisapproved
        '
        Me.chkDisapproved.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkDisapproved.AutoCheck = False
        Me.chkDisapproved.BackColor = System.Drawing.Color.White
        Me.chkDisapproved.BegFindValue = Nothing
        Me.chkDisapproved.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDisapproved.DisplayOnly = True
        Me.chkDisapproved.EditingMode = False
        Me.chkDisapproved.EndFindValue = Nothing
        Me.chkDisapproved.FieldDescription = Nothing
        Me.chkDisapproved.FieldName = Nothing
        Me.chkDisapproved.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkDisapproved.FindEnabled = True
        Me.chkDisapproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout1.SetFlowBreak(Me.chkDisapproved, True)
        Me.chkDisapproved.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkDisapproved.ForeColor = System.Drawing.Color.Black
        Me.chkDisapproved.IFindableControl_FindEnabled = False
        Me.chkDisapproved.IgnoreCase = False
        Me.chkDisapproved.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkDisapproved.LinkedLabel = Me.lblApproved
        Me.chkDisapproved.Location = New System.Drawing.Point(256, 319)
        Me.chkDisapproved.Margin = New System.Windows.Forms.Padding(1)
        Me.chkDisapproved.Name = "chkDisapproved"
        Me.chkDisapproved.NoLabel = False
        Me.chkDisapproved.OldValue = ""
        Me.chkDisapproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkDisapproved.Size = New System.Drawing.Size(19, 16)
        Me.chkDisapproved.TabIndex = 9
        Me.chkDisapproved.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDisapproved.Translatable = False
        Me.chkDisapproved.UseVisualStyleBackColor = False
        '
        'lblApprovedBy
        '
        Me.lblApprovedBy.BackColor = System.Drawing.Color.Transparent
        Me.lblApprovedBy.DisplayOnly = True
        Me.lblApprovedBy.EditingMode = False
        Me.lblApprovedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblApprovedBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblApprovedBy.Location = New System.Drawing.Point(1, 351)
        Me.lblApprovedBy.Margin = New System.Windows.Forms.Padding(1)
        Me.lblApprovedBy.Name = "lblApprovedBy"
        Me.lblApprovedBy.Size = New System.Drawing.Size(253, 30)
        Me.lblApprovedBy.TabIndex = 325
        Me.lblApprovedBy.Text = "Approved / Disapproved by?"
        Me.lblApprovedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblApprovedBy.Translatable = True
        '
        'cboApprovedBy
        '
        Me.cboApprovedBy.BackColor = System.Drawing.Color.White
        Me.cboApprovedBy.BegFindValue = Nothing
        Me.cboApprovedBy.ChangingSearchValueOnly = False
        Me.cboApprovedBy.CurrentSearchTerm = ""
        Me.cboApprovedBy.DataValue = Nothing
        Me.cboApprovedBy.DefaultValue = Nothing
        Me.cboApprovedBy.DisplayMember = "Name"
        Me.cboApprovedBy.DisplayOnly = True
        Me.cboApprovedBy.DropDownHeight = 24
        Me.cboApprovedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboApprovedBy.Editable = True
        Me.cboApprovedBy.EditingMode = False
        Me.cboApprovedBy.EndFindValue = Nothing
        Me.cboApprovedBy.FieldDescription = Nothing
        Me.cboApprovedBy.FieldName = Nothing
        Me.cboApprovedBy.FilterRule = Nothing
        Me.cboApprovedBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[Integer]
        Me.cboApprovedBy.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.cboApprovedBy, True)
        Me.cboApprovedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboApprovedBy.ForeColor = System.Drawing.Color.Black
        Me.cboApprovedBy.FormattingEnabled = True
        Me.cboApprovedBy.HideWhenNotEditingOrAdding = False
        Me.cboApprovedBy.IgnoreCase = False
        Me.cboApprovedBy.IntegralHeight = False
        Me.cboApprovedBy.LimitToList = False
        Me.cboApprovedBy.LinkedLabel = Me.lblApprovedBy
        Me.cboApprovedBy.Location = New System.Drawing.Point(256, 351)
        Me.cboApprovedBy.Margin = New System.Windows.Forms.Padding(1)
        Me.cboApprovedBy.MaxDropDownItems = 1
        Me.cboApprovedBy.Name = "cboApprovedBy"
        Me.cboApprovedBy.OldValue = 0
        Me.cboApprovedBy.OriginalDataSource = Nothing
        Me.cboApprovedBy.OriginalList = Nothing
        Me.cboApprovedBy.OverrideDropDownStyleList = False
        Me.cboApprovedBy.PreviousSearchTerm = Nothing
        Me.cboApprovedBy.PropertySelector = Nothing
        Me.cboApprovedBy.Size = New System.Drawing.Size(717, 28)
        Me.cboApprovedBy.SuggestBoxHeight = 200
        Me.cboApprovedBy.SuggestCharCount = 0
        Me.cboApprovedBy.SuggestListOrderRule = Nothing
        Me.cboApprovedBy.TabIndex = 10
        Me.cboApprovedBy.TextToSearch = Nothing
        Me.cboApprovedBy.Translatable = False
        Me.cboApprovedBy.ValueIsMandatory = False
        Me.cboApprovedBy.ValueIsNullable = False
        Me.cboApprovedBy.ValueIsNumeric = False
        Me.cboApprovedBy.ValueMember = "IdNo"
        '
        'lblApprovalNote
        '
        Me.lblApprovalNote.BackColor = System.Drawing.Color.Transparent
        Me.lblApprovalNote.DisplayOnly = True
        Me.lblApprovalNote.EditingMode = False
        Me.lblApprovalNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblApprovalNote.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblApprovalNote.Location = New System.Drawing.Point(1, 383)
        Me.lblApprovalNote.Margin = New System.Windows.Forms.Padding(1)
        Me.lblApprovalNote.Name = "lblApprovalNote"
        Me.lblApprovalNote.Size = New System.Drawing.Size(253, 30)
        Me.lblApprovalNote.TabIndex = 327
        Me.lblApprovalNote.Text = "Approval/Disapproval Note"
        Me.lblApprovalNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblApprovalNote.Translatable = True
        '
        'txtApprovalNote
        '
        Me.txtApprovalNote.BackColor = System.Drawing.Color.White
        Me.txtApprovalNote.BegFindValue = Nothing
        Me.txtApprovalNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApprovalNote.ComputedValue = False
        Me.txtApprovalNote.CustomFormat = Nothing
        Me.txtApprovalNote.DataBoundControl = True
        Me.txtApprovalNote.DisplayOnly = True
        Me.txtApprovalNote.EditingMode = True
        Me.txtApprovalNote.EndFindValue = Nothing
        Me.txtApprovalNote.FieldDescription = Nothing
        Me.txtApprovalNote.FieldName = Nothing
        Me.txtApprovalNote.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtApprovalNote.FindEnabled = False
        Me.txtApprovalNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtApprovalNote.ForeColor = System.Drawing.Color.Black
        Me.txtApprovalNote.LinkedLabel = Me.lblApprovalNote
        Me.txtApprovalNote.Location = New System.Drawing.Point(256, 383)
        Me.txtApprovalNote.Margin = New System.Windows.Forms.Padding(1)
        Me.txtApprovalNote.MaximumValue = Nothing
        Me.txtApprovalNote.MinimumValue = Nothing
        Me.txtApprovalNote.Name = "txtApprovalNote"
        Me.txtApprovalNote.OldValue = Nothing
        Me.txtApprovalNote.OverrideMaxLength = 0
        Me.txtApprovalNote.ReadOnly = True
        Me.txtApprovalNote.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtApprovalNote.Size = New System.Drawing.Size(718, 26)
        Me.txtApprovalNote.TabIndex = 11
        Me.txtApprovalNote.Translatable = False
        '
        'lblDateCreated
        '
        Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
        Me.lblDateCreated.DisplayOnly = True
        Me.lblDateCreated.EditingMode = False
        Me.lblDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblDateCreated.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDateCreated.Location = New System.Drawing.Point(1, 415)
        Me.lblDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDateCreated.Name = "lblDateCreated"
        Me.lblDateCreated.Size = New System.Drawing.Size(253, 28)
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
        Me.txtDateCreated.Location = New System.Drawing.Point(256, 415)
        Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.OverrideMaxLength = 0
        Me.txtDateCreated.ReadOnly = True
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.Size = New System.Drawing.Size(171, 26)
        Me.txtDateCreated.TabIndex = 12
        Me.txtDateCreated.Translatable = False
        Me.txtDateCreated.ValueIsMandatory = True
        '
        'EmployeeLeaveEarnedEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 543)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "EmployeeLeaveEarnedEntry"
        Me.Text = "Employee Earned Leave Entry"
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
    Friend WithEvents lblApproved As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents chkApproved As Libraries.CBaseControlsLibrary.CCheckBox
    Friend WithEvents lblDateCreated As Libraries.CBaseControlsLibrary.CLabel
    Public WithEvents txtDateCreated As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblApprovedBy As Libraries.CBaseControlsLibrary.CLabel
    Public WithEvents cboApprovedBy As Libraries.CBaseControlsLibrary.CtComboBox
    Friend WithEvents lblApprovalNote As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtApprovalNote As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblDisapproved As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents chkDisapproved As Libraries.CBaseControlsLibrary.CCheckBox
End Class
