Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeLeaveEarnedEntryX
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeLeaveEarnedEntryX))
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
            Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblDaysEarned = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDaysEarned = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReason = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReason = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblenteredBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboenteredBy = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.SuspendLayout()
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
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
            Me.cboEmployeeIdNo.ReadOnlyCombo = False
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
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
            Me.CFlowLayout2.Controls.Add(Me.lblStartDate)
            Me.CFlowLayout2.Controls.Add(Me.dtpStartDate)
            Me.CFlowLayout2.Controls.Add(Me.lblEndDate)
            Me.CFlowLayout2.Controls.Add(Me.dtpEndDate)
            Me.CFlowLayout2.Controls.Add(Me.lblDaysEarned)
            Me.CFlowLayout2.Controls.Add(Me.txtDaysEarned)
            Me.CFlowLayout2.Controls.Add(Me.lblReason)
            Me.CFlowLayout2.Controls.Add(Me.txtReason)
            Me.CFlowLayout2.Controls.Add(Me.lblenteredBy)
            Me.CFlowLayout2.Controls.Add(Me.cboenteredBy)
            Me.CFlowLayout2.Controls.Add(Me.lblPosted)
            Me.CFlowLayout2.Controls.Add(Me.chkActive)
            Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
            Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
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
            Me.cboLeaveIdNo.ReadOnlyCombo = False
            Me.cboLeaveIdNo.SuggestBoxHeight = 200
            Me.cboLeaveIdNo.SuggestListOrderRule = Nothing
            Me.cboLeaveIdNo.TextToSearch = Nothing
            Me.cboLeaveIdNo.Translatable = False
            Me.cboLeaveIdNo.ValueIsMandatory = False
            Me.cboLeaveIdNo.ValueIsNullable = False
            Me.cboLeaveIdNo.ValueIsNumeric = False
            Me.cboLeaveIdNo.ValueMember = "IdNo"
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
            'lblDaysEarned
            '
            Me.lblDaysEarned.BackColor = System.Drawing.Color.Transparent
            Me.lblDaysEarned.DisplayOnly = True
            Me.lblDaysEarned.EditingMode = False
            resources.ApplyResources(Me.lblDaysEarned, "lblDaysEarned")
            Me.lblDaysEarned.Name = "lblDaysEarned"
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
            Me.CFlowLayout2.SetFlowBreak(Me.txtDaysEarned, True)
            resources.ApplyResources(Me.txtDaysEarned, "txtDaysEarned")
            Me.txtDaysEarned.ForeColor = System.Drawing.Color.Black
            Me.txtDaysEarned.LinkedLabel = Me.lblIdNo
            Me.txtDaysEarned.MaximumValue = Nothing
            Me.txtDaysEarned.MinimumValue = Nothing
            Me.txtDaysEarned.Name = "txtDaysEarned"
            Me.txtDaysEarned.OldValue = Nothing
            Me.txtDaysEarned.OverrideMaxLength = 0
            Me.txtDaysEarned.ReadOnly = True
            Me.txtDaysEarned.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDaysEarned.TabStop = False
            Me.txtDaysEarned.Translatable = False
            Me.txtDaysEarned.ValueIsNumeric = True
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
            Me.cboenteredBy.ReadOnlyCombo = True
            Me.cboenteredBy.SuggestBoxHeight = 200
            Me.cboenteredBy.SuggestListOrderRule = Nothing
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
            resources.ApplyResources(Me.lblPosted, "lblPosted")
            Me.lblPosted.Name = "lblPosted"
            Me.lblPosted.Translatable = True
            '
            'chkActive
            '
            resources.ApplyResources(Me.chkActive, "chkActive")
            Me.chkActive.AutoCheck = False
            Me.chkActive.BackColor = System.Drawing.Color.White
            Me.chkActive.BegFindValue = Nothing
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = False
            Me.chkActive.EndFindValue = Nothing
            Me.chkActive.FieldDescription = Nothing
            Me.chkActive.FieldName = Nothing
            Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkActive.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.chkActive, True)
            Me.chkActive.ForeColor = System.Drawing.Color.Black
            Me.chkActive.IFindableControl_FindEnabled = False
            Me.chkActive.IgnoreCase = False
            Me.chkActive.LinkedLabel = Me.lblPosted
            Me.chkActive.Name = "chkActive"
            Me.chkActive.NoLabel = False
            Me.chkActive.OldValue = ""
            Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkActive.Translatable = False
            Me.chkActive.UseVisualStyleBackColor = False
            '
            'EmployeeLeaveEarnedEntryX
            '
            resources.ApplyResources(Me, "$this")
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Name = "EmployeeLeaveEarnedEntryX"
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
        Friend WithEvents lblReason As CLabel
        Public WithEvents txtReason As CTextBox
        Friend WithEvents lblenteredBy As CLabel
        Public WithEvents cboenteredBy As CaComboBox
        Friend WithEvents dgvNote As CDgvTextColumn
        Friend WithEvents dgvDateCreated As CDgvTextColumn
        Friend WithEvents dgvItemIdNo As CDgvTextColumn
        Friend WithEvents EmployeeLeaveEarnedIdNo As DataGridViewTextBoxColumn
        Friend WithEvents lblDaysEarned As CLabel
        Public WithEvents txtDaysEarned As CTextBox
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents chkActive As CCheckBox
    End Class
End Namespace