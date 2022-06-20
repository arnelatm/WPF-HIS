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
        Me.lblHolidayIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtStartDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtEndDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNote = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNote = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtLeaveNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
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
        'lblHolidayIdNo
        '
        Me.lblHolidayIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblHolidayIdNo.DisplayOnly = true
        Me.lblHolidayIdNo.EditingMode = false
        resources.ApplyResources(Me.lblHolidayIdNo, "lblHolidayIdNo")
        Me.lblHolidayIdNo.Name = "lblHolidayIdNo"
        Me.lblHolidayIdNo.Translatable = true
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
        Me.CFlowLayout2.Controls.Add(Me.lblStartDate)
        Me.CFlowLayout2.Controls.Add(Me.txtStartDate)
        Me.CFlowLayout2.Controls.Add(Me.lblEndDate)
        Me.CFlowLayout2.Controls.Add(Me.txtEndDate)
        Me.CFlowLayout2.Controls.Add(Me.lblPayrollName)
        Me.CFlowLayout2.Controls.Add(Me.txtPayrollName)
        Me.CFlowLayout2.Controls.Add(Me.lblHolidayIdNo)
        Me.CFlowLayout2.Controls.Add(Me.CTextBox1)
        Me.CFlowLayout2.Controls.Add(Me.CLabel1)
        Me.CFlowLayout2.Controls.Add(Me.txtLeaveNameAra)
        Me.CFlowLayout2.Controls.Add(Me.CLabel2)
        Me.CFlowLayout2.Controls.Add(Me.dtpStartDate)
        Me.CFlowLayout2.Controls.Add(Me.CLabel3)
        Me.CFlowLayout2.Controls.Add(Me.dtpEndDate)
        Me.CFlowLayout2.Controls.Add(Me.lblNote)
        Me.CFlowLayout2.Controls.Add(Me.txtNote)
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
        'lblStartDate
        '
        Me.lblStartDate.DisplayOnly = true
        Me.lblStartDate.EditingMode = false
        resources.ApplyResources(Me.lblStartDate, "lblStartDate")
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Translatable = true
        '
        'txtStartDate
        '
        Me.txtStartDate.BackColor = System.Drawing.Color.White
        Me.txtStartDate.BegFindValue = Nothing
        Me.txtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartDate.ComputedValue = false
        Me.txtStartDate.CustomFormat = Nothing
        Me.txtStartDate.DataBoundControl = true
        Me.txtStartDate.DisplayOnly = true
        Me.txtStartDate.EditingMode = true
        Me.txtStartDate.EndFindValue = Nothing
        Me.txtStartDate.FieldDescription = Nothing
        Me.txtStartDate.FieldName = Nothing
        Me.txtStartDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtStartDate.FindEnabled = false
        resources.ApplyResources(Me.txtStartDate, "txtStartDate")
        Me.txtStartDate.ForeColor = System.Drawing.Color.Black
        Me.txtStartDate.LinkedLabel = Me.lblStartDate
        Me.txtStartDate.MaximumValue = Nothing
        Me.txtStartDate.MinimumValue = Nothing
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.OldValue = Nothing
        Me.txtStartDate.ReadOnly = true
        Me.txtStartDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtStartDate.Translatable = false
        Me.txtStartDate.ValueIsMandatory = true
        '
        'lblEndDate
        '
        Me.lblEndDate.DisplayOnly = true
        Me.lblEndDate.EditingMode = false
        resources.ApplyResources(Me.lblEndDate, "lblEndDate")
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Translatable = true
        '
        'txtEndDate
        '
        Me.txtEndDate.BackColor = System.Drawing.Color.White
        Me.txtEndDate.BegFindValue = Nothing
        Me.txtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndDate.ComputedValue = false
        Me.txtEndDate.CustomFormat = Nothing
        Me.txtEndDate.DataBoundControl = true
        Me.txtEndDate.DisplayOnly = true
        Me.txtEndDate.EditingMode = true
        Me.txtEndDate.EndFindValue = Nothing
        Me.txtEndDate.FieldDescription = Nothing
        Me.txtEndDate.FieldName = Nothing
        Me.txtEndDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtEndDate.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtEndDate, true)
        resources.ApplyResources(Me.txtEndDate, "txtEndDate")
        Me.txtEndDate.ForeColor = System.Drawing.Color.Black
        Me.txtEndDate.LinkedLabel = Me.lblEndDate
        Me.txtEndDate.MaximumValue = Nothing
        Me.txtEndDate.MinimumValue = Nothing
        Me.txtEndDate.Name = "txtEndDate"
        Me.txtEndDate.OldValue = Nothing
        Me.txtEndDate.ReadOnly = true
        Me.txtEndDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtEndDate.Translatable = false
        Me.txtEndDate.ValueIsMandatory = true
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
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.Color.White
        Me.txtNote.BegFindValue = Nothing
        Me.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNote.ComputedValue = false
        Me.txtNote.CustomFormat = Nothing
        Me.txtNote.DataBoundControl = true
        Me.txtNote.EditingMode = true
        Me.txtNote.EndFindValue = Nothing
        Me.txtNote.FieldDescription = Nothing
        Me.txtNote.FieldName = Nothing
        Me.txtNote.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNote.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtNote, true)
        resources.ApplyResources(Me.txtNote, "txtNote")
        Me.txtNote.ForeColor = System.Drawing.Color.Black
        Me.txtNote.LinkedLabel = Me.lblNote
        Me.txtNote.MaximumValue = Nothing
        Me.txtNote.MinimumValue = Nothing
        Me.txtNote.Name = "txtNote"
        Me.txtNote.OldValue = Nothing
        Me.txtNote.ReadOnly = true
        Me.txtNote.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNote.Translatable = false
        Me.txtNote.ValueIsMandatory = true
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
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.ReadOnly = true
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.Translatable = false
        Me.txtDateCreated.ValueIsMandatory = true
        '
        'CTextBox1
        '
        Me.CTextBox1.BackColor = System.Drawing.Color.White
        Me.CTextBox1.BegFindValue = Nothing
        Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox1.ComputedValue = false
        Me.CTextBox1.CustomFormat = Nothing
        Me.CTextBox1.DataBoundControl = true
        Me.CTextBox1.DisplayOnly = true
        Me.CTextBox1.EditingMode = true
        Me.CTextBox1.EndFindValue = Nothing
        Me.CTextBox1.FieldDescription = Nothing
        Me.CTextBox1.FieldName = Nothing
        Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CTextBox1.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.CTextBox1, true)
        resources.ApplyResources(Me.CTextBox1, "CTextBox1")
        Me.CTextBox1.ForeColor = System.Drawing.Color.Black
        Me.CTextBox1.LinkedLabel = Nothing
        Me.CTextBox1.MaximumValue = Nothing
        Me.CTextBox1.MinimumValue = Nothing
        Me.CTextBox1.Name = "CTextBox1"
        Me.CTextBox1.OldValue = Nothing
        Me.CTextBox1.ReadOnly = true
        Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CTextBox1.TabStop = false
        Me.CTextBox1.Translatable = false
        Me.CTextBox1.ValueIsMandatory = true
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
        'txtLeaveNameAra
        '
        Me.txtLeaveNameAra.BackColor = System.Drawing.Color.White
        Me.txtLeaveNameAra.BegFindValue = Nothing
        Me.txtLeaveNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLeaveNameAra.ComputedValue = false
        Me.txtLeaveNameAra.CustomFormat = Nothing
        Me.txtLeaveNameAra.DataBoundControl = true
        Me.txtLeaveNameAra.EditingMode = false
        Me.txtLeaveNameAra.EndFindValue = Nothing
        Me.txtLeaveNameAra.EnglishControl = Nothing
        Me.txtLeaveNameAra.FieldDescription = Nothing
        Me.txtLeaveNameAra.FieldName = Nothing
        Me.txtLeaveNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLeaveNameAra.FindEnabled = true
        resources.ApplyResources(Me.txtLeaveNameAra, "txtLeaveNameAra")
        Me.txtLeaveNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtLeaveNameAra.LinkedLabel = Nothing
        Me.txtLeaveNameAra.MaximumValue = Nothing
        Me.txtLeaveNameAra.MinimumValue = Nothing
        Me.txtLeaveNameAra.Name = "txtLeaveNameAra"
        Me.txtLeaveNameAra.OldValue = Nothing
        Me.txtLeaveNameAra.ReadOnly = true
        Me.txtLeaveNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLeaveNameAra.Translatable = false
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
        Me.dtpStartDate.LinkedLabel = Me.CLabel2
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
        'CLabel3
        '
        Me.CLabel3.BackColor = System.Drawing.Color.Transparent
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        resources.ApplyResources(Me.CLabel3, "CLabel3")
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Translatable = true
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
        Me.dtpEndDate.LinkedLabel = Me.CLabel3
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
        Friend WithEvents lblHolidayIdNo As CLabel
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblNote As CLabel
        Public WithEvents txtNote As CTextBox
        Friend WithEvents lblPayrollIdNo As CLabel
        Friend WithEvents txtPayrollIdNo As CTextBox
        Friend WithEvents lblStartDate As CLabel
        Public WithEvents txtStartDate As CTextBox
        Friend WithEvents lblEndDate As CLabel
        Public WithEvents txtEndDate As CTextBox
        Friend WithEvents lblPayrollName As CLabel
        Friend WithEvents txtPayrollName As CTextBox
        Friend WithEvents lblPayrollCode As CLabel
        Friend WithEvents txtPayrollCode As CTextBox
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents CTextBox1 As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtLeaveNameAra As CTextBoxArabic
        Friend WithEvents CLabel2 As CLabel
        Public WithEvents dtpStartDate As CCustomDateTimePicker
        Friend WithEvents CLabel3 As CLabel
        Public WithEvents dtpEndDate As CCustomDateTimePicker
    End Class
End Namespace