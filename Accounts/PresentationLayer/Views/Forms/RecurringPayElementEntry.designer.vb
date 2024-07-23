Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RecurringPayElementEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecurringPayElementEntry))
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
        Me.lblLimitAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtLimitAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblPeriodicAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPeriodicAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblPayElementName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayElementIdNo = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
        Me.lblRecurType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboRecurType = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblTotalAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTotalAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout2.SuspendLayout
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
        Me.TxtIdNo.FindEnabled = false
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
        Me.cboEmployeeIdNo.DataValue = Nothing
        Me.cboEmployeeIdNo.DefaultValue = Nothing
        Me.cboEmployeeIdNo.DisplayMember = "Name"
        Me.cboEmployeeIdNo.EditingMode = true
        Me.cboEmployeeIdNo.EndFindValue = Nothing
        Me.cboEmployeeIdNo.FieldDescription = Nothing
        Me.cboEmployeeIdNo.FieldName = Nothing
            Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboEmployeeIdNo.FindEnabled = false
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
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
            Me.cboEmployeeIdNo.TextToSearch = Nothing
            Me.cboEmployeeIdNo.Translatable = false
        Me.cboEmployeeIdNo.ValueIsMandatory = false
        Me.cboEmployeeIdNo.ValueIsNullable = false
        Me.cboEmployeeIdNo.ValueIsNumeric = false
        Me.cboEmployeeIdNo.ValueMember = "IdNo"
        '
        'lblLimitAmount
        '
        Me.lblLimitAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblLimitAmount.DisplayOnly = true
        Me.lblLimitAmount.EditingMode = false
        resources.ApplyResources(Me.lblLimitAmount, "lblLimitAmount")
        Me.lblLimitAmount.Name = "lblLimitAmount"
        Me.lblLimitAmount.Translatable = true
        '
        'txtLimitAmount
        '
        Me.txtLimitAmount.BackColor = System.Drawing.Color.White
        Me.txtLimitAmount.BegFindValue = Nothing
        Me.txtLimitAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLimitAmount.ComputedValue = false
        Me.txtLimitAmount.CustomFormat = Nothing
        Me.txtLimitAmount.DataBoundControl = true
        Me.txtLimitAmount.EditingMode = true
        Me.txtLimitAmount.EndFindValue = Nothing
        Me.txtLimitAmount.FieldDescription = Nothing
        Me.txtLimitAmount.FieldName = Nothing
        Me.txtLimitAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLimitAmount.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtLimitAmount, true)
        resources.ApplyResources(Me.txtLimitAmount, "txtLimitAmount")
        Me.txtLimitAmount.ForeColor = System.Drawing.Color.Black
        Me.txtLimitAmount.LinkedLabel = Me.lblLimitAmount
        Me.txtLimitAmount.MaximumValue = Nothing
        Me.txtLimitAmount.MinimumValue = Nothing
        Me.txtLimitAmount.Name = "txtLimitAmount"
        Me.txtLimitAmount.OldValue = Nothing
        Me.txtLimitAmount.ReadOnly = true
        Me.txtLimitAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLimitAmount.Translatable = false
        Me.txtLimitAmount.ValueIsMandatory = true
        Me.txtLimitAmount.ValueIsNumeric = true
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
        'lblPeriodicAmount
        '
        Me.lblPeriodicAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblPeriodicAmount.DisplayOnly = true
        Me.lblPeriodicAmount.EditingMode = false
        resources.ApplyResources(Me.lblPeriodicAmount, "lblPeriodicAmount")
        Me.lblPeriodicAmount.Name = "lblPeriodicAmount"
        Me.lblPeriodicAmount.Translatable = true
        '
        'txtPeriodicAmount
        '
        Me.txtPeriodicAmount.BackColor = System.Drawing.Color.White
        Me.txtPeriodicAmount.BegFindValue = Nothing
        Me.txtPeriodicAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodicAmount.ComputedValue = false
        Me.txtPeriodicAmount.CustomFormat = Nothing
        Me.txtPeriodicAmount.DataBoundControl = true
        Me.txtPeriodicAmount.EditingMode = true
        Me.txtPeriodicAmount.EndFindValue = Nothing
        Me.txtPeriodicAmount.FieldDescription = Nothing
        Me.txtPeriodicAmount.FieldName = Nothing
        Me.txtPeriodicAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPeriodicAmount.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtPeriodicAmount, true)
        resources.ApplyResources(Me.txtPeriodicAmount, "txtPeriodicAmount")
        Me.txtPeriodicAmount.ForeColor = System.Drawing.Color.Black
        Me.txtPeriodicAmount.LinkedLabel = Me.lblPeriodicAmount
        Me.txtPeriodicAmount.MaximumValue = Nothing
        Me.txtPeriodicAmount.MinimumValue = Nothing
        Me.txtPeriodicAmount.Name = "txtPeriodicAmount"
        Me.txtPeriodicAmount.OldValue = Nothing
        Me.txtPeriodicAmount.ReadOnly = true
        Me.txtPeriodicAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPeriodicAmount.Translatable = false
        Me.txtPeriodicAmount.ValueIsMandatory = true
        Me.txtPeriodicAmount.ValueIsNumeric = true
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
        Me.txtDateCreated.FindEnabled = false
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
        Me.CFlowLayout2.Controls.Add(Me.lblPayElementName)
        Me.CFlowLayout2.Controls.Add(Me.cboPayElementIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblRecurType)
        Me.CFlowLayout2.Controls.Add(Me.cboRecurType)
        Me.CFlowLayout2.Controls.Add(Me.lblPeriodicAmount)
        Me.CFlowLayout2.Controls.Add(Me.txtPeriodicAmount)
        Me.CFlowLayout2.Controls.Add(Me.lblLimitAmount)
        Me.CFlowLayout2.Controls.Add(Me.txtLimitAmount)
        Me.CFlowLayout2.Controls.Add(Me.lblStartDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpStartDate)
        Me.CFlowLayout2.Controls.Add(Me.lblEndDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpEndDate)
        Me.CFlowLayout2.Controls.Add(Me.lblTotalAmount)
        Me.CFlowLayout2.Controls.Add(Me.txtTotalAmount)
        Me.CFlowLayout2.Controls.Add(Me.CLabel2)
        Me.CFlowLayout2.Controls.Add(Me.chkActive)
        Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
        Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
        resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
        Me.CFlowLayout2.Name = "CFlowLayout2"
        '
        'lblPayElementName
        '
        Me.lblPayElementName.BackColor = System.Drawing.Color.Transparent
        Me.lblPayElementName.DisplayOnly = true
        Me.lblPayElementName.EditingMode = false
        resources.ApplyResources(Me.lblPayElementName, "lblPayElementName")
        Me.lblPayElementName.Name = "lblPayElementName"
        Me.lblPayElementName.Translatable = true
        '
        'cboPayElementIdNo
        '
        Me.cboPayElementIdNo.BackColor = System.Drawing.Color.White
        Me.cboPayElementIdNo.BegFindValue = Nothing
        Me.cboPayElementIdNo.ChangingSearchValueOnly = false
        Me.cboPayElementIdNo.CurrentSearchTerm = ""
        Me.cboPayElementIdNo.DataValue = Nothing
        Me.cboPayElementIdNo.DefaultValue = Nothing
        Me.cboPayElementIdNo.DisplayMember = "Name"
        Me.cboPayElementIdNo.EditingMode = true
        Me.cboPayElementIdNo.EndFindValue = Nothing
        Me.cboPayElementIdNo.FieldDescription = Nothing
        Me.cboPayElementIdNo.FieldName = Nothing
            Me.cboPayElementIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayElementIdNo.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.cboPayElementIdNo, true)
        resources.ApplyResources(Me.cboPayElementIdNo, "cboPayElementIdNo")
        Me.cboPayElementIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboPayElementIdNo.FormattingEnabled = true
        Me.cboPayElementIdNo.HideWhenNotEditingOrAdding = false
        Me.cboPayElementIdNo.IgnoreCase = false
        Me.cboPayElementIdNo.LinkedLabel = Me.lblEmployeeIdNo
        Me.cboPayElementIdNo.Name = "cboPayElementIdNo"
        Me.cboPayElementIdNo.OldValue = 0
        Me.cboPayElementIdNo.OriginalDataSource = Nothing
        Me.cboPayElementIdNo.OriginalList = Nothing
        Me.cboPayElementIdNo.OverrideDropDownStyleList = false
        Me.cboPayElementIdNo.PreviousSearchTerm = Nothing
            Me.cboPayElementIdNo.SuggestBoxHeight = 200
            Me.cboPayElementIdNo.TextToSearch = Nothing
            Me.cboPayElementIdNo.Translatable = false
        Me.cboPayElementIdNo.ValueIsMandatory = false
        Me.cboPayElementIdNo.ValueIsNullable = false
        Me.cboPayElementIdNo.ValueIsNumeric = false
        Me.cboPayElementIdNo.ValueMember = "IdNo"
        '
        'lblRecurType
        '
        Me.lblRecurType.BackColor = System.Drawing.Color.Transparent
        Me.lblRecurType.DisplayOnly = true
        Me.lblRecurType.EditingMode = false
        resources.ApplyResources(Me.lblRecurType, "lblRecurType")
        Me.lblRecurType.Name = "lblRecurType"
        Me.lblRecurType.Translatable = true
        '
        'cboRecurType
        '
        Me.cboRecurType.BackColor = System.Drawing.Color.White
        Me.cboRecurType.BegFindValue = Nothing
        Me.cboRecurType.ChangingSearchValueOnly = false
        Me.cboRecurType.CurrentSearchTerm = ""
        Me.cboRecurType.DataValue = Nothing
        Me.cboRecurType.DefaultValue = Nothing
        Me.cboRecurType.DisplayMember = "Name"
        Me.cboRecurType.EditingMode = true
        Me.cboRecurType.EndFindValue = Nothing
        Me.cboRecurType.FieldDescription = Nothing
        Me.cboRecurType.FieldName = Nothing
            Me.cboRecurType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboRecurType.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.cboRecurType, true)
        resources.ApplyResources(Me.cboRecurType, "cboRecurType")
        Me.cboRecurType.ForeColor = System.Drawing.Color.Black
        Me.cboRecurType.FormattingEnabled = true
        Me.cboRecurType.HideWhenNotEditingOrAdding = false
        Me.cboRecurType.IgnoreCase = false
        Me.cboRecurType.LinkedLabel = Me.lblEmployeeIdNo
        Me.cboRecurType.Name = "cboRecurType"
        Me.cboRecurType.OldValue = 0
        Me.cboRecurType.OriginalDataSource = Nothing
        Me.cboRecurType.OriginalList = Nothing
        Me.cboRecurType.OverrideDropDownStyleList = false
        Me.cboRecurType.PreviousSearchTerm = Nothing
            Me.cboRecurType.SuggestBoxHeight = 200
            Me.cboRecurType.TextToSearch = Nothing
            Me.cboRecurType.Translatable = false
        Me.cboRecurType.ValueIsMandatory = false
        Me.cboRecurType.ValueIsNullable = false
        Me.cboRecurType.ValueIsNumeric = false
        Me.cboRecurType.ValueMember = "Code"
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
        'lblTotalAmount
        '
        Me.lblTotalAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalAmount.DisplayOnly = true
        Me.lblTotalAmount.EditingMode = false
        resources.ApplyResources(Me.lblTotalAmount, "lblTotalAmount")
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Translatable = true
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.White
        Me.txtTotalAmount.BegFindValue = Nothing
        Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmount.ComputedValue = false
        Me.txtTotalAmount.CustomFormat = Nothing
        Me.txtTotalAmount.DataBoundControl = true
        Me.txtTotalAmount.DisplayOnly = true
        Me.txtTotalAmount.EditingMode = true
        Me.txtTotalAmount.EndFindValue = Nothing
        Me.txtTotalAmount.FieldDescription = Nothing
        Me.txtTotalAmount.FieldName = Nothing
        Me.txtTotalAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalAmount.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtTotalAmount, true)
        resources.ApplyResources(Me.txtTotalAmount, "txtTotalAmount")
        Me.txtTotalAmount.ForeColor = System.Drawing.Color.Black
        Me.txtTotalAmount.LinkedLabel = Me.lblTotalAmount
        Me.txtTotalAmount.MaximumValue = Nothing
        Me.txtTotalAmount.MinimumValue = Nothing
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.OldValue = Nothing
        Me.txtTotalAmount.ReadOnly = true
        Me.txtTotalAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalAmount.Translatable = false
        Me.txtTotalAmount.ValueIsMandatory = true
        Me.txtTotalAmount.ValueIsNumeric = true
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
        'chkActive
        '
        Me.chkActive.BackColor = System.Drawing.Color.White
        Me.chkActive.BegFindValue = Nothing
        Me.chkActive.DisplayOnly = false
        Me.chkActive.EditingMode = true
        Me.chkActive.EndFindValue = Nothing
        Me.chkActive.FieldDescription = Nothing
        Me.chkActive.FieldName = Nothing
        Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkActive.FindEnabled = false
        resources.ApplyResources(Me.chkActive, "chkActive")
        Me.CFlowLayout2.SetFlowBreak(Me.chkActive, true)
        Me.chkActive.ForeColor = System.Drawing.Color.Black
        Me.chkActive.IFindableControl_FindEnabled = false
        Me.chkActive.IgnoreCase = false
        Me.chkActive.LinkedLabel = Nothing
        Me.chkActive.Name = "chkActive"
        Me.chkActive.NoLabel = true
        Me.chkActive.OldValue = Nothing
        Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkActive.Translatable = false
        Me.chkActive.UseVisualStyleBackColor = false
        '
        'RecurringPayElementEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        Me.Controls.Add(Me.CFlowLayout2)
        Me.Name = "RecurringPayElementEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents lblIdNo As CLabel
        Public WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblEmployeeIdNo As CLabel
        Public WithEvents cboEmployeeIdNo As CdtComboBox
        Friend WithEvents lblLimitAmount As CLabel
        Public WithEvents txtLimitAmount As CTextBox
        Friend WithEvents lblStartDate As CLabel
        Public WithEvents dtpStartDate As CCustomDateTimePicker
        Friend WithEvents lblPeriodicAmount As CLabel
        Public WithEvents txtPeriodicAmount As CTextBox
        Friend WithEvents lblDateCreated As CLabel
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblPayElementName As CLabel
        Public WithEvents cboPayElementIdNo As CdtComboBox
        Friend WithEvents lblTotalAmount As CLabel
        Public WithEvents txtTotalAmount As CTextBox
        Friend WithEvents lblRecurType As CLabel
        Public WithEvents cboRecurType As CdtComboBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents lblEndDate As CLabel
        Public WithEvents dtpEndDate As CCustomDateTimePicker
    End Class
End Namespace