Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Presentation.Forms

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
        Me.cboLeaveIdNo = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateStart = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateEnd = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblEnteredBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEnteredBy = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
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
        Me.CFlowLayout2.Controls.Add(Me.lblLeaveIdNo)
        Me.CFlowLayout2.Controls.Add(Me.cboLeaveIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblStartDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpDateStart)
        Me.CFlowLayout2.Controls.Add(Me.lblEndDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpDateEnd)
        Me.CFlowLayout2.Controls.Add(Me.lblEnteredBy)
        Me.CFlowLayout2.Controls.Add(Me.cboEnteredBy)
        Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
        Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
        resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
        Me.CFlowLayout2.Name = "CFlowLayout2"
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
        'lblEnteredBy
        '
        Me.lblEnteredBy.BackColor = System.Drawing.Color.Transparent
        Me.lblEnteredBy.DisplayOnly = true
        Me.lblEnteredBy.EditingMode = false
        resources.ApplyResources(Me.lblEnteredBy, "lblEnteredBy")
        Me.lblEnteredBy.Name = "lblEnteredBy"
        Me.lblEnteredBy.Translatable = true
        '
        'cboEnteredBy
        '
        Me.cboEnteredBy.BackColor = System.Drawing.Color.White
        Me.cboEnteredBy.BegFindValue = Nothing
        Me.cboEnteredBy.ChangingSearchValueOnly = false
        Me.cboEnteredBy.CurrentSearchTerm = ""
        Me.cboEnteredBy.DefaultValue = Nothing
        Me.cboEnteredBy.DisplayMember = "Name"
        Me.cboEnteredBy.DisplayOnly = true
        Me.cboEnteredBy.DropDownHeight = 24
        Me.cboEnteredBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboEnteredBy.EditingMode = true
        Me.cboEnteredBy.EndFindValue = Nothing
        Me.cboEnteredBy.FieldDescription = Nothing
        Me.cboEnteredBy.FieldName = Nothing
        Me.cboEnteredBy.FilterRule = Nothing
        Me.cboEnteredBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboEnteredBy.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.cboEnteredBy, true)
        resources.ApplyResources(Me.cboEnteredBy, "cboEnteredBy")
        Me.cboEnteredBy.ForeColor = System.Drawing.Color.Black
        Me.cboEnteredBy.FormattingEnabled = true
        Me.cboEnteredBy.HideWhenNotEditingOrAdding = false
        Me.cboEnteredBy.IgnoreCase = false
        Me.cboEnteredBy.LinkedLabel = Me.lblEnteredBy
        Me.cboEnteredBy.Name = "cboEnteredBy"
        Me.cboEnteredBy.OldValue = 0
        Me.cboEnteredBy.OriginalDataSource = Nothing
        Me.cboEnteredBy.OriginalList = Nothing
        Me.cboEnteredBy.OverrideDropDownStyleList = false
        Me.cboEnteredBy.PreviousSearchTerm = Nothing
        Me.cboEnteredBy.PropertySelector = Nothing
            Me.cboEnteredBy.SuggestBoxHeight = 200
            Me.cboEnteredBy.SuggestListOrderRule = Nothing
        Me.cboEnteredBy.TextToSearch = Nothing
        Me.cboEnteredBy.Translatable = false
        Me.cboEnteredBy.ValueIsMandatory = false
        Me.cboEnteredBy.ValueIsNullable = false
        Me.cboEnteredBy.ValueIsNumeric = false
        Me.cboEnteredBy.ValueMember = "IdNo"
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
        Public WithEvents cboLeaveIdNo As CtCombobox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents lblStartDate As CLabel
        Public WithEvents dtpDateStart As CCustomDateTimePicker
        Friend WithEvents lblEndDate As CLabel
        Public WithEvents dtpDateEnd As CCustomDateTimePicker
        Friend WithEvents lblEnteredBy As CLabel
        Public WithEvents cboEnteredBy As CtCombobox
    End Class
End Namespace