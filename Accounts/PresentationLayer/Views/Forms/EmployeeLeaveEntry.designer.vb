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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblLeaveName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboLeaveIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblFullDay = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkFullDay = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblLeaveReason = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtLeaveReason = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblLeaveStatus = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboLeaveStatus = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.btnHistory = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.lblenteredBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboenteredBy = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewApprovalHistory = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.bsEmployeeLeaveApprovalHistory = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsEmployeeLeaveApproval = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvApprovalIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvItemIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvDateCreated = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvApprovedBy = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvLeaveStatus = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvNote = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.EmployeeLeaveIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout2.SuspendLayout
        CType(Me.DataGridViewApprovalHistory,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsEmployeeLeaveApprovalHistory,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsEmployeeLeaveApproval,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'lblIdNo
        '
        Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Translatable = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.CFlowLayout2.SetFlowBreak(Me.TxtIdNo, true)
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblEmployeeIdNo
        '
        Me.lblEmployeeIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblEmployeeIdNo.DisplayOnly = true
        Me.lblEmployeeIdNo.EditingMode = false
        resources.ApplyResources(Me.lblEmployeeIdNo, "lblEmployeeIdNo")
        Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
        Me.lblEmployeeIdNo.Translatable = true
        '
        'cboEmployeeIdNo
        '
        Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
        Me.cboEmployeeIdNo.BegFindValue = Nothing
        Me.cboEmployeeIdNo.ChangingSearchValueOnly = false
        Me.cboEmployeeIdNo.CurrentSearchTerm = ""
        Me.cboEmployeeIdNo.DefaultValue = Nothing
        Me.cboEmployeeIdNo.DisplayMember = "Name"
        Me.cboEmployeeIdNo.EditingMode = true
        Me.cboEmployeeIdNo.EndFindValue = Nothing
        Me.cboEmployeeIdNo.FieldDescription = Nothing
        Me.cboEmployeeIdNo.FieldName = Nothing
        Me.cboEmployeeIdNo.FilterRule = Nothing
        Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboEmployeeIdNo.FindEnabled = true
        Me.CFlowLayout2.SetFlowBreak(Me.cboEmployeeIdNo, true)
        resources.ApplyResources(Me.cboEmployeeIdNo, "cboEmployeeIdNo")
        Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboEmployeeIdNo.FormattingEnabled = true
        Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = false
        Me.cboEmployeeIdNo.IgnoreCase = false
        Me.cboEmployeeIdNo.LinkedLabel = Me.lblEmployeeIdNo
        Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
        Me.cboEmployeeIdNo.OldValue = 0
        Me.cboEmployeeIdNo.OriginalDataSource = Nothing
        Me.cboEmployeeIdNo.OriginalList = Nothing
        Me.cboEmployeeIdNo.OverrideDropDownStyleList = false
        Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
        Me.cboEmployeeIdNo.PropertySelector = Nothing
        Me.cboEmployeeIdNo.ReadOnlyCombo = false
        Me.cboEmployeeIdNo.SuggestBoxHeight = 200
        Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
        Me.cboEmployeeIdNo.TextToSearch = Nothing
        Me.cboEmployeeIdNo.Translatable = false
        Me.cboEmployeeIdNo.ValueIsMandatory = false
        Me.cboEmployeeIdNo.ValueIsNullable = false
        Me.cboEmployeeIdNo.ValueIsNumeric = false
        Me.cboEmployeeIdNo.ValueMember = "IdNo"
        '
        'lblStartDate
        '
        Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
        Me.lblStartDate.DisplayOnly = true
        Me.lblStartDate.EditingMode = false
        resources.ApplyResources(Me.lblStartDate, "lblStartDate")
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Translatable = true
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpStartDate.DefaultValue = Nothing
        Me.dtpStartDate.DisplayOnly = false
        Me.dtpStartDate.DtpDefaultValue = Nothing
        Me.dtpStartDate.EditingMode = true
        Me.dtpStartDate.EditsAllowed = false
        Me.CFlowLayout2.SetFlowBreak(Me.dtpStartDate, true)
        Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
        Me.dtpStartDate.LinkedLabel = Me.lblStartDate
        resources.ApplyResources(Me.dtpStartDate, "dtpStartDate")
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ReadOnlyDp = false
        Me.dtpStartDate.SecurityKey = Nothing
        Me.dtpStartDate.ShowLongDate = false
        Me.dtpStartDate.ShowTime = false
        Me.dtpStartDate.TargetCalendar = Nothing
        Me.dtpStartDate.Translatable = false
        Me.dtpStartDate.Value = Nothing
        Me.dtpStartDate.ValueIsMandatory = false
        Me.dtpStartDate.ValueIsNullable = false
        '
        'lblDateCreated
        '
        Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
        Me.lblDateCreated.DisplayOnly = true
        Me.lblDateCreated.EditingMode = false
        resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
        Me.lblDateCreated.Name = "lblDateCreated"
        Me.lblDateCreated.Translatable = true
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.Color.White
        Me.txtDateCreated.BegFindValue = Nothing
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.ComputedValue = false
        Me.txtDateCreated.CustomFormat = Nothing
        Me.txtDateCreated.DataBoundControl = true
        Me.txtDateCreated.DisplayOnly = true
        Me.txtDateCreated.EditingMode = true
        Me.txtDateCreated.EndFindValue = Nothing
        Me.txtDateCreated.FieldDescription = Nothing
        Me.txtDateCreated.FieldName = Nothing
        Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDateCreated.FindEnabled = true
        Me.CFlowLayout2.SetFlowBreak(Me.txtDateCreated, true)
        resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.ReadOnly = true
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.Translatable = false
        Me.txtDateCreated.ValueIsMandatory = true
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
        Me.CFlowLayout2.Controls.Add(Me.lblFullDay)
        Me.CFlowLayout2.Controls.Add(Me.chkFullDay)
        Me.CFlowLayout2.Controls.Add(Me.lblStartDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpStartDate)
        Me.CFlowLayout2.Controls.Add(Me.lblEndDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpEndDate)
        Me.CFlowLayout2.Controls.Add(Me.lblLeaveReason)
        Me.CFlowLayout2.Controls.Add(Me.txtLeaveReason)
        Me.CFlowLayout2.Controls.Add(Me.lblLeaveStatus)
        Me.CFlowLayout2.Controls.Add(Me.cboLeaveStatus)
        Me.CFlowLayout2.Controls.Add(Me.btnHistory)
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
        Me.lblLeaveName.DisplayOnly = true
        Me.lblLeaveName.EditingMode = false
        resources.ApplyResources(Me.lblLeaveName, "lblLeaveName")
        Me.lblLeaveName.Name = "lblLeaveName"
        Me.lblLeaveName.Translatable = true
        '
        'cboLeaveIdNo
        '
        Me.cboLeaveIdNo.BackColor = System.Drawing.Color.White
        Me.cboLeaveIdNo.BegFindValue = Nothing
        Me.cboLeaveIdNo.ChangingSearchValueOnly = false
        Me.cboLeaveIdNo.CurrentSearchTerm = ""
        Me.cboLeaveIdNo.DefaultValue = Nothing
        Me.cboLeaveIdNo.DisplayMember = "Name"
        Me.cboLeaveIdNo.EditingMode = true
        Me.cboLeaveIdNo.EndFindValue = Nothing
        Me.cboLeaveIdNo.FieldDescription = Nothing
        Me.cboLeaveIdNo.FieldName = Nothing
        Me.cboLeaveIdNo.FilterRule = Nothing
        Me.cboLeaveIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboLeaveIdNo.FindEnabled = true
        Me.CFlowLayout2.SetFlowBreak(Me.cboLeaveIdNo, true)
        resources.ApplyResources(Me.cboLeaveIdNo, "cboLeaveIdNo")
        Me.cboLeaveIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboLeaveIdNo.FormattingEnabled = true
        Me.cboLeaveIdNo.HideWhenNotEditingOrAdding = false
        Me.cboLeaveIdNo.IgnoreCase = false
        Me.cboLeaveIdNo.LinkedLabel = Me.lblLeaveName
        Me.cboLeaveIdNo.Name = "cboLeaveIdNo"
        Me.cboLeaveIdNo.OldValue = 0
        Me.cboLeaveIdNo.OriginalDataSource = Nothing
        Me.cboLeaveIdNo.OriginalList = Nothing
        Me.cboLeaveIdNo.OverrideDropDownStyleList = false
        Me.cboLeaveIdNo.PreviousSearchTerm = Nothing
        Me.cboLeaveIdNo.PropertySelector = Nothing
        Me.cboLeaveIdNo.ReadOnlyCombo = false
        Me.cboLeaveIdNo.SuggestBoxHeight = 200
        Me.cboLeaveIdNo.SuggestListOrderRule = Nothing
        Me.cboLeaveIdNo.TextToSearch = Nothing
        Me.cboLeaveIdNo.Translatable = false
        Me.cboLeaveIdNo.ValueIsMandatory = false
        Me.cboLeaveIdNo.ValueIsNullable = false
        Me.cboLeaveIdNo.ValueIsNumeric = false
        Me.cboLeaveIdNo.ValueMember = "IdNo"
        '
        'lblFullDay
        '
        Me.lblFullDay.BackColor = System.Drawing.Color.Transparent
        Me.lblFullDay.DisplayOnly = true
        Me.lblFullDay.EditingMode = false
        resources.ApplyResources(Me.lblFullDay, "lblFullDay")
        Me.lblFullDay.Name = "lblFullDay"
        Me.lblFullDay.Translatable = true
        '
        'chkFullDay
        '
        Me.chkFullDay.BackColor = System.Drawing.Color.White
        Me.chkFullDay.BegFindValue = Nothing
        Me.chkFullDay.DisplayOnly = false
        Me.chkFullDay.EditingMode = true
        Me.chkFullDay.EndFindValue = Nothing
        Me.chkFullDay.FieldDescription = Nothing
        Me.chkFullDay.FieldName = Nothing
        Me.chkFullDay.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkFullDay.FindEnabled = true
        resources.ApplyResources(Me.chkFullDay, "chkFullDay")
        Me.CFlowLayout2.SetFlowBreak(Me.chkFullDay, true)
        Me.chkFullDay.ForeColor = System.Drawing.Color.Black
        Me.chkFullDay.IFindableControl_FindEnabled = false
        Me.chkFullDay.IgnoreCase = false
        Me.chkFullDay.LinkedLabel = Me.lblFullDay
        Me.chkFullDay.Name = "chkFullDay"
        Me.chkFullDay.NoLabel = true
        Me.chkFullDay.OldValue = Nothing
        Me.chkFullDay.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkFullDay.Translatable = false
        Me.chkFullDay.UseVisualStyleBackColor = false
        '
        'lblEndDate
        '
        Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEndDate.DisplayOnly = true
        Me.lblEndDate.EditingMode = false
        resources.ApplyResources(Me.lblEndDate, "lblEndDate")
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Translatable = true
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndDate.DefaultValue = Nothing
        Me.dtpEndDate.DisplayOnly = false
        Me.dtpEndDate.DtpDefaultValue = Nothing
        Me.dtpEndDate.EditingMode = true
        Me.dtpEndDate.EditsAllowed = false
        Me.CFlowLayout2.SetFlowBreak(Me.dtpEndDate, true)
        Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndDate.LinkedLabel = Me.lblEndDate
        resources.ApplyResources(Me.dtpEndDate, "dtpEndDate")
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ReadOnlyDp = false
        Me.dtpEndDate.SecurityKey = Nothing
        Me.dtpEndDate.ShowLongDate = false
        Me.dtpEndDate.ShowTime = false
        Me.dtpEndDate.TargetCalendar = Nothing
        Me.dtpEndDate.Translatable = false
        Me.dtpEndDate.Value = Nothing
        Me.dtpEndDate.ValueIsMandatory = false
        Me.dtpEndDate.ValueIsNullable = false
        '
        'lblLeaveReason
        '
        Me.lblLeaveReason.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveReason.DisplayOnly = true
        Me.lblLeaveReason.EditingMode = false
        resources.ApplyResources(Me.lblLeaveReason, "lblLeaveReason")
        Me.lblLeaveReason.Name = "lblLeaveReason"
        Me.lblLeaveReason.Translatable = true
        '
        'txtLeaveReason
        '
        Me.txtLeaveReason.BackColor = System.Drawing.Color.White
        Me.txtLeaveReason.BegFindValue = Nothing
        Me.txtLeaveReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLeaveReason.ComputedValue = false
        Me.txtLeaveReason.CustomFormat = Nothing
        Me.txtLeaveReason.DataBoundControl = true
        Me.txtLeaveReason.EditingMode = true
        Me.txtLeaveReason.EndFindValue = Nothing
        Me.txtLeaveReason.FieldDescription = Nothing
        Me.txtLeaveReason.FieldName = Nothing
        Me.txtLeaveReason.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLeaveReason.FindEnabled = true
        Me.CFlowLayout2.SetFlowBreak(Me.txtLeaveReason, true)
        resources.ApplyResources(Me.txtLeaveReason, "txtLeaveReason")
        Me.txtLeaveReason.ForeColor = System.Drawing.Color.Black
        Me.txtLeaveReason.LinkedLabel = Me.lblLeaveReason
        Me.txtLeaveReason.MaximumValue = Nothing
        Me.txtLeaveReason.MinimumValue = Nothing
        Me.txtLeaveReason.Name = "txtLeaveReason"
        Me.txtLeaveReason.OldValue = Nothing
        Me.txtLeaveReason.ReadOnly = true
        Me.txtLeaveReason.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLeaveReason.Translatable = false
        Me.txtLeaveReason.ValueIsMandatory = true
        '
        'lblLeaveStatus
        '
        Me.lblLeaveStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveStatus.DisplayOnly = true
        Me.lblLeaveStatus.EditingMode = false
        resources.ApplyResources(Me.lblLeaveStatus, "lblLeaveStatus")
        Me.lblLeaveStatus.Name = "lblLeaveStatus"
        Me.lblLeaveStatus.Translatable = true
        '
        'cboLeaveStatus
        '
        Me.cboLeaveStatus.BackColor = System.Drawing.Color.White
        Me.cboLeaveStatus.BegFindValue = Nothing
        Me.cboLeaveStatus.ChangingSearchValueOnly = false
        Me.cboLeaveStatus.CurrentSearchTerm = ""
        Me.cboLeaveStatus.DefaultValue = Nothing
        Me.cboLeaveStatus.DisplayMember = "Name"
        Me.cboLeaveStatus.DisplayOnly = true
        Me.cboLeaveStatus.DropDownHeight = 24
        Me.cboLeaveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboLeaveStatus.EditingMode = true
        Me.cboLeaveStatus.EndFindValue = Nothing
        Me.cboLeaveStatus.FieldDescription = Nothing
        Me.cboLeaveStatus.FieldName = Nothing
        Me.cboLeaveStatus.FilterRule = Nothing
        Me.cboLeaveStatus.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboLeaveStatus.FindEnabled = true
        resources.ApplyResources(Me.cboLeaveStatus, "cboLeaveStatus")
        Me.cboLeaveStatus.ForeColor = System.Drawing.Color.Black
        Me.cboLeaveStatus.FormattingEnabled = true
        Me.cboLeaveStatus.HideWhenNotEditingOrAdding = false
        Me.cboLeaveStatus.IgnoreCase = false
        Me.cboLeaveStatus.LinkedLabel = Me.lblLeaveStatus
        Me.cboLeaveStatus.Name = "cboLeaveStatus"
        Me.cboLeaveStatus.OldValue = 0
        Me.cboLeaveStatus.OriginalDataSource = Nothing
        Me.cboLeaveStatus.OriginalList = Nothing
        Me.cboLeaveStatus.OverrideDropDownStyleList = false
        Me.cboLeaveStatus.PreviousSearchTerm = Nothing
        Me.cboLeaveStatus.PropertySelector = Nothing
        Me.cboLeaveStatus.ReadOnlyCombo = true
        Me.cboLeaveStatus.SuggestBoxHeight = 200
        Me.cboLeaveStatus.SuggestListOrderRule = Nothing
        Me.cboLeaveStatus.TextToSearch = Nothing
        Me.cboLeaveStatus.Translatable = false
        Me.cboLeaveStatus.ValueIsMandatory = false
        Me.cboLeaveStatus.ValueIsNullable = false
        Me.cboLeaveStatus.ValueIsNumeric = false
        Me.cboLeaveStatus.ValueMember = "Code"
        '
        'btnHistory
        '
        Me.btnHistory.DesignerSelected = false
        resources.ApplyResources(Me.btnHistory, "btnHistory")
        Me.btnHistory.ImageIndex = 0
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.OriginalImageName = Nothing
        Me.btnHistory.SecurityKey = ""
        '
        'lblenteredBy
        '
        Me.lblenteredBy.BackColor = System.Drawing.Color.Transparent
        Me.lblenteredBy.DisplayOnly = true
        Me.lblenteredBy.EditingMode = false
        resources.ApplyResources(Me.lblenteredBy, "lblenteredBy")
        Me.lblenteredBy.Name = "lblenteredBy"
        Me.lblenteredBy.Translatable = true
        '
        'cboenteredBy
        '
        Me.cboenteredBy.BackColor = System.Drawing.Color.White
        Me.cboenteredBy.BegFindValue = Nothing
        Me.cboenteredBy.ChangingSearchValueOnly = false
        Me.cboenteredBy.CurrentSearchTerm = ""
        Me.cboenteredBy.DefaultValue = Nothing
        Me.cboenteredBy.DisplayMember = "Name"
        Me.cboenteredBy.DisplayOnly = true
        Me.cboenteredBy.DropDownHeight = 24
        Me.cboenteredBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboenteredBy.EditingMode = true
        Me.cboenteredBy.EndFindValue = Nothing
        Me.cboenteredBy.FieldDescription = Nothing
        Me.cboenteredBy.FieldName = Nothing
        Me.cboenteredBy.FilterRule = Nothing
        Me.cboenteredBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboenteredBy.FindEnabled = true
        Me.CFlowLayout2.SetFlowBreak(Me.cboenteredBy, true)
        resources.ApplyResources(Me.cboenteredBy, "cboenteredBy")
        Me.cboenteredBy.ForeColor = System.Drawing.Color.Black
        Me.cboenteredBy.FormattingEnabled = true
        Me.cboenteredBy.HideWhenNotEditingOrAdding = false
        Me.cboenteredBy.IgnoreCase = false
        Me.cboenteredBy.LinkedLabel = Me.lblEmployeeIdNo
        Me.cboenteredBy.Name = "cboenteredBy"
        Me.cboenteredBy.OldValue = 0
        Me.cboenteredBy.OriginalDataSource = Nothing
        Me.cboenteredBy.OriginalList = Nothing
        Me.cboenteredBy.OverrideDropDownStyleList = false
        Me.cboenteredBy.PreviousSearchTerm = Nothing
        Me.cboenteredBy.PropertySelector = Nothing
        Me.cboenteredBy.ReadOnlyCombo = true
        Me.cboenteredBy.SuggestBoxHeight = 200
        Me.cboenteredBy.SuggestListOrderRule = Nothing
        Me.cboenteredBy.TextToSearch = Nothing
        Me.cboenteredBy.Translatable = false
        Me.cboenteredBy.ValueIsMandatory = false
        Me.cboenteredBy.ValueIsNullable = false
        Me.cboenteredBy.ValueIsNumeric = false
        Me.cboenteredBy.ValueMember = "IdNo"
        '
        'CLabel1
        '
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Translatable = true
        '
        'DataGridViewApprovalHistory
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewApprovalHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewApprovalHistory.AutoGenerateColumns = false
        Me.DataGridViewApprovalHistory.BegFindValue = Nothing
        Me.DataGridViewApprovalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewApprovalHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvApprovalIdNo, Me.dgvItemIdNo, Me.dgvDateCreated, Me.dgvApprovedBy, Me.dgvLeaveStatus, Me.dgvNote, Me.EmployeeLeaveIdNo})
        Me.DataGridViewApprovalHistory.DataSource = Me.bsEmployeeLeaveApprovalHistory
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewApprovalHistory.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewApprovalHistory.DgvFooter = Nothing
        Me.DataGridViewApprovalHistory.DisplayOnly = false
        Me.DataGridViewApprovalHistory.Ea = Nothing
        Me.DataGridViewApprovalHistory.EditingMode = false
        Me.DataGridViewApprovalHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewApprovalHistory.EndFindValue = Nothing
        Me.DataGridViewApprovalHistory.FieldDescription = Nothing
        Me.DataGridViewApprovalHistory.FieldName = Nothing
        Me.DataGridViewApprovalHistory.FieldsDictionary = Nothing
        Me.DataGridViewApprovalHistory.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewApprovalHistory.FindEnabled = false
        Me.DataGridViewApprovalHistory.FirstRowDeletionEnabled = true
        Me.DataGridViewApprovalHistory.FirstRowInsertionEnabled = true
        Me.DataGridViewApprovalHistory.IgnoreCase = false
        Me.DataGridViewApprovalHistory.IsDirty = false
        resources.ApplyResources(Me.DataGridViewApprovalHistory, "DataGridViewApprovalHistory")
        Me.DataGridViewApprovalHistory.Name = "DataGridViewApprovalHistory"
        Me.DataGridViewApprovalHistory.ReadOnly = true
        Me.DataGridViewApprovalHistory.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewApprovalHistory.SecurityKey = ""
        Me.DataGridViewApprovalHistory.SequenceColumn = "dgvSequence"
        Me.DataGridViewApprovalHistory.SequenceFieldName = "Sequence"
        Me.DataGridViewApprovalHistory.ShowFooter = false
        Me.DataGridViewApprovalHistory.ShowInsertColumnWhenEditing = true
        Me.DataGridViewApprovalHistory.Translatable = true
        '
        'bsEmployeeLeaveApprovalHistory
        '
        Me.bsEmployeeLeaveApprovalHistory.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeeLeaveApprovalHistoryModel)
        '
        'dgvApprovalIdNo
        '
        Me.dgvApprovalIdNo.BegFindValue = Nothing
        Me.dgvApprovalIdNo.DataPropertyName = "ApprovalIdNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvApprovalIdNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvApprovalIdNo.EditingMode = false
        Me.dgvApprovalIdNo.EndFindValue = Nothing
        Me.dgvApprovalIdNo.FieldDescription = Nothing
        Me.dgvApprovalIdNo.FieldName = Nothing
        Me.dgvApprovalIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvApprovalIdNo.FindEnabled = false
        resources.ApplyResources(Me.dgvApprovalIdNo, "dgvApprovalIdNo")
        Me.dgvApprovalIdNo.IgnoreCase = false
        Me.dgvApprovalIdNo.Name = "dgvApprovalIdNo"
        Me.dgvApprovalIdNo.ReadOnly = true
        Me.dgvApprovalIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvApprovalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvApprovalIdNo.Translatable = false
        '
        'dgvItemIdNo
        '
        Me.dgvItemIdNo.BegFindValue = Nothing
        Me.dgvItemIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvItemIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvItemIdNo.EditingMode = false
        Me.dgvItemIdNo.EndFindValue = Nothing
        Me.dgvItemIdNo.FieldDescription = Nothing
        Me.dgvItemIdNo.FieldName = Nothing
        Me.dgvItemIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvItemIdNo.FindEnabled = false
        resources.ApplyResources(Me.dgvItemIdNo, "dgvItemIdNo")
        Me.dgvItemIdNo.IgnoreCase = false
        Me.dgvItemIdNo.Name = "dgvItemIdNo"
        Me.dgvItemIdNo.ReadOnly = true
        Me.dgvItemIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvItemIdNo.Translatable = false
        '
        'dgvDateCreated
        '
        Me.dgvDateCreated.BegFindValue = Nothing
        Me.dgvDateCreated.DataPropertyName = "DateCreated"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvDateCreated.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDateCreated.EditingMode = false
        Me.dgvDateCreated.EndFindValue = Nothing
        Me.dgvDateCreated.FieldDescription = Nothing
        Me.dgvDateCreated.FieldName = Nothing
        Me.dgvDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDateCreated.FindEnabled = false
        resources.ApplyResources(Me.dgvDateCreated, "dgvDateCreated")
        Me.dgvDateCreated.IgnoreCase = false
        Me.dgvDateCreated.Name = "dgvDateCreated"
        Me.dgvDateCreated.ReadOnly = true
        Me.dgvDateCreated.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDateCreated.Translatable = false
        '
        'dgvApprovedBy
        '
        Me.dgvApprovedBy.DataPropertyName = "ApprovedBy"
        Me.dgvApprovedBy.EditingMode = false
        resources.ApplyResources(Me.dgvApprovedBy, "dgvApprovedBy")
        Me.dgvApprovedBy.Name = "dgvApprovedBy"
        Me.dgvApprovedBy.ReadOnly = true
        Me.dgvApprovedBy.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvApprovedBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvApprovedBy.Translatable = false
        '
        'dgvLeaveStatus
        '
        Me.dgvLeaveStatus.DataPropertyName = "Status"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvLeaveStatus.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvLeaveStatus.EditingMode = false
        resources.ApplyResources(Me.dgvLeaveStatus, "dgvLeaveStatus")
        Me.dgvLeaveStatus.Name = "dgvLeaveStatus"
        Me.dgvLeaveStatus.ReadOnly = true
        Me.dgvLeaveStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLeaveStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvLeaveStatus.Translatable = false
        '
        'dgvNote
        '
        Me.dgvNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvNote.BegFindValue = Nothing
        Me.dgvNote.DataPropertyName = "Note"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvNote.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvNote.EditingMode = false
        Me.dgvNote.EndFindValue = Nothing
        Me.dgvNote.FieldDescription = Nothing
        Me.dgvNote.FieldName = Nothing
        Me.dgvNote.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvNote.FindEnabled = false
        resources.ApplyResources(Me.dgvNote, "dgvNote")
        Me.dgvNote.IgnoreCase = false
        Me.dgvNote.Name = "dgvNote"
        Me.dgvNote.ReadOnly = true
        Me.dgvNote.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNote.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvNote.Translatable = false
        '
        'EmployeeLeaveIdNo
        '
        Me.EmployeeLeaveIdNo.DataPropertyName = "EmployeeLeaveIdNo"
        resources.ApplyResources(Me.EmployeeLeaveIdNo, "EmployeeLeaveIdNo")
        Me.EmployeeLeaveIdNo.Name = "EmployeeLeaveIdNo"
        Me.EmployeeLeaveIdNo.ReadOnly = true
        '
        'EmployeeLeaveEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        Me.Controls.Add(Me.CFlowLayout2)
        Me.Name = "EmployeeLeaveEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        CType(Me.DataGridViewApprovalHistory,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsEmployeeLeaveApprovalHistory,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsEmployeeLeaveApproval,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents lblIdNo As CLabel
        Public WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblEmployeeIdNo As CLabel
        Public WithEvents cboEmployeeIdNo As CaComboBox
        Friend WithEvents lblStartDate As CLabel
        Public WithEvents dtpStartDate As CCustomDateTimePicker
        Friend WithEvents lblDateCreated As CLabel
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblLeaveName As CLabel
        Public WithEvents cboLeaveIdNo As CaComboBox
        Friend WithEvents lblEndDate As CLabel
        Public WithEvents dtpEndDate As CCustomDateTimePicker
        Friend WithEvents lblFullDay As CLabel
        Friend WithEvents chkFullDay As CCheckBox
        Friend WithEvents lblLeaveReason As CLabel
        Public WithEvents txtLeaveReason As CTextBox
        Friend WithEvents lblLeaveStatus As CLabel
        Public WithEvents cboLeaveStatus As CaComboBox
        Friend WithEvents lblenteredBy As CLabel
        Public WithEvents cboenteredBy As CaComboBox
        Friend WithEvents btnHistory As CButton
        Friend WithEvents DataGridViewApprovalHistory As CDataGridView
        Friend WithEvents bsEmployeeLeaveApproval As BindingSource
        Friend WithEvents bsEmployeeLeaveApprovalHistory As BindingSource
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents dgvApprovalIdNo As CDgvTextColumn
        Friend WithEvents dgvItemIdNo As CDgvTextColumn
        Friend WithEvents dgvDateCreated As CDgvTextColumn
        Friend WithEvents dgvApprovedBy As CDgvComboBoxColumn
        Friend WithEvents dgvLeaveStatus As CDgvComboBoxColumn
        Friend WithEvents dgvNote As CDgvTextColumn
        Friend WithEvents EmployeeLeaveIdNo As DataGridViewTextBoxColumn
    End Class
End Namespace