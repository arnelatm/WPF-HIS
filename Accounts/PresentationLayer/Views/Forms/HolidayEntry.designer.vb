Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class HolidayEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HolidayEntry))
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblLeaveIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboLeaveIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollStartDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollEndDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNote = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDescription = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateStart = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateEnd = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
        'lblLeaveIdNo
        '
        Me.lblLeaveIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveIdNo.DisplayOnly = true
        Me.lblLeaveIdNo.EditingMode = false
        resources.ApplyResources(Me.lblLeaveIdNo, "lblLeaveIdNo")
        Me.lblLeaveIdNo.Name = "lblLeaveIdNo"
        Me.lblLeaveIdNo.Translatable = true
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
        Me.cboLeaveIdNo.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.cboLeaveIdNo, true)
        resources.ApplyResources(Me.cboLeaveIdNo, "cboLeaveIdNo")
        Me.cboLeaveIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboLeaveIdNo.FormattingEnabled = true
        Me.cboLeaveIdNo.HideWhenNotEditingOrAdding = false
        Me.cboLeaveIdNo.IgnoreCase = false
        Me.cboLeaveIdNo.LinkedLabel = Me.lblLeaveIdNo
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
        'CFlowLayout2
        '
        Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout2.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout2.Controls.Add(Me.TxtIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblPayrollIdNo)
        Me.CFlowLayout2.Controls.Add(Me.txtPayrollIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblPayrollCode)
        Me.CFlowLayout2.Controls.Add(Me.txtPayrollCode)
        Me.CFlowLayout2.Controls.Add(Me.lblPayrollStartDate)
        Me.CFlowLayout2.Controls.Add(Me.txtPayrollStartDate)
        Me.CFlowLayout2.Controls.Add(Me.lblPayrollEndDate)
        Me.CFlowLayout2.Controls.Add(Me.txtPayrollEndDate)
        Me.CFlowLayout2.Controls.Add(Me.lblPayrollName)
        Me.CFlowLayout2.Controls.Add(Me.txtPayrollName)
        Me.CFlowLayout2.Controls.Add(Me.lblNote)
        Me.CFlowLayout2.Controls.Add(Me.txtDescription)
        Me.CFlowLayout2.Controls.Add(Me.lblLeaveIdNo)
        Me.CFlowLayout2.Controls.Add(Me.cboLeaveIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblStartDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpDateStart)
        Me.CFlowLayout2.Controls.Add(Me.lblEndDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpDateEnd)
        Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
        Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
        resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
        Me.CFlowLayout2.Name = "CFlowLayout2"
        '
        'lblPayrollIdNo
        '
        Me.lblPayrollIdNo.DisplayOnly = true
        Me.lblPayrollIdNo.EditingMode = false
        resources.ApplyResources(Me.lblPayrollIdNo, "lblPayrollIdNo")
        Me.lblPayrollIdNo.Name = "lblPayrollIdNo"
        Me.lblPayrollIdNo.Translatable = true
        '
        'txtPayrollIdNo
        '
        Me.txtPayrollIdNo.BackColor = System.Drawing.Color.White
        Me.txtPayrollIdNo.BegFindValue = Nothing
        Me.txtPayrollIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollIdNo.ComputedValue = false
        Me.txtPayrollIdNo.CustomFormat = Nothing
        Me.txtPayrollIdNo.DataBoundControl = true
        Me.txtPayrollIdNo.DisplayOnly = true
        Me.txtPayrollIdNo.EditingMode = true
        Me.txtPayrollIdNo.EndFindValue = Nothing
        Me.txtPayrollIdNo.FieldDescription = Nothing
        Me.txtPayrollIdNo.FieldName = Nothing
        Me.txtPayrollIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollIdNo.FindEnabled = false
        resources.ApplyResources(Me.txtPayrollIdNo, "txtPayrollIdNo")
        Me.txtPayrollIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollIdNo.LinkedLabel = Nothing
        Me.txtPayrollIdNo.MaximumValue = Nothing
        Me.txtPayrollIdNo.MinimumValue = Nothing
        Me.txtPayrollIdNo.Name = "txtPayrollIdNo"
        Me.txtPayrollIdNo.OldValue = Nothing
        Me.txtPayrollIdNo.ReadOnly = true
        Me.txtPayrollIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollIdNo.TabStop = false
        Me.txtPayrollIdNo.Translatable = false
        '
        'lblPayrollCode
        '
        Me.lblPayrollCode.DisplayOnly = true
        Me.lblPayrollCode.EditingMode = false
        resources.ApplyResources(Me.lblPayrollCode, "lblPayrollCode")
        Me.lblPayrollCode.Name = "lblPayrollCode"
        Me.lblPayrollCode.Translatable = true
        '
        'txtPayrollCode
        '
        Me.txtPayrollCode.BackColor = System.Drawing.Color.White
        Me.txtPayrollCode.BegFindValue = Nothing
        Me.txtPayrollCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollCode.ComputedValue = false
        Me.txtPayrollCode.CustomFormat = Nothing
        Me.txtPayrollCode.DataBoundControl = true
        Me.txtPayrollCode.DisplayOnly = true
        Me.txtPayrollCode.EditingMode = true
        Me.txtPayrollCode.EndFindValue = Nothing
        Me.txtPayrollCode.FieldDescription = Nothing
        Me.txtPayrollCode.FieldName = Nothing
        Me.txtPayrollCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollCode.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtPayrollCode, true)
        resources.ApplyResources(Me.txtPayrollCode, "txtPayrollCode")
        Me.txtPayrollCode.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollCode.LinkedLabel = Nothing
        Me.txtPayrollCode.MaximumValue = Nothing
        Me.txtPayrollCode.MinimumValue = Nothing
        Me.txtPayrollCode.Name = "txtPayrollCode"
        Me.txtPayrollCode.OldValue = Nothing
        Me.txtPayrollCode.ReadOnly = true
        Me.txtPayrollCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollCode.TabStop = false
        Me.txtPayrollCode.Translatable = false
        '
        'lblPayrollStartDate
        '
        Me.lblPayrollStartDate.DisplayOnly = true
        Me.lblPayrollStartDate.EditingMode = false
        resources.ApplyResources(Me.lblPayrollStartDate, "lblPayrollStartDate")
        Me.lblPayrollStartDate.Name = "lblPayrollStartDate"
        Me.lblPayrollStartDate.Translatable = true
        '
        'txtPayrollStartDate
        '
        Me.txtPayrollStartDate.BackColor = System.Drawing.Color.White
        Me.txtPayrollStartDate.BegFindValue = Nothing
        Me.txtPayrollStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollStartDate.ComputedValue = false
        Me.txtPayrollStartDate.CustomFormat = Nothing
        Me.txtPayrollStartDate.DataBoundControl = true
        Me.txtPayrollStartDate.DisplayOnly = true
        Me.txtPayrollStartDate.EditingMode = true
        Me.txtPayrollStartDate.EndFindValue = Nothing
        Me.txtPayrollStartDate.FieldDescription = Nothing
        Me.txtPayrollStartDate.FieldName = Nothing
        Me.txtPayrollStartDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollStartDate.FindEnabled = false
        resources.ApplyResources(Me.txtPayrollStartDate, "txtPayrollStartDate")
        Me.txtPayrollStartDate.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollStartDate.LinkedLabel = Me.lblPayrollStartDate
        Me.txtPayrollStartDate.MaximumValue = Nothing
        Me.txtPayrollStartDate.MinimumValue = Nothing
        Me.txtPayrollStartDate.Name = "txtPayrollStartDate"
        Me.txtPayrollStartDate.OldValue = Nothing
        Me.txtPayrollStartDate.ReadOnly = true
        Me.txtPayrollStartDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollStartDate.Translatable = false
        Me.txtPayrollStartDate.ValueIsMandatory = true
        '
        'lblPayrollEndDate
        '
        Me.lblPayrollEndDate.DisplayOnly = true
        Me.lblPayrollEndDate.EditingMode = false
        resources.ApplyResources(Me.lblPayrollEndDate, "lblPayrollEndDate")
        Me.lblPayrollEndDate.Name = "lblPayrollEndDate"
        Me.lblPayrollEndDate.Translatable = true
        '
        'txtPayrollEndDate
        '
        Me.txtPayrollEndDate.BackColor = System.Drawing.Color.White
        Me.txtPayrollEndDate.BegFindValue = Nothing
        Me.txtPayrollEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollEndDate.ComputedValue = false
        Me.txtPayrollEndDate.CustomFormat = Nothing
        Me.txtPayrollEndDate.DataBoundControl = true
        Me.txtPayrollEndDate.DisplayOnly = true
        Me.txtPayrollEndDate.EditingMode = true
        Me.txtPayrollEndDate.EndFindValue = Nothing
        Me.txtPayrollEndDate.FieldDescription = Nothing
        Me.txtPayrollEndDate.FieldName = Nothing
        Me.txtPayrollEndDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollEndDate.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtPayrollEndDate, true)
        resources.ApplyResources(Me.txtPayrollEndDate, "txtPayrollEndDate")
        Me.txtPayrollEndDate.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollEndDate.LinkedLabel = Me.lblPayrollEndDate
        Me.txtPayrollEndDate.MaximumValue = Nothing
        Me.txtPayrollEndDate.MinimumValue = Nothing
        Me.txtPayrollEndDate.Name = "txtPayrollEndDate"
        Me.txtPayrollEndDate.OldValue = Nothing
        Me.txtPayrollEndDate.ReadOnly = true
        Me.txtPayrollEndDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollEndDate.Translatable = false
        Me.txtPayrollEndDate.ValueIsMandatory = true
        '
        'lblPayrollName
        '
        Me.lblPayrollName.DisplayOnly = true
        Me.lblPayrollName.EditingMode = false
        resources.ApplyResources(Me.lblPayrollName, "lblPayrollName")
        Me.lblPayrollName.Name = "lblPayrollName"
        Me.lblPayrollName.Translatable = true
        '
        'txtPayrollName
        '
        Me.txtPayrollName.BackColor = System.Drawing.Color.White
        Me.txtPayrollName.BegFindValue = Nothing
        Me.txtPayrollName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollName.ComputedValue = false
        Me.txtPayrollName.CustomFormat = Nothing
        Me.txtPayrollName.DataBoundControl = true
        Me.txtPayrollName.DisplayOnly = true
        Me.txtPayrollName.EditingMode = true
        Me.txtPayrollName.EndFindValue = Nothing
        Me.txtPayrollName.FieldDescription = Nothing
        Me.txtPayrollName.FieldName = Nothing
        Me.txtPayrollName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollName.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtPayrollName, true)
        resources.ApplyResources(Me.txtPayrollName, "txtPayrollName")
        Me.txtPayrollName.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollName.LinkedLabel = Nothing
        Me.txtPayrollName.MaximumValue = Nothing
        Me.txtPayrollName.MinimumValue = Nothing
        Me.txtPayrollName.Name = "txtPayrollName"
        Me.txtPayrollName.OldValue = Nothing
        Me.txtPayrollName.ReadOnly = true
        Me.txtPayrollName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollName.TabStop = false
        Me.txtPayrollName.Translatable = false
        Me.txtPayrollName.ValueIsMandatory = true
        '
        'lblNote
        '
        Me.lblNote.BackColor = System.Drawing.Color.Transparent
        Me.lblNote.DisplayOnly = true
        Me.lblNote.EditingMode = false
        resources.ApplyResources(Me.lblNote, "lblNote")
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Translatable = true
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.BegFindValue = Nothing
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.ComputedValue = false
        Me.txtDescription.CustomFormat = Nothing
        Me.txtDescription.DataBoundControl = true
        Me.txtDescription.EditingMode = true
        Me.txtDescription.EndFindValue = Nothing
        Me.txtDescription.FieldDescription = Nothing
        Me.txtDescription.FieldName = Nothing
        Me.txtDescription.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDescription.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtDescription, true)
        resources.ApplyResources(Me.txtDescription, "txtDescription")
        Me.txtDescription.ForeColor = System.Drawing.Color.Black
        Me.txtDescription.LinkedLabel = Me.lblNote
        Me.txtDescription.MaximumValue = Nothing
        Me.txtDescription.MinimumValue = Nothing
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.OldValue = Nothing
        Me.txtDescription.ReadOnly = true
        Me.txtDescription.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDescription.Translatable = false
        Me.txtDescription.ValueIsMandatory = true
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
        'dtpDateStart
        '
        Me.dtpDateStart.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateStart.DefaultValue = Nothing
        Me.dtpDateStart.DisplayOnly = false
        Me.dtpDateStart.DtpDefaultValue = Nothing
        Me.dtpDateStart.EditingMode = true
        Me.dtpDateStart.EditsAllowed = false
        Me.CFlowLayout2.SetFlowBreak(Me.dtpDateStart, true)
        Me.dtpDateStart.ForeColor = System.Drawing.Color.Black
        Me.dtpDateStart.LinkedLabel = Me.lblStartDate
        resources.ApplyResources(Me.dtpDateStart, "dtpDateStart")
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.ReadOnlyDp = false
        Me.dtpDateStart.SecurityKey = Nothing
        Me.dtpDateStart.ShowLongDate = false
        Me.dtpDateStart.ShowTime = false
        Me.dtpDateStart.TargetCalendar = Nothing
        Me.dtpDateStart.Translatable = false
        Me.dtpDateStart.Value = Nothing
        Me.dtpDateStart.ValueIsMandatory = false
        Me.dtpDateStart.ValueIsNullable = false
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
        'dtpDateEnd
        '
        Me.dtpDateEnd.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateEnd.DefaultValue = Nothing
        Me.dtpDateEnd.DisplayOnly = false
        Me.dtpDateEnd.DtpDefaultValue = Nothing
        Me.dtpDateEnd.EditingMode = true
        Me.dtpDateEnd.EditsAllowed = false
        Me.CFlowLayout2.SetFlowBreak(Me.dtpDateEnd, true)
        Me.dtpDateEnd.ForeColor = System.Drawing.Color.Black
        Me.dtpDateEnd.LinkedLabel = Me.lblEndDate
        resources.ApplyResources(Me.dtpDateEnd, "dtpDateEnd")
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.ReadOnlyDp = false
        Me.dtpDateEnd.SecurityKey = Nothing
        Me.dtpDateEnd.ShowLongDate = false
        Me.dtpDateEnd.ShowTime = false
        Me.dtpDateEnd.TargetCalendar = Nothing
        Me.dtpDateEnd.Translatable = false
        Me.dtpDateEnd.Value = Nothing
        Me.dtpDateEnd.ValueIsMandatory = false
        Me.dtpDateEnd.ValueIsNullable = false
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
        Me.txtDateCreated.LinkedLabel = Nothing
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.ReadOnly = true
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.Translatable = false
        Me.txtDateCreated.ValueIsMandatory = true
        '
        'HolidayEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        Me.Controls.Add(Me.CFlowLayout2)
        Me.Name = "HolidayEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents lblIdNo As CLabel
        Public WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblLeaveIdNo As CLabel
        Public WithEvents cboLeaveIdNo As CaComboBox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblNote As CLabel
        Public WithEvents txtDescription As CTextBox
        Friend WithEvents lblPayrollIdNo As CLabel
        Friend WithEvents txtPayrollIdNo As CTextBox
        Friend WithEvents lblPayrollStartDate As CLabel
        Public WithEvents txtPayrollStartDate As CTextBox
        Friend WithEvents lblPayrollEndDate As CLabel
        Public WithEvents txtPayrollEndDate As CTextBox
        Friend WithEvents lblPayrollName As CLabel
        Friend WithEvents txtPayrollName As CTextBox
        Friend WithEvents lblPayrollCode As CLabel
        Friend WithEvents txtPayrollCode As CTextBox
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents lblStartDate As CLabel
        Public WithEvents dtpDateStart As CCustomDateTimePicker
        Friend WithEvents lblEndDate As CLabel
        Public WithEvents dtpDateEnd As CCustomDateTimePicker
    End Class
End Namespace