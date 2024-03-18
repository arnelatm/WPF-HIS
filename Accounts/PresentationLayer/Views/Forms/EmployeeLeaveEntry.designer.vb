Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeLeaveEntry
        Inherits CFormEntry

        'Form overrides dispose to clean up the component list.
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeLeaveEntry))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblLeaveName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboLeaveIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblHolidayName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboHolidayIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblFullDay = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkFullDay = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNoOfDays = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReason = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReason = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblStatus = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboStatus = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblenteredBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboenteredBy = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.DataGridViewApprovalHistory = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvApprovalIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvApprovalDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvItemIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvStatus = New AATM.Libraries.CBaseControlsLibrary.CtComboBoxColumn()
            Me.dgvApprovedBy = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvApprovalNote = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.EmployeeLeaveIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsEmployeeLeaveApprovalHistory = New System.Windows.Forms.BindingSource(Me.components)
            Me.bsEmployeeLeaveApproval = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            CType(Me.DataGridViewApprovalHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsEmployeeLeaveApprovalHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsEmployeeLeaveApproval, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
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
            Me.CFlowLayout2.SetFlowBreak(Me.TxtIdNo, True)
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblEmployeeIdNo
            '
            Me.lblEmployeeIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblEmployeeIdNo.DisplayOnly = True
            Me.lblEmployeeIdNo.EditingMode = False
            resources.ApplyResources(Me.lblEmployeeIdNo, "lblEmployeeIdNo")
            Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
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
            Me.cboEmployeeIdNo.EditingMode = True
            Me.cboEmployeeIdNo.EndFindValue = Nothing
            Me.cboEmployeeIdNo.FieldDescription = Nothing
            Me.cboEmployeeIdNo.FieldName = Nothing
            Me.cboEmployeeIdNo.FilterRule = Nothing
            Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboEmployeeIdNo.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.cboEmployeeIdNo, True)
            resources.ApplyResources(Me.cboEmployeeIdNo, "cboEmployeeIdNo")
            Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboEmployeeIdNo.FormattingEnabled = True
            Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboEmployeeIdNo.IgnoreCase = False
            Me.cboEmployeeIdNo.LimitToList = False
            Me.cboEmployeeIdNo.LinkedLabel = Me.lblEmployeeIdNo
            Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
            Me.cboEmployeeIdNo.OldValue = 0
            Me.cboEmployeeIdNo.OriginalDataSource = Nothing
            Me.cboEmployeeIdNo.OriginalList = Nothing
            Me.cboEmployeeIdNo.OverrideDropDownStyleList = False
            Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
            Me.cboEmployeeIdNo.PropertySelector = Nothing
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
            Me.cboEmployeeIdNo.SuggestCharCount = 0
            Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
            Me.cboEmployeeIdNo.TextToSearch = Nothing
            Me.cboEmployeeIdNo.Translatable = False
            Me.cboEmployeeIdNo.ValueIsMandatory = False
            Me.cboEmployeeIdNo.ValueIsNullable = False
            Me.cboEmployeeIdNo.ValueIsNumeric = False
            Me.cboEmployeeIdNo.ValueMember = "IdNo"
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.DisplayOnly = True
            Me.lblStartDate.EditingMode = False
            resources.ApplyResources(Me.lblStartDate, "lblStartDate")
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Translatable = True
            '
            'dtpStartDate
            '
            resources.ApplyResources(Me.dtpStartDate, "dtpStartDate")
            Me.dtpStartDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpStartDate.DefaultValue = Nothing
            Me.dtpStartDate.DisplayOnly = False
            Me.dtpStartDate.DtpDefaultValue = Nothing
            Me.dtpStartDate.EditingMode = True
            Me.dtpStartDate.EditsAllowed = False
            Me.CFlowLayout2.SetFlowBreak(Me.dtpStartDate, True)
            Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpStartDate.LinkedLabel = Me.lblStartDate
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
            Me.dtpStartDate.TargetCalendar = Nothing
            Me.dtpStartDate.Translatable = False
            Me.dtpStartDate.Value = Nothing
            Me.dtpStartDate.ValueIsMandatory = False
            Me.dtpStartDate.ValueIsNullable = False
            '
            'lblDateCreated
            '
            Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
            Me.lblDateCreated.Name = "lblDateCreated"
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
            Me.CFlowLayout2.SetFlowBreak(Me.txtDateCreated, True)
            resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.OverrideMaxLength = 0
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Translatable = False
            Me.txtDateCreated.ValueIsMandatory = True
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout2.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout2.Controls.Add(Me.lblEmployeeIdNo)
            Me.CFlowLayout2.Controls.Add(Me.cboEmployeeIdNo)
            Me.CFlowLayout2.Controls.Add(Me.lblLeaveName)
            Me.CFlowLayout2.Controls.Add(Me.cboLeaveIdNo)
            Me.CFlowLayout2.Controls.Add(Me.lblHolidayName)
            Me.CFlowLayout2.Controls.Add(Me.cboHolidayIdNo)
            Me.CFlowLayout2.Controls.Add(Me.lblFullDay)
            Me.CFlowLayout2.Controls.Add(Me.chkFullDay)
            Me.CFlowLayout2.Controls.Add(Me.lblStartDate)
            Me.CFlowLayout2.Controls.Add(Me.dtpStartDate)
            Me.CFlowLayout2.Controls.Add(Me.lblEndDate)
            Me.CFlowLayout2.Controls.Add(Me.dtpEndDate)
            Me.CFlowLayout2.Controls.Add(Me.CLabel2)
            Me.CFlowLayout2.Controls.Add(Me.txtNoOfDays)
            Me.CFlowLayout2.Controls.Add(Me.lblReason)
            Me.CFlowLayout2.Controls.Add(Me.txtReason)
            Me.CFlowLayout2.Controls.Add(Me.lblStatus)
            Me.CFlowLayout2.Controls.Add(Me.cboStatus)
            Me.CFlowLayout2.Controls.Add(Me.lblenteredBy)
            Me.CFlowLayout2.Controls.Add(Me.cboenteredBy)
            Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
            Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
            Me.CFlowLayout2.Controls.Add(Me.CLabel1)
            Me.CFlowLayout2.Controls.Add(Me.DataGridViewApprovalHistory)
            resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
            Me.CFlowLayout2.Name = "CFlowLayout2"
            '
            'lblLeaveName
            '
            Me.lblLeaveName.BackColor = System.Drawing.Color.Transparent
            Me.lblLeaveName.DisplayOnly = True
            Me.lblLeaveName.EditingMode = False
            resources.ApplyResources(Me.lblLeaveName, "lblLeaveName")
            Me.lblLeaveName.Name = "lblLeaveName"
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
            Me.CFlowLayout2.SetFlowBreak(Me.cboLeaveIdNo, True)
            resources.ApplyResources(Me.cboLeaveIdNo, "cboLeaveIdNo")
            Me.cboLeaveIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboLeaveIdNo.FormattingEnabled = True
            Me.cboLeaveIdNo.HideWhenNotEditingOrAdding = False
            Me.cboLeaveIdNo.IgnoreCase = False
            Me.cboLeaveIdNo.LimitToList = False
            Me.cboLeaveIdNo.LinkedLabel = Me.lblLeaveName
            Me.cboLeaveIdNo.Name = "cboLeaveIdNo"
            Me.cboLeaveIdNo.OldValue = 0
            Me.cboLeaveIdNo.OriginalDataSource = Nothing
            Me.cboLeaveIdNo.OriginalList = Nothing
            Me.cboLeaveIdNo.OverrideDropDownStyleList = False
            Me.cboLeaveIdNo.PreviousSearchTerm = Nothing
            Me.cboLeaveIdNo.PropertySelector = Nothing
            Me.cboLeaveIdNo.SuggestBoxHeight = 200
            Me.cboLeaveIdNo.SuggestCharCount = 0
            Me.cboLeaveIdNo.SuggestListOrderRule = Nothing
            Me.cboLeaveIdNo.TextToSearch = Nothing
            Me.cboLeaveIdNo.Translatable = False
            Me.cboLeaveIdNo.ValueIsMandatory = False
            Me.cboLeaveIdNo.ValueIsNullable = False
            Me.cboLeaveIdNo.ValueIsNumeric = False
            Me.cboLeaveIdNo.ValueMember = "IdNo"
            '
            'lblHolidayName
            '
            Me.lblHolidayName.BackColor = System.Drawing.Color.Transparent
            Me.lblHolidayName.DisplayOnly = True
            Me.lblHolidayName.EditingMode = False
            resources.ApplyResources(Me.lblHolidayName, "lblHolidayName")
            Me.lblHolidayName.Name = "lblHolidayName"
            Me.lblHolidayName.Translatable = True
            '
            'cboHolidayIdNo
            '
            Me.cboHolidayIdNo.BackColor = System.Drawing.Color.White
            Me.cboHolidayIdNo.BegFindValue = Nothing
            Me.cboHolidayIdNo.ChangingSearchValueOnly = False
            Me.cboHolidayIdNo.CurrentSearchTerm = ""
            Me.cboHolidayIdNo.DataValue = Nothing
            Me.cboHolidayIdNo.DefaultValue = Nothing
            Me.cboHolidayIdNo.DisplayMember = "Name"
            Me.cboHolidayIdNo.Editable = True
            Me.cboHolidayIdNo.EditingMode = True
            Me.cboHolidayIdNo.EndFindValue = Nothing
            Me.cboHolidayIdNo.FieldDescription = Nothing
            Me.cboHolidayIdNo.FieldName = Nothing
            Me.cboHolidayIdNo.FilterRule = Nothing
            Me.cboHolidayIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboHolidayIdNo.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.cboHolidayIdNo, True)
            resources.ApplyResources(Me.cboHolidayIdNo, "cboHolidayIdNo")
            Me.cboHolidayIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboHolidayIdNo.FormattingEnabled = True
            Me.cboHolidayIdNo.HideWhenNotEditingOrAdding = False
            Me.cboHolidayIdNo.IgnoreCase = False
            Me.cboHolidayIdNo.LimitToList = False
            Me.cboHolidayIdNo.LinkedLabel = Me.lblHolidayName
            Me.cboHolidayIdNo.Name = "cboHolidayIdNo"
            Me.cboHolidayIdNo.OldValue = 0
            Me.cboHolidayIdNo.OriginalDataSource = Nothing
            Me.cboHolidayIdNo.OriginalList = Nothing
            Me.cboHolidayIdNo.OverrideDropDownStyleList = False
            Me.cboHolidayIdNo.PreviousSearchTerm = Nothing
            Me.cboHolidayIdNo.PropertySelector = Nothing
            Me.cboHolidayIdNo.SuggestBoxHeight = 200
            Me.cboHolidayIdNo.SuggestCharCount = 0
            Me.cboHolidayIdNo.SuggestListOrderRule = Nothing
            Me.cboHolidayIdNo.TextToSearch = Nothing
            Me.cboHolidayIdNo.Translatable = False
            Me.cboHolidayIdNo.ValueIsMandatory = False
            Me.cboHolidayIdNo.ValueIsNullable = False
            Me.cboHolidayIdNo.ValueIsNumeric = False
            Me.cboHolidayIdNo.ValueMember = "IdNo"
            '
            'lblFullDay
            '
            Me.lblFullDay.BackColor = System.Drawing.Color.Transparent
            Me.lblFullDay.DisplayOnly = True
            Me.lblFullDay.EditingMode = False
            resources.ApplyResources(Me.lblFullDay, "lblFullDay")
            Me.lblFullDay.Name = "lblFullDay"
            Me.lblFullDay.Translatable = True
            '
            'chkFullDay
            '
            Me.chkFullDay.BackColor = System.Drawing.Color.White
            Me.chkFullDay.BegFindValue = Nothing
            Me.chkFullDay.DisplayOnly = False
            Me.chkFullDay.EditingMode = True
            Me.chkFullDay.EndFindValue = Nothing
            Me.chkFullDay.FieldDescription = Nothing
            Me.chkFullDay.FieldName = Nothing
            Me.chkFullDay.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkFullDay.FindEnabled = True
            resources.ApplyResources(Me.chkFullDay, "chkFullDay")
            Me.CFlowLayout2.SetFlowBreak(Me.chkFullDay, True)
            Me.chkFullDay.ForeColor = System.Drawing.Color.Black
            Me.chkFullDay.IFindableControl_FindEnabled = False
            Me.chkFullDay.IgnoreCase = False
            Me.chkFullDay.LinkedLabel = Me.lblFullDay
            Me.chkFullDay.Name = "chkFullDay"
            Me.chkFullDay.NoLabel = True
            Me.chkFullDay.OldValue = Nothing
            Me.chkFullDay.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkFullDay.Translatable = False
            Me.chkFullDay.UseVisualStyleBackColor = False
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            resources.ApplyResources(Me.lblEndDate, "lblEndDate")
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Translatable = True
            '
            'dtpEndDate
            '
            resources.ApplyResources(Me.dtpEndDate, "dtpEndDate")
            Me.dtpEndDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndDate.DefaultValue = Nothing
            Me.dtpEndDate.DisplayOnly = False
            Me.dtpEndDate.DtpDefaultValue = Nothing
            Me.dtpEndDate.EditingMode = True
            Me.dtpEndDate.EditsAllowed = False
            Me.CFlowLayout2.SetFlowBreak(Me.dtpEndDate, True)
            Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndDate.LinkedLabel = Me.lblEndDate
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.ReadOnlyDp = False
            Me.dtpEndDate.SecurityKey = Nothing
            Me.dtpEndDate.ShowLongDate = False
            Me.dtpEndDate.ShowTime = False
            Me.dtpEndDate.TargetCalendar = Nothing
            Me.dtpEndDate.Translatable = False
            Me.dtpEndDate.Value = Nothing
            Me.dtpEndDate.ValueIsMandatory = False
            Me.dtpEndDate.ValueIsNullable = False
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Translatable = True
            '
            'txtNoOfDays
            '
            Me.txtNoOfDays.BackColor = System.Drawing.Color.White
            Me.txtNoOfDays.BegFindValue = Nothing
            Me.txtNoOfDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNoOfDays.ComputedValue = True
            Me.txtNoOfDays.CustomFormat = Nothing
            Me.txtNoOfDays.DataBoundControl = True
            Me.txtNoOfDays.DisplayOnly = True
            Me.txtNoOfDays.EditingMode = True
            Me.txtNoOfDays.EndFindValue = Nothing
            Me.txtNoOfDays.FieldDescription = Nothing
            Me.txtNoOfDays.FieldName = Nothing
            Me.txtNoOfDays.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[Integer]
            Me.txtNoOfDays.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtNoOfDays, True)
            resources.ApplyResources(Me.txtNoOfDays, "txtNoOfDays")
            Me.txtNoOfDays.ForeColor = System.Drawing.Color.Black
            Me.txtNoOfDays.LinkedLabel = Me.lblIdNo
            Me.txtNoOfDays.MaximumValue = Nothing
            Me.txtNoOfDays.MinimumValue = Nothing
            Me.txtNoOfDays.Name = "txtNoOfDays"
            Me.txtNoOfDays.OldValue = Nothing
            Me.txtNoOfDays.OverrideMaxLength = 0
            Me.txtNoOfDays.ReadOnly = True
            Me.txtNoOfDays.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNoOfDays.TabStop = False
            Me.txtNoOfDays.Translatable = False
            Me.txtNoOfDays.ValueIsNumeric = True
            '
            'lblReason
            '
            Me.lblReason.BackColor = System.Drawing.Color.Transparent
            Me.lblReason.DisplayOnly = True
            Me.lblReason.EditingMode = False
            resources.ApplyResources(Me.lblReason, "lblReason")
            Me.lblReason.Name = "lblReason"
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
            Me.CFlowLayout2.SetFlowBreak(Me.txtReason, True)
            resources.ApplyResources(Me.txtReason, "txtReason")
            Me.txtReason.ForeColor = System.Drawing.Color.Black
            Me.txtReason.LinkedLabel = Me.lblReason
            Me.txtReason.MaximumValue = Nothing
            Me.txtReason.MinimumValue = Nothing
            Me.txtReason.Name = "txtReason"
            Me.txtReason.OldValue = Nothing
            Me.txtReason.OverrideMaxLength = 0
            Me.txtReason.ReadOnly = True
            Me.txtReason.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReason.Translatable = False
            Me.txtReason.ValueIsMandatory = True
            '
            'lblStatus
            '
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblStatus.DisplayOnly = True
            Me.lblStatus.EditingMode = False
            resources.ApplyResources(Me.lblStatus, "lblStatus")
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Translatable = True
            '
            'cboStatus
            '
            Me.cboStatus.BackColor = System.Drawing.Color.White
            Me.cboStatus.BegFindValue = Nothing
            Me.cboStatus.ChangingSearchValueOnly = False
            Me.cboStatus.CurrentSearchTerm = ""
            Me.cboStatus.DataValue = Nothing
            Me.cboStatus.DefaultValue = Nothing
            Me.cboStatus.DisplayMember = "Name"
            Me.cboStatus.DisplayOnly = True
            Me.cboStatus.DropDownHeight = 24
            Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboStatus.Editable = True
            Me.cboStatus.EditingMode = True
            Me.cboStatus.EndFindValue = Nothing
            Me.cboStatus.FieldDescription = Nothing
            Me.cboStatus.FieldName = Nothing
            Me.cboStatus.FilterRule = Nothing
            Me.cboStatus.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboStatus.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.cboStatus, True)
            resources.ApplyResources(Me.cboStatus, "cboStatus")
            Me.cboStatus.ForeColor = System.Drawing.Color.Black
            Me.cboStatus.FormattingEnabled = True
            Me.cboStatus.HideWhenNotEditingOrAdding = False
            Me.cboStatus.IgnoreCase = False
            Me.cboStatus.LimitToList = False
            Me.cboStatus.LinkedLabel = Me.lblStatus
            Me.cboStatus.Name = "cboStatus"
            Me.cboStatus.OldValue = 0
            Me.cboStatus.OriginalDataSource = Nothing
            Me.cboStatus.OriginalList = Nothing
            Me.cboStatus.OverrideDropDownStyleList = False
            Me.cboStatus.PreviousSearchTerm = Nothing
            Me.cboStatus.PropertySelector = Nothing
            Me.cboStatus.SuggestBoxHeight = 200
            Me.cboStatus.SuggestCharCount = 0
            Me.cboStatus.SuggestListOrderRule = Nothing
            Me.cboStatus.TextToSearch = Nothing
            Me.cboStatus.Translatable = False
            Me.cboStatus.ValueIsMandatory = False
            Me.cboStatus.ValueIsNullable = False
            Me.cboStatus.ValueIsNumeric = False
            Me.cboStatus.ValueMember = "Code"
            '
            'lblenteredBy
            '
            Me.lblenteredBy.BackColor = System.Drawing.Color.Transparent
            Me.lblenteredBy.DisplayOnly = True
            Me.lblenteredBy.EditingMode = False
            resources.ApplyResources(Me.lblenteredBy, "lblenteredBy")
            Me.lblenteredBy.Name = "lblenteredBy"
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
            Me.cboenteredBy.EditingMode = True
            Me.cboenteredBy.EndFindValue = Nothing
            Me.cboenteredBy.FieldDescription = Nothing
            Me.cboenteredBy.FieldName = Nothing
            Me.cboenteredBy.FilterRule = Nothing
            Me.cboenteredBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboenteredBy.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.cboenteredBy, True)
            resources.ApplyResources(Me.cboenteredBy, "cboenteredBy")
            Me.cboenteredBy.ForeColor = System.Drawing.Color.Black
            Me.cboenteredBy.FormattingEnabled = True
            Me.cboenteredBy.HideWhenNotEditingOrAdding = False
            Me.cboenteredBy.IgnoreCase = False
            Me.cboenteredBy.LimitToList = False
            Me.cboenteredBy.LinkedLabel = Me.lblEmployeeIdNo
            Me.cboenteredBy.Name = "cboenteredBy"
            Me.cboenteredBy.OldValue = 0
            Me.cboenteredBy.OriginalDataSource = Nothing
            Me.cboenteredBy.OriginalList = Nothing
            Me.cboenteredBy.OverrideDropDownStyleList = False
            Me.cboenteredBy.PreviousSearchTerm = Nothing
            Me.cboenteredBy.PropertySelector = Nothing
            Me.cboenteredBy.SuggestBoxHeight = 200
            Me.cboenteredBy.SuggestCharCount = 0
            Me.cboenteredBy.SuggestListOrderRule = Nothing
            Me.cboenteredBy.TextToSearch = Nothing
            Me.cboenteredBy.Translatable = False
            Me.cboenteredBy.ValueIsMandatory = False
            Me.cboenteredBy.ValueIsNullable = False
            Me.cboenteredBy.ValueIsNumeric = False
            Me.cboenteredBy.ValueMember = "IdNo"
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'DataGridViewApprovalHistory
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewApprovalHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewApprovalHistory.AutoGenerateColumns = False
            Me.DataGridViewApprovalHistory.BegFindValue = Nothing
            Me.DataGridViewApprovalHistory.Cached = False
            Me.DataGridViewApprovalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewApprovalHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvApprovalIdNo, Me.dgvApprovalDate, Me.dgvItemIdNo, Me.dgvStatus, Me.dgvApprovedBy, Me.dgvApprovalNote, Me.EmployeeLeaveIdNo})
            Me.DataGridViewApprovalHistory.DataFilter = Nothing
            Me.DataGridViewApprovalHistory.DataSource = Me.bsEmployeeLeaveApprovalHistory
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewApprovalHistory.DefaultCellStyle = DataGridViewCellStyle8
            Me.DataGridViewApprovalHistory.DgvFooter = Nothing
            Me.DataGridViewApprovalHistory.DisplayOnly = False
            Me.DataGridViewApprovalHistory.Ea = Nothing
            Me.DataGridViewApprovalHistory.EditingMode = False
            Me.DataGridViewApprovalHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewApprovalHistory.EndFindValue = Nothing
            Me.DataGridViewApprovalHistory.FieldDescription = Nothing
            Me.DataGridViewApprovalHistory.FieldName = Nothing
            Me.DataGridViewApprovalHistory.FieldsDictionary = Nothing
            Me.DataGridViewApprovalHistory.FindColumnNo = CType(0, Short)
            Me.DataGridViewApprovalHistory.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewApprovalHistory.FindEnabled = False
            Me.DataGridViewApprovalHistory.FirstRowDeletionEnabled = True
            Me.DataGridViewApprovalHistory.FirstRowInsertionEnabled = True
            Me.DataGridViewApprovalHistory.IgnoreCase = False
            Me.DataGridViewApprovalHistory.IsDirty = False
            resources.ApplyResources(Me.DataGridViewApprovalHistory, "DataGridViewApprovalHistory")
            Me.DataGridViewApprovalHistory.Name = "DataGridViewApprovalHistory"
            Me.DataGridViewApprovalHistory.OldCellValue = Nothing
            Me.DataGridViewApprovalHistory.ReadOnly = True
            Me.DataGridViewApprovalHistory.Searchable = True
            Me.DataGridViewApprovalHistory.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewApprovalHistory.SecurityKey = ""
            Me.DataGridViewApprovalHistory.SequenceColumn = "dgvSequence"
            Me.DataGridViewApprovalHistory.SequenceFieldName = "Sequence"
            Me.DataGridViewApprovalHistory.ShowFooter = False
            Me.DataGridViewApprovalHistory.Translatable = True
            '
            'dgvApprovalIdNo
            '
            Me.dgvApprovalIdNo.BegFindValue = Nothing
            Me.dgvApprovalIdNo.DataPropertyName = "ApprovalIdNo"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvApprovalIdNo.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvApprovalIdNo.EditingMode = False
            Me.dgvApprovalIdNo.EndFindValue = Nothing
            Me.dgvApprovalIdNo.FieldDescription = Nothing
            Me.dgvApprovalIdNo.FieldName = Nothing
            Me.dgvApprovalIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvApprovalIdNo.FindEnabled = False
            Me.dgvApprovalIdNo.Frozen = True
            resources.ApplyResources(Me.dgvApprovalIdNo, "dgvApprovalIdNo")
            Me.dgvApprovalIdNo.IgnoreCase = False
            Me.dgvApprovalIdNo.Name = "dgvApprovalIdNo"
            Me.dgvApprovalIdNo.ReadOnly = True
            Me.dgvApprovalIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvApprovalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvApprovalIdNo.Translatable = False
            '
            'dgvApprovalDate
            '
            Me.dgvApprovalDate.BegFindValue = Nothing
            Me.dgvApprovalDate.DataPropertyName = "ApprovalDate"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvApprovalDate.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvApprovalDate.EditingMode = False
            Me.dgvApprovalDate.EndFindValue = Nothing
            Me.dgvApprovalDate.FieldDescription = Nothing
            Me.dgvApprovalDate.FieldName = Nothing
            Me.dgvApprovalDate.FillWeight = 50.0!
            Me.dgvApprovalDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvApprovalDate.FindEnabled = False
            Me.dgvApprovalDate.Frozen = True
            resources.ApplyResources(Me.dgvApprovalDate, "dgvApprovalDate")
            Me.dgvApprovalDate.IgnoreCase = False
            Me.dgvApprovalDate.Name = "dgvApprovalDate"
            Me.dgvApprovalDate.ReadOnly = True
            Me.dgvApprovalDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvApprovalDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvApprovalDate.Translatable = False
            '
            'dgvItemIdNo
            '
            Me.dgvItemIdNo.BegFindValue = Nothing
            Me.dgvItemIdNo.DataPropertyName = "IdNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvItemIdNo.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvItemIdNo.EditingMode = False
            Me.dgvItemIdNo.EndFindValue = Nothing
            Me.dgvItemIdNo.FieldDescription = Nothing
            Me.dgvItemIdNo.FieldName = Nothing
            Me.dgvItemIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvItemIdNo.FindEnabled = False
            Me.dgvItemIdNo.Frozen = True
            resources.ApplyResources(Me.dgvItemIdNo, "dgvItemIdNo")
            Me.dgvItemIdNo.IgnoreCase = False
            Me.dgvItemIdNo.Name = "dgvItemIdNo"
            Me.dgvItemIdNo.ReadOnly = True
            Me.dgvItemIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvItemIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvItemIdNo.Translatable = False
            '
            'dgvStatus
            '
            Me.dgvStatus.AutoComplete = False
            Me.dgvStatus.DataPropertyName = "Status"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvStatus.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvStatus.EditingMode = False
            Me.dgvStatus.Frozen = True
            resources.ApplyResources(Me.dgvStatus, "dgvStatus")
            Me.dgvStatus.Name = "dgvStatus"
            Me.dgvStatus.ReadOnly = True
            Me.dgvStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvStatus.SuggestCharCount = 0
            Me.dgvStatus.Translatable = False
            '
            'dgvApprovedBy
            '
            Me.dgvApprovedBy.BegFindValue = Nothing
            Me.dgvApprovedBy.DataPropertyName = "ApprovedByName"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvApprovedBy.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvApprovedBy.EditingMode = False
            Me.dgvApprovedBy.EndFindValue = Nothing
            Me.dgvApprovedBy.FieldDescription = Nothing
            Me.dgvApprovedBy.FieldName = Nothing
            Me.dgvApprovedBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvApprovedBy.FindEnabled = False
            Me.dgvApprovedBy.Frozen = True
            resources.ApplyResources(Me.dgvApprovedBy, "dgvApprovedBy")
            Me.dgvApprovedBy.IgnoreCase = False
            Me.dgvApprovedBy.Name = "dgvApprovedBy"
            Me.dgvApprovedBy.ReadOnly = True
            Me.dgvApprovedBy.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvApprovedBy.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvApprovedBy.Translatable = False
            '
            'dgvApprovalNote
            '
            Me.dgvApprovalNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvApprovalNote.BegFindValue = Nothing
            Me.dgvApprovalNote.DataPropertyName = "ApprovalNote"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvApprovalNote.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvApprovalNote.DisplayOnly = True
            Me.dgvApprovalNote.EditingMode = False
            Me.dgvApprovalNote.EndFindValue = Nothing
            Me.dgvApprovalNote.FieldDescription = Nothing
            Me.dgvApprovalNote.FieldName = Nothing
            Me.dgvApprovalNote.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvApprovalNote.FindEnabled = False
            resources.ApplyResources(Me.dgvApprovalNote, "dgvApprovalNote")
            Me.dgvApprovalNote.IgnoreCase = False
            Me.dgvApprovalNote.Name = "dgvApprovalNote"
            Me.dgvApprovalNote.ReadOnly = True
            Me.dgvApprovalNote.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvApprovalNote.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvApprovalNote.Translatable = False
            '
            'EmployeeLeaveIdNo
            '
            Me.EmployeeLeaveIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.EmployeeLeaveIdNo.DataPropertyName = "EmployeeLeaveIdNo"
            resources.ApplyResources(Me.EmployeeLeaveIdNo, "EmployeeLeaveIdNo")
            Me.EmployeeLeaveIdNo.Name = "EmployeeLeaveIdNo"
            Me.EmployeeLeaveIdNo.ReadOnly = True
            '
            'bsEmployeeLeaveApprovalHistory
            '
            Me.bsEmployeeLeaveApprovalHistory.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeeLeaveApprovalHistoryModel)
            '
            'EmployeeLeaveEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Name = "EmployeeLeaveEntry"
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            CType(Me.DataGridViewApprovalHistory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsEmployeeLeaveApprovalHistory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsEmployeeLeaveApproval, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblIdNo As CLabel
        Public WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblEmployeeIdNo As CLabel
        Public WithEvents cboEmployeeIdNo As CtComboBox
        Friend WithEvents lblStartDate As CLabel
        Public WithEvents dtpStartDate As CCustomDateTimePicker
        Friend WithEvents lblDateCreated As CLabel
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblLeaveName As CLabel
        Public WithEvents cboLeaveIdNo As CtComboBox
        Friend WithEvents lblEndDate As CLabel
        Public WithEvents dtpEndDate As CCustomDateTimePicker
        Friend WithEvents lblFullDay As CLabel
        Friend WithEvents chkFullDay As CCheckBox
        Friend WithEvents lblReason As CLabel
        Public WithEvents txtReason As CTextBox
        Friend WithEvents lblStatus As CLabel
        Public WithEvents cboStatus As CtComboBox
        Friend WithEvents lblenteredBy As CLabel
        Public WithEvents cboenteredBy As CtComboBox
        Friend WithEvents DataGridViewApprovalHistory As CtDataGridView
        Friend WithEvents bsEmployeeLeaveApproval As BindingSource
        Friend WithEvents bsEmployeeLeaveApprovalHistory As BindingSource
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblHolidayName As CLabel
        Public WithEvents cboHolidayIdNo As CtComboBox
        Friend WithEvents dgvNote As CDgvTextColumn
        Friend WithEvents dgvDateCreated As CDgvTextColumn
        Friend WithEvents dgvApprovalIdNo As CDgvTextColumn
        Friend WithEvents dgvApprovalDate As CDgvTextColumn
        Friend WithEvents dgvItemIdNo As CDgvTextColumn
        Friend WithEvents dgvStatus As CtComboBoxColumn
        Friend WithEvents dgvApprovedBy As CDgvTextColumn
        Friend WithEvents dgvApprovalNote As CDgvTextColumn
        Friend WithEvents EmployeeLeaveIdNo As DataGridViewTextBoxColumn
        Friend WithEvents CLabel2 As CLabel
        Public WithEvents txtNoOfDays As CTextBox
    End Class
End Namespace