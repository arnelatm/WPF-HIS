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
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.SuspendLayout()
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
            Me.TxtIdNo.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.TxtIdNo, True)
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
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
            Me.cboEmployeeIdNo.DefaultValue = Nothing
            Me.cboEmployeeIdNo.DisplayMember = "Name"
            Me.cboEmployeeIdNo.EditingMode = True
            Me.cboEmployeeIdNo.EndFindValue = Nothing
            Me.cboEmployeeIdNo.FieldDescription = Nothing
            Me.cboEmployeeIdNo.FieldName = Nothing
            Me.cboEmployeeIdNo.FilterRule = Nothing
            Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboEmployeeIdNo.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.cboEmployeeIdNo, True)
            resources.ApplyResources(Me.cboEmployeeIdNo, "cboEmployeeIdNo")
            Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboEmployeeIdNo.FormattingEnabled = True
            Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboEmployeeIdNo.IgnoreCase = False
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
            Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpStartDate.DefaultValue = Nothing
            Me.dtpStartDate.DisplayOnly = False
            Me.dtpStartDate.DtpDefaultValue = Nothing
            Me.dtpStartDate.EditingMode = True
            Me.dtpStartDate.EditsAllowed = False
            Me.CFlowLayout2.SetFlowBreak(Me.dtpStartDate, True)
            Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpStartDate.LinkedLabel = Me.lblStartDate
            resources.ApplyResources(Me.dtpStartDate, "dtpStartDate")
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
            Me.txtDateCreated.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDateCreated, True)
            resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
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
            Me.cboLeaveIdNo.DefaultValue = Nothing
            Me.cboLeaveIdNo.DisplayMember = "Name"
            Me.cboLeaveIdNo.EditingMode = True
            Me.cboLeaveIdNo.EndFindValue = Nothing
            Me.cboLeaveIdNo.FieldDescription = Nothing
            Me.cboLeaveIdNo.FieldName = Nothing
            Me.cboLeaveIdNo.FilterRule = Nothing
            Me.cboLeaveIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboLeaveIdNo.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.cboLeaveIdNo, True)
            resources.ApplyResources(Me.cboLeaveIdNo, "cboLeaveIdNo")
            Me.cboLeaveIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboLeaveIdNo.FormattingEnabled = True
            Me.cboLeaveIdNo.HideWhenNotEditingOrAdding = False
            Me.cboLeaveIdNo.IgnoreCase = False
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
            Me.chkFullDay.FindEnabled = False
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
            Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndDate.DefaultValue = Nothing
            Me.dtpEndDate.DisplayOnly = False
            Me.dtpEndDate.DtpDefaultValue = Nothing
            Me.dtpEndDate.EditingMode = True
            Me.dtpEndDate.EditsAllowed = False
            Me.CFlowLayout2.SetFlowBreak(Me.dtpEndDate, True)
            Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndDate.LinkedLabel = Me.lblEndDate
            resources.ApplyResources(Me.dtpEndDate, "dtpEndDate")
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
            'lblLeaveReason
            '
            Me.lblLeaveReason.BackColor = System.Drawing.Color.Transparent
            Me.lblLeaveReason.DisplayOnly = True
            Me.lblLeaveReason.EditingMode = False
            resources.ApplyResources(Me.lblLeaveReason, "lblLeaveReason")
            Me.lblLeaveReason.Name = "lblLeaveReason"
            Me.lblLeaveReason.Translatable = True
            '
            'txtLeaveReason
            '
            Me.txtLeaveReason.BackColor = System.Drawing.Color.White
            Me.txtLeaveReason.BegFindValue = Nothing
            Me.txtLeaveReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLeaveReason.ComputedValue = False
            Me.txtLeaveReason.CustomFormat = Nothing
            Me.txtLeaveReason.DataBoundControl = True
            Me.txtLeaveReason.EditingMode = True
            Me.txtLeaveReason.EndFindValue = Nothing
            Me.txtLeaveReason.FieldDescription = Nothing
            Me.txtLeaveReason.FieldName = Nothing
            Me.txtLeaveReason.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtLeaveReason.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtLeaveReason, True)
            resources.ApplyResources(Me.txtLeaveReason, "txtLeaveReason")
            Me.txtLeaveReason.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveReason.LinkedLabel = Me.lblLeaveReason
            Me.txtLeaveReason.MaximumValue = Nothing
            Me.txtLeaveReason.MinimumValue = Nothing
            Me.txtLeaveReason.Name = "txtLeaveReason"
            Me.txtLeaveReason.OldValue = Nothing
            Me.txtLeaveReason.ReadOnly = True
            Me.txtLeaveReason.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveReason.Translatable = False
            Me.txtLeaveReason.ValueIsMandatory = True
            '
            'lblLeaveStatus
            '
            Me.lblLeaveStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblLeaveStatus.DisplayOnly = True
            Me.lblLeaveStatus.EditingMode = False
            resources.ApplyResources(Me.lblLeaveStatus, "lblLeaveStatus")
            Me.lblLeaveStatus.Name = "lblLeaveStatus"
            Me.lblLeaveStatus.Translatable = True
            '
            'cboLeaveStatus
            '
            Me.cboLeaveStatus.BackColor = System.Drawing.Color.White
            Me.cboLeaveStatus.BegFindValue = Nothing
            Me.cboLeaveStatus.ChangingSearchValueOnly = False
            Me.cboLeaveStatus.CurrentSearchTerm = ""
            Me.cboLeaveStatus.DefaultValue = Nothing
            Me.cboLeaveStatus.DisplayMember = "Name"
            Me.cboLeaveStatus.EditingMode = True
            Me.cboLeaveStatus.EndFindValue = Nothing
            Me.cboLeaveStatus.FieldDescription = Nothing
            Me.cboLeaveStatus.FieldName = Nothing
            Me.cboLeaveStatus.FilterRule = Nothing
            Me.cboLeaveStatus.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboLeaveStatus.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.cboLeaveStatus, True)
            resources.ApplyResources(Me.cboLeaveStatus, "cboLeaveStatus")
            Me.cboLeaveStatus.ForeColor = System.Drawing.Color.Black
            Me.cboLeaveStatus.FormattingEnabled = True
            Me.cboLeaveStatus.HideWhenNotEditingOrAdding = False
            Me.cboLeaveStatus.IgnoreCase = False
            Me.cboLeaveStatus.LinkedLabel = Me.lblLeaveStatus
            Me.cboLeaveStatus.Name = "cboLeaveStatus"
            Me.cboLeaveStatus.OldValue = 0
            Me.cboLeaveStatus.OriginalDataSource = Nothing
            Me.cboLeaveStatus.OriginalList = Nothing
            Me.cboLeaveStatus.OverrideDropDownStyleList = False
            Me.cboLeaveStatus.PreviousSearchTerm = Nothing
            Me.cboLeaveStatus.PropertySelector = Nothing
            Me.cboLeaveStatus.ReadOnlyCombo = False
            Me.cboLeaveStatus.SuggestBoxHeight = 200
            Me.cboLeaveStatus.SuggestListOrderRule = Nothing
            Me.cboLeaveStatus.TextToSearch = Nothing
            Me.cboLeaveStatus.Translatable = False
            Me.cboLeaveStatus.ValueIsMandatory = False
            Me.cboLeaveStatus.ValueIsNullable = False
            Me.cboLeaveStatus.ValueIsNumeric = False
            Me.cboLeaveStatus.ValueMember = "Code"
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
        Friend WithEvents lblFullDay As CLabel
        Friend WithEvents chkFullDay As CCheckBox
        Friend WithEvents lblLeaveReason As CLabel
        Public WithEvents txtLeaveReason As CTextBox
        Friend WithEvents lblLeaveStatus As CLabel
        Public WithEvents cboLeaveStatus As CaComboBox
    End Class
End Namespace