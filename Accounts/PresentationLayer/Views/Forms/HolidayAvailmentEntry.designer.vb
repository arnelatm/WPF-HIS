Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class HolidayAvailmentEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HolidayAvailmentEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboHolidayTransferIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblHolidayIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboHolidayIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblAvailmentDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpAvailmentDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblStatus = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboStatus = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblenteredBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboenteredBy = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewApprovalHistory = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvApprovalIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.HolidayAvailmentIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsHolidayAvailmentApprovalHistory = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsHolidayAvailmentApproval = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout2.SuspendLayout
        CType(Me.DataGridViewApprovalHistory,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsHolidayAvailmentApprovalHistory,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsHolidayAvailmentApproval,System.ComponentModel.ISupportInitialize).BeginInit
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
        Me.CFlowLayout2.Controls.Add(Me.CLabel2)
        Me.CFlowLayout2.Controls.Add(Me.cboHolidayTransferIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblHolidayIdNo)
        Me.CFlowLayout2.Controls.Add(Me.cboHolidayIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblAvailmentDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpAvailmentDate)
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
        'CLabel2
        '
        Me.CLabel2.BackColor = System.Drawing.Color.Transparent
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        resources.ApplyResources(Me.CLabel2, "CLabel2")
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Translatable = true
        '
        'cboHolidayTransferIdNo
        '
        Me.cboHolidayTransferIdNo.BackColor = System.Drawing.Color.White
        Me.cboHolidayTransferIdNo.BegFindValue = Nothing
        Me.cboHolidayTransferIdNo.ChangingSearchValueOnly = false
        Me.cboHolidayTransferIdNo.CurrentSearchTerm = ""
        Me.cboHolidayTransferIdNo.DefaultValue = Nothing
        Me.cboHolidayTransferIdNo.DisplayMember = "Name"
        Me.cboHolidayTransferIdNo.EditingMode = true
        Me.cboHolidayTransferIdNo.EndFindValue = Nothing
        Me.cboHolidayTransferIdNo.FieldDescription = Nothing
        Me.cboHolidayTransferIdNo.FieldName = Nothing
        Me.cboHolidayTransferIdNo.FilterRule = Nothing
        Me.cboHolidayTransferIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboHolidayTransferIdNo.FindEnabled = true
        Me.CFlowLayout2.SetFlowBreak(Me.cboHolidayTransferIdNo, true)
        resources.ApplyResources(Me.cboHolidayTransferIdNo, "cboHolidayTransferIdNo")
        Me.cboHolidayTransferIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboHolidayTransferIdNo.FormattingEnabled = true
        Me.cboHolidayTransferIdNo.HideWhenNotEditingOrAdding = false
        Me.cboHolidayTransferIdNo.IgnoreCase = false
        Me.cboHolidayTransferIdNo.LinkedLabel = Me.lblEmployeeIdNo
        Me.cboHolidayTransferIdNo.Name = "cboHolidayTransferIdNo"
        Me.cboHolidayTransferIdNo.OldValue = 0
        Me.cboHolidayTransferIdNo.OriginalDataSource = Nothing
        Me.cboHolidayTransferIdNo.OriginalList = Nothing
        Me.cboHolidayTransferIdNo.OverrideDropDownStyleList = false
        Me.cboHolidayTransferIdNo.PreviousSearchTerm = Nothing
        Me.cboHolidayTransferIdNo.PropertySelector = Nothing
        Me.cboHolidayTransferIdNo.ReadOnlyCombo = false
        Me.cboHolidayTransferIdNo.SuggestBoxHeight = 200
        Me.cboHolidayTransferIdNo.SuggestListOrderRule = Nothing
        Me.cboHolidayTransferIdNo.TextToSearch = Nothing
        Me.cboHolidayTransferIdNo.Translatable = false
        Me.cboHolidayTransferIdNo.ValueIsMandatory = false
        Me.cboHolidayTransferIdNo.ValueIsNullable = false
        Me.cboHolidayTransferIdNo.ValueIsNumeric = false
        Me.cboHolidayTransferIdNo.ValueMember = "IdNo"
        '
        'lblHolidayIdNo
        '
        Me.lblHolidayIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblHolidayIdNo.DisplayOnly = true
        Me.lblHolidayIdNo.EditingMode = false
        resources.ApplyResources(Me.lblHolidayIdNo, "lblHolidayIdNo")
        Me.lblHolidayIdNo.Name = "lblHolidayIdNo"
        Me.lblHolidayIdNo.Translatable = true
        '
        'cboHolidayIdNo
        '
        Me.cboHolidayIdNo.BackColor = System.Drawing.Color.White
        Me.cboHolidayIdNo.BegFindValue = Nothing
        Me.cboHolidayIdNo.ChangingSearchValueOnly = false
        Me.cboHolidayIdNo.CurrentSearchTerm = ""
        Me.cboHolidayIdNo.DefaultValue = Nothing
        Me.cboHolidayIdNo.DisplayMember = "Name"
        Me.cboHolidayIdNo.DisplayOnly = true
        Me.cboHolidayIdNo.DropDownHeight = 30
        Me.cboHolidayIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboHolidayIdNo.EditingMode = true
        Me.cboHolidayIdNo.EndFindValue = Nothing
        Me.cboHolidayIdNo.FieldDescription = Nothing
        Me.cboHolidayIdNo.FieldName = Nothing
        Me.cboHolidayIdNo.FilterRule = Nothing
        Me.cboHolidayIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboHolidayIdNo.FindEnabled = true
        Me.CFlowLayout2.SetFlowBreak(Me.cboHolidayIdNo, true)
        resources.ApplyResources(Me.cboHolidayIdNo, "cboHolidayIdNo")
        Me.cboHolidayIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboHolidayIdNo.FormattingEnabled = true
        Me.cboHolidayIdNo.HideWhenNotEditingOrAdding = false
        Me.cboHolidayIdNo.IgnoreCase = false
        Me.cboHolidayIdNo.LinkedLabel = Me.lblHolidayIdNo
        Me.cboHolidayIdNo.Name = "cboHolidayIdNo"
        Me.cboHolidayIdNo.OldValue = 0
        Me.cboHolidayIdNo.OriginalDataSource = Nothing
        Me.cboHolidayIdNo.OriginalList = Nothing
        Me.cboHolidayIdNo.OverrideDropDownStyleList = false
        Me.cboHolidayIdNo.PreviousSearchTerm = Nothing
        Me.cboHolidayIdNo.PropertySelector = Nothing
        Me.cboHolidayIdNo.ReadOnlyCombo = true
        Me.cboHolidayIdNo.SuggestBoxHeight = 200
        Me.cboHolidayIdNo.SuggestListOrderRule = Nothing
        Me.cboHolidayIdNo.TextToSearch = Nothing
        Me.cboHolidayIdNo.Translatable = false
        Me.cboHolidayIdNo.ValueIsMandatory = false
        Me.cboHolidayIdNo.ValueIsNullable = false
        Me.cboHolidayIdNo.ValueIsNumeric = false
        Me.cboHolidayIdNo.ValueMember = "Code"
        '
        'lblAvailmentDate
        '
        Me.lblAvailmentDate.BackColor = System.Drawing.Color.Transparent
        Me.lblAvailmentDate.DisplayOnly = true
        Me.lblAvailmentDate.EditingMode = false
        resources.ApplyResources(Me.lblAvailmentDate, "lblAvailmentDate")
        Me.lblAvailmentDate.Name = "lblAvailmentDate"
        Me.lblAvailmentDate.Translatable = true
        '
        'dtpAvailmentDate
        '
        Me.dtpAvailmentDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpAvailmentDate.DefaultValue = Nothing
        Me.dtpAvailmentDate.DisplayOnly = false
        Me.dtpAvailmentDate.DtpDefaultValue = Nothing
        Me.dtpAvailmentDate.EditingMode = true
        Me.dtpAvailmentDate.EditsAllowed = false
        Me.CFlowLayout2.SetFlowBreak(Me.dtpAvailmentDate, true)
        Me.dtpAvailmentDate.ForeColor = System.Drawing.Color.Black
        Me.dtpAvailmentDate.LinkedLabel = Me.lblAvailmentDate
        resources.ApplyResources(Me.dtpAvailmentDate, "dtpAvailmentDate")
        Me.dtpAvailmentDate.Name = "dtpAvailmentDate"
        Me.dtpAvailmentDate.ReadOnlyDp = false
        Me.dtpAvailmentDate.SecurityKey = Nothing
        Me.dtpAvailmentDate.ShowLongDate = false
        Me.dtpAvailmentDate.ShowTime = false
        Me.dtpAvailmentDate.TargetCalendar = Nothing
        Me.dtpAvailmentDate.Translatable = false
        Me.dtpAvailmentDate.Value = Nothing
        Me.dtpAvailmentDate.ValueIsMandatory = false
        Me.dtpAvailmentDate.ValueIsNullable = false
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.DisplayOnly = true
        Me.lblStatus.EditingMode = false
        resources.ApplyResources(Me.lblStatus, "lblStatus")
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Translatable = true
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.Color.White
        Me.cboStatus.BegFindValue = Nothing
        Me.cboStatus.ChangingSearchValueOnly = false
        Me.cboStatus.CurrentSearchTerm = ""
        Me.cboStatus.DefaultValue = Nothing
        Me.cboStatus.DisplayMember = "Name"
        Me.cboStatus.DisplayOnly = true
        Me.cboStatus.DropDownHeight = 24
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboStatus.EditingMode = true
        Me.cboStatus.EndFindValue = Nothing
        Me.cboStatus.FieldDescription = Nothing
        Me.cboStatus.FieldName = Nothing
        Me.cboStatus.FilterRule = Nothing
        Me.cboStatus.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboStatus.FindEnabled = true
        resources.ApplyResources(Me.cboStatus, "cboStatus")
        Me.cboStatus.ForeColor = System.Drawing.Color.Black
        Me.cboStatus.FormattingEnabled = true
        Me.cboStatus.HideWhenNotEditingOrAdding = false
        Me.cboStatus.IgnoreCase = false
        Me.cboStatus.LinkedLabel = Me.lblStatus
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.OldValue = 0
        Me.cboStatus.OriginalDataSource = Nothing
        Me.cboStatus.OriginalList = Nothing
        Me.cboStatus.OverrideDropDownStyleList = false
        Me.cboStatus.PreviousSearchTerm = Nothing
        Me.cboStatus.PropertySelector = Nothing
        Me.cboStatus.ReadOnlyCombo = true
        Me.cboStatus.SuggestBoxHeight = 200
        Me.cboStatus.SuggestListOrderRule = Nothing
        Me.cboStatus.TextToSearch = Nothing
        Me.cboStatus.Translatable = false
        Me.cboStatus.ValueIsMandatory = false
        Me.cboStatus.ValueIsNullable = false
        Me.cboStatus.ValueIsNumeric = false
        Me.cboStatus.ValueMember = "Code"
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
        Me.DataGridViewApprovalHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvApprovalIdNo, Me.HolidayAvailmentIdNo})
        Me.DataGridViewApprovalHistory.DataSource = Me.bsHolidayAvailmentApprovalHistory
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewApprovalHistory.DefaultCellStyle = DataGridViewCellStyle3
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
        'HolidayAvailmentIdNo
        '
        Me.HolidayAvailmentIdNo.DataPropertyName = "HolidayAvailmentIdNo"
        resources.ApplyResources(Me.HolidayAvailmentIdNo, "HolidayAvailmentIdNo")
        Me.HolidayAvailmentIdNo.Name = "HolidayAvailmentIdNo"
        Me.HolidayAvailmentIdNo.ReadOnly = true
        '
        'HolidayAvailmentEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        Me.Controls.Add(Me.CFlowLayout2)
        Me.Name = "HolidayAvailmentEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        CType(Me.DataGridViewApprovalHistory,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsHolidayAvailmentApprovalHistory,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsHolidayAvailmentApproval,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents lblIdNo As CLabel
        Public WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblEmployeeIdNo As CLabel
        Public WithEvents cboEmployeeIdNo As CaComboBox
        Friend WithEvents lblDateCreated As CLabel
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblenteredBy As CLabel
        Public WithEvents cboenteredBy As CaComboBox
        Friend WithEvents DataGridViewApprovalHistory As CDataGridView
        Friend WithEvents bsHolidayAvailmentApproval As BindingSource
        Friend WithEvents bsHolidayAvailmentApprovalHistory As BindingSource
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents dgvApprovalIdNo As CDgvTextColumn
        Friend WithEvents dgvItemIdNo As CDgvTextColumn
        Friend WithEvents dgvDateCreated As CDgvTextColumn
        Friend WithEvents dgvEnteredBy As CaDgvComboBoxColumn
        Friend WithEvents dgvNote As CDgvTextColumn
        Friend WithEvents dgvLeaveStatus As CDgvComboBoxColumn
        Friend WithEvents HolidayAvailmentIdNo As DataGridViewTextBoxColumn
        Friend WithEvents CLabel2 As CLabel
        Public WithEvents cboHolidayTransferIdNo As CaComboBox
        Friend WithEvents lblHolidayIdNo As CLabel
        Public WithEvents cboHolidayIdNo As CaComboBox
        Friend WithEvents lblStatus As CLabel
        Friend WithEvents lblAvailmentDate As CLabel
        Public WithEvents dtpAvailmentDate As CCustomDateTimePicker
        Public WithEvents cboStatus As CaComboBox
    End Class
End Namespace